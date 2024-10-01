using Cardinal.Settings;

namespace Cardinal
{
    public partial class WebsocketConnection : Form
    {
        private AppSettings appSettings;

        public WebsocketConnection()
        {
            InitializeComponent();
            appSettings = new AppSettings();
            string serverIP = appSettings.GetAppSettings(AppSettings.Settings.ServerIP);
            serverIPTextBox.Text = serverIP;
            string serverPort = appSettings.GetAppSettings(AppSettings.Settings.ServerPort);
            serverPortTextBox.Text = serverPort;
            string serverPassword = appSettings.GetAppSettings(AppSettings.Settings.ServerPassword);
            serverPasswordTextBox.Text = serverPassword;
            if (string.IsNullOrEmpty(serverIP) || string.IsNullOrEmpty(serverPort) || string.IsNullOrEmpty(serverPassword))
            {
                firstTimeSetupWarning.Text = "NOTE: For first time setup, close the program and restart after entering connection details.";
            }
        }

        protected override void OnClosed(EventArgs e)
        {
            appSettings.UpdateAppSettings(AppSettings.Settings.ServerIP, serverIPTextBox.Text);
            appSettings.UpdateAppSettings(AppSettings.Settings.ServerPort, serverPortTextBox.Text);
            appSettings.UpdateAppSettings(AppSettings.Settings.ServerPassword, serverPasswordTextBox.Text);
        }
    }
}
