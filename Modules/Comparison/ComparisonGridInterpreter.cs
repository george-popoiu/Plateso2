using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Media;
using System.Windows.Controls;
using System.Windows.Input;
using Plateso2;
using Plateso2.Modules;
using System.Xml;

namespace Plateso2.Modules.Comparison
{
    public class ComparisonGridInterpreter : Grid
    {
        #region Variables
        ComparisonTestResult result;
        Window1 host;
        
        TreeView treeView;
        Button button;
        #endregion

        #region Constructor
        
        public ComparisonGridInterpreter(ComparisonTestResult result, Window1 host)
        {
            this.Background = (Brush)(App.Current.TryFindResource("TopBorderBrush"));
            this.result = result;
            this.host = host;
            
            button = new Button();
            button.Click += new RoutedEventHandler(button_Click);
            button.VerticalAlignment = VerticalAlignment.Center;
            button.HorizontalAlignment = HorizontalAlignment.Center;
            treeView = new TreeView();

            MakeLayout();
            AddControls();
            LoadTree();
        }        
        
        #endregion

        #region Events

        string GetStringFromDocData(DocData docData)
        {
            string s = null;
            s += docData.Title; s += ",";
            s += docData.Id.ToString(); s += ",";
            s += docData.Length.ToString();

            return s;
        }

        string GetPositionDataString(List<PositionData> list)
        {
            string s = null;

            for (int i = 0; i < list.Count; i++)
            {
                s += (list[i]._start1.ToString() + "," + list[i]._start2.ToString() + "," + list[i]._length.ToString());
                if (i < list.Count - 1) s += "|";
            }

            return s;
        }

        void button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                WindowSave save = new WindowSave(host.DicResults);
                if (save.ShowDialog() == false) return;
                result.TestName = save.ResultName;

                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(Constants.ResultsXmlPath);

                XmlElement xmlResult = xmlDoc.CreateElement("Result");
                xmlResult.SetAttribute("TestType", result.TestType.ToString());
                xmlResult.SetAttribute("TestName", result.TestName);
                xmlResult.SetAttribute("Username", host.Username);
                xmlResult.SetAttribute("Limit", result.Limit.ToString());

                foreach (DocData docData in result.DicComparison.Keys)
                {
                    XmlElement xmlDocData = xmlDoc.CreateElement("Document");
                    xmlDocData.SetAttribute("Id", docData.Id.ToString());
                    xmlDocData.SetAttribute("Title", docData.Title);
                    xmlDocData.SetAttribute("Length", docData.Length.ToString());

                    foreach (ComparisonData comparisonData in result.DicComparison[docData])
                    {
                        XmlElement xmlComparisonData = xmlDoc.CreateElement("ComparisonData");
                        xmlComparisonData.SetAttribute("Doc1", GetStringFromDocData(comparisonData.Doc1));
                        xmlComparisonData.SetAttribute("Doc2", GetStringFromDocData(comparisonData.Doc2));
                        xmlComparisonData.SetAttribute("Matches", comparisonData.Matches.ToString());
                        xmlComparisonData.SetAttribute("ListPositions", GetPositionDataString(comparisonData.ListPositions));

                        xmlDocData.AppendChild(xmlComparisonData);
                    }

                    xmlResult.AppendChild(xmlDocData);
                }

                xmlDoc.DocumentElement.AppendChild(xmlResult);
                xmlDoc.Save(Constants.ResultsXmlPath);
                host.LoadResults();
            }
            catch (Exception exc)
            {
                Message.Show("Error !", exc.Message);
            }
        }

        void item2_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {            
            TVIComparison item = (TVIComparison)(sender);
            ComparisonWindowInterpreter window = new ComparisonWindowInterpreter(item.ComparisonData, this.host);
            window.Show();
        }

        #endregion

        #region Methods

        void MakeLayout()
        {
            AddColumns();
            AddRows();
        }

        void AddColumns()
        {
            ColumnDefinition col1 = new ColumnDefinition();
            col1.Width = new GridLength(0.15, GridUnitType.Star);
            ColumnDefinition col2 = new ColumnDefinition();
            col2.Width = new GridLength(0.7, GridUnitType.Star);
            ColumnDefinition col3 = new ColumnDefinition();
            col3.Width = new GridLength(0.15, GridUnitType.Star);

            this.ColumnDefinitions.Add(col1);
            this.ColumnDefinitions.Add(col2);
            this.ColumnDefinitions.Add(col3);
        }

        void AddRows()
        {
            RowDefinition row1 = new RowDefinition();
            row1.Height = new GridLength(0.1, GridUnitType.Star);
            RowDefinition row2 = new RowDefinition();
            row2.Height = new GridLength(0.8, GridUnitType.Star);
            RowDefinition row3 = new RowDefinition();
            row3.Height = new GridLength(0.1, GridUnitType.Star);

            this.RowDefinitions.Add(row1);
            this.RowDefinitions.Add(row2);
            this.RowDefinitions.Add(row3);
        }

        void AddControls()
        {
            //Row 1
            TextBlock txt1 = new TextBlock();
            txt1.Text = "Report duplicate chunks larger than : "+result.Limit.ToString();
            txt1.VerticalAlignment = VerticalAlignment.Center;
            txt1.HorizontalAlignment = HorizontalAlignment.Center;
            txt1.SetValue(Grid.RowProperty, 0); txt1.SetValue(Grid.ColumnProperty, 1);
            this.Children.Add(txt1);

            //row2
            treeView.Margin = new Thickness(10,0,10,0);
            treeView.SetValue(Grid.RowProperty, 1); treeView.SetValue(Grid.ColumnProperty, 1);
            this.Children.Add(treeView);

            //row3
            button.Content = "Save";
            button.Width = 80;
            button.Style = (Style)(App.Current.TryFindResource("button_common"));
            button.SetValue(Grid.RowProperty, 2); button.SetValue(Grid.ColumnProperty,1);
            this.Children.Add(button);
        }

        void LoadTree()
        {
            foreach (DocData docData in result.ListDocs)
            {
                TextBlock headerText = new TextBlock();
                headerText.Text = docData.Title;
                TVIComparison item = new TVIComparison(headerText, null);
                
                foreach (ComparisonData data in result.DicComparison[docData])
                {
                    TextBlock header = new TextBlock();
                    if (data.Doc1.Title == docData.Title) header.Text = data.Doc2.Title;
                    else header.Text = data.Doc1.Title;
                    TextBlock footer = new TextBlock();
                    footer.Text = "Mathces : " + data.Matches.ToString();
                    footer.Foreground = Brushes.Red;
                    footer.FontSize = 10;

                    TVIComparison item2 = new TVIComparison(header, footer, data);
                    item2.MouseDoubleClick += new MouseButtonEventHandler(item2_MouseDoubleClick);
                    item.Items.Add(item2);
                }

                treeView.Items.Add(item);
            }
        }        

        #endregion

        #region Properties
        public ComparisonTestResult Result
        {
            get { return result; }
        }
        public Window1 WindowHost
        {
            get { return host; }
        }
        #endregion
    }

    public class TVIComparison : TreeViewItem
    {
        #region Variables

        TextBlock headerText, footerText;
        Cursor cursor;
        FontWeight fontWeight;
        
        ComparisonData comparisonData;
        bool hasComparisonData = false;

        #endregion

        #region Constructors

        public TVIComparison(TextBlock headerText, TextBlock footerText)
        {
            this.headerText = headerText;
            this.footerText = footerText;
            if (this.footerText != null) this.footerText.Margin = new Thickness(2);

            StackPanel stack = new StackPanel();
            stack.Children.Add(this.headerText);
            if (this.footerText != null) stack.Children.Add(this.footerText);
            this.Header = stack;
            
            this.MouseEnter += new System.Windows.Input.MouseEventHandler(TVIComparison_MouseEnter);
            this.MouseLeave += new System.Windows.Input.MouseEventHandler(TVIComparison_MouseLeave);
        }
        
        public TVIComparison(TextBlock headerText, TextBlock footerText, ComparisonData comparisonData)
        {
            this.headerText = headerText;
            this.footerText = footerText;
            this.comparisonData = comparisonData;
            hasComparisonData = true;
            this.footerText.Margin = new Thickness(2);

            StackPanel stack = new StackPanel();
            stack.Children.Add(this.headerText);
            stack.Children.Add(this.footerText);
            this.Header = stack;
            
            this.MouseEnter += new System.Windows.Input.MouseEventHandler(TVIComparison_MouseEnter);
            this.MouseLeave += new System.Windows.Input.MouseEventHandler(TVIComparison_MouseLeave);
        }

        #endregion

        #region Events        

        void TVIComparison_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            this.Cursor = cursor;
            headerText.FontWeight = fontWeight;
        }

        void TVIComparison_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            fontWeight = headerText.FontWeight;
            cursor = this.Cursor;
            
            this.Cursor = Cursors.Hand;
            headerText.FontWeight = FontWeights.Bold;
        }

        #endregion

        #region Properties

        public ComparisonData ComparisonData
        {
            get
            {                
                return comparisonData;
            }
        }
        public TextBlock HeaderText
        {
            get { return headerText; }
            set { headerText = value; }
        }
        public TextBlock FooterText
        {
            get { return footerText; }
            set { footerText = value; }
        }

        #endregion
    }
}
