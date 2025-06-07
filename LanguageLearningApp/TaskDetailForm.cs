using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace LanguageLearningApp
{
    public partial class TaskDetailForm : Form
    {
        private int taskId;

        public TaskDetailForm(int id)
        {
            InitializeComponent();
            taskId = id;
            LoadTask();
        }

        private void LoadTask()
        {
            using (SqlConnection conn = DBConnection.GetConnection())
            {
                conn.Open();
                string query = "SELECT Question, Answer FROM Tasks WHERE TaskId = @id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", taskId);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    labelQuestion.Text = reader["Question"].ToString();
                }
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            string userAnswer = txtAnswer.Text.Trim().ToLower();
            string correctAnswer = "";

            using (SqlConnection conn = DBConnection.GetConnection())
            {
                conn.Open();
                string query = "SELECT Answer FROM Tasks WHERE TaskId = @id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", taskId);
                correctAnswer = cmd.ExecuteScalar().ToString().ToLower();

                if (userAnswer == correctAnswer)
                {
                    AddScore();
                    MessageBox.Show("Правильно!");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Неправильно. Попробуйте ещё раз.");
                }
            }
        }

        private void AddScore()
        {
            using (SqlConnection conn = DBConnection.GetConnection())
            {
                conn.Open();
                string query = "INSERT INTO UserTaskScores (UserId, TaskId, Points) VALUES (@userId, @taskId, 10)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@userId", LoginForm.CurrentUserId);
                cmd.Parameters.AddWithValue("@taskId", taskId);
                cmd.ExecuteNonQuery();
            }
        }
        private void btnBack_Click(object sender, EventArgs e)
        {
            TaskListForm form = new TaskListForm(LanguageSelectionForm.SelectedLanguageId); // Исправлено
            form.Show();
            this.Hide();
        }
    }
}
