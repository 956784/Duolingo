using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace LanguageLearningApp
{
    public partial class AddEditTaskForm : Form
    {
        private int taskId;

        public AddEditTaskForm(int id)
        {
            InitializeComponent();
            taskId = id;

            if (id > 0) // Редактирование существующего задания
            {
                LoadTask(id);
            }
        }

        private void LoadTask(int id)
        {
            using (SqlConnection conn = DBConnection.GetConnection())
            {
                conn.Open();
                string query = "SELECT Question, Answer FROM Tasks WHERE TaskId = @id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", id);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    txtQuestion.Text = reader["Question"].ToString();
                    txtAnswer.Text = reader["Answer"].ToString();
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string questionText = txtQuestion.Text.Trim();
            string answerText = txtAnswer.Text.Trim();

            if (string.IsNullOrEmpty(questionText) || string.IsNullOrEmpty(answerText))
            {
                MessageBox.Show("Введите текст вопроса и ответа.");
                return;
            }

            using (SqlConnection conn = DBConnection.GetConnection())
            {
                conn.Open();
                string query;

                if (taskId == 0) // Новое задание
                {
                    query = "INSERT INTO Tasks (Question, Answer, LanguageId) VALUES (@question, @answer, @langId)";
                }
                else // Редактирование существующего задания
                {
                    query = "UPDATE Tasks SET Question = @question, Answer = @answer WHERE TaskId = @id";
                }

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@question", questionText);
                cmd.Parameters.AddWithValue("@answer", answerText);

                if (taskId > 0)
                {
                    cmd.Parameters.AddWithValue("@id", taskId);
                }

                cmd.ExecuteNonQuery();
                MessageBox.Show("Задание сохранено успешно.");
                this.Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}