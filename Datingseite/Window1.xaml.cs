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

namespace Datingseite.Pages
{
    /// <summary>
    /// Interaktionslogik für Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
            
            textboxUsername.Text = "Username: " + GlobaleVariabeln.username;
            textboxFirstName.Text = "Vorname: " + GlobaleVariabeln.firstname;
            textboxName.Text = "Name: " + GlobaleVariabeln.name;
            textboxGender.Text = "Geschlecht: " + GlobaleVariabeln.gender;
            textboxAge.Text = "Alter: " + GlobaleVariabeln.birthday;
            textboxDescription.Text = "Beschreibung: " + GlobaleVariabeln.description;
            
        }



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
                bitmap = convertByteArrayToBitmap(imageBytes);
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

        BitmapImage convertByteArrayToBitmap(Byte[] btArray)
        {
            BitmapImage bmp = new BitmapImage();
            bmp.BeginInit();
            bmp.StreamSource = new System.IO.MemoryStream(btArray);
            bmp.EndInit();
            return bmp;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            TestseitePage1 testseitePage = new TestseitePage1();
            this.Content = testseitePage;
             
        }
    }
}
