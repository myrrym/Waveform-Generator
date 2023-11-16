using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Waveform_Generator.Entities;
using MySql.Data;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Math.EC;

namespace Waveform_Generator.Repositories
{
    public class ProjectRepository
    {
        // use mysql connection
        private readonly string connectionString; // Set your database connection string here
        public ProjectRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        // constructor
        private List<Project> projects = new List<Project>();

        // add project method
        public bool CreateProject(Project project)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    string insertQuery = "INSERT INTO projects (project_name, project_type, date_modified) VALUES (@ProjectName, @ProjectType, @DateModified)";
                    using (MySqlCommand cmd = new MySqlCommand(insertQuery, connection))
                    {
                        cmd.Parameters.AddWithValue("@ProjectName", project.ProjectName);
                        cmd.Parameters.AddWithValue("@ProjectType", "Sine Wave");
                        cmd.Parameters.AddWithValue("@DateModified", DateTime.Now);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        return rowsAffected > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions (log, show error message, etc.)
                Console.WriteLine($"Error: {ex.Message}");
                return false;
            }
        }

        // list all projects method
        public List<Project> GetProjects()
        {
            List<Project> projects = new List<Project>();

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string sql = "SELECT project_id, project_name, project_type, date_modified FROM projects";

                using (MySqlCommand command = new MySqlCommand(sql, connection))
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Project project = new Project
                        {
                            ProjectId = reader.IsDBNull(reader.GetOrdinal("project_id")) ? 0 : reader.GetInt32(reader.GetOrdinal("project_id")),
                            ProjectName = reader.IsDBNull(reader.GetOrdinal("project_name")) ? string.Empty : reader.GetString(reader.GetOrdinal("project_name")),
                            ProjectType = reader.IsDBNull(reader.GetOrdinal("project_type")) ? string.Empty : reader.GetString(reader.GetOrdinal("project_type")),
                            DateModified = reader.IsDBNull(reader.GetOrdinal("date_modified")) ? DateTime.MinValue : reader.GetDateTime(reader.GetOrdinal("date_modified")),
                        };

                        projects.Add(project);
                    }
                }
            }

            return projects;
        }

        // edit project name method
        public void UpdateProjectName(Project updatedProjectName)
        {
            Project existingProjectName = projects.Find(p => p.ProjectId == updatedProjectName.ProjectId);
            if (existingProjectName != null)
            {
                existingProjectName.ProjectName = updatedProjectName.ProjectName;
                existingProjectName.DateModified = DateTime.Now;
            }
        }

        // delete project method
        public void DeleteProject(int projectId)
        {
            projects.RemoveAll(p => p.ProjectId == projectId);
        }
    }
}
