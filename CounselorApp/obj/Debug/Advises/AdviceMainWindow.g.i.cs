﻿#pragma checksum "..\..\..\Advises\AdviceMainWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "C9294045A6E095C16831610146F0B1CD92F07411"
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
    /// AdviceMainWindow
    /// </summary>
    public partial class AdviceMainWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 11 "..\..\..\Advises\AdviceMainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label LabelChoose;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\..\Advises\AdviceMainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox ComboBoxAdvices;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\..\Advises\AdviceMainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ShowAdviceButton;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\..\Advises\AdviceMainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BackButton;
        
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
            System.Uri resourceLocater = new System.Uri("/CounselorApp;component/advises/advicemainwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Advises\AdviceMainWindow.xaml"
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
            this.LabelChoose = ((System.Windows.Controls.Label)(target));
            return;
            case 2:
            this.ComboBoxAdvices = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 3:
            this.ShowAdviceButton = ((System.Windows.Controls.Button)(target));
            
            #line 15 "..\..\..\Advises\AdviceMainWindow.xaml"
            this.ShowAdviceButton.Click += new System.Windows.RoutedEventHandler(this.ClickShowAdvice);
            
            #line default
            #line hidden
            return;
            case 4:
            this.BackButton = ((System.Windows.Controls.Button)(target));
            
            #line 16 "..\..\..\Advises\AdviceMainWindow.xaml"
            this.BackButton.Click += new System.Windows.RoutedEventHandler(this.ClickOnBackButton);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

