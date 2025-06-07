using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace LanguageLearningApp
{
    public partial class ManageLanguagesForm : Form
    {
        public ManageLanguagesForm()
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
                    ListViewItem item = new ListViewItem(reader["Name"].ToString());
                    item.Tag = reader["LanguageId"];
                    listViewLanguages.Items.Add(item);
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string name = txtLanguageName.Text;
            using (SqlConnection conn = DBConnection.GetConnection())
            {
                conn.Open();
                string query = "INSERT INTO Languages (Name) VALUES (@name)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.ExecuteNonQuery();
                LoadLanguages();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (listViewLanguages.SelectedItems.Count > 0)
            {
                int langId = Convert.ToInt32(listViewLanguages.SelectedItems[0].Tag);
                using (SqlConnection conn = DBConnection.GetConnection())
                {
                    conn.Open();
                    string query = "DELETE FROM Languages WHERE LanguageId = @id";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id", langId);
                    cmd.ExecuteNonQuery();
                    LoadLanguages();
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
