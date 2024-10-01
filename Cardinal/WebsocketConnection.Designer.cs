namespace Cardinal
{
    partial class WebsocketConnection
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            serverIPTextBox = new TextBox();
            serverIPLabel = new Label();
            serverPortTextBox = new TextBox();
            serverPortLabel = new Label();
            serverPasswordTextBox = new TextBox();
            serverPasswordLabel = new Label();
            title = new Label();
            firstTimeSetupWarning = new Label();
            SuspendLayout();
            // 
            // serverIPTextBox
            // 
            serverIPTextBox.Location = new Point(373, 144);
            serverIPTextBox.Name = "serverIPTextBox";
            serverIPTextBox.Size = new Size(182, 23);
            serverIPTextBox.TabIndex = 0;
            // 
            // serverIPLabel
            // 
            serverIPLabel.AutoSize = true;
            serverIPLabel.Location = new Point(224, 147);
            serverIPLabel.Name = "serverIPLabel";
            serverIPLabel.Size = new Size(119, 15);
            serverIPLabel.TabIndex = 1;
            serverIPLabel.Text = "Server IP (Best Guess)";
            // 
            // serverPortTextBox
            // 
            serverPortTextBox.Location = new Point(373, 196);
            serverPortTextBox.Name = "serverPortTextBox";
            serverPortTextBox.Size = new Size(182, 23);
            serverPortTextBox.TabIndex = 2;
            // 
            // serverPortLabel
            // 
            serverPortLabel.AutoSize = true;
            serverPortLabel.Location = new Point(224, 199);
            serverPortLabel.Name = "serverPortLabel";
            serverPortLabel.Size = new Size(64, 15);
            serverPortLabel.TabIndex = 3;
            serverPortLabel.Text = "Server Port";
            // 
            // serverPasswordTextBox
            // 
            serverPasswordTextBox.Location = new Point(373, 244);
            serverPasswordTextBox.Name = "serverPasswordTextBox";
            serverPasswordTextBox.Size = new Size(182, 23);
            serverPasswordTextBox.TabIndex = 4;
            // 
            // serverPasswordLabel
            // 
            serverPasswordLabel.AutoSize = true;
            serverPasswordLabel.Location = new Point(224, 247);
            serverPasswordLabel.Name = "serverPasswordLabel";
            serverPasswordLabel.Size = new Size(92, 15);
            serverPasswordLabel.TabIndex = 5;
            serverPasswordLabel.Text = "Server Password";
            // 
            // title
            // 
            title.AutoSize = true;
            title.Location = new Point(275, 60);
            title.Name = "title";
            title.Size = new Size(231, 15);
            title.TabIndex = 6;
            title.Text = "Enter OBS WebSocket Connect Info below:";
            // 
            // firstTimeSetupWarning
            // 
            firstTimeSetupWarning.AutoSize = true;
            firstTimeSetupWarning.ForeColor = Color.Red;
            firstTimeSetupWarning.Location = new Point(288, 91);
            firstTimeSetupWarning.Name = "firstTimeSetupWarning";
            firstTimeSetupWarning.Size = new Size(0, 15);
            firstTimeSetupWarning.TabIndex = 7;
            // 
            // WebsocketConnection
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(firstTimeSetupWarning);
            Controls.Add(title);
            Controls.Add(serverPasswordLabel);
            Controls.Add(serverPasswordTextBox);
            Controls.Add(serverPortLabel);
            Controls.Add(serverPortTextBox);
            Controls.Add(serverIPLabel);
            Controls.Add(serverIPTextBox);
            Name = "WebsocketConnection";
            Text = "WebSocket Connection";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox serverIPTextBox;
        private Label serverIPLabel;
        private TextBox serverPortTextBox;
        private Label serverPortLabel;
        private TextBox serverPasswordTextBox;
        private Label serverPasswordLabel;
        private Label title;
        private Label firstTimeSetupWarning;
    }
}