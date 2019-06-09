using CounselorApp.Administrator;
using CounselorApp.Advises;
using System;
using System.Linq;

namespace UnitTests
{
    public class Sanity_Counselor
    {

        #region Control Mapping
        const string ADMIN_USERNAME = "LIRAN_NAGAR";
        #endregion Control Mapping

        #region Members
        private string _id = "1_" + DateTime.Now;
        private string _name = "advice_test_" + DateTime.Now;
        private string _body = "Body_test_" + DateTime.Now;
        private string _pathProtected = "path_protected_test_" + DateTime.Now;
        private string _bodyVulnerable = "path_vulnerable_test_" + DateTime.Now;
        private string _sourceTest = "source_test_" + DateTime.Now;

        #endregion Members

        public void Step1()
        {
            try
            {
                LoggerTest.Instance.Info("Step 1.1  Create New Advice");
                var newAdvice = new AddNewAdvice(ADMIN_USERNAME);
                newAdvice.InsertDataToDB(_id, _name, _body, _pathProtected, _bodyVulnerable, _sourceTest);
                LoggerTest.Instance.Info("Step 1.2  Check the advice exist [" + _name + "]");
                CheckAdviceExistInDataBase(_name);
            }
            catch (Exception ex)
            {
                LoggerTest.Instance.Error("Exception while during step1 ", ex);
            }
        }

        public void Step2()
        {
            try
            {
                LoggerTest.Instance.Info("Step 2  Edit advice [" + _name + "] to [new_" + _name + "]");
                var edit = new EditAdvice(_name, ADMIN_USERNAME);
                edit.UpdateAdvice("new_" + _name, "", "", "", "");
                LoggerTest.Instance.Info("Step 2.1 check advice name changed [new_" + _name + "]");
                CheckAdviceExistInDataBase("new_" + _name);
            }
            catch (Exception ex)
            {
                LoggerTest.Instance.Error("Exception while during step2 ", ex);
            }
        }


        public void Step3()
        {
            try
            {
                LoggerTest.Instance.Info("Step 3 delete advice [new_" + _name + "]");
                var menageAdvice = new MenageAdvice(ADMIN_USERNAME);
                menageAdvice.DeleteAdviceFromDB("new_" + _name);
                LoggerTest.Instance.Info("Step 3.1 Check the security advice does not exist");
                CheckAdviceDoesNotExistInDataBase("new_" + _name);
            }
            catch (Exception ex)
            {
                LoggerTest.Instance.Error("Exception while during step2 ", ex);
            }
        }

        private void CheckAdviceDoesNotExistInDataBase(string nameAdvice)
        {
            var adviceMainWin = new AdviceMainWindow();
            string name = adviceMainWin.ListOfAdvices.Select(m => m as string).Where(k => k.Equals(nameAdvice)).FirstOrDefault();
            if (!string.IsNullOrEmpty(name))
            {
                throw new Exception("The advice " + nameAdvice + "was found not as expected!");
            }
        }

        private void CheckAdviceExistInDataBase(string nameAdvice)
        {
            var adviceMainWin = new AdviceMainWindow();
            string name = adviceMainWin.ListOfAdvices.Select(m => m as string).Where(k => k.Equals(nameAdvice)).FirstOrDefault();
            if (string.IsNullOrEmpty(name))
            {
                throw new Exception("The advice not found! expected result " + nameAdvice);
            }
        }

    }
}
