using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace LanguageLearningApp
{
    public partial class AddEditTestForm : Form
    {
        private int questionId;

        public AddEditTestForm(int id)
        {
            InitializeComponent();
            questionId = id;

            if (id > 0) // Редактирование существующего вопроса
            {
                LoadQuestion(id);
            }
        }

        private void LoadQuestion(int id)
        {
            using (SqlConnection conn = DBConnection.GetConnection())
            {
                conn.Open();
                string query = "SELECT QuestionText FROM TestQuestions WHERE QuestionId = @id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", id);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    txtQuestion.Text = reader["QuestionText"].ToString();
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string questionText = txtQuestion.Text.Trim();

            if (string.IsNullOrEmpty(questionText))
            {
                MessageBox.Show("Введите текст вопроса.");
                return;
            }

            using (SqlConnection conn = DBConnection.GetConnection())
            {
                conn.Open();
                string query;

                if (questionId == 0) // Новый вопрос
                {
                    query = "INSERT INTO TestQuestions (QuestionText) VALUES (@text)";
                }
                else // Редактирование существующего вопроса
                {
                    query = "UPDATE TestQuestions SET QuestionText = @text WHERE QuestionId = @id";
                }

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@text", questionText);

                if (questionId > 0)
                {
                    cmd.Parameters.AddWithValue("@id", questionId);
                }

                cmd.ExecuteNonQuery();
                MessageBox.Show("Тестовый вопрос сохранён успешно.");
                this.Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}