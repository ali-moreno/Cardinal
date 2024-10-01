using System.Windows.Forms;

namespace Cardinal
{
    partial class Sources
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
            cmbxSourceSelector = new ComboBox();
            form2Label = new Label();
            SuspendLayout();
            // 
            // cmbxSourceSelector
            // 
            cmbxSourceSelector.Location = new Point(332, 169);
            cmbxSourceSelector.Name = "cmbxSourceSelector";
            cmbxSourceSelector.Size = new Size(121, 23);
            cmbxSourceSelector.TabIndex = 0;
            cmbxSourceSelector.Text = "Select Source";
            cmbxSourceSelector.SelectedIndexChanged += cmbxSourceSelector_Selection;
            // 
            // form2Label
            // 
            form2Label.AutoSize = true;
            form2Label.Location = new Point(331, 108);
            form2Label.Name = "form2Label";
            form2Label.Size = new Size(122, 15);
            form2Label.TabIndex = 1;
            form2Label.Text = "Select game source:";
            // 
            // Sources
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(cmbxSourceSelector);
            Controls.Add(form2Label);
            Name = "Sources";
            Text = "Form2";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cmbxSourceSelector;
        private Label form2Label;
    }
}