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

namespace Plateso2.Modules.KMP
{
    /// <summary>
    /// Interaction logic for KMPWindowViewer.xaml
    /// </summary>
    public partial class KMPWindowViewer : Window
    {
        #region Variables
        DocData docData;
        List<int> positions;
        Dictionary<string, DocumentClass> dicDocuments;
        List<int> stextPos;
        int patternLength;
        int p = 0;
        #endregion

        #region Constructors
        public KMPWindowViewer(DocData docData,List<int> positions,Dictionary<string,DocumentClass> dicDocuments,int patternLength)
        {
            InitializeComponent();
            this.docData = docData;
            this.positions = positions;
            this.dicDocuments = dicDocuments;
            this.patternLength = patternLength;
        }
        #endregion

        #region WindowStateEvents
        private void butExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void butMinimize_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void gridTop_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
        #endregion

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {            
            if ((!dicDocuments.ContainsKey(docData.Title)) || (dicDocuments.ContainsKey(docData.Title) && docData.Id != dicDocuments[docData.Title].Id))
            {
                Message.Show("Error !", "The document was deleted !");
                this.Close();
                return;
            }
            DocumentClass document = dicDocuments[docData.Title];
            this.textbTitle.Text = document.Title;
            this.Title = document.Title;

            string stext = null;
            for (int k = 0; k < document.SplitedText.Length; k++)
            {
                if (k < document.SplitedText.Length - 1) stext += (document.SplitedText[k] + " ");
                else stext += document.SplitedText[k];
            }

            int i = 0, j = 0, t = -1;
            stextPos = new List<int>();
            while (i < positions.Count && j < stext.Length)
            {
                if (stext[j] != ' ') t++;
                if (t == positions[i])
                {
                    stextPos.Add(j);
                    i++;
                }
                j++;
            }

            TextBlock allText = ColorText(stext, this.positions, this.stextPos, this.patternLength);
            allText.TextWrapping = TextWrapping.WrapWithOverflow;            
            svTextViewer.Content = allText;
        }

        #region Inerpretor Methods
        private TextBlock ColorText(string stext, List<int> positions, List<int> stextPos, int length)
        {
            TextBlock allText = new TextBlock();

            if (positions.Count == 0)
            {
                allText.Text = stext;
                return allText;
            }
            
            foreach (int i in stextPos)
            {
                if (!(i >= p)) continue;                 
                
                Run run1 = GetInline(stext, p, i-1, RunType.Normal);
                Run run2 = GetInline(stext, p, patternLength, RunType.Match);                    
                allText.Inlines.Add(run1);
                allText.Inlines.Add(run2);
                            
            }

            if (p < stext.Length)
            {
                Run run = GetInline(stext, p, stext.Length - 1, RunType.Normal);
                allText.Inlines.Add(run);
            }

            return allText;
        }

        private Run GetInline(string stext,int start, int length, RunType runType)
        {
            Run run = new Run();                        
            string sRun = null;

            if (runType == RunType.Normal && length <= start) return run;

            if (runType == RunType.Normal)
            {
                int i = start;
                while (i <= length)
                {
                    sRun += stext[i].ToString();
                    i++;
                }
                p = length + 1;
                //MessageBox.Show(p.ToString());

                run.Text = sRun;
                return run;
            }

            int j = start, l = 0;
            while (j < stext.Length && l < length)
            {
                if (stext[j] != ' ') l++;
                sRun += stext[j].ToString();
                j++;
                p++;
            }
                       
            run.Text = sRun;
            run.Foreground = Brushes.Red;
            run.FontWeight = FontWeights.Bold;
            return run;
        }
        #endregion

        public enum RunType
        {
            Normal,
            Match,
        }

        #region ResizeEvents

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
