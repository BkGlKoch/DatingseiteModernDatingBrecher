using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Datingseite
{
    class TinderMethods
    {
        static Random random = new Random();
        static int maxuser;
        static int randomuser;


        MySqlConnection mySqlCon = new MySqlConnection(GlobaleVariabeln.globalMySqlConnection);
        static string query;

        public static string tinderFullName = "";
        public static string tinderUserName = "";
        public static string tinderFirstName = "";
        public static string tinderName = "";
        public static string tinderBirthday = "";
        public static string tinderDescription = "";
        public static string tinderGender = "";
        public static int tinderIdUser;


        public static void getNewTinder()
        {


            randomuser = random.Next(1, GetIndexLong() + 1);

            query = "SELECT * FROM user WHERE idUser = '" + randomuser + "'";

            MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(query, GlobaleVariabeln.globalMySqlConnection);

            DataTable dt = new DataTable();

            mySqlDataAdapter.Fill(dt);




            tinderUserName = dt.Rows[0].ItemArray[6].ToString();
            tinderFirstName = dt.Rows[0].ItemArray[2].ToString();
            tinderName = dt.Rows[0].ItemArray[1].ToString();
            tinderGender = dt.Rows[0].ItemArray[4].ToString();
            tinderDescription = dt.Rows[0].ItemArray[5].ToString();
            tinderBirthday = dt.Rows[0].ItemArray[3].ToString();
            tinderIdUser = Convert.ToInt32(dt.Rows[0].ItemArray[0]);
            tinderFullName = tinderFirstName + " " + tinderName;


        }

        public static int GetIndexLong()
        {
       
            using (MySqlConnection conn = new MySqlConnection(GlobaleVariabeln.globalMySqlConnection))
            {
                using (MySqlCommand cmd = new MySqlCommand("SELECT COUNT(*) FROM user", conn))
                {
                    conn.Open();
                    int value = int.Parse(cmd.ExecuteScalar().ToString());
                    conn.Dispose();
                    return value;
                }

            }
          
        }

    }
}
