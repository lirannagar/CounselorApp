using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Forms;

namespace CounselorApp.Administrator
{
    /// <summary>
    /// Interaction logic for EditAdvice.xaml
    /// </summary>
    public partial class EditAdvice : Window
    {

        #region Control Mapping
        #endregion Control Mapping


        #region Members
        private OracleCommand cmd;
        private string nameAdvice;
        private string oldPathWebNotProtected;
        private string oldePathWebProtected;
        private TextRange textRangebody;
        #endregion Members


        #region Constructor
        public EditAdvice(string nameAdvice)
        {
            try
            {
                InitializeComponent();              
                this.nameAdvice = nameAdvice;
                cmd = new OracleCommand();
                NameTextBox.Text = nameAdvice;
                textRangebody = new TextRange(BodyTextBox.Document.ContentStart, BodyTextBox.Document.ContentEnd);
                textRangebody.Text = GetAdviceBody(nameAdvice);
                VulnerableWebTextBox.Text = GetPathWebNotProtected(nameAdvice);
                ProtectedWebTextBox.Text = GetPathWebProtected(nameAdvice);
                SourceAdviceTextBox.Text = GetSource(nameAdvice);
                this.oldPathWebNotProtected = VulnerableWebTextBox.Text;
                this.oldePathWebProtected = ProtectedWebTextBox.Text;              
                Logger.Instance.Info("EditAdvice(" + nameAdvice + ")");
            }
            catch (Exception ex)
            {
                Logger.Instance.Error("Error while trying to open edit advice", ex);
            }

        }
        #endregion Constructor


        #region Private Methods
        private void ClickOnBack(object sender, RoutedEventArgs e)
        {
            try
            {
                var menegedWindow = new MenageAdvice();
                menegedWindow.Show();
                this.Close();
                Logger.Instance.Info("ClickOnBack()");
            }
            catch (Exception ex)
            {
                Logger.Instance.Error("Error while trying to click On Back", ex);
            }
        }

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
                Logger.Instance.Error("Error while trying to Click Upload Vulnerable Web Button", ex);
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
                Logger.Instance.Error("Error while trying to Click Upload Protected Web Button", ex);
            }
        }

        private void UpdateButtonClick(object sender, RoutedEventArgs e)
        {
            try
            {
                CheckTextBoxField();             
                TransferDirectory(ProtectedWebTextBox.Text);                                  
                TransferDirectory(VulnerableWebTextBox.Text);             
                DeleteOldFiles(VulnerableWebTextBox.Text, ProtectedWebTextBox.Text);
                UploadVulnerableWebButton.IsEnabled = false;
                VulnerableWebTextBox.IsEnabled = false;
                UploadProtectedWebButton.IsEnabled = false;
                ProtectedWebTextBox.IsEnabled = false;
                UploadFile.IsEnabled = false;
                UpdateAdvice(this.nameAdvice, this.textRangebody.Text, ProtectedWebTextBox.Text, VulnerableWebTextBox.Text, SourceAdviceTextBox.Text);
                Logger.Instance.Info("UpdateButtonClick()");
            }
            catch (Exception ex)
            {
                Logger.Instance.Error("Error while trying to Click update  button", ex);
            }
        }
        private void CheckTextBoxField()
        {
     
            if(string.IsNullOrEmpty(this.nameAdvice) || 
                (string.IsNullOrEmpty(this.textRangebody.Text) || this.textRangebody.Text.Equals("\r\n") )|| 
                string.IsNullOrEmpty(ProtectedWebTextBox.Text) ||
                string.IsNullOrEmpty(VulnerableWebTextBox.Text) ||
                string.IsNullOrEmpty(SourceAdviceTextBox.Text))
            {
                throw new Exception("One of the fileds are empty!");
            }

        }
        /// <summary>
        /// Transfer Directory to the System Directory 
        /// </summary>
        /// <param name="pathText">Path of the server directory </param>
        private void TransferDirectory(string pathText)
        {
            Directory.Move(pathText, GetPathOfServerInSourceDirectory(pathText));
        }

        /// <summary>
        /// Turn the path to the path in the system directory
        /// </summary>
        /// <param name="pathText">Path of Web Server</param>
        /// <returns></returns>
        private string  GetPathOfServerInSourceDirectory(string pathText)
        {
            string destinationFile = pathText;
            List<string> listPath = destinationFile.Split('\\').ToList();
            var nameDirectory = listPath[listPath.Count - 1];

            return Directory.GetCurrentDirectory() + '\\' + nameDirectory;
        }

        /// <summary>
        /// Delete old Directories of web servers if changed
        /// </summary>
        /// <param name="VulnerableWeb">New Vulnerable Web path</param>
        /// <param name="protectedWeb">New protected Web path</param>
        private void DeleteOldFiles(string VulnerableWeb , string protectedWeb)
        {
            try
            {        
                if (!GetPathOfServerInSourceDirectory(protectedWeb).Equals(GetPathOfServerInSourceDirectory(oldePathWebProtected)))
                {
                    if (Directory.Exists(GetPathOfServerInSourceDirectory(oldePathWebProtected)))
                    {
                        DeleteDirectory(GetPathOfServerInSourceDirectory(oldePathWebProtected));                       
                    }
                }
                if (!GetPathOfServerInSourceDirectory(VulnerableWeb).Equals(GetPathOfServerInSourceDirectory(oldePathWebProtected)))
                {
                    if (Directory.Exists(GetPathOfServerInSourceDirectory(oldePathWebProtected)))
                    {
                        DeleteDirectory(GetPathOfServerInSourceDirectory(oldePathWebProtected));
                    }
                }         
            }
            catch (Exception ex)
            {
                throw new Exception("Exception while trying to Delete Old Files", ex);
            }

        }
        /// <summary>
        /// Deletes all contents of the folder
        /// </summary>
        /// <param name="path">Path of directory</param>
        private void DeleteDirectory(string path)
        {
            foreach (string directory in Directory.GetDirectories(path))
            {
                DeleteDirectory(directory);
            }
            try
            {
                Directory.Delete(path, true);
            }
            catch (IOException)
            {
                Directory.Delete(path, true);
            }
            catch (UnauthorizedAccessException)
            {
                Directory.Delete(path, true);
            }
        }
        /// <summary>
        /// Get advice body from oracle DB
        /// </summary>
        /// <param name="nameAdvice">name of advice</param>
        /// <returns></returns>
        private string GetAdviceBody(string nameAdvice)
        {
            try
            {
                cmd.Connection = OracleSingletonConnection.Instance;
                string advice = "select advises.advice_text"
                    + " from advises"
                    + " where advises.advice_name = '" + nameAdvice + "'";
                cmd.CommandText = advice;
                Logger.Instance.Info("GetAdviceBody(" + nameAdvice + ")");
                return Convert.ToString(cmd.ExecuteScalar());
            }
            catch (Exception ex)
            {

                throw new Exception("Exception while trying to Get Advice Body", ex);
            }

        }
        /// <summary>
        /// Get Path Web Not Protected from oracle DB
        /// </summary>
        /// <param name="nameAdvice">name of advice</param>
        /// <returns></returns>
        private string GetPathWebNotProtected(string nameAdvice)
        {
            try
            {
                cmd.Connection = OracleSingletonConnection.Instance;
                string advice = "select advises.PATH_NOT_PROTECTED_WEB"
                    + " from advises"
                    + " where advises.advice_name = '" + nameAdvice + "'";
                cmd.CommandText = advice;
                Logger.Instance.Info("GetPathWebNotProtected(" + nameAdvice + ")");
                return Convert.ToString(cmd.ExecuteScalar());
            }
            catch (Exception ex)
            {
                throw new Exception("Exception while trying to Get Path Web Not Protected", ex);
            }
        }
        /// <summary>
        /// Get Path Web Protected from oracle DB
        /// </summary>
        /// <param name="nameAdvice">name of advice</param>
        /// <returns></returns>
        private string GetPathWebProtected(string nameAdvice)
        {
            try
            {
                cmd.Connection = OracleSingletonConnection.Instance;
                string advice = "select advises.PATH_PROTECTED_WEB"
                    + " from advises"
                    + " where advises.advice_name = '" + nameAdvice + "'";
                cmd.CommandText = advice;
                Logger.Instance.Info("GetPathWebProtected(" + nameAdvice + ")");
                return Convert.ToString(cmd.ExecuteScalar());
            }
            catch (Exception ex)
            {

                throw new Exception("Exception while trying to Get Path Web Protected", ex);
            }

        }
        /// <summary>
        /// /Get body from oracle DB
        /// </summary>
        /// <param name="nameAdvice">name of advice</param>
        /// <returns></returns>
        private string GetBody(string nameAdvice)
        {
            try
            {
                cmd.Connection = OracleSingletonConnection.Instance;
                string advice = "select advises.advice_text"
                    + " from advises"
                    + " where advises.advice_name = '" + nameAdvice + "'";
                cmd.CommandText = advice;
                Logger.Instance.Info("GetBody(" + nameAdvice + ")");
                return Convert.ToString(cmd.ExecuteScalar());
            }
            catch (Exception ex)
            {

                throw new Exception("Exception while trying to Get body", ex);
            }

        }
        /// <summary>
        /// Get source from oracle DB
        /// </summary>
        /// <param name="nameAdvice">name of advice</param>
        /// <returns></returns>
        private string GetSource(string nameAdvice)
        {
            try
            {
                cmd.Connection = OracleSingletonConnection.Instance;
                string advice = "select advises.source_advice"
                    + " from advises"
                    + " where advises.advice_name = '" + nameAdvice + "'";
                cmd.CommandText = advice;
                Logger.Instance.Info("GetSource(" + nameAdvice + ")");
                return Convert.ToString(cmd.ExecuteScalar());
            }
            catch (Exception ex)
            {

                throw new Exception("Exception while trying to Get source", ex);
            }

        }
        /// <summary>
        /// Update values into Oracle data base
        /// </summary>
        /// <param name="name">Name of advice</param>
        /// <param name="body">Body of advice</param>
        /// <param name="pathProtected">Protected web path</param>
        /// <param name="pathVulnerable">Vulnerable web path</param>
        /// <param name="source">Source of advice</param>
        private void UpdateAdvice(string name, string body, string pathProtected, string pathVulnerable, string source)
        {
            try
            {
                cmd.Connection = OracleSingletonConnection.Instance;
                string updateString = "UPDATE advises " +
                            "SET advice_name = '" + name + "', " +
                            "advice_text = '" + body + "', " +
                            "path_protected_web = '" + pathProtected + "', " +
                            "path_not_protected_web = '" + pathVulnerable + "', " +
                            "SOURCE_ADVICE = '" + source + "' " +
                            "WHERE advice_name like '" + name + "'";
                cmd.CommandText = updateString;
                cmd.ExecuteNonQuery();
                Logger.Instance.Info("UpdateAdvice("+name+")");
            }
            catch (Exception ex)
            {
                throw new Exception("Exception  while trying to  Update Advice to the DB", ex);
            }

        }



        #endregion Private Methods

        #region Public Methods
        #endregion Public Methods


    }
}
