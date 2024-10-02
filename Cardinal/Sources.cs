using Cardinal.Settings;
using OBSWebsocketDotNet;
using OBSWebsocketDotNet.Types;

namespace Cardinal
{
    public partial class Sources : Form
    {
        private AppSettings appSettings;

        public Sources(OBSWebsocket client)
        {
            InitializeComponent();
            appSettings = new AppSettings();
            cmbxSourceSelector.Text = string.IsNullOrEmpty(appSettings.GetAppSettings(AppSettings.Settings.Source)) ? "Select Source" : appSettings.GetAppSettings(AppSettings.Settings.Source);
            GetSceneListInfo sceneList = client.GetSceneList();
            List<string> sceneNames = new List<string>();
            foreach (var scene in sceneList.Scenes)
            {
                sceneNames.Add(scene.Name);
            }
            List<string> sources = new List<string>();
            foreach (string sceneName in sceneNames)
            {
                List<SceneItemDetails> sceneItemDetails = client.GetSceneItemList(sceneName);
                List<string> sourceNames = new List<string>();
                foreach (SceneItemDetails sceneItem in sceneItemDetails)
                {
                    string sourceName = sceneItem.SourceName;
                    if (!sources.Contains(sourceName))
                    {
                        sources.Add(sourceName);
                    }
                }
            }
            foreach (string source in sources)
            {
                cmbxSourceSelector.Items.Add(source);
            }
        }

        private void cmbxSourceSelector_Selection(object sender, EventArgs e)
        {
            appSettings.UpdateAppSettings(AppSettings.Settings.Source, cmbxSourceSelector.SelectedItem.ToString());
        }
    }
}
