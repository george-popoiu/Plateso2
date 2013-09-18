using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Xml;
using Plateso2;
using Plateso2.Modules;

namespace Plateso2.Modules.KMP
{
    class KMPGridViewer : Grid
    {
        #region Variables
        KMPTestResult testResult;
        Dictionary<string, DocumentClass> dicDocuments;
        Dictionary<string, ITestResult> dicResults;
        Window1 windowHost;

        //controls
        TextBox textb;
        Button butSave;
        ListBox lbDocs;
        #endregion

        #region Constructors
        public KMPGridViewer(KMPTestResult testResult,Dictionary<string,DocumentClass> dicDocuments, Window1 windowHost)
        {
            this.dicDocuments = dicDocuments;
            this.dicResults = windowHost.DicResults;
            this.testResult = testResult;
            this.windowHost = windowHost;
            this.Background = (Brush)(App.Current.TryFindResource("TopBorderBrush"));

            textb = new TextBox();
            textb.Style = (Style)(App.Current.TryFindResource("style_textb"));
            textb.Margin = new Thickness(5);
            
            butSave = new Button();            
            butSave.Content = "Save";            
            butSave.Width = 50;
            butSave.Style=(Style)(App.Current.TryFindResource("button_common"));
            butSave.Click += new RoutedEventHandler(butSave_Click);
            butSave.VerticalAlignment = VerticalAlignment.Center;
            butSave.HorizontalAlignment = HorizontalAlignment.Center;            

            lbDocs = new ListBox();
            lbDocs.Margin = new Thickness(15,10,15,10);
            
            MakeLayout();
            FillListBox();
            AddControls();
        }
        #endregion

        #region Events
        void butSave_Click(object sender, RoutedEventArgs e)
        {
            WindowSave save = new WindowSave(windowHost.DicResults);
            if (save.ShowDialog() == true)
            {
                this.testResult.TestName = save.ResultName;
                SaveResult(save.ResultName,this.testResult);
            }
            save.Close(); save = null;
        }

        void item_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            try
            {
                KMPLbItem item = (KMPLbItem)(sender);
                if (!dicDocuments.ContainsKey(item.DocumentData.Title) || (dicDocuments.ContainsKey(item.DocumentData.Title) && dicDocuments[item.DocumentData.Title].Id != item.DocumentData.Id)) throw new Exception("The document is no longer available !");
                KMPWindowViewer viewer = new KMPWindowViewer(item.DocumentData, testResult.DicPositions[item.DocumentData], this.dicDocuments, testResult.ClearPattern.Length);
                viewer.Show();
            }
            catch (Exception exc)
            {
                Message.Show("Error !", exc.Message);
            }
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
            col1.Width = new GridLength(0.25, GridUnitType.Star);

            ColumnDefinition col2 = new ColumnDefinition();
            col2.Width = new GridLength(0.5, GridUnitType.Star);

            ColumnDefinition col3 = new ColumnDefinition();
            col3.Width = new GridLength(0.25, GridUnitType.Star);

            this.ColumnDefinitions.Add(col1);
            this.ColumnDefinitions.Add(col2);
            this.ColumnDefinitions.Add(col3);
        }

        void AddRows()
        {
            RowDefinition row1 = new RowDefinition();
            row1.Height = new GridLength(0, GridUnitType.Auto);
            RowDefinition row2 = new RowDefinition();
            row2.Height = new GridLength(0.9, GridUnitType.Star);
            RowDefinition row3 = new RowDefinition();
            row3.Height = new GridLength(0.1, GridUnitType.Star);

            this.RowDefinitions.Add(row1);
            this.RowDefinitions.Add(row2);
            this.RowDefinitions.Add(row3);
        }

        void AddControls()
        {
            //Top controls
            StackPanel stack = new StackPanel();
            stack.Margin = new Thickness(10);
            TextBlock topText = new TextBlock();
            textb.Margin = new Thickness(5);
            topText.Text = "Pattern :";            
            textb.IsReadOnly = true;
            textb.AcceptsReturn = true;
            textb.AcceptsTab = true;
            textb.VerticalScrollBarVisibility = ScrollBarVisibility.Auto;
            textb.HorizontalScrollBarVisibility = ScrollBarVisibility.Auto;
            textb.MaxHeight = 150;
            textb.Text = testResult.Pattern;
            stack.Children.Add(topText); stack.Children.Add(textb);
            stack.SetValue(Grid.RowProperty, 0);
            stack.SetValue(Grid.ColumnProperty, 1);
            this.Children.Add(stack);

            //Middle controls
            lbDocs.SetValue(Grid.ColumnProperty, 1);
            lbDocs.SetValue(Grid.RowProperty, 1);
            this.Children.Add(lbDocs);

            //Bottom controls
            butSave.SetValue(Grid.RowProperty, 2);
            butSave.SetValue(Grid.ColumnProperty, 1);
            this.Children.Add(butSave);
        }

        void FillListBox()
        {
            foreach (DocData docData in testResult.DicPositions.Keys)
            {                
                string footer = "Matches : " + testResult.DicPositions[docData].Count.ToString();                

                KMPLbItem item = new KMPLbItem(docData.Title, footer, docData);
                item.MouseDoubleClick += new System.Windows.Input.MouseButtonEventHandler(item_MouseDoubleClick);
                lbDocs.Items.Add(item);
            }
        }

        string GetPositionsString(List<int> list)
        {
            string result = "";
            for (int i = 0; i < list.Count; i++)
            {
                if (i == list.Count - 1) result += list[i].ToString();
                else result += (list[i].ToString() + ",");
            }
            return result;
        }

        void SaveResult(string resultName, KMPTestResult testResult)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(Constants.ResultsXmlPath);

            XmlElement xmlResult = xmlDoc.CreateElement("Result");              
            xmlResult.SetAttribute("TestType", testResult.TestType.ToString());
            xmlResult.SetAttribute("TestName", testResult.TestName);
            xmlResult.SetAttribute("Pattern", testResult.Pattern);
            xmlResult.SetAttribute("Username", windowHost.Username);

            foreach (DocData doc in testResult.DicPositions.Keys)
            {
                XmlElement xmlDocument = xmlDoc.CreateElement("Document");
                xmlDocument.SetAttribute("Title", doc.Title);
                xmlDocument.SetAttribute("Id", doc.Id.ToString());
                xmlDocument.SetAttribute("Length", doc.Length.ToString());
                xmlDocument.SetAttribute("Matches", testResult.DicPositions[doc].Count.ToString());
                xmlDocument.SetAttribute("Positions",GetPositionsString(testResult.DicPositions[doc]));

                xmlResult.AppendChild(xmlDocument);
            }

            xmlDoc.DocumentElement.AppendChild(xmlResult);
            xmlDoc.Save(Constants.ResultsXmlPath);

            windowHost.LoadResults();
            this.dicResults = windowHost.DicResults;            
        }

        #endregion

        #region Properties
        public KMPTestResult TestResult
        {
            get { return this.testResult; }
        }
        #endregion
    }

    public class KMPLbItem : ListBoxItem
    {
        TextBlock headerText;
        TextBlock footerText;
        DocData docData;

        public KMPLbItem(string headerText, string footerText,DocData docData)
        {
            this.docData = docData;

            this.headerText = new TextBlock();
            this.headerText.Text = headerText;
            this.footerText = new TextBlock();
            this.footerText.Text = footerText;
            this.footerText.Foreground = Brushes.Red;
            this.footerText.FontSize = 10;
            this.footerText.Margin = new Thickness(2);

            StackPanel stack = new StackPanel();

            stack.Children.Add(this.headerText);
            stack.Children.Add(this.footerText);

            this.Content = stack;
        }

        public TextBlock HeaderText
        {
            get { return this.headerText; }
        }
        public TextBlock FooterText
        {
            get { return this.footerText; }
        }
        public DocData DocumentData
        {
            get { return this.docData; }
        }
    }
}
