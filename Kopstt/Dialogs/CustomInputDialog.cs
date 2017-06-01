using MahApps.Metro.Controls.Dialogs;

namespace Kopstt.Dialogs
{
    internal class CustomInputDialog : BaseMetroDialog
    {
        private MetroDialogSettings metroDialogSettings;
        private object view;

        public CustomInputDialog(object view, MetroDialogSettings metroDialogSettings)
        {
            this.view = view;
            this.metroDialogSettings = metroDialogSettings;
        }

        public string Input { get; set; }
        public string Message { get; set; }
        public string Title { get; set; }
    }
}