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
        static string query;

        public static string tinderFullName = "";
        public static string tinderUserName = "";
        public static string tinderFirstName = "";
        public static string tinderName = "";
        public static string tinderBirthday = "";
        public static string tinderDescription = "";
        public static string tinderGender = "";
        public static int tinderIdUser;

        static int iterator = 1;
        static Boolean nextTinderPossible = true;


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
                iterator++;
                query = "SELECT * FROM user WHERE idUser = '" + iterator + "'";
         
            }




            MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(query, GlobaleVariabeln.globalMySqlConnection);

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

        public static Boolean isNextTinderPossible()
        {
            return nextTinderPossible;
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
                    return value + 1;
                }

            }

        }

    }
}
