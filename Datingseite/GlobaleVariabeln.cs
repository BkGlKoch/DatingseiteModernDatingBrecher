using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;
using System.Data;
using System.Windows.Media.Imaging;
using System.IO;

namespace Datingseite
{
    class GlobaleVariabeln
    {
        static MySqlCommand sqlCommand;

        public static string globalMySqlConnection = "server=localhost; port=3306; username=Datingseite; password=schönenabendnoch45613; database=modernDating";
        public static string username = "";
        public static string firstname = "";
        public static string name = "";
        public static string birthday = "";
        public static string description = "";
        public static string gender = "";
        public static int userid = 3;
       
        

        public static BitmapImage loadProfilBild(String username)
        {
            try //Versucht das Profilbild aus der Datenbank zu laden.
            {
                MySqlConnection mySqlCon = new MySqlConnection(GlobaleVariabeln.globalMySqlConnection);
                string query = "SELECT profilbild FROM user WHERE username ='" + username + "'";
                MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(query, GlobaleVariabeln.globalMySqlConnection);
                DataTable dt = new DataTable();
                mySqlDataAdapter.Fill(dt);

                sqlCommand = new MySqlCommand(query, mySqlCon);

                mySqlCon.Open();
                sqlCommand.ExecuteNonQuery();
                mySqlCon.Close();

                BitmapImage bitmap = new BitmapImage();

                byte[] byteArray = (byte[])dt.Rows[0].ItemArray[0];

                bitmap = convertByteArrayToBitmap(byteArray);


                return bitmap;
            }
            catch
            {
                return null;
            }

        }

        static byte[] convertBitmapImageToByteArray(BitmapImage bmpImage)
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

        static BitmapImage convertByteArrayToBitmap(Byte[] btArray)
        {
            BitmapImage bmp = new BitmapImage();
            bmp.BeginInit();
            bmp.StreamSource = new System.IO.MemoryStream(btArray);
            bmp.EndInit();
            return bmp;
        }

    }
}
