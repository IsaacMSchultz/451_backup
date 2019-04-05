namespace Milestone2App
{
    partial class ReviewForm
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
            this.ReviewGrid = new System.Windows.Forms.DataGridView();
            this.Stars = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Text = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Useful = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Funny = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cool = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.ReviewGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // ReviewGrid
            // 
            this.ReviewGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ReviewGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Stars,
            this.Date,
            this.Text,
            this.Useful,
            this.Funny,
            this.Cool});
            this.ReviewGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ReviewGrid.Location = new System.Drawing.Point(0, 0);
            this.ReviewGrid.Margin = new System.Windows.Forms.Padding(0);
            this.ReviewGrid.Name = "ReviewGrid";
            this.ReviewGrid.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.ReviewGrid.RowTemplate.Height = 24;
            this.ReviewGrid.Size = new System.Drawing.Size(706, 357);
            this.ReviewGrid.TabIndex = 0;
            // 
            // Stars
            // 
            this.Stars.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Stars.HeaderText = "Stars";
            this.Stars.Name = "Stars";
            this.Stars.Width = 56;
            // 
            // Date
            // 
            this.Date.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Date.HeaderText = "Date";
            this.Date.Name = "Date";
            this.Date.Width = 55;
            // 
            // Text
            // 
            this.Text.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Text.HeaderText = "Text";
            this.Text.Name = "Text";
            // 
            // Useful
            // 
            this.Useful.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Useful.HeaderText = "Useful";
            this.Useful.Name = "Useful";
            this.Useful.Width = 62;
            // 
            // Funny
            // 
            this.Funny.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Funny.HeaderText = "Funny";
            this.Funny.Name = "Funny";
            this.Funny.Width = 61;
            // 
            // Cool
            // 
            this.Cool.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Cool.HeaderText = "Cool";
            this.Cool.Name = "Cool";
            this.Cool.Width = 53;
            // 
            // ReviewForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(706, 357);
            this.Controls.Add(this.ReviewGrid);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ReviewForm";
            ((System.ComponentModel.ISupportInitialize)(this.ReviewGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView ReviewGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn Stars;
        private System.Windows.Forms.DataGridViewTextBoxColumn Date;
        private System.Windows.Forms.DataGridViewTextBoxColumn Text;
        private System.Windows.Forms.DataGridViewTextBoxColumn Useful;
        private System.Windows.Forms.DataGridViewTextBoxColumn Funny;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cool;
    }
}