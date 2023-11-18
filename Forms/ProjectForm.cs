using System.Xml.Linq;
using Waveform_Generator.Entities;
using Waveform_Generator.Repositories;
using System;
using System.Windows.Forms;
using System.Configuration;
using Microsoft.Extensions.Configuration;
using Waveform_Generator.Database;
using MySqlX.XDevAPI.Relational;

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

                    // Open Form1 after creating a new project
                    WaveformGeneratorForm waveformGeneratorForm = new WaveformGeneratorForm();
                    waveformGeneratorForm.Show();

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

        // event handler for both update and delete buttons
        private void dataGridViewProjects_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // check if edit button is pressed
            if (e.ColumnIndex == dataGridViewProjects.Columns["Edit"].Index && e.RowIndex >= 0)
            {
                int projectId = (int)dataGridViewProjects.Rows[e.RowIndex].Cells["idDataGridViewTextBoxColumn"].Value;

                // Prompt user for new project name
                string updatedProjectName = Microsoft.VisualBasic.Interaction.InputBox($"Enter the new name for the project:", "Update Project Name");

                if (!string.IsNullOrWhiteSpace(updatedProjectName))
                {
                    // Call a method to update the project name
                    UpdateProjectName(projectId, updatedProjectName);

                    // Refresh DataGridView
                    LoadProjects();
                }
                else
                {
                    MessageBox.Show("New project name cannot be empty.", "Error");
                }
            }

            // Check if the clicked cell is in the delete button column and row is valid + Check if the clicked cell is in the delete column and not in the header row
            if (e.ColumnIndex == dataGridViewProjects.Columns["Delete"].Index && e.RowIndex >= 0)
            {
                // for debugging purposes
                foreach (DataGridViewColumn column in dataGridViewProjects.Columns)
                {
                    System.Diagnostics.Debug.WriteLine("This is a debug message");
                    System.Diagnostics.Debug.WriteLine(column.Name);
                }

                // Handle delete button click
                int projectId = (int)dataGridViewProjects.Rows[e.RowIndex].Cells["idDataGridViewTextBoxColumn"].Value;

                // Call a method to delete the project based on projectId
                DeleteProject(projectId);
            }
        }

        private void UpdateProjectName(int projectId, string updatedProjectName)
        {
            // Call your ProjectRepository method to update the project name in the database
            projectRepository.UpdateProjectName(projectId, updatedProjectName);
        }

        private void DeleteProject(int projectId)
        {
            bool success = projectRepository.DeleteProject(projectId);

            if (success)
            {
                MessageBox.Show($"Project deleted successfully.", "Success");
                // Reload projects view
                LoadProjects();
            }
            else
            {
                MessageBox.Show("Failed to delete the project.", "Error");
            }
        }

        // dont know what this does lol but it wont let me remove it
        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}