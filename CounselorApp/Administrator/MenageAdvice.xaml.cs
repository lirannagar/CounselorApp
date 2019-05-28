using System;
using System.Collections.Generic;
using System.Windows;
using Oracle.ManagedDataAccess.Client;

namespace CounselorApp.Administrator
{
    /// <summary>
    /// Interaction logic for MenageAdvice.xaml
    /// </summary>
    public partial class MenageAdvice : Window
    {
        #region Control Mapping
        const string DEFAULT_COMBOBOX_SELECTION = "Select Advice To Edit";

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
                string advice = "select advises.advice_name from advises";
                cmd.CommandText = advice;
                advices.Add(Convert.ToString(cmd.ExecuteScalar()));
                return advices;
            }
        }
        #endregion Properties

        #region Constructor
        public MenageAdvice()
        {
            InitializeComponent();
            cmd = new OracleCommand();
            ListOfAdvices.ForEach(advice => ComboBoxAdvices.Items.Add(advice));
            Logger.Instance.Info("AdviceMainWindow()");
        }
        #endregion Constructor


        #region Private Methods
        private void ClickEditAdviceButton(object sender, RoutedEventArgs e)
        {
            try
            {
                if (ComboBoxAdvices.Text.Equals(DEFAULT_COMBOBOX_SELECTION))
                {
                    throw new Exception("Please choose an opetion");
                }
                string choosenAdviceName = ComboBoxAdvices.Text;
                var editWin = new EditAdvice(choosenAdviceName);
                editWin.Show();
                this.Close();
                Logger.Instance.Info("ClickEditAdviceButton( " + choosenAdviceName + " )");
            }
            catch (Exception ex)
            {
                Logger.Instance.Error("Error while trying to click edit advice button", ex);
            }
        }

        private void ClickAddNewAdviceButton(object sender, RoutedEventArgs e)
        {
            try
            {
                var newAdviceWin = new AddNewAdvice();
                newAdviceWin.Show();
                this.Close();
                Logger.Instance.Info("ClickAddNewAdviceButton()");
            }
            catch (Exception ex)
            {

                Logger.Instance.Error("Error while trying to Click Add New Advice Button", ex);
            }
        }
        #endregion Private Methods

        #region Public Methods
        #endregion Public Methods

    }
}
