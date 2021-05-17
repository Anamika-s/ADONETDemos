using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Step 1 , add required namespaces/library
using System.Data.SqlClient;

namespace AdoNetDemos
{
    class Program
    {
        static void Main(string[] args)
        {
            // Step 2, Create a connection object , within that
            // pass the connectionstring
            // connectionstring contains 
            // 1. Server Name 
            // 2. Database Name
            // 3. Credentials

            SqlConnection sqlConnection = new SqlConnection();
            string connectionString = "data source=LAPTOP-53S2KQS8;" +
                "initial catalog=PracticeDb;integrated security=true";
            sqlConnection.ConnectionString = connectionString;

            // Step 3: , We need to pass the request from front End 
            // to Back End
            // Create Object of SqlCommand
            // Within that we will pass 2 parameters
            // 1. Command 2. Connection Object

            SqlCommand command = new SqlCommand();
            command.CommandText = "Select * from Employee";
            command.Connection = sqlConnection;

            // Step 4: Open Connection
            sqlConnection.Open();
            // At this point , connection is established 
            // in between FEnd & BEnd
            // Step 5: Execute Query

            // ExecuteReader exeutes Select Query at backend
            // and brings record from there

            SqlDataReader reader = command.ExecuteReader();
            if(reader.HasRows)
            {
                while(reader.Read())
                {
                    Console.WriteLine(reader[0] + " " + reader[1]);
                }
            }
            // Close connection between FEnd & BEnd
            sqlConnection.Close();
        }
    }
}
