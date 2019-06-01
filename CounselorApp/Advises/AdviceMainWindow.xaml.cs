
using Oracle.ManagedDataAccess.Client;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using CodeGenerator;

namespace CounselorApp.Advises
{
    /// <summary>
    /// Interaction logic for AdviceMainWindow.xaml
    /// </summary>
    public partial class AdviceMainWindow : Window
    {

        #region Control Mapping
        const string CHOOSE_ADVICE_STRING = "Choose Advice";
        const string NAME_SPACE_NAME = "CounselorApp.Advises";
        const string CLASS_NAME =  "SecurityAdviceWidnow";
        const string PROJECT_NAME = "CounselorApp";
        const string DIRECTORY_NAME = "Advises";
        const string TEMPLATE_NEW_CLASS = "Web_Server_Agaist_";
        #endregion Control Mapping

        #region Members
        private OracleCommand cmd;
        #endregion Members

        #region Properties
        List<string> ListOfAdvices
        {
            get
            {
                var advices = new List<string>();
                cmd.Connection = OracleSingletonConnection.Instance;
                string advice = "select advises.ID_ADVISE from advises";
                cmd.CommandText = advice;
                int startId = Convert.ToInt32(cmd.ExecuteScalar());
                cmd.CommandText = "select count(ID_ADVISE) from advises";
                int length = Convert.ToInt32(cmd.ExecuteScalar());
                for (int i = startId; i < (startId + length); i++)
                {
                    cmd.CommandText = "select ADVICE_NAME from advises  where ID_ADVISE = " + i + "";
                    advices.Add(Convert.ToString(cmd.ExecuteScalar()));
                }
                return advices;
            }
        }
        #endregion Properties

        #region Constructor
        public AdviceMainWindow()
        {
            InitializeComponent();
            cmd = new OracleCommand();
            ListOfAdvices.ForEach(advice => ComboBoxAdvices.Items.Add(advice));
            Logger.Instance.Info("AdviceMainWindow()");
        }
        #endregion Private Methods

        #region Public Methods
        #endregion Public Methods

        #region Private Methods
        private void ClickShowAdvice(object sender, RoutedEventArgs e)
        {

            if (!ComboBoxAdvices.SelectedValue.ToString().Contains(CHOOSE_ADVICE_STRING))
            {
                string nameClassToUpdate = TEMPLATE_NEW_CLASS + ComboBoxAdvices.SelectedValue.ToString();
                GenerateAdviceCode(nameClassToUpdate.Replace(" ","_"));
                var adviceWindow = new SecurityAdviceWidnow(ComboBoxAdvices.SelectedValue.ToString())
                {
                    Title = "Security Advice agaist " + ComboBoxAdvices.SelectedValue
                };               
                adviceWindow.Show();
                this.Close();
            }
        }
        /// <summary>
        /// Update The Advice page with his servers
        /// </summary>
        /// <param name="adviceClassName">Class name to update</param>
        private void GenerateAdviceCode(string adviceClassName)
        {
            string className = CLASS_NAME;
            string classnamespace = NAME_SPACE_NAME;
            string dir = DIRECTORY_NAME;
            string project = PROJECT_NAME;
            var cds = new SecurityAdviceUpdatePage();
            CodeCompileUnit newClassCode = cds.GenerateCSharpCode(className, classnamespace, adviceClassName);
            cds.GenerateCode(newClassCode, className);
            cds.SwitchClass(className, Directory.GetCurrentDirectory(), project, dir);
        }

        /// <summary>
        /// Back to the login window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClickOnBackButton(object sender, RoutedEventArgs e)
        {
            try
            {
                var logInWindow = new MainWindow();
                logInWindow.Show();
                this.Close();
                Logger.Instance.Info("ClickOnBackButton()");
            }
            catch (Exception ex)
            {
                Logger.Instance.Error("Error while trying to click on back button", ex);
            }
        }
        #endregion Private Methods

    }
}
