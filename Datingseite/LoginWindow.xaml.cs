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
        MySqlConnection mySqlCon;
        MySqlCommand sqlCommand;
        string query;
        public LoginWindow()
        {
            InitializeComponent();

            if (!doesDatabaseExist())
            {

                mySqlCon = new MySqlConnection("server=localhost; port=3306; username=root; password=1234;");
                string query = "CREATE database modernDating; use modernDating; create table user( idUser int primary key not null auto_increment, nachname varchar(40), vorname varchar(40), geburtsdatum date, geschlecht varchar(30), beschreibung varchar(400), username varchar(20), password varchar(20) CHARACTER SET 'utf8mb4' COLLATE 'utf8mb4_0900_as_cs' );";

                sqlCommand = new MySqlCommand(query, mySqlCon);

                mySqlCon.Open();
                sqlCommand.ExecuteNonQuery();
                mySqlCon.Close();
            }
        }

        bool doesDatabaseExist()
        {
            mySqlCon = new MySqlConnection(GlobaleVariabeln.globalMySqlConnection);
            try
            {
                mySqlCon.Open();
                return true;
            }
            catch
            {
                return false;
            }
        }


        private void registerLabel_MouseDown(object sender, MouseButtonEventArgs e)
        {
            RegisterWindow registerWindow = new RegisterWindow();
            registerWindow.Show();
            this.Close();
        }

        private void loginButton_Click(object sender, RoutedEventArgs e)
        {

            mySqlCon = new MySqlConnection(GlobaleVariabeln.globalMySqlConnection); 

            query = "SELECT * FROM user WHERE username = '"+textboxUsername.Text.Trim()+"' AND password = '" + passwordBox.Password.Trim()+"'";

            MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(query, GlobaleVariabeln.globalMySqlConnection);

            DataTable dt = new DataTable();

            mySqlDataAdapter.Fill(dt);


            if (dt.Rows.Count == 1)
            {
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
