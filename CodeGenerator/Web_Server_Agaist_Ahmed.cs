//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CodeGenerator {
    using System;
    using System.Diagnostics;
    using System.Net;
    using System.Net.Sockets;
    
    
    public class Web_Server_Agaist_Ahmed {
        
        private System.Diagnostics.Process p;
        
        public Web_Server_Agaist_Ahmed() {
            p = new Process();
            p.StartInfo.WorkingDirectory = "C:\\Users\\Liran\\Desktop\\CounselorApp\\CounselorApp\\bin\\Debug\\nginx";
            p.StartInfo.WindowStyle  = ProcessWindowStyle.Hidden;
            p.StartInfo.FileName = "cmd.exe";
            p.StartInfo.Arguments = "/c nginx.exe";
        }
        
        public void StartServer() {
            p.Start();
        }
        
        public void ShutDown() {
            p.Kill();
            p.Dispose();
        }
        
        public void OpenBrowser() {
            Process.Start("http://192.168.56.1:3001");
        }
    }
}
