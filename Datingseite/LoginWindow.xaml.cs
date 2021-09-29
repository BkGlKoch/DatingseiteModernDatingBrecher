using System;
using System.Collections.Generic;
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
using System.Data;

namespace Datingseite
{
    /// <summary>
    /// Interaktionslogik für LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
       

        public LoginWindow()
        {
            InitializeComponent();
        }

        private void registerLabel_MouseDown(object sender, MouseButtonEventArgs e)
        { 
            RegisterWindow registerWindow = new RegisterWindow(); //Register window wird definiert 
            registerWindow.Show(); //Register window wird gezeigt
            this.Close(); //Login fenster wird geschlossen
        }

        private void loginButton_Click(object sender, RoutedEventArgs e)
        {

            MySqlConnection mySqlCon = new MySqlConnection(GlobaleVariabeln.globalMySqlConnection); //MySQl Con

            string query = "SELECT * FROM user WHERE username = '"+textboxUsername.Text.Trim()+"' AND password = '" + passwordBox.Password.Trim()+"'";

            MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(query, GlobaleVariabeln.globalMySqlConnection); //MySQl Adapter

            DataTable dt = new DataTable(); //Neuer Datatable wird erstellt 

            mySqlDataAdapter.Fill(dt); //Datatable wird befüllt


            if (dt.Rows.Count == 1) //dt.Rows[0].ItemArray[ZAHL] => Row = Reihe im Table => ItemArray = Spalte im Table
            {
                
            //Standart GVs werden befüllt
                GlobaleVariabeln.userid = Convert.ToInt32(dt.Rows[0].ItemArray[0]);
                GlobaleVariabeln.username = dt.Rows[0].ItemArray[6].ToString();
                GlobaleVariabeln.firstname = dt.Rows[0].ItemArray[2].ToString();
                GlobaleVariabeln.name = dt.Rows[0].ItemArray[1].ToString();
                GlobaleVariabeln.gender = dt.Rows[0].ItemArray[4].ToString();
                GlobaleVariabeln.description = dt.Rows[0].ItemArray[5].ToString();
                GlobaleVariabeln.birthday = dt.Rows[0].ItemArray[3].ToString();

                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                this.Close();
            }

            else
            {
                MessageBox.Show("Falscher Nutzername oder falsches Passwort!");
            }
        }

        private void loginButton_KeyDown(object sender, KeyEventArgs e)
        {

        }
    }
}
