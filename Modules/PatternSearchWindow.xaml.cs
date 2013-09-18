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
    /// Interaction logic for PatternSearchWindow.xaml
    /// </summary>
    public partial class PatternSearchWindow : Window
    {
        Dictionary<string, DocumentClass> dicDocuments;
        List<DocumentClass> listDocsToSearch;

        public PatternSearchWindow(Dictionary<string,DocumentClass> dicDocuments)
        {
            InitializeComponent();
            this.dicDocuments = dicDocuments;
            listDocsToSearch = new List<DocumentClass>();
        }

        #region Window state events
        private void gridTop_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }        

        private void butExit_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }
        
        private void butMinimize_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }
        #endregion        

        private void butSearch_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (tbPattern.Text.Length == 0 || Constants.GetClearPattern(tbPattern.Text)==null) throw new Exception("Insert the pattern !");
                if (lbDocuments.SelectedItems.Count == 0) throw new Exception("Select documents !");

                foreach (MyLbItem item in lbDocuments.SelectedItems)
                {
                    listDocsToSearch.Add(dicDocuments[item.HeaderText]);
                }

                this.DialogResult = true;
            }
            catch (Exception exc)
            {
                Message.Show("Error !", exc.Message);
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            foreach (string s in dicDocuments.Keys)
            {
                MyLbItem item = new MyLbItem(s);
                lbDocuments.Items.Add(item);
            }
        }

        public List<DocumentClass> ListDocsToSearch
        {
            get { return this.listDocsToSearch; }
        }
        public string Pattern
        {
            get
            {
                if (tbPattern.Text.Length == 0) return null;
                return this.tbPattern.Text;
            }
        }
    }

    public class MyLbItem : ListBoxItem
    {
        string headerText;
        public MyLbItem(string headerText)
        {
            this.Content = headerText;
            this.headerText = headerText;
        }

        public string HeaderText
        {
            get { return this.headerText; }
            set { this.headerText = value; }
        }
    }

}
