﻿#pragma checksum "..\..\frmUser.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "089E30B588E05B1F8D3C6023C32CE17D544BFBFC"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Minh_WPF_C2_B1;
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


namespace Minh_WPF_C2_B1 {
    
    
    /// <summary>
    /// frmUser
    /// </summary>
    public partial class frmUser : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 24 "..\..\frmUser.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lbTrang;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\frmUser.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem menuDat;
        
        #line default
        #line hidden
        
        
        #line 49 "..\..\frmUser.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem menuXem;
        
        #line default
        #line hidden
        
        
        #line 57 "..\..\frmUser.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem menuThoat;
        
        #line default
        #line hidden
        
        
        #line 61 "..\..\frmUser.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel stackPanel;
        
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
            System.Uri resourceLocater = new System.Uri("/Minh_WPF_C2_B1;component/frmuser.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\frmUser.xaml"
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
            this.lbTrang = ((System.Windows.Controls.Label)(target));
            return;
            case 2:
            this.menuDat = ((System.Windows.Controls.MenuItem)(target));
            
            #line 42 "..\..\frmUser.xaml"
            this.menuDat.Click += new System.Windows.RoutedEventHandler(this.menuDat_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.menuXem = ((System.Windows.Controls.MenuItem)(target));
            
            #line 50 "..\..\frmUser.xaml"
            this.menuXem.Click += new System.Windows.RoutedEventHandler(this.menuXem_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.menuThoat = ((System.Windows.Controls.MenuItem)(target));
            
            #line 58 "..\..\frmUser.xaml"
            this.menuThoat.Click += new System.Windows.RoutedEventHandler(this.menuThoat_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.stackPanel = ((System.Windows.Controls.StackPanel)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

