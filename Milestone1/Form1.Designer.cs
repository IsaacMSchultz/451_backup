﻿namespace Milestone1
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
            this.groupBox = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.businessGrid)).BeginInit();
            this.groupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // stateDropDown
            // 
            this.stateDropDown.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.stateDropDown.FormattingEnabled = true;
            this.stateDropDown.Location = new System.Drawing.Point(122, 0);
            this.stateDropDown.Name = "stateDropDown";
            this.stateDropDown.Size = new System.Drawing.Size(678, 21);
            this.stateDropDown.TabIndex = 0;
            this.stateDropDown.SelectedIndexChanged += new System.EventHandler(this.stateDropDown_SelectedIndexChanged);
            // 
            // cityDropDown
            // 
            this.cityDropDown.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cityDropDown.FormattingEnabled = true;
            this.cityDropDown.Location = new System.Drawing.Point(122, 20);
            this.cityDropDown.Name = "cityDropDown";
            this.cityDropDown.Size = new System.Drawing.Size(678, 21);
            this.cityDropDown.TabIndex = 1;
            this.cityDropDown.SelectedIndexChanged += new System.EventHandler(this.cityDropDown_SelectedIndexChanged);
            // 
            // businessGrid
            // 
            this.businessGrid.AllowUserToAddRows = false;
            this.businessGrid.AllowUserToDeleteRows = false;
            this.businessGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.businessGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.businessGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.businessGrid.Location = new System.Drawing.Point(0, 41);
            this.businessGrid.Name = "businessGrid";
            this.businessGrid.ReadOnly = true;
            this.businessGrid.Size = new System.Drawing.Size(800, 409);
            this.businessGrid.TabIndex = 2;
            // 
            // textBox1
            // 
            this.textBox1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Cursor = System.Windows.Forms.Cursors.Default;
            this.textBox1.Location = new System.Drawing.Point(6, 3);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(116, 13);
            this.textBox1.TabIndex = 3;
            this.textBox1.Text = "State";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox2
            // 
            this.textBox2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox2.Cursor = System.Windows.Forms.Cursors.Default;
            this.textBox2.Location = new System.Drawing.Point(6, 23);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(116, 13);
            this.textBox2.TabIndex = 4;
            this.textBox2.Text = "City";
            this.textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // groupBox
            // 
            this.groupBox.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.groupBox.Controls.Add(this.stateDropDown);
            this.groupBox.Controls.Add(this.textBox2);
            this.groupBox.Controls.Add(this.cityDropDown);
            this.groupBox.Controls.Add(this.textBox1);
            this.groupBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox.Location = new System.Drawing.Point(0, 0);
            this.groupBox.Name = "groupBox";
            this.groupBox.Size = new System.Drawing.Size(800, 41);
            this.groupBox.TabIndex = 5;
            this.groupBox.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.businessGrid);
            this.Controls.Add(this.groupBox);
            this.Name = "Form1";
            this.Text = "Milestone 1 Sample Application";
            ((System.ComponentModel.ISupportInitialize)(this.businessGrid)).EndInit();
            this.groupBox.ResumeLayout(false);
            this.groupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox stateDropDown;
        private System.Windows.Forms.ComboBox cityDropDown;
        private System.Windows.Forms.DataGridView businessGrid;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.GroupBox groupBox;
    }
}

