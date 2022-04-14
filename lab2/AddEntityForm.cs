using System;
using System.Windows.Forms;
using lab2.Studio;

namespace lab2
{
    public partial class AddEntityForm : Form
    {
        private EntityManagement _entityManagement;
        public AddEntityForm(EntityManagement entity)
        {
            InitializeComponent();
            _entityManagement = entity;
        }

        private void saveNewTask_Click(object sender, EventArgs e)
        {
            _entityManagement.addTask(descriptionTextBox.Text, Int32.Parse(rimeRequiredTextBox.Text));
            this.Close();
        }
    }
}