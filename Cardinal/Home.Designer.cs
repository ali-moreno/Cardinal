namespace Cardinal
{
    partial class Home
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Home));
            btnCaptureDeck = new Button();
            lblScreenshotCapturedMessage = new Label();
            lblJeremyCodeComplete = new Label();
            toolStrip1 = new ToolStrip();
            settingsDropdownToggleButton = new ToolStripDropDownButton();
            btnOpenSourceSettings = new ToolStripMenuItem();
            btnOpenConnectionSettings = new ToolStripMenuItem();
            btnOpenCaptureSettings = new ToolStripMenuItem();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            toolStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // btnCaptureDeck
            // 
            btnCaptureDeck.Location = new Point(332, 207);
            btnCaptureDeck.Name = "btnCaptureDeck";
            btnCaptureDeck.Size = new Size(105, 23);
            btnCaptureDeck.TabIndex = 0;
            btnCaptureDeck.Text = "Capture Deck";
            btnCaptureDeck.UseVisualStyleBackColor = true;
            btnCaptureDeck.Click += btnCaptureDeck_Click;
            // 
            // lblScreenshotCapturedMessage
            // 
            lblScreenshotCapturedMessage.AutoSize = true;
            lblScreenshotCapturedMessage.Location = new Point(0, 162);
            lblScreenshotCapturedMessage.Name = "lblScreenshotCapturedMessage";
            lblScreenshotCapturedMessage.Size = new Size(0, 15);
            lblScreenshotCapturedMessage.TabIndex = 1;
            // 
            // lblJeremyCodeComplete
            // 
            lblJeremyCodeComplete.AutoSize = true;
            lblJeremyCodeComplete.Location = new Point(332, 262);
            lblJeremyCodeComplete.Name = "lblJeremyCodeComplete";
            lblJeremyCodeComplete.Size = new Size(0, 15);
            lblJeremyCodeComplete.TabIndex = 2;
            // 
            // toolStrip1
            // 
            toolStrip1.Items.AddRange(new ToolStripItem[] { settingsDropdownToggleButton });
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(800, 25);
            toolStrip1.TabIndex = 3;
            toolStrip1.Text = "toolStrip1";
            // 
            // settingsDropdownToggleButton
            // 
            settingsDropdownToggleButton.DropDownItems.AddRange(new ToolStripItem[] { btnOpenSourceSettings, btnOpenConnectionSettings, btnOpenCaptureSettings });
            settingsDropdownToggleButton.Image = (Image)resources.GetObject("settingsDropdownToggleButton.Image");
            settingsDropdownToggleButton.ImageTransparentColor = Color.Magenta;
            settingsDropdownToggleButton.Name = "settingsDropdownToggleButton";
            settingsDropdownToggleButton.Size = new Size(78, 22);
            settingsDropdownToggleButton.Text = "Settings";
            // 
            // btnOpenSourceSettings
            // 
            btnOpenSourceSettings.Name = "btnOpenSourceSettings";
            btnOpenSourceSettings.Size = new Size(197, 22);
            btnOpenSourceSettings.Text = "Sources";
            btnOpenSourceSettings.Click += btnOpenSourceSettings_Click;
            // 
            // btnOpenConnectionSettings
            // 
            btnOpenConnectionSettings.Name = "btnOpenConnectionSettings";
            btnOpenConnectionSettings.Size = new Size(197, 22);
            btnOpenConnectionSettings.Text = "Websocket Connection";
            btnOpenConnectionSettings.Click += btnOpenConnectionSettings_Click;
            // 
            // btnOpenCaptureSettings
            // 
            btnOpenCaptureSettings.Name = "btnOpenCaptureSettings";
            btnOpenCaptureSettings.Size = new Size(197, 22);
            btnOpenCaptureSettings.Text = "Capture Settings";
            btnOpenCaptureSettings.Click += btnOpenCaptureSettings_Click;
            // 
            // Home
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(toolStrip1);
            Controls.Add(lblJeremyCodeComplete);
            Controls.Add(lblScreenshotCapturedMessage);
            Controls.Add(btnCaptureDeck);
            KeyPreview = true;
            Name = "Home";
            Text = "TCGplayer Cardinal";
            KeyDown += KeyDownHandler;
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnCaptureDeck;
        private Label lblScreenshotCapturedMessage;
        private Label lblJeremyCodeComplete;
        private ToolStrip toolStrip1;
        //private ToolStripComboBox cmbxSourceSelector;
        private ToolStripDropDownButton settingsDropdownToggleButton;
        private ToolStripMenuItem btnOpenSourceSettings;
        private ToolStripMenuItem btnOpenConnectionSettings;
        private ToolStripMenuItem btnOpenCaptureSettings;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}