using System;
using System.Data.SqlClient;
using MySql.Data;
using MySql.Data.MySqlClient;
using Microsoft.Extensions.Configuration;

namespace Waveform_Generator.Main
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //Form1
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());

            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            


           // Application.Run(new ProjectForm());

            // database stuff - updated to include local config
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            string connectionString = configuration.GetConnectionString("MyDatabaseConnection");
            string apiKey = configuration["OtherSettings:ApiKey"];

            //// database stuff - v1
            //string connectionString = "server=localhost;userid=root;password=3142CCmm/3142;database=waveform_generator_db";


            //// Specify the database name
            //string databaseName = "waveform_generator_db";

            //// SQL command to use database
            //string useDatabaseSql = $"USE DATABASE {databaseName}";

            //try
            //{
            //    // Open a connection to the SQL Server
            //    using (SqlConnection connection = new SqlConnection(connectionString))
            //    {
            //        connection.Open();

            //        // Create a command and execute the SQL command
            //        using (SqlCommand command = new SqlCommand(useDatabaseSql, connection))
            //        {
            //            command.ExecuteNonQuery();
            //            Console.WriteLine($"Database '{databaseName}' connected successfully.");
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine($"Error creating the database: {ex.Message}");
            //}
        }
    }
}