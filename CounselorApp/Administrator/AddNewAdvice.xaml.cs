

namespace CounselorApp.Administrator
{

    using Oracle.ManagedDataAccess.Client;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Windows;
    using System.Windows.Documents;
    using System.Windows.Forms;



    public partial class AddNewAdvice : Window
    {
        #region Control Mapping
        #endregion Control Mapping


        #region Members
        private OracleCommand cmd;
        private string nameAdmin;
        private string textBoxBody;
        #endregion Members


        #region Constructor
        public AddNewAdvice(string nameAdmin)
        {
            InitializeComponent();
            this.nameAdmin = nameAdmin;
            logInLebal.Content = nameAdmin;
            cmd = new OracleCommand();
            Logger.Instance.Info("AddNewAdvice()");
        }
        #endregion Constructor


        #region Private Methods
        /// <summary>
        /// Upload to the system web server that vulnerable agaist the attack 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        /// <summary>
        /// Upload to the system web server that protected agaist the attack 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        /// <summary>
        /// Upload all the data to the Causelor App
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UploadButton(object sender, RoutedEventArgs e)
        {
            try
            {
               // CheckValues();
                TransferDirectory(ProtectedWebTextBox.Text);
                TransferDirectory(VulnerableWebTextBox.Text);
                UploadVulnerableWebButton.IsEnabled = false;
                VulnerableWebTextBox.IsEnabled = false;
                UploadProtectedWebButton.IsEnabled = false;
                ProtectedWebTextBox.IsEnabled = false;
                SourceAdviceTextBox.IsEnabled = false;
                UploadFile.IsEnabled = false;
                NameTextBox.IsEnabled = false;
                BodyTextBox.Document.IsEnabled = false;


                string bodyAdviceText = new TextRange(BodyTextBox.Document.ContentStart, BodyTextBox.Document.ContentEnd).Text;
                this.textBoxBody = bodyAdviceText;
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
        /// Check if all field are correct
        /// </summary>
        private void CheckValues()
        {
            if (!SourceAdviceTextBox.Text.Contains("http://"))
            {
                throw new Exception("Source must be an URL");
                ErrorMSG.Visibility = Visibility.Visible;
                ErrorMSG.Content = "Source must be an URL";
            }

            if (string.IsNullOrEmpty(NameTextBox.Text) ||
                string.IsNullOrEmpty(textBoxBody) ||
                string.IsNullOrEmpty(textBoxBody) ||
                string.IsNullOrEmpty(ProtectedWebTextBox.Text) ||
                string.IsNullOrEmpty(VulnerableWebTextBox.Text))
            {
                throw new Exception("Some values are empty");
                ErrorMSG.Visibility = Visibility.Visible;
                ErrorMSG.Content = "Some values are empty";
            }
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
        /// <summary>
        /// Inserting all the information to the Oracle DB
        /// </summary>
        /// <param name="id">Automatic ID</param>
        /// <param name="Name">Name of attack</param>
        /// <param name="body">Body of the advice</param>
        /// <param name="pathProtected">Protected Web server path</param>
        /// <param name="pathVulnerable">Vulnerable web server path</param>
        /// <param name="source">Source of the advice URL</param>
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
        /// <summary>
        /// Back to the admin main window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClickOnBack(object sender, RoutedEventArgs e)
        {
            try
            {
                var adminWindow = new MenageAdvice(this.nameAdmin);
                adminWindow.Show();
                this.Close();
                Logger.Instance.Info("ClickOnBack()");
            }
            catch (Exception ex)
            {
                Logger.Instance.Error("Exception while trying to click on back button", ex);
            }
        }

        #endregion Private Methods

        #region Public Methods
        #endregion Public Methods





    }



}
