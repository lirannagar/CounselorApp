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
        public CodeCompileUnit GenerateCSharpCode(string className, string classNameSpace)
        {
            var compileUnit = new CodeCompileUnit();

            var codedomsamplenamespace = new CodeNamespace(classNameSpace);

            var firstimport = new CodeNamespaceImport("System.Diagnostics");
            var secondImport = new CodeNamespaceImport("CodeGenerator");
            var thirdImport = new CodeNamespaceImport("System.CodeDom");
            var fourImport = new CodeNamespaceImport("System.Collections.Generic");
            var fiveImport = new CodeNamespaceImport("System.IO");
            var sixImport = new CodeNamespaceImport("System.Linq");
            codedomsamplenamespace.Imports.Add(firstimport);
            codedomsamplenamespace.Imports.Add(secondImport);
            codedomsamplenamespace.Imports.Add(thirdImport);
            codedomsamplenamespace.Imports.Add(fourImport);
            codedomsamplenamespace.Imports.Add(firstimport);
            codedomsamplenamespace.Imports.Add(sixImport);

            var newType = new CodeTypeDeclaration(className) { Attributes = MemberAttributes.Public };
            CodeMemberMethod mainMethod = new CodeMemberMethod()
            {
                Name = "Main",
                Attributes = MemberAttributes.Public | MemberAttributes.Final | MemberAttributes.Static,
                ReturnType = new CodeTypeReference("System.Void")
            };
            newType.Members.Add(mainMethod);
            codedomsamplenamespace.Types.Add(newType);

            compileUnit.Namespaces.Add(codedomsamplenamespace);


            // Create a NameSpace - "namespace CodeDomSampleNS"
            //



            // Create using statement - "using System;"
            //


            // Add the using statement to the namespace -
            // namespace CodeDomSampleNS {
            //      using System;
            //
            codedomsamplenamespace.Imports.Add(firstimport);

            // Create a type inside the namespace - public class CodeDomSample
            //


            var members = new CodeMemberField();
            members.Attributes = MemberAttributes.Private;
            members.Name = "p";
            members.Type = new CodeTypeReference(typeof(Process));
            newType.Members.Add(members);

            var constructor = new CodeConstructor { Attributes = MemberAttributes.Public };

            var constructorexpOne = new CodeAssignStatement(new CodeVariableReferenceExpression("p.StartInfo.WorkingDirectory"), new CodePrimitiveExpression(@"C:\Users\Liran\Desktop\WebTest"));
            var constructorexpTwo = new CodeTypeReferenceExpression("p.StartInfo.WindowStyle  = ProcessWindowStyle.Hidden");
            var constructorexpThree = new CodeAssignStatement(new CodeVariableReferenceExpression("p.StartInfo.FileName"), new CodePrimitiveExpression("cmd.exe"));
            var constructorexpFour = new CodeAssignStatement(new CodeVariableReferenceExpression("p.StartInfo.Arguments"), new CodePrimitiveExpression("/c node app.js"));

            constructor.Statements.Add(constructorexpOne);
            constructor.Statements.Add(constructorexpTwo);
            constructor.Statements.Add(constructorexpThree);
            constructor.Statements.Add(constructorexpFour);

            newType.Members.Add(constructor);
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
                Name = "OpenBrowserd",
                Attributes = MemberAttributes.Public | MemberAttributes.Final
            };
            var openBrowerCode = new CodeMethodInvokeExpression(new CodeTypeReferenceExpression("Process"), "Start", new CodePrimitiveExpression("http://:3000"));
            methodOpenBrowser.Statements.Add(openBrowerCode);



            newType.Members.Add(methodStart);
            newType.Members.Add(methodDispose);
            newType.Members.Add(methodOpenBrowser);


            // Add the type to the namespace
            //
            codedomsamplenamespace.Types.Add(newType);

            // Add the NameSpace to the CodeCompileUnit
            //
            compileUnit.Namespaces.Add(codedomsamplenamespace);

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
        public void SwitchClass(string className, string mainPath)
        {
            List<string> listPath = mainPath.Split('\\').ToList();

            string newString = mainPath;
            string newPath = newString.Remove(newString.Length - 9, 9);
            List<string> ListNameOfProject = mainPath.Split('\\').ToList();

            string nameProject = ListNameOfProject[ListNameOfProject.Count - 4];


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
