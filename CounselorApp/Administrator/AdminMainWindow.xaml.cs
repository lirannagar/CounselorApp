using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CounselorApp.Administrator
{
    /// <summary>
    /// Interaction logic for AdminMainWindow.xaml
    /// </summary>
    public partial class AdminMainWindow : Window
    {



        #region Control Mapping
        #endregion Control Mapping


        #region Members        
        #endregion Members


        #region Constructor
        public AdminMainWindow()
        {
            try
            {
                InitializeComponent();
                Logger.Instance.Info("AdminMainWindow()");
            }catch(Exception ex)
            {
                Logger.Instance.Error("Error while trying to open Admin Main Window "  , ex);
            }           
        }
        #endregion Constructor


        #region Private Methods
        private void ClickSecurityAdviser(object sender, RoutedEventArgs e)
        {

        }
        private void ClickAdvisesButton(object sender, RoutedEventArgs e)
        {
            try
            {
                var advice = new MenageAdvice();
                advice.Show();
                this.Close();
                Logger.Instance.Info("ClickAdvisesButton()");
            }
            catch (Exception ex)
            {
                Logger.Instance.Error("Error while trying to open MenageAdvice window", ex);
            }
        }
        #endregion Private Methods


        #region Public Methods
        #endregion Public Methods



    }
}
