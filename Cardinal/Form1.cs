using OBSWebsocketDotNet;
using OBSWebsocketDotNet.Communication;
using OBSWebsocketDotNet.Types;
using OBSWebsocketDotNet.Types.Events;
using System.Buffers.Text;
using System.Diagnostics;
using System.Drawing.Imaging;
using System.Net.WebSockets;
using System.Runtime.InteropServices;
using System.Text;

namespace Cardinal
{
    public partial class Form1 : Form
    {
        private static string projectDirectory = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;
        private static string screenshotsDirectory = $"{projectDirectory}{Path.DirectorySeparatorChar}Captured_Screenshots";

        public Form1()
        {
            InitializeComponent();
        }

        private void btnCaptureDeck_Click(object sender, EventArgs e)
        {
            OBSWebsocket client = ConnectToOBS();
            string filePath = SaveSourceScreenshot(client, "VS");
            lblScreenshotCapturedMessage.Text = $"Screenshot saved to {filePath}";
        }

        //private Bitmap TakeScreenshot()
        //{
        //    List<Screen> screens = Screen.AllScreens.ToList();
        //    Process outlook = Process.GetProcesses().ToList().First(process => process.MainWindowTitle.Contains("OBS"));
        //    var handle = outlook.MainWindowHandle;
        //    RECT rc;
        //    GetWindowRect(handle, out rc);
        //    Size rcSize = new Size(rc.Right - rc.Left, rc.Bottom - rc.Top);

        //    Bitmap captureBitmap = new Bitmap(rc.Right - rc.Left, rc.Bottom - rc.Top, PixelFormat.Format32bppArgb);
        //    Graphics captureGraphics = Graphics.FromImage(captureBitmap);
        //    captureGraphics.CopyFromScreen(rc.Left, rc.Top, 0, 0, rcSize);

        //    return captureBitmap;
        //}

        //[DllImport("user32.dll")]
        //[return: MarshalAs(UnmanagedType.Bool)]
        //static extern bool GetWindowRect(IntPtr hWnd, out RECT lpRect);
        //[StructLayout(LayoutKind.Sequential)]
        //public struct RECT
        //{
        //    public int Left;        // x position of upper-left corner
        //    public int Top;         // y position of upper-left corner
        //    public int Right;       // x position of lower-right corner
        //    public int Bottom;      // y position of lower-right corner
        //}

        //private string SaveScreenshot(Bitmap captureBitmap)
        //{
        //    string dateTime = DateTime.Now.ToString().Replace("/", "-").Replace(":", "").Replace(" ", "_");
        //    string filePath = $"{screenshotsDirectory}{Path.DirectorySeparatorChar}cardinal_screenshot_{dateTime}.png";
        //    captureBitmap.Save(filePath, ImageFormat.Png);
        //    return filePath;
        //}

        private OBSWebsocket ConnectToOBS()
        {
            OBSWebsocket client = new OBSWebsocket();
            client.ConnectAsync($"ws://192.168.1.206:4455", "E9WLIDyPvHbdszwW");
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
            string filePath = $"{screenshotsDirectory}{Path.DirectorySeparatorChar}cardinal_screenshot_{dateTime}.png";
            client.SaveSourceScreenshot(source, "png", filePath);
            return filePath;
        }
    }
}