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
    /// Interaction logic for WindowSave.xaml
    /// </summary>
    public partial class WindowSave : Window
    {
        Dictionary<string, ITestResult> dicResults;
        public WindowSave(Dictionary<string,ITestResult> dicResults)
        {
            InitializeComponent();
            this.dicResults = dicResults;
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

        private void butSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (tbName.Text.Length == 0) throw new Exception("Enter a name !");
                if (this.dicResults.ContainsKey(tbName.Text)) throw new Exception("There is already a result with the same name !");
                this.DialogResult = true;
            }
            catch (Exception exc)
            {
                Message.Show("Error !", exc.Message);
            }
        }

        public string ResultName
        {
            get { return this.tbName.Text; }
        }

    }
}
