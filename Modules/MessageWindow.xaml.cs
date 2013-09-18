﻿using System;
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
    /// Interaction logic for MessageWindow.xaml
    /// </summary>
    public partial class MessageWindow : Window
    {
        public MessageWindow()
        {
            InitializeComponent();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        public void Show(string caption,string message)
        {
            Caption.Text = null;
            Caption.Text = caption;
            text.Text = null;
            text.Text = message;
            this.ShowDialog();            
        }

        private void OK_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;            
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void OK_MouseEnter(object sender, MouseEventArgs e)
        {
            
        }

        private void OK_MouseLeave(object sender, MouseEventArgs e)
        {

        }

    }
}
