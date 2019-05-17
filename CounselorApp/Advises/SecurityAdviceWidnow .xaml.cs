using ConnectionOracle;
using Oracle.ManagedDataAccess.Client;
using System;
using System.IO;
using System.Windows;
using System.Windows.Xps.Packaging;
using Microsoft.Office.Interop.Word;
using Microsoft.Win32;
using Word = Microsoft.Office.Interop.Word;

namespace CounselorApp.Advises
{
    /// <summary>
    /// Interaction logic for SecurityAdviceWidnow.xaml
    /// </summary>
    public partial class SecurityAdviceWidnow : System.Windows.Window
    {


        #region Control Mapping
        #endregion Control Mapping


        #region Members
        private OracleCommand cmd;
        #endregion Members


        #region Constructor
        public SecurityAdviceWidnow(string adviceName)
        {
            try
            {
                cmd = new OracleCommand();
                string adviceBody = GetAdviceBody(adviceName);
                string advicePathWebNotProected = GetPathWebNotProtected(adviceName);
                string advicePathWebProected = GetPathWebProtected(adviceName);
                InitializeComponent();
                lebalText.Content = adviceBody;
            }
            catch (Exception ex)
            {
                Logger.Instance.Error("Error while trying to open  Security Advice Widnow" , ex);
            }
        }
        #endregion Constructor


        #region Private Methods

        private void ClickProtectedWeb(object sender, RoutedEventArgs e)
        {
            try
            {
                Logger.Instance.Info("ClickProtectedWeb()");
            }catch(Exception ex)
            {
                Logger.Instance.Error("Error while trying to open Protected  Web " , ex);
            }
        }

        private void ClickVulnerableWeb(object sender, RoutedEventArgs e)
        {
            try
            {
                Logger.Instance.Info("ClickVulnerableWeb()");
            }
            catch (Exception ex)
            {
                Logger.Instance.Error("Error while trying to open Vulnerable Web "  , ex);
            }
        }
        /// <summary>
        /// Get advice body from oracle DB
        /// </summary>
        /// <param name="nameAdvice">name of advice</param>
        /// <returns></returns>
        private string GetAdviceBody(string nameAdvice)
        {
            cmd.Connection = OracleSingletonConnection.Instance;
            string advice = "select advises.advice_text"
                + " from advises"
                + " where advises.advice_name = '" + nameAdvice + "'";
            cmd.CommandText = advice;
            return Convert.ToString(cmd.ExecuteScalar());
        }
        /// <summary>
        /// Get Path Web Not Protected from oracle DB
        /// </summary>
        /// <param name="nameAdvice">name of advice</param>
        /// <returns></returns>
        private string GetPathWebNotProtected(string nameAdvice)
        {
            cmd.Connection = OracleSingletonConnection.Instance;
            string advice = "select advises.PATH_NOT_PROTECTED_WEB"
                + " from advises"
                + " where advises.advice_name = '" + nameAdvice + "'";
            cmd.CommandText = advice;
            return Convert.ToString(cmd.ExecuteScalar());
        }
        /// <summary>
        /// Get Path Web Protected from oracle DB
        /// </summary>
        /// <param name="nameAdvice">name of advice</param>
        /// <returns></returns>
        private string GetPathWebProtected(string nameAdvice)
        {

            cmd.Connection = OracleSingletonConnection.Instance;
            string advice = "select advises.PATH_PROTECTED_WEB"
                + " from advises"
                + " where advises.advice_name = '" + nameAdvice + "'";
            cmd.CommandText = advice;
            return Convert.ToString(cmd.ExecuteScalar());
        }


        #endregion Private Methods

        #region Public Methods
        #endregion Public Methods

    }



}
