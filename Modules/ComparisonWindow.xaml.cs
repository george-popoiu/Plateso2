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

namespace Plateso2.Modules
{
    /// <summary>
    /// Interaction logic for ComparisonWindow.xaml
    /// </summary>
    public partial class ComparisonWindow : Window
    {
        Dictionary<string, Plateso2.Modules.DocumentClass> dicDocs;
        List<DocumentClass> listDocs;
        List<DocumentClass> listToCompare;
        int limit;

        public ComparisonWindow(List<DocumentClass> listDocs,Dictionary<string,DocumentClass> dicDocs)
        {
            InitializeComponent();
            listToCompare = new List<DocumentClass>(); 
            this.listDocs = listDocs;
            this.dicDocs = dicDocs;
            LoadListBox();
        }

        void LoadListBox()
        {
            foreach (DocumentClass doc in listDocs)
            {
                MyLbItem item = new MyLbItem(doc.Title);
                lbDocs.Items.Add(item);
            }
        }

        #region WindowStateEvents

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

        private void butCompare_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                limit = int.Parse(tbLimit.Text);
                if (limit < 0) throw new Exception("The limit must be greater than 0 !");
                if (lbDocs.SelectedItems.Count == 0) throw new Exception("You have not selected any documents !");

                foreach (MyLbItem item in lbDocs.SelectedItems)
                {
                    listToCompare.Add(dicDocs[item.HeaderText]);
                }
                this.DialogResult = true;
            }
            catch (Exception exc)
            {
                Message.Show("Error !", exc.Message);
            }
        }

        public List<DocumentClass> ListToCompare
        {
            get { return listToCompare; }
        }
        public int Limit
        {
            get { return limit; }
        }
    }
}
