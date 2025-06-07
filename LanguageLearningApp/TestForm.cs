using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace LanguageLearningApp
{
    public partial class TestForm : Form
    {
        private int languageId;
        private List<TestQuestion> questions = new List<TestQuestion>();
        private int currentQuestionIndex = 0;
        private int score = 0;

        public TestForm(int langId)
        {
            InitializeComponent();
            languageId = langId;
            LoadQuestions();
            ShowQuestion();
        }

        private void LoadQuestions()
        {
            using (SqlConnection conn = DBConnection.GetConnection())
            {
                conn.Open();
                string query = "SELECT * FROM TestQuestions WHERE LanguageId = @langId";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@langId", languageId);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        questions.Add(new TestQuestion
                        {
                            QuestionText = reader["QuestionText"].ToString(),
                            A = reader["OptionA"].ToString(),
                            B = reader["OptionB"].ToString(),
                            C = reader["OptionC"].ToString(),
                            D = reader["OptionD"].ToString(),
                            Correct = reader["CorrectAnswer"].ToString()[0]
                        });
                    }
                }
            }
        }

        private void ShowQuestion()
        {
            if (currentQuestionIndex < questions.Count)
            {
                var q = questions[currentQuestionIndex];
                labelQuestion.Text = q.QuestionText;
                rbA.Text = q.A;
                rbB.Text = q.B;
                rbC.Text = q.C;
                rbD.Text = q.D;
            }
            else
            {
                SaveResult();
                MessageBox.Show($"Тест завершен! Ваш результат: {score} из {questions.Count}");
                this.Close(); // Закрываем форму после завершения теста
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            char selected = '\0';
            if (rbA.Checked) selected = 'A';
            else if (rbB.Checked) selected = 'B';
            else if (rbC.Checked) selected = 'C';
            else if (rbD.Checked) selected = 'D';

            if (selected != '\0')
            {
                if (selected == questions[currentQuestionIndex].Correct)
                    score++;
                currentQuestionIndex++;
                ShowQuestion();
            }
            else
            {
                MessageBox.Show("Выберите вариант ответа!");
            }
        }

        private void SaveResult()
        {
            using (SqlConnection conn = DBConnection.GetConnection())
            {
                conn.Open();
                string query = "INSERT INTO UserTestResults (UserId, LanguageId, LevelId, Score) VALUES (@userId, @langId, @levelId, @score)";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@userId", LoginForm.CurrentUserId);
                    cmd.Parameters.AddWithValue("@langId", languageId);
                    cmd.Parameters.AddWithValue("@levelId", 1); // Можно улучшить выбор уровня
                    cmd.Parameters.AddWithValue("@score", score);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            TestOrTaskForm form = new TestOrTaskForm(languageId);
            form.Show();
            this.Hide();
        }
    }

    public class TestQuestion
    {
        public string QuestionText { get; set; }
        public string A { get; set; }
        public string B { get; set; }
        public string C { get; set; }
        public string D { get; set; }
        public char Correct { get; set; }
    }
}
