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
    public partial class WPFAddNewAdviceGeneratorCode
    {

        public CodeCompileUnit GenerateCSharpCode(string className, string classNameSpace)
        {

            var compileUnit = new CodeCompileUnit();

            var codedomsamplenamespace = new CodeNamespace(classNameSpace);

            #region Imports Creation

            var import1 = new CodeNamespaceImport("System");
            var import2 = new CodeNamespaceImport("CodeGenerator");
            var import3 = new CodeNamespaceImport("System.Collections.Generic");
            var import4 = new CodeNamespaceImport("System.Windows.Forms");
            var import5 = new CodeNamespaceImport("System.IO");
            var import6 = new CodeNamespaceImport("System.Linq");
            var import7 = new CodeNamespaceImport("System.Windows");
            var import8 = new CodeNamespaceImport("System.CodeDom");

            codedomsamplenamespace.Imports.Add(import1);
            codedomsamplenamespace.Imports.Add(import2);
            codedomsamplenamespace.Imports.Add(import3);
            codedomsamplenamespace.Imports.Add(import4);
            codedomsamplenamespace.Imports.Add(import5);
            codedomsamplenamespace.Imports.Add(import6);
            codedomsamplenamespace.Imports.Add(import7);
            codedomsamplenamespace.Imports.Add(import8);
            #endregion Imports Creation

            //Class Creation
            #region Class Creation
            var newType = new CodeTypeDeclaration(className)
            {
                Attributes = MemberAttributes.Public,
                IsPartial = true,
            };
            newType.BaseTypes.Add("Window");
            #endregion Class Creation

            #region Constructor Creation
            var constructor = new CodeConstructor { Attributes = MemberAttributes.Public };
            var init = new CodeTypeReferenceExpression("InitializeComponent()");
            #endregion Constructor Creation

            #region Methods Creation
            ///private void ClickUploadVulnerableWebButton(object sender, RoutedEventArgs e)
            CodeMemberMethod clickUploadVulnerableWeb = new CodeMemberMethod();
            clickUploadVulnerableWeb.Name = "ClickUploadVulnerableWebButton";
            clickUploadVulnerableWeb.ReturnType = new CodeTypeReference("System.Void");
            clickUploadVulnerableWeb.Attributes = MemberAttributes.Private;
            clickUploadVulnerableWeb.Parameters.Add(new CodeParameterDeclarationExpression("System.Object", "sender"));
            clickUploadVulnerableWeb.Parameters.Add(new CodeParameterDeclarationExpression("RoutedEventArgs", "e"));
            CodeTryCatchFinallyStatement try1 = new CodeTryCatchFinallyStatement();
            CodeObjectCreateExpression objectFolderBrowserDialog = new CodeObjectCreateExpression(new CodeTypeReference("FolderBrowserDialog"));

            CodeVariableDeclarationStatement classDeclaration1 = new CodeVariableDeclarationStatement(typeof(string),
             "className", new CodePrimitiveExpression(className));
            CodeVariableDeclarationStatement classDeclaration2 = new CodeVariableDeclarationStatement(typeof(string),
             "nameSpace", new CodePrimitiveExpression(classNameSpace));

            CodeObjectCreateExpression objectCreate = new CodeObjectCreateExpression(new CodeTypeReference("WPFAddNewAdviceGeneratorCode"));

            CodeMethodInvokeExpression generateCodeStart =
                            new CodeMethodInvokeExpression(
                            new CodeVariableReferenceExpression("cds"), "GenerateCode", new CodeVariableReferenceExpression("newClassCode"), new CodeVariableReferenceExpression("className"));

            CodeMethodInvokeExpression generateCodeSecond =
                            new CodeMethodInvokeExpression(
                            new CodeVariableReferenceExpression("cds"), "SwitchClass", new CodeVariableReferenceExpression("className"), new CodeVariableReferenceExpression("Directory.GetCurrentDirectory()"));

            CodeMethodInvokeExpression generateCodeThird =
                            new CodeMethodInvokeExpression(
                            new CodeVariableReferenceExpression("cds"), "GenerateCSharpCode", new CodeVariableReferenceExpression("className"), new CodeVariableReferenceExpression("nameSpace"));
            CodeMethodInvokeExpression showDialogStatement =
                            new CodeMethodInvokeExpression(
                            new CodeVariableReferenceExpression("dialog"), "ShowDialog");
            try1.TryStatements.Add(new CodeVariableDeclarationStatement(new CodeTypeReference("var"), "dialog", objectFolderBrowserDialog));
            try1.TryStatements.Add(showDialogStatement);
            var contectBetweenText = new CodeTypeReferenceExpression("VulnerableWebTextBox.Text = dialog.SelectedPath");
            try1.TryStatements.Add(contectBetweenText);
            try1.TryStatements.Add(classDeclaration1);
            try1.TryStatements.Add(classDeclaration2);
            try1.TryStatements.Add(new CodeVariableDeclarationStatement(new CodeTypeReference("var"), "cds", objectCreate));
            try1.TryStatements.Add(new CodeVariableDeclarationStatement(new CodeTypeReference("CodeCompileUnit"), "newClassCode", generateCodeThird));
            try1.TryStatements.Add(generateCodeStart);
            try1.TryStatements.Add(generateCodeSecond);
            var logStatementUploadVulnerableWeb = new CodeTypeReferenceExpression("Logger.Instance.Info(\"ClickUploadVulnerableWebButton()\")");
            try1.TryStatements.Add(logStatementUploadVulnerableWeb);
            CodeCatchClause catch1UploadVulnerableWeb = new CodeCatchClause("ex", new CodeTypeReference("Exception"));
            var logStatement2UploadVulnerableWeb = new CodeMethodInvokeExpression(new CodeTypeReferenceExpression("Logger"), "Instance.Error", new CodePrimitiveExpression("Error while trying to Click Upload Vulnerable Web Button  "), new CodeTypeReferenceExpression("ex"));
            catch1UploadVulnerableWeb.Statements.Add(logStatement2UploadVulnerableWeb);
            try1.CatchClauses.Add(catch1UploadVulnerableWeb);
            clickUploadVulnerableWeb.Statements.Add(try1);

            ///private void ClickUploadProtectedWebButton(object sender, RoutedEventArgs e)
            CodeMemberMethod ClickUploadVulnerableWebMethod = new CodeMemberMethod();
            ClickUploadVulnerableWebMethod.Name = "ClickUploadProtectedWebButton";
            ClickUploadVulnerableWebMethod.ReturnType = new CodeTypeReference("System.Void");
            ClickUploadVulnerableWebMethod.Attributes = MemberAttributes.Private;
            ClickUploadVulnerableWebMethod.Parameters.Add(new CodeParameterDeclarationExpression("System.Object", "sender"));
            ClickUploadVulnerableWebMethod.Parameters.Add(new CodeParameterDeclarationExpression("RoutedEventArgs", "e"));
            CodeTryCatchFinallyStatement try2 = new CodeTryCatchFinallyStatement();
            CodeObjectCreateExpression objectFolderBrowserDialog2 = new CodeObjectCreateExpression(new CodeTypeReference("FolderBrowserDialog"));
            try2.TryStatements.Add(new CodeVariableDeclarationStatement(new CodeTypeReference("var"), "dialog", objectFolderBrowserDialog));
            try2.TryStatements.Add(showDialogStatement);
            var contectBetweenText2 = new CodeTypeReferenceExpression("ProtectedWebTextBox.Text = dialog.SelectedPath");
            try2.TryStatements.Add(contectBetweenText2);
            var logStatementUploadVulnerableWebMethod = new CodeTypeReferenceExpression("Logger.Instance.Info(\"ClickUploadProtectedWebButton()\")");
            try2.TryStatements.Add(logStatementUploadVulnerableWebMethod);
            CodeCatchClause catch1UploadVulnerableWebMethod = new CodeCatchClause("ex", new CodeTypeReference("Exception"));
            var logStatement2UploadVulnerableWebMethod = new CodeMethodInvokeExpression(new CodeTypeReferenceExpression("Logger"), "Instance.Error", new CodePrimitiveExpression("Error while trying to Click Upload Protected Web Button "), new CodeTypeReferenceExpression("ex"));
            catch1UploadVulnerableWebMethod.Statements.Add(logStatement2UploadVulnerableWebMethod);
            try2.CatchClauses.Add(catch1UploadVulnerableWebMethod);
            ClickUploadVulnerableWebMethod.Statements.Add(try2);



            ///private void UploadButton(object sender, RoutedEventArgs e)
            CodeMemberMethod ClickUploadMethod = new CodeMemberMethod();
            ClickUploadMethod.Name = "UploadButton";
            ClickUploadMethod.ReturnType = new CodeTypeReference("System.Void");
            ClickUploadMethod.Attributes = MemberAttributes.Private;
            ClickUploadMethod.Parameters.Add(new CodeParameterDeclarationExpression("System.Object", "sender"));
            ClickUploadMethod.Parameters.Add(new CodeParameterDeclarationExpression("RoutedEventArgs", "e"));
            CodeTryCatchFinallyStatement tryUploadMethod = new CodeTryCatchFinallyStatement();
            var logStatementUploadMethod = new CodeTypeReferenceExpression("Logger.Instance.Info(\"UploadButton()\")");
            tryUploadMethod.TryStatements.Add(logStatementUploadMethod);
            CodeCatchClause catch1UploadMethod = new CodeCatchClause("ex", new CodeTypeReference("Exception"));
            var logStatement2UploadMethod = new CodeMethodInvokeExpression(new CodeTypeReferenceExpression("Logger"), "Instance.Error", new CodePrimitiveExpression("Error while trying to Click Upload Protected Web Button  "), new CodeTypeReferenceExpression("ex"));
            catch1UploadMethod.Statements.Add(logStatement2UploadMethod);
            tryUploadMethod.CatchClauses.Add(catch1UploadMethod);
            ClickUploadMethod.Statements.Add(tryUploadMethod);


            //private void ClickUploadButtonVulnerbale(object sender, RoutedEventArgs e)
            CodeMemberMethod ClickUploadButtonVulnerbale = new CodeMemberMethod();
            ClickUploadButtonVulnerbale.Name = "ClickUploadButtonVulnerbale";
            ClickUploadButtonVulnerbale.ReturnType = new CodeTypeReference("System.Void");
            ClickUploadButtonVulnerbale.Attributes = MemberAttributes.Private;
            ClickUploadButtonVulnerbale.Parameters.Add(new CodeParameterDeclarationExpression("System.Object", "sender"));
            ClickUploadButtonVulnerbale.Parameters.Add(new CodeParameterDeclarationExpression("RoutedEventArgs", "e"));
            var contectBetweenTextUploadButtonVulnerbale = new CodeTypeReferenceExpression("string destinationFile = VulnerableWebTextBox.Text");
            var listStatement = new CodeVariableDeclarationStatement(typeof(List<string>), "listPath", new CodeTypeReferenceExpression("destinationFile.Split('\\\\').ToList()"));
            var nameDirectoryStatement = new CodeVariableDeclarationStatement(new CodeTypeReference("var"), "nameDirectory", new CodeArgumentReferenceExpression("listPath[listPath.Count - 1]"));
            var moveStatement = new CodeMethodInvokeExpression(new CodeTypeReferenceExpression("Directory"), "Move", new CodeTypeReferenceExpression("VulnerableWebTextBox.Text"), new CodeArgumentReferenceExpression("Directory.GetCurrentDirectory() + " + "'\\\\'" + " + nameDirectory"));
            var falseStatmentNumber1 = new CodeTypeReferenceExpression("UploadVulnerableWebButton.IsEnabled = false");
            var falseStatmentNumber2 = new CodeTypeReferenceExpression("UploadButtonVulnerbale.IsEnabled = false");
            var falseStatmentNumber3 = new CodeTypeReferenceExpression("VulnerableWebTextBox.IsEnabled = false");
            var logStatementUploadButtonVulnerbale = new CodeTypeReferenceExpression("Logger.Instance.Info(\"ClickUploadButtonVulnerbale()\")");
            CodeTryCatchFinallyStatement tryUploadButtonVulnerbale = new CodeTryCatchFinallyStatement();
            tryUploadButtonVulnerbale.TryStatements.Add(contectBetweenTextUploadButtonVulnerbale);
            tryUploadButtonVulnerbale.TryStatements.Add(listStatement);
            tryUploadButtonVulnerbale.TryStatements.Add(nameDirectoryStatement);
            tryUploadButtonVulnerbale.TryStatements.Add(moveStatement);
            tryUploadButtonVulnerbale.TryStatements.Add(falseStatmentNumber1);
            tryUploadButtonVulnerbale.TryStatements.Add(falseStatmentNumber2);
            tryUploadButtonVulnerbale.TryStatements.Add(falseStatmentNumber3);
            CodeCatchClause catch1UploadButtonVulnerbale = new CodeCatchClause("ex", new CodeTypeReference("Exception"));
            var logStatementUploadButtonVulnerbale2 = new CodeMethodInvokeExpression(new CodeTypeReferenceExpression("Logger"), "Instance.Error", new CodePrimitiveExpression("Error while trying to Click Upload Button Vulnerbale  "), new CodeTypeReferenceExpression("ex"));
            catch1UploadButtonVulnerbale.Statements.Add(logStatementUploadButtonVulnerbale2);
            tryUploadButtonVulnerbale.CatchClauses.Add(catch1UploadButtonVulnerbale);
            ClickUploadButtonVulnerbale.Statements.Add(tryUploadButtonVulnerbale);


            //private void ClickUploadButtonProtected(object sender, RoutedEventArgs e)
            CodeMemberMethod ClickUploadButtonProtected = new CodeMemberMethod();
            ClickUploadButtonProtected.Name = "ClickUploadButtonProtected";
            ClickUploadButtonProtected.ReturnType = new CodeTypeReference("System.Void");
            ClickUploadButtonProtected.Attributes = MemberAttributes.Private;
            ClickUploadButtonProtected.Parameters.Add(new CodeParameterDeclarationExpression("System.Object", "sender"));
            ClickUploadButtonProtected.Parameters.Add(new CodeParameterDeclarationExpression("RoutedEventArgs", "e"));
            var contectBetweenTextUploadButtonProtected = new CodeTypeReferenceExpression("string sourceFile = ProtectedWebTextBox.Text");
            var contectBetweenTextUploadButtonProtected2 = new CodeTypeReferenceExpression("string destinationFile = ProtectedWebTextBox.Text");
            var listStatement2 = new CodeVariableDeclarationStatement(typeof(List<string>), "listPath", new CodeTypeReferenceExpression("destinationFile.Split('\\\\').ToList()"));
            var nameDirectoryStatement2 = new CodeVariableDeclarationStatement(new CodeTypeReference("var"), "nameDirectory", new CodeArgumentReferenceExpression("listPath[listPath.Count - 1]"));
            var moveStatement2 = new CodeMethodInvokeExpression(new CodeTypeReferenceExpression("Directory"), "Move", new CodeTypeReferenceExpression("ProtectedWebTextBox.Text"), new CodeArgumentReferenceExpression("Directory.GetCurrentDirectory() +" + "'\\\\'" + "+ nameDirectory"));

            var falseStatmentUploadButtonProtectedNumber1 = new CodeTypeReferenceExpression("UploadProtectedWebButton.IsEnabled = false");
            var falseStatmentUploadButtonProtectedNumber2 = new CodeTypeReferenceExpression("UploadButtonProtected.IsEnabled = false");
            var falseStatmentUploadButtonProtectedNumber3 = new CodeTypeReferenceExpression("ProtectedWebTextBox.IsEnabled = false");
            var logStatementUploadButtonProtected = new CodeTypeReferenceExpression("Logger.Instance.Info(\"ClickUploadButtonProtected()\")");
            CodeTryCatchFinallyStatement tryUploadButtonProtected = new CodeTryCatchFinallyStatement();
            tryUploadButtonProtected.TryStatements.Add(contectBetweenTextUploadButtonProtected);
            tryUploadButtonProtected.TryStatements.Add(contectBetweenTextUploadButtonProtected2);
            tryUploadButtonProtected.TryStatements.Add(listStatement2);
            tryUploadButtonProtected.TryStatements.Add(nameDirectoryStatement2);
            tryUploadButtonProtected.TryStatements.Add(moveStatement2);
            tryUploadButtonProtected.TryStatements.Add(falseStatmentUploadButtonProtectedNumber1);
            tryUploadButtonProtected.TryStatements.Add(falseStatmentUploadButtonProtectedNumber2);
            tryUploadButtonProtected.TryStatements.Add(falseStatmentUploadButtonProtectedNumber3);
            tryUploadButtonProtected.TryStatements.Add(logStatementUploadButtonProtected);
            CodeCatchClause catchUploadButtonProtected = new CodeCatchClause("ex", new CodeTypeReference("Exception"));
            var logStatementUploadButtonProtected2 = new CodeMethodInvokeExpression(new CodeTypeReferenceExpression("Logger"), "Instance.Error", new CodePrimitiveExpression("Error while trying to Click Upload Button Protected  "), new CodeTypeReferenceExpression("ex"));
            catchUploadButtonProtected.Statements.Add(logStatementUploadButtonProtected2);
            tryUploadButtonProtected.CatchClauses.Add(catchUploadButtonProtected);
            ClickUploadButtonProtected.Statements.Add(tryUploadButtonProtected);

            #endregion Methods Creation




            constructor.Statements.Add(init);
            newType.Members.Add(clickUploadVulnerableWeb);
            newType.Members.Add(ClickUploadVulnerableWebMethod);
            newType.Members.Add(ClickUploadMethod);
            newType.Members.Add(ClickUploadButtonProtected);
            newType.Members.Add(ClickUploadButtonVulnerbale);

            newType.Members.Add(constructor);
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

        public void SwitchClass(string className, string mainPath, string nameDirectory = null)
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
            string nameProject = ListNameOfProject[ListNameOfProject.Count - 3];
            if (File.Exists(newPath + className + ".xaml.cs"))
            {
                File.Delete(newPath + className + ".xaml.cs");
            }
            File.Move(mainPath + "\\" + className + ".xaml.cs", newPath + "\\" + className + ".xaml.cs");
            var p = new Microsoft.Build.Evaluation.Project();
            //csprojObjectPath + nameProject + ".csproj"
            p.AddItem("Compile", newPath + "\\" + className + ".xaml.cs");
            var x = p.GetItems("Compile").Where(a => a.UnevaluatedInclude == newPath + "\\" + className + ".xaml.cs").FirstOrDefault();
            p.RemoveItem(x);
            //p.Save();
        }
    }


}
