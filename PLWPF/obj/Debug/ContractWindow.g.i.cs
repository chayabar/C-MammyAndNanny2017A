﻿#pragma checksum "..\..\ContractWindow.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "EA5E54E94812B55D63B2D46F532816A3"
//------------------------------------------------------------------------------
// <auto-generated>
//     קוד זה נוצר על-ידי כלי.
//     גירסת זמן ריצה:4.0.30319.42000
//
//     ייתכן ששינויים בקובץ זה גרמו לפעולה לא תקינה ויאבדו אם
//     הקוד נוצר מחדש.
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
    /// ContractWindow
    /// </summary>
    public partial class ContractWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 23 "..\..\ContractWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button AddContractButton;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\ContractWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button UpdateContractButton;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\ContractWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button DeleteContractButton;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\ContractWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ShowAllContracts;
        
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
            System.Uri resourceLocater = new System.Uri("/PLWPF;component/contractwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\ContractWindow.xaml"
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
            this.AddContractButton = ((System.Windows.Controls.Button)(target));
            
            #line 24 "..\..\ContractWindow.xaml"
            this.AddContractButton.Click += new System.Windows.RoutedEventHandler(this.AddContractButton_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.UpdateContractButton = ((System.Windows.Controls.Button)(target));
            
            #line 27 "..\..\ContractWindow.xaml"
            this.UpdateContractButton.Click += new System.Windows.RoutedEventHandler(this.UpdateContractButton_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.DeleteContractButton = ((System.Windows.Controls.Button)(target));
            
            #line 30 "..\..\ContractWindow.xaml"
            this.DeleteContractButton.Click += new System.Windows.RoutedEventHandler(this.DeleteContractButton_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.ShowAllContracts = ((System.Windows.Controls.Button)(target));
            
            #line 31 "..\..\ContractWindow.xaml"
            this.ShowAllContracts.Click += new System.Windows.RoutedEventHandler(this.ShowAllContractsButton_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

