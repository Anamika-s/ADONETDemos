using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace AdoNetDemos
{
    class ExecuteScalarDemo
    {
        static void Main()
        {

            SqlConnection connection = new SqlConnection("data source=LAPTOP-53S2KQS8;" +
               "initial catalog=PracticeDb;integrated security=true");

            SqlCommand command = new SqlCommand("Select max(salary) from Employee", connection);
            connection.Open();
            int maxSalary = (int)command.ExecuteScalar();
            Console.WriteLine("Max Salary is "+ maxSalary);
            connection.Close();
        }
    }
}

