namespace MySQLBackup
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            statusStrip1 = new System.Windows.Forms.StatusStrip();
            toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            toolStripStatusLabelVersion = new System.Windows.Forms.ToolStripStatusLabel();
            toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            button7 = new System.Windows.Forms.Button();
            button8 = new System.Windows.Forms.Button();
            button9 = new System.Windows.Forms.Button();
            groupBox2 = new System.Windows.Forms.GroupBox();
            button10 = new System.Windows.Forms.Button();
            textBoxDefaultBackupFolder = new System.Windows.Forms.TextBox();
            folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            notifyIcon1 = new System.Windows.Forms.NotifyIcon(components);
            errorProvider1 = new System.Windows.Forms.ErrorProvider(components);
            groupBox3 = new System.Windows.Forms.GroupBox();
            comboBoxServers = new System.Windows.Forms.ComboBox();
            checkBox1 = new System.Windows.Forms.CheckBox();
            label6 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            button11 = new System.Windows.Forms.Button();
            textBoxPassword = new System.Windows.Forms.TextBox();
            textBoxLogin = new System.Windows.Forms.TextBox();
            textBoxPort = new System.Windows.Forms.TextBox();
            listViewDatabase = new System.Windows.Forms.ListView();
            columnHeader1 = new System.Windows.Forms.ColumnHeader();
            columnHeader2 = new System.Windows.Forms.ColumnHeader();
            picLoader = new System.Windows.Forms.PictureBox();
            checkBoxShowDirectory = new System.Windows.Forms.CheckBox();
            checkBoxShowMessageInfo = new System.Windows.Forms.CheckBox();
            statusStrip1.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picLoader).BeginInit();
            SuspendLayout();
            // 
            // statusStrip1
            // 
            statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { toolStripStatusLabel1, toolStripStatusLabelVersion, toolStripStatusLabel2 });
            statusStrip1.Location = new System.Drawing.Point(0, 366);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new System.Drawing.Size(589, 22);
            statusStrip1.TabIndex = 8;
            statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            toolStripStatusLabel1.Size = new System.Drawing.Size(0, 17);
            // 
            // toolStripStatusLabelVersion
            // 
            toolStripStatusLabelVersion.Name = "toolStripStatusLabelVersion";
            toolStripStatusLabelVersion.Size = new System.Drawing.Size(47, 17);
            toolStripStatusLabelVersion.Text = "ver 47.7";
            toolStripStatusLabelVersion.Click += toolStripStatusLabelVersion_Click;
            // 
            // toolStripStatusLabel2
            // 
            toolStripStatusLabel2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            toolStripStatusLabel2.IsLink = true;
            toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            toolStripStatusLabel2.Size = new System.Drawing.Size(496, 17);
            toolStripStatusLabel2.Spring = true;
            toolStripStatusLabel2.Text = "https://netcode.one";
            toolStripStatusLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            toolStripStatusLabel2.Click += toolStripStatusLabel2_Click;
            // 
            // button7
            // 
            button7.Location = new System.Drawing.Point(398, 298);
            button7.Name = "button7";
            button7.Size = new System.Drawing.Size(75, 38);
            button7.TabIndex = 11;
            button7.Text = "Backup";
            button7.UseVisualStyleBackColor = true;
            button7.Click += button7_Click;
            // 
            // button8
            // 
            button8.Location = new System.Drawing.Point(496, 298);
            button8.Name = "button8";
            button8.Size = new System.Drawing.Size(75, 38);
            button8.TabIndex = 12;
            button8.Text = "Restore";
            button8.UseVisualStyleBackColor = true;
            button8.Click += button8_Click;
            // 
            // button9
            // 
            button9.Location = new System.Drawing.Point(286, 298);
            button9.Name = "button9";
            button9.Size = new System.Drawing.Size(75, 38);
            button9.TabIndex = 14;
            button9.Text = "Check Database";
            button9.UseVisualStyleBackColor = true;
            button9.Click += button9_Click;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(button10);
            groupBox2.Controls.Add(textBoxDefaultBackupFolder);
            groupBox2.Location = new System.Drawing.Point(10, 202);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new System.Drawing.Size(293, 59);
            groupBox2.TabIndex = 15;
            groupBox2.TabStop = false;
            groupBox2.Text = "Backup Path";
            // 
            // button10
            // 
            button10.Location = new System.Drawing.Point(256, 22);
            button10.Name = "button10";
            button10.Size = new System.Drawing.Size(30, 20);
            button10.TabIndex = 1;
            button10.Text = "...";
            button10.UseVisualStyleBackColor = true;
            button10.Click += button10_Click;
            // 
            // textBoxDefaultBackupFolder
            // 
            textBoxDefaultBackupFolder.Location = new System.Drawing.Point(15, 22);
            textBoxDefaultBackupFolder.Name = "textBoxDefaultBackupFolder";
            textBoxDefaultBackupFolder.Size = new System.Drawing.Size(236, 23);
            textBoxDefaultBackupFolder.TabIndex = 0;
            // 
            // notifyIcon1
            // 
            notifyIcon1.Icon = (System.Drawing.Icon)resources.GetObject("notifyIcon1.Icon");
            notifyIcon1.Text = "MySQLBackup";
            notifyIcon1.Visible = true;
            notifyIcon1.MouseClick += notifyIcon1_MouseClick;
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(comboBoxServers);
            groupBox3.Controls.Add(checkBox1);
            groupBox3.Controls.Add(label6);
            groupBox3.Controls.Add(groupBox2);
            groupBox3.Controls.Add(label5);
            groupBox3.Controls.Add(label4);
            groupBox3.Controls.Add(label3);
            groupBox3.Controls.Add(label2);
            groupBox3.Controls.Add(button11);
            groupBox3.Controls.Add(textBoxPassword);
            groupBox3.Controls.Add(textBoxLogin);
            groupBox3.Controls.Add(textBoxPort);
            groupBox3.Location = new System.Drawing.Point(269, 12);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new System.Drawing.Size(312, 280);
            groupBox3.TabIndex = 16;
            groupBox3.TabStop = false;
            groupBox3.Text = "MySQL Server";
            // 
            // comboBoxServers
            // 
            comboBoxServers.FormattingEnabled = true;
            comboBoxServers.Location = new System.Drawing.Point(105, 29);
            comboBoxServers.Name = "comboBoxServers";
            comboBoxServers.Size = new System.Drawing.Size(151, 23);
            comboBoxServers.TabIndex = 17;
            comboBoxServers.SelectedIndexChanged += comboBoxServers_SelectedIndexChanged;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new System.Drawing.Point(105, 141);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new System.Drawing.Size(108, 19);
            checkBox1.TabIndex = 22;
            checkBox1.Text = "Show Password";
            checkBox1.UseVisualStyleBackColor = true;
            checkBox1.CheckedChanged += checkBox1_CheckedChanged_1;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new System.Drawing.Point(108, 12);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(16, 15);
            label6.TabIndex = 21;
            label6.Text = "...";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(37, 118);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(57, 15);
            label5.TabIndex = 19;
            label5.Text = "Password";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(57, 89);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(37, 15);
            label4.TabIndex = 18;
            label4.Text = "Login";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(65, 62);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(29, 15);
            label3.TabIndex = 17;
            label3.Text = "Port";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(18, 32);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(74, 15);
            label2.TabIndex = 16;
            label2.Text = "Server Name";
            // 
            // button11
            // 
            button11.Location = new System.Drawing.Point(107, 166);
            button11.Name = "button11";
            button11.Size = new System.Drawing.Size(114, 23);
            button11.TabIndex = 15;
            button11.Text = "Check conection";
            button11.UseVisualStyleBackColor = true;
            button11.Click += button11_Click;
            // 
            // textBoxPassword
            // 
            textBoxPassword.Location = new System.Drawing.Point(105, 116);
            textBoxPassword.Name = "textBoxPassword";
            textBoxPassword.Size = new System.Drawing.Size(100, 23);
            textBoxPassword.TabIndex = 3;
            // 
            // textBoxLogin
            // 
            textBoxLogin.Location = new System.Drawing.Point(105, 86);
            textBoxLogin.Name = "textBoxLogin";
            textBoxLogin.Size = new System.Drawing.Size(100, 23);
            textBoxLogin.TabIndex = 2;
            // 
            // textBoxPort
            // 
            textBoxPort.Location = new System.Drawing.Point(105, 58);
            textBoxPort.Name = "textBoxPort";
            textBoxPort.Size = new System.Drawing.Size(47, 23);
            textBoxPort.TabIndex = 1;
            // 
            // listViewDatabase
            // 
            listViewDatabase.Activation = System.Windows.Forms.ItemActivation.OneClick;
            listViewDatabase.CheckBoxes = true;
            listViewDatabase.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] { columnHeader1, columnHeader2 });
            listViewDatabase.FullRowSelect = true;
            listViewDatabase.HoverSelection = true;
            listViewDatabase.Location = new System.Drawing.Point(8, 10);
            listViewDatabase.Name = "listViewDatabase";
            listViewDatabase.Size = new System.Drawing.Size(256, 351);
            listViewDatabase.TabIndex = 17;
            listViewDatabase.UseCompatibleStateImageBehavior = false;
            listViewDatabase.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "Database";
            columnHeader1.Width = 190;
            // 
            // columnHeader2
            // 
            columnHeader2.Text = "Size";
            columnHeader2.Width = 90;
            // 
            // picLoader
            // 
            picLoader.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            picLoader.Image = Properties.Resources.MEBIB;
            picLoader.Location = new System.Drawing.Point(94, 137);
            picLoader.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            picLoader.Name = "picLoader";
            picLoader.Size = new System.Drawing.Size(80, 62);
            picLoader.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            picLoader.TabIndex = 18;
            picLoader.TabStop = false;
            picLoader.WaitOnLoad = true;
            // 
            // checkBoxShowDirectory
            // 
            checkBoxShowDirectory.AutoSize = true;
            checkBoxShowDirectory.Location = new System.Drawing.Point(286, 342);
            checkBoxShowDirectory.Name = "checkBoxShowDirectory";
            checkBoxShowDirectory.Size = new System.Drawing.Size(106, 19);
            checkBoxShowDirectory.TabIndex = 23;
            checkBoxShowDirectory.Text = "Show Directory";
            checkBoxShowDirectory.UseVisualStyleBackColor = true;
            checkBoxShowDirectory.CheckedChanged += checkBoxShowDirectory_CheckedChanged;
            // 
            // checkBoxShowMessageInfo
            // 
            checkBoxShowMessageInfo.AutoSize = true;
            checkBoxShowMessageInfo.Location = new System.Drawing.Point(413, 342);
            checkBoxShowMessageInfo.Name = "checkBoxShowMessageInfo";
            checkBoxShowMessageInfo.Size = new System.Drawing.Size(128, 19);
            checkBoxShowMessageInfo.TabIndex = 24;
            checkBoxShowMessageInfo.Text = "Show Message Info";
            checkBoxShowMessageInfo.UseVisualStyleBackColor = true;
            checkBoxShowMessageInfo.CheckedChanged += checkBoxShowMessageInfo_CheckedChanged;
            // 
            // Form1
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(589, 388);
            Controls.Add(checkBoxShowMessageInfo);
            Controls.Add(checkBoxShowDirectory);
            Controls.Add(picLoader);
            Controls.Add(listViewDatabase);
            Controls.Add(groupBox3);
            Controls.Add(button9);
            Controls.Add(button8);
            Controls.Add(button7);
            Controls.Add(statusStrip1);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "Form1";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "MySQLBackup";
            Load += Form1_Load;
            Resize += Form1_Resize;
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picLoader).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.TextBox textBoxDefaultBackupFolder;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.TextBox textBoxLogin;
        private System.Windows.Forms.TextBox textBoxPort;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelVersion;
        private System.Windows.Forms.ComboBox comboBoxServers;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.ListView listViewDatabase;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.PictureBox picLoader;
        private System.Windows.Forms.CheckBox checkBoxShowDirectory;
        private System.Windows.Forms.CheckBox checkBoxShowMessageInfo;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
    }
}
