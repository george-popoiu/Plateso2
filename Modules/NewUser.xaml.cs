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
    /// Interaction logic for NewUser.xaml
    /// </summary>
    public partial class NewUser : Window
    {
        public NewUser()
        {
            InitializeComponent();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        private void button_exit_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }

        private void grid_top_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void button_minimize_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void button_newuser_Click(object sender, RoutedEventArgs e)
        {
            //validare
            if (textb_username.Text.Length == 0 || textb_password.Password.Length == 0 || textb_password2.Password.Length == 0)
            {
                text_bottom.Text = "All three fields most be completed !";
                text_bottom.Foreground = Brushes.Red;
                return;
            }
            if (textb_username.Text.Length > 30)
            {
                text_bottom.Text = "Your username has more than 30 characters !";
                text_bottom.Foreground = Brushes.Red;
                return;
            }
            if (textb_username.Text.Length < 3)
            {
                text_bottom.Text = "Your username has less than 3 characters !";
                text_bottom.Foreground = Brushes.Red;
                return;
            }
            if (textb_username.Text[0] >= 48 && textb_username.Text[0] <= 57)
            {
                text_bottom.Text = "Invalid username !";
                text_bottom.Foreground = Brushes.Red;
                return;
            }
            foreach (char c in textb_username.Text)
            {
                if (!Constants.IsAllowed(c))
                {
                    text_bottom.Text = "Invalid username !";
                    text_bottom.Foreground = Brushes.Red;
                    return;
                }
            }
            if (textb_password.Password != textb_password2.Password)
            {
                text_bottom.Text = "Passwords must be the same !";
                text_bottom.Foreground = Brushes.Red;
                return;
            }
            if (textb_password.Password.Length > 30)
            {
                text_bottom.Text = "Your password has more than 30 characters !";
                text_bottom.Foreground = Brushes.Red;
                return;
            }
            if (textb_password.Password.Length < 3)
            {
                text_bottom.Text = "Your password has less than 3 characters !";
                text_bottom.Foreground = Brushes.Red;
                return;
            }
            foreach (char c in textb_password.Password)
            {
                if (!Constants.IsAllowed(c))
                {
                    text_bottom.Text = "Invalid password !";
                    text_bottom.Foreground = Brushes.Red;
                    return;
                }
            }                        


            //s-a trecut de validare => executare query
            string username = textb_username.Text.ToLower();
            string password = textb_password.Password;
            MySqlConnection dbc;
            string connstr = "SERVER="+Constants.DbHost+"; DATABASE="+Constants.DbName+"; UID="+Constants.DbUsername+"; PASSWORD="+Constants.DbPassword+";";

            try
            {
                using (dbc = new MySqlConnection(connstr))
                {
                    MySqlCommand command = dbc.CreateCommand();
                    MySqlDataReader reader;

                    string query = "SELECT * FROM users WHERE username='" + username + "';";
                    command.CommandText = query;
                    dbc.Open();
                    reader = command.ExecuteReader();                    
                    if (reader.HasRows)
                    {
                        text_bottom.Text = "There is a user with the same name. Please choose another username.";
                        text_bottom.Foreground = Brushes.Red;
                        return;
                    }                    
                    reader.Close();

                    query = "INSERT INTO users(username,password) VALUES('" + username + "','" + password + "');";                    
                    command.CommandText = query;
                    reader = command.ExecuteReader();
                    reader.Close();

                    query = "CREATE TABLE " + username + "(title text, text longtext, ctext longtext, extension varchar(10) not null, id int primary key not null auto_increment );";
                    command.CommandText = query;
                    reader=command.ExecuteReader();
                    reader.Close();

                    this.DialogResult = true;

                    reader.Dispose();
                    command.Dispose();
                }                
                dbc.Dispose();
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
