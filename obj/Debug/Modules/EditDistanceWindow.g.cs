﻿#pragma checksum "..\..\..\Modules\EditDistanceWindow.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "0DDDDF205F3CA617EEBDC7303A875D79"
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
    /// EditDistanceWindow
    /// </summary>
    public partial class EditDistanceWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 5 "..\..\..\Modules\EditDistanceWindow.xaml"
        internal System.Windows.Controls.Grid gridRoot;
        
        #line default
        #line hidden
        
        
        #line 9 "..\..\..\Modules\EditDistanceWindow.xaml"
        internal System.Windows.Controls.Grid gridLayout;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\..\Modules\EditDistanceWindow.xaml"
        internal System.Windows.Controls.Grid gridTop;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\..\Modules\EditDistanceWindow.xaml"
        internal System.Windows.Controls.StackPanel stackTopButtons;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\..\Modules\EditDistanceWindow.xaml"
        internal System.Windows.Controls.Button butExit;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\..\Modules\EditDistanceWindow.xaml"
        internal System.Windows.Controls.Button butMinimize;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\..\Modules\EditDistanceWindow.xaml"
        internal System.Windows.Controls.Grid gridMiddle;
        
        #line default
        #line hidden
        
        
        #line 54 "..\..\..\Modules\EditDistanceWindow.xaml"
        internal System.Windows.Controls.ListBox lbDocuments;
        
        #line default
        #line hidden
        
        
        #line 59 "..\..\..\Modules\EditDistanceWindow.xaml"
        internal System.Windows.Controls.Button butOk;
        
        #line default
        #line hidden
        
        
        #line 63 "..\..\..\Modules\EditDistanceWindow.xaml"
        internal System.Windows.Controls.Button butCancel;
        
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
            System.Uri resourceLocater = new System.Uri("/Plateso2;component/modules/editdistancewindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Modules\EditDistanceWindow.xaml"
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
            
            #line 17 "..\..\..\Modules\EditDistanceWindow.xaml"
            this.gridTop.MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.gridTop_MouseLeftButtonDown);
            
            #line default
            #line hidden
            return;
            case 4:
            this.stackTopButtons = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 5:
            this.butExit = ((System.Windows.Controls.Button)(target));
            
            #line 25 "..\..\..\Modules\EditDistanceWindow.xaml"
            this.butExit.Click += new System.Windows.RoutedEventHandler(this.butExit_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.butMinimize = ((System.Windows.Controls.Button)(target));
            
            #line 29 "..\..\..\Modules\EditDistanceWindow.xaml"
            this.butMinimize.Click += new System.Windows.RoutedEventHandler(this.butMinimize_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.gridMiddle = ((System.Windows.Controls.Grid)(target));
            return;
            case 8:
            this.lbDocuments = ((System.Windows.Controls.ListBox)(target));
            return;
            case 9:
            this.butOk = ((System.Windows.Controls.Button)(target));
            
            #line 59 "..\..\..\Modules\EditDistanceWindow.xaml"
            this.butOk.Click += new System.Windows.RoutedEventHandler(this.butOk_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            this.butCancel = ((System.Windows.Controls.Button)(target));
            
            #line 63 "..\..\..\Modules\EditDistanceWindow.xaml"
            this.butCancel.Click += new System.Windows.RoutedEventHandler(this.butCancel_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}