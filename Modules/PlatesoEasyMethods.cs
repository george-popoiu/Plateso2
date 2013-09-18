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
using MySql.Data.MySqlClient;
using System.IO;
using System.Xml;
using Plateso2.Modules.KMP;
using Plateso2.Modules.EditDistance;
using Plateso2.Modules.Comparison;

namespace Plateso2
{
    public partial class Window1 : Window
    {
        #region FlushDocuments
        void FlushDocuments(TreeViewItem root, List<DocumentClass> list, Dictionary<string, DocumentClass> dic)
        {
            root.Items.Clear();
            list.Clear();
            dic.Clear();
        }
        #endregion

        #region LoadDocuments
        void LoadDocuments(TreeViewItem root, string username,List<DocumentClass> listDocuments,Dictionary<string,DocumentClass> dicDocuments)
        {
            try
            {
                FlushDocuments(root, listDocuments, dicDocuments);
                using (MySqlConnection dbc = new MySqlConnection(Constants.ConnectionString))
                {
                    string query = "SELECT * FROM " + username + ";";
                    MySqlCommand command = dbc.CreateCommand();
                    command.CommandText = query;
                    MySqlDataReader reader;
                    dbc.Open();
                    reader = command.ExecuteReader();

                    if (!reader.HasRows) return;

                    while (reader.Read())
                    {
                        DocumentClass document = new DocumentClass((string)(reader["title"]), (string)(reader["text"]), (string)(reader["extension"]), (string)(reader["ctext"]),(int)(reader["id"]));
                        listDocuments.Add(document);
                        dicDocuments.Add(document.Title.ToLower(), document);

                        TvAddDocument(tvDocuments, document);                        
                    }

                    reader.Close(); reader.Dispose();
                    command.Dispose();
                }
            }
            catch (Exception exc)
            {
                Message.Show("Error !", exc.Message);
            }
        }
        #endregion LoadDocuments

        #region Add Document into the TreeView
        void TvAddDocument(TreeViewItem root, DocumentClass document)
        {
            MyTreeViewItem item = new MyTreeViewItem(document.Title, Constants.ImageUri(document.GetDocumentType));

            ContextMenu menu = new ContextMenu();            
            MyMenuItem menuItem = new MyMenuItem(item);
            menuItem.Header = "View document in a new window";
            menuItem.Click += new RoutedEventHandler(menuItem_Click);            
            menu.Items.Add(menuItem);

            item.ContextMenu = menu;
            item.MouseDoubleClick += new MouseButtonEventHandler(item_MouseDoubleClick);
            root.Items.Add(item);
        }

        void menuItem_Click(object sender, RoutedEventArgs e)
        {
            try
            {                
                MyMenuItem item = (MyMenuItem)(sender);
                DocumentViewerWindow window = new DocumentViewerWindow(item.Host.HeaderText, dicDocuments[item.Host.HeaderText].Text);
                window.Show();
            }
            catch { }
        }

        void item_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            DocumentClass document;
            MyTreeViewItem item = (MyTreeViewItem)(sender);
            dicDocuments.TryGetValue(item.HeaderText, out document);
            
            svTextViewer.Visibility = Visibility.Visible;
            
            TextBlock content = new TextBlock();
            if (document == null) return;
            content.Text = document.Text;
            content.Margin = new Thickness(10);
            content.TextWrapping = TextWrapping.WrapWithOverflow;            

            svTextViewer.ClearValue(ScrollViewer.ContentProperty);
            svTextViewer.Content = content;
        }
        #endregion Add Document into the TreeView

        #region LoadKMPResults
        private List<int> GetPositions(string stringPositions)
        {

            List<int> list = new List<int>();
            string[] separators = new string[] { "," };
            string[] split = stringPositions.Split(separators, StringSplitOptions.RemoveEmptyEntries);
            try
            {
                foreach (string s in split)
                {
                    list.Add(int.Parse(s));
                }
            }
            catch (Exception exc)
            {
                Message.Show("Error !", exc.Message);
            }
            return list;
        }

        private void LoadKMPResult(XmlNode node)
        {
            try
            {
                string pattern = node.Attributes["Pattern"].Value;
                string testName = node.Attributes["TestName"].Value;
                Dictionary<DocData, List<int>> dicPositions = new Dictionary<DocData, List<int>>();

                foreach (XmlNode node2 in node.ChildNodes)
                {
                    int id = int.Parse(node2.Attributes["Id"].Value);
                    int length = int.Parse(node2.Attributes["Length"].Value);
                    DocData docData = new DocData(node2.Attributes["Title"].Value, id, length);
                    List<int> list = GetPositions(node2.Attributes["Positions"].Value);
                    dicPositions.Add(docData, list);
                }

                KMPTestResult result = new KMPTestResult(pattern, testName, dicPositions);
                this.dicResults.Add(result.TestName, result);
            }
            catch (Exception exc)
            {
                Message.Show("Error !", exc.Message);
            }
        }
        #endregion

        #region LoadEditDistanceResults

        void LoadEditDistanceResult(XmlNode node)
        {
            try
            {
                string testName = node.Attributes["TestName"].Value;
                Dictionary<DocData, List<EditData>> dicEdit = new Dictionary<DocData, List<EditData>>();
                
                XmlNodeList nodeList = node.ChildNodes;                

                foreach (XmlNode xmlNode in nodeList)
                {
                    string title = xmlNode.Attributes["Title"].Value;
                    int id = int.Parse(xmlNode.Attributes["Id"].Value);
                    int length = int.Parse(xmlNode.Attributes["Length"].Value);
                    
                    DocData docData = new DocData(title, id, length);
                    List<EditData> list = new List<EditData>();

                    XmlNodeList listEditData = xmlNode.ChildNodes;

                    foreach (XmlNode nodeEditData in listEditData)
                    {
                        string _title = nodeEditData.Attributes["Title"].Value;
                        int _id = int.Parse(nodeEditData.Attributes["Id"].Value);
                        int _length = int.Parse(nodeEditData.Attributes["Length"].Value);
                        int _editDistance = int.Parse(nodeEditData.Attributes["EditDistance"].Value);
                        EditData editData = new EditData(_title, _id, _length, _editDistance);
                        list.Add(editData);
                    }

                    dicEdit.Add(docData, list);
                }

                EditTestResult result = new EditTestResult(dicEdit, testName);
                this.dicResults.Add(testName, result);
            }
            catch (Exception exc)
            {
                Message.Show("Error !", exc.Message);
            }
        }    

        #endregion

        #region LoadComparisonResults

        DocData GetDocDataFromString(string stringDocData)
        {
            string[] sep = new string[] { "," };
            string[] info = stringDocData.Split(sep, StringSplitOptions.RemoveEmptyEntries);
            string title = info[0];
            int id = int.Parse(info[1]);
            int length = int.Parse(info[2]);

            return new DocData(title, id, length);
        }

        List<PositionData> GetListPositionsFromString(string stringPositions)
        {
            List<PositionData> list = new List<PositionData>();
            string[] sep = new string[] { "|" };
            string[] info = stringPositions.Split(sep, StringSplitOptions.RemoveEmptyEntries);
            
            foreach (string s in info)
            {
                string[] _sep = new string[] { "," };
                string[] _info = s.Split(_sep, StringSplitOptions.RemoveEmptyEntries);
                PositionData positionData = new PositionData(int.Parse(_info[0]), int.Parse(_info[1]), int.Parse(_info[2]));
                list.Add(positionData);
            }

            return list;
        }

        void LoadComparisonResults(XmlNode node)
        {
            try
            {
                int limit = int.Parse(node.Attributes["Limit"].Value);
                string testName = node.Attributes["TestName"].Value;
                Dictionary<DocData, List<ComparisonData>> dicComparison = new Dictionary<DocData, List<ComparisonData>>();

                foreach (XmlNode xmlDocData in node.ChildNodes)
                {
                    string title = xmlDocData.Attributes["Title"].Value;
                    int id = int.Parse(xmlDocData.Attributes["Id"].Value);
                    int length = int.Parse(xmlDocData.Attributes["Length"].Value);

                    DocData docData = new DocData(title, id, length);
                    List<ComparisonData> list = new List<ComparisonData>();

                    foreach (XmlNode xmlComparisonData in xmlDocData.ChildNodes)
                    {
                        DocData doc1 = GetDocDataFromString(xmlComparisonData.Attributes["Doc1"].Value);
                        DocData doc2 = GetDocDataFromString(xmlComparisonData.Attributes["Doc2"].Value);
                        List<PositionData> listPositions = GetListPositionsFromString(xmlComparisonData.Attributes["ListPositions"].Value);
                        ComparisonData comparisonData = new ComparisonData(doc1, doc2, listPositions);

                        list.Add(comparisonData);
                    }

                    dicComparison.Add(docData, list);
                }

                ComparisonTestResult result = new ComparisonTestResult(testName, limit, dicComparison);
                this.dicResults.Add(result.TestName, result);
            }
            catch (Exception exc)
            {
                Message.Show("Error !", exc.Message);
            }
        }

        #endregion

        #region LoadResults

        public void LoadResults()
        {
            this.dicResults.Clear();
            this.tvResults.Items.Clear();
            try
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(Constants.ResultsXmlPath);
                XmlNodeList nodeList = xmlDoc.DocumentElement.ChildNodes;

                foreach (XmlNode node in nodeList)
                {
                    if (node.Attributes["Username"].Value == this.Username)
                    {
                        if (node.Attributes["TestType"].Value == "KMP")
                        {
                            LoadKMPResult(node);
                            continue;
                        }
                        if (node.Attributes["TestType"].Value == "EditDistance")
                        {
                            LoadEditDistanceResult(node);
                            continue;
                        }
                        if (node.Attributes["TestType"].Value == "Comparison")
                        {
                            LoadComparisonResults(node);
                            continue;
                        }
                    }
                }

                foreach (string s in dicResults.Keys)
                {
                    TVIResult item = new TVIResult(s, dicResults[s].TestType);
                    item.MouseDoubleClick += new MouseButtonEventHandler(TVIResult_MouseDoubleClick);
                    tvResults.Items.Add(item);
                }
            }
            catch (Exception exc)
            {
                Message.Show("Error !", exc.Message);
            }
        }

        void TVIResult_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            TVIResult item = (TVIResult)(sender);
            if (item.TestType == TestType.KMP)
            {
                KMPGridViewer viewer = new KMPGridViewer((KMPTestResult)(dicResults[item.HeaderText]), this.dicDocuments, this);
                svTextViewer.ClearValue(ScrollViewer.ContentProperty);
                if (svTextViewer.Visibility != Visibility.Visible) svTextViewer.Visibility = Visibility.Visible;
                svTextViewer.Content = viewer;
                return;
            }
            if (item.TestType == TestType.EditDistance)
            {
                EditGridIterpreter interpreter = new EditGridIterpreter((EditTestResult)(dicResults[item.HeaderText]), this);
                svTextViewer.ClearValue(ScrollViewer.ContentProperty);
                if (svTextViewer.Visibility != Visibility.Visible) svTextViewer.Visibility = Visibility.Visible;
                svTextViewer.Content = interpreter;
                return;
            }
            if (item.TestType == TestType.Comparison)
            {
                ComparisonGridInterpreter interpreter = new ComparisonGridInterpreter((ComparisonTestResult)(dicResults[item.HeaderText]), this);
                svTextViewer.ClearValue(ScrollViewer.ContentProperty);
                if (svTextViewer.Visibility != Visibility.Visible) svTextViewer.Visibility = Visibility.Visible;
                svTextViewer.Content = interpreter;
                return;
            }
        }
        
        #endregion

    }

    public enum DocumentClassType
    {
        Txt = 0,
        Pdf = 1,
        Doc = 2,
        Docx = 3,
        Odt = 4,
        GDocs=5,
    }
}