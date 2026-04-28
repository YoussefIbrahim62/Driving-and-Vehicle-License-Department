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
    public partial class MainAppForm : Form
    {
        public MainAppForm()
        {
            InitializeComponent();
        }

        private void MainAppForm_Load(object sender, EventArgs e)
        {
            pictureBox1.BackColor = Color.FromArgb(146, 147, 152);
        }

        private void peopleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManagePeople ManagePeopleForm = new frmManagePeople();

            ManagePeopleForm.ShowDialog();
        }


    }
}
