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
            statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { toolStripStatusLabel1, toolStripStatusLabelVersion });
            statusStrip1.Location = new System.Drawing.Point(0, 491);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 16, 0);
            statusStrip1.Size = new System.Drawing.Size(673, 26);
            statusStrip1.TabIndex = 8;
            statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            toolStripStatusLabel1.Size = new System.Drawing.Size(0, 20);
            // 
            // toolStripStatusLabelVersion
            // 
            toolStripStatusLabelVersion.Name = "toolStripStatusLabelVersion";
            toolStripStatusLabelVersion.Size = new System.Drawing.Size(60, 20);
            toolStripStatusLabelVersion.Text = "ver 47.7";
            toolStripStatusLabelVersion.Click += toolStripStatusLabelVersion_Click;
            // 
            // button7
            // 
            button7.Location = new System.Drawing.Point(455, 397);
            button7.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            button7.Name = "button7";
            button7.Size = new System.Drawing.Size(86, 51);
            button7.TabIndex = 11;
            button7.Text = "Backup";
            button7.UseVisualStyleBackColor = true;
            button7.Click += button7_Click;
            // 
            // button8
            // 
            button8.Location = new System.Drawing.Point(567, 397);
            button8.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            button8.Name = "button8";
            button8.Size = new System.Drawing.Size(86, 51);
            button8.TabIndex = 12;
            button8.Text = "Restore";
            button8.UseVisualStyleBackColor = true;
            button8.Click += button8_Click;
            // 
            // button9
            // 
            button9.Location = new System.Drawing.Point(327, 397);
            button9.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            button9.Name = "button9";
            button9.Size = new System.Drawing.Size(86, 51);
            button9.TabIndex = 14;
            button9.Text = "Check Database";
            button9.UseVisualStyleBackColor = true;
            button9.Click += button9_Click;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(button10);
            groupBox2.Controls.Add(textBoxDefaultBackupFolder);
            groupBox2.Location = new System.Drawing.Point(11, 270);
            groupBox2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            groupBox2.Size = new System.Drawing.Size(335, 79);
            groupBox2.TabIndex = 15;
            groupBox2.TabStop = false;
            groupBox2.Text = "Backup Path";
            // 
            // button10
            // 
            button10.Location = new System.Drawing.Point(292, 29);
            button10.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            button10.Name = "button10";
            button10.Size = new System.Drawing.Size(34, 27);
            button10.TabIndex = 1;
            button10.Text = "...";
            button10.UseVisualStyleBackColor = true;
            button10.Click += button10_Click;
            // 
            // textBoxDefaultBackupFolder
            // 
            textBoxDefaultBackupFolder.Location = new System.Drawing.Point(17, 29);
            textBoxDefaultBackupFolder.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            textBoxDefaultBackupFolder.Name = "textBoxDefaultBackupFolder";
            textBoxDefaultBackupFolder.Size = new System.Drawing.Size(269, 27);
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
            groupBox3.Location = new System.Drawing.Point(307, 16);
            groupBox3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            groupBox3.Name = "groupBox3";
            groupBox3.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            groupBox3.Size = new System.Drawing.Size(357, 373);
            groupBox3.TabIndex = 16;
            groupBox3.TabStop = false;
            groupBox3.Text = "MySQL Server";
            // 
            // comboBoxServers
            // 
            comboBoxServers.FormattingEnabled = true;
            comboBoxServers.Location = new System.Drawing.Point(120, 39);
            comboBoxServers.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            comboBoxServers.Name = "comboBoxServers";
            comboBoxServers.Size = new System.Drawing.Size(172, 28);
            comboBoxServers.TabIndex = 17;
            comboBoxServers.SelectedIndexChanged += comboBoxServers_SelectedIndexChanged;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new System.Drawing.Point(120, 188);
            checkBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new System.Drawing.Size(132, 24);
            checkBox1.TabIndex = 22;
            checkBox1.Text = "Show Password";
            checkBox1.UseVisualStyleBackColor = true;
            checkBox1.CheckedChanged += checkBox1_CheckedChanged_1;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new System.Drawing.Point(124, 16);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(18, 20);
            label6.TabIndex = 21;
            label6.Text = "...";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(42, 158);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(70, 20);
            label5.TabIndex = 19;
            label5.Text = "Password";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(65, 119);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(46, 20);
            label4.TabIndex = 18;
            label4.Text = "Login";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(74, 82);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(35, 20);
            label3.TabIndex = 17;
            label3.Text = "Port";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(20, 42);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(94, 20);
            label2.TabIndex = 16;
            label2.Text = "Server Name";
            // 
            // button11
            // 
            button11.Location = new System.Drawing.Point(122, 222);
            button11.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            button11.Name = "button11";
            button11.Size = new System.Drawing.Size(130, 31);
            button11.TabIndex = 15;
            button11.Text = "Check conection";
            button11.UseVisualStyleBackColor = true;
            button11.Click += button11_Click;
            // 
            // textBoxPassword
            // 
            textBoxPassword.Location = new System.Drawing.Point(120, 154);
            textBoxPassword.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            textBoxPassword.Name = "textBoxPassword";
            textBoxPassword.Size = new System.Drawing.Size(114, 27);
            textBoxPassword.TabIndex = 3;
            // 
            // textBoxLogin
            // 
            textBoxLogin.Location = new System.Drawing.Point(120, 115);
            textBoxLogin.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            textBoxLogin.Name = "textBoxLogin";
            textBoxLogin.Size = new System.Drawing.Size(114, 27);
            textBoxLogin.TabIndex = 2;
            // 
            // textBoxPort
            // 
            textBoxPort.Location = new System.Drawing.Point(120, 78);
            textBoxPort.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            textBoxPort.Name = "textBoxPort";
            textBoxPort.Size = new System.Drawing.Size(53, 27);
            textBoxPort.TabIndex = 1;
            // 
            // listViewDatabase
            // 
            listViewDatabase.Activation = System.Windows.Forms.ItemActivation.OneClick;
            listViewDatabase.CheckBoxes = true;
            listViewDatabase.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] { columnHeader1, columnHeader2 });
            listViewDatabase.FullRowSelect = true;
            listViewDatabase.HoverSelection = true;
            listViewDatabase.Location = new System.Drawing.Point(9, 13);
            listViewDatabase.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            listViewDatabase.Name = "listViewDatabase";
            listViewDatabase.Size = new System.Drawing.Size(292, 467);
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
            picLoader.Location = new System.Drawing.Point(107, 183);
            picLoader.Name = "picLoader";
            picLoader.Size = new System.Drawing.Size(92, 83);
            picLoader.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            picLoader.TabIndex = 18;
            picLoader.TabStop = false;
            picLoader.WaitOnLoad = true;
            // 
            // checkBoxShowDirectory
            // 
            checkBoxShowDirectory.AutoSize = true;
            checkBoxShowDirectory.Location = new System.Drawing.Point(327, 456);
            checkBoxShowDirectory.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            checkBoxShowDirectory.Name = "checkBoxShowDirectory";
            checkBoxShowDirectory.Size = new System.Drawing.Size(132, 24);
            checkBoxShowDirectory.TabIndex = 23;
            checkBoxShowDirectory.Text = "Show Directory";
            checkBoxShowDirectory.UseVisualStyleBackColor = true;
            checkBoxShowDirectory.CheckedChanged += checkBoxShowDirectory_CheckedChanged;
            // 
            // checkBoxShowMessageInfo
            // 
            checkBoxShowMessageInfo.AutoSize = true;
            checkBoxShowMessageInfo.Location = new System.Drawing.Point(472, 456);
            checkBoxShowMessageInfo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            checkBoxShowMessageInfo.Name = "checkBoxShowMessageInfo";
            checkBoxShowMessageInfo.Size = new System.Drawing.Size(159, 24);
            checkBoxShowMessageInfo.TabIndex = 24;
            checkBoxShowMessageInfo.Text = "Show Message Info";
            checkBoxShowMessageInfo.UseVisualStyleBackColor = true;
            checkBoxShowMessageInfo.CheckedChanged += checkBoxShowMessageInfo_CheckedChanged;
            // 
            // Form1
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(673, 517);
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
            Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
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
    }
}
