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
    /// Interaction logic for ChangePassword.xaml
    /// </summary>
    public partial class ChangePassword : Window
    {
        public ChangePassword()
        {
            InitializeComponent();
        }

        private void grid_top_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void button_exit_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }

        private void button_minimize_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void button_changepassword_Click(object sender, RoutedEventArgs e)
        {
            if (tbUsername.Text.Length == 0 || tbOldPassword.Password.Length == 0 || tbNewPassword.Password.Length == 0 || tbNewPassword2.Password.Length == 0)
            {
                text_bottom.Text = "You must complete all fields !";
                text_bottom.Foreground = Brushes.Red;
                return;
            }
            foreach (char c in tbUsername.Text)
            {
                if (!Constants.IsAllowed(c))
                {
                    text_bottom.Text = "Invalid username or password !";
                    text_bottom.Foreground = Brushes.Red;
                    return;                    
                }
            }
            foreach (char c in tbOldPassword.Password)
            {
                if (!Constants.IsAllowed(c))
                {
                    text_bottom.Text = "Invalid username or password !";
                    text_bottom.Foreground = Brushes.Red;
                    return;
                }
            }
            if ((tbNewPassword.Password != tbNewPassword2.Password) || (tbNewPassword.Password.Length < 3) || (tbNewPassword2.Password.Length < 3))
            {
                text_bottom.Text = "Invalid username or password !";
                text_bottom.Foreground = Brushes.Red;
                return;
            }
            foreach (char c in tbNewPassword.Password)
            {
                if (!Constants.IsAllowed(c))
                {
                    text_bottom.Text = "Invalid username or password !";
                    text_bottom.Foreground = Brushes.Red;
                    return;
                }
            }


            string connstr = "SERVER=" + Constants.DbHost + "; DATABASE=" + Constants.DbName + "; UID=" + Constants.DbUsername + "; PASSWORD=" + Constants.DbPassword + ";";

            try
            {
                using (MySqlConnection connection = new MySqlConnection(connstr))
                {
                    bool exists = false;
                    string query;
                    MySqlCommand command = connection.CreateCommand();
                    MySqlDataReader reader;

                    query = "SELECT password FROM users WHERE username='" + tbUsername.Text + "';";
                    command.CommandText = query;
                    connection.Open();
                    reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        if ((string)(reader["password"]) == tbOldPassword.Password)
                        {
                            exists = true;
                        }
                    }
                    reader.Close();

                    if (!exists)
                    {
                        text_bottom.Text = "Invalid username or password !";
                        text_bottom.Foreground = Brushes.Red;
                        return;
                    }

                    query = "UPDATE users SET password='" + tbNewPassword.Password + "' WHERE username='" + tbUsername.Text + "';";
                    command.CommandText = query;
                    reader = command.ExecuteReader();

                    reader.Close();
                    reader.Dispose();
                    command.Dispose();

                    this.DialogResult = true;
                }
            }
            catch (Exception exc)
            {
                Message.Show("Error !", exc.Message);
                text_bottom.Text = exc.Message;
                text_bottom.Foreground = Brushes.Red;
            }            
        }
    }
}
