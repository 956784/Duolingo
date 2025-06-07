using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace LanguageLearningApp
{
    public partial class LanguageSelectionForm : Form
    {
        public static int SelectedLanguageId { get; set; }

        public LanguageSelectionForm()
        {
            InitializeComponent();
            LoadLanguages();
        }

        private void LoadLanguages()
        {
            using (SqlConnection conn = DBConnection.GetConnection())
            {
                conn.Open();
                string query = "SELECT LanguageId, Name FROM Languages";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    int id = Convert.ToInt32(reader["LanguageId"]);
                    string name = reader["Name"].ToString();
                    Button btn = new Button();
                    btn.Text = name;
                    btn.Tag = id;
                    btn.Click += BtnLang_Click;
                    flowLayoutPanel.Controls.Add(btn);
                }
            }
        }

        private void BtnLang_Click(object sender, EventArgs e)
        {
            SelectedLanguageId = Convert.ToInt32(((Button)sender).Tag);
            TestOrTaskForm form = new TestOrTaskForm(SelectedLanguageId);
            form.Show();
            this.Hide();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            MainForm mainForm = new MainForm();
            mainForm.Show();
            this.Hide();
        }
    }
}