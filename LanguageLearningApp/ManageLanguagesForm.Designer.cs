using System.Windows.Forms;

namespace LanguageLearningApp
{
    partial class ManageLanguagesForm
    {
        private System.ComponentModel.IContainer components = null;
        private ListView listViewLanguages;
        private ColumnHeader columnHeaderName;
        private TextBox txtLanguageName;
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
            this.listViewLanguages = new System.Windows.Forms.ListView();
            this.columnHeaderName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.txtLanguageName = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();

            this.SuspendLayout();

            // 
            // listViewLanguages
            // 
            this.listViewLanguages.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderName});
            this.listViewLanguages.FullRowSelect = true;
            this.listViewLanguages.GridLines = true;
            this.listViewLanguages.HideSelection = false;
            this.listViewLanguages.Location = new System.Drawing.Point(20, 20);
            this.listViewLanguages.Name = "listViewLanguages";
            this.listViewLanguages.Size = new System.Drawing.Size(360, 150);
            this.listViewLanguages.TabIndex = 0;
            this.listViewLanguages.UseCompatibleStateImageBehavior = false;
            this.listViewLanguages.View = System.Windows.Forms.View.Details;

            // 
            // columnHeaderName
            // 
            this.columnHeaderName.Text = "Язык";
            this.columnHeaderName.Width = 350;

            // 
            // txtLanguageName
            // 
            this.txtLanguageName.Location = new System.Drawing.Point(20, 180);
            this.txtLanguageName.Name = "txtLanguageName";
            this.txtLanguageName.Size = new System.Drawing.Size(200, 22);
            this.txtLanguageName.TabIndex = 1;

            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(230, 180);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 25);
            this.btnAdd.TabIndex = 2;
            this.btnAdd.Text = "Добавить";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);

            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(305, 180);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 25);
            this.btnDelete.TabIndex = 3;
            this.btnDelete.Text = "Удалить";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);

            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(20, 220);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(100, 30);
            this.btnBack.TabIndex = 4;
            this.btnBack.Text = "Назад";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);

            // 
            // ManageLanguagesForm
            // 
            this.ClientSize = new System.Drawing.Size(400, 300);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.txtLanguageName);
            this.Controls.Add(this.listViewLanguages);
            this.Name = "ManageLanguagesForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Управление языками";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}