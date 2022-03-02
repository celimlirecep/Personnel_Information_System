using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personel_Information_v2.Tools
{
    
    class SQLconnection
    {
        private static SqlConnection connection;

        public static SqlConnection Connection
        {
            get
            {
                if (connection==null)
                {
                    connection = new SqlConnection(ConfigurationManager.ConnectionStrings["PersonelInformationDataAdress"].ConnectionString);
                }
              
                return connection; 
            }
            set 
            {
                connection = value; 
            }
        }
        public static void connectionOPen()
        {
            if (connection.State==ConnectionState.Closed)
            {
                Connection.Open();
            }
        }
        public static void connectionClose()
        {
            if (connection.State==ConnectionState.Open)
            {
                Connection.Close();
            }
        }

        
      


    }
}
