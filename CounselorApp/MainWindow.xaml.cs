using CounselorApp.Administrator;
using CounselorApp.Advises;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Windows;
using System.Windows.Media;
#pragma warning disable CS0162


namespace CounselorApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        #region Control Mapping
        const string CHOOSE_OPETION_STRING = "Choose role";
        const string REGULAR_USER_STRING = "Regular User";
        const string MASTER_STRING = "Master";
        const string MASTER_CODE = "A100";


        #endregion Control Mapping

        #region Members
        private OracleCommand cmd;
        #endregion Members


        static bool firstTimeEnter = true;

        #region Constructor
        public MainWindow()
        {
            InitializeComponent();
            cmd = new OracleCommand();
            if (firstTimeEnter)
            {
                Logger.Instance.Info("--------------------------------------------PROGRAM STARTED--------------------------------------------");
                OpenConnection();
                SwitchAdminUser();
                firstTimeEnter = false;
            }
        }
        #endregion Constructor

        #region Private Methods
        /// <summary>
        /// LogIn Button to the Caunselor System
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClickLogInButton(object sender, RoutedEventArgs e)
        {
            try
            {
                string inputUserName = UserNameText.Text.ToUpper();
                string inputPassword = PasswordText.Password.ToString();
                string inputRole = RoleComboBox.Text;
                if (inputRole.Equals(REGULAR_USER_STRING))
                {
                    var adviceWindow = new AdviceMainWindow();
                    adviceWindow.Show();
                    this.Close();                                       
                }
                else
                {
                    CheckInputLogInWindow(inputUserName, inputPassword, inputRole);
                    string userFromDB = GetUserNameFromDB(inputUserName);
                    string passwordFromDB = GetUserPasswordDB(inputUserName);
                    string roleFromDB = GetRoleFromDB(inputUserName);
                    if (inputRole.Equals(MASTER_STRING)) { inputRole = MASTER_CODE; }
                    if (inputUserName.Equals(userFromDB) && inputPassword.Equals(passwordFromDB) && inputRole.Equals(roleFromDB))
                    {
                        var admin = new AdminMainWindow(userFromDB);
                        admin.Show();
                        this.Close();
                    }
                    else
                    {
                        ErrorLebal.Content = "One of the values is incorrect!";
                        ErrorLebal.Visibility = Visibility.Visible;
                        throw new Exception("One of the values is incorrect");
                    }
                }
                Logger.Instance.Info("ClickLogInButton()");
            }
            catch (Exception ex)
            {
                Logger.Instance.Error("Error while tyring to click log in ", ex);
            }
        }

        /// <summary>
        /// Check if one of the inputs are empty
        /// </summary>
        /// <param name="inputUserName">User name input</param>
        /// <param name="inputPassword">Password user input</param>
        /// <param name="_role">Role user input</param>
        private void CheckInputLogInWindow(string _inputUserName, string _inputPassword, string _role)
        {
            if (string.IsNullOrEmpty(_inputUserName))
            {
                ErrorLebal.Content = "Please choose User Name!";
                ErrorLebal.Visibility = Visibility.Visible;
                throw new Exception("user name not choosed");
            }
            if (string.IsNullOrEmpty(_inputPassword))
            {
                ErrorLebal.Content = "Please choosep Password!";
                ErrorLebal.Visibility = Visibility.Visible;
                throw new Exception("user name not choosed");
            }

            if (_role.Equals(CHOOSE_OPETION_STRING))
            {
                ErrorLebal.Content = "Please choose role opetion!";
                ErrorLebal.Visibility = Visibility.Visible;
                throw new Exception("role not choosed");
            }
        }


        /// <summary>
        /// Get role value from user
        /// </summary>
        /// <param name="userName">User name to his role value</param>
        /// <returns></returns>
        private string GetRoleFromDB(string userName)
        {
            string nameRole = "";
            cmd.Connection = OracleSingletonConnection.Instance;
            string role = "select USERS.ROLE_ID "
                 + " FROM USERS "
                 + " WHERE USERS.USER_NAME like '" + userName + "'";
            cmd.CommandText = role;
            nameRole = Convert.ToString(cmd.ExecuteScalar());
            Logger.Instance.Info("GetRoleFromDB( " + userName + " )");
            return nameRole;
        }
        /// <summary>
        ///  Get user password value from user
        /// </summary>
        /// <param name="userName">User name to his password value</param>
        /// <returns></returns>
        private string GetUserPasswordDB(string userName)
        {

            string namePasswod = "";
            cmd.Connection = OracleSingletonConnection.Instance;
            string password = "select USERS.Password_ENCRYPTED "
              + " FROM USERS "
              + " WHERE USERS.USER_NAME like '" + userName + "'";
            cmd.CommandText = password;
            try
            {
                namePasswod = Convert.ToString(cmd.ExecuteScalar());
            }
            catch { }

            Logger.Instance.Info("GetUserPassword( " + userName + " )");
            return namePasswod;
        }
        /// <summary>
        /// Get user name value from user
        /// </summary>
        /// <param name="userName">User name to his username value</param>
        /// <returns></returns>
        private string GetUserNameFromDB(string userName)
        {

            string nameID = "";
            cmd.Connection = OracleSingletonConnection.Instance;
            string user = "select USERS.USER_NAME "
                          + " FROM USERS "
                          + " WHERE USERS.USER_NAME like '" + userName + "'";
            cmd.CommandText = user;
            try
            {
                nameID = Convert.ToString(cmd.ExecuteScalar());
            }
            catch { }
            if (string.IsNullOrEmpty(nameID))
            {
                ErrorLebal.Content = "One of the fields is incorrect!";
                ErrorLebal.Visibility = Visibility.Visible;
                throw new Exception("User name not exist or whrong");
            }
            return nameID;
        }
        #endregion Private Methods

        #region Public Methods
        /// <summary>
        /// Open Connection with the oracle database
        /// </summary>
        public void OpenConnection()
        {
            try
            {
                OracleSingletonConnection.Instance.Open();
                Logger.Instance.Info("OpenConnection()");
            }
            catch (Exception ex)
            {
                Logger.Instance.Error("Exeption while trying to open DB\n Details:\n", ex);
            }
        }
        /// <summary>
        /// Switch between Users 
        /// </summary>
        public void SwitchAdminUser()
        {
            try
            {
                OracleSingletonConnection.Instance.Close();
                OracleSingletonConnection.Instance.ConnectionString = "DATA SOURCE = localhost:1521/xe;USER ID = LIRAN_NAGAR; PASSWORD=123123";
                OracleSingletonConnection.Instance.Open();
                Logger.Instance.Info("SwitchAdminUser()");
            }
            catch (OracleException ex)
            {
                Logger.Instance.Error("Exption while trying to chenge admin user\n Details:\n", ex);
            }
        }
        #endregion Public Methods        
    }
}
