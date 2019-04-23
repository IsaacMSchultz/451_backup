using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;

namespace Milestone2App
{
    public partial class ReviewForm : Form
    {
        public ReviewForm(DataGridView grid)
        {
            this.ReviewGrid = grid;
            ((System.ComponentModel.ISupportInitialize)(this.ReviewGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // ReviewGrid
            // 
            this.ReviewGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ReviewGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ReviewGrid.Location = new System.Drawing.Point(0, 0);
            this.ReviewGrid.Margin = new System.Windows.Forms.Padding(0);
            this.ReviewGrid.Name = "ReviewGrid";
            this.ReviewGrid.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.ReviewGrid.RowTemplate.Height = 24;
            this.ReviewGrid.Size = new System.Drawing.Size(706, 357);
            this.ReviewGrid.TabIndex = 0;
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

        private void ReviewForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            this.Parent = null;
            e.Cancel = true;

            
        }
    }
}
