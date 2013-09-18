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
using MySql.Data.MySqlClient;

namespace Plateso2.Modules
{
    /// <summary>
    /// Interaction logic for DeleteUserWindow.xaml
    /// </summary>
    public partial class DeleteUserWindow : Window
    {
        public DeleteUserWindow()
        {
            InitializeComponent();
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

        private void buttonDeleteUser_Click(object sender, RoutedEventArgs e)
        {
            if (tbUsername.Text.Length == 0 || tbPassword.Password.Length == 0)
            {
                textFooter.Text = "Insert an username and a password !";
                textFooter.Foreground = Brushes.Red;
                return;
            }

            string username = tbUsername.Text.ToLower();
            string password = tbPassword.Password;

            //protejare de SQL Injection
            foreach (char c in username)
            {
                if (!Constants.IsAllowed(c))
                {
                    textFooter.Text = "Invalid username or password !";
                    textFooter.Foreground = Brushes.Red;
                    return;
                }
            }
            foreach (char c in password)
            {
                if (!Constants.IsAllowed(c))
                {
                    textFooter.Text = "Invalid username or password !";
                    textFooter.Foreground = Brushes.Red;
                    return;
                }
            }

            try
            {
                using (MySqlConnection dbc = new MySqlConnection(Constants.ConnectionString))
                {
                    MySqlCommand command = dbc.CreateCommand();
                    MySqlDataReader reader;
                    string query = "select * from users where username='" + username + "' limit 1;";
                    dbc.Open();
                    command.CommandText = query;
                    reader = command.ExecuteReader();
                    reader.Read();

                    if (!reader.HasRows || reader["password"].ToString() != password)
                    {
                        textFooter.Text = "Invalid username or password !";
                        textFooter.Foreground = Brushes.Red;
                        return;
                    }

                    reader.Close();

                    query = "drop table " + username + ";";
                    command.CommandText = query;
                    command.ExecuteNonQuery();

                    query = "delete from users where username='" + username + "' limit 1;";
                    command.CommandText = query;
                    command.ExecuteNonQuery();

                    command.Dispose(); reader.Dispose();
                }

                this.DialogResult = true;
            }
            catch (Exception exc)
            {
                textFooter.Text = exc.Message;
                textFooter.Foreground = Brushes.Red;
            }

        }

    }
}
