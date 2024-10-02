using Cardinal.Settings;

namespace Cardinal
{
    public partial class CaptureSettings : Form
    {
        private AppSettings appSettings;

        public CaptureSettings()
        {
            InitializeComponent();
            appSettings = new AppSettings();
            AppSettings.FunctionKeys[] listItems = (AppSettings.FunctionKeys[])Enum.GetValues(typeof(AppSettings.FunctionKeys));
            foreach (var item in listItems)
            {
                cmbxHotkeySelector.Items.Add(item);
            }
            cmbxHotkeySelector.Text = string.IsNullOrEmpty(appSettings.GetAppSettings(AppSettings.Settings.CaptureHotkey)) ? "Select Hotkey" : appSettings.GetAppSettings(AppSettings.Settings.CaptureHotkey);
            universalHotkeyCheckbox.Checked = appSettings.GetAppSettings(AppSettings.Settings.UniversalHotkey) == "true";
            lblUniversalHotkeyReminder.Visible = universalHotkeyCheckbox.Checked;
            chkSaveScreenshots.Checked = appSettings.GetAppSettings(AppSettings.Settings.SaveScreenshots) == "true";
            lblSaveScreenshots.Visible = chkSaveScreenshots.Checked;
            lblSaveScreenshots.Text = $"{lblSaveScreenshots.Text} {AppSettings.screenshotsDirectory}";
        }

        private void cmbxHotkeySelector_Selection(object sender, EventArgs e)
        {
            appSettings.UpdateAppSettings(AppSettings.Settings.CaptureHotkey, cmbxHotkeySelector.SelectedItem.ToString());
        }

        private void universalHotkeyCheckbox_Toggle(object sender, EventArgs e)
        {
            string newValue = universalHotkeyCheckbox.Checked ? "true" : "false";
            appSettings.UpdateAppSettings(AppSettings.Settings.UniversalHotkey, newValue);
            lblUniversalHotkeyReminder.Visible = universalHotkeyCheckbox.Checked;
        }

        private void chkSaveScreenshots_Toggle(object sender, EventArgs e)
        {
            string newValue = chkSaveScreenshots.Checked ? "true" : "false";
            appSettings.UpdateAppSettings(AppSettings.Settings.SaveScreenshots, newValue);
            lblSaveScreenshots.Visible = chkSaveScreenshots.Checked;
        }
    }
}
