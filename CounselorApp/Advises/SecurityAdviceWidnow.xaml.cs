

namespace CounselorApp.Advises
{
    using Oracle.ManagedDataAccess.Client;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Net.NetworkInformation;
    using System.Net.Sockets;
    using System.Windows;
    using System.Windows.Documents;



    public partial class SecurityAdviceWidnow : Window
    {


        #region Control Mapping
        #endregion Control Mapping


        #region Members
        Process v;
        Process p;
        private OracleCommand cmd;
        private TextRange textRangebody;
        private string sourceWeb;
        private string advicePathWebNotProected;
        private string advicePathWebProected;
        #endregion Members


        #region Constructor
        public SecurityAdviceWidnow(string adviceName)
        {
            try
            {
                InitializeComponent();
                cmd = new OracleCommand();
                textRangebody = new TextRange(BodyTextBox.Document.ContentStart, BodyTextBox.Document.ContentEnd);
                textRangebody.Text = GetAdviceBody(adviceName);
                this.advicePathWebNotProected = GetPathWebNotProtected(adviceName);
                this.advicePathWebProected = GetPathWebProtected(adviceName);
                this.sourceWeb = GetSource(adviceName);
            }
            catch (Exception ex)
            {
                Logger.Instance.Error("Error while trying to open  Security Advice Widnow ", ex);
            }
        }
        #endregion Constructor


        #region Private Methods

        private void ShutDownClick(object sender, RoutedEventArgs e)
        {
            try
            {
                ShutDownVulnerable();
                ShutDownProtected();
                Logger.Instance.Info("ShutDownClick()");
            }
            catch (Exception ex)
            {

                Logger.Instance.Error("Exception while trying to Shut Down Click", ex);
            }

        }

        private void ClickOnOpenSource(object sender, RoutedEventArgs e)
        {
            try
            {
                Web_Server_Source();
                Logger.Instance.Info("ClickOnOpenSource(" + this.sourceWeb + ")");
            }
            catch (Exception ex)
            {
                Logger.Instance.Error("Error while trying to open source advice ", ex);
            }
        }

        private void ClickVulnerableWeb(object sender, RoutedEventArgs e)
        {
            try
            {
                Web_Server_Vulnerable();
                Logger.Instance.Info("ClickVulnerableWeb()");
            }
            catch (Exception ex)
            {
                Logger.Instance.Error("Error while trying to open Vulnerable Web ", ex);
            }
        }

        private void ClickProtectedWeb(object sender, RoutedEventArgs e)
        {
            try
            {

                Web_Server_Protected();
                Logger.Instance.Info("ClickProtectedWeb()");
            }
            catch (Exception ex)
            {
                Logger.Instance.Error("Error while trying to open Protected  Web ", ex);
            }
        }

        private string GetSource(string nameAdvice)
        {
            try
            {
                cmd.Connection = OracleSingletonConnection.Instance;
                string advice = "select advises.SOURCE_ADVICE from advises where advises.advice_name = '" + nameAdvice + "'";
                cmd.CommandText = advice;
                return Convert.ToString(cmd.ExecuteScalar());
            }
            catch (Exception ex)
            {
                throw new System.Exception("Exception while trying to get source  ", ex);
            }
        }

        private string GetAdviceBody(string nameAdvice)
        {
            try
            {
                cmd.Connection = OracleSingletonConnection.Instance;
                string advice = "select advises.advice_text from advises where advises.advice_name = '" + nameAdvice + "'";
                cmd.CommandText = advice;
                return Convert.ToString(cmd.ExecuteScalar());
            }
            catch (Exception ex)
            {
                throw new Exception("Error while trying to get advice body ", ex);
            }
        }

        private string GetPathWebNotProtected(string nameAdvice)
        {
            try
            {
                cmd.Connection = OracleSingletonConnection.Instance;
                string advice = "select advises.PATH_NOT_PROTECTED_WEB from advises where advises.advice_name = '" + nameAdvice + "'";
                cmd.CommandText = advice;
                return Convert.ToString(cmd.ExecuteScalar());
            }
            catch (Exception ex)
            {
                throw new System.Exception("Exception while trying to Get Path Web Not Protected ", ex);
            }
        }

        private string GetPathWebProtected(string nameAdvice)
        {
            try
            {
                cmd.Connection = OracleSingletonConnection.Instance;
                string advice = "select advises.PATH_PROTECTED_WEB from advises where advises.advice_name = '" + nameAdvice + "'";
                cmd.CommandText = advice;
                return Convert.ToString(cmd.ExecuteScalar());
            }
            catch (Exception ex)
            {
                throw new System.Exception("Exception while trying to Get Path Web Protected ", ex);
            }
        }

        private void ClickOnBackButton(object sender, RoutedEventArgs e)
        {
            try
            {
                var adviceMain = new AdviceMainWindow();
                adviceMain.Show();
                this.Close();
                Logger.Instance.Info("ClickOnBackButton()");
            }
            catch (Exception ex)
            {
                Logger.Instance.Error("Error while trying to click back button", ex);
            }
        }
        #endregion Private Methods


        #region Public Methods
        /// <summary>
        /// Get the local IP address
        /// </summary>
        /// <returns></returns>
        public static string GetWirelessIPAddress()
        {

            return NetworkInterface
            .GetAllNetworkInterfaces()
            .Where(i => i.NetworkInterfaceType == NetworkInterfaceType.Wireless80211)
            .SelectMany(i => i.GetIPProperties().UnicastAddresses)
            .Where(a => a.Address.AddressFamily == AddressFamily.InterNetwork)
            .Select(a => a.Address.ToString())
            .ToList()[2];
        }


        public void Web_Server_Vulnerable()
        {
            try
            {
                string fileName = GetNameOfFileToStartTheServer(this.advicePathWebNotProected);
                v = new Process();
                v.StartInfo.WorkingDirectory = this.advicePathWebNotProected;
                v.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                v.StartInfo.FileName = "cmd.exe";
                v.StartInfo.Arguments = "/c node " + fileName + "";
                v.Start();
                OpenBrowserVulnerable();
            }
            catch (Exception)
            {

                throw new Exception("Error while trying to open web server vulnerable");
            }
        }
        public void Web_Server_Protected()
        {
            try
            {
                string fileName = GetNameOfFileToStartTheServer(this.advicePathWebProected);
                p = new Process();
                p.StartInfo.WorkingDirectory = this.advicePathWebProected;
                p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                p.StartInfo.FileName = "cmd.exe";
                p.StartInfo.Arguments = "/c node " + fileName + "";
                p.Start();
                OpenBrowserProtected();
            }
            catch (Exception ex)
            {

                throw new Exception("Error while trying to open web server Protected", ex);
            }
        }
        public void Web_Server_Source()
        {
            try
            {
                Process.Start(this.sourceWeb);
            }
            catch (Exception ex)
            {

                throw new Exception("Error while trying to open web source ", ex);
            }

        }
        public void ShutDownProtected()
        {
            try
            {
                p.Kill();
                p.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception("Exception while trying to Shut Down Protected ", ex);
            }
        }

        public void ShutDownVulnerable()
        {
            try
            {
                v.Kill();
                v.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception("Exception while trying to Shut Down Vulnerable ", ex);
            }
        }
        public void OpenBrowserVulnerable()
        {
            try
            {
                Process.Start("http://" + GetWirelessIPAddress() + ":3000");
            }
            catch (Exception ex)
            {
                throw new Exception("Exception while trying Open Browser Vulnerable ", ex);
            }
        }
        public void OpenBrowserProtected()
        {
            try
            {
                Process.Start("http://" + GetWirelessIPAddress() + ":3001");
            }
            catch (Exception ex)
            {
                throw new Exception("Exception while trying Open Browser Protected ", ex);
            }

        }
        /// <summary>
        /// Shuold return the single file that responsible to start the server
        /// </summary>
        /// <param name="pathToCreateServer">Path of the diretory of the server</param>
        /// <returns></returns>
        private string GetNameOfFileToStartTheServer(string pathToCreateServer)
        {
            try
            {
                string pathOfTheFile = Directory.GetFiles(pathToCreateServer).Where(m => m.Contains("app.js") || m.Contains(".exe")).FirstOrDefault();
                if (string.IsNullOrEmpty(pathOfTheFile))
                    throw new Exception("No file found");
                List<string> listPath = pathOfTheFile.Split('\\').ToList();
                return listPath[listPath.Count - 1];
            }
            catch (Exception ex)
            {
                throw new Exception("There is no server in the attached folder!!", ex);
            }
        }
        #endregion Public Methods







    }
}
