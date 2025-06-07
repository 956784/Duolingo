using System.Windows.Forms;

namespace LanguageLearningApp
{
    partial class ManageTestsForm
    {
        private System.ComponentModel.IContainer components = null;
        private ListView listViewTests;
        private ColumnHeader columnHeaderQuestion;
        private Button btnAdd;
        private Button btnDelete;
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
            this.listViewTests = new ListView();
            this.columnHeaderQuestion = new ColumnHeader();
            this.btnAdd = new Button();
            this.btnDelete = new Button();
            this.btnBack = new Button();

            this.SuspendLayout();

            // 
            // listViewTests
            // 
            this.listViewTests.Columns.AddRange(new ColumnHeader[] { this.columnHeaderQuestion });
            this.listViewTests.FullRowSelect = true;
            this.listViewTests.GridLines = true;
            this.listViewTests.HideSelection = false;
            this.listViewTests.Location = new System.Drawing.Point(20, 20);
            this.listViewTests.Name = "listViewTests";
            this.listViewTests.Size = new System.Drawing.Size(360, 200);
            this.listViewTests.TabIndex = 0;
            this.listViewTests.View = View.Details;

            // 
            // columnHeaderQuestion
            // 
            this.columnHeaderQuestion.Text = "Тестовый вопрос";
            this.columnHeaderQuestion.Width = 350;

            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(20, 230);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(100, 30);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Text = "Добавить";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);

            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(130, 230);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(100, 30);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Text = "Удалить";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);

            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(240, 230);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(100, 30);
            this.btnBack.TabIndex = 3;
            this.btnBack.Text = "Назад";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);

            // 
            // ManageTestsForm
            // 
            this.ClientSize = new System.Drawing.Size(400, 300);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.listViewTests);
            this.Name = "ManageTestsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Управление тестами";
            this.ResumeLayout(false);
        }
    }
}