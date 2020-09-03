using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marija_Bozic_Dan_60.Helper
{
    static class ConnectionHelper
    {
        private static string connectionString = ConfigurationManager.ConnectionStrings["con"].ToString();

        public static SqlConnection GetNewConnection()
        {
            SqlConnection newConnection = new SqlConnection(connectionString);

            return newConnection;
        }
    }
}
