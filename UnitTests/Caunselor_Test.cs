using System;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Microsoft.VisualStudio.TestTools.UITest.Input;
using Microsoft.VisualStudio.TestTools.UITest.Extension;
using Microsoft.VisualStudio.TestTools.UITesting.HtmlControls;
using Microsoft.VisualStudio.TestTools.UITesting.DirectUIControls;
using Microsoft.VisualStudio.TestTools.UITesting.WindowsRuntimeControls;
using Keyboard = Microsoft.VisualStudio.TestTools.UITesting.Keyboard;
using Logger;
using CounselorApp;


namespace UnitTests
{
    /// <summary>
    /// Summary description for CodedUITest1
    /// </summary>
    [CodedUITest]
    public class Caunselor_Test
    {

        public Caunselor_Test()
        {
            LoggerTest.Instance.Info("Test Started");
            var main = new MainWindow();        
        }



        [TestMethod]
        public void TestInitSanityCounselor()
        {
            var testSanity = new Sanity_Counselor();
            testSanity.Step1();
            testSanity.Step2();
            testSanity.Step3();
        }

        [TestMethod]
        public void TestInitServers()
        {
            var serverSanity = new Sanity_Server();
            serverSanity.Step1();
            serverSanity.Step2();
            serverSanity.Step3();
            serverSanity.Step4();
            serverSanity.Step5();
        }


    }
 
}
