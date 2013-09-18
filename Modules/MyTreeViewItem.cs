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
using Plateso2.Modules.EditDistance;

namespace Plateso2.Modules
{
    public class MyTreeViewItem : TreeViewItem
    {
        #region Variables
        string header_text;
        TextBlock txtbHeader;
        CheckBox checkbox;
        Cursor cursor;
        #endregion

        #region Constructors
        public MyTreeViewItem(string header_text, string image_uri)
        {            
            this.header_text = header_text;
            txtbHeader = new TextBlock();
            txtbHeader.Text = this.header_text;
            txtbHeader.VerticalAlignment = VerticalAlignment.Center;
            txtbHeader.Margin = new Thickness(0, 0, 2, 0);

            BitmapImage imgsource = new BitmapImage(new Uri(image_uri));
            Image image = new Image();
            image.Source = imgsource;
            image.Width = Constants.TvImageWidth;
            image.Height = Constants.TvImageHeight;
            image.Margin = new Thickness(0, 0, 2, 0);

            checkbox = new CheckBox();
            checkbox.Visibility = Visibility.Collapsed;

            StackPanel stack = new StackPanel();
            stack.Orientation = Orientation.Horizontal;
            stack.FlowDirection = FlowDirection.LeftToRight;
            stack.Children.Add(checkbox);
            stack.Children.Add(image);
            stack.Children.Add(txtbHeader);            

            this.Header = stack;

            this.MouseEnter += new MouseEventHandler(MyTreeViewItem_MouseEnter);
            this.MouseLeave += new MouseEventHandler(MyTreeViewItem_MouseLeave);
        }
        #endregion

        #region Events
        void MyTreeViewItem_MouseLeave(object sender, MouseEventArgs e)
        {
            this.Cursor = cursor;
            txtbHeader.FontWeight = FontWeights.Normal;
        }
        
        void MyTreeViewItem_MouseEnter(object sender, MouseEventArgs e)
        {
            cursor = this.Cursor;
            this.txtbHeader.FontWeight = FontWeights.Bold;
            this.Cursor = Cursors.Hand;
        }
        #endregion

        #region Properties
        public string HeaderText
        {
            get { return this.header_text; }
        }
        public bool? IsChecked
        {
            get { return this.checkbox.IsChecked; }
        }
        public bool IsCheckboxVisible
        {
            get
            {
                if (this.checkbox.Visibility == Visibility.Visible) return true;
                return false;
            }
        }
        #endregion

        #region Methods
        public void ShowCheckbox()
        {
            this.checkbox.Visibility = Visibility.Visible;
        }
        public void HideCheckbox()
        {
            this.checkbox.Visibility = Visibility.Hidden;
        }
        #endregion
    }

    public class TVIResult : TreeViewItem
    {
        #region Variables
        TestType testType;
        TextBlock headerText;
        Cursor cursor;
        #endregion

        #region Constructors
        public TVIResult(string headerText,TestType testType)
        {
            this.testType = testType;
            
            this.headerText = new TextBlock();
            this.headerText.Text = headerText;
            this.headerText.VerticalAlignment = VerticalAlignment.Center;

            BitmapImage imagesource = new BitmapImage(new Uri(Constants.GetTVResultImageUri(testType)));
            Image image = new Image();
            image.Source = imagesource;
            image.Width = Constants.TvImageWidth;
            image.Height = Constants.TvImageHeight;
            image.Margin = new Thickness(0, 0, 2, 0);

            StackPanel stack = new StackPanel();
            stack.Orientation = Orientation.Horizontal;
            stack.Children.Add(image);
            stack.Children.Add(this.headerText);
            this.Header = stack;

            this.MouseEnter += new MouseEventHandler(ResultTVItem_MouseEnter);
            this.MouseLeave += new MouseEventHandler(ResultTVItem_MouseLeave);
        }
        #endregion

        #region Handlers
        void ResultTVItem_MouseLeave(object sender, MouseEventArgs e)
        {
            this.Cursor = cursor;
            this.headerText.FontWeight = FontWeights.Normal;
        }

        void ResultTVItem_MouseEnter(object sender, MouseEventArgs e)
        {
            cursor = this.Cursor;
            headerText.FontWeight = FontWeights.Bold;
            this.Cursor = Cursors.Hand;
        }
        #endregion

        #region Properties
        public TestType TestType
        {
            get { return this.testType; }
        }
        public string HeaderText
        {
            get { return this.headerText.Text; }
        }
        #endregion
    }

    class TVIInterpreter : TreeViewItem
    {
        TextBlock tbHeaderText;
        TextBlock tbFooterText;
        IDocData docData;
        Cursor cursor;

        public TVIInterpreter(TextBlock tbHeaderText,TextBlock tbFooterText,IDocData docData)
        {
            this.docData = docData;
            this.tbHeaderText = tbHeaderText;
            this.tbFooterText = tbFooterText; tbFooterText.FontSize = 12;
            this.tbFooterText.Margin = new Thickness(2);

            StackPanel stack = new StackPanel();
            stack.Children.Add(this.tbHeaderText);
            stack.Children.Add(this.tbFooterText);

            this.Header = stack;

            this.MouseEnter += new MouseEventHandler(TVIInterpreter_MouseEnter);
            this.MouseLeave += new MouseEventHandler(TVIInterpreter_MouseLeave);
        }

        void TVIInterpreter_MouseLeave(object sender, MouseEventArgs e)
        {
            this.Cursor = this.cursor;
            tbHeaderText.FontWeight = FontWeights.Normal;
        }

        void TVIInterpreter_MouseEnter(object sender, MouseEventArgs e)
        {
            this.cursor = this.Cursor;
            this.Cursor = Cursors.Hand;
            tbHeaderText.FontWeight = FontWeights.Bold;
        }

        public IDocData DocData
        {
            get { return docData; }
        }
    }
}
