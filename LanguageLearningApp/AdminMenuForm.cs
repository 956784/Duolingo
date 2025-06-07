using System;
using System.Windows.Forms;

namespace LanguageLearningApp
{
    public partial class AdminMenuForm : Form
    {
        public AdminMenuForm()
        {
            InitializeComponent();
        }

        private void btnManageLanguages_Click(object sender, EventArgs e)
        {
            ManageLanguagesForm form = new ManageLanguagesForm();
            form.Show();
            this.Hide();
        }

        private void btnAddEditTask_Click(object sender, EventArgs e)
        {
            AddEditTaskForm form = new AddEditTaskForm(0); // Создаем форму для добавления нового задания (id = 0)
            form.Show();
            this.Hide();
        }

        private void btnManageTests_Click(object sender, EventArgs e)
        {
            ManageTestsForm form = new ManageTestsForm();
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