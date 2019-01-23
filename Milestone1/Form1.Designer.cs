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
            this.businessGrid = new System.Windows.Forms.DataGridView();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.businessGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // stateDropDown
            // 
            this.stateDropDown.FormattingEnabled = true;
            this.stateDropDown.Location = new System.Drawing.Point(122, 0);
            this.stateDropDown.Name = "stateDropDown";
            this.stateDropDown.Size = new System.Drawing.Size(678, 21);
            this.stateDropDown.TabIndex = 0;
            this.stateDropDown.SelectedIndexChanged += new System.EventHandler(this.stateDropDown_SelectedIndexChanged);
            // 
            // cityDropDown
            // 
            this.cityDropDown.FormattingEnabled = true;
            this.cityDropDown.Location = new System.Drawing.Point(122, 21);
            this.cityDropDown.Name = "cityDropDown";
            this.cityDropDown.Size = new System.Drawing.Size(678, 21);
            this.cityDropDown.TabIndex = 1;
            this.cityDropDown.SelectedIndexChanged += new System.EventHandler(this.cityDropDown_SelectedIndexChanged);
            // 
            // businessGrid
            // 
            this.businessGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.businessGrid.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.businessGrid.Location = new System.Drawing.Point(0, 48);
            this.businessGrid.Name = "businessGrid";
            this.businessGrid.Size = new System.Drawing.Size(800, 402);
            this.businessGrid.TabIndex = 2;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(0, 0);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(116, 20);
            this.textBox1.TabIndex = 3;
            this.textBox1.Text = "State";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(0, 21);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(116, 20);
            this.textBox2.TabIndex = 4;
            this.textBox2.Text = "City";
            this.textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.businessGrid);
            this.Controls.Add(this.cityDropDown);
            this.Controls.Add(this.stateDropDown);
            this.Name = "Form1";
            this.Text = "Milestone 1 Sample Application";
            ((System.ComponentModel.ISupportInitialize)(this.businessGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox stateDropDown;
        private System.Windows.Forms.ComboBox cityDropDown;
        private System.Windows.Forms.DataGridView businessGrid;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
    }
}

