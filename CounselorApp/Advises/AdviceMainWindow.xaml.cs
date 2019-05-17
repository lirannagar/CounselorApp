
using ConnectionOracle;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Linq;

namespace CounselorApp.Advises
{
    /// <summary>
    /// Interaction logic for AdviceMainWindow.xaml
    /// </summary>
    public partial class AdviceMainWindow : Window
    {

        #region Control Mapping
        const string CHOOSE_ADVICE_STRING = "Choose Advice";
        #endregion Control Mapping


        #region Members
        private OracleCommand cmd;
        #endregion Members

        #region Properties
        List<string> ListOfAdvices
        {
            get
            {
                int idCounter = 1;
                List<string> advices = new List<string>();
                string nameAdvice = "";
                while (true)
                {                   
                    cmd.Connection = OracleSingletonConnection.Instance;
                    string advice = "select advises.advice_name"
                        + " from advises"
                        + " where advises.id_advise = " + idCounter + "";
                    cmd.CommandText = advice;
                    nameAdvice = Convert.ToString(cmd.ExecuteScalar());
                    if (string.IsNullOrEmpty(nameAdvice))
                    {
                        break;
                    }
                    else
                    {
                        advices.Add(nameAdvice);
                        idCounter++;
                    }
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

        private void ClickShowAdvice(object sender, RoutedEventArgs e)
        {
           
            if (!ComboBoxAdvices.SelectedValue.ToString().Contains(CHOOSE_ADVICE_STRING))
            {
                var adviceWindow = new SecurityAdviceWidnow(ComboBoxAdvices.SelectedValue.ToString())
                {
                    Title = "Security Advice agaist " + ComboBoxAdvices.SelectedValue
                };
                adviceWindow.Show();
                this.Close();
            }       
        }
        #endregion Private Methods


        #region Public Methods
        #endregion Public Methods




    }
}
