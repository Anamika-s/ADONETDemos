using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace AdoNetDemo
{
    enum choice { Insert = 1, Update, Delete, GetRecords };
    class SPDemo
    {

        static void Main()
        {
            int Choice;
            string ch = "y";
            while (ch == "y")
            {
                try
                {
                    MainMenu();
                    Console.WriteLine("Enter Your Choice");
                    Choice = Byte.Parse(Console.ReadLine());
                    switch (Choice)
                    {
                        case (int)choice.Insert:
                            {
                                InsertRecord();
                                break;
                            }
                        case (int)choice.Update:
                            {
                                UpdateRecord();
                                break;
                            }
                        case (int)choice.Delete:
                            {
                                DeleteRecord();
                                break;
                            }
                        case (int)choice.GetRecords:
                            {
                                GetRecords();
                                break;
                            }
                        default:
                            {
                                Console.WriteLine("Invalid Choice");
                                break;
                            }
                    }
                    Console.WriteLine("Do you want to repeat the process");
                    ch = Console.ReadLine();

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
        static void MainMenu()
        {
            Console.WriteLine("1. Insert Record");
            Console.WriteLine("2. Update Record");
            Console.WriteLine("3. Delete Record");
            Console.WriteLine("4. Display All Records");
        }

        static string GetConnectionString()
        {
            string connectionString = ConfigurationManager.AppSettings
                ["MyConnection"].ToString();
            return connectionString;
        }
        static SqlConnection GetConnnection()
        {

            SqlConnection connection = new SqlConnection(GetConnectionString());
            // connection = new SqlConnection("data source=LAPTOP-53S2KQS8;" +
            //    "initial catalog=PracticeDb1;integrated security=true");


            return connection;
        }
        static void InsertRecord()
        {
            using (SqlConnection connection = GetConnnection())
            {
                Console.WriteLine("Enter ID");
                int id = Byte.Parse(Console.ReadLine());
                Console.WriteLine("Enter Name");
                string name = Console.ReadLine();
                Console.WriteLine("Enter Address");
                string address = Console.ReadLine();
                Console.WriteLine("Enter Salary");
                int salary = int.Parse(Console.ReadLine());
                using (SqlCommand command = new 
                    SqlCommand("InsertEmployee", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@id", id);
                    command.Parameters.AddWithValue("@name", name);
                    command.Parameters.AddWithValue("@address", address);
                    command.Parameters.AddWithValue("@salary", salary);
                    connection.Open();
                    int count = command.ExecuteNonQuery();
                    Console.WriteLine("No of Records inserted are " + count);
                    connection.Close();

                }
            }
        }


        static void UpdateRecord()
        {
            using (SqlConnection connection = GetConnnection())
            {


                Console.WriteLine("Enter ID whose Record you want to modisy");
                int id = Byte.Parse(Console.ReadLine());

                Console.WriteLine("Enter New Address");
                string address = Console.ReadLine();
                Console.WriteLine("Enter Revised Salary");
                int salary = int.Parse(Console.ReadLine());
                using (SqlCommand command = new SqlCommand("UpdateEmployee", connection))
                {

                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@id", id);

                    command.Parameters.AddWithValue("@address", address);
                    command.Parameters.AddWithValue("@salary", salary);
                    connection.Open();
                    int count = command.ExecuteNonQuery();
                    Console.WriteLine("No of Records updated are " + count);
                    connection.Close();
                }
            }
        }

        static void DeleteRecord()
        {
            using (SqlConnection connection = GetConnnection())
            {

                Console.WriteLine("Enter ID whose Record you want to delete");
                int id = Byte.Parse(Console.ReadLine());

                using (SqlCommand command = new SqlCommand("DeleteEmployee", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@id", id);

                    connection.Open();
                    int count = command.ExecuteNonQuery();
                    Console.WriteLine("No of Records deleted are " + count);
                    connection.Close();

                }
            }
        }
        static void GetRecords()
        {
            using (SqlConnection connection = GetConnnection())
            {
                using (SqlCommand command = new SqlCommand
                ("GetEmployees",
                connection))
                {
                    command.CommandType = CommandType.StoredProcedure;  
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine(reader["id"].ToString() + " " + reader["name"]);
                        }
                    }

                    reader.Close();
                    connection.Close();

                }
            }
        }
    }


}
