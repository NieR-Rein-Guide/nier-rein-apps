using System;
using System.Drawing;
using System.Numerics;
using System.Threading.Tasks;
using ImGui.Forms.Controls;
using ImGui.Forms.Controls.Layouts;
using ImGui.Forms.Modals;
using ImGui.Forms.Models;
using nier_rein_gui.Controls;
using NierReincarnation.Localizations;

namespace nier_rein_gui.Dialogs
{
    class SetupApplicationDialog : Modal
    {
        public SetupApplicationDialog()
        {
            Result = DialogResult.Cancel;

            Size = new Vector2(200, 100);
            Caption = "Startup";
            Content = new Label { Caption = "Setup application..." };
        }

        protected override async void ShowInternal()
        {
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
                Close(DialogResult.Cancel);
                return;
            }

            // Ensure text assets
            await EnsureTextAssets(Language.En);

            // Close modal
            Close(DialogResult.Ok);
        }

        #region Setup

        private async Task EnsureSetup()
        {
            // Set setup design
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

            // Setup application
            await Task.Run(NierReincarnation.NierReincarnation.Setup);
        }

        #endregion

        #region Login

        private string _username;
        private string _password;

        private TextBox _userBox;
        private TextBox _passBox;
        private Button _loginBtn;
        private Label _errMsg;

        private async Task SetupLogin()
        {
            if (NierReincarnation.NierReincarnation.IsLoggedIn())
            {
                await AfterLogin();
                return;
            }

            // Set login design
            _errMsg = new Label { TextColor = Color.Firebrick };
            _userBox = new TextBox { Width = SizeValue.Relative(1) };
            _passBox = new TextBox { Width = SizeValue.Relative(1), IsMasked = true };
            _loginBtn = new NierButton { Caption = "Login" };

            _userBox.TextChanged += UserBox_TextChanged;
            _passBox.TextChanged += PassBox_TextChanged;
            _loginBtn.Clicked += LoginBtn_Clicked;

            Caption = "Login";
            Content = new StackLayout
            {
                Alignment = Alignment.Vertical,
                ItemSpacing = 3,
                Items =
                {
                    new StackItem(_errMsg){HorizontalAlignment = HorizontalAlignment.Center},
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
                                    _userBox
                                }
                            },
                            new TableRow
                            {
                                Cells =
                                {
                                    new Label {Caption = "Password:"},
                                    _passBox
                                }
                            }
                        }
                    },
                    new StackItem(_loginBtn) {HorizontalAlignment = HorizontalAlignment.Right}
                }
            };
        }

        private void UserBox_TextChanged(object sender, EventArgs e)
        {
            _username = _userBox.Text;
        }

        private void PassBox_TextChanged(object sender, EventArgs e)
        {
            _password = _passBox.Text;
        }

        private async void LoginBtn_Clicked(object sender, EventArgs e)
        {
            _errMsg.Caption = string.Empty;
            ToggleDialog(false);

            var isLoggedIn = await TryLogin();

            ToggleDialog(true);

            if (isLoggedIn)
                await AfterLogin();
        }

        private Task<bool> TryLogin()
        {
            return Task.Run(async () =>
            {
                try
                {
                    await NierReincarnation.NierReincarnation.Login(_username, _password);
                }
                catch (Exception e)
                {
                    _errMsg.Caption = "Couldn't login.";
                    Console.WriteLine(e.Message);

                    return false;
                }

                return true;
            });
        }

        private void ToggleDialog(bool toggle)
        {
            _userBox.IsReadOnly = !toggle;
            _passBox.IsReadOnly = !toggle;
            _loginBtn.Enabled = toggle;
        }

        #endregion

        #region Initialize

        private async Task<bool> EnsureInitialized()
        {
            // Set setup design
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

            // Setup application
            await Task.Run(NierReincarnation.NierReincarnation.Initialize);

            return NierReincarnation.NierReincarnation.IsInitialized;
        }

        #endregion

        #region Localizations

        private async Task EnsureTextAssets(Language language)
        {
            var assetContext = NierReincarnation.NierReincarnation.GetContexts().Assets;
            var assetCount = assetContext.GetTextAssetCount(language);
            var assetSize = assetContext.GetTextAssetSize(language);

            // Set setup design
            Size = new Vector2(250, 100);
            Content = new StackLayout
            {
                Alignment = Alignment.Horizontal,
                Items =
                {
                    new StackItem(new Label {Caption = $"Download {assetCount} text files ({assetSize/1024/1024}MB) ..."})
                    {
                        HorizontalAlignment = HorizontalAlignment.Center,
                        VerticalAlignment = VerticalAlignment.Center,
                        Size = ImGui.Forms.Models.Size.Parent
                    }
                }
            };

            await NierReincarnation.NierReincarnation.LoadLocalizations(language);
        }

        #endregion
    }
}
