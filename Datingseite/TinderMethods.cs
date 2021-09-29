using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Datingseite
{
    class TinderMethods
    {
        static string query;

        public static ArrayList allmatchids = new ArrayList();

        public static string tinderFullName = "";
        public static string tinderUserName = "";
        public static string tinderFirstName = "";
        public static string tinderName = "";
        public static string tinderBirthday = "";
        public static string tinderDescription = "";
        public static string tinderGender = "";
        public static int tinderIdUser;


        public static string matchesFullName = "";
        public static string matchesUserName = "";
        public static string matchesFirstName = "";
        public static string matchesName = "";
        public static string matchesBirthday = "";
        public static string matchesDescription = "";
        public static string matchesGender = "";

        static int iterator = 1;
        static Boolean nextTinderPossible = true;

        static MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(query, GlobaleVariabeln.globalMySqlConnection);
        static MySqlConnection mysqlcon = new MySqlConnection(GlobaleVariabeln.globalMySqlConnection);

        public static void getNewTinder()
        {
            if(iterator == GetIndexLong())
            {
                nextTinderPossible = false;
            }

            if (iterator != GlobaleVariabeln.userid && iterator != GetIndexLong())
            {
                query = "SELECT * FROM user WHERE idUser = '" + iterator + "'";
                iterator++;
           

            }
            else
            {
                iterator = iterator + 1;
                getNewTinder();
         
            }

            mySqlDataAdapter = new MySqlDataAdapter(query, GlobaleVariabeln.globalMySqlConnection);

            DataTable dt = new DataTable();

            mySqlDataAdapter.Fill(dt);

            try
            {
                tinderUserName = dt.Rows[0].ItemArray[6].ToString();
                tinderFirstName = dt.Rows[0].ItemArray[2].ToString();
                tinderName = dt.Rows[0].ItemArray[1].ToString();
                tinderGender = dt.Rows[0].ItemArray[4].ToString();
                tinderDescription = dt.Rows[0].ItemArray[5].ToString();
                tinderBirthday = dt.Rows[0].ItemArray[3].ToString();
                tinderFullName = tinderFirstName + " " + tinderName;
                tinderIdUser = Convert.ToInt32(dt.Rows[0].ItemArray[0]);

            
            }
            catch
            {

                iterator++;
                nextTinderPossible = false;
            }


        }

        public static void getUserDataFromUserId(int userid)
        {
            query = "SELECT * FROM user WHERE idUser = '" + userid + "'";

            mySqlDataAdapter = new MySqlDataAdapter(query, GlobaleVariabeln.globalMySqlConnection);

            DataTable dt = new DataTable();

            mySqlDataAdapter.Fill(dt);

            if(dt.Rows.Count > 0)
            {
                matchesUserName = dt.Rows[0].ItemArray[6].ToString();
                matchesFirstName = dt.Rows[0].ItemArray[2].ToString();
                matchesName = dt.Rows[0].ItemArray[1].ToString();
                matchesGender = dt.Rows[0].ItemArray[4].ToString();
                matchesDescription = dt.Rows[0].ItemArray[5].ToString();
                matchesBirthday = dt.Rows[0].ItemArray[3].ToString();
                matchesFullName = matchesFirstName + " " + matchesName;
            }
            else
            {
               
            }
        }

        public static Boolean isNextTinderPossible()
        {
            return nextTinderPossible;
        }


        public static void saveInterator(int newIterator)
        {
            query = "UPDATE user SET tinders= '" + newIterator + "' WHERE username='" + GlobaleVariabeln.username + "';";

            mySqlDataAdapter = new MySqlDataAdapter(query, GlobaleVariabeln.globalMySqlConnection);

            MySqlCommand sqlCommand = new MySqlCommand(query, mysqlcon);
            mysqlcon.Open();
            sqlCommand.ExecuteNonQuery();
            mysqlcon.Close();

        }


        public static int GetIndexLong()  // Hier wird gezählt wie viele User registriert sind
        {
            using (MySqlConnection conn = new MySqlConnection(GlobaleVariabeln.globalMySqlConnection))
            {
                using (MySqlCommand cmd = new MySqlCommand("SELECT COUNT(*) FROM user", conn))
                {
                    conn.Open();
                    int value = int.Parse(cmd.ExecuteScalar().ToString());

                    conn.Close();
                    return value;
                }
            }
        }
    }
}
