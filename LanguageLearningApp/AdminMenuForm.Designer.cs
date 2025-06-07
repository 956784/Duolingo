using System.Windows.Forms;

namespace LanguageLearningApp
{
    partial class AdminMenuForm
    {
        private System.ComponentModel.IContainer components = null;
        private Button btnManageLanguages;
        private Button btnAddEditTask;
        private Button btnManageTests;
        private Button btnBack;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.btnManageLanguages = new System.Windows.Forms.Button();
            this.btnAddEditTask = new System.Windows.Forms.Button(); // Изменено на btnAddEditTask
            this.btnManageTests = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.SuspendLayout();

            // btnManageLanguages
            this.btnManageLanguages.Location = new System.Drawing.Point(100, 30);
            this.btnManageLanguages.Name = "btnManageLanguages";
            this.btnManageLanguages.Size = new System.Drawing.Size(200, 40);
            this.btnManageLanguages.TabIndex = 0;
            this.btnManageLanguages.Text = "Управление языками";
            this.btnManageLanguages.UseVisualStyleBackColor = true;
            this.btnManageLanguages.Click += new System.EventHandler(this.btnManageLanguages_Click);

            // btnAddEditTask
            this.btnAddEditTask.Location = new System.Drawing.Point(100, 90);
            this.btnAddEditTask.Name = "btnAddEditTask"; // Изменено на btnAddEditTask
            this.btnAddEditTask.Size = new System.Drawing.Size(200, 40);
            this.btnAddEditTask.TabIndex = 1;
            this.btnAddEditTask.Text = "Управление заданиями";
            this.btnAddEditTask.UseVisualStyleBackColor = true;
            this.btnAddEditTask.Click += new System.EventHandler(this.btnAddEditTask_Click); // Исправлено на btnAddEditTask_Click

            // btnManageTests
            this.btnManageTests.Location = new System.Drawing.Point(100, 150);
            this.btnManageTests.Name = "btnManageTests";
            this.btnManageTests.Size = new System.Drawing.Size(200, 40);
            this.btnManageTests.TabIndex = 2;
            this.btnManageTests.Text = "Управление тестами";
            this.btnManageTests.UseVisualStyleBackColor = true;
            this.btnManageTests.Click += new System.EventHandler(this.btnManageTests_Click);

            // btnBack
            this.btnBack.Location = new System.Drawing.Point(100, 210);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(200, 40);
            this.btnBack.TabIndex = 3;
            this.btnBack.Text = "Назад";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);

            // AdminMenuForm
            this.ClientSize = new System.Drawing.Size(400, 300);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnManageTests);
            this.Controls.Add(this.btnAddEditTask); // Изменено на btnAddEditTask
            this.Controls.Add(this.btnManageLanguages);
            this.Name = "AdminMenuForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Админ-меню";
            this.ResumeLayout(false);
        }
    }
}