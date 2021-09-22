using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Win32;
using System.IO;
using System.Drawing.Imaging;
using System.Windows.Media;
using MySql.Data.MySqlClient;
using System.Data;

namespace Datingseite.Pages
{
    /// <summary>
    /// Interaktionslogik für Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        MySqlCommand sqlCommand;
        public Window1()
        {
            InitializeComponent();

            textboxUsername.Text = "Username: " + GlobaleVariabeln.username;
            textboxFirstName.Text = "Vorname: " + GlobaleVariabeln.firstname;
            textboxName.Text = "Name: " + GlobaleVariabeln.name;
            textboxGender.Text = "Geschlecht: " + GlobaleVariabeln.gender;
            textboxAge.Text = "Alter: " + GlobaleVariabeln.birthday;
            textboxDescriptionChange.Text = GlobaleVariabeln.description;


            BitmapImage bitmap = GlobaleVariabeln.loadProfilBild(GlobaleVariabeln.username);
            profilePicture.Source = bitmap;

            BitmapImage image = new BitmapImage();

            if (bitmap == null)
            {

            }


        }

        MySqlConnection mySqlCon = new MySqlConnection(GlobaleVariabeln.globalMySqlConnection);
        static string query;



        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            this.Close();
        }

        private void Image_MouseUp(object sender, MouseButtonEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*";
            if (openFileDialog.ShowDialog() == true)
            {
                BitmapImage bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.UriSource = new Uri(openFileDialog.FileName);
                bitmap.EndInit();
                profilePicture.Source = bitmap;

                byte[] imageBytes = convertBitmapImageToByteArray(bitmap);

                string query = "UPDATE user SET profilbild= @Content WHERE username='" + GlobaleVariabeln.username + "';";
                MySqlConnection cn = new MySqlConnection(GlobaleVariabeln.globalMySqlConnection);
                MySqlCommand cmd = new MySqlCommand(query, cn);
                MySqlParameter sqlParameter = cmd.Parameters.Add("@Content", MySqlDbType.Binary);
                sqlParameter.Value = imageBytes;

                string byteArrayString = BitConverter.ToString(imageBytes);

                cn.Open();
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
        }
        byte[] convertBitmapImageToByteArray(BitmapImage bmpImage)
        {
            byte[] imageArray;
            JpegBitmapEncoder encoder = new JpegBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(bmpImage));
            using (MemoryStream ms = new MemoryStream())
            {
                encoder.Save(ms);
                imageArray = ms.ToArray();
                return imageArray;
            }
        }


        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            TestseitePage1 testseitePage = new TestseitePage1();
            this.Content = testseitePage;

        }

        private void TheGrid_OnLoaded(object sender, RoutedEventArgs e)
        {
            theGrid.Focus();
        }

        private void Grid_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Back)
            {
                Hauptmenu hauptmenu = new Hauptmenu();
                this.Close();
            }
        }


        private void Border_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void textboxDescription_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void textboxDescriptionChange_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                string beschreibung = textboxDescriptionChange.Text;
                query = "UPDATE user SET beschreibung= '" + beschreibung + "' WHERE username='" + GlobaleVariabeln.username + "';";
                GlobaleVariabeln.description = beschreibung;


                MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(query, GlobaleVariabeln.globalMySqlConnection);

                MySqlCommand sqlCommand = new MySqlCommand(query, mySqlCon);
                mySqlCon.Open();
                sqlCommand.ExecuteNonQuery();
                mySqlCon.Close();
            }
        }

        private void profilbildsetzten_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*";
            if (openFileDialog.ShowDialog() == true)
            {
                BitmapImage bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.UriSource = new Uri(openFileDialog.FileName);
                bitmap.EndInit();


                byte[] imageBytes = convertBitmapImageToByteArray(bitmap);

                string query = "UPDATE user SET profilbild= @Content WHERE username='" + GlobaleVariabeln.username + "';";
                MySqlConnection cn = new MySqlConnection(GlobaleVariabeln.globalMySqlConnection);
                MySqlCommand cmd = new MySqlCommand(query, cn);
                MySqlParameter sqlParameter = cmd.Parameters.Add("@Content", MySqlDbType.Binary);
                sqlParameter.Value = imageBytes;

                string byteArrayString = BitConverter.ToString(imageBytes);

                profilePicture.Source = bitmap;

                cn.Open();
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }


            byte[] convertBitmapImageToByteArray(BitmapImage bmpImage)
            {
                byte[] imageArray;
                JpegBitmapEncoder encoder = new JpegBitmapEncoder();
                encoder.Frames.Add(BitmapFrame.Create(bmpImage));
                using (MemoryStream ms = new MemoryStream())
                {
                    encoder.Save(ms);
                    imageArray = ms.ToArray();
                    return imageArray;
                }
            }
        }
    }
}
