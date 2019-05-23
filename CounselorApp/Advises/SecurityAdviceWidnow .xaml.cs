using ConnectionOracle;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Documents;

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
                Logger.Instance.Error("Error while trying to open  Security Advice Widnow" , ex);
            }
        }
        #endregion Constructor


        #region Private Methods
        private void ClickOnOpenSource(object sender, RoutedEventArgs e)
        {
            try
            {
                Process.Start(this.sourceWeb);
                Logger.Instance.Info("ClickOnOpenSource("+this.sourceWeb+")");
            }
            catch (Exception ex)
            {
                Logger.Instance.Error("Error while trying to open source advice", ex);
            }
        }
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
        /// Get source advice
        /// </summary>
        /// <param name="nameAdvice">Name of attack</param>
        /// <returns></returns>
        private string GetSource(string nameAdvice)
        {
            try
            {
                cmd.Connection = OracleSingletonConnection.Instance;
                string advice = "select advises.SOURCE_ADVICE"
                    + " from advises"
                    + " where advises.advice_name = '" + nameAdvice + "'";
                cmd.CommandText = advice;
                return Convert.ToString(cmd.ExecuteScalar());
            }
            catch (Exception ex)
            {

                throw new Exception("Exception while trying to get source", ex) ;
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
                return Convert.ToString(cmd.ExecuteScalar());
            }
            catch (Exception ex)
            {
                throw new Exception("Exception while trying to  Get Advice Body", ex);
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
                return Convert.ToString(cmd.ExecuteScalar());
            }
            catch (Exception ex)
            {
                throw new Exception("Exception while trying to Get Path Web Not Protected", ex) ;
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
                return Convert.ToString(cmd.ExecuteScalar());
            }
            catch (Exception ex)
            {
                throw new Exception("Exception while trying to Get Path Web Protected", ex);
            }
          
        }
        #endregion Private Methods

        #region Public Methods
        #endregion Public Methods

 
    }



}
