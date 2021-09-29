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
        static MySqlCommand sqlCommand; //privater MySQL Command

        public static string globalMySqlConnection = "server=localhost; port=3306; username=root; password=1234; database=moderndating";
        // </- Standart MySQL Connection

     // User bezogenen Informationen (Als eingeloggter User) 
        public static string username = "";
        public static string firstname = "";
        public static string name = "";
        public static string birthday = "";
        public static string description = "";
        public static string gender = "";
        public static int userid = 0;
       
        

        public static BitmapImage loadProfilBild(String username)
        {
            try //Versucht das Profilbild aus der Datenbank zu laden.
            {
                MySqlConnection mySqlCon = new MySqlConnection(GlobaleVariabeln.globalMySqlConnection); //MySQL Connection wird 
                string query = "SELECT profilbild FROM user WHERE username ='" + username + "'"; // Query = SQL Befehl

                MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(query, GlobaleVariabeln.globalMySqlConnection); // Ist die Verbindung (Kommunikation) zwischen der DB und C#

                DataTable dt = new DataTable();
                mySqlDataAdapter.Fill(dt); // Der MySQL Adapter befüllt den DataTable

                sqlCommand = new MySqlCommand(query, mySqlCon); // SQL Command wird definiert (Befehl + DB Verbindung)

                mySqlCon.Open();  //MySQL Connection wird geöffnet
                sqlCommand.ExecuteNonQuery(); // MySQL Befehl wird ausgeführt
                mySqlCon.Close(); //MySQL Connection wird geschlossen

                BitmapImage bitmap = new BitmapImage(); // Neue Bitmap wird erstellt
                 
                byte[] byteArray = (byte[])dt.Rows[0].ItemArray[0]; // Neues ByteArray wird erstellt, in dem das Convertierte Profilbild gespeichert wird

                bitmap = convertByteArrayToBitmap(byteArray); // Bitmap bekommt den Inhalt des ByteArrays


                return bitmap; // Die Bitmap wird returnt
            }
            catch
            {
                return null;
            }

        } //Methode um Profilbild aus der DB zu laden 

        public static int getUserIdbyUsername(String username)
        {
            MySqlConnection mySqlCon = new MySqlConnection(GlobaleVariabeln.globalMySqlConnection);

            mySqlCon.Open();

            string query = "SELECT idUser FROM user WHERE username ='" + username + "'";
            MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(query, GlobaleVariabeln.globalMySqlConnection);
            DataTable dt = new DataTable();
            mySqlDataAdapter.Fill(dt);

            

            return Convert.ToInt32(dt.Rows[0].ItemArray[0]); //UserID wird aus der Datenbank gelesen

            
        }  // Returnt die Userid des eigegebenen Usernamens


        static BitmapImage convertByteArrayToBitmap(Byte[] btArray)
        {
            BitmapImage bmp = new BitmapImage(); // Neues BitmapImage wird erstellt
         
            bmp.BeginInit();      
            bmp.StreamSource = new System.IO.MemoryStream(btArray); // BitmapImage bekommt Inhalt (in Array Form)
            bmp.EndInit();
            return bmp; // BitmapImage wird returnt 
        }

    }
}
