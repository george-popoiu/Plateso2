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
    /// Interaction logic for DeleteWindow.xaml
    /// </summary>
    public partial class DeleteWindow : Window
    {
        List<string> listDocuments, listResults;
        List<string> listDocumentsToDelete, listResultsToDelete;

        public DeleteWindow(List<string> listDocuments, List<string> listResults)
        {
            InitializeComponent();
            this.listDocuments = listDocuments;
            this.listResults = listResults;

            listResultsToDelete = new List<string>();
            listDocumentsToDelete = new List<string>();

            foreach (string s in listDocuments)
            {
                MyLbItem item = new MyLbItem(s);
                lbDocuments.Items.Add(item);
            }
            foreach (string s in listResults)
            {
                MyLbItem item = new MyLbItem(s);
                lbResults.Items.Add(item);
            }
        }

        #region WindowState Events
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

        private void butDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (lbDocuments.SelectedItems.Count == 0 && lbResults.SelectedItems.Count == 0) 
                    throw new Exception("Select documents or results to delete !");

                foreach (MyLbItem item in lbDocuments.SelectedItems)
                {
                    listDocumentsToDelete.Add(item.HeaderText);
                }

                foreach (MyLbItem item in lbResults.SelectedItems)
                {
                    listResultsToDelete.Add(item.HeaderText);
                }

                this.DialogResult = true;
            }
            catch (Exception exc)
            {
                Message.Show("Error !", exc.Message);
            }
        }

        public List<string> DocumentsToDelete
        {
            get { return this.listDocumentsToDelete; }
        }

        public List<string> ResultsDoDelete
        {
            get { return this.listResultsToDelete; }
        }

    }
}
