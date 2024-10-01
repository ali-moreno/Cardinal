namespace Cardinal
{
    partial class Hotkeys
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
            hotkeyLabel = new Label();
            cmbxHotkeySelector = new ComboBox();
            universalHotkeyCheckbox = new CheckBox();
            lblUniversalHotkeyReminder = new Label();
            SuspendLayout();
            // 
            // hotkeyLabel
            // 
            hotkeyLabel.AutoSize = true;
            hotkeyLabel.Location = new Point(240, 191);
            hotkeyLabel.Name = "hotkeyLabel";
            hotkeyLabel.Size = new Size(93, 15);
            hotkeyLabel.TabIndex = 0;
            hotkeyLabel.Text = "Capture Hotkey:";
            // 
            // cmbxHotkeySelector
            // 
            cmbxHotkeySelector.FormattingEnabled = true;
            cmbxHotkeySelector.Location = new Point(363, 188);
            cmbxHotkeySelector.Name = "cmbxHotkeySelector";
            cmbxHotkeySelector.Size = new Size(121, 23);
            cmbxHotkeySelector.TabIndex = 1;
            cmbxHotkeySelector.SelectedIndexChanged += cmbxHotkeySelector_Selection;
            // 
            // universalHotkeyCheckbox
            // 
            universalHotkeyCheckbox.AutoSize = true;
            universalHotkeyCheckbox.Location = new Point(317, 229);
            universalHotkeyCheckbox.Name = "universalHotkeyCheckbox";
            universalHotkeyCheckbox.Size = new Size(142, 19);
            universalHotkeyCheckbox.TabIndex = 2;
            universalHotkeyCheckbox.Text = "Use Universal Hotkey?";
            universalHotkeyCheckbox.UseVisualStyleBackColor = true;
            universalHotkeyCheckbox.CheckedChanged += universalHotkeyCheckbox_Toggle;
            // 
            // lblUniversalHotkeyReminder
            // 
            lblUniversalHotkeyReminder.AutoSize = true;
            lblUniversalHotkeyReminder.Location = new Point(169, 251);
            lblUniversalHotkeyReminder.Name = "lblUniversalHotkeyReminder";
            lblUniversalHotkeyReminder.Size = new Size(473, 15);
            lblUniversalHotkeyReminder.TabIndex = 3;
            lblUniversalHotkeyReminder.Text = "Note: to use a universal hotkey, input Ctrl and your selected function key simultaneously";
            // 
            // Hotkeys
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(lblUniversalHotkeyReminder);
            Controls.Add(universalHotkeyCheckbox);
            Controls.Add(cmbxHotkeySelector);
            Controls.Add(hotkeyLabel);
            Name = "Hotkeys";
            Text = "Hotkeys";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label hotkeyLabel;
        private ComboBox cmbxHotkeySelector;
        private CheckBox universalHotkeyCheckbox;
        private Label lblUniversalHotkeyReminder;
    }
}