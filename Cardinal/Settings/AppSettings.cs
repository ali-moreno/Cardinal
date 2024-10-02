using Newtonsoft.Json;

namespace Cardinal.Settings
{
    public class AppSettings
    {
        public static string projectDirectory = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;
        public static string settingsDirectory = $"{projectDirectory}{Path.DirectorySeparatorChar}Settings";
        public static string screenshotsDirectory = $"{projectDirectory}{Path.DirectorySeparatorChar}Captured_Screenshots";

        public static string apiKey = "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";
        public static string llmPrompt = @"User input is a screenshot of a deck from Magic: the Gathering Online. Look at the visible card names, " +
                "identify them, and count them. They are not guaranteed to be unique, so pay attention to duplicates and count the number of occurrences." +
                "Ignore anything that isn't a main deck or sideboard card. This includes other visible cards outside those two domains, as well as any " +
                "UI elements that aren't cards. Your response must be valid JSON, and nothing else. Even though you're looking at both " +
                "the main deck and the sideboard, do not distinguish between them in your output. Your JSON response should be a list of tokens with " +
                "two tokens each under them: 'name' for the card name, and 'count' for the number of times you see it, in the main deck and sideboard combined. " +
                "Note that there will always be 60 cards in the main deck, and 15 cards in the sideboard, for a total of 75 cards. Make sure your response totals exactly 75 cards.";

        public enum Settings { Source, ServerIP, ServerPort, ServerPassword, CaptureHotkey, UniversalHotkey, SaveScreenshots }
        public Dictionary<Settings, string> SettingsText = new Dictionary<Settings, string>()
        {
            {Settings.Source, "source" },
            {Settings.ServerIP, "serverIP" },
            {Settings.ServerPort, "serverPort" },
            {Settings.ServerPassword, "serverPassword" },
            {Settings.CaptureHotkey, "captureHotkey" },
            {Settings.UniversalHotkey, "universalHotkey" },
            {Settings.SaveScreenshots, "saveScreenshots" }
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
