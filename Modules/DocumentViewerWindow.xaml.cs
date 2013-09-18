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

namespace Plateso2.Modules
{
    /// <summary>
    /// Interaction logic for DocumentViewerWindow.xaml
    /// </summary>
    public partial class DocumentViewerWindow : Window
    {
        TextBlock content;

        public DocumentViewerWindow(string title, string text)
        {
            InitializeComponent();
            
            textbTitle.Text = title;
            this.Title = title;
            
            content = new TextBlock();
            content.Text = text;
            content.TextWrapping = TextWrapping.WrapWithOverflow;

            svTextViewer.ClearValue(ScrollViewer.ContentProperty);
            svTextViewer.Content = content;
        }

        private void gridTop_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void butExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void butMinimize_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void thTop_DragDelta(object sender, System.Windows.Controls.Primitives.DragDeltaEventArgs e)
        {
            if (this.Height > this.MinHeight)
            {
                this.Height -= e.VerticalChange;
                this.Top += e.VerticalChange;
            }
            else
            {
                this.Height = this.MinHeight + 2;
                thTop.ReleaseMouseCapture();
            }
        }

        private void thBottom_DragDelta(object sender, System.Windows.Controls.Primitives.DragDeltaEventArgs e)
        {
            if (this.Height > this.MinHeight)
            {
                this.Height += e.VerticalChange;
            }
            else
            {
                this.Height = this.MinHeight + 2;
                thBottom.ReleaseMouseCapture();
            }
        }

        private void thLeft_DragDelta(object sender, System.Windows.Controls.Primitives.DragDeltaEventArgs e)
        {
            if (this.Width > this.MinWidth)
            {
                this.Width -= e.HorizontalChange;
                this.Left += e.HorizontalChange;
            }
            else
            {
                this.Width = this.MinWidth + 2;
                thLeft.ReleaseMouseCapture();
            }
        }

        private void thRight_DragDelta(object sender, System.Windows.Controls.Primitives.DragDeltaEventArgs e)
        {
            if (this.Width > this.MinWidth)
            {
                this.Width += e.HorizontalChange;
            }
            else
            {
                this.Width = this.MinWidth + 2;
                thRight.ReleaseMouseCapture();
            }
        }
    }
}
