using MySqlConnector;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using Microsoft.Extensions.Configuration;
using EnCryptDecrypt;
using Newtonsoft.Json.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static Mysqlx.Expect.Open.Types.Condition.Types;
using System.Threading.Channels;


//  Install-package Microsoft.EntityFrameworkCore.MySql
//  Install - package Microsoft.EntityFrameworkcore.Design
//  Install-package Microsoft.EntityFrameworkcore.Tools

namespace MySQLBackup
{
    public partial class Form1 : Form
    {
        string index = "0";
        int processId = 0;
        Process gprocess;

        string defaultBackupFolder = @"C:\";
        string server = "127.0.0.1";
        string port = "3306";
        string login = "rafal";
        string pass = "rafal";

        string version = "";
        bool showDirectory = false;
        bool showMessageInfo = false;
        string app = "";

        string currentDatabase = "";

        string conStr = "";

        bool connection = false;

        string jsonFile = "MySQLBackup.servers.json";

        bool appVisible = true;

        public Form1()
        {
            InitializeComponent();
        }

        void readConfigDataFromJson()
        {
            app = new ConfigurationBuilder().AddJsonFile("MySQLBackup.servers.json").Build().GetSection("Config")["app"];
            //toolStripStatusLabelVersion.Text = version;

            version = new ConfigurationBuilder().AddJsonFile("MySQLBackup.servers.json").Build().GetSection("Config")["version"];

            toolStripStatusLabelVersion.Text = app + " " + version;

            string sshowDirectory = new ConfigurationBuilder().AddJsonFile("MySQLBackup.servers.json").Build().GetSection("Config")["showDirectory"];
            if (sshowDirectory != null)
                if (sshowDirectory.ToLower() == "yes" || sshowDirectory.ToLower() == "true")
                {
                    showDirectory = true;
                }

            string sshowMessageInfo = new ConfigurationBuilder().AddJsonFile("MySQLBackup.servers.json").Build().GetSection("Config")["showMessageInfo"];
            if (sshowDirectory != null)
                if (sshowMessageInfo.ToLower() == "yes" || sshowMessageInfo.ToLower() == "true")
                {
                    showMessageInfo = true;
                }
        }

        private void SetLoading(bool displayLoader)
        {
            if (displayLoader)
            {
                this.Invoke((MethodInvoker)delegate
                {
                    picLoader.Visible = true;
                    this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
                });
            }
            else
            {
                this.Invoke((MethodInvoker)delegate
                {
                    picLoader.Visible = false;
                    this.Cursor = System.Windows.Forms.Cursors.Default;
                });
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;

            SetLoading(false);

            textBoxPassword.PasswordChar = '*';
            picLoader.BackColor = Color.Transparent;

            //read version app from Json
            readConfigDataFromJson();

            // set checkBox from global
            setCheckBoxShowDirectory();

            // set checkBox from global
            setCheckBoxShowMessageInfo();

            // fill ComboBox and insert 1 server data
            // fill Boxes data
            GetAllServersFocusFirstFromJson();

            // set glogal
            setGlobalFromTextBox();

            //check conn to mysql 
            if (checkConnection())
            {
                if (Directory.Exists(defaultBackupFolder))
                {
                    //show database
                    showDatabaseNameSize();
                }
                else
                {
                    //
                }
            }
        }
        public bool checkConnection() //R
        {
            label6.Text = "Connection False";
            bool conn = false;

            try
            {
                string ver = "?";
                string serverName = server; // Address server (for local database "localhost")
                string userName = login;  // user name
                //string dbName = basename; //Name database not need
                string portName = port; // Port for connection
                string password = pass; // Password for connection 

                conStr = "server=" + serverName +
                           ";user=" + userName +
                           ";port=" + portName +
                           ";password=" + password + ";Connection Timeout=4";

                using (MySqlConnection con = new MySqlConnection(conStr))
                {
                    string sql0 = "select @@version;"; //any request for cheking
                    MySqlCommand cmd0 = new MySqlCommand(sql0, con);
                    con.Open();
                    ver = cmd0.ExecuteScalar().ToString();

                    label6.Text = ver;
                    con.Close();
                    conn = true;
                }
            }
            catch (Exception)
            {
                label6.Text = "Connection False";
                conn = false;
            }
            return conn;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            //check builder connection from global data
            if (checkConnection())
            {
                //runBackup();
                try
                {
                    Thread threadInput = new Thread(runBackup);
                    threadInput.Start();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }
        public void runBackup()
        {
            //Install-Package MySqlBackup.NET
            //Install-Package MySqlBackup.Net.DevartExpress
            //Install-Package MySqlBackup.NET.MySqlConnector

            //backup
            toolStripStatusLabel1.Text = "Backup";

            bool directoryExists = false;

            if (Directory.Exists(@defaultBackupFolder))
            {
                directoryExists = true;
            }
            else
            {
                MessageBox.Show(string.Format("{0} Directory does not exist!", @defaultBackupFolder));
                return;
            }

            for (int i = 0; i < listViewDatabase.CheckedItems.Count; i++)
            {
                //set focus item
                setFocusLlistViewDatabaseItem(i);


                string seletedItem = listViewDatabase.CheckedItems[i].SubItems[0].Text;

                string @dbname = (string)seletedItem; currentDatabase = dbname;

                if (showMessageInfo)
                    MessageBox.Show("Backup for database " + @dbname);

                string serverName = server;
                string userName = login;
                string portName = port;
                string password = pass;
                conStr = "server=" + serverName +
                               ";user=" + userName +
                               ";port=" + portName +
                               ";password=" + password + ";charset=utf8mb4;";

                string constring = conStr + "database = " + @dbname + ";";

                using (MySqlConnection conn = new MySqlConnection(constring))
                {
                    using (MySqlCommand cmd = new MySqlCommand())
                    {
                        using (MySqlBackup mb = new MySqlBackup(cmd))
                        {
                            cmd.Connection = conn;
                            conn.Open();
                            mb.ExportInfo.AddCreateDatabase = true;
                            mb.ExportInfo.ExportTableStructure = true;
                            mb.ExportInfo.ExportRows = true;
                            mb.ExportInfo.ResetAutoIncrement = true;

                            mb.ExportInfo.AddCreateDatabase = true;
                            mb.ExportInfo.ExportTableStructure = true;
                            mb.ExportInfo.ExportRows = true;
                            mb.ExportInfo.RecordDumpTime = true;
                            mb.ExportInfo.ResetAutoIncrement = false;
                            mb.ExportInfo.MaxSqlLength = 104857600; //100MB
                            mb.ExportInfo.ExportFunctions = true;
                            mb.ExportInfo.ExportProcedures = true;
                            mb.ExportInfo.ExportTriggers = true;
                            mb.ExportInfo.ExportEvents = true;
                            mb.ExportInfo.ExportViews = true;
                            mb.ExportInfo.ExportRoutinesWithoutDefiner = false;
                            mb.ExportInfo.RowsExportMode = RowsDataExportMode.Replace;
                            mb.ExportInfo.WrapWithinTransaction = false;
                            mb.ExportInfo.GetTotalRowsMode = GetTotalRowsMethod.SelectCount;
                            mb.ExportInfo.BlobExportMode = BlobDataExportMode.HexString;

                            mb.ExportProgressChanged += new MySqlBackup.exportProgressChange(Mb_ExportProgressChanged);
                            mb.ExportCompleted += new MySqlBackup.exportComplete(Mb_ExportCompleted);

                            string dumpFile = System.IO.Path.Combine(defaultBackupFolder, @dbname) + ".sql";

                            cmd.CommandTimeout = 60;
                            cmd.CommandText = "use `" + @dbname + "`;";
                            cmd.ExecuteNonQuery();

                            mb.ExportToFile(dumpFile);

                            conn.Close(); //R
                        }
                    }
                }
            }
            if (showDirectory)
                if (directoryExists)
                {
                    ProcessStartInfo startInfo = new ProcessStartInfo
                    {
                        Arguments = @defaultBackupFolder,
                        FileName = "explorer.exe"
                    };

                    Process.Start(startInfo);
                }
                else
                {
                    MessageBox.Show(string.Format("{0} Directory does not exist!", @defaultBackupFolder));
                    return;
                }
        }
        private void Mb_ExportCompleted(object sender, ExportCompleteArgs e)
        {
            this.Invoke((MethodInvoker)delegate
            {
                toolStripStatusLabel1.Text = "Finish";
            });

            string errMsg = null;
            if (e.LastError != null)
            {
                errMsg = e.LastError.ToString();
                MessageBox.Show("Export " + e.CompletionType.ToString() + " " + currentDatabase + " " + Environment.NewLine + errMsg);
            }
            else
            {
                errMsg = "";

                if (showMessageInfo)
                    MessageBox.Show("Export " + e.CompletionType.ToString() + " " + currentDatabase + " " + Environment.NewLine + errMsg);
            }

        }
        private void Mb_ExportProgressChanged(object sender, ExportProgressArgs e)
        {
            this.Invoke((MethodInvoker)delegate
            {
                toolStripStatusLabel1.Text = (e.CurrentRowIndexInAllTables + " " + e.TotalRowsInAllTables);
            });
        }


        private void button8_Click(object sender, EventArgs e)
        {
            //check builder connection from global data
            if (checkConnection())
            {
                //runRestore();
                try
                {
                    Thread threadInput = new Thread(runRestore);
                    threadInput.Start();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }

            }
        }
        public void runRestore()
        {
            //restore
            toolStripStatusLabel1.Text = "Restore";


            bool directoryExists = false;

            if (Directory.Exists(@defaultBackupFolder))
            {
                directoryExists = true;
            }
            else
            {
                MessageBox.Show(string.Format("{0} Directory does not exist!", @defaultBackupFolder));
                return;
            }

            string serverName = server;
            string userName = login;
            string portName = port;
            string password = pass;
            conStr = "server=" + serverName +
                           ";user=" + userName +
                           //";database=" + dbName +
                           ";port=" + portName +
                           ";password=" + password + ";";
            string connstr = conStr + "sslmode=none;charset=utf8mb4;";


            try
            {
                //conn.Open();
                //cmd.Connection = conn;
                //cmd.CommandTimeout = 60;

                string[] files = System.IO.Directory.GetFiles(defaultBackupFolder);

                //check if checked
                for (int i = 0; i < listViewDatabase.CheckedItems.Count; i++)
                {
                    //set focus item
                    setFocusLlistViewDatabaseItem(i);

                    string seletedItem = listViewDatabase.CheckedItems[i].SubItems[0].Text;

                    string @dbname = (string)seletedItem; currentDatabase = @dbname;

                    bool exist = false;

                    if (showMessageInfo)
                        MessageBox.Show("Restore for database " + @dbname);

                    // check if exists backup file
                    foreach (string file in files)
                    {
                        if (file.ToLower().EndsWith(".sql"))
                        {
                            string dbNamefile = System.IO.Path.GetFileNameWithoutExtension(file);

                            //if checking name = name file.sql
                            if (@dbname == dbNamefile)
                            {
                                if (showMessageInfo)
                                    MessageBox.Show("Run Restore for file " + dbNamefile);

                                using (MySqlConnection conn = new MySqlConnection(connstr))
                                {
                                    using (MySqlCommand cmd = new MySqlCommand())
                                    {
                                        using (MySqlBackup mb = new MySqlBackup(cmd))
                                        {

                                            conn.Open();
                                            cmd.Connection = conn;
                                            cmd.CommandTimeout = 60;

                                            string dbName = System.IO.Path.GetFileNameWithoutExtension(file);

                                            cmd.CommandTimeout = 60;
                                            cmd.CommandText = "create database if not exists `" + dbName + "`";
                                            cmd.ExecuteNonQuery();

                                            cmd.CommandText = "use `" + dbName + "`";
                                            cmd.ExecuteNonQuery();

                                            mb.ImportCompleted += new MySqlBackup.importComplete(Mb_ImportCompleted);
                                            mb.ImportProgressChanged += new MySqlBackup.importProgressChange(Mb_ImportProgressChanged);

                                            mb.ImportFromFile(file);

                                            exist = true;

                                            conn.Close();
                                        }
                                    }
                                }
                            }
                        }
                    }
                    if (!exist)
                    {
                        MessageBox.Show("Not exists backup for " + @dbname);
                    }
                }
                //conn.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message + " " + e.InnerException?.Message);
            }
            if (showDirectory)
                if (directoryExists)
                {
                    ProcessStartInfo startInfo = new ProcessStartInfo
                    {
                        Arguments = @defaultBackupFolder,
                        FileName = "explorer.exe"
                    };
                    Process.Start(startInfo);
                }
                else
                {
                    MessageBox.Show(string.Format("{0} Directory does not exist!", @defaultBackupFolder));
                    return;
                }
        }
        private void Mb_ImportCompleted(object sender, ImportCompleteArgs e)
        {
            this.Invoke((MethodInvoker)delegate
            {
                toolStripStatusLabel1.Text = "Finish";

                string errMsg = null;
                if (e.LastError != null)
                {
                    errMsg = e.LastError.ToString();
                    MessageBox.Show("Import " + e.CompleteType.ToString() + " " + currentDatabase + " " + Environment.NewLine + errMsg);
                }
                else
                {
                    errMsg = "";

                    if (showMessageInfo)
                        MessageBox.Show("Import " + e.CompleteType.ToString() + " " + currentDatabase + " " + Environment.NewLine + errMsg);
                }
            });
        }
        private void Mb_ImportProgressChanged(object sender, ImportProgressArgs e)
        {
            this.Invoke((MethodInvoker)delegate
            {
                toolStripStatusLabel1.Text = (e.PercentageCompleted.ToString());// OR + " " + e.CurrentBytes + " " + e.TotalBytes);
            });

        }

        private void button9_Click(object sender, EventArgs e)
        {
            //read version app fron Json
            readConfigDataFromJson();

            //check builder connection from global data
            if (checkConnection())
            {
                if (Directory.Exists(defaultBackupFolder))
                {
                    //show database
                    //showDatabaseNameSize();
                    try
                    {
                        Thread threadInput = new Thread(showDatabaseNameSize);
                        threadInput.Start();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }
                else
                {
                    MessageBox.Show(string.Format("{0} Directory does not exist!", @defaultBackupFolder));
                }
            }
        }



        public void showDatabaseNameSize() //R
        {
            //show database

            listViewDatabase.Items.Clear();

            string serverName = server;
            string userName = login;
            string portName = port;
            string password = pass;
            conStr = "server=" + serverName +
                           ";user=" + userName +
                           ";port=" + portName +
                           ";password=" + password + ";";

            string connstr = conStr;

            using (MySqlConnection conn = new MySqlConnection(connstr))
            {
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    using (MySqlBackup mb = new MySqlBackup(cmd))
                    {
                        conn.Open();
                        cmd.Connection = conn;
                        cmd.CommandText = "show databases;";

                        cmd.CommandText = "SELECT table_schema AS 'Database', " +
                                          "ROUND(SUM(data_length + index_length),0) AS 'Size' FROM " +
                                          "information_schema.TABLES GROUP BY table_schema";


                        MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                        DataTable dtDbList = new DataTable();
                        da.Fill(dtDbList);

                        int i = 0;
                        foreach (DataRow dr in dtDbList.Rows)
                        {
                            String dbname = dr[0] + "";

                            // change long data to string KB, MB, GB
                            string size = ReturnSize((long)(decimal)dr[1]);


                            // skip mysql default system tables
                            switch (dbname)
                            {
                                case "sys":
                                case "performance_schema":
                                case "mysql":
                                case "information_schema":
                                    continue;
                            }

                            //Fill listView
                            listViewDatabase.Items.Add(new ListViewItem(new string[] { dbname, size }));

                            //check file names from defaultBackupFolder
                            string[] files = System.IO.Directory.GetFiles(defaultBackupFolder);
                            foreach (string file in files)
                            {
                                if (file.ToLower().EndsWith(".sql"))
                                {
                                    string dbNamefile = System.IO.Path.GetFileNameWithoutExtension(file);
                                    if (dbname == dbNamefile)
                                    {
                                        // check to checked
                                        listViewDatabase.Items[i].Checked = true;
                                    }
                                }
                            }
                            i++;

                        }
                        conn.Close();
                    }
                }
            }
        }

        static string ReturnSize(Int64 value, int decimalPlaces = 2)
        {
            string[] SizeSuffixes =
                   { "bytes", "KB", "MB", "GB", "TB", "PB", "EB", "ZB", "YB" };

            if (decimalPlaces < 0) { throw new ArgumentOutOfRangeException("decimalPlaces"); }
            if (value < 0) { return "-" + ReturnSize(-value, decimalPlaces); }
            if (value == 0) { return string.Format("{0:n" + decimalPlaces + "} bytes", 0); }

            // mag is 0 for bytes, 1 for KB, 2, for MB, etc.
            int mag = (int)Math.Log(value, 1024);

            // 1L << (mag * 10) == 2 ^ (10 * mag) 
            // [i.e. the number of bytes in the unit corresponding to mag]
            decimal adjustedSize = (decimal)value / (1L << (mag * 10));

            // make adjustment when the value is large enough that
            // it would round up to 1000 or more
            if (Math.Round(adjustedSize, decimalPlaces) >= 1000)
            {
                mag += 1;
                adjustedSize /= 1024;
            }

            return string.Format("{0:n" + decimalPlaces + "} {1}", adjustedSize, SizeSuffixes[mag]);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            //Directory backup restore for server

            folderBrowserDialog1.Description = "Here indicate the destination directory where the Database copies will be created";

            if (Directory.Exists(textBoxDefaultBackupFolder.Text))
            {
                folderBrowserDialog1.SelectedPath = @textBoxDefaultBackupFolder.Text;
                folderBrowserDialog1.InitialDirectory = @textBoxDefaultBackupFolder.Text;
            }
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                textBoxDefaultBackupFolder.Text = folderBrowserDialog1.SelectedPath;
                defaultBackupFolder = textBoxDefaultBackupFolder.Text;


                if (!string.IsNullOrEmpty(server))
                {
                    if (ifExistsServerInJson(server))
                    {
                        UpdateServerToJson(server);
                    }
                    else
                    {
                        AddServerIfNotExistsToJson();
                    }
                }
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(defaultBackupFolder))
            {
                try
                {
                    //testConnection();
                    Thread threadInput = new Thread(testConnection);
                    threadInput.Start();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            else
            {
                MessageBox.Show("Please set Backup directory path.");
            }

        }
        public void testConnection() //R
        {
            SetLoading(true);

            if (wasChangeBoxDataVsGlobalData())
            {
                //very impotrant server name is changed
                server = comboBoxServers.Text;

                if (!string.IsNullOrEmpty(server))
                {
                    if (ifExistsServerInJson(server))
                    {
                        UpdateServerToJson(server);
                    }
                    else
                    {
                        AddServerIfNotExistsToJson();
                    }
                }

                //reload
                // fill ComboBox and insert current server data
                ReloadAllServersFocusServerFromJson(server);

                setGlobalFromTextBox();
            }
            else
            {
                //MessageBox.Show("Nothing changed");
            }

            //check builder connection from global data
            if (checkConnection())
            {
                if (Directory.Exists(defaultBackupFolder))
                {
                    //show database
                    showDatabaseNameSize();
                }
                else
                {
                    //
                }
            }
            SetLoading(false);
        }

        public bool wasChangeBoxDataVsGlobalData()
        {
            bool was_shanged = false;
            //glogal
            if (defaultBackupFolder != textBoxDefaultBackupFolder.Text) { was_shanged = true; }
            if (server != comboBoxServers.Text) { was_shanged = true; }
            if (port != textBoxPort.Text) { was_shanged = true; }
            if (login != textBoxLogin.Text) { was_shanged = true; }
            if (pass != textBoxPassword.Text) { was_shanged = true; }

            //MessageBox.Show("Global: " + server + " comboBoxServers.Text: " + comboBoxServers.Text);

            return was_shanged;
        }

        public void saveDataToJson() //R
        {
            // save to MySQLBackup.servers.json
            AddOrUpdateDataConfigJson("Config:app", app);
            AddOrUpdateDataConfigJson("Config:version", version);
            AddOrUpdateDataConfigJson("Config:defaultBackupFolder", defaultBackupFolder);
        }

        public static void AddOrUpdateDataConfigJson<T>(string key, T value)
        {
            //Install-Package Newtonsoft.Json
            //NuGet\Install-Package Microsoft.Extensions.Configuration.Json -Version 7.0.0

            try
            {
                var filePath = Path.Combine(AppContext.BaseDirectory, "MySQLBackup.servers.json");
                string json = File.ReadAllText(filePath);
                dynamic jsonObj = Newtonsoft.Json.JsonConvert.DeserializeObject(json);

                var sectionPath = key.Split(":")[0];

                if (!string.IsNullOrEmpty(sectionPath))
                {
                    var keyPath = key.Split(":")[1];
                    jsonObj[sectionPath][keyPath] = value;
                }
                else
                {
                    jsonObj[sectionPath] = value; // if no sectionpath just set the value
                }

                string output = Newtonsoft.Json.JsonConvert.SerializeObject(jsonObj, Newtonsoft.Json.Formatting.Indented);
                File.WriteAllText(filePath, output);
            }
            catch (ConfigurationErrorsException)
            {
                Console.WriteLine("Error writing app settings");
            }
        }

        private void ReloadAllServersFocusServerFromJson(string _server)
        {
            int index = 0;

            comboBoxServers.Items.Clear();

            var json = File.ReadAllText("MySQLBackup.servers.json");
            try
            {
                var jObject = JObject.Parse(json);

                if (jObject != null)
                {
                    JArray serversArrary = (JArray)jObject["servers"];
                    if (serversArrary != null)
                    {
                        foreach (var item in serversArrary)
                        {
                            comboBoxServers.Items.Add(item["server"]);
                            if (item["server"].ToString() == _server)
                            {
                                comboBoxServers.SelectedIndex = index;
                                server = comboBoxServers.SelectedItem.ToString();
                            }
                            index++;
                        }
                    }
                }
                GetServerFromJsonToGlobal(server);
            }
            catch (Exception)
            {
                throw;
            }
        }
        private void GetAllServersFocusFirstFromJson() //R
        {
            comboBoxServers.Items.Clear();

            var json = File.ReadAllText("MySQLBackup.servers.json");
            try
            {
                var jObject = JObject.Parse(json);

                if (jObject != null)
                {
                    JArray experiencesArrary = (JArray)jObject["servers"];
                    if (experiencesArrary.Count > 0)
                    {
                        foreach (var item in experiencesArrary)
                        {
                            comboBoxServers.Items.Add(item["server"]);
                        }
                        comboBoxServers.SelectedIndex = 0;
                        server = comboBoxServers.SelectedItem.ToString();

                        GetServerFromJsonToGlobal(server);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void checkBox1_CheckedChanged_1(object sender, EventArgs e)
        {
            if (checkBox1.Checked == false)
            {
                textBoxPassword.PasswordChar = '*';
            }
            if (checkBox1.Checked == true)
            {
                textBoxPassword.PasswordChar = '\0'; //(char)0; 
            }
        }

        private void comboBoxServers_SelectedIndexChanged(object sender, EventArgs e)
        {
            // server changed index
            server = comboBoxServers.SelectedItem.ToString();
            GetServerFromJsonToGlobal(server);

            listViewDatabase.Items.Clear();
        }
        private void GetServerFromJsonToGlobal(string _server)
        {
            var json = File.ReadAllText("MySQLBackup.servers.json");
            try
            {
                var jObject = JObject.Parse(json);

                if (jObject != null)
                {
                    JArray experiencesArrary = (JArray)jObject["servers"];
                    if (experiencesArrary != null)
                    {
                        foreach (var item in experiencesArrary)
                        {
                            if (item["server"].ToString() == _server)
                            {
                                //server

                                try
                                {
                                    pass = CryptorEngine.Decrypt(item["pass"].ToString(), true); //RAF
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show("Decrypt Error : " + ex.Message.ToString());
                                    return;
                                }

                                server = item["server"].ToString();
                                port = item["port"].ToString();

                                login = item["login"].ToString();
                                defaultBackupFolder = item["defaultBackupFolder"].ToString();

                                textBoxDefaultBackupFolder.Text = defaultBackupFolder;
                                comboBoxServers.Text = server;
                                textBoxPort.Text = port;
                                textBoxLogin.Text = login;
                                textBoxPassword.Text = pass;
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private bool ifExistsServerInJson(string _server)
        {
            bool present = false;

            var json = File.ReadAllText("MySQLBackup.servers.json");
            try
            {
                var jObject = JObject.Parse(json);

                if (jObject != null)
                {
                    JArray experiencesArrary = (JArray)jObject["servers"];
                    if (experiencesArrary != null)
                    {
                        foreach (var item in experiencesArrary)
                        {
                            if (item["server"].ToString() == _server)
                            {
                                //server
                                present = true;
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return present;
        }

        private void AddServerIfNotExistsToJson()
        {
            //glogal
            defaultBackupFolder = textBoxDefaultBackupFolder.Text;
            server = comboBoxServers.Text;
            port = textBoxPort.Text;
            login = textBoxLogin.Text;
            pass = textBoxPassword.Text;

            if (ifExistsServerInJson(server))
            {
                return;
            }

            var _newServer = "{ 'server': '" + server + "', 'port': '" + port + "', 'pass':  '" + CryptorEngine.Encrypt(@pass, true) + "', 'login': '" + login + "', 'defaultBackupFolder': '" + @defaultBackupFolder + "'}";
            var newServer = _newServer.Replace("\\", "\\\\");
            try
            {
                var json = File.ReadAllText("MySQLBackup.servers.json");
                var jsonObj = JObject.Parse(json);
                var serversArrary = jsonObj.GetValue("servers") as JArray;
                var newServers = JObject.Parse(newServer);
                serversArrary.Add(newServers);

                jsonObj["servers"] = serversArrary;
                string newJsonResult = Newtonsoft.Json.JsonConvert.SerializeObject(jsonObj,
                                       Newtonsoft.Json.Formatting.Indented);
                File.WriteAllText("MySQLBackup.servers.json", newJsonResult);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Add Error : " + ex.Message.ToString());
            }
        }

        private void UpdateServerToJson(string _server)
        {
            //glogal
            defaultBackupFolder = textBoxDefaultBackupFolder.Text;
            server = _server;
            port = textBoxPort.Text;
            login = textBoxLogin.Text;
            pass = textBoxPassword.Text;

            string json = File.ReadAllText("MySQLBackup.servers.json");

            try
            {
                var jObject = JObject.Parse(json);
                JArray serversArrary = (JArray)jObject["servers"];

                if (_server != "")
                {
                    foreach (var s in serversArrary.Where(obj => obj["server"].Value<string>() == _server))
                    {
                        s["port"] = !string.IsNullOrEmpty(port) ? port : "";
                        s["login"] = !string.IsNullOrEmpty(login) ? login : "";

                        s["pass"] = !string.IsNullOrEmpty(pass) ? CryptorEngine.Encrypt(pass, true) : CryptorEngine.Encrypt("", true);

                        s["defaultBackupFolder"] = !string.IsNullOrEmpty(defaultBackupFolder) ? defaultBackupFolder : "";
                    }

                    jObject["servers"] = serversArrary;
                    string output = Newtonsoft.Json.JsonConvert.SerializeObject(jObject, Newtonsoft.Json.Formatting.Indented);
                    File.WriteAllText("MySQLBackup.servers.json", output);
                }
                else
                {
                    MessageBox.Show("Invalid server name, Try Again!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Update Error : " + ex.Message.ToString());
            }

            setGlobalFromTextBox();
        }

        public void setGlobalFromTextBox() //R
        {
            //glogal
            defaultBackupFolder = textBoxDefaultBackupFolder.Text;
            server = comboBoxServers.Text;
            port = textBoxPort.Text;
            login = textBoxLogin.Text;
            pass = textBoxPassword.Text;
        }

        private void setFocusLlistViewDatabaseItem(int i)
        {
            if (listViewDatabase.Items.Count > 0)
            {
                listViewDatabase.SelectedItems.Clear();
                listViewDatabase.FocusedItem = null;

                this.listViewDatabase.Items[i].Selected = true;
                this.listViewDatabase.Items[i].Focused = true;
                this.listViewDatabase.Focus();
                this.listViewDatabase.FocusedItem = this.listViewDatabase.Items[i];
                Application.DoEvents();
            }
        }
        private void toolStripStatusLabelVersion_Click(object sender, EventArgs e)
        {

        }

        private void checkBoxShowDirectory_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxShowDirectory.Checked == false)
            {
                showDirectory = false;

                AddOrUpdateDataConfigJson("Config:showDirectory", "No");
            }
            if (checkBoxShowDirectory.Checked == true)
            {
                showDirectory = true;

                AddOrUpdateDataConfigJson("Config:showDirectory", "Yes");
            }
        }

        private string GetDetailsFromJson(string key)
        {
            var json = File.ReadAllText(jsonFile);
            try
            {
                var jObject = JObject.Parse(json);

                if (jObject != null)
                {
                    var config = jObject["Config"];
                    return config[key].ToString();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return "";
        }

        void setCheckBoxShowDirectory()
        {
            if (showDirectory == false)
            {
                checkBoxShowDirectory.Checked = false;
            }
            if (showDirectory == true)
            {
                checkBoxShowDirectory.Checked = true;
            }
        }
        void setCheckBoxShowMessageInfo()
        {
            if (showMessageInfo == false)
            {
                checkBoxShowMessageInfo.Checked = false;
            }
            if (showMessageInfo == true)
            {
                checkBoxShowMessageInfo.Checked = true;
            }
        }



        private void checkBoxShowMessageInfo_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxShowMessageInfo.Checked == false)
            {
                showMessageInfo = false;
                AddOrUpdateDataConfigJson("Config:showMessageInfo", "No");
            }
            if (checkBoxShowMessageInfo.Checked == true)
            {
                showMessageInfo = true;
                AddOrUpdateDataConfigJson("Config:showMessageInfo", "Yes");
            }
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                this.Hide();
                appVisible = false;
            }
        }

        private void notifyIcon1_MouseClick(object sender, MouseEventArgs e)
        {
            //this.Show();
            //this.WindowState = FormWindowState.Normal;

            if (!appVisible)
            {
                this.Show();
                this.WindowState = FormWindowState.Normal;
                appVisible = true;
            }
            else if (appVisible)
            {
                this.WindowState = FormWindowState.Minimized;
                this.Hide();
                appVisible = false;
            }
        }

        private void toolStripStatusLabel2_Click(object sender, EventArgs e)
        {
            try
            {
                VisitLink();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to open link that was clicked.");
            }
        }

        private void VisitLink()
        {
            System.Diagnostics.Process.Start(new ProcessStartInfo
            {
                FileName = "https://netcode.one",
                UseShellExecute = true
            });
        }
   


        //
    }
}
