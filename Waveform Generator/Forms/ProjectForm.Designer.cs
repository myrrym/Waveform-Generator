namespace Waveform_Generator
{
    partial class ProjectForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            buttonAddProject = new Button();
            dataGridViewProjects = new DataGridView();
            projectBindingSource = new BindingSource(components);
            idDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            nameDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            typeDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            dateModifiedDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            Update = new DataGridViewButtonColumn();
            Delete = new DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)dataGridViewProjects).BeginInit();
            ((System.ComponentModel.ISupportInitialize)projectBindingSource).BeginInit();
            SuspendLayout();
            // 
            // buttonAddProject
            // 
            buttonAddProject.Location = new Point(12, 12);
            buttonAddProject.Name = "buttonAddProject";
            buttonAddProject.Size = new Size(144, 23);
            buttonAddProject.TabIndex = 0;
            buttonAddProject.Text = "Create New Project";
            buttonAddProject.UseVisualStyleBackColor = true;
            buttonAddProject.Click += buttonAddProject_Click;
            // 
            // dataGridViewProjects
            // 
            dataGridViewProjects.AutoGenerateColumns = false;
            dataGridViewProjects.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewProjects.Columns.AddRange(new DataGridViewColumn[] { idDataGridViewTextBoxColumn, nameDataGridViewTextBoxColumn, typeDataGridViewTextBoxColumn, dateModifiedDataGridViewTextBoxColumn, Update, Delete });
            dataGridViewProjects.DataSource = projectBindingSource;
            dataGridViewProjects.Location = new Point(0, 41);
            dataGridViewProjects.Name = "dataGridViewProjects";
            dataGridViewProjects.RowTemplate.Height = 25;
            dataGridViewProjects.Size = new Size(1023, 411);
            dataGridViewProjects.TabIndex = 1;
            dataGridViewProjects.CellContentClick += buttonUpdateProjectName_Click;
            // 
            // projectBindingSource
            // 
            projectBindingSource.DataSource = typeof(Entities.Project);
            // 
            // idDataGridViewTextBoxColumn
            // 
            idDataGridViewTextBoxColumn.DataPropertyName = "ProjectId";
            idDataGridViewTextBoxColumn.HeaderText = "Project Id";
            idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            // 
            // nameDataGridViewTextBoxColumn
            // 
            nameDataGridViewTextBoxColumn.DataPropertyName = "ProjectName";
            nameDataGridViewTextBoxColumn.HeaderText = "Project Name";
            nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            // 
            // typeDataGridViewTextBoxColumn
            // 
            typeDataGridViewTextBoxColumn.DataPropertyName = "ProjectType";
            typeDataGridViewTextBoxColumn.HeaderText = "Project Type";
            typeDataGridViewTextBoxColumn.Name = "typeDataGridViewTextBoxColumn";
            // 
            // dateModifiedDataGridViewTextBoxColumn
            // 
            dateModifiedDataGridViewTextBoxColumn.DataPropertyName = "DateModified";
            dateModifiedDataGridViewTextBoxColumn.HeaderText = "Date Modified";
            dateModifiedDataGridViewTextBoxColumn.Name = "dateModifiedDataGridViewTextBoxColumn";
            // 
            // Update
            // 
            Update.HeaderText = "Update";
            Update.Name = "Update";
            Update.Resizable = DataGridViewTriState.True;
            Update.SortMode = DataGridViewColumnSortMode.Automatic;
            // 
            // Delete
            // 
            Delete.HeaderText = "Delete";
            Delete.Name = "Delete";
            // 
            // ProjectForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1023, 451);
            Controls.Add(dataGridViewProjects);
            Controls.Add(buttonAddProject);
            Name = "ProjectForm";
            Text = "Waveform Generator";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewProjects).EndInit();
            ((System.ComponentModel.ISupportInitialize)projectBindingSource).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button buttonAddProject;
        private DataGridView dataGridViewProjects;
        private DataGridViewTextBoxColumn ProjectName;
        private DataGridViewTextBoxColumn Type;
        private DataGridViewTextBoxColumn DateModified;
        private DataGridViewButtonColumn Update;
        private DataGridViewButtonColumn Delete;
        private DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn typeDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn dateModifiedDataGridViewTextBoxColumn;
        private BindingSource projectBindingSource;
    }
}