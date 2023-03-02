using Grpc.Core;
using ImGui.Forms.Controls;
using ImGui.Forms.Controls.Layouts;
using ImGui.Forms.Modals;
using ImGui.Forms.Modals.IO;
using ImGui.Forms.Models;
using NierReincarnation.App.Controls.Buttons;
using NierReincarnation.App.Resources;
using NierReincarnation.Context;
using NierReincarnation.Core.Octo.Data;
using NierReincarnation.Core.UnityEngine;
using Serilog;
using System;
using System.Drawing;
using System.Numerics;
using System.Threading.Tasks;

namespace NierReincarnation.App.Dialogs
{
    internal class SetupApplicationDialog : Modal
    {
        private AssetContext _assetContext;

        public SetupApplicationDialog()
        {
            Result = DialogResult.Cancel;

            Size = new Vector2(200, 100);
            Caption = LocalizationResources.StartupTitle;
        }

        protected override async void ShowInternal()
        {
            // Setup error handler
            NierReincarnation.ApiError += NierReincarnationApiError;

            // Ensure application being setup
            await EnsureSetup();

            // Ensure user being logged in
            await SetupLogin();
        }

        private async Task AfterLogin()
        {
            // Ensure data being initialized
            var isInitialized = await EnsureInitialized();
            if (!isInitialized)
            {
                await MessageBox.ShowInformationAsync(LocalizationResources.MissingDataTitle, LocalizationResources.MissingDataDescription);

                Close(DialogResult.Cancel);
                return;
            }

            _assetContext = NierReincarnation.Assets;

            // Ensure text assets
            await EnsureTextAssets(Application.Language);

            // Ensure icon assets
            await EnsureIconAssets();

            // Remove error handler
            NierReincarnation.ApiError -= NierReincarnationApiError;

            // Close modal
            Close(DialogResult.Ok);
        }

        private async Task<bool> NierReincarnationApiError(RpcException e)
        {
            Log.Fatal(e, "API error on initialization.");

            switch (e.StatusCode)
            {
                // Catch new version precondition error and close application after
                case StatusCode.FailedPrecondition:
                    var dlg = new VersionMaintenanceDialog();
                    await dlg.ShowAsync();

                    return false;

                default:
                    return true;
            }
        }

        #region Setup

        private async Task EnsureSetup()
        {
            // Set setup design
            SetupSetupDialog();

            // Setup application
            await Task.Run(NierReincarnation.Setup);
        }

        #endregion Setup

        #region Login

        private async Task SetupLogin()
        {
            if (NierReincarnation.IsLoggedIn())
            {
                await AfterLogin();
                return;
            }

            // Set login design
            SetupLoginLayout();
        }

        private Task<bool> TryLogin(string username, string password)
        {
            return Task.Run(async () =>
            {
                try
                {
                    return await NierReincarnation.Login(username, password, ReceiveOtp);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Log.Fatal(e, "Login exception");

                    return false;
                }
            });
        }

        private Task<string> ReceiveOtp()
        {
            return InputBox.ShowAsync(LocalizationResources.OtpTitle, LocalizationResources.OtpDescription);
        }

        #endregion Login

        #region Initialize

        private async Task<bool> EnsureInitialized()
        {
            // Set setup design
            SetupInitializeLayout();

            // Setup application
            await Task.Run(NierReincarnation.Initialize);

            return NierReincarnation.IsInitialized;
        }

        #endregion Initialize

        #region Assets

        private async Task EnsureTextAssets(Language language)
        {
            var assetCount = _assetContext.GetTextAssetCount(language);
            var assetSize = _assetContext.GetTextAssetSize(language);

            // Set setup design
            SetupAssetDownloadLayout(LocalizationResources.DownloadTexts, assetCount, assetSize);

            // Download assets
            await NierReincarnation.LoadLocalizations(language);
        }

        private async Task EnsureIconAssets()
        {
            // Ensure every small icon for characters, weapons, etc
            static bool IconSelector(Item i) => i.name.EndsWith("standard") &&
                                         (i.name.StartsWith("ui)weapon)") ||
                                          i.name.StartsWith("ui)costume)") ||
                                          i.name.StartsWith("ui)companion)") ||
                                          i.name.StartsWith("ui)thought)") ||
                                          i.name.StartsWith("ui)memory)") ||
                                          i.name.StartsWith("ui)consumable_item)") ||
                                          i.name.StartsWith("ui)world_map)map)wm_map_image_"));

            var assetCount = _assetContext.GetAssetCount(IconSelector);
            var assetSize = _assetContext.GetAssetSize(IconSelector);

            // Set setup design
            SetupAssetDownloadLayout(LocalizationResources.DownloadIcons, assetCount, assetSize);

            // Download assets
            await _assetContext.DownloadAssets(IconSelector);
        }

        #endregion Assets

        #region Create layouts

        private void SetupSetupDialog()
        {
            Content = new StackLayout
            {
                Alignment = Alignment.Horizontal,
                Items =
                {
                    new StackItem(new Label {Text = LocalizationResources.SetupDescription})
                    {
                        HorizontalAlignment = HorizontalAlignment.Center,
                        VerticalAlignment = VerticalAlignment.Center,
                        Size = ImGui.Forms.Models.Size.Parent
                    }
                }
            };
        }

        private void SetupLoginLayout()
        {
            var username = string.Empty;
            var password = string.Empty;

            var errMsg = new Label { TextColor = Color.Firebrick };
            var userBox = new TextBox { Width = SizeValue.Relative(1) };
            var passBox = new TextBox { Width = SizeValue.Relative(1), IsMasked = true };
            var loginBtn = new NierButton { Text = LocalizationResources.LoginButton };

            userBox.TextChanged += (s, e) => username = userBox.Text;
            passBox.TextChanged += (s, e) => password = passBox.Text;
            loginBtn.Clicked += async (s, e) =>
            {
                errMsg.Text = string.Empty;

                userBox.IsReadOnly = true;
                passBox.IsReadOnly = true;
                loginBtn.Enabled = false;

                var isLoggedIn = await TryLogin(username, password);
                if (!isLoggedIn)
                    errMsg.Text = LocalizationResources.LoginError;

                userBox.IsReadOnly = false;
                passBox.IsReadOnly = false;
                loginBtn.Enabled = true;

                if (isLoggedIn)
                    await AfterLogin();
            };

            Caption = LocalizationResources.LoginTitle;
            Content = new StackLayout
            {
                Alignment = Alignment.Vertical,
                ItemSpacing = 3,
                Items =
                {
                    new StackItem(errMsg){HorizontalAlignment = HorizontalAlignment.Center},
                    new TableLayout
                    {
                        Spacing = new Vector2(3,3),
                        Rows =
                        {
                            new TableRow
                            {
                                Cells =
                                {
                                    new Label {Text = LocalizationResources.LoginUsername},
                                    userBox
                                }
                            },
                            new TableRow
                            {
                                Cells =
                                {
                                    new Label {Text = LocalizationResources.LoginPassword},
                                    passBox
                                }
                            }
                        }
                    },
                    new StackItem(loginBtn) {HorizontalAlignment = HorizontalAlignment.Right}
                }
            };
        }

        private void SetupInitializeLayout()
        {
            Content = new StackLayout
            {
                Alignment = Alignment.Horizontal,
                Items =
                {
                    new StackItem(new Label {Text = LocalizationResources.DataDescription})
                    {
                        HorizontalAlignment = HorizontalAlignment.Center,
                        VerticalAlignment = VerticalAlignment.Center,
                        Size = ImGui.Forms.Models.Size.Parent
                    }
                }
            };
        }

        private void SetupAssetDownloadLayout(string itemName, int assetCount, int assetSize)
        {
            Size = new Vector2(250, 100);
            Content = new StackLayout
            {
                Alignment = Alignment.Horizontal,
                Items =
                {
                    new StackItem(new Label {Text = string.Format(LocalizationResources.DownloadDescription,assetCount,itemName,assetSize/1024f/1024)})
                    {
                        HorizontalAlignment = HorizontalAlignment.Center,
                        VerticalAlignment = VerticalAlignment.Center,
                        Size = ImGui.Forms.Models.Size.Parent
                    }
                }
            };
        }

        #endregion Create layouts
    }
}
