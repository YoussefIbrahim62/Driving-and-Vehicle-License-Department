using DVLD___Business_Layer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD___Presentation_Layer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DataTable dt = clsBusinessLayer.ListAllPeople();

            if (dt.Columns.Count != 0 )
            {
                dataGridView1.DataSource = dt;
            }
            else
            {
                MessageBox.Show("No Available Records");
            }
        }
    }
}
