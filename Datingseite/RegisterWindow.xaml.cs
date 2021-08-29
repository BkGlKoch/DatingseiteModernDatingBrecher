﻿using System;
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
                string testDatum = "2000-10-10";
                string testBeschreibung = "Hier steht etwas über mich.";
                query = "INSERT INTO user (`nachname`, `vorname`, `geburtstag`, `geschlecht`, `beschreibung`, `username`, `password`) VALUES ('" + textboxNachname.Text + "','" + textboxVorname.Text + "','" + testDatum + "','" + genderPicker.SelectionBoxItem.ToString()+ "','" + testBeschreibung + "','" + textboxUsername.Text + "','" + passwordBox.Password + "');";

                MySqlCommand sqlCommand = new MySqlCommand(query, mySqlCon);

                mySqlCon.Open();
                sqlCommand.ExecuteNonQuery();
                mySqlCon.Close();
            }
            
        }
    }
}