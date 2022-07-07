using System;
using ImGui.Forms.Controls;
using ImGui.Forms.Controls.Layouts;
using ImGui.Forms.Modals;
using NierReincarnation.Context;

namespace nier_rein_gui.Extensions
{
    static class BaseContextExtensions
    {
        private static ReAuthDialog _reAuthDlg;

        public static void SetupReAuthorization(this BaseContext context, Action beforeUnauthenticated, Action<bool> afterUnauthenticated)
        {
            // HINT: Make sure the events were removed at least once
            context.BeforeUnauthenticated -= BaseContext_BeforeUnauthenticated;
            context.AfterUnauthenticated -= BaseContext_AfterUnauthenticated;

            if (beforeUnauthenticated != null)
                context.BeforeUnauthenticated -= beforeUnauthenticated;
            if (afterUnauthenticated != null)
                context.AfterUnauthenticated -= afterUnauthenticated;

            context.BeforeUnauthenticated += BaseContext_BeforeUnauthenticated;
            context.AfterUnauthenticated += BaseContext_AfterUnauthenticated;

            if (beforeUnauthenticated != null)
                context.BeforeUnauthenticated += beforeUnauthenticated;
            if (afterUnauthenticated != null)
                context.AfterUnauthenticated += afterUnauthenticated;
        }

        private static async void BaseContext_BeforeUnauthenticated()
        {
            _reAuthDlg ??= new ReAuthDialog();

            await _reAuthDlg.ShowAsync();
        }

        private static void BaseContext_AfterUnauthenticated(bool hasReauthorized)
        {
            if (_reAuthDlg == null)
                return;

            _reAuthDlg.KeepOpen = !hasReauthorized;
            _reAuthDlg.Close(DialogResult.Ok);

            if (hasReauthorized)
                _reAuthDlg = null;
        }

        class ReAuthDialog : Modal
        {
            public bool KeepOpen { get; set; } = true;

            public ReAuthDialog()
            {
                Caption = "Re-Authorization";
                Content = new StackLayout
                {
                    Alignment = Alignment.Vertical,
                    Items =
                    {
                        new StackItem(new Label {Caption = "Initialize data...",Width = 1f}){VerticalAlignment = VerticalAlignment.Center}
                    }
                };
            }

            protected override bool ShouldCancelClose()
            {
                return KeepOpen;
            }
        }
    }
}
