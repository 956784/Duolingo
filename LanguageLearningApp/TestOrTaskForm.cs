using System;
using System.Windows.Forms;

namespace LanguageLearningApp
{
    public partial class TestOrTaskForm : Form
    {
        private int languageId;

        public TestOrTaskForm(int langId)
        {
            InitializeComponent();
            languageId = langId;
        }

        private void btnTakeTest_Click(object sender, EventArgs e)
        {
            // Создаем новую форму TestForm каждый раз
            TestForm testForm = new TestForm(languageId);
            try
            {
                testForm.Show(); // Показываем форму
                this.Hide(); // Скрываем текущую форму
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при открытии теста: {ex.Message}");
            }
        }

        private void btnDoTasks_Click(object sender, EventArgs e)
        {
            TaskListForm taskForm = new TaskListForm(languageId);
            taskForm.Show();
            this.Hide();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            LanguageSelectionForm form = new LanguageSelectionForm();
            form.Show();
            this.Hide();
        }
    }
}