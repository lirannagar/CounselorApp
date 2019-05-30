

namespace CounselorApp.Administrator
{
    using CodeGenerator;
    using Oracle.ManagedDataAccess.Client;
    using System;
    using System.CodeDom;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Net.Sockets;
    using System.Windows;
    using System.Windows.Documents;
    using System.Windows.Forms;



    public partial class AddNewAdvice : Window
    {
        #region Control Mapping
        const string PROJECT_NAME = "CodeGenerator";
        const string NAME_SPACE_NAME = "CodeGenerator";
        const string TEMPLATE_NEW_CLASS = "Web_Server_Agaist_";
        #endregion Control Mapping


        #region Members
        private OracleCommand cmd;
        #endregion Members


        #region Constructor
        public AddNewAdvice()
        {
            InitializeComponent();
            cmd = new OracleCommand();
            Logger.Instance.Info("AddNewAdvice()");
        }
        #endregion Constructor


        #region Private Methods

        private void ClickUploadVulnerableWebButton(object sender, RoutedEventArgs e)
        {
            try
            {
                var dialog = new FolderBrowserDialog();
                dialog.ShowDialog();
                VulnerableWebTextBox.Text = dialog.SelectedPath;
                Logger.Instance.Info("ClickUploadVulnerableWebButton()");
            }
            catch (Exception ex)
            {
                Logger.Instance.Error("Error while trying to Click Upload Vulnerable Web Button  ", ex);
            }
        }

        private void ClickUploadProtectedWebButton(object sender, RoutedEventArgs e)
        {
            try
            {
                var dialog = new FolderBrowserDialog();
                dialog.ShowDialog();
                ProtectedWebTextBox.Text = dialog.SelectedPath;
                Logger.Instance.Info("ClickUploadProtectedWebButton()");
            }
            catch (Exception ex)
            {
                Logger.Instance.Error("Error while trying to Click Upload Protected Web Button ", ex);
            }
        }

        private void UploadButton(object sender, RoutedEventArgs e)
        {
            try
            {
                string className = TEMPLATE_NEW_CLASS + NameTextBox.Text;
                string nameSpace = NAME_SPACE_NAME;
                string project = PROJECT_NAME;
                TransferDirectory(ProtectedWebTextBox.Text);
                TransferDirectory(VulnerableWebTextBox.Text);
                string pathToCreateServer = GetPathOfServerInSourceDirectory(VulnerableWebTextBox.Text);
                string nameFile = GetNameOfFileToStartTheServer(pathToCreateServer);
                var cds = new ClassGenerator();
                cds.SetIPAddress(GetLocalIPAddress());
                CodeCompileUnit newClassCode = cds.GenerateCSharpCode(className, nameSpace, pathToCreateServer, nameFile);
                cds.GenerateCode(newClassCode, className);
                cds.AddClassToSolution(className, Directory.GetCurrentDirectory(), project);

                UploadVulnerableWebButton.IsEnabled = false;
                VulnerableWebTextBox.IsEnabled = false;
                UploadProtectedWebButton.IsEnabled = false;
                ProtectedWebTextBox.IsEnabled = false;
                UploadFile.IsEnabled = false;

                string bodyAdviceText = new TextRange(BodyTextBox.Document.ContentStart, BodyTextBox.Document.ContentEnd).Text;
                cmd.Connection = OracleSingletonConnection.Instance;
                cmd.CommandText = "SELECT advice_seq.nextval from dual";
                string id = Convert.ToInt32(cmd.ExecuteScalar()).ToString();
                InsertDataToDB(id, NameTextBox.Text, bodyAdviceText, GetPathOfServerInSourceDirectory(ProtectedWebTextBox.Text), GetPathOfServerInSourceDirectory(VulnerableWebTextBox.Text), SourceAdviceTextBox.Text);
                Logger.Instance.Info("UploadButton()");
            }
            catch (Exception ex)
            {
                Logger.Instance.Error("Error while trying to Click Upload Protected Web Button  ", ex);
            }
        }

        /// <summary>
        /// Shuold return the single file that responsible to start the server
        /// </summary>
        /// <param name="pathToCreateServer">Path of the diretory of the server</param>
        /// <returns></returns>
        private string GetNameOfFileToStartTheServer(string pathToCreateServer)
        { 
            string pathOfTheFile = Directory.GetFiles(pathToCreateServer).Where(m => m.Contains(".js") || m.Contains(".exe")).FirstOrDefault();
            List<string> listPath = pathOfTheFile.Split('\\').ToList();
            return listPath[listPath.Count - 1];
        }

        /// <summary>
        /// Transfer Directory to the System Directory 
        /// </summary>
        /// <param name="pathText">Path of the server directory </param>
        private void TransferDirectory(string pathText)
        {
            try
            {
                Directory.Move(pathText, GetPathOfServerInSourceDirectory(pathText));
            }
            catch (Exception ex)
            {

                throw new Exception("Error while trying to Transfer Directory ", ex);
            }

        }

        /// <summary>
        /// Turn the path to the path in the system directory
        /// </summary>
        /// <param name="pathText">Path of Web Server</param>
        /// <returns></returns>
        private string GetPathOfServerInSourceDirectory(string pathText)
        {
            try
            {
                string destinationFile = pathText;
                List<string> listPath = destinationFile.Split('\\').ToList();
                var nameDirectory = listPath[listPath.Count - 1];
                return Directory.GetCurrentDirectory() + '\\' + nameDirectory;
            }
            catch (Exception ex)
            {
                throw new Exception("Exception while to trying to Get Path Of Server In Source Directory", ex);
            }

        }

        private void InsertDataToDB(string id, string Name, string body, string pathProtected, string pathVulnerable, string source)
        {
            try
            {
                cmd.Connection = OracleSingletonConnection.Instance;
                string newAdviceString = "INSERT INTO advises "
                 + "(id_advise, advice_name, advice_text, path_protected_web, path_not_protected_web, SOURCE_ADVICE) "
                 + "VALUES "
                 + "(" + id + ", '" + Name + "' , '" + body + "', '" + pathProtected + "', '" + pathVulnerable + "', '" + source + "')";
                cmd.CommandText = newAdviceString;
                cmd.ExecuteNonQuery();
                Logger.Instance.Info("InsertToDB (" + Name + ")");
            }
            catch (Exception ex)
            {
                throw new Exception("Exception while trying to InsertToDB", ex);
            }

        }
        private void ClickOnBack(object sender, RoutedEventArgs e)
        {
            try
            {
                var adminWindow = new MenageAdvice();
                adminWindow.Show();
                this.Close();
                Logger.Instance.Info("ClickOnBack()");
            }
            catch (Exception ex)
            {
                Logger.Instance.Error("Exception while trying to click on back button", ex);
            }
        }
        /// <summary>
        /// Get the local IP address
        /// </summary>
        /// <returns></returns>
        private string GetLocalIPAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            throw new Exception("No network adapters with an IPv4 address in the system!");
        }
        #endregion Private Methods


        #region Public Methods
        #endregion Public Methods





    }



}
