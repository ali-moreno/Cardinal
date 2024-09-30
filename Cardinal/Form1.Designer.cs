namespace Cardinal
{
    partial class Form1
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
            btnCaptureDeck = new Button();
            lblScreenshotCapturedMessage = new Label();
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
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(lblScreenshotCapturedMessage);
            Controls.Add(btnCaptureDeck);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnCaptureDeck;
        private Label lblScreenshotCapturedMessage;
    }
}