using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        public EventTaskManagement eventTaskManagement;
        public Form1()
        {
            eventTaskManagement = EventTaskManagement.getInstance(new CoderEntity(),
                new DesignerEntity(),
                new ProjectManagerEntity());
            runningRandomTask += eventTaskManagement.runEventHendler;

            InitializeComponent();
        }

        private void runSimulation_Click(object sender, EventArgs e)
        {
            runningRandomTask.Invoke(logBox);
        }
    }
}
