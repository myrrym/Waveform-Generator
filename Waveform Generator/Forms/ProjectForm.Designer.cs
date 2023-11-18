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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProjectForm));
            buttonCreateProject = new Button();
            dataGridViewProjects = new DataGridView();
            idDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            nameDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            typeDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            dateModifiedDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            Edit = new DataGridViewImageColumn();
            Delete = new DataGridViewImageColumn();
            projectBindingSource1 = new BindingSource(components);
            projectBindingSource = new BindingSource(components);
            ((System.ComponentModel.ISupportInitialize)dataGridViewProjects).BeginInit();
            ((System.ComponentModel.ISupportInitialize)projectBindingSource1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)projectBindingSource).BeginInit();
            SuspendLayout();
            // 
            // buttonCreateProject
            // 
            buttonCreateProject.Location = new Point(12, 12);
            buttonCreateProject.Name = "buttonCreateProject";
            buttonCreateProject.Size = new Size(144, 23);
            buttonCreateProject.TabIndex = 0;
            buttonCreateProject.Text = "Create New Project";
            buttonCreateProject.UseVisualStyleBackColor = true;
            buttonCreateProject.Click += buttonCreateProject_Click;
            // 
            // dataGridViewProjects
            // 
            dataGridViewProjects.AllowUserToAddRows = false;
            dataGridViewProjects.AllowUserToDeleteRows = false;
            dataGridViewProjects.AutoGenerateColumns = false;
            dataGridViewProjects.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewProjects.Columns.AddRange(new DataGridViewColumn[] { idDataGridViewTextBoxColumn, nameDataGridViewTextBoxColumn, typeDataGridViewTextBoxColumn, dateModifiedDataGridViewTextBoxColumn, Edit, Delete });
            dataGridViewProjects.DataSource = projectBindingSource;
            dataGridViewProjects.Location = new Point(0, 41);
            dataGridViewProjects.Name = "dataGridViewProjects";
            dataGridViewProjects.ReadOnly = true;
            dataGridViewProjects.RowTemplate.Height = 25;
            dataGridViewProjects.Size = new Size(1023, 411);
            dataGridViewProjects.TabIndex = 1;
            dataGridViewProjects.CellContentClick += dataGridViewProjects_CellContentClick;
            // 
            // idDataGridViewTextBoxColumn
            // 
            idDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            idDataGridViewTextBoxColumn.DataPropertyName = "ProjectId";
            idDataGridViewTextBoxColumn.HeaderText = "Project Id";
            idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            idDataGridViewTextBoxColumn.ReadOnly = true;
            idDataGridViewTextBoxColumn.Width = 82;
            // 
            // nameDataGridViewTextBoxColumn
            // 
            nameDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            nameDataGridViewTextBoxColumn.DataPropertyName = "ProjectName";
            nameDataGridViewTextBoxColumn.HeaderText = "Project Name";
            nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            nameDataGridViewTextBoxColumn.ReadOnly = true;
            nameDataGridViewTextBoxColumn.Width = 104;
            // 
            // typeDataGridViewTextBoxColumn
            // 
            typeDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            typeDataGridViewTextBoxColumn.DataPropertyName = "ProjectType";
            typeDataGridViewTextBoxColumn.HeaderText = "Project Type";
            typeDataGridViewTextBoxColumn.Name = "typeDataGridViewTextBoxColumn";
            typeDataGridViewTextBoxColumn.ReadOnly = true;
            typeDataGridViewTextBoxColumn.Width = 96;
            // 
            // dateModifiedDataGridViewTextBoxColumn
            // 
            dateModifiedDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dateModifiedDataGridViewTextBoxColumn.DataPropertyName = "DateModified";
            dateModifiedDataGridViewTextBoxColumn.HeaderText = "Date Modified";
            dateModifiedDataGridViewTextBoxColumn.Name = "dateModifiedDataGridViewTextBoxColumn";
            dateModifiedDataGridViewTextBoxColumn.ReadOnly = true;
            dateModifiedDataGridViewTextBoxColumn.Width = 107;
            // 
            // Edit
            // 
            Edit.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            Edit.HeaderText = "Edit";
            Edit.Image = (Image)resources.GetObject("Edit.Image");
            Edit.Name = "Edit";
            Edit.ReadOnly = true;
            Edit.Resizable = DataGridViewTriState.True;
            Edit.SortMode = DataGridViewColumnSortMode.Automatic;
            Edit.Width = 52;
            // 
            // Delete
            // 
            Delete.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            Delete.HeaderText = "Delete";
            Delete.Image = (Image)resources.GetObject("Delete.Image");
            Delete.Name = "Delete";
            Delete.ReadOnly = true;
            Delete.Resizable = DataGridViewTriState.True;
            Delete.SortMode = DataGridViewColumnSortMode.Automatic;
            Delete.Width = 65;
            // 
            // projectBindingSource1
            // 
            projectBindingSource1.DataSource = typeof(Entities.Project);
            // 
            // projectBindingSource
            // 
            projectBindingSource.DataSource = typeof(Entities.Project);
            // 
            // ProjectForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1023, 451);
            Controls.Add(dataGridViewProjects);
            Controls.Add(buttonCreateProject);
            Name = "ProjectForm";
            Text = "Waveform Generator";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewProjects).EndInit();
            ((System.ComponentModel.ISupportInitialize)projectBindingSource1).EndInit();
            ((System.ComponentModel.ISupportInitialize)projectBindingSource).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button buttonCreateProject;
        private DataGridView dataGridViewProjects;
        private DataGridViewTextBoxColumn ProjectName;
        private DataGridViewTextBoxColumn Type;
        private DataGridViewTextBoxColumn DateModified;
        private BindingSource projectBindingSource;
        private DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn typeDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn dateModifiedDataGridViewTextBoxColumn;
        private DataGridViewImageColumn Edit;
        private DataGridViewImageColumn Delete;
        private BindingSource projectBindingSource1;
    }
}