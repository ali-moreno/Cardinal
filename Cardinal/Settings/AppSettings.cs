using Newtonsoft.Json;

namespace Cardinal.Settings
{
    public class AppSettings
    {
        public static string projectDirectory = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;
        public static string settingsDirectory = $"{projectDirectory}{Path.DirectorySeparatorChar}Settings";
        public static string screenshotsDirectory = $"{projectDirectory}{Path.DirectorySeparatorChar}Captured_Screenshots";

        public enum Settings { Source, ServerIP, ServerPort, ServerPassword, CaptureHotkey, UniversalHotkey }
        public Dictionary<Settings, string> SettingsText = new Dictionary<Settings, string>()
        {
            {Settings.Source, "source" },
            {Settings.ServerIP, "serverIP" },
            {Settings.ServerPort, "serverPort" },
            {Settings.ServerPassword, "serverPassword" },
            {Settings.CaptureHotkey, "captureHotkey" },
            {Settings.UniversalHotkey, "universalHotkey" }
        };
        public enum FunctionKeys { F1, F2, F3, F4, F5, F6, F7, F8, F9, F10, F11, F12, F13, F14, F15, F16, F17, F18, F19, F20, F21, F22, F23, F24 }
        public Dictionary<string, Keys> FunctionKeyKey = new Dictionary<string, Keys>()
        {
            {"F1", Keys.F1 },
            {"F2", Keys.F2 },
            {"F3", Keys.F3 },
            {"F4", Keys.F4 },
            {"F5", Keys.F5 },
            {"F6", Keys.F6 },
            {"F7", Keys.F7 },
            {"F8", Keys.F8 },
            {"F9", Keys.F9 },
            {"F10", Keys.F10 },
            {"F11", Keys.F11 },
            {"F12", Keys.F12 },
            {"F13", Keys.F13 },
            {"F14", Keys.F14 },
            {"F15", Keys.F15 },
            {"F16", Keys.F16 },
            {"F17", Keys.F17 },
            {"F18", Keys.F18 },
            {"F19", Keys.F19 },
            {"F20", Keys.F20 },
            {"F21", Keys.F21 },
            {"F22", Keys.F22 },
            {"F23", Keys.F23 },
            {"F24", Keys.F24 }
        };

        public string GetAppSettings(Settings settings)
        {
            string json = File.ReadAllText($"{AppSettings.settingsDirectory}{Path.DirectorySeparatorChar}AppSettings.json");
            dynamic jsonObj = JsonConvert.DeserializeObject<dynamic>(json);
            return jsonObj[SettingsText[settings]];
        }
        public void UpdateAppSettings(Settings settings, string newValue)
        {
            string json = File.ReadAllText($"{AppSettings.settingsDirectory}{Path.DirectorySeparatorChar}AppSettings.json");
            dynamic jsonObj = JsonConvert.DeserializeObject<dynamic>(json);
            jsonObj[SettingsText[settings]] = newValue;
            string output = JsonConvert.SerializeObject(jsonObj, Formatting.Indented);
            File.WriteAllText($"{AppSettings.settingsDirectory}{Path.DirectorySeparatorChar}AppSettings.json", output);
        }
    }
}
