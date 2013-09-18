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
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using MySql.Data.MySqlClient;


namespace Plateso2.Modules
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
            text_bottom.Text = "Welcome !";
        }        

        private void header_Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void button_close_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }

        private void button_minimize_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void button_login_Click(object sender, RoutedEventArgs e)
        {
            //Daca s-a introdus username-ul si parola
            if( textb_username.Text.Length == 0 || textb_password.Password.Length==0 ) 
            {
                text_bottom.Text = "Insert an username and a password !";
                text_bottom.Foreground = Brushes.Red;
                return;
            }            

            string username = textb_username.Text;
            string password = textb_password.Password;

            if (username.Length < 3 || username.Length > 30 || password.Length < 3 || password.Length > 30)
            {
                text_bottom.Text = "Your username and your password can contain between 3 and 30 characters !";
                text_bottom.Foreground = Brushes.Red;
                return;
            }

            if ( ((int)(username[0]) >= 48 && (int)(username[0]) <= 57) )
            {
                text_bottom.Text = "Invalid username or password !";
                text_bottom.Foreground = Brushes.Red;
                return;
            }

            //validare - protejare de SQL Injection
            foreach (char c in username)
            {
                if (!Constants.IsAllowed(c))
                {
                    text_bottom.Text = "Invalid username or password !";
                    text_bottom.Foreground = Brushes.Red;
                    return;
                }
            }
            foreach (char c in password)
            {
                if (!Constants.IsAllowed(c))
                {
                    text_bottom.Text = "Invalid username or password !";
                    text_bottom.Foreground = Brushes.Red;
                    return;
                }
            }

            string connstr = "SERVER=" + Constants.DbHost + ";" + "DATABASE=" + Constants.DbName + ";" + "UID=" + Constants.DbUsername + ";" + "PASSWORD=" + Constants.DbPassword + ";";
            
            //s-a trecut de validare => executare query
            try
            {
                using ( MySqlConnection dbc = new MySqlConnection(connstr) )
                {
                    bool loged = false;
                    MySqlCommand command = dbc.CreateCommand();
                    MySqlDataReader reader;
                    command.CommandText = "SELECT * FROM users WHERE username='" + username + "';";
                    dbc.Open();
                    reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        if ((string)(reader["password"]) == password)  loged = true;
                    }

                    reader.Dispose();
                    command.Dispose();

                    if (loged)
                    {
                        this.DialogResult = true;
                        return;
                    }
                    else
                    {
                        text_bottom.Text = "Invalid username or password !";
                        text_bottom.Foreground = Brushes.Red;
                        return;
                    }
                }
            }
            catch ( Exception ex )
            {
                text_bottom.Text = ex.Message;
                text_bottom.Foreground = Brushes.Red;
            }
        }

        private void button_newuser_Click(object sender, RoutedEventArgs e)
        {
            //pun blur effect pe fereastra de login
            BlurEffect blur = new BlurEffect();
            blur.Radius = 8;
            this.Effect = blur;

            //afisez formularul de creare utilizator nou
            NewUser newuser = new NewUser();
            newuser.ShowDialog();
            newuser.Close();
            newuser = null;

            this.ClearValue(EffectProperty);
            blur = null;            
        }

        public string Username
        {
            get { return this.textb_username.Text; }
        }

        public string Password
        {
            get { return this.textb_password.Password; }
        }

        private void button_changepassword_Click(object sender, RoutedEventArgs e)
        {
            BlurEffect blur = new BlurEffect();
            blur.Radius = 8;
            this.Effect = blur;
            
            ChangePassword change_password = new ChangePassword();
            change_password.ShowDialog();
            change_password.Close();
            change_password = null;

            this.ClearValue(EffectProperty);
            blur = null;
        }

        private void buttonDeleteUser_Click(object sender, RoutedEventArgs e)
        {
            BlurEffect blur = new BlurEffect();
            blur.Radius = 8;
            this.Effect = blur;

            DeleteUserWindow window = new DeleteUserWindow();
            window.ShowDialog();
            window = null;

            this.ClearValue(EffectProperty);
            blur = null;
        }
        
    }
}
