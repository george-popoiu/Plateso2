﻿#pragma checksum "..\..\..\Modules\ChangePassword.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "A9643DCCA45B33B393E40C56D62358FE"
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
    /// ChangePassword
    /// </summary>
    public partial class ChangePassword : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 5 "..\..\..\Modules\ChangePassword.xaml"
        internal System.Windows.Controls.Grid grid_root;
        
        #line default
        #line hidden
        
        
        #line 7 "..\..\..\Modules\ChangePassword.xaml"
        internal System.Windows.Controls.Grid grid_layout;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\..\Modules\ChangePassword.xaml"
        internal System.Windows.Controls.Grid grid_top;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\..\Modules\ChangePassword.xaml"
        internal System.Windows.Controls.Button button_exit;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\..\Modules\ChangePassword.xaml"
        internal System.Windows.Controls.Button button_minimize;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\..\Modules\ChangePassword.xaml"
        internal System.Windows.Controls.TextBlock text_title;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\..\Modules\ChangePassword.xaml"
        internal System.Windows.Controls.Grid grid_middle;
        
        #line default
        #line hidden
        
        
        #line 59 "..\..\..\Modules\ChangePassword.xaml"
        internal System.Windows.Controls.TextBox tbUsername;
        
        #line default
        #line hidden
        
        
        #line 64 "..\..\..\Modules\ChangePassword.xaml"
        internal System.Windows.Controls.PasswordBox tbOldPassword;
        
        #line default
        #line hidden
        
        
        #line 69 "..\..\..\Modules\ChangePassword.xaml"
        internal System.Windows.Controls.PasswordBox tbNewPassword;
        
        #line default
        #line hidden
        
        
        #line 74 "..\..\..\Modules\ChangePassword.xaml"
        internal System.Windows.Controls.PasswordBox tbNewPassword2;
        
        #line default
        #line hidden
        
        
        #line 77 "..\..\..\Modules\ChangePassword.xaml"
        internal System.Windows.Controls.Button button_changepassword;
        
        #line default
        #line hidden
        
        
        #line 82 "..\..\..\Modules\ChangePassword.xaml"
        internal System.Windows.Controls.Grid grid_bottom;
        
        #line default
        #line hidden
        
        
        #line 83 "..\..\..\Modules\ChangePassword.xaml"
        internal System.Windows.Controls.TextBlock text_bottom;
        
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
            System.Uri resourceLocater = new System.Uri("/Plateso2;component/modules/changepassword.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Modules\ChangePassword.xaml"
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
            this.grid_root = ((System.Windows.Controls.Grid)(target));
            return;
            case 2:
            this.grid_layout = ((System.Windows.Controls.Grid)(target));
            return;
            case 3:
            this.grid_top = ((System.Windows.Controls.Grid)(target));
            
            #line 15 "..\..\..\Modules\ChangePassword.xaml"
            this.grid_top.MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.grid_top_MouseLeftButtonDown);
            
            #line default
            #line hidden
            return;
            case 4:
            this.button_exit = ((System.Windows.Controls.Button)(target));
            
            #line 22 "..\..\..\Modules\ChangePassword.xaml"
            this.button_exit.Click += new System.Windows.RoutedEventHandler(this.button_exit_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.button_minimize = ((System.Windows.Controls.Button)(target));
            
            #line 28 "..\..\..\Modules\ChangePassword.xaml"
            this.button_minimize.Click += new System.Windows.RoutedEventHandler(this.button_minimize_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.text_title = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 7:
            this.grid_middle = ((System.Windows.Controls.Grid)(target));
            return;
            case 8:
            this.tbUsername = ((System.Windows.Controls.TextBox)(target));
            return;
            case 9:
            this.tbOldPassword = ((System.Windows.Controls.PasswordBox)(target));
            return;
            case 10:
            this.tbNewPassword = ((System.Windows.Controls.PasswordBox)(target));
            return;
            case 11:
            this.tbNewPassword2 = ((System.Windows.Controls.PasswordBox)(target));
            return;
            case 12:
            this.button_changepassword = ((System.Windows.Controls.Button)(target));
            
            #line 77 "..\..\..\Modules\ChangePassword.xaml"
            this.button_changepassword.Click += new System.Windows.RoutedEventHandler(this.button_changepassword_Click);
            
            #line default
            #line hidden
            return;
            case 13:
            this.grid_bottom = ((System.Windows.Controls.Grid)(target));
            return;
            case 14:
            this.text_bottom = ((System.Windows.Controls.TextBlock)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}
