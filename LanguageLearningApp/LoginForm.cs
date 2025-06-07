using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace LanguageLearningApp
{
    public partial class LoginForm : Form
    {
        public static int CurrentUserId;
        public static bool IsAdmin;

        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text.Trim();
            string password = txtPassword.Text.Trim();

            try
            {
                using (SqlConnection conn = DBConnection.GetConnection())
                {
                    conn.Open();
                    string query = "SELECT UserId, PasswordHash, IsAdmin, Email FROM Users WHERE Email = @Email";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Email", email);
        
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string storedPassword = reader["PasswordHash"].ToString();
                                if (password == storedPassword)
                                {
                                    CurrentUserId = Convert.ToInt32(reader["UserId"]);
                                    IsAdmin = Convert.ToBoolean(reader["IsAdmin"]);
                                    this.Hide();
                                    MainForm mainForm = new MainForm();
                                    mainForm.Show();
                                }
                                else
                                {
                                    MessageBox.Show("Неверный пароль.");
                                }
                            }
               
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при входе: " + ex.Message);
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            RegisterForm registerForm = new RegisterForm();
            if (registerForm.ShowDialog() == DialogResult.OK)
            {
                txtEmail.Text = registerForm.Email;
                txtPassword.Focus();
            }
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }
    }
}