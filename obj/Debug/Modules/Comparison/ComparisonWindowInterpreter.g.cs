﻿#pragma checksum "..\..\..\..\Modules\Comparison\ComparisonWindowInterpreter.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "E50D65B8E3FD93B96EBE8A883DB4927F"
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


namespace Plateso2.Modules.Comparison {
    
    
    /// <summary>
    /// ComparisonWindowInterpreter
    /// </summary>
    public partial class ComparisonWindowInterpreter : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 5 "..\..\..\..\Modules\Comparison\ComparisonWindowInterpreter.xaml"
        internal System.Windows.Controls.Grid gridRoot;
        
        #line default
        #line hidden
        
        
        #line 9 "..\..\..\..\Modules\Comparison\ComparisonWindowInterpreter.xaml"
        internal System.Windows.Controls.Grid gridLayout;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\..\..\Modules\Comparison\ComparisonWindowInterpreter.xaml"
        internal System.Windows.Controls.Grid gridTop;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\..\..\Modules\Comparison\ComparisonWindowInterpreter.xaml"
        internal System.Windows.Controls.StackPanel stackTopButtons;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\..\..\Modules\Comparison\ComparisonWindowInterpreter.xaml"
        internal System.Windows.Controls.Button butExit;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\..\..\Modules\Comparison\ComparisonWindowInterpreter.xaml"
        internal System.Windows.Controls.Button buttonMaximize;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\..\..\Modules\Comparison\ComparisonWindowInterpreter.xaml"
        internal System.Windows.Controls.Button butMinimize;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\..\..\Modules\Comparison\ComparisonWindowInterpreter.xaml"
        internal System.Windows.Controls.TextBlock textTitle;
        
        #line default
        #line hidden
        
        
        #line 45 "..\..\..\..\Modules\Comparison\ComparisonWindowInterpreter.xaml"
        internal System.Windows.Controls.Grid gridMiddle;
        
        #line default
        #line hidden
        
        
        #line 52 "..\..\..\..\Modules\Comparison\ComparisonWindowInterpreter.xaml"
        internal System.Windows.Controls.Grid grid1;
        
        #line default
        #line hidden
        
        
        #line 54 "..\..\..\..\Modules\Comparison\ComparisonWindowInterpreter.xaml"
        internal System.Windows.Controls.ScrollViewer svTextViewer1;
        
        #line default
        #line hidden
        
        
        #line 57 "..\..\..\..\Modules\Comparison\ComparisonWindowInterpreter.xaml"
        internal System.Windows.Controls.Grid grid2;
        
        #line default
        #line hidden
        
        
        #line 59 "..\..\..\..\Modules\Comparison\ComparisonWindowInterpreter.xaml"
        internal System.Windows.Controls.ScrollViewer svTextViewer2;
        
        #line default
        #line hidden
        
        
        #line 68 "..\..\..\..\Modules\Comparison\ComparisonWindowInterpreter.xaml"
        internal System.Windows.Controls.Primitives.Thumb topThumb;
        
        #line default
        #line hidden
        
        
        #line 69 "..\..\..\..\Modules\Comparison\ComparisonWindowInterpreter.xaml"
        internal System.Windows.Controls.Primitives.Thumb bottomThumb;
        
        #line default
        #line hidden
        
        
        #line 70 "..\..\..\..\Modules\Comparison\ComparisonWindowInterpreter.xaml"
        internal System.Windows.Controls.Primitives.Thumb leftThumb;
        
        #line default
        #line hidden
        
        
        #line 71 "..\..\..\..\Modules\Comparison\ComparisonWindowInterpreter.xaml"
        internal System.Windows.Controls.Primitives.Thumb rightThumb;
        
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
            System.Uri resourceLocater = new System.Uri("/Plateso2;component/modules/comparison/comparisonwindowinterpreter.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Modules\Comparison\ComparisonWindowInterpreter.xaml"
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
            
            #line 17 "..\..\..\..\Modules\Comparison\ComparisonWindowInterpreter.xaml"
            this.gridTop.MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.gridTop_MouseLeftButtonDown);
            
            #line default
            #line hidden
            return;
            case 4:
            this.stackTopButtons = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 5:
            this.butExit = ((System.Windows.Controls.Button)(target));
            
            #line 25 "..\..\..\..\Modules\Comparison\ComparisonWindowInterpreter.xaml"
            this.butExit.Click += new System.Windows.RoutedEventHandler(this.butExit_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.buttonMaximize = ((System.Windows.Controls.Button)(target));
            
            #line 29 "..\..\..\..\Modules\Comparison\ComparisonWindowInterpreter.xaml"
            this.buttonMaximize.Click += new System.Windows.RoutedEventHandler(this.buttonMaximize_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.butMinimize = ((System.Windows.Controls.Button)(target));
            
            #line 35 "..\..\..\..\Modules\Comparison\ComparisonWindowInterpreter.xaml"
            this.butMinimize.Click += new System.Windows.RoutedEventHandler(this.butMinimize_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.textTitle = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 9:
            this.gridMiddle = ((System.Windows.Controls.Grid)(target));
            return;
            case 10:
            this.grid1 = ((System.Windows.Controls.Grid)(target));
            return;
            case 11:
            this.svTextViewer1 = ((System.Windows.Controls.ScrollViewer)(target));
            return;
            case 12:
            this.grid2 = ((System.Windows.Controls.Grid)(target));
            return;
            case 13:
            this.svTextViewer2 = ((System.Windows.Controls.ScrollViewer)(target));
            return;
            case 14:
            this.topThumb = ((System.Windows.Controls.Primitives.Thumb)(target));
            
            #line 68 "..\..\..\..\Modules\Comparison\ComparisonWindowInterpreter.xaml"
            this.topThumb.DragDelta += new System.Windows.Controls.Primitives.DragDeltaEventHandler(this.topThumb_DragDelta);
            
            #line default
            #line hidden
            return;
            case 15:
            this.bottomThumb = ((System.Windows.Controls.Primitives.Thumb)(target));
            
            #line 69 "..\..\..\..\Modules\Comparison\ComparisonWindowInterpreter.xaml"
            this.bottomThumb.DragDelta += new System.Windows.Controls.Primitives.DragDeltaEventHandler(this.bottomThumb_DragDelta);
            
            #line default
            #line hidden
            return;
            case 16:
            this.leftThumb = ((System.Windows.Controls.Primitives.Thumb)(target));
            
            #line 70 "..\..\..\..\Modules\Comparison\ComparisonWindowInterpreter.xaml"
            this.leftThumb.DragDelta += new System.Windows.Controls.Primitives.DragDeltaEventHandler(this.leftThumb_DragDelta);
            
            #line default
            #line hidden
            return;
            case 17:
            this.rightThumb = ((System.Windows.Controls.Primitives.Thumb)(target));
            
            #line 71 "..\..\..\..\Modules\Comparison\ComparisonWindowInterpreter.xaml"
            this.rightThumb.DragDelta += new System.Windows.Controls.Primitives.DragDeltaEventHandler(this.rightThumb_DragDelta);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
