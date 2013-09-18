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
using Plateso2;
using Plateso2.Modules;
using Plateso2.Modules.EditDistance;

namespace Plateso2.Modules
{
    /// <summary>
    /// Interaction logic for EditDistanceWindow.xaml
    /// </summary>
    public partial class EditDistanceWindow : Window
    {
        List<DocumentClass> listDocs;
        Dictionary<string, Plateso2.Modules.DocumentClass> dicDocuments;
        List<DocumentClass> listSelectedDocs;

        public EditDistanceWindow(List<DocumentClass> listDocs,Dictionary<string,DocumentClass> dicDocuments)
        {
            InitializeComponent();
            this.listDocs = listDocs;
            this.dicDocuments = dicDocuments;
            listSelectedDocs = new List<DocumentClass>();
            FillListBox();
        }

        #region WindowStateEvents
        
        private void butCancel_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }

        private void butOk_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (lbDocuments.SelectedItems.Count == 0) throw new Exception("Select documents !");
                foreach (MyLbItem item in lbDocuments.SelectedItems)
                {
                    listSelectedDocs.Add(dicDocuments[item.HeaderText]);
                }
                this.DialogResult = true;
            }
            catch (Exception exc)
            {
                Message.Show("Error !", exc.Message);
            }
        }

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

        void FillListBox()
        {
            foreach (DocumentClass doc in listDocs)
            {
                MyLbItem item = new MyLbItem(doc.Title);
                lbDocuments.Items.Add(item);
            }
        }

        public List<DocumentClass> SelectedDocuments
        {
            get { return this.listSelectedDocs; }
        }

    }
}
