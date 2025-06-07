using System;
using System.Windows.Forms;

namespace LanguageLearningApp
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            if (LoginForm.IsAdmin)
            {
                btnAdminPanel.Visible = true;
            }
        }

        private void btnStartLearning_Click(object sender, EventArgs e)
        {
            LanguageSelectionForm form = new LanguageSelectionForm();
            form.Show();
            this.Hide();
        }

        private void btnAdminPanel_Click(object sender, EventArgs e)
        {
            AdminMenuForm adminForm = new AdminMenuForm();
            adminForm.Show();
            this.Hide();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            LoginForm.CurrentUserId = 0;
            this.Close();
            Application.Restart();
        }
    }
}