namespace Milestone2App
{
    partial class CheckinForm
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
            this.CheckinTimeSelector = new System.Windows.Forms.DateTimePicker();
            this.SubmitCheckinButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // CheckinTimeSelector
            // 
            this.CheckinTimeSelector.Dock = System.Windows.Forms.DockStyle.Top;
            this.CheckinTimeSelector.Location = new System.Drawing.Point(0, 0);
            this.CheckinTimeSelector.Name = "CheckinTimeSelector";
            this.CheckinTimeSelector.Size = new System.Drawing.Size(355, 20);
            this.CheckinTimeSelector.TabIndex = 0;
            // 
            // SubmitCheckinButton
            // 
            this.SubmitCheckinButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SubmitCheckinButton.Location = new System.Drawing.Point(0, 20);
            this.SubmitCheckinButton.Name = "SubmitCheckinButton";
            this.SubmitCheckinButton.Size = new System.Drawing.Size(355, 71);
            this.SubmitCheckinButton.TabIndex = 1;
            this.SubmitCheckinButton.Text = "Check In";
            this.SubmitCheckinButton.UseVisualStyleBackColor = true;
            this.SubmitCheckinButton.Click += new System.EventHandler(this.SubmitCheckinButton_Click);
            // 
            // CheckinForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(355, 91);
            this.Controls.Add(this.SubmitCheckinButton);
            this.Controls.Add(this.CheckinTimeSelector);
            this.Name = "CheckinForm";
            this.Text = "Select Time";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DateTimePicker CheckinTimeSelector;
        private System.Windows.Forms.Button SubmitCheckinButton;
    }
}