using System.Windows.Forms;

namespace LanguageLearningApp
{
    partial class RatingForm
    {
        private System.ComponentModel.IContainer components = null;
        private ListView listViewRanking;
        private ColumnHeader columnHeaderUser;
        private ColumnHeader columnHeaderPoints;
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
            this.listViewRanking = new System.Windows.Forms.ListView();
            this.columnHeaderUser = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderPoints = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnBack = new System.Windows.Forms.Button();

            this.SuspendLayout();

            // 
            // listViewRanking
            // 
            this.listViewRanking.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderUser,
            this.columnHeaderPoints});
            this.listViewRanking.FullRowSelect = true;
            this.listViewRanking.GridLines = true;
            this.listViewRanking.HideSelection = false;
            this.listViewRanking.Location = new System.Drawing.Point(20, 20);
            this.listViewRanking.Name = "listViewRanking";
            this.listViewRanking.Size = new System.Drawing.Size(360, 200);
            this.listViewRanking.TabIndex = 0;
            this.listViewRanking.UseCompatibleStateImageBehavior = false;
            this.listViewRanking.View = System.Windows.Forms.View.Details;

            // 
            // columnHeaderUser
            // 
            this.columnHeaderUser.Text = "Пользователь";
            this.columnHeaderUser.Width = 200;

            // 
            // columnHeaderPoints
            // 
            this.columnHeaderPoints.Text = "Баллы";
            this.columnHeaderPoints.Width = 150;

            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(20, 230);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(100, 30);
            this.btnBack.TabIndex = 1;
            this.btnBack.Text = "Назад";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);

            // 
            // RatingForm
            // 
            this.ClientSize = new System.Drawing.Size(400, 300);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.listViewRanking);
            this.Name = "RatingForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Рейтинг";
            this.ResumeLayout(false);
        }
    }
}