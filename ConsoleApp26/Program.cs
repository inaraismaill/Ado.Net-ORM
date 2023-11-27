using ConsoleApp26.helpers;
using System.Data.SqlClient;

namespace ConsoleApp26
{
    internal class Program
    {private const string _connectionString = @"Server=INARA\SQLEXPRESS;Database =human;Trusted_Connection=true";
        static void Main(string[] args)
        {
            Console.WriteLine("1. Register\n2. Login\n3. Exit");
            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Register();
                    break;
                case 2:
                    Login();
                    break;
                case 3:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid choice");
                    break;
            }
        }
        static void Register()
        {
            Console.Write("Enter your name: ");
            string name = Console.ReadLine();

            Console.Write("Enter your surname: ");
            string surname = Console.ReadLine();

            Console.Write("Enter your password: ");
            string password = Console.ReadLine();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string query = "INSERT INTO Users (Name, Surname, Password) VALUES (@Name, @Surname, @Password)";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Name", name);
                    command.Parameters.AddWithValue("@Surname", surname);

                    command.ExecuteNonQuery();
                }
            }

            Console.WriteLine("Registration successful!");
        }

        static void Login()
        {
            Console.Write("Enter your name: ");
            string name = Console.ReadLine();

            Console.Write("Enter your password: ");
            string password = Console.ReadLine();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string query = "SELECT COUNT(*) FROM Users WHERE Name = @Name AND Password = @Password";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Name", name);

                    int userCount = (int)command.ExecuteScalar();

                    if (userCount > 0)
                    {
                        Console.WriteLine("Login successful!");
                    }
                    else
                    {
                        Console.WriteLine("Login unsuccessful");
                    }
                }
            }
        }

    }
}