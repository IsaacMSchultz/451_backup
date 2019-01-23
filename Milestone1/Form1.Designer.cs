namespace Milestone1
{
    partial class Form1
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
            this.stateDropDown = new System.Windows.Forms.ComboBox();
            this.cityDropDown = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // stateDropDown
            // 
            this.stateDropDown.Dock = System.Windows.Forms.DockStyle.Top;
            this.stateDropDown.FormattingEnabled = true;
            this.stateDropDown.Location = new System.Drawing.Point(0, 0);
            this.stateDropDown.Name = "stateDropDown";
            this.stateDropDown.Size = new System.Drawing.Size(800, 21);
            this.stateDropDown.TabIndex = 0;
            // 
            // cityDropDown
            // 
            this.cityDropDown.Dock = System.Windows.Forms.DockStyle.Top;
            this.cityDropDown.FormattingEnabled = true;
            this.cityDropDown.Location = new System.Drawing.Point(0, 21);
            this.cityDropDown.Name = "cityDropDown";
            this.cityDropDown.Size = new System.Drawing.Size(800, 21);
            this.cityDropDown.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.cityDropDown);
            this.Controls.Add(this.stateDropDown);
            this.Name = "Form1";
            this.Text = "Milestone 1 Sample Application";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox stateDropDown;
        private System.Windows.Forms.ComboBox cityDropDown;
    }
}

