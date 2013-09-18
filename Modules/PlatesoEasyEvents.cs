using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Plateso2.Modules;
using MySql.Data.MySqlClient;
using System.IO;

namespace Plateso2
{
    public partial class Window1 : Window
    {
        #region WindoStateEvents
        private void gridTop_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
        private void buttonExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void buttonMinimize_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }
        private void buttonMaximize_Click(object sender, RoutedEventArgs e)
        {
            if (this.WindowState == WindowState.Normal) { this.WindowState = WindowState.Maximized; return; }
            this.WindowState = WindowState.Normal;
        }
        #endregion WindowStateEvents

        #region WindowResizeEvents
        private void topThumb_DragDelta(object sender, System.Windows.Controls.Primitives.DragDeltaEventArgs e)
        {
            if (this.Height > this.MinHeight)
            {
                this.Height -= e.VerticalChange;
                this.Top += e.VerticalChange;
            }
            else
            {
                this.Height = this.MinHeight + 5;
                topThumb.ReleaseMouseCapture();
            }
        }
        private void buttomThumb_DragDelta(object sender, System.Windows.Controls.Primitives.DragDeltaEventArgs e)
        {
            if (this.Height > this.MinHeight)
            {
                this.Height += e.VerticalChange;                
            }
            else
            {
                this.Height = this.MinHeight + 5;
                buttomThumb.ReleaseMouseCapture();
            }
        }
        private void leftThumb_DragDelta(object sender, System.Windows.Controls.Primitives.DragDeltaEventArgs e)
        {
            if (this.Width > this.MinWidth)
            {
                this.Width -= e.HorizontalChange;
                this.Left += e.HorizontalChange;
            }
            else
            {
                this.Width = this.MinWidth + 5;
                leftThumb.ReleaseMouseCapture();
            }
        }
        private void rightThumb_DragDelta(object sender, System.Windows.Controls.Primitives.DragDeltaEventArgs e)
        {
            if (this.Width > this.MinWidth)
            {
                this.Width += e.HorizontalChange;                
            }
            else
            {
                this.Width = this.MinWidth + 5;
                rightThumb.ReleaseMouseCapture();
            }
        }
        #endregion WindowResizeEvents        

    }

    public class Win32Window : System.Windows.Forms.IWin32Window
    {
        IntPtr _handle;
        public Win32Window(IntPtr handle)
        {
            _handle = handle;            
        }
        IntPtr System.Windows.Forms.IWin32Window.Handle
        {
            get { return _handle; }
        }
    }

    public class MyMenuItem : MenuItem
    {
        MyTreeViewItem _host;

        public MyMenuItem(MyTreeViewItem host)
        {
            _host = host;
        }

        public MyTreeViewItem Host
        {
            get { return _host; }
        }
    }

}