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

        public static string fullname = "";
        public static string username = "";
        public static string firstname = "";
        public static string name = "";
        public static string birthday = "";
        public static string description = "";
        public static string gender = "";



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
            firstname = dt.Rows[0].ItemArray[2].ToString();
            name = dt.Rows[0].ItemArray[1].ToString();
            gender = dt.Rows[0].ItemArray[4].ToString();
            description = dt.Rows[0].ItemArray[5].ToString();
            birthday = dt.Rows[0].ItemArray[3].ToString();
            fullname = firstname + " " + name;


        }


    }
}
