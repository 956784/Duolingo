using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace LanguageLearningApp
{
    public partial class TaskListForm : Form
    {
        private int languageId;

        public TaskListForm(int langId)
        {
            InitializeComponent();
            languageId = langId;
            LoadTasks();
        }

        private void LoadTasks()
        {
            using (SqlConnection conn = DBConnection.GetConnection())
            {
                conn.Open();
                string query = "SELECT TaskId, Question FROM Tasks WHERE LanguageId = @langId";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@langId", languageId);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    int taskId = Convert.ToInt32(reader["TaskId"]);
                    string question = reader["Question"].ToString();

                    Button btn = new Button();
                    btn.Text = question;
                    btn.Tag = taskId;
                    btn.Click += BtnTask_Click;
                    flowLayoutPanel.Controls.Add(btn);
                }
            }
        }

        private void BtnTask_Click(object sender, EventArgs e)
        {
            int taskId = Convert.ToInt32(((Button)sender).Tag);
            TaskDetailForm form = new TaskDetailForm(taskId);
            form.Show();
            this.Hide();
        }
        private void btnBack_Click(object sender, EventArgs e)
        {
            LanguageSelectionForm form = new LanguageSelectionForm();
            form.Show();
            this.Hide();
        }
    }
}
