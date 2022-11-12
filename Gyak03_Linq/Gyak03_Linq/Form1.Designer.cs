
namespace Gyak03_Linq
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
            this.countryFilter = new System.Windows.Forms.TextBox();
            this.countryList = new System.Windows.Forms.ListBox();
            this.resultGrid = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.resultGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // countryFilter
            // 
            this.countryFilter.Location = new System.Drawing.Point(22, 12);
            this.countryFilter.Name = "countryFilter";
            this.countryFilter.Size = new System.Drawing.Size(170, 23);
            this.countryFilter.TabIndex = 0;
            this.countryFilter.TextChanged += new System.EventHandler(this.countryFilter_TextChanged);
            // 
            // countryList
            // 
            this.countryList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.countryList.FormattingEnabled = true;
            this.countryList.ItemHeight = 15;
            this.countryList.Location = new System.Drawing.Point(22, 50);
            this.countryList.Name = "countryList";
            this.countryList.Size = new System.Drawing.Size(170, 364);
            this.countryList.TabIndex = 1;
            this.countryList.SelectedIndexChanged += new System.EventHandler(this.countryList_SelectedIndexChanged);
            // 
            // resultGrid
            // 
            this.resultGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.resultGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.resultGrid.Location = new System.Drawing.Point(198, 50);
            this.resultGrid.Name = "resultGrid";
            this.resultGrid.RowTemplate.Height = 25;
            this.resultGrid.Size = new System.Drawing.Size(565, 364);
            this.resultGrid.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.resultGrid);
            this.Controls.Add(this.countryList);
            this.Controls.Add(this.countryFilter);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.resultGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox countryFilter;
        private System.Windows.Forms.ListBox countryList;
        private System.Windows.Forms.DataGridView resultGrid;
    }
}

