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
using System.IO;

namespace Plateso2.Modules
{
    /// <summary>
    /// Interaction logic for DownloadWindow.xaml
    /// </summary>
    public partial class DownloadWindow : Window
    {
        List<DocumentClass> listDocuments;
        Dictionary<string, DocumentClass> dicDocuments;

        public DownloadWindow(Window1 hostWindow)
        {
            InitializeComponent();
            this.listDocuments = hostWindow.ListDocuments;
            this.dicDocuments = hostWindow.DicDocuments;
        }        

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

        private void butBrowse_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.FolderBrowserDialog dialog = new System.Windows.Forms.FolderBrowserDialog();
            
            System.Windows.Forms.DialogResult result = dialog.ShowDialog(new Win32Window(new System.Windows.Interop.WindowInteropHelper(this).Handle));

            if (result != System.Windows.Forms.DialogResult.OK) { tbLocation.Text = null; return; }

            tbLocation.Text = dialog.SelectedPath;

            dialog.Dispose();            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (tbLocation.Text.Length == 0) throw new Exception("Choose a location !");
                StreamWriter sw;
                foreach (ListBoxItem lbi in lbDocuments.SelectedItems)
                {                    
                    sw = new StreamWriter(tbLocation.Text + "\\" + lbi.Content.ToString()+".txt");
                    sw.Write(dicDocuments[lbi.Content.ToString()].Text);
                    sw.Close(); sw.Dispose();
                }
                this.Close();
                
            }
            catch (Exception exc)
            {
                Message.Show("Error !", exc.Message);
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            foreach (DocumentClass doc in listDocuments)
            {
                ListBoxItem lbi = new ListBoxItem();
                lbi.VerticalContentAlignment = VerticalAlignment.Center;
                lbi.Content = doc.Title;
                lbDocuments.Items.Add(lbi);
            }
        }        
    }

    public class Win32Window : System.Windows.Forms.IWin32Window
    {
        IntPtr _handle;
        public Win32Window(IntPtr handle)
        {
            _handle = handle;
        }

        IntPtr System.Windows.Forms.IWin32Window.Handle
        {
            get { return _handle; }
        }
    }
}
