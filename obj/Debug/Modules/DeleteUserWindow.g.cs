﻿#pragma checksum "..\..\..\Modules\DeleteUserWindow.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "0077477F2D79BE831452B9784952260A"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.4927
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

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


namespace Plateso2.Modules {
    
    
    /// <summary>
    /// DeleteUserWindow
    /// </summary>
    public partial class DeleteUserWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 5 "..\..\..\Modules\DeleteUserWindow.xaml"
        internal System.Windows.Controls.Grid gridRoot;
        
        #line default
        #line hidden
        
        
        #line 9 "..\..\..\Modules\DeleteUserWindow.xaml"
        internal System.Windows.Controls.Grid gridLayout;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\..\Modules\DeleteUserWindow.xaml"
        internal System.Windows.Controls.Grid gridTop;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\..\Modules\DeleteUserWindow.xaml"
        internal System.Windows.Controls.StackPanel stackTopButtons;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\..\Modules\DeleteUserWindow.xaml"
        internal System.Windows.Controls.Button butExit;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\..\Modules\DeleteUserWindow.xaml"
        internal System.Windows.Controls.Button butMinimize;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\..\Modules\DeleteUserWindow.xaml"
        internal System.Windows.Controls.TextBlock textbTitle;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\..\Modules\DeleteUserWindow.xaml"
        internal System.Windows.Controls.Grid gridMiddle;
        
        #line default
        #line hidden
        
        
        #line 60 "..\..\..\Modules\DeleteUserWindow.xaml"
        internal System.Windows.Controls.TextBox tbUsername;
        
        #line default
        #line hidden
        
        
        #line 65 "..\..\..\Modules\DeleteUserWindow.xaml"
        internal System.Windows.Controls.PasswordBox tbPassword;
        
        #line default
        #line hidden
        
        
        #line 68 "..\..\..\Modules\DeleteUserWindow.xaml"
        internal System.Windows.Controls.Button buttonDeleteUser;
        
        #line default
        #line hidden
        
        
        #line 70 "..\..\..\Modules\DeleteUserWindow.xaml"
        internal System.Windows.Controls.Grid gridFooter;
        
        #line default
        #line hidden
        
        
        #line 71 "..\..\..\Modules\DeleteUserWindow.xaml"
        internal System.Windows.Controls.TextBlock textFooter;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Plateso2;component/modules/deleteuserwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Modules\DeleteUserWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.gridRoot = ((System.Windows.Controls.Grid)(target));
            return;
            case 2:
            this.gridLayout = ((System.Windows.Controls.Grid)(target));
            return;
            case 3:
            this.gridTop = ((System.Windows.Controls.Grid)(target));
            
            #line 17 "..\..\..\Modules\DeleteUserWindow.xaml"
            this.gridTop.MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.gridTop_MouseLeftButtonDown);
            
            #line default
            #line hidden
            return;
            case 4:
            this.stackTopButtons = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 5:
            this.butExit = ((System.Windows.Controls.Button)(target));
            
            #line 25 "..\..\..\Modules\DeleteUserWindow.xaml"
            this.butExit.Click += new System.Windows.RoutedEventHandler(this.butExit_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.butMinimize = ((System.Windows.Controls.Button)(target));
            
            #line 29 "..\..\..\Modules\DeleteUserWindow.xaml"
            this.butMinimize.Click += new System.Windows.RoutedEventHandler(this.butMinimize_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.textbTitle = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 8:
            this.gridMiddle = ((System.Windows.Controls.Grid)(target));
            return;
            case 9:
            this.tbUsername = ((System.Windows.Controls.TextBox)(target));
            return;
            case 10:
            this.tbPassword = ((System.Windows.Controls.PasswordBox)(target));
            return;
            case 11:
            this.buttonDeleteUser = ((System.Windows.Controls.Button)(target));
            
            #line 68 "..\..\..\Modules\DeleteUserWindow.xaml"
            this.buttonDeleteUser.Click += new System.Windows.RoutedEventHandler(this.buttonDeleteUser_Click);
            
            #line default
            #line hidden
            return;
            case 12:
            this.gridFooter = ((System.Windows.Controls.Grid)(target));
            return;
            case 13:
            this.textFooter = ((System.Windows.Controls.TextBlock)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}
