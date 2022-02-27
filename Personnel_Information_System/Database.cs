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
        SqlCommand command;
        string querySentence;
        public string TableName { get; set; }
        public DataTable Dt { get; set; }



        public Database()
        {
            connection= connect();
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
        /// <summary>
        /// This method adds parameters to the table
        /// </summary>
        /// <param name="employee"></param>
      
        public void operation(Employee employee)
        {
            connectionOpen();
            querySentence = $"INSERT INTO  {TableName} " +
                $"(EmployeeNumber,EmployeeID,DateOfStart,DepartmentID,WorkingStatus) VALUES" +
                $"(@P1,@P2,@P3,@P4,@P5) ";
            command = new SqlCommand(querySentence, connection);
            command.Parameters.AddWithValue("@P1", employee.EmployeeNumber);
            command.Parameters.AddWithValue("@P2", employee.EmployeeNameID);
            command.Parameters.AddWithValue("@P3", employee.DateOfStart.ToString("yyyy-MM-dd"));
            command.Parameters.AddWithValue("@P4", employee.DepartmantID);
            command.Parameters.AddWithValue("@P5", employee.WorkingStatus);
            command.ExecuteNonQuery();
            connectionclose();
        }
        /// <summary>
        /// This method doesn't delete. this method sets the last column's cell to false 
        /// </summary>
        /// <param name="id"></param>
        
        public void operation(string id)
        {
            connectionOpen();
            querySentence = $"UPDATE {TableName} SET WorkingStatus=0 WHERE EmployeeNumber='{id}'";
            command = new SqlCommand(querySentence, connection);
            command.ExecuteNonQuery();
            connectionclose();
        }

       





    }
}
