﻿#pragma checksum "..\..\ChildWindow.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "A8505B2BDCC7B036F29891C753FAEE43"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using PLWPF;
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


namespace PLWPF {
    
    
    /// <summary>
    /// ChildWindow
    /// </summary>
    public partial class ChildWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 22 "..\..\ChildWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button AddChildButton;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\ChildWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button UpdateChildButton;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\ChildWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button DeleteChildButton;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\ChildWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ShowAllChilds;
        
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
            System.Uri resourceLocater = new System.Uri("/PLWPF;component/childwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\ChildWindow.xaml"
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
            this.AddChildButton = ((System.Windows.Controls.Button)(target));
            
            #line 22 "..\..\ChildWindow.xaml"
            this.AddChildButton.Click += new System.Windows.RoutedEventHandler(this.AddChildButton_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.UpdateChildButton = ((System.Windows.Controls.Button)(target));
            
            #line 24 "..\..\ChildWindow.xaml"
            this.UpdateChildButton.Click += new System.Windows.RoutedEventHandler(this.UpdateChildButton_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.DeleteChildButton = ((System.Windows.Controls.Button)(target));
            
            #line 26 "..\..\ChildWindow.xaml"
            this.DeleteChildButton.Click += new System.Windows.RoutedEventHandler(this.DeleteChildButton_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.ShowAllChilds = ((System.Windows.Controls.Button)(target));
            
            #line 27 "..\..\ChildWindow.xaml"
            this.ShowAllChilds.Click += new System.Windows.RoutedEventHandler(this.ShowAllChildsButton_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

