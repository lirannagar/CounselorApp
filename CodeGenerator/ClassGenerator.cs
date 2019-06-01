using Microsoft.CSharp;
using System;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace CodeGenerator
{
    public class ClassGenerator
    {
        const string NODE_JS_EXTENSION_FILE = "js";
        const string EXE_EXTENSION_FILE = "exe";

        private string ipAddress;

        public CodeCompileUnit GenerateCSharpCode(string className, string classNameSpace, string path, string nameFile)
        {
            CodeCompileUnit compileUnit = new CodeCompileUnit();

            compileUnit = GenerateServerCode(compileUnit, className, classNameSpace, path, nameFile);


            // Return the CompileUnit
            //
            return compileUnit;
        }

        // Generate code for a particular provider and compile it
        //
        public void GenerateCode(CodeCompileUnit ccu, String className)
        {
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
        private CodeCompileUnit GenerateServerCode(CodeCompileUnit compileUnit, string className, string classNameSpace, string pathFile, string fileName)
        {

            #region NameSpace Creation
            var codedomsamplenamespace = new CodeNamespace(classNameSpace);
            #endregion NameSpace Creation

            #region Import Creation
            var firstimport = new CodeNamespaceImport("System");
            var secondImport = new CodeNamespaceImport("System.Diagnostics");
            var thirdImport = new CodeNamespaceImport("System.Net");
            var fourImport = new CodeNamespaceImport("System.Net.Sockets");

            codedomsamplenamespace.Imports.Add(firstimport);
            codedomsamplenamespace.Imports.Add(secondImport);
            codedomsamplenamespace.Imports.Add(thirdImport);
            codedomsamplenamespace.Imports.Add(fourImport);
            #endregion Import Creation

            #region Class Creation
            var newType = new CodeTypeDeclaration(className) { Attributes = MemberAttributes.Public };
            #endregion Class Creation

            #region Member Creation
            var members = new CodeMemberField();
            members.Attributes = MemberAttributes.Private;
            members.Name = "p";
            members.Type = new CodeTypeReference(typeof(Process));
            newType.Members.Add(members);
            #endregion Member Creation

            #region Constructor Creation
            var constructor = new CodeConstructor { Attributes = MemberAttributes.Public };
            var statement = new CodeTypeReferenceExpression("p = new Process()");
            var statementOne = new CodeAssignStatement(new CodeVariableReferenceExpression("p.StartInfo.WorkingDirectory"), new CodePrimitiveExpression(pathFile));
            var statementTwo = new CodeTypeReferenceExpression("p.StartInfo.WindowStyle  = ProcessWindowStyle.Hidden");
            var statementThree = new CodeAssignStatement(new CodeVariableReferenceExpression("p.StartInfo.FileName"), new CodePrimitiveExpression("cmd.exe"));
            CodeAssignStatement statementFour = null;
            if(fileName.Contains(NODE_JS_EXTENSION_FILE))
                statementFour =  new CodeAssignStatement(new CodeVariableReferenceExpression("p.StartInfo.Arguments"), new CodePrimitiveExpression("/c node " + fileName));
            else if (fileName.Contains(EXE_EXTENSION_FILE))
                statementFour = new CodeAssignStatement(new CodeVariableReferenceExpression("p.StartInfo.Arguments"), new CodePrimitiveExpression("/c " + fileName));


            constructor.Statements.Add(statement);
            constructor.Statements.Add(statementOne);
            constructor.Statements.Add(statementTwo);
            constructor.Statements.Add(statementThree);
            constructor.Statements.Add(statementFour);

            newType.Members.Add(constructor);
            #endregion Constructor Creation

            #region Method Creation
            // Declaring a ToString method
            CodeMemberMethod methodStart = new CodeMemberMethod()
            {
                Name = "StartServer",
                Attributes = MemberAttributes.Public | MemberAttributes.Final
            };
            var startCode = new CodeTypeReferenceExpression("p.Start()");
            methodStart.Statements.Add(startCode);


            CodeMemberMethod methodDispose = new CodeMemberMethod()
            {
                Name = "ShutDown",
                Attributes = MemberAttributes.Public | MemberAttributes.Final
            };
            var disposeCodeOne = new CodeTypeReferenceExpression("p.Kill()");
            var disposeCodeTwo = new CodeTypeReferenceExpression("p.Dispose()");
            methodDispose.Statements.Add(disposeCodeOne);
            methodDispose.Statements.Add(disposeCodeTwo);

            CodeMemberMethod methodOpenBrowser = new CodeMemberMethod()
            {
                Name = "OpenBrowser",
                Attributes = MemberAttributes.Public | MemberAttributes.Final
            };
            string portNumber = null;
            if (fileName.Contains(NODE_JS_EXTENSION_FILE)) { portNumber = "3000"; } else if (fileName.Contains(EXE_EXTENSION_FILE)) { portNumber = "3001"; }
            var openBrowerCode = new CodeMethodInvokeExpression(new CodeTypeReferenceExpression("Process"), "Start", new CodePrimitiveExpression("http://" + ipAddress +":"+ portNumber + ""));
            methodOpenBrowser.Statements.Add(openBrowerCode);

            newType.Members.Add(methodStart);
            newType.Members.Add(methodDispose);
            newType.Members.Add(methodOpenBrowser);
            #endregion Method Creation

            // Add the type to the namespace
            //
            codedomsamplenamespace.Types.Add(newType);

            // Add the NameSpace to the CodeCompileUnit
            //
            compileUnit.Namespaces.Add(codedomsamplenamespace);
            return compileUnit;
        }
        public void SetIPAddress(string ip)
        {
            this.ipAddress = ip;
        }

        public void AddClassToSolution(string className, string mainPath, string projectName = null)
        {
            List<string> listPath = mainPath.Split('\\').ToList();

            string newString = mainPath;
            string newPath;
            List<string> ListNameOfProject = mainPath.Split('\\').ToList();
            string nameProject = ListNameOfProject[ListNameOfProject.Count - 3];
            if (!string.IsNullOrEmpty(projectName))
            {
                newPath = newString.Remove(newString.Length - (10 + nameProject.Length), (10 + nameProject.Length));
                newPath += projectName;
            }
            else
                newPath = newString.Remove(newString.Length - 9, 9);

            if (!string.IsNullOrEmpty(nameProject)) { nameProject = projectName; }
            File.Move(mainPath + "\\" + className + ".cs", newPath + "\\" + className + ".cs");
            var p = new Microsoft.Build.Evaluation.Project(newPath + "\\" + nameProject + ".csproj");
            //
            p.AddItem("Compile", newPath + "\\" + className + ".cs");
            p.Save();
        }
        public void SwitchClass(string className, string mainPath, string projectName = null)
        {
            List<string> listPath = mainPath.Split('\\').ToList();

            string newString = mainPath;
            string newPath = newString.Remove(newString.Length - 9, 9);
            List<string> ListNameOfProject = mainPath.Split('\\').ToList();

            string nameProject = ListNameOfProject[ListNameOfProject.Count - 4];
            if (!string.IsNullOrEmpty(projectName))
            {
                newPath = newString.Remove(newString.Length - (10 + nameProject.Length), (10 + nameProject.Length));
                newPath += projectName;
            }
            else
                newPath = newString.Remove(newString.Length - 9, 9);

            if (File.Exists(newPath + "\\" + className + ".cs"))
            {
                File.Delete(newPath + "\\" + className + ".cs");
            }

            File.Move(mainPath + "\\" + className + ".cs", newPath + "\\" + className + ".cs");
            var p = new Microsoft.Build.Evaluation.Project(newPath + "\\" + nameProject + ".csproj");
            p.AddItem("Compile", newPath + "\\" + className + ".cs");
            var x = p.GetItems("Compile").Where(a => a.UnevaluatedInclude == newPath + "\\" + className + ".cs").FirstOrDefault();
            p.RemoveItem(x);
            p.Save();
        }

    }
}
