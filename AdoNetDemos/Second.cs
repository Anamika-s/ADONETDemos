using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace AdoNetDemos
{
    class Second
    {
        public static void Main()
        {

            //SqlConnection sqlConnection = new SqlConnection();
            //string connectionString = "data source=LAPTOP-53S2KQS8;" +
            //    "initial catalog=PracticeDb;integrated security=true";
            //sqlConnection.ConnectionString = connectionString;

            SqlConnection connection = new SqlConnection("data source=LAPTOP-53S2KQS8;" +
                "initial catalog=PracticeDb;integrated security=true");

            //SqlCommand command = new SqlCommand();
            //command.CommandText = "Select * from Employee";
            //command.Connection = sqlConnection;

            SqlCommand command = new SqlCommand("Select * from Employee",
                connection);

            connection.Open();
            SqlDataReader reader =  command.ExecuteReader();
            if(reader.HasRows)
            {
                while(reader.Read())
                {
                    Console.WriteLine(reader["id"].ToString()+  " " + reader["name"]);
                }
            }

            reader.Close();
            connection.Close();
           
        }
    }
}
