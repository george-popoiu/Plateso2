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

namespace Plateso2.Modules.Comparison
{
    /// <summary>
    /// Interaction logic for ComparisonWindowInterpreter.xaml
    /// </summary>
    public partial class ComparisonWindowInterpreter : Window
    {
        ComparisonData data;
        Window1 windowHost;

        public ComparisonWindowInterpreter(ComparisonData data, Window1 host)
        {
            InitializeComponent();
            
            this.data = data;
            this.windowHost = host;

            string title = data.Doc1.Title + " - " + data.Doc2.Title;
            textTitle.Text = title;
            this.Title = title;

            this.Loaded += new RoutedEventHandler(ComparisonWindowInterpreter_Loaded);
        }

        void ComparisonWindowInterpreter_Loaded(object sender, RoutedEventArgs e)
        {
            if (DocumentExists(data.Doc1))
            {
                svTextViewer1.Visibility = Visibility.Visible;
                TextBlock content = Highlight(windowHost.DicDocuments[data.Doc1.Title].SplitedText, data.ListPositions, 1);
                content.TextWrapping = TextWrapping.WrapWithOverflow;
                content.Margin = new Thickness(5);
                svTextViewer1.Content = content;
            }            

            if (DocumentExists(data.Doc2))
            {
                svTextViewer2.Visibility = Visibility.Visible;
                TextBlock content = Highlight(windowHost.DicDocuments[data.Doc2.Title].SplitedText, data.ListPositions, 2);
                content.TextWrapping = TextWrapping.WrapWithOverflow;
                content.Margin = new Thickness(5);
                svTextViewer2.Content = content;
            }            
        }

        bool DocumentExists(DocData docData)
        {
            if (!windowHost.DicDocuments.ContainsKey(docData.Title)) return false;
            else
            {
                if (windowHost.DicDocuments[docData.Title].Id != docData.Id) return false;
            }
            return true;
        }

        TextBlock Highlight(string[] words, List<PositionData> list, int docnr)
        {
            TextBlock textBlock = new TextBlock();
            Run[] inlines = new Run[words.Length];

            for (int i = 0; i < inlines.Length; i++)
            {
                inlines[i] = new Run();
                inlines[i].Text = words[i];
            }

            foreach (PositionData data in list)
            {
                int start;
                int l = 0;
                int length  = data._length;

                if (docnr == 1) start = data._start1;
                else start = data._start2;

                while (l < length)
                {                    
                    inlines[start].Foreground = Brushes.Red;
                    l++; start++;
                }
            }

            foreach (Run run in inlines)
            {
                Run val = run;
                val.Text += " ";
                textBlock.Inlines.Add(val);
            }

            return textBlock;
        }

        #region WindowStateEvents

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

        private void buttonMaximize_Click(object sender, RoutedEventArgs e)
        {
            if (this.WindowState != WindowState.Maximized) this.WindowState = WindowState.Maximized;
            else this.WindowState = WindowState.Normal;
        }

        #endregion

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
                this.Height = this.MinHeight + 2;
                topThumb.ReleaseMouseCapture();
            }
        }

        private void bottomThumb_DragDelta(object sender, System.Windows.Controls.Primitives.DragDeltaEventArgs e)
        {
            if (this.Height > this.MinHeight)
            {
                this.Height += e.VerticalChange;
            }
            else
            {
                this.Height = this.MinHeight + 2;
                bottomThumb.ReleaseMouseCapture();
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
                this.Width = this.MinWidth + 2;
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
                this.Width = this.MinWidth + 2;
                rightThumb.ReleaseMouseCapture();
            }
        }

        #endregion

    }
}
