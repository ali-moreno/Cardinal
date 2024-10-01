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
            btnOpenHotkeySettings = new ToolStripMenuItem();
            //cmbxSourceSelector = new ToolStripComboBox();
            toolStrip1.SuspendLayout();
            SuspendLayout();
            this.KeyPreview = true;
            this.KeyDown += new KeyEventHandler(this.KeyDownHandler);
            // 
            // btnCaptureDeck
            // 
            btnCaptureDeck.Location = new Point(332, 207);
            btnCaptureDeck.Name = "btnCaptureDeck";
            btnCaptureDeck.Size = new Size(105, 23);
            btnCaptureDeck.TabIndex = 0;
            btnCaptureDeck.Text = "Capture Deck";
            btnCaptureDeck.UseVisualStyleBackColor = true;
            btnCaptureDeck.Click += this.btnCaptureDeck_Click;
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
            lblJeremyCodeComplete.Location = new Point(12, 286);
            lblJeremyCodeComplete.Name = "lblJeremyCodeComplete";
            lblJeremyCodeComplete.Size = new Size(0, 15);
            lblJeremyCodeComplete.TabIndex = 2;
            // 
            // toolStrip1
            // 
            //toolStrip1.Items.AddRange(new ToolStripItem[] { settingsDropdownToggleButton, cmbxSourceSelector });
            toolStrip1.Items.AddRange(new ToolStripItem[] { settingsDropdownToggleButton });
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(800, 25);
            toolStrip1.TabIndex = 3;
            toolStrip1.Text = "toolStrip1";
            // 
            // settingsDropdownToggleButton
            // 
            settingsDropdownToggleButton.DropDownItems.AddRange(new ToolStripItem[] { btnOpenSourceSettings, btnOpenConnectionSettings, btnOpenHotkeySettings });
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
            btnOpenSourceSettings.Click += this.btnOpenSourceSettings_Click;
            // 
            // btnOpenConnectionSettings
            // 
            btnOpenConnectionSettings.Name = "btnOpenConnectionSettings";
            btnOpenConnectionSettings.Size = new Size(197, 22);
            btnOpenConnectionSettings.Text = "Websocket Connection";
            btnOpenConnectionSettings.Click += this.btnOpenConnectionSettings_Click;
            // 
            // btnOpenHotkeySettings
            // 
            btnOpenHotkeySettings.Name = "btnOpenHotkeySettings";
            btnOpenHotkeySettings.Size = new Size(197, 22);
            btnOpenHotkeySettings.Text = "Hotkeys";
            btnOpenHotkeySettings.Click += this.btnOpenHotkeySettings_Click;
            //// 
            //// cmbxSourceSelector
            //// 
            //cmbxSourceSelector.Name = "cmbxSourceSelector";
            //cmbxSourceSelector.Size = new Size(121, 25);
            //cmbxSourceSelector.Text = "Select Source";
            //cmbxSourceSelector.SelectedIndexChanged += this.cmbxSourceSelector_Selection;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(toolStrip1);
            Controls.Add(lblJeremyCodeComplete);
            Controls.Add(lblScreenshotCapturedMessage);
            Controls.Add(btnCaptureDeck);
            Name = "Form1";
            Text = "TCGplayer Cardinal";
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
        private ToolStripMenuItem btnOpenHotkeySettings;
    }
}