namespace Svchost_Viewer_Ver1
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.panel1_svchost_Process = new System.Windows.Forms.Panel();
            this.Panel1_groupBox2 = new System.Windows.Forms.GroupBox();
            this.Status_mode_txt = new System.Windows.Forms.Label();
            this.service_name_txt = new System.Windows.Forms.Label();
            this.Start_mode_txt = new System.Windows.Forms.Label();
            this.Service_Type_txt = new System.Windows.Forms.Label();
            this.service_stopped_checkbox = new System.Windows.Forms.CheckBox();
            this.service_pause_checkbox = new System.Windows.Forms.CheckBox();
            this.Description_Label1 = new System.Windows.Forms.Label();
            this.ServiceInformation_richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.Panel1_groupBox1 = new System.Windows.Forms.GroupBox();
            this.processInformation_richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.refreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.serviceControlToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stopSelectServiceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.windowsServiceManagerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.generateReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripTextLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.panel1_svchost_Process.SuspendLayout();
            this.Panel1_groupBox2.SuspendLayout();
            this.Panel1_groupBox1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // treeView1
            // 
            this.treeView1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.treeView1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.treeView1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.treeView1.ImageIndex = 1;
            this.treeView1.ImageList = this.imageList1;
            this.treeView1.Location = new System.Drawing.Point(0, 27);
            this.treeView1.Name = "treeView1";
            this.treeView1.SelectedImageIndex = 0;
            this.treeView1.ShowPlusMinus = false;
            this.treeView1.ShowRootLines = false;
            this.treeView1.Size = new System.Drawing.Size(209, 343);
            this.treeView1.TabIndex = 6;
            this.treeView1.BeforeCollapse += new System.Windows.Forms.TreeViewCancelEventHandler(this.treeView1_BeforeCollapse);
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "shell1.ico");
            this.imageList1.Images.SetKeyName(1, "user1.ico");
            // 
            // panel1_svchost_Process
            // 
            this.panel1_svchost_Process.BackColor = System.Drawing.SystemColors.Control;
            this.panel1_svchost_Process.Controls.Add(this.Panel1_groupBox2);
            this.panel1_svchost_Process.Controls.Add(this.Panel1_groupBox1);
            this.panel1_svchost_Process.Location = new System.Drawing.Point(215, 27);
            this.panel1_svchost_Process.Name = "panel1_svchost_Process";
            this.panel1_svchost_Process.Size = new System.Drawing.Size(459, 343);
            this.panel1_svchost_Process.TabIndex = 7;
            // 
            // Panel1_groupBox2
            // 
            this.Panel1_groupBox2.Controls.Add(this.Status_mode_txt);
            this.Panel1_groupBox2.Controls.Add(this.service_name_txt);
            this.Panel1_groupBox2.Controls.Add(this.Start_mode_txt);
            this.Panel1_groupBox2.Controls.Add(this.Service_Type_txt);
            this.Panel1_groupBox2.Controls.Add(this.service_stopped_checkbox);
            this.Panel1_groupBox2.Controls.Add(this.service_pause_checkbox);
            this.Panel1_groupBox2.Controls.Add(this.Description_Label1);
            this.Panel1_groupBox2.Controls.Add(this.ServiceInformation_richTextBox1);
            this.Panel1_groupBox2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Panel1_groupBox2.Location = new System.Drawing.Point(6, 83);
            this.Panel1_groupBox2.Name = "Panel1_groupBox2";
            this.Panel1_groupBox2.Size = new System.Drawing.Size(446, 258);
            this.Panel1_groupBox2.TabIndex = 4;
            this.Panel1_groupBox2.TabStop = false;
            this.Panel1_groupBox2.Text = "Service Information :";
            // 
            // Status_mode_txt
            // 
            this.Status_mode_txt.AutoSize = true;
            this.Status_mode_txt.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Status_mode_txt.Location = new System.Drawing.Point(45, 67);
            this.Status_mode_txt.Name = "Status_mode_txt";
            this.Status_mode_txt.Size = new System.Drawing.Size(43, 13);
            this.Status_mode_txt.TabIndex = 18;
            this.Status_mode_txt.Text = "Status :";
            // 
            // service_name_txt
            // 
            this.service_name_txt.AutoSize = true;
            this.service_name_txt.ForeColor = System.Drawing.SystemColors.ControlText;
            this.service_name_txt.Location = new System.Drawing.Point(47, 16);
            this.service_name_txt.Name = "service_name_txt";
            this.service_name_txt.Size = new System.Drawing.Size(41, 13);
            this.service_name_txt.TabIndex = 16;
            this.service_name_txt.Text = "Name :";
            // 
            // Start_mode_txt
            // 
            this.Start_mode_txt.AutoSize = true;
            this.Start_mode_txt.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Start_mode_txt.Location = new System.Drawing.Point(24, 50);
            this.Start_mode_txt.Name = "Start_mode_txt";
            this.Start_mode_txt.Size = new System.Drawing.Size(64, 13);
            this.Start_mode_txt.TabIndex = 15;
            this.Start_mode_txt.Text = "Start mode :";
            // 
            // Service_Type_txt
            // 
            this.Service_Type_txt.AutoSize = true;
            this.Service_Type_txt.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Service_Type_txt.Location = new System.Drawing.Point(12, 33);
            this.Service_Type_txt.Name = "Service_Type_txt";
            this.Service_Type_txt.Size = new System.Drawing.Size(76, 13);
            this.Service_Type_txt.TabIndex = 14;
            this.Service_Type_txt.Text = "Service Type :";
            // 
            // service_stopped_checkbox
            // 
            this.service_stopped_checkbox.AutoCheck = false;
            this.service_stopped_checkbox.AutoSize = true;
            this.service_stopped_checkbox.ForeColor = System.Drawing.SystemColors.ControlText;
            this.service_stopped_checkbox.Location = new System.Drawing.Point(290, 32);
            this.service_stopped_checkbox.Name = "service_stopped_checkbox";
            this.service_stopped_checkbox.Size = new System.Drawing.Size(142, 17);
            this.service_stopped_checkbox.TabIndex = 13;
            this.service_stopped_checkbox.TabStop = false;
            this.service_stopped_checkbox.Text = "Service can be stopped.";
            this.service_stopped_checkbox.UseVisualStyleBackColor = true;
            // 
            // service_pause_checkbox
            // 
            this.service_pause_checkbox.AutoCheck = false;
            this.service_pause_checkbox.AutoSize = true;
            this.service_pause_checkbox.ForeColor = System.Drawing.SystemColors.ControlText;
            this.service_pause_checkbox.Location = new System.Drawing.Point(290, 15);
            this.service_pause_checkbox.Name = "service_pause_checkbox";
            this.service_pause_checkbox.Size = new System.Drawing.Size(139, 17);
            this.service_pause_checkbox.TabIndex = 12;
            this.service_pause_checkbox.TabStop = false;
            this.service_pause_checkbox.Text = "Service can be paused.";
            this.service_pause_checkbox.UseVisualStyleBackColor = true;
            // 
            // Description_Label1
            // 
            this.Description_Label1.AutoSize = true;
            this.Description_Label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Description_Label1.Location = new System.Drawing.Point(9, 88);
            this.Description_Label1.Name = "Description_Label1";
            this.Description_Label1.Size = new System.Drawing.Size(79, 13);
            this.Description_Label1.TabIndex = 1;
            this.Description_Label1.Text = "Description :";
            // 
            // ServiceInformation_richTextBox1
            // 
            this.ServiceInformation_richTextBox1.BackColor = System.Drawing.SystemColors.Control;
            this.ServiceInformation_richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ServiceInformation_richTextBox1.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.ServiceInformation_richTextBox1.ForeColor = System.Drawing.SystemColors.WindowText;
            this.ServiceInformation_richTextBox1.Location = new System.Drawing.Point(6, 104);
            this.ServiceInformation_richTextBox1.Name = "ServiceInformation_richTextBox1";
            this.ServiceInformation_richTextBox1.ReadOnly = true;
            this.ServiceInformation_richTextBox1.Size = new System.Drawing.Size(434, 148);
            this.ServiceInformation_richTextBox1.TabIndex = 0;
            this.ServiceInformation_richTextBox1.Text = "";
            // 
            // Panel1_groupBox1
            // 
            this.Panel1_groupBox1.Controls.Add(this.processInformation_richTextBox1);
            this.Panel1_groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Panel1_groupBox1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Panel1_groupBox1.Location = new System.Drawing.Point(6, 3);
            this.Panel1_groupBox1.Name = "Panel1_groupBox1";
            this.Panel1_groupBox1.Size = new System.Drawing.Size(446, 74);
            this.Panel1_groupBox1.TabIndex = 3;
            this.Panel1_groupBox1.TabStop = false;
            this.Panel1_groupBox1.Text = "Svchost Information :";
            // 
            // processInformation_richTextBox1
            // 
            this.processInformation_richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.processInformation_richTextBox1.Location = new System.Drawing.Point(12, 17);
            this.processInformation_richTextBox1.Name = "processInformation_richTextBox1";
            this.processInformation_richTextBox1.ReadOnly = true;
            this.processInformation_richTextBox1.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.processInformation_richTextBox1.Size = new System.Drawing.Size(428, 51);
            this.processInformation_richTextBox1.TabIndex = 3;
            this.processInformation_richTextBox1.Text = "";
            this.processInformation_richTextBox1.WordWrap = false;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.refreshToolStripMenuItem,
            this.serviceControlToolStripMenuItem,
            this.toolsToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.menuStrip1.Size = new System.Drawing.Size(676, 24);
            this.menuStrip1.TabIndex = 8;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // refreshToolStripMenuItem
            // 
            this.refreshToolStripMenuItem.Name = "refreshToolStripMenuItem";
            this.refreshToolStripMenuItem.Size = new System.Drawing.Size(58, 20);
            this.refreshToolStripMenuItem.Text = "Refresh";
            this.refreshToolStripMenuItem.Click += new System.EventHandler(this.refreshToolStripMenuItem_Click);
            // 
            // serviceControlToolStripMenuItem
            // 
            this.serviceControlToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.stopSelectServiceToolStripMenuItem});
            this.serviceControlToolStripMenuItem.Name = "serviceControlToolStripMenuItem";
            this.serviceControlToolStripMenuItem.Size = new System.Drawing.Size(97, 20);
            this.serviceControlToolStripMenuItem.Text = "Service control";
            this.serviceControlToolStripMenuItem.DropDownOpening += new System.EventHandler(this.serviceControlToolStripMenuItem_DropDownOpening);
            // 
            // stopSelectServiceToolStripMenuItem
            // 
            this.stopSelectServiceToolStripMenuItem.Name = "stopSelectServiceToolStripMenuItem";
            this.stopSelectServiceToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.stopSelectServiceToolStripMenuItem.Text = "Stop Selected Service";
            this.stopSelectServiceToolStripMenuItem.Click += new System.EventHandler(this.stopSelectServiceToolStripMenuItem_Click);
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.windowsServiceManagerToolStripMenuItem,
            this.generateReportToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.toolsToolStripMenuItem.Text = "Tools";
            // 
            // windowsServiceManagerToolStripMenuItem
            // 
            this.windowsServiceManagerToolStripMenuItem.Name = "windowsServiceManagerToolStripMenuItem";
            this.windowsServiceManagerToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
            this.windowsServiceManagerToolStripMenuItem.Text = "Windows Service Manager";
            this.windowsServiceManagerToolStripMenuItem.Click += new System.EventHandler(this.windowsServiceManagerToolStripMenuItem_Click);
            // 
            // generateReportToolStripMenuItem
            // 
            this.generateReportToolStripMenuItem.Name = "generateReportToolStripMenuItem";
            this.generateReportToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
            this.generateReportToolStripMenuItem.Text = "Generate Report";
            this.generateReportToolStripMenuItem.Click += new System.EventHandler(this.generateReportToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripTextLabel1,
            this.toolStripProgressBar1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 373);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(676, 22);
            this.statusStrip1.TabIndex = 9;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripTextLabel1
            // 
            this.toolStripTextLabel1.Name = "toolStripTextLabel1";
            this.toolStripTextLabel1.Size = new System.Drawing.Size(10, 17);
            this.toolStripTextLabel1.Text = ".";
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.Size = new System.Drawing.Size(100, 16);
            this.toolStripProgressBar1.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.toolStripProgressBar1.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(676, 395);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.panel1_svchost_Process);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.menuStrip1);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Svchost Viewer";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.panel1_svchost_Process.ResumeLayout(false);
            this.Panel1_groupBox2.ResumeLayout(false);
            this.Panel1_groupBox2.PerformLayout();
            this.Panel1_groupBox1.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.Panel panel1_svchost_Process;
        private System.Windows.Forms.GroupBox Panel1_groupBox1;
        private System.Windows.Forms.GroupBox Panel1_groupBox2;
        private System.Windows.Forms.RichTextBox ServiceInformation_richTextBox1;
        private System.Windows.Forms.Label Description_Label1;
        private System.Windows.Forms.Label Status_mode_txt;
        private System.Windows.Forms.Label service_name_txt;
        private System.Windows.Forms.Label Start_mode_txt;
        private System.Windows.Forms.Label Service_Type_txt;
        private System.Windows.Forms.CheckBox service_stopped_checkbox;
        private System.Windows.Forms.CheckBox service_pause_checkbox;
        private System.Windows.Forms.RichTextBox processInformation_richTextBox1;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem refreshToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripTextLabel1;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
        private System.Windows.Forms.ToolStripMenuItem serviceControlToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stopSelectServiceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem windowsServiceManagerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem generateReportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
    }
}

