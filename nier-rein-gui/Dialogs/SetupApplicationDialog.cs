using System;
using System.Drawing;
using System.Numerics;
using System.Threading.Tasks;
using Grpc.Core;
using ImGui.Forms.Controls;
using ImGui.Forms.Controls.Layouts;
using ImGui.Forms.Modals;
using ImGui.Forms.Models;
using nier_rein_gui.Controls.Buttons;
using NierReincarnation.Context;
using NierReincarnation.Core.Octo.Data;
using NierReincarnation.Core.UnityEngine;
using Serilog;

namespace nier_rein_gui.Dialogs
{
    class SetupApplicationDialog : Modal
    {
        private AssetContext _assetContext;

        public SetupApplicationDialog()
        {
            Result = DialogResult.Cancel;

            Size = new Vector2(200, 100);
            Caption = "Startup";
        }

        protected override async void ShowInternal()
        {
            // Setup error handler
            NierReincarnation.NierReincarnation.ApiError += NierReincarnationApiError;

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
                await MessageBox.ShowInformationAsync("Missing data", "Could not retrieve some data. Application will be closed.\nRe-Open the application to try again.");

                Close(DialogResult.Cancel);
                return;
            }

            _assetContext = NierReincarnation.NierReincarnation.GetContexts().Assets;

            // Ensure text assets
            await EnsureTextAssets(Application.Language);

            // Ensure icon assets
            await EnsureIconAssets();

            // Remove error handler
            NierReincarnation.NierReincarnation.ApiError -= NierReincarnationApiError;

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
            await Task.Run(NierReincarnation.NierReincarnation.Setup);
        }

        #endregion

        #region Login

        private async Task SetupLogin()
        {
            if (NierReincarnation.NierReincarnation.IsLoggedIn())
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
                    await NierReincarnation.NierReincarnation.Login(username, password);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Log.Fatal(e, "Login exception");

                    return false;
                }

                return true;
            });
        }

        #endregion

        #region Initialize

        private async Task<bool> EnsureInitialized()
        {
            // Set setup design
            SetupInitializeLayout();

            // Setup application
            await Task.Run(NierReincarnation.NierReincarnation.Initialize);

            return NierReincarnation.NierReincarnation.IsInitialized;
        }

        #endregion

        #region Assets

        private async Task EnsureTextAssets(Language language)
        {
            var assetCount = _assetContext.GetTextAssetCount(language);
            var assetSize = _assetContext.GetTextAssetSize(language);

            // Set setup design
            SetupAssetDownloadLayout("text files", assetCount, assetSize);

            // Download assets
            await NierReincarnation.NierReincarnation.LoadLocalizations(language);
        }

        private async Task EnsureIconAssets()
        {
            // Ensure every small icon for characters, weapons, etc
            bool IconSelector(Item i) => i.name.EndsWith("standard") &&
                                         (i.name.StartsWith("ui)weapon)") ||
                                          i.name.StartsWith("ui)costume)") ||
                                          i.name.StartsWith("ui)companion)") ||
                                          i.name.StartsWith("ui)memory)")||
                                          i.name.StartsWith("ui)consumable_item)"));

            var assetCount = _assetContext.GetAssetCount(IconSelector);
            var assetSize = _assetContext.GetAssetSize(IconSelector);

            // Set setup design
            SetupAssetDownloadLayout("icons", assetCount, assetSize);

            // Download assets
            await _assetContext.DownloadAssets(IconSelector);
        }

        #endregion

        #region Create layouts

        private void SetupSetupDialog()
        {
            Content = new StackLayout
            {
                Alignment = Alignment.Horizontal,
                Items =
                {
                    new StackItem(new Label {Caption = "Setup application..."})
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
            var loginBtn = new NierButton { Caption = "Login" };

            userBox.TextChanged += (s, e) => username = userBox.Text;
            passBox.TextChanged += (s, e) => password = passBox.Text;
            loginBtn.Clicked += async (s, e) =>
            {
                errMsg.Caption = string.Empty;

                userBox.IsReadOnly = true;
                passBox.IsReadOnly = true;
                loginBtn.Enabled = false;

                var isLoggedIn = await TryLogin(username, password);
                if (!isLoggedIn)
                    errMsg.Caption = "Couldn't login.";

                userBox.IsReadOnly = false;
                passBox.IsReadOnly = false;
                loginBtn.Enabled = true;

                if (isLoggedIn)
                    await AfterLogin();
            };

            Caption = "Login";
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
                                    new Label {Caption = "Username:"},
                                    userBox
                                }
                            },
                            new TableRow
                            {
                                Cells =
                                {
                                    new Label {Caption = "Password:"},
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
                    new StackItem(new Label {Caption = "Initialize data..."})
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
                    new StackItem(new Label {Caption = $"Download {assetCount} {itemName} ({assetSize/1024f/1024:0.0}MB) ..."})
                    {
                        HorizontalAlignment = HorizontalAlignment.Center,
                        VerticalAlignment = VerticalAlignment.Center,
                        Size = ImGui.Forms.Models.Size.Parent
                    }
                }
            };
        }

        #endregion
    }
}
