using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Datingseite
{
    class TinderMethods
    {

        MySqlConnection mySqlCon = new MySqlConnection(GlobaleVariabeln.globalMySqlConnection);
        static string query;

        public static string tinderFullName = "";
        public static string tinderUserName = "Username";
        public static string tinderFirstName = "";
        public static string tinderName = "";
        public static string tinderBirthday = "";
        public static string tinderDescription = "";
        public static string tinderGender = "";



        public void setTinderYes(string partnerusername)
        {

            getRandomTinder();
        }

        public void setTinderNo(string partnerusername)
        {

            getRandomTinder();
        }

        public static void getRandomTinder()
        {
            getTinderData("Username");
            
            
        }

        private static void getTinderData(string username)
        {
           

            query = "SELECT * FROM user WHERE username = '" + username + "'";

            MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(query, GlobaleVariabeln.globalMySqlConnection);

            DataTable dt = new DataTable();

            mySqlDataAdapter.Fill(dt);


            
            username = dt.Rows[0].ItemArray[6].ToString();
            tinderFirstName = dt.Rows[0].ItemArray[2].ToString();
            tinderName = dt.Rows[0].ItemArray[1].ToString();
            tinderGender = dt.Rows[0].ItemArray[4].ToString();
            tinderDescription = dt.Rows[0].ItemArray[5].ToString();
            tinderBirthday = dt.Rows[0].ItemArray[3].ToString();
            tinderFullName = tinderFirstName + " " + tinderName;


        }


    }
}
