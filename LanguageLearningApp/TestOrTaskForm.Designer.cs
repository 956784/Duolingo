using System.Windows.Forms;

namespace LanguageLearningApp
{
    partial class TestOrTaskForm
    {
        private System.ComponentModel.IContainer components = null;
        private Button btnTakeTest;
        private Button btnDoTasks;
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
            this.btnTakeTest = new System.Windows.Forms.Button();
            this.btnDoTasks = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();

            this.SuspendLayout();

            // 
            // btnTakeTest
            // 
            this.btnTakeTest.Location = new System.Drawing.Point(100, 50);
            this.btnTakeTest.Name = "btnTakeTest";
            this.btnTakeTest.Size = new System.Drawing.Size(200, 40);
            this.btnTakeTest.TabIndex = 0;
            this.btnTakeTest.Text = "Пройти тест";
            this.btnTakeTest.UseVisualStyleBackColor = true;
            this.btnTakeTest.Click += new System.EventHandler(this.btnTakeTest_Click);

            // 
            // btnDoTasks
            // 
            this.btnDoTasks.Location = new System.Drawing.Point(100, 110);
            this.btnDoTasks.Name = "btnDoTasks";
            this.btnDoTasks.Size = new System.Drawing.Size(200, 40);
            this.btnDoTasks.TabIndex = 1;
            this.btnDoTasks.Text = "Выполнить задания";
            this.btnDoTasks.UseVisualStyleBackColor = true;
            this.btnDoTasks.Click += new System.EventHandler(this.btnDoTasks_Click);

            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(100, 170);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(200, 40);
            this.btnBack.TabIndex = 2;
            this.btnBack.Text = "Назад";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);

            // 
            // TestOrTaskForm
            // 
            this.ClientSize = new System.Drawing.Size(400, 300);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnDoTasks);
            this.Controls.Add(this.btnTakeTest);
            this.Name = "TestOrTaskForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Тест или задание";
            this.ResumeLayout(false);
        }
    }
}