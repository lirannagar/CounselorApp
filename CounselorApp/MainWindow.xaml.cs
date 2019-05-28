using CounselorApp.Administrator;
using CounselorApp.Advises;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Windows;
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
        const string REGULAR_USER_STRING = "Regular user";
        #endregion Control Mapping

        #region Members
        private OracleCommand cmd;
        #endregion Members

        static bool firstTimeEnter = true;

        #region Constructor
        public MainWindow()
        {
            InitializeComponent();
            if (firstTimeEnter)
            {
                Logger.Instance.Info("--------------------------------------------PROGRAM STARTED--------------------------------------------");
                OpenConnection();
                SwitchAdminUser();
                firstTimeEnter = false;
            }
                       

            var admin = new MenageAdvice();
            admin.Show();
            this.Close();
        }
        #endregion Constructor

        #region Private Methods
        /// <summary>
        /// Open Connection with the oracle database
        /// </summary>
        private void OpenConnection()
        {
            try
            {
                cmd = new OracleCommand();
                OracleSingletonConnection.Instance.Open();
                Logger.Instance.Info("OpenConnection()");
            }
            catch (OracleException ex)
            {
                Logger.Instance.Error("Exeption while trying to open DB\n Details:\n", ex);
            }
        }
        /// <summary>
        /// LogIn Button to the Caunselor System
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClickLogInButton(object sender, RoutedEventArgs e)
        {
            try
            {
                string inputUserName = UserNameText.Text;
                string inputPassword = PasswordText.Password.ToString();
                string inputRole = RoleComboBox.Text;
                if (inputRole.Equals(REGULAR_USER_STRING))
                {
                    var adviceWindow = new AdviceMainWindow();
                    adviceWindow.Show();
                    this.Close();
                }
                CheckInputLogInWindow(inputUserName, inputPassword, inputRole);
                string userFromDB = GetUserNameFromDB(inputUserName);
                string passwordFromDB = GetUserPasswordDB(inputUserName);
                string roleFromDB = GetRoleFromDB(inputUserName);

                if (inputUserName.Equals(userFromDB) && inputPassword.Equals(passwordFromDB) && inputRole.Equals(roleFromDB))
                {



                }
                else
                {
                    throw new Exception("One of the values is incorrect");
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
                MessageBox.Show("Please choose User Name!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                throw new Exception("user name not choosed");
            }
            if (string.IsNullOrEmpty(_inputPassword))
            {
                MessageBox.Show("Please choosep Password!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                throw new Exception("user name not choosed");
            }

            if (_role.Equals(CHOOSE_OPETION_STRING))
            {
                MessageBox.Show("Please choose role opetion!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                throw new Exception("role not choosed");
            }
        }

        /// <summary>
        /// Switch between Users 
        /// </summary>
        private void SwitchAdminUser()
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
            namePasswod = Convert.ToString(cmd.ExecuteScalar());
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
                          + " WHERE USERS.USER_NAME like '" + userName.ToUpper() + "'";
            cmd.CommandText = user;
            nameID = Convert.ToString(cmd.ExecuteScalar());
            if (string.IsNullOrEmpty(nameID))
            {
                throw new Exception("User name not exist or whrong");
                MessageBox.Show("User name not exist or whrong", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            return nameID;
        }
        #endregion Private Methods

        #region Public Methods
        #endregion Public Methods        
    }
}
