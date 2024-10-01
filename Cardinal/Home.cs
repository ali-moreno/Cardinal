using Cardinal.Settings;
using OBSWebsocketDotNet;
using System.Text;

namespace Cardinal
{
    public partial class Home : Form
    {
        public OBSWebsocket client;
        private AppSettings appSettings;
        KeyboardHook hook;

        public Home()
        {
            InitializeComponent();
            appSettings = new AppSettings();
            hook = new KeyboardHook();
            if (string.IsNullOrEmpty(appSettings.GetAppSettings(AppSettings.Settings.ServerIP)) || string.IsNullOrEmpty(appSettings.GetAppSettings(AppSettings.Settings.ServerPort)) || string.IsNullOrEmpty(appSettings.GetAppSettings(AppSettings.Settings.ServerPassword)))
            {
                WebsocketConnection websocketConnection = new WebsocketConnection();
                websocketConnection.ShowDialog();
            }
            else
            {
                client = ConnectToOBS();
            }
            hook.KeyPressed += UniversalKeyDownHandler;
            hook.RegisterHotKey(global::ModifierKeys.Control, appSettings.FunctionKeyKey[appSettings.GetAppSettings(AppSettings.Settings.CaptureHotkey)]);
        }

        private void btnCaptureDeck_Click(object sender, EventArgs e)
        {
            TriggerScreenshot();
        }

        private void KeyDownHandler(object sender, KeyEventArgs e)
        {
            if (appSettings.GetAppSettings(AppSettings.Settings.UniversalHotkey) == "false")
            {
                if (e.KeyCode == appSettings.FunctionKeyKey[appSettings.GetAppSettings(AppSettings.Settings.CaptureHotkey)])
                {
                    TriggerScreenshot();
                }
            }
        }

        private void UniversalKeyDownHandler(object sender, KeyPressedEventArgs e)
        {
            if (appSettings.GetAppSettings(AppSettings.Settings.UniversalHotkey) == "true")
            {
                if (e.Key == appSettings.FunctionKeyKey[appSettings.GetAppSettings(AppSettings.Settings.CaptureHotkey)])
                {
                    TriggerScreenshot();
                }
            }
        }

        private void TriggerScreenshot()
        {
            string source = appSettings.GetAppSettings(AppSettings.Settings.Source);
            string filePath = SaveSourceScreenshot(client, source);
            lblScreenshotCapturedMessage.Text = $"Screenshot saved to {filePath}";
            //Jeremy(filePath);
        }

        private OBSWebsocket ConnectToOBS()
        {
            OBSWebsocket client = new OBSWebsocket();
            client.ConnectAsync($"ws://{appSettings.GetAppSettings(AppSettings.Settings.ServerIP)}:{appSettings.GetAppSettings(AppSettings.Settings.ServerPort)}", appSettings.GetAppSettings(AppSettings.Settings.ServerPassword));
            for (int i = 0; i < 30; i++)
            {
                if (!client.IsConnected)
                {
                    Thread.Sleep(TimeSpan.FromSeconds(1));
                }
                else
                {
                    break;
                }
            }
            return client;
        }

        private string SaveSourceScreenshot(OBSWebsocket client, string source)
        {
            string dateTime = DateTime.Now.ToString().Replace("/", "-").Replace(":", "").Replace(" ", "_");
            string filePath = $"{AppSettings.screenshotsDirectory}{Path.DirectorySeparatorChar}cardinal_screenshot_{dateTime}.png";
            client.SaveSourceScreenshot(source, "png", filePath);
            return filePath;
        }

        private async void Jeremy(string imagePath)
        {
            string apiKey = "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";
            //string imagePath = @"Untitled.png";

            string prompt = @"User input is a screenshot of a deck from Magic: the Gathering Online. Look at the visible card names, " +
                "identify them, and count them. They are not guaranteed to be unique, so pay attention to duplicates and count the number of occurrences." +
                "Ignore anything that isn't a main deck or sideboard card. This includes other visible cards outside those two domains, as well as any " +
                "UI elements that aren't cards. Your response must be valid JSON, and nothing else. Even though you're looking at both " +
                "the main deck and the sideboard, do not distinguish between them in your output. Your JSON response should be a list of tokens with " +
                "two tokens each under them: 'name' for the card name, and 'count' for the number of times you see it, in the main deck and sideboard combined. " +
                "Note that there will always be 60 cards in the main deck, and 15 cards in the sideboard, for a total of 75 cards. Make sure your response totals exactly 75 cards.";

            // Function to encode the image
            string EncodeImage(string path)
            {
                byte[] imageBytes = File.ReadAllBytes(path);
                return Convert.ToBase64String(imageBytes);
            }

            // Getting the base64 string
            string base64Image = EncodeImage(imagePath);

            // Creating the HTTP client
            using (var client = new HttpClient())
            {
                // Adding Authorization header
                client.DefaultRequestHeaders.Add("Authorization", $"Bearer {apiKey}");

                // Creating the payload
                var payload = $@"
                {{
                    ""model"": ""gpt-4o-mini"",
                    ""messages"": [
                        {{
                            ""role"": ""user"",
                            ""content"": [
                                {{
                                    ""type"": ""text"",
                                    ""text"": ""{prompt}""
                                }},
                                {{
                                    ""type"": ""image_url"",
                                    ""image_url"": {{
                                        ""url"": ""data:image/jpeg;base64,{base64Image}""
                                    }}
                                }}
                            ]
                        }}
                    ],
                    ""response_format"": {{
                        ""type"": ""json_schema"",
                        ""json_schema"": {{
                            ""name"": ""card_identification"",
                            ""schema"": {{
                                ""type"": ""object"",
                                ""properties"": {{
                                    ""cards"": {{
                                        ""type"": ""array"",
                                        ""items"": {{
                                            ""type"": ""object"",
                                            ""properties"": {{
                                                ""card_name"": {{""type"": ""string""}},
                                                ""card_count"": {{""type"": ""string""}}
                                            }},
                                            ""required"": [""card_name"", ""card_count""],
                                            ""additionalProperties"": false
                                        }}
                                    }}
                                }},
                                ""required"": [""cards""],
                                ""additionalProperties"": false
                            }},
                            ""strict"": true
                        }}
                    }}
                }}";

                // Creating the StringContent with JSON media type
                var content = new StringContent(payload, Encoding.UTF8, "application/json");

                // Sending the request
                var response = await client.PostAsync("https://api.openai.com/v1/chat/completions", content);

                // Reading the response
                string responseContent = await response.Content.ReadAsStringAsync();

                lblJeremyCodeComplete.Text = $"Jeremy's code is complete!";
                string AliPutBreakpointHere = "";
            }
        }

        private void btnOpenSourceSettings_Click(object sender, EventArgs e)
        {
            Sources frm2 = new Sources();
            frm2.ShowDialog();
        }

        private void btnOpenConnectionSettings_Click(object sender, EventArgs e)
        {
            WebsocketConnection websocketConnection = new WebsocketConnection();
            websocketConnection.ShowDialog();
        }

        private void btnOpenHotkeySettings_Click(Object sender, EventArgs e)
        {
            Hotkeys hotkeys = new Hotkeys();
            hotkeys.ShowDialog();
        }
    }
}