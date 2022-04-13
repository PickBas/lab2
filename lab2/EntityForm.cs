using System;
using System.Data;
using System.Windows.Forms;

namespace lab2
{
    public partial class EntityForm : Form
    {
        public EntityForm()
        {
            InitializeComponent();
            DataTable table = new DataTable();
            table.Columns.Add("#");
            table.Columns.Add("Type");
            table.Columns.Add("Description");
            table.Columns.Add("%");
            table.Columns.Add("LastTimeCalled");
            DataRow dr = table.NewRow();
            dr["#"] = "100";
            dr["Type"] = "ProjectManagerTask";
            dr["Description"] = "Analyze designer performance";
            dr["%"] = "100";
            dr["LastTimeCalled"] = DateTime.Now.ToString();
            table.Rows.Add(dr);
            dataGridView1.DataSource = table;
            dataGridView1.Columns[0].Width = 30;
            dataGridView1.Columns[1].Width = 115;
            dataGridView1.Columns[2].Width = 200;
            dataGridView1.Columns[3].Width = 30;
            dataGridView1.Columns[4].Width = 130;
        }
    }
}