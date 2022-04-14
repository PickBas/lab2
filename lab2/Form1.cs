using System;
using System.Windows.Forms;
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
            eventTaskManagement = EventTaskManagement.getInstance();
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
                eventTaskManagement.getStudio().coderTaskCounter, 
                "CoderTask",
                eventTaskManagement.getStudio().getEntity("coder").getAmountOfActivities());
            entityForm.Show();
        }

        private void designerInfoBtn_Click(object sender, EventArgs e)
        {
            EntityForm entityForm = new EntityForm(
                eventTaskManagement.getStudio().designerTaskCounter, 
                "DesignerTask",
                eventTaskManagement.getStudio().getEntity("designer").getAmountOfActivities());
            entityForm.Show();
        }

        private void projectManagerInfoBtn_Click(object sender, EventArgs e)
        {
            EntityForm entityForm = new EntityForm(
                eventTaskManagement.getStudio().projectManagerTaskCounter, 
                "ProjectManagerTask",
                eventTaskManagement.getStudio().getEntity("projectManager").getAmountOfActivities());
            entityForm.Show();
        }

        private void coderAddTask_Click(object sender, EventArgs e)
        {
            AddEntityForm addEntityForm = new AddEntityForm(eventTaskManagement
                .getStudio()
                .getEntity("coder"));
            addEntityForm.Show();
        }

        private void designerAddTask_Click(object sender, EventArgs e)
        {
            AddEntityForm addEntityForm = new AddEntityForm(eventTaskManagement
                .getStudio()
                .getEntity("designer"));
            addEntityForm.Show();
        }

        private void projectManagerAddTask_Click(object sender, EventArgs e)
        {
            AddEntityForm addEntityForm = new AddEntityForm(eventTaskManagement
                .getStudio()
                .getEntity("projectManager"));
            addEntityForm.Show();
        }
    }
}
