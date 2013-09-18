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
using Plateso2.Modules.KMP;
using Plateso2.Modules.EditDistance;
using Plateso2.Modules.Comparison;
using MySql.Data.MySqlClient;
using System.IO;
using System.Xml;

namespace Plateso2
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        #region Variables
        string username;
        Dictionary<string, DocumentClass> dicDocuments;
        List<DocumentClass> listDocuments;
        Dictionary<string, ITestResult> dicResults;
        #endregion

        #region Constructors
        public Window1()
        {
            InitializeComponent();
        }
        #endregion

        #region WindowLoad
        
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
            LoginWindow login = new LoginWindow();
            //nu s-a trecut de login => inchid
            if (login.ShowDialog() == false) { login.Close(); login = null; this.Close(); return; }

            //s-a trecut de login            
            this.Visibility = Visibility.Visible;
            
            username = login.Username.ToLower();            

            //iau informatii de la login window, dupa care o inchid
            login.Close();
            login = null;

            textCentral.Text += " " + username + " !";

            dicDocuments = new Dictionary<string, DocumentClass>();
            listDocuments = new List<DocumentClass>();
            dicResults = new Dictionary<string, ITestResult>();

            if (!File.Exists(Constants.ResultsXmlPath))
            {                             
                XmlDocument xmlDoc = new XmlDocument();                
                xmlDoc.InnerXml = "<?xml version=\"1.0\" encoding=\"utf-8\" ?>"+
                                    "<Results>"+
                                    "</Results>";
                xmlDoc.Save(Constants.ResultsXmlPath);
            }

            LoadDocuments(tvDocuments, username, listDocuments, dicDocuments);
            LoadResults();
            LoadPlugIns();
        }
        
        #endregion WindowLoad

        #region Upload

        public static string GetTextToAdd(string text)
        {
            string[] sep = new string[] { "'" };

            string[] arr = text.Split(sep, StringSplitOptions.None);

            string result = null;

            foreach (string s in arr) result += s;

            return result;
        }

        public static bool IsFileTypeSupported(string ext)
        {
            string s = ext.ToLower();
            if (s == "pdf" || s == "doc" || s == "txt" || s == "docx") return true;
            return false;
        }

        private void buttonUpload_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog open = new Microsoft.Win32.OpenFileDialog();
            open.Multiselect = true;
            open.DefaultExt = "txt";
            open.Filter = "Text Files (*.txt)|*.txt|PDF Files (*.pdf)|*.pdf|Microsoft Office Word Documents (*.doc,*.docx)|*.doc;*.docx";

            Nullable<bool> result = open.ShowDialog();

            if (result == false || result == null) return;            

            try
            {

                using (MySqlConnection dbc = new MySqlConnection(Constants.ConnectionString))
                {
                    string query;
                    MySqlCommand command = dbc.CreateCommand();
                    MySqlDataReader reader;

                    dbc.Open();

                    foreach (string path in open.FileNames)
                    {
                        string safeName = Constants.GetSafeName(path);

                        if (dicDocuments.ContainsKey(safeName))
                        {
                            Message.Show("Cannot Upload !", "There is already a document with the same name !");
                            continue;
                        }

                        if (!IsFileTypeSupported(Constants.GetExt(safeName))) throw new Exception("File type not supported !");

                        DocumentClass document = new DocumentClass(safeName, DocumentReader.GeneralReader(path, safeName), Constants.GetExt(safeName));
                        dicDocuments.Add(document.Title, document);
                        listDocuments.Add(document);

                        TvAddDocument(tvDocuments, document);

                        query="INSERT INTO "+username+"(title,text,ctext,extension) VALUES('"+document.Title+"','"+GetTextToAdd(document.Text)+"','"+document.ConcatenatedText+"','"+document.Extension+"');";
                        command.CommandText = query;
                        reader = command.ExecuteReader();
                        reader.Close();
                    }
                    
                    command.Dispose();
                }

                LoadDocuments(tvDocuments, username, this.listDocuments, this.dicDocuments);

            }            
            catch (Exception exc)
            {
                Message.Show("Error !", exc.Message);
            }
        }
        
        #endregion Upload        

        #region Download
        private void buttonDownload_Click(object sender, RoutedEventArgs e)
        {
            try
            {                
                DownloadWindow downloadWindow = new DownloadWindow(this);
                System.Windows.Media.Effects.BlurEffect blur = new System.Windows.Media.Effects.BlurEffect();
                blur.Radius = 8;
                this.Effect = blur;
                downloadWindow.ShowDialog();
                this.ClearValue(Window.EffectProperty);
                downloadWindow = null; blur = null;
            }
            catch (Exception exc)
            {
                Message.Show("Error !",exc.Message);
            }
        }
        #endregion

        #region Properties
        public List<DocumentClass> ListDocuments
        {
            get { return this.listDocuments; }
            set { this.listDocuments = value; }
        }
        public Dictionary<string, DocumentClass> DicDocuments
        {
            get { return this.dicDocuments; }
            set { this.dicDocuments = value; }
        }
        public Dictionary<string, ITestResult> DicResults
        {
            get { return this.dicResults; }
        }
        public string Username
        {
            get { return this.username; }
        }
        #endregion

        #region Delete

        #region Get List<string> from Dictionary keys
        
        List<string> GetListDocNames(Dictionary<string, DocumentClass> dic)
        {
            List<string> list = new List<string>();            
            foreach (string s in dic.Keys)
            {
                list.Add(s);
            }
            return list;
        }
        List<string> GetListResultNames(Dictionary<string, ITestResult> dic)
        {
            List<string> list = new List<string>();
            foreach (string s in dic.Keys)
            {
                list.Add(s);
            }
            return list;
        }

        #endregion

        #region DeleteDocuments

        void DeleteDocuments(List<string> list)
        {
            if (list.Count == 0) return;

            foreach (string s in list)
            {
                listDocuments.Remove(dicDocuments[s]);
                dicDocuments.Remove(s);
            }

            try
            {
                using (MySqlConnection dbc = new MySqlConnection(Constants.ConnectionString))
                {
                    dbc.Open();
                    MySqlCommand command = dbc.CreateCommand();
                    MySqlDataReader reader;
                    string query = null;

                    foreach (string s in list)
                    {
                        query = "delete from " + this.username + " where title='" + s + "';";
                        command.CommandText = query;
                        reader = command.ExecuteReader();
                        reader.Close();
                    }

                    reader = null; command.Dispose();
                }
            }
            catch (Exception exc)
            {
                Message.Show("Error !", exc.Message);
            }
            finally
            {
                LoadDocuments(tvDocuments, this.username, listDocuments, dicDocuments);
            }
        }

        #endregion

        #region DeleteResults

        void DeleteResults(List<string> list)
        {
            if (list.Count == 0) return;

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(Constants.ResultsXmlPath);

            List<XmlNode> listToDelete = new List<XmlNode>();

            foreach(XmlNode node in xmlDoc.DocumentElement.ChildNodes)
            {
                if (node.Attributes["Username"].Value == this.username && list.Contains(node.Attributes["TestName"].Value))
                {
                    listToDelete.Add(node);
                }
            }

            foreach (XmlNode node in listToDelete)
            {
                xmlDoc.DocumentElement.RemoveChild(node);
            }
            xmlDoc.Save(Constants.ResultsXmlPath);

            foreach (string s in list)
            {
                dicResults.Remove(s);
            }

            listToDelete = null;
            LoadResults();
        }

        #endregion

        private void buttonDelete_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Media.Effects.BlurEffect blur = new System.Windows.Media.Effects.BlurEffect();
            blur.Radius = 8;
            this.Effect = blur;
            
            DeleteWindow window = new DeleteWindow(GetListDocNames(this.dicDocuments),GetListResultNames(this.dicResults));

            if (window.ShowDialog() == false)
            {
                this.ClearValue(Window1.EffectProperty);
                blur = null; window = null;
                return;
            }

            DeleteDocuments(window.DocumentsToDelete);
            DeleteResults(window.ResultsDoDelete);

            this.ClearValue(Window1.EffectProperty);
            blur = null; window = null;            
        }
        
        #endregion

        #region GDocs
        private void butGDocs_Click(object sender, RoutedEventArgs e)
        {
            try
            {                                
                System.Windows.Media.Effects.BlurEffect blur = new System.Windows.Media.Effects.BlurEffect();
                blur.Radius = 8;
                this.Effect = blur;

                GDocsWindow gdocs = new GDocsWindow();
                if (gdocs.ShowDialog() == true)
                {
                    Dictionary<string, DocumentClass> dicToAdd = gdocs.ToAdd;
                    try
                    {
                        using (MySqlConnection dbc = new MySqlConnection(Constants.ConnectionString))
                        {
                            string query;
                            MySqlCommand command = dbc.CreateCommand();
                            MySqlDataReader reader;
                            dbc.Open();
                            foreach (string s in dicToAdd.Keys)
                            {
                                if (!dicDocuments.ContainsKey(s.ToLower()))
                                {
                                    dicDocuments.Add(s, dicToAdd[s]);
                                    listDocuments.Add(dicToAdd[s]);
                                    TvAddDocument(tvDocuments, dicToAdd[s]);

                                    query = "INSERT INTO " + username + "(title,text,ctext,extension) VALUES('" + dicToAdd[s].Title + "','" + dicToAdd[s].Text + "','" + dicToAdd[s].ConcatenatedText + "','" + dicToAdd[s].Extension + "');";
                                    command.CommandText = query;
                                    reader = command.ExecuteReader();
                                    reader.Close();
                                }
                            }
                        }
                        LoadDocuments(tvDocuments, username, this.listDocuments, this.dicDocuments);
                    }
                    catch (Exception exc)
                    {
                        Message.Show("Error !", exc.Message);
                    }
                }

                this.ClearValue(Window.EffectProperty);
                gdocs = null; blur = null;
            }
            catch (Exception exc)
            {
                Message.Show("Error !", exc.Message);
            }
        }
        #endregion

        #region PatternSearch
        private void butPatternSearch_Click(object sender, RoutedEventArgs e)
        {
            PatternSearchWindow window = new PatternSearchWindow(this.dicDocuments);
            
            System.Windows.Media.Effects.BlurEffect blur = new System.Windows.Media.Effects.BlurEffect();
            blur.Radius = 8;            
            this.Effect = blur;

            if (window.ShowDialog() == false)
            {
                window = null;
                this.ClearValue(Window.EffectProperty); blur = null;
                return;
            }
            
            KMPTester tester = new KMPTester(window.Pattern, window.ListDocsToSearch);
            string title = textblockTitle.Text;
            textblockTitle.Text += " - Searching...";
            tester.BeginTest();
            textblockTitle.Text = title;

            KMPTestResult result = new KMPTestResult(tester);
            KMPGridViewer viewer = new KMPGridViewer(result,this.dicDocuments,this);
            
            this.svTextViewer.Visibility = Visibility.Visible;
            this.svTextViewer.ClearValue(ScrollViewer.ContentProperty);
            this.svTextViewer.Content = viewer;

            window = null;
            this.ClearValue(Window.EffectProperty); blur = null;
        }
        #endregion

        #region EditDistance

        private void butEditDistance_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                System.Windows.Media.Effects.BlurEffect blur = new System.Windows.Media.Effects.BlurEffect();
                blur.Radius = 8;
                this.Effect = blur;

                EditDistanceWindow window = new EditDistanceWindow(this.listDocuments, this.dicDocuments);
                if (window.ShowDialog() == false)
                {
                    window = null;
                    this.ClearValue(Window.EffectProperty);
                    return;
                }
                List<DocumentClass> listSelectedDocs = window.SelectedDocuments;
                window = null;
                this.ClearValue(Window.EffectProperty);

                EditTester tester = new EditTester(listSelectedDocs);
                this.textblockTitle.Text = "Plateso - Plase wait ...";
                tester.BeginTest();
                this.textblockTitle.Text = "Plateso";

                EditTestResult result = new EditTestResult(tester);

                EditGridIterpreter iterpreter = new EditGridIterpreter(result, this);

                svTextViewer.Visibility = Visibility.Visible;
                svTextViewer.ClearValue(ScrollViewer.ContentProperty);                
                svTextViewer.Content = iterpreter;

                //EditData data = tester.DicEdit[listDocuments[0]][0];
                //MessageBox.Show(data.EditDistance.ToString());

            }
            catch (Exception exc)
            {
                Message.Show("Error !", exc.Message);
            }
        }

        #endregion        

        #region Comparison

        private void butComparison_Click(object sender, RoutedEventArgs e)
        {

            System.Windows.Media.Effects.BlurEffect blur = new System.Windows.Media.Effects.BlurEffect();
            blur.Radius = 8;
            this.Effect = blur;

            ComparisonWindow window = new ComparisonWindow(listDocuments, dicDocuments);
            if (window.ShowDialog() == false)
            {
                this.ClearValue(Window1.EffectProperty);
                window = null; blur = null;
                return;
            }

            ComparisonTester tester = new ComparisonTester(window.ListToCompare, window.Limit);

            this.ClearValue(Window1.EffectProperty);
            window = null; blur = null;

            this.textblockTitle.Text = "Plateso - Comparing...";
            tester.BeginTest();
            this.textblockTitle.Text = "Plateso";

            ComparisonTestResult result = new ComparisonTestResult(tester);
            ComparisonGridInterpreter grid = new ComparisonGridInterpreter(result, this);

            svTextViewer.ClearValue(ScrollViewer.ContentProperty);
            if (svTextViewer.Visibility != Visibility.Visible) svTextViewer.Visibility = Visibility.Visible;
            svTextViewer.Content = grid;
        }

        #endregion

        #region Home

        private void buttonHome_Click(object sender, RoutedEventArgs e)
        {
            svTextViewer.ClearValue(ScrollViewer.ContentProperty);
            svTextViewer.Visibility = Visibility.Hidden;
        }

        #endregion


    }
}
