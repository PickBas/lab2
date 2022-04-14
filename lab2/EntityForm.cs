using System;
using System.Data;
using System.Windows.Forms;
using lab2.Studio;

namespace lab2
{
    public partial class EntityForm : Form
    {
        public EntityForm(CounterManagement counterManagement, string type, int amountOfActivities)
        {
            InitializeComponent();
            label2.Text += amountOfActivities;
            DataTable table = new DataTable();
            table.Columns.Add("#");
            table.Columns.Add("Type");
            table.Columns.Add("Description");
            table.Columns.Add("%");
            table.Columns.Add("LastTimeCalled");
            var tasks = counterManagement.getProbability();
            for (int i = 0; i < tasks.Count; ++i)
            {
                DataRow dr = table.NewRow();
                dr["#"] = (i + 1).ToString();
                dr["Type"] = type;
                dr["Description"] = tasks[i].Item2.getDescription();
                dr["%"] = tasks[i].Item1.ToString();
                dr["LastTimeCalled"] = counterManagement.getTasksWithDateTime()[i].Item1.ToString();
                table.Rows.Add(dr);
            }
            dataGridView1.DataSource = table;
            dataGridView1.Columns[0].Width = 30;
            dataGridView1.Columns[1].Width = 115;
            dataGridView1.Columns[2].Width = 200;
            dataGridView1.Columns[3].Width = 30;
            dataGridView1.Columns[4].Width = 130;
        }
    }
}