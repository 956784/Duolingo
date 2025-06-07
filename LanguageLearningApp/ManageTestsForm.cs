using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace LanguageLearningApp
{
    public partial class ManageTestsForm : Form
    {
        public ManageTestsForm()
        {
            InitializeComponent();
            LoadTestQuestions();
        }

        private void LoadTestQuestions()
        {
            using (SqlConnection conn = DBConnection.GetConnection())
            {
                conn.Open();
                string query = "SELECT QuestionId, QuestionText FROM TestQuestions";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    ListViewItem item = new ListViewItem(reader["QuestionText"].ToString());
                    item.Tag = reader["QuestionId"];
                    listViewTests.Items.Add(item);
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddEditTestForm form = new AddEditTestForm(0); // 0 — это новый вопрос
            form.ShowDialog();
            LoadTestQuestions(); // Обновить список после добавления
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (listViewTests.SelectedItems.Count > 0)
            {
                int questionId = Convert.ToInt32(listViewTests.SelectedItems[0].Tag);
                using (SqlConnection conn = DBConnection.GetConnection())
                {
                    conn.Open();
                    string query = "DELETE FROM TestQuestions WHERE QuestionId = @id";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id", questionId);
                    cmd.ExecuteNonQuery();
                    LoadTestQuestions(); // Обновить список после удаления
                }
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            AdminMenuForm adminForm = new AdminMenuForm();
            adminForm.Show();
            this.Hide();
        }
    }
}