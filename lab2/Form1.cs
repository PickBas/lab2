using System;
using System.Windows.Forms;
using lab2.Coder;
using lab2.Designer;
using lab2.ProjectManager;
using lab2.Studio;

namespace lab2
{
    public partial class Form1 : Form
    {
        public event Func<TextBox, bool> runningRandomTask;
        public event Func<TextBox, bool> simulationStop;
        public EventTaskManagement eventTaskManagement;
        public Form1()
        {
            eventTaskManagement = EventTaskManagement.getInstance(new CoderEntity(),
                new DesignerEntity(),
                new ProjectManagerEntity());
            runningRandomTask += eventTaskManagement.runEventHendler;
            simulationStop += eventTaskManagement.stopEventHendler;

            InitializeComponent();
        }

        private void runSimulation_Click(object sender, EventArgs e)
        {
            runningRandomTask.Invoke(logBox);
        }

        private void stopSimulation_Click(object sender, EventArgs e)
        {
            simulationStop.Invoke(logBox);
            logBox.AppendText("Stopped simulation" + Environment.NewLine);
        }

        private void coderInfoBtn_Click(object sender, EventArgs e)
        {
            EntityForm entityForm = new EntityForm(
                eventTaskManagement.coderTaskCounter, 
                "CoderTask",
                eventTaskManagement.getEntity("coder").getAmountOfActivities());
            entityForm.Show();
        }

        private void designerInfoBtn_Click(object sender, EventArgs e)
        {
            EntityForm entityForm = new EntityForm(
                eventTaskManagement.designerTaskCounter, 
                "DesignerTask",
                eventTaskManagement.getEntity("designer").getAmountOfActivities());
            entityForm.Show();
        }

        private void projectManagerInfoBtn_Click(object sender, EventArgs e)
        {
            EntityForm entityForm = new EntityForm(
                eventTaskManagement.projectManagerTaskCounter, 
                "ProjectManagerTask",
                eventTaskManagement.getEntity("projectManager").getAmountOfActivities());
            entityForm.Show();
        }

        private void coderAddTask_Click(object sender, EventArgs e)
        {
            AddEntityForm addEntityForm = new AddEntityForm(eventTaskManagement.getEntity("coder"));
            addEntityForm.Show();
        }

        private void designerAddTask_Click(object sender, EventArgs e)
        {
            AddEntityForm addEntityForm = new AddEntityForm(eventTaskManagement.getEntity("designer"));
            addEntityForm.Show();
        }

        private void projectManagerAddTask_Click(object sender, EventArgs e)
        {
            AddEntityForm addEntityForm = new AddEntityForm(eventTaskManagement.getEntity("projectManager"));
            addEntityForm.Show();
        }
    }
}
