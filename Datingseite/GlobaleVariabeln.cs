using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;
using System.Data;

namespace Datingseite
{
    class GlobaleVariabeln
    {
        public static string globalMySqlConnection = "server=localhost; port=3306; username=Datingseite; password=schönenabendnoch45613; database=modernDating";
        public static string loggedInUser = "";
        public static MySqlConnection mySqlCon;
        public static MySqlCommand sqlCommand;
    }
}
