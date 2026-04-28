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
    public partial class frmPersonDetails : Form
    {
        public int _PersonId { get; set; }

        public frmPersonDetails(int personID)
        {
            InitializeComponent();
            _PersonId = personID;

            lbFormHeader.Left = (this.ClientSize.Width - lbFormHeader.Width) / 2;
            groupBox1.Left = (this.ClientSize.Width - groupBox1.Width) / 2;

        }

        private void frmPersonDetails_Load(object sender, EventArgs e)
        {
            ctrlPersonCard1.LoadPersonData(_PersonId);

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
