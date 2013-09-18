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
using Google.GData.Client;
using Google.GData.Documents;
using Google.GData.Extensions;
using Google.GData.Tools;
using Google.Documents;
using System.IO;
using System.Threading;

namespace Plateso2.Modules
{
    /// <summary>
    /// Interaction logic for GDocsWindow.xaml
    /// </summary>
    public partial class GDocsWindow : Window
    {        

        Dictionary<string, DocumentClass> dicToAdd;
        Dictionary<string, Document> dicGDocs;
        List<Document> listGDocs;
        DocumentsService myService = null;
        DocumentsRequest request = null;
        bool logged = false;


        public GDocsWindow()
        {
            InitializeComponent();
            myService = new DocumentsService(Constants.GDocsAppName);
            dicToAdd = new Dictionary<string, DocumentClass>();
            dicGDocs = new Dictionary<string, Document>();
            listGDocs = new List<Document>();
        }

        #region WindowState Events
        private void butExit_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
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

        #region Properties
        public Dictionary<string, DocumentClass> ToAdd
        {
            get { return this.dicToAdd; }
        }
        #endregion

        #region Download
        private void Download(DocumentsService service, DocumentsRequest request, Dictionary<string, Document> dicGDocs, List<Document> listGDocs)
        {
            RequestSettings setting = new RequestSettings(Constants.GDocsAppName, service.Credentials);
            setting.AutoPaging = true;
            setting.PageSize = 100;
            if (setting == null) return;

            request = new DocumentsRequest(setting);
            Feed<Document> entries = request.GetDocuments();
            
            foreach (Document doc in entries.Entries)
            {
                if (!dicGDocs.ContainsKey(doc.Title.ToLower())) dicGDocs.Add(doc.Title.ToLower(), doc);
                if (!listGDocs.Contains(doc)) listGDocs.Add(doc);
            }
        }
        private void FlushData(Dictionary<string, Document> dicGDocs, List<Document> listGDocs,Dictionary<string,DocumentClass> dicDocsToAdd,ListBox items)
        {
            dicGDocs.Clear();
            listGDocs.Clear();
            dicDocsToAdd.Clear();
            items.Items.Clear();
        }
        #endregion

        #region Login
        private void butLogin_Click(object sender, RoutedEventArgs e)
        {
            if (tbUsername.Text.Length == 0 || tbPassword.Password.Length == 0)
            {
                Message.Show("Try again !", "Invalid username or password !");
                return;
            }
            try
            {
                myService.setUserCredentials(tbUsername.Text, tbPassword.Password);
                FlushData(this.dicGDocs, this.listGDocs, this.dicToAdd, lbDocuments);
                Download(myService, this.request, this.dicGDocs, this.listGDocs);
                logged = true;

                LbItem item = null;
                foreach (Document doc in listGDocs)
                {
                    item = new LbItem(doc.Title);
                    lbDocuments.Items.Add(item);
                }
            }
            catch (Exception exc)
            {
                Message.Show("Error !", exc.Message);
            }
        }
        #endregion

        #region ButtonLogout
        private void butLogout_Click(object sender, RoutedEventArgs e)
        {
            tbUsername.Text = null;
            tbPassword.Password = null;
            FlushData(this.dicGDocs, this.listGDocs, this.dicToAdd, lbDocuments);
            logged = false;
        }
        #endregion

        #region ButtonDownload
        private void butDownload_Click(object sender, RoutedEventArgs e)
        {
            if (!logged)
            {
                Message.Show("Error !", "You are not logged in.");
                return;
            }
            
            RequestSettings settings = new RequestSettings(Constants.GDocsAppName, myService.Credentials);
            request = new DocumentsRequest(settings);
            
            foreach (LbItem item in lbDocuments.SelectedItems)
            {
                try
                {
                    Document doc = dicGDocs[item.DocTitle.ToLower()];                    
                    Stream stream = request.Download(doc, Document.DownloadType.txt);
                    string path = AppDomain.CurrentDomain.BaseDirectory + "\\" + Constants.GDocsTempFileName;
                    FileStream fileStream = new FileStream(path, FileMode.Create);

                    int nBytes = 2048;
                    byte[] arr = new byte[nBytes];
                    int count = 0;
                    do
                    {
                        count = stream.Read(arr, 0, nBytes);
                        fileStream.Write(arr, 0, count);
                    }
                    while (count > 0);
                    stream.Close(); stream.Dispose();
                    fileStream.Close(); fileStream.Dispose();

                    StreamReader sr = new StreamReader(path);
                    DocumentClass document = new DocumentClass(doc.Title.ToLower(), Window1.GetTextToAdd(sr.ReadToEnd()), Constants.GDocsExtension);
                    sr.Close(); sr.Dispose();
                    dicToAdd.Add(document.Title, document);

                    File.Delete(path);
                }
                catch (Exception exc)
                {
                  Message.Show("Error !", exc.Message);
                }
            }
            this.DialogResult = true;
        }
        #endregion

        #region ButtonDelete
        private void butDelete_Click(object sender, RoutedEventArgs e)
        {
            if (!logged)
            {
                Message.Show("Error !", "You are not logged in.");
                return;
            }
            try
            {
                List<LbItem> removed = new List<LbItem>();
                DocumentEntry entry;
                foreach (LbItem item in lbDocuments.SelectedItems)
                {
                    removed.Add(item);

                    Document document = dicGDocs[item.DocTitle.ToLower()];
                    dicGDocs.Remove(item.DocTitle.ToLower());
                    listGDocs.Remove(document);

                    entry = document.DocumentEntry;
                    myService.Delete(entry);
                }
                foreach (LbItem item in removed)
                {
                    lbDocuments.Items.Remove(item);
                }
                removed.Clear();
                removed = null;
            }
            catch (Exception exc)
            {
                Message.Show("Error !", exc.Message);
            }
        }
        #endregion

        #region ListBoxDrop

        private string GetGDocsName(string path)
        {
            string[] arr = path.Split('\\');
            string s = arr[arr.Length - 1];
            string result = s.Substring(0, s.Length - (s.Length - s.LastIndexOf('.')));

            return result.ToLower();
        }

        private void lbDocuments_Drop(object sender, DragEventArgs e)
        {
            if (!logged)
            {
                Message.Show("Error !", "Your are not logged in.");
                return;
            }

            string[] fileNames = (string[])(e.Data.GetData(DataFormats.FileDrop));
            foreach (string file in fileNames)
            {
                try
                {
                    string path = file.ToLower();
                    string name = GetGDocsName(path);
                    if (!dicGDocs.ContainsKey(name))
                    {
                        myService.UploadDocument(path,name);
                        dicGDocs.Add(name, new Document());
                    }
                }
                catch (Exception exc)
                {
                    Message.Show("Error !", exc.Message);
                }
            }            
        }
        #endregion

        public class LbItem : ListBoxItem
        {
            string _docTitle;
            public LbItem() { }
            public LbItem(string docTitle)
            {
                _docTitle = docTitle;
                this.Content = _docTitle;
            }
            public string DocTitle
            {
                get { return _docTitle; }
                set { _docTitle = value; }
            }
        }        

    }
}
