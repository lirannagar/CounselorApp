using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CounselorApp.Administrator;
using CounselorApp.Advises;

namespace UnitTests
{
    public class Sanity_Server
    {

        #region Control Mapping
        const string ADMIN_USERNAME = "LIRAN_NAGAR";
        #endregion Control Mapping

        #region Members
        private string _advcieName = "DoS Attack";

        #endregion Members


        public void Step1()
        {
            try
            {
                LoggerTest.Instance.Info("Step 1  Open Vulnerable Server from DoS Attack advice");
                var server = new SecurityAdviceWidnow(_advcieName);
                server.Web_Server_Vulnerable();
            }
            catch (Exception ex)
            {

                LoggerTest.Instance.Error("Error while execute step1", ex);
            }           
        }

        public void Step2()
        {
            try
            {
                LoggerTest.Instance.Info("Step 2  Open Source advice from DoS Attack advice");
                var server = new SecurityAdviceWidnow(_advcieName);
                server.Web_Server_Source();
            }
            catch (Exception ex)
            {
                LoggerTest.Instance.Error("Error while execute step2", ex);
            }
        }

        public void Step3()
        {
            try
            {
                LoggerTest.Instance.Info("Step 3  Open Protected Server from DoS Attack advice");
                var server = new SecurityAdviceWidnow(_advcieName);
                server.Web_Server_Protected();
            }
            catch (Exception ex)
            {
                LoggerTest.Instance.Error("Error while execute step3", ex);
            }
        }

        public void Step4()
        {
            try
            {
                LoggerTest.Instance.Info("Step 4  ShutDown Protected Servers");
                var server = new SecurityAdviceWidnow(_advcieName);
                server.ShutDownProtected();
            }
            catch (Exception ex)
            {
                LoggerTest.Instance.Error("Error while execute step4", ex);
            }
        }

        public void Step5()
        {
            try
            {
                LoggerTest.Instance.Info("Step 5  ShutDown Vulnerable Servers");
                var server = new SecurityAdviceWidnow(_advcieName);
                server.ShutDownVulnerable();
            }
            catch (Exception ex)
            {
                LoggerTest.Instance.Error("Error while execute step5", ex);
            }
        }

    }
}
