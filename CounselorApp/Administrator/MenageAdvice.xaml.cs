using System;
using System.Collections.Generic;
using System.Windows;
using Oracle.ManagedDataAccess.Client;
using System.Windows.Controls;
using System.Linq;

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
        private string adminName;
        #endregion Members

        #region Properties
        List<string> ListOfAdvices
        {
            get
            {
                var advices = new List<string>();
                cmd.Connection = OracleSingletonConnection.Instance;
                string advice = "SELECT * FROM ADVISES ORDER BY ID_ADVISE";
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
        public MenageAdvice(string adminName)
        {
            InitializeComponent();
            this.adminName = adminName;
            logInLebal.Content = adminName;
            cmd = new OracleCommand();
            ListOfAdvices.ForEach(advice => ComboBoxAdvices.Items.Add(advice));
            Logger.Instance.Info("AdviceMainWindow()");
        }
        #endregion Constructor


        #region Private Methods
        private void ClickOnBack(object sender, RoutedEventArgs e)
        {
            try
            {
                var mainAdmin = new AdminMainWindow(adminName);
                mainAdmin.Show();
                this.Close();
                Logger.Instance.Info("ClickOnBack"); ;
            }
            catch (Exception ex)
            {

                Logger.Instance.Error("Error while trying to click on backButton", ex); ;
            }
        }
        private void DeleteAdvcieClick(object sender, RoutedEventArgs e)
        {
            try
            {
                cmd.Connection = OracleSingletonConnection.Instance;
                if (ComboBoxAdvices.Text.Equals(DEFAULT_COMBOBOX_SELECTION))
                {
                    throw new Exception("Please choose an opetion");
                }
                string choosenAdviceName = ComboBoxAdvices.Text;
                string deleteStatment = "DELETE FROM advises"
                                          + " where advises.ADVICE_NAME like '" + choosenAdviceName + "'";
                cmd.CommandText = deleteStatment;
                cmd.ExecuteNonQuery();
                foreach (var item in ComboBoxAdvices.Items)
                {
                    if (item.ToString().Equals(choosenAdviceName))
                    {
                        ComboBoxAdvices.Items.Remove(item);
                        ComboBoxAdvices.Text = DEFAULT_COMBOBOX_SELECTION;
                        break;
                    }                        
                }
                Logger.Instance.Info("DeleteAdvcieButton( " + choosenAdviceName + " )");
            }
            catch (Exception ex)
            {
                Logger.Instance.Error("Error while trying to Delete Advcie Button", ex);
            }
        }
        private void ClickEditAdviceButton(object sender, RoutedEventArgs e)
        {
            try
            {
                if (ComboBoxAdvices.Text.Equals(DEFAULT_COMBOBOX_SELECTION))
                {
                    throw new Exception("Please choose an opetion");
                }
                string choosenAdviceName = ComboBoxAdvices.Text;
                var editWin = new EditAdvice(choosenAdviceName, this.adminName);
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
                var newAdviceWin = new AddNewAdvice(this.adminName);
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
