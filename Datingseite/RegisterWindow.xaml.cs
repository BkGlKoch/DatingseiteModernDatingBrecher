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
    /// Interaktionslogik für RegisterWindow.xaml
    /// </summary>
    public partial class RegisterWindow : Window
    {
        public RegisterWindow()
        {
            InitializeComponent();
        }

        private void backToLoginButton_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow loginWindow = new LoginWindow();
            loginWindow.Show();
            this.Close();
        }

        private void registerButton_Click(object sender, RoutedEventArgs e)
        {
            MySqlConnection mySqlCon = new MySqlConnection(GlobaleVariabeln.globalMySqlConnection);

            string query = "SELECT * FROM user WHERE username = '" + textboxUsername.Text.Trim() + "'";

            MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(query, GlobaleVariabeln.globalMySqlConnection);
            DataTable dt = new DataTable();
            mySqlDataAdapter.Fill(dt);

            DateTime today = DateTime.Today.AddYears(-18);

            double result = DateTime.Compare(today, birthdayDatePicker.SelectedDate.Value);

           if (dt.Rows.Count == 1)
            {
                MessageBox.Show("Benutzername ist bereits vergeben!");
            }
            else if (result < 1)
            {
                MessageBox.Show("Nicht alt Genug!");
            }
           else
            {

                string formatedDateForMySql = birthdayDatePicker.SelectedDate.Value.ToString("yyyy-MM-dd HH:mm:ss");
                string testBeschreibung = "Hier steht etwas über mich.";
                query = "INSERT INTO user (`nachname`, `vorname`, `geburtsdatum`, `geschlecht`, `beschreibung`, `username`, `password`) VALUES ('" + textboxNachname.Text + "','" + textboxVorname.Text + "','" + formatedDateForMySql + "','" + genderPicker.SelectionBoxItem.ToString()+ "','" + testBeschreibung + "','" + textboxUsername.Text + "','" + passwordBox.Password + "');";

                MySqlCommand sqlCommand = new MySqlCommand(query, mySqlCon);

                mySqlCon.Open();
                sqlCommand.ExecuteNonQuery();

                query = "SELECT idUser FROM user WHERE username ='" + textboxUsername.Text + "'";

                mySqlDataAdapter = new MySqlDataAdapter(query, GlobaleVariabeln.globalMySqlConnection);
                dt = new DataTable();

                mySqlDataAdapter.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    GlobaleVariabeln.userid = Convert.ToInt32(dt.Rows[0].ItemArray[0]);
                    GlobaleVariabeln.username = textboxUsername.Text;
                    GlobaleVariabeln.name = textboxNachname.Text;
                    GlobaleVariabeln.firstname = textboxVorname.Text;
                    GlobaleVariabeln.birthday = birthdayDatePicker.Text;
                    GlobaleVariabeln.gender = genderPicker.Text;
                    GlobaleVariabeln.description = testBeschreibung;

                    MainWindow mainWindow = new MainWindow();
                    mainWindow.Show();
                    this.Close();
                }
            }
            
        }
    }
}
