using Cardinal.Settings;
using Newtonsoft.Json.Linq;
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
            if (!string.IsNullOrEmpty(appSettings.GetAppSettings(AppSettings.Settings.CaptureHotkey)) && appSettings.GetAppSettings(AppSettings.Settings.UniversalHotkey) == "true")
            {
                hook.KeyPressed += UniversalKeyDownHandler;
                hook.RegisterHotKey(global::ModifierKeys.Control, appSettings.FunctionKeyKey[appSettings.GetAppSettings(AppSettings.Settings.CaptureHotkey)]);
            }
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
            Jeremy(filePath);
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

        // Returns filepath if screenshot was saved, otherwise returns base64-encoded string
        private string SaveSourceScreenshot(OBSWebsocket client, string source)
        {
            if (appSettings.GetAppSettings(AppSettings.Settings.SaveScreenshots) == "true")
            {
                string dateTime = DateTime.Now.ToString().Replace("/", "-").Replace(":", "").Replace(" ", "_");
                string filePath = $"{AppSettings.screenshotsDirectory}{Path.DirectorySeparatorChar}cardinal_screenshot_{dateTime}.png";
                client.SaveSourceScreenshot(source, "png", filePath);
                lblScreenshotCapturedMessage.Text = $"Screenshot saved to {filePath}";
                return filePath;
            }
            else
            {
                return client.GetSourceScreenshot(source, "png");
            }
        }

        private async void Jeremy(string imageString)
        {
            string apiKey = AppSettings.apiKey;
            string prompt = AppSettings.llmPrompt;

            lblJeremyCodeComplete.Text = "Loading...";
            lblJeremyCodeComplete.Refresh();
            string base64Image;
            if (appSettings.GetAppSettings(AppSettings.Settings.SaveScreenshots) == "true")
            {
                // Function to encode the image
                string EncodeImage(string path)
                {
                    byte[] imageBytes = File.ReadAllBytes(path);
                    return Convert.ToBase64String(imageBytes);
                }
                // Getting the base64 string
                base64Image = EncodeImage(imageString);
            }
            else
            {
                base64Image = imageString.Replace("data:image/png;base64,", "");
            }
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

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    // Reading the response
                    string responseContent = await response.Content.ReadAsStringAsync();
                    JObject responseJson = JObject.Parse(responseContent);
                    JToken temp = responseJson["choices"][0]["message"]["content"];
                    List<JToken> cardList = JObject.Parse(temp.ToString())["cards"].ToList();
                    // Send to backend
                    using (HttpClient client2 = new HttpClient())
                    {
                        string url = "https://us-central1-team-cardinal-hackathon2024.cloudfunctions.net/handle_json";
                        string jsonPayload = "[";
                        cardList.ForEach(x =>
                        {
                            jsonPayload += $"{{\"card_name\": \"{x["card_name"]}\", \"card_count\":\"{x["card_count"]}\"}},";
                        });
                        // Trim last comma
                        jsonPayload = jsonPayload.Remove(jsonPayload.Length - 1);
                        jsonPayload += "]";
                        //string jsonPayload = @"[{""card_name"": ""Force of Will"", ""card_count"": ""4""},{""card_name"": ""Brainstorm"", ""card_count"":""2""}]";
                        StringContent content1 = new StringContent(jsonPayload, Encoding.UTF8, "application/json");
                        var response2 = await client2.PostAsync(url, content1);
                        string responseContent2 = await response2.Content.ReadAsStringAsync();
                        Console.WriteLine(responseContent2);
                        Console.ReadLine();
                        string JeremyPutBreakpointHere = "";
                    }
                    lblJeremyCodeComplete.Visible = true;
                    lblJeremyCodeComplete.ForeColor = Color.Green;
                    lblJeremyCodeComplete.Text = "Capture completed successfully!";
                    lblJeremyCodeComplete.Refresh();
                }
                else
                {
                    lblJeremyCodeComplete.Visible = true;
                    lblJeremyCodeComplete.ForeColor = Color.Red;
                    lblJeremyCodeComplete.Text = $"ERROR: capture unsuccessful: OpenAI responded with {response.StatusCode}";
                    lblJeremyCodeComplete.Refresh();
                }
                string AliPutBreakpointHere = "";
            }
        }

        private void btnOpenSourceSettings_Click(object sender, EventArgs e)
        {
            Sources sources = new Sources(client);
            sources.ShowDialog();
        }

        private void btnOpenConnectionSettings_Click(object sender, EventArgs e)
        {
            WebsocketConnection websocketConnection = new WebsocketConnection();
            websocketConnection.ShowDialog();
        }

        private void btnOpenCaptureSettings_Click(Object sender, EventArgs e)
        {
            CaptureSettings hotkeys = new CaptureSettings();
            hotkeys.ShowDialog();
        }
    }
}