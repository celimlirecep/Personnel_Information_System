using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personnel_Information_System
{
    class Database
    {


        SqlConnection connection;
        string querySentence;
        public string TableName { get; set; }
        public DataTable Dt { get; set; }



        public Database()
        {
            connect();
            connectionOpen();
        }


        SqlConnection connect()
        {
            
            string Server = @"RECEP-CELIMLI\SQLEXPRESS";
            string DatabaseAdress = @"Personnel_Information_System";
            string UserName = @"sa";
            string Pasword = @"123";
            string connectionAdress = $@"Server={Server};Database={DatabaseAdress};User={UserName};Pwd={Pasword}";
            connection = new SqlConnection(connectionAdress);
            return connection;
            

        }
        void connectionOpen()
        {
            if (connection.State==System.Data.ConnectionState.Closed)
            {
                connection.Open();
            }
        }
        void connectionclose()
        {
            if (connection.State==System.Data.ConnectionState.Open)
            {
                connection.Close();
            }
        }

        /// <summary>
        /// This method pulls a data from datatable. After it displays on the datagridview
        /// </summary>
        public void operation()
        {
            querySentence = $"SELECT * FROM {TableName}";
            SqlDataAdapter adapter = new SqlDataAdapter(querySentence, connection);
            Dt = new DataTable();
            adapter.Fill(Dt);
            
        }
      
        public void operation(params object[] arg)
        {
            string columsentence = "";
            foreach (object item in arg)
            {
                columsentence = string.Join(",",item.ToString());
            }
            
            querySentence=$"INSERT INTO "

        }





    }
}
