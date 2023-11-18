using System;
using System.Data.SqlClient;
using MySql.Data;
using MySql.Data.MySqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Waveform_Generator.Database;

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
            Application.Run(new Form1());
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // config builder - database
            IConfiguration configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            // Example: Create a service provider to inject the configuration
            var serviceProvider = new ServiceCollection()
                .AddSingleton(configuration)
                .AddSingleton<DatabaseManager>()
                .BuildServiceProvider();

            // Example: Resolve and use the DatabaseManager
            var databaseManager = new DatabaseManager(configuration);
            string connectionString = databaseManager.GetConnectionString();

            

            //Application.Run(new ProjectForm(databaseManager));
        }
    }
}