using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace LanguageLearningApp
{
    public partial class RatingForm : Form
    {
        public RatingForm()
        {
            InitializeComponent();
            LoadRanking();
        }

        private void LoadRanking()
        {
            using (SqlConnection conn = DBConnection.GetConnection())
            {
                conn.Open();
                string query = @"
                    SELECT u.Username, SUM(uts.Points) AS TotalPoints 
                    FROM Users u 
                    JOIN UserTaskScores uts ON u.UserId = uts.UserId 
                    GROUP BY u.Username 
                    ORDER BY TotalPoints DESC";

                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    ListViewItem item = new ListViewItem(reader["Username"].ToString());
                    item.SubItems.Add(reader["TotalPoints"].ToString());
                    listViewRanking.Items.Add(item);
                }
            }
        }
        private void btnBack_Click(object sender, EventArgs e)
        {
            MainForm mainForm = new MainForm();
            mainForm.Show();
            this.Hide();
        }
    }
}
