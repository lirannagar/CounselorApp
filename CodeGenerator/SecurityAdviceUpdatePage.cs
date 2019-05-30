using Microsoft.CSharp;
using System;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;


namespace CodeGenerator
{

    public partial class SecurityAdviceUpdatePage
    {
 
        public CodeCompileUnit GenerateCSharpCode(string className, string classNameSpace, string classNameServerToUpdate)
        {

            var compileUnit = new CodeCompileUnit();

            var codedomsamplenamespace = new CodeNamespace(classNameSpace);

            #region Imports Creation
            var import1 = new CodeNamespaceImport("InitializationApp");
            var import2 = new CodeNamespaceImport("Oracle.ManagedDataAccess.Client");
            var import3 = new CodeNamespaceImport("System");
            var import4 = new CodeNamespaceImport("System.Diagnostics");
            var import5 = new CodeNamespaceImport("System.Windows");
            var import6 = new CodeNamespaceImport("System.Windows.Documents");
            var import7 = new CodeNamespaceImport("CodeGenerator");


            codedomsamplenamespace.Imports.Add(import2);
            codedomsamplenamespace.Imports.Add(import3);
            codedomsamplenamespace.Imports.Add(import4);
            codedomsamplenamespace.Imports.Add(import5);
            codedomsamplenamespace.Imports.Add(import6);
            codedomsamplenamespace.Imports.Add(import7);
            #endregion Imports Creation

            #region Class Creation
            var newType = new CodeTypeDeclaration(className)
            {
                Attributes = MemberAttributes.Public,
                IsPartial = true,
            };
            newType.BaseTypes.Add("Window");
            #endregion Class Creation

            #region Member Creation
            var field1 = new CodeMemberField("OracleCommand", "cmd");
            var field2 = new CodeMemberField("TextRange", "textRangebody");
            var filed3 = new CodeMemberField(typeof(string), "sourceWeb");
            var filed4 = new CodeMemberField(typeof(string), "advicePathWebNotProected");
            var filed5 = new CodeMemberField(typeof(string), "advicePathWebProected");
            newType.Members.Add(field1);
            newType.Members.Add(field2);
            newType.Members.Add(filed3);
            newType.Members.Add(filed4);
            newType.Members.Add(filed5);
            #endregion Member Creation

            #region Constructor Creation
            var constructor = new CodeConstructor
            { Attributes = MemberAttributes.Public };
            constructor.Parameters.Add(new CodeParameterDeclarationExpression(typeof(string), "adviceName"));
            var statementOne = new CodeAssignStatement();
            statementOne.Right = new CodeObjectCreateExpression(new CodeTypeReference("OracleCommand"));
            statementOne.Left = new CodeTypeReferenceExpression("cmd");
            var statementTwo = new CodeAssignStatement();
            statementTwo.Right = new CodeObjectCreateExpression(new CodeTypeReference("TextRange"), new CodeVariableReferenceExpression("BodyTextBox.Document.ContentStart"), new CodeVariableReferenceExpression("BodyTextBox.Document.ContentEnd"));
            statementTwo.Left = new CodeTypeReferenceExpression("textRangebody");
            var statementThree = new CodeTypeReferenceExpression("textRangebody.Text = GetAdviceBody(adviceName)");
            var statementFour = new CodeAssignStatement();
            statementFour.Left = new CodeMethodReferenceExpression(new CodeThisReferenceExpression(), "advicePathWebNotProected");
            statementFour.Right = new CodeTypeReferenceExpression("GetPathWebNotProtected(adviceName)");
            var statementFive = new CodeAssignStatement();
            statementFive.Left = new CodeMethodReferenceExpression(new CodeThisReferenceExpression(), "sourceWeb");
            statementFive.Right = new CodeTypeReferenceExpression("GetSource(adviceName)");
            var statementSix = new CodeAssignStatement();
            statementSix.Left = new CodeMethodReferenceExpression(new CodeThisReferenceExpression(), "advicePathWebProected");
            statementSix.Right = new CodeTypeReferenceExpression("GetPathWebProtected(adviceName)");
            var init = new CodeTypeReferenceExpression("InitializeComponent()");
            var tryConstructor = new CodeTryCatchFinallyStatement();
            tryConstructor.TryStatements.Add(init);
            tryConstructor.TryStatements.Add(statementOne);
            tryConstructor.TryStatements.Add(statementTwo);
            tryConstructor.TryStatements.Add(statementThree);
            tryConstructor.TryStatements.Add(statementFour);
            tryConstructor.TryStatements.Add(statementSix);
            tryConstructor.TryStatements.Add(statementFive);
            var catchConstructor = new CodeCatchClause("ex", new CodeTypeReference("Exception"));
            var logErrorConstructor = new CodeMethodInvokeExpression(new CodeTypeReferenceExpression("Logger"), "Instance.Error", new CodePrimitiveExpression("Error while trying to open  Security Advice Widnow "), new CodeTypeReferenceExpression("ex"));
            catchConstructor.Statements.Add(logErrorConstructor);
            tryConstructor.CatchClauses.Add(catchConstructor);
            #endregion Constructor Creation

            #region Methods Creation
            ///private void ClickOnOpenSource(object sender, RoutedEventArgs e)
            var ClickOnOpenSource = new CodeMemberMethod();
            ClickOnOpenSource.Name = "ClickOnOpenSource";
            ClickOnOpenSource.ReturnType = new CodeTypeReference("System.Void");
            ClickOnOpenSource.Attributes = MemberAttributes.Private;
            ClickOnOpenSource.Parameters.Add(new CodeParameterDeclarationExpression("System.Object", "sender"));
            ClickOnOpenSource.Parameters.Add(new CodeParameterDeclarationExpression("RoutedEventArgs", "e"));
            var tryClickOnOpenSource = new CodeTryCatchFinallyStatement();
            var processStartState = new CodeMethodInvokeExpression(new CodeTypeReferenceExpression("Process"), "Start", new CodeVariableReferenceExpression("this.sourceWeb"));
            var logInfoClickOnOpenSource = new CodeMethodInvokeExpression(new CodeTypeReferenceExpression("Logger"), "Instance.Info", new CodeArgumentReferenceExpression("\"ClickOnOpenSource(\" + this.sourceWeb + \")\""));
            tryClickOnOpenSource.TryStatements.Add(processStartState);
            tryClickOnOpenSource.TryStatements.Add(logInfoClickOnOpenSource);
            var catchClickOnOpenSource = new CodeCatchClause("ex", new CodeTypeReference("Exception"));
            var logErrorClickOnOpenSource = new CodeMethodInvokeExpression(new CodeTypeReferenceExpression("Logger"), "Instance.Error", new CodePrimitiveExpression("Error while trying to open source advice "), new CodeTypeReferenceExpression("ex"));
            catchClickOnOpenSource.Statements.Add(logErrorClickOnOpenSource);
            tryClickOnOpenSource.CatchClauses.Add(catchClickOnOpenSource);
            ClickOnOpenSource.Statements.Add(tryClickOnOpenSource);

            ///private void ClickOnBackButton(object sender, RoutedEventArgs e)
            var ClickOnBackButton = new CodeMemberMethod();
            ClickOnBackButton.Name = "ClickOnBackButton";
            ClickOnBackButton.ReturnType = new CodeTypeReference("System.Void");
            ClickOnBackButton.Attributes = MemberAttributes.Private;
            ClickOnBackButton.Parameters.Add(new CodeParameterDeclarationExpression("System.Object", "sender"));
            ClickOnBackButton.Parameters.Add(new CodeParameterDeclarationExpression("RoutedEventArgs", "e"));
            var tryClickOnBackButton = new CodeTryCatchFinallyStatement();
            var adviceMain = new CodeVariableReferenceExpression("var adviceMain = new AdviceMainWindow()");
            var adviceMainOpen = new CodeVariableReferenceExpression("adviceMain.Show()");
            var closeCurrentWindow = new CodeVariableReferenceExpression("this.Close()");
            var logInfoClickOnBackButton = new CodeMethodInvokeExpression(new CodeTypeReferenceExpression("Logger"), "Instance.Info", new CodePrimitiveExpression("ClickOnBackButton()"));
            tryClickOnBackButton.TryStatements.Add(adviceMain);
            tryClickOnBackButton.TryStatements.Add(adviceMainOpen);
            tryClickOnBackButton.TryStatements.Add(closeCurrentWindow);
            tryClickOnBackButton.TryStatements.Add(logInfoClickOnBackButton);
            var catchClickOnBackButton = new CodeCatchClause("ex", new CodeTypeReference("Exception"));
            var logErrorClickOnBackButton = new CodeMethodInvokeExpression(new CodeTypeReferenceExpression("Logger"), "Instance.Error", new CodePrimitiveExpression("Error while trying to click back button"), new CodeTypeReferenceExpression("ex"));
            catchClickOnBackButton.Statements.Add(logErrorClickOnBackButton);
            tryClickOnBackButton.CatchClauses.Add(catchClickOnBackButton);
            ClickOnBackButton.Statements.Add(tryClickOnBackButton);




            ///private void ClickProtectedWeb(object sender, RoutedEventArgs e)
            var ClickProtectedWebMethod = new CodeMemberMethod();
            ClickProtectedWebMethod.Name = "ClickProtectedWeb";
            ClickProtectedWebMethod.ReturnType = new CodeTypeReference("System.Void");
            ClickProtectedWebMethod.Attributes = MemberAttributes.Private;
            ClickProtectedWebMethod.Parameters.Add(new CodeParameterDeclarationExpression("System.Object", "sender"));
            ClickProtectedWebMethod.Parameters.Add(new CodeParameterDeclarationExpression("RoutedEventArgs", "e"));
            var tryClickProtectedWeb = new CodeTryCatchFinallyStatement();
            var logInfoClickProtectedWebMethod = new CodeMethodInvokeExpression(new CodeTypeReferenceExpression("Logger"), "Instance.Info", new CodePrimitiveExpression("ClickProtectedWeb()"));
            tryClickProtectedWeb.TryStatements.Add(logInfoClickProtectedWebMethod);
            var catchClickProtectedWeb = new CodeCatchClause("ex", new CodeTypeReference("Exception"));
            var logErrorClickProtectedWeb = new CodeMethodInvokeExpression(new CodeTypeReferenceExpression("Logger"), "Instance.Error", new CodePrimitiveExpression("Error while trying to open Protected  Web "), new CodeTypeReferenceExpression("ex"));
            catchClickProtectedWeb.Statements.Add(logErrorClickProtectedWeb);
            tryClickProtectedWeb.CatchClauses.Add(catchClickProtectedWeb);
            ClickProtectedWebMethod.Statements.Add(tryClickProtectedWeb);



            ///private void ClickVulnerableWeb(object sender, RoutedEventArgs e)
            var ClickVulnerableWeb = new CodeMemberMethod();
            ClickVulnerableWeb.Name = "ClickVulnerableWeb";
            ClickVulnerableWeb.ReturnType = new CodeTypeReference("System.Void");
            ClickVulnerableWeb.Attributes = MemberAttributes.Private;
            ClickVulnerableWeb.Parameters.Add(new CodeParameterDeclarationExpression("System.Object", "sender"));
            ClickVulnerableWeb.Parameters.Add(new CodeParameterDeclarationExpression("RoutedEventArgs", "e"));
            var tryClickVulnerableWeb = new CodeTryCatchFinallyStatement();
            var statementServerStartOne = new CodeAssignStatement();
            statementServerStartOne.Right = new CodeObjectCreateExpression(new CodeTypeReference(classNameServerToUpdate));
            statementServerStartOne.Left = new CodeTypeReferenceExpression("var serv");
            var statementServerStartTwo = new CodeMethodInvokeExpression(new CodeTypeReferenceExpression("serv"), "StartServer");
            var statementServerStartThree = new CodeMethodInvokeExpression(new CodeTypeReferenceExpression("serv"), "OpenBrowser");
            var logInfoClickVulnerableWeb = new CodeMethodInvokeExpression(new CodeTypeReferenceExpression("Logger"), "Instance.Info", new CodePrimitiveExpression("ClickVulnerableWeb()"));
            tryClickVulnerableWeb.TryStatements.Add(statementServerStartOne);
            tryClickVulnerableWeb.TryStatements.Add(statementServerStartTwo);
            tryClickVulnerableWeb.TryStatements.Add(statementServerStartThree);
            tryClickVulnerableWeb.TryStatements.Add(logInfoClickVulnerableWeb);
            var catchClickVulnerableWeb = new CodeCatchClause("ex", new CodeTypeReference("Exception"));
            var logErrorClickVulnerableWeb = new CodeMethodInvokeExpression(new CodeTypeReferenceExpression("Logger"), "Instance.Error", new CodePrimitiveExpression("Error while trying to open Vulnerable Web "), new CodeTypeReferenceExpression("ex"));
            catchClickVulnerableWeb.Statements.Add(logErrorClickVulnerableWeb);
            tryClickVulnerableWeb.CatchClauses.Add(catchClickVulnerableWeb);
            ClickVulnerableWeb.Statements.Add(tryClickVulnerableWeb);


            //private string GetSource(string nameAdvice)
            var ClickGetSource = new CodeMemberMethod();
            ClickGetSource.Name = "GetSource";
            ClickGetSource.ReturnType = new CodeTypeReference("System.string");
            ClickGetSource.Attributes = MemberAttributes.Private;
            ClickGetSource.Parameters.Add(new CodeParameterDeclarationExpression(typeof(string), "nameAdvice"));
            var connectionStatement = new CodeArgumentReferenceExpression("cmd.Connection = OracleSingletonConnection.Instance");
            var stringQuery = new CodeVariableDeclarationStatement(typeof(string), "advice", new CodeArgumentReferenceExpression("\"select advises.SOURCE_ADVICE" + " from advises" + " where advises.advice_name = '\" + nameAdvice + \"'\""));
            var sendCommentGetSource = new CodeArgumentReferenceExpression("cmd.CommandText = advice");
            var tryGetSource = new CodeTryCatchFinallyStatement();
            tryGetSource.TryStatements.Add(connectionStatement);
            tryGetSource.TryStatements.Add(stringQuery);
            tryGetSource.TryStatements.Add(sendCommentGetSource);
            tryGetSource.TryStatements.Add(new CodeMethodReturnStatement(new CodeArgumentReferenceExpression("Convert.ToString(cmd.ExecuteScalar())")));
            var catchGetSource = new CodeCatchClause("ex", new CodeTypeReference("Exception"));
            var logErrorGetSource = new CodeThrowExceptionStatement(new CodeObjectCreateExpression(new CodeTypeReference(typeof(Exception)), new CodePrimitiveExpression("Exception while trying to get source  "), new CodeTypeReferenceExpression("ex")));
            catchGetSource.Statements.Add(logErrorGetSource);
            tryGetSource.CatchClauses.Add(catchGetSource);
            ClickGetSource.Statements.Add(tryGetSource);


            //private void GetAdviceBody(string nameAdvice)
            var GetAdviceBody = new CodeMemberMethod();
            GetAdviceBody.Name = "GetAdviceBody";
            GetAdviceBody.ReturnType = new CodeTypeReference("System.string");
            GetAdviceBody.Attributes = MemberAttributes.Private;
            GetAdviceBody.Parameters.Add(new CodeParameterDeclarationExpression(typeof(string), "nameAdvice"));
            connectionStatement = new CodeArgumentReferenceExpression("cmd.Connection = OracleSingletonConnection.Instance");
            stringQuery = new CodeVariableDeclarationStatement(typeof(string), "advice", new CodeArgumentReferenceExpression("\"select advises.advice_text" + " from advises" + " where advises.advice_name = '\" + nameAdvice + \"'\""));
            sendCommentGetSource = new CodeArgumentReferenceExpression("cmd.CommandText = advice");
            var tryGetAdviceBody = new CodeTryCatchFinallyStatement();
            tryGetAdviceBody.TryStatements.Add(connectionStatement);
            tryGetAdviceBody.TryStatements.Add(stringQuery);
            tryGetAdviceBody.TryStatements.Add(sendCommentGetSource);
            tryGetAdviceBody.TryStatements.Add(new CodeMethodReturnStatement(new CodeArgumentReferenceExpression("Convert.ToString(cmd.ExecuteScalar())")));
            var catchGetAdviceBody = new CodeCatchClause("ex", new CodeTypeReference("Exception"));
            var logErrorGetAdviceBody = new CodeThrowExceptionStatement(new CodeObjectCreateExpression(new CodeTypeReference(typeof(Exception)), new CodePrimitiveExpression("Error while trying to get advice body "), new CodeTypeReferenceExpression("ex")));
            catchGetAdviceBody.Statements.Add(logErrorGetAdviceBody);
            tryGetAdviceBody.CatchClauses.Add(catchGetAdviceBody);
            GetAdviceBody.Statements.Add(tryGetAdviceBody);


            //private void GetPathWebNotProtected(string nameAdvice)
            var GetPathWebNotProtected = new CodeMemberMethod();
            GetPathWebNotProtected.Name = "GetPathWebNotProtected";
            GetPathWebNotProtected.ReturnType = new CodeTypeReference("System.string");
            GetPathWebNotProtected.Attributes = MemberAttributes.Private;
            GetPathWebNotProtected.Parameters.Add(new CodeParameterDeclarationExpression(typeof(string), "nameAdvice"));
            connectionStatement = new CodeArgumentReferenceExpression("cmd.Connection = OracleSingletonConnection.Instance");
            stringQuery = new CodeVariableDeclarationStatement(typeof(string), "advice", new CodeArgumentReferenceExpression("\"select advises.PATH_NOT_PROTECTED_WEB" + " from advises" + " where advises.advice_name = '\" + nameAdvice + \"'\""));
            sendCommentGetSource = new CodeArgumentReferenceExpression("cmd.CommandText = advice");
            var tryGetPathWebNotProtected = new CodeTryCatchFinallyStatement();
            tryGetPathWebNotProtected.TryStatements.Add(connectionStatement);
            tryGetPathWebNotProtected.TryStatements.Add(stringQuery);
            tryGetPathWebNotProtected.TryStatements.Add(sendCommentGetSource);
            tryGetPathWebNotProtected.TryStatements.Add(new CodeMethodReturnStatement(new CodeArgumentReferenceExpression("Convert.ToString(cmd.ExecuteScalar())")));
            var catchGetPathWebNotProtected = new CodeCatchClause("ex", new CodeTypeReference("Exception"));
            var logErrorGetPathWebNotProtected = new CodeThrowExceptionStatement(new CodeObjectCreateExpression(new CodeTypeReference(typeof(Exception)), new CodePrimitiveExpression("Exception while trying to Get Path Web Not Protected "), new CodeTypeReferenceExpression("ex")));
            catchGetPathWebNotProtected.Statements.Add(logErrorGetPathWebNotProtected);
            tryGetPathWebNotProtected.CatchClauses.Add(catchGetPathWebNotProtected);
            GetPathWebNotProtected.Statements.Add(tryGetPathWebNotProtected);

            //private void GetPathWebProtected(string nameAdvice)
            var GetPathWebProtected = new CodeMemberMethod();
            GetPathWebProtected.Name = "GetPathWebProtected";
            GetPathWebProtected.ReturnType = new CodeTypeReference("System.string");
            GetPathWebProtected.Attributes = MemberAttributes.Private;
            GetPathWebProtected.Parameters.Add(new CodeParameterDeclarationExpression(typeof(string), "nameAdvice"));
            connectionStatement = new CodeArgumentReferenceExpression("cmd.Connection = OracleSingletonConnection.Instance");
            stringQuery = new CodeVariableDeclarationStatement(typeof(string), "advice", new CodeArgumentReferenceExpression("\"select advises.PATH_PROTECTED_WEB" + " from advises" + " where advises.advice_name = '\" + nameAdvice + \"'\""));
            sendCommentGetSource = new CodeArgumentReferenceExpression("cmd.CommandText = advice");
            var tryGetPathWebProtected = new CodeTryCatchFinallyStatement();
            tryGetPathWebProtected.TryStatements.Add(connectionStatement);
            tryGetPathWebProtected.TryStatements.Add(stringQuery);
            tryGetPathWebProtected.TryStatements.Add(sendCommentGetSource);
            tryGetPathWebProtected.TryStatements.Add(new CodeMethodReturnStatement(new CodeArgumentReferenceExpression("Convert.ToString(cmd.ExecuteScalar())")));
            var catchGetPathWebProtected = new CodeCatchClause("ex", new CodeTypeReference("Exception"));
            var logErrortryGetPathWebProtected = new CodeThrowExceptionStatement(new CodeObjectCreateExpression(new CodeTypeReference(typeof(Exception)), new CodePrimitiveExpression("Exception while trying to Get Path Web Protected "), new CodeTypeReferenceExpression("ex")));
            catchGetPathWebProtected.Statements.Add(logErrortryGetPathWebProtected);
            tryGetPathWebProtected.CatchClauses.Add(catchGetPathWebProtected);
            GetPathWebProtected.Statements.Add(tryGetPathWebProtected);


            


            #endregion Methods Creation


            constructor.Statements.Add(tryConstructor);

            newType.Members.Add(constructor);
            newType.Members.Add(ClickOnOpenSource);
            newType.Members.Add(ClickVulnerableWeb);
            newType.Members.Add(ClickProtectedWebMethod);
            newType.Members.Add(ClickGetSource);
            newType.Members.Add(GetAdviceBody);
            newType.Members.Add(GetPathWebNotProtected);
            newType.Members.Add(GetPathWebProtected);
            newType.Members.Add(ClickOnBackButton);
            codedomsamplenamespace.Types.Add(newType);
            compileUnit.Namespaces.Add(codedomsamplenamespace);
            // Return the CompileUnit
            //
            return compileUnit;
        }

        // Generate code for a particular provider and compile it
        //
        public void GenerateCode(CodeCompileUnit ccu, String className)
        {
            className = className + ".xaml";
            var cp = new CompilerParameters();
            String sourceFile;


            // Generate Code from Compile Unit using CSharp code provider
            //
            var csharpcodeprovider = new CSharpCodeProvider();

            if (csharpcodeprovider.FileExtension[0] == '.')
            {
                sourceFile = className + csharpcodeprovider.FileExtension;
            }
            else
            {
                sourceFile = className + "." + csharpcodeprovider.FileExtension;
            }
            var tw1 = new IndentedTextWriter(new StreamWriter(sourceFile, false), "    ");
            csharpcodeprovider.GenerateCodeFromCompileUnit(ccu, tw1, new CodeGeneratorOptions());

            tw1.Close();
            cp.GenerateExecutable = true;
            cp.OutputAssembly = className + ".exe";
            cp.GenerateInMemory = false;
            csharpcodeprovider.CompileAssemblyFromDom(cp, ccu);
        }

        private CompilerResults CompileCsharpSource(string[] sources, string output, params string[] references)
        {
            var parameters = new CompilerParameters(references, output);
            parameters.GenerateExecutable = true;
            using (var provider = new CSharpCodeProvider())
                return provider.CompileAssemblyFromSource(parameters, sources);
        }

        public void AddClassToSolution(string className, string mainPath, string nameDirectory = null)
        {
            List<string> listPath = mainPath.Split('\\').ToList();

            string newString = mainPath;
            string newPath = newString.Remove(newString.Length - 9, 9);
            string csprojObjectPath = newPath;
            if (!string.IsNullOrEmpty(nameDirectory))
            {
                newPath += (nameDirectory + "\\");
            }
            List<string> ListNameOfProject = mainPath.Split('\\').ToList();

            string nameProject = ListNameOfProject[ListNameOfProject.Count - 4];
            File.Move(mainPath + "\\" + className + ".xaml.cs", newPath + "\\" + className + ".xaml.cs");
            var p = new Microsoft.Build.Evaluation.Project(newPath + "\\" + nameProject + ".csproj");
            p.AddItem("Compile", newPath + "\\" + className + ".xaml.cs");
            p.Save();

        }

        public void SwitchClass(string className, string mainPath, string projectName = null, string nameDirectory = null)
        {
            List<string> listPath = mainPath.Split('\\').ToList();

            string newString = mainPath;
            string newPath = newString.Remove(newString.Length - 9, 9);

            List<string> ListNameOfProject = mainPath.Split('\\').ToList();

            string nameProject = ListNameOfProject[ListNameOfProject.Count - 4];
            if (!string.IsNullOrEmpty(projectName))
            {
                newPath = newString.Remove(newString.Length - (10 + nameProject.Length), (10 + nameProject.Length));
                newPath += (projectName + "\\");
            }
            else
                newPath = newString.Remove(newString.Length - 9, 9);
            string finalPath = newPath;
            if (!string.IsNullOrEmpty(nameDirectory))
            {

                newPath += (nameDirectory + "\\");
            }

            if (File.Exists(newPath + "\\" + className + ".xaml.cs"))
            {
                File.Delete(newPath + "\\" + className + ".xaml.cs");
            }

            File.Move(mainPath + "\\" + className + ".xaml.cs", newPath + "\\" + className + ".xaml.cs");
            if (!string.IsNullOrEmpty(projectName)) { nameProject = projectName; }
            var p = new Microsoft.Build.Evaluation.Project(finalPath + "\\" + nameProject + ".csproj");
            p.AddItem("Compile", newPath + "\\" + className + ".xaml.cs");
            var x = p.GetItems("Compile").Where(a => a.UnevaluatedInclude == newPath + "\\" + className + ".xaml.cs").FirstOrDefault();
            p.RemoveItem(x);
            p.Save();
        }
    }


}
