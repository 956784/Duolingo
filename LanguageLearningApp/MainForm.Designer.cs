using System.Windows.Forms;

namespace LanguageLearningApp
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;
        private Button btnStartLearning;
        private Button btnAdminPanel;
        private Button btnLogout;

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
            this.btnStartLearning = new System.Windows.Forms.Button();
            this.btnAdminPanel = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();

            this.SuspendLayout();

            // 
            // btnStartLearning
            // 
            this.btnStartLearning.Location = new System.Drawing.Point(100, 50);
            this.btnStartLearning.Name = "btnStartLearning";
            this.btnStartLearning.Size = new System.Drawing.Size(200, 40);
            this.btnStartLearning.TabIndex = 0;
            this.btnStartLearning.Text = "Начать учить язык";
            this.btnStartLearning.UseVisualStyleBackColor = true;
            this.btnStartLearning.Click += new System.EventHandler(this.btnStartLearning_Click);

            // 
            // btnAdminPanel
            // 
            this.btnAdminPanel.Location = new System.Drawing.Point(100, 110);
            this.btnAdminPanel.Name = "btnAdminPanel";
            this.btnAdminPanel.Size = new System.Drawing.Size(200, 40);
            this.btnAdminPanel.TabIndex = 1;
            this.btnAdminPanel.Text = "Админ-панель";
            this.btnAdminPanel.UseVisualStyleBackColor = true;
            this.btnAdminPanel.Visible = false;
            this.btnAdminPanel.Click += new System.EventHandler(this.btnAdminPanel_Click);

            // 
            // btnLogout
            // 
            this.btnLogout.Location = new System.Drawing.Point(100, 170);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(200, 40);
            this.btnLogout.TabIndex = 2;
            this.btnLogout.Text = "Выйти из аккаунта";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);

            // 
            // MainForm
            // 
            this.ClientSize = new System.Drawing.Size(400, 300);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.btnAdminPanel);
            this.Controls.Add(this.btnStartLearning);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Главное меню";
            this.ResumeLayout(false);
        }
    }
}