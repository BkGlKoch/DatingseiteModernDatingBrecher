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
            MySqlConnection mySqlCon = new MySqlConnection(GlobaleVariabeln.globalMySqlConnection); //MySQl con

            string query = "SELECT * FROM user WHERE username = '" + textboxUsername.Text.Trim() + "'"; //SQL befehl

            MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(query, GlobaleVariabeln.globalMySqlConnection); //Mysql Adapter
            DataTable dt = new DataTable(); // Data Tabel
            mySqlDataAdapter.Fill(dt); // Data Table wird befüllt

            DateTime today = DateTime.Today.AddYears(-18); //Geburtstagsdatum wird konvertiert

            double result = DateTime.Compare(today, birthdayDatePicker.SelectedDate.Value); // Geburtstagsdatum wird 

           if (dt.Rows.Count == 1) //Wird geschaut ob beim User in diesem "Table" eine "Reihe" erstellt ist
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

                MySqlCommand sqlCommand = new MySqlCommand(query, mySqlCon); //MySQl Command

                mySqlCon.Open(); //MySQl Con wird geöffnet
                sqlCommand.ExecuteNonQuery(); //MySQl Befehlt wird ausgeführt

                query = "SELECT idUser FROM user WHERE username ='" + textboxUsername.Text + "'"; //MySQl Query wird definiert

                mySqlDataAdapter = new MySqlDataAdapter(query, GlobaleVariabeln.globalMySqlConnection); //MySQl Adapter
                dt = new DataTable(); //MySQl Datatable wird erstellt

                mySqlDataAdapter.Fill(dt); //MySQl Datatable wird befüllt

                if (dt.Rows.Count > 0)
                {
                //GV Inhalt wird gesetzt (Beim Registiereren)
                    GlobaleVariabeln.userid = Convert.ToInt32(dt.Rows[0].ItemArray[0]);
                    GlobaleVariabeln.username = textboxUsername.Text;
                    GlobaleVariabeln.name = textboxNachname.Text;
                    GlobaleVariabeln.firstname = textboxVorname.Text;
                    GlobaleVariabeln.birthday = birthdayDatePicker.Text;
                    GlobaleVariabeln.gender = genderPicker.Text;
                    GlobaleVariabeln.description = testBeschreibung;

                    MainWindow mainWindow = new MainWindow(); //MainWindow wird definiert
                    mainWindow.Show();  //Mainwindow (Content Frame) wird geöffnet)
                    this.Close(); //Aktuelles Fenster wird geschlossen
                }
            }
            
        }
    }
}
