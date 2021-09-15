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
    /// Interaktionslogik für TestseitePage1.xaml
    /// </summary>
    /// 
    //Test für das Hochladen von Bildern.+
    public partial class TestseitePage1 : Page
    {
        public TestseitePage1()
        {
            InitializeComponent();
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*";
            if (openFileDialog.ShowDialog() == true)
            {
                BitmapImage bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.UriSource = new Uri(openFileDialog.FileName);
                bitmap.EndInit();
                


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
    }
}
