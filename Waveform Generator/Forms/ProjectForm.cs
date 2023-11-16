using System.Xml.Linq;
using Waveform_Generator.Entities;
using Waveform_Generator.Repositories;
using System;
using System.Windows.Forms;
using System.Configuration;
using Microsoft.Extensions.Configuration;
using Waveform_Generator.Database;

namespace Waveform_Generator
{
    public partial class ProjectForm : Form
    {
        // constructor
        private ProjectRepository projectRepository;
        private readonly DatabaseManager _databaseManager;

        // starting point for the project form class
        public ProjectForm(DatabaseManager databaseManager)
        {
            InitializeComponent();

            //dataGridViewProjects.CellContentClick += DataGridViewProjects_CellContentClick;

            _databaseManager = databaseManager;

            // Instantiate ProjectRepository with the connection string
            string connectionString = _databaseManager.GetConnectionString();
            projectRepository = new ProjectRepository(connectionString);

            LoadProjects();
        }

        // load all projects
        private void LoadProjects()
        {
            dataGridViewProjects.DataSource = projectRepository.GetProjects();
        }

        // when add project button is clicked
        private void buttonCreateProject_Click(object sender, EventArgs e)
        {
            // Show an input box to get the new project name
            string projectName = Microsoft.VisualBasic.Interaction.InputBox("Enter the new project name:", "Create New Project");

            // Check if the user entered a project name
            if (!string.IsNullOrWhiteSpace(projectName))
            {
                Project newProject = new Project
                {
                    ProjectName = projectName,
                };

                bool success = projectRepository.CreateProject(newProject);

                if (success)
                {
                    MessageBox.Show($"New project created: {projectName}", "Success");
                    // Reload projects view
                    LoadProjects();
                }
                else
                {
                    MessageBox.Show("Failed to create a new project.", "Error");
                }
            }
            else
            {
                MessageBox.Show("Project name cannot be empty.", "Error");
            }
        }

        // when update project name button is clicked
        private void buttonUpdateProjectName_Click(object sender, DataGridViewCellEventArgs e)
        {
            // the "Update" button is in the 2nd last column (index: Columns.Count - 2)
            if (e.RowIndex >= 0 && e.ColumnIndex == dataGridViewProjects.Columns.Count - 2)
            {
                // Get the project name from the selected row
                string projectName = dataGridViewProjects.Rows[e.RowIndex].Cells["ProjectName"].Value.ToString();

                // Prompt the user for the new project name
                string updatedProjectName = Microsoft.VisualBasic.Interaction.InputBox($"Enter the new name for the project '{projectName}':", "Update Project Name");

                // Check if the user entered a new project name
                if (!string.IsNullOrWhiteSpace(updatedProjectName))
                {
                    // Create an instance of the Project class with the updated name
                    Project updatedProject = new Project
                    {
                        ProjectName = updatedProjectName,
                    };
                }
                else
                {
                    MessageBox.Show("New project name cannot be empty.", "Error");
                }
            }

            if (dataGridViewProjects.SelectedRows.Count > 0)
            {
                LoadProjects();
            }
        }

        // when delete project button is clicked
        private void buttonDeleteProject_Click(object sender, EventArgs e)
        {
            if (dataGridViewProjects.SelectedRows.Count > 0)
            {
                int projectId = (int)dataGridViewProjects.SelectedRows[0].Cells["Id"].Value;
                projectRepository.DeleteProject(projectId);
                LoadProjects();
            }
        }

        // dont know what this does lol but it wont let me remove it
        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}