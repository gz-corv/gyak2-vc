
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
            this.countryList.FormattingEnabled = true;
            this.countryList.ItemHeight = 15;
            this.countryList.Location = new System.Drawing.Point(22, 50);
            this.countryList.Name = "countryList";
            this.countryList.Size = new System.Drawing.Size(170, 364);
            this.countryList.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.countryList);
            this.Controls.Add(this.countryFilter);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox countryFilter;
        private System.Windows.Forms.ListBox countryList;
    }
}

