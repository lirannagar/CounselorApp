﻿#pragma checksum "..\..\..\Advises\SecurityAdviceWidnow .xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "06FCD52A04478F8F413679C4192528C5C90D0225"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using CounselorApp.Advises;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace CounselorApp.Advises {
    
    
    /// <summary>
    /// SecurityAdviceWidnow
    /// </summary>
    public partial class SecurityAdviceWidnow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 11 "..\..\..\Advises\SecurityAdviceWidnow .xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button webProtectedButton;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\..\Advises\SecurityAdviceWidnow .xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button webNotProtectedButton;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\..\Advises\SecurityAdviceWidnow .xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RichTextBox BodyTextBox;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\..\Advises\SecurityAdviceWidnow .xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button OpenSourceButton;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/CounselorApp;component/advises/securityadvicewidnow%20.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Advises\SecurityAdviceWidnow .xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.webProtectedButton = ((System.Windows.Controls.Button)(target));
            
            #line 11 "..\..\..\Advises\SecurityAdviceWidnow .xaml"
            this.webProtectedButton.Click += new System.Windows.RoutedEventHandler(this.ClickProtectedWeb);
            
            #line default
            #line hidden
            return;
            case 2:
            this.webNotProtectedButton = ((System.Windows.Controls.Button)(target));
            
            #line 12 "..\..\..\Advises\SecurityAdviceWidnow .xaml"
            this.webNotProtectedButton.Click += new System.Windows.RoutedEventHandler(this.ClickVulnerableWeb);
            
            #line default
            #line hidden
            return;
            case 3:
            this.BodyTextBox = ((System.Windows.Controls.RichTextBox)(target));
            return;
            case 4:
            this.OpenSourceButton = ((System.Windows.Controls.Button)(target));
            
            #line 20 "..\..\..\Advises\SecurityAdviceWidnow .xaml"
            this.OpenSourceButton.Click += new System.Windows.RoutedEventHandler(this.ClickOnOpenSource);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

