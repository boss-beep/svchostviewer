namespace Svchost_Viewer_Ver1
{
    partial class About
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

        new private System.Windows.Forms.Label ProductName;
        new private System.Windows.Forms.Label ProductVersion;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button Ok_button;

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(About));
            this.ProductName = new System.Windows.Forms.Label();
            this.ProductVersion = new System.Windows.Forms.Label();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.Ok_button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ProductName
            // 
            this.ProductName.AutoSize = true;
            this.ProductName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProductName.Location = new System.Drawing.Point(9, 9);
            this.ProductName.Name = "ProductName";
            this.ProductName.Size = new System.Drawing.Size(110, 17);
            this.ProductName.TabIndex = 0;
            this.ProductName.Text = "Product Name";
            // 
            // ProductVersion
            // 
            this.ProductVersion.AutoSize = true;
            this.ProductVersion.Location = new System.Drawing.Point(9, 28);
            this.ProductVersion.Name = "ProductVersion";
            this.ProductVersion.Size = new System.Drawing.Size(81, 13);
            this.ProductVersion.TabIndex = 1;
            this.ProductVersion.Text = "Product version";
            // 
            // richTextBox1
            // 
            this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox1.Cursor = System.Windows.Forms.Cursors.Default;
            this.richTextBox1.Location = new System.Drawing.Point(12, 57);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(316, 96);
            this.richTextBox1.TabIndex = 2;
            this.richTextBox1.Text = "Svchost viewer is\n\nmade by boss-beep\n\nSource code and updates are available on\n\nh" +
    "ttps://github.com/boss-beep/svchostviewer";
            this.richTextBox1.LinkClicked += new System.Windows.Forms.LinkClickedEventHandler(this.richTextBox1_LinkClicked);
            this.richTextBox1.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged);
            // 
            // Ok_button
            // 
            this.Ok_button.Location = new System.Drawing.Point(133, 159);
            this.Ok_button.Name = "Ok_button";
            this.Ok_button.Size = new System.Drawing.Size(75, 23);
            this.Ok_button.TabIndex = 3;
            this.Ok_button.Text = "OK Mommy";
            this.Ok_button.UseVisualStyleBackColor = true;
            this.Ok_button.Click += new System.EventHandler(this.Ok_button_Click);
            // 
            // About
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(340, 187);
            this.Controls.Add(this.Ok_button);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.ProductVersion);
            this.Controls.Add(this.ProductName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "About";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "About";
            this.Load += new System.EventHandler(this.About_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion


    }
}