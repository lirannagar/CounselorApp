using Oracle.ManagedDataAccess.Client;

namespace ConnectionOracle
{
    public class OracleSingletonConnection
    {
        #region Control Mapping
        const string CONNECTION_STRING = "DATA SOURCE = localhost:1521/xe;USER ID = SYSTEM; PASSWORD=123123";
        #endregion Control Mapping

        #region Members
        private static OracleConnection instance;
        #endregion Members

        #region Public Methods
        public static OracleConnection Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new OracleConnection(CONNECTION_STRING);
                }
                return instance;
            }
        }
        #endregion Public Methods
    }
}
