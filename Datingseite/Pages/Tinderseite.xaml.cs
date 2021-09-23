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
using System.Windows.Navigation;
using System.Windows.Shapes;
using MySql.Data.MySqlClient;

namespace Datingseite.Pages
{
    /// <summary>
    /// Interaktionslogik für Tinderseite.xaml
    /// </summary>
    public partial class Tinderseite : Page
    {

        
    
        public Tinderseite()
        {
          
            InitializeComponent();

           if (TinderMethods.isNextTinderPossible()) { 
            TinderMethods.getNewTinder();
            updateData();
           }else

           {
                setTinderEnd();
           }


        }

        private void TheGrid_OnLoaded(object sender, RoutedEventArgs e)
        {
            theGrid.Focus();
        }

        private void Grid_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (TinderMethods.isNextTinderPossible()) { 
                
            if(e.Key == Key.A)
            {
               
                TinderMethods.getNewTinder();
                updateData();

            }
            else if(e.Key == Key.D)
            {
                TinderMethods.getNewTinder();
                updateData();
            }
            }else
            {
                setTinderEnd();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Hauptmenu hauptmenu = new Hauptmenu();
            NavigationService.Navigate(hauptmenu);
        }

        private void YesButton_Click(object sender, RoutedEventArgs e)
        {
            if (TinderMethods.isNextTinderPossible())
            {
                string query = "INSERT INTO matches (idUser1, idUser2) VALUES ('" + GlobaleVariabeln.userid + "','" + TinderMethods.tinderIdUser + "')";
                MySqlConnection mySqlCon = new MySqlConnection(GlobaleVariabeln.globalMySqlConnection);
                MySqlCommand sqlCommand = new MySqlCommand(query, mySqlCon);
                mySqlCon.Open();
                sqlCommand.ExecuteNonQuery();
                mySqlCon.Close();


                TinderMethods.getNewTinder();
                updateData();
            }else
            {
                setTinderEnd();
            }
        }

        private void NoButton_Click(object sender, RoutedEventArgs e)
        {
            if (TinderMethods.isNextTinderPossible())
            {
                TinderMethods.getNewTinder();
                updateData();
            }
            else
            {
                setTinderEnd();
            }
        }


        private void updateData()
        {

            BitmapImage bitmap = GlobaleVariabeln.loadProfilBild(TinderMethods.tinderUserName);
            profilbildbox.Source = bitmap;

            textboxName.Text = TinderMethods.tinderFullName;
            textboxAge.Text = TinderMethods.tinderBirthday;
            textboxGender.Text = TinderMethods.tinderGender;
            textboxDescription.Text = TinderMethods.tinderDescription;
        }

        private void setTinderEnd()
        {

            textboxName.Text = "Kein";
            textboxAge.Text = "Tinder";
            textboxGender.Text = "mehr";
            textboxDescription.Text = "da :(";
        }
        
    }
}
