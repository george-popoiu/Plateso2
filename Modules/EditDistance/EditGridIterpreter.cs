using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Documents;
using System.Xml;

namespace Plateso2.Modules.EditDistance
{
    public class EditGridIterpreter : Grid
    {
        #region Variables

        EditTestResult result;
        Window1 host;
        
        TextBlock tbTitle;
        TreeView tvHost;
        Button butSave;        

        #endregion

        #region Constructor

        public EditGridIterpreter(EditTestResult result, Window1 host)
        {
            this.result = result;
            this.host = host;
            this.Background = (Brush)(App.Current.TryFindResource("TopBorderBrush"));            

            //title
            tbTitle = new TextBlock();
            tbTitle.FontSize = 20;
            tbTitle.Text = "Edit distance";
            tbTitle.VerticalAlignment = VerticalAlignment.Center;
            tbTitle.HorizontalAlignment = HorizontalAlignment.Center;

            //treeview
            tvHost = new TreeView();            

            //button
            butSave = new Button();
            butSave.Width = 80;
            butSave.Content = "Save";
            butSave.VerticalAlignment = VerticalAlignment.Center;
            butSave.HorizontalAlignment = HorizontalAlignment.Center;
            butSave.Click += new RoutedEventHandler(butSave_Click);
            butSave.Style = (Style)(App.Current.TryFindResource("button_common"));

            MakeLayout();
            FillTreeView();
            AddControls();
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
            tbTitle.SetValue(Grid.ColumnProperty, 1);
            tbTitle.SetValue(Grid.RowProperty, 0);

            tvHost.SetValue(Grid.ColumnProperty, 1);
            tvHost.SetValue(Grid.RowProperty, 1);            

            butSave.SetValue(Grid.ColumnProperty, 1);
            butSave.SetValue(Grid.RowProperty, 2);

            this.Children.Add(tbTitle);
            this.Children.Add(tvHost);
            this.Children.Add(butSave);
        }

        void FillTreeView()
        {
            foreach (DocData docData in result.DicEdit.Keys)
            {
                TextBlock tbHeaderText = new TextBlock();
                tbHeaderText.Text = docData.Title;
                TextBlock tbFooterText = new TextBlock();
                tbFooterText.Text = "Length : " + docData.Length.ToString();

                TVIInterpreter item = new TVIInterpreter(tbHeaderText, tbFooterText, docData);

                foreach (EditData editData in result.DicEdit[docData])
                {
                    TextBlock tbHeader = new TextBlock();
                    tbHeader.Text = editData.Title;
                    TextBlock tbFooter = new TextBlock();
                    Run run1 = new Run("Length : " + editData.Length.ToString() + " ");
                    Run run2 = new Run("Edit distance : " + editData.EditDistance.ToString());
                    run2.Foreground = Brushes.Red;
                    tbFooter.Inlines.Add(run1); tbFooter.Inlines.Add(run2);

                    TVIInterpreter item2 = new TVIInterpreter(tbHeader, tbFooter, editData);
                    item.Items.Add(item2);
                }

                tvHost.Items.Add(item);
            }
        }

        void SaveResult(EditTestResult result)
        {
            try
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(Constants.ResultsXmlPath);

                XmlElement xmlResult = xmlDoc.CreateElement("Result");
                xmlResult.SetAttribute("TestType", result.TestType.ToString());
                xmlResult.SetAttribute("TestName", result.TestName);
                xmlResult.SetAttribute("Username", host.Username);

                foreach (DocData docData in result.DicEdit.Keys)
                {
                    XmlElement xmlDocData = xmlDoc.CreateElement("Document");
                    xmlDocData.SetAttribute("Title", docData.Title);
                    xmlDocData.SetAttribute("Id", docData.Id.ToString());
                    xmlDocData.SetAttribute("Length", docData.Length.ToString());

                    foreach(EditData editData in result.DicEdit[docData])
                    {
                        XmlElement xmlEditData = xmlDoc.CreateElement("EditData");
                        xmlEditData.SetAttribute("Title", editData.Title);
                        xmlEditData.SetAttribute("Id", editData.Id.ToString());
                        xmlEditData.SetAttribute("Length", editData.Length.ToString());
                        xmlEditData.SetAttribute("EditDistance", editData.EditDistance.ToString());

                        xmlDocData.AppendChild(xmlEditData);
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

        #endregion

        #region Events

        void butSave_Click(object sender, RoutedEventArgs e)
        {
            WindowSave save = new WindowSave(host.DicResults);
            if (save.ShowDialog() == true)
            {
                result.TestName = save.ResultName;
                SaveResult(result);
            }
            save = null;
        }

        #endregion

        #region Properties

        public EditTestResult TestResult
        {
            get { return result; }
        }

        #endregion

    }
}
