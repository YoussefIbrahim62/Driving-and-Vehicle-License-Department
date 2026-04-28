using DVLD___SharedItems;
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
    public partial class frmAdd_EditPerson : Form
    {
        public frmAdd_EditPerson(clsShared.enPrsnMode FormMode,int PersonId=-10)
        {
            InitializeComponent();

            if(FormMode == clsShared.enPrsnMode.enUpdatingNewPerson)
            {
                lbFormHeader.Text = "Edit Person Information";
                lbPersonId.Text = PersonId.ToString();  
                ctrlAdd_EditPersonInfo1.LoadPersonData(PersonId);
            }
            else
            {
                lbFormHeader.Text = "Add New Person";
                lbPersonId.Text = "N/A";
            }

        }

        private void frmAdd_EditPerson_Load(object sender, EventArgs e)
        {
            lbFormHeader.Left = (this.ClientSize.Width - lbFormHeader.Width) / 2;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
