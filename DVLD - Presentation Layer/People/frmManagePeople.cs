using DVLD___Business_Layer;
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
    public partial class frmManagePeople : Form
    {
        public frmManagePeople()
        {
            InitializeComponent();
        }


        private enum enPeopleFilters
        {
            None
            ,Person_ID
            ,National_Number
            ,First_Name
            ,Second_Name
            ,Third_Name
            ,Last_Name
            ,Nationality
            ,Gender
            ,Phone
            ,Email
        }

        private enum enInputMode
        {
            None,
            NumbersOnly,
            LettersOnly
        }


        enInputMode _currentMode = enInputMode.None;


        private void _FillDataGridRowsWithData(DataTable dt)
        {
            DataTable PeopleData = dt;
            if (PeopleData == null || PeopleData.Rows.Count == 0)
            {
                //MessageBox.Show("No Records Available !!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                lbTotalNumberOfRecords.Text = "0";
            }
            else
            {
                foreach (DataRow Row in PeopleData.Rows)
                {
                    if (Row[6].ToString() == "0")
                    {
                        dataGridView1.Rows.Add(Row[0], Row[1], Row[2], Row[3], Row[4], Row[5],
                                            "Male", Row[7], Row[8], Row[9], Row[10]);
                    }
                    else
                    {
                        dataGridView1.Rows.Add(Row[0], Row[1], Row[2], Row[3], Row[4], Row[5],
                                            "Female", Row[7], Row[8], Row[9], Row[10]);
                    }

                }
                lbTotalNumberOfRecords.Text = PeopleData.Rows.Count.ToString();
            }
        }


        private void _FillDataGridWithPeopleData(enPeopleFilters FilterType, string Paramater)
        {
            dataGridView1.Rows.Clear();
            DataTable PeopleData;
                switch (FilterType)
                {

                    case enPeopleFilters.None:
                    {
                        PeopleData = clsPerson.ListAllPeople();
                        _FillDataGridRowsWithData(PeopleData);
                        break;
                    }
                    case enPeopleFilters.Person_ID:
                    {
                        if (int.TryParse(Paramater, out int PrsID))
                        {
                            PeopleData = clsPerson.GetPersonById(PrsID);
                            _FillDataGridRowsWithData(PeopleData);
                        }
                        break;
                    }
                    case enPeopleFilters.National_Number:
                    {
                        PeopleData = clsPerson.ListAllPeopleByNationalId(Paramater);
                        _FillDataGridRowsWithData(PeopleData);
                        break;
                    }
                    case enPeopleFilters.First_Name:
                    {
                        PeopleData = clsPerson.ListAllPeopleByFirstName(Paramater);
                        _FillDataGridRowsWithData(PeopleData);
                        break;
                    }
                    case enPeopleFilters.Second_Name:
                    {
                        PeopleData = clsPerson.ListAllPeopleBySecondName(Paramater);
                        _FillDataGridRowsWithData(PeopleData);
                        break;
                    }
                    case enPeopleFilters.Third_Name:
                    {
                        PeopleData = clsPerson.ListAllPeopleByThirdName(Paramater);
                        _FillDataGridRowsWithData(PeopleData);
                        break;
                    }
                    case enPeopleFilters.Last_Name:
                    {
                        PeopleData = clsPerson.ListAllPeopleByLastName(Paramater);
                        _FillDataGridRowsWithData(PeopleData);
                        break;
                    }
                    case enPeopleFilters.Gender:
                    {

                        if(Enum.TryParse(Paramater, out clsShared.enGender result))
                        {
                            PeopleData = clsPerson.ListAllPeopleByGender(result);
                            _FillDataGridRowsWithData(PeopleData);
                        }
                        break;
                    }
                    case enPeopleFilters.Nationality:
                    {
                        PeopleData = clsPerson.ListAllPeopleByCountryName(Paramater);
                        _FillDataGridRowsWithData(PeopleData);
                        break;
                    }
                    case enPeopleFilters.Phone:
                    {
                        PeopleData = clsPerson.GetPersonByPhoneNumber(Paramater);
                        _FillDataGridRowsWithData(PeopleData);
                        break;
                    }
                    case enPeopleFilters.Email:
                    {
                        PeopleData = clsPerson.GetPersonByEmail(Paramater);
                        _FillDataGridRowsWithData(PeopleData);
                        break;
                    }
                default:
                        break;
                }

        }


        private void _ShowPersonDetails(int PersonId)
        {
            frmPersonDetails personDetails = new frmPersonDetails(PersonId);

            personDetails.ShowDialog();

            _FillDataGridWithPeopleData(enPeopleFilters.None,"");
        }



        private void frmManagePeople_Load(object sender, EventArgs e)
        {
            pictureBox1.Left = (this.ClientSize.Width - pictureBox1.Width) / 2;
            label1.Left = (this.ClientSize.Width - pictureBox1.Width) / 2;
            cbFilters.Text = "None";

        }


        private void _DeletePerson()
        {
            if (dataGridView1.SelectedRows.Count > 0 &&
                int.TryParse(dataGridView1.SelectedRows[0].Cells["dgvColPersonID"].Value.ToString(), out int PrsId))
            {
                if (MessageBox.Show("Are you sure you want to delete this record?", "Careful", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    switch (clsPerson.Delete(PrsId))
                    {
                        case 0:
                            {
                                MessageBox.Show("Person was not deleted because it has linked data to it", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                break;
                            }
                        case 1:
                            {
                                MessageBox.Show("Person was deleted successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                break;
                            }
                        case -1:
                            {
                                MessageBox.Show("Person was not deleted successfully, Please try again later", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                break;
                            }
                        default:
                            break;
                    }

                    _FillDataGridWithPeopleData(enPeopleFilters.None, "");
                    cbFilters.Text = "None";

                }
            }


        }


        private void tbSearchBox_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (_currentMode == enInputMode.NumbersOnly)
            {
                if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                    e.Handled = true;
            }
            else if (_currentMode == enInputMode.LettersOnly)
            {
                if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ' ')
                    e.Handled = true;
            }
        }


        private void tbSearchBox_TextChanged(object sender, EventArgs e)
        {
            if (tbSearchBox.Text == string.Empty)
            {
                _FillDataGridWithPeopleData(enPeopleFilters.None, "");
            }
            else
            {
                switch (cbFilters.Text)
                {
                    case "Person ID":
                        {
                            if (int.TryParse(tbSearchBox.Text, out int PrsID))
                            {
                                _FillDataGridWithPeopleData(enPeopleFilters.Person_ID, PrsID.ToString());
                            }
                            break;
                        }
                    case "National Number":
                        {
                            _FillDataGridWithPeopleData(enPeopleFilters.National_Number, tbSearchBox.Text);
                            break;
                        }
                    case "First Name":
                        {
                            _FillDataGridWithPeopleData(enPeopleFilters.First_Name, tbSearchBox.Text);
                            break;
                        }
                    case "Second Name":
                        {
                            _FillDataGridWithPeopleData(enPeopleFilters.Second_Name, tbSearchBox.Text);
                            break;
                        }
                    case "Third Name":
                        {
                            _FillDataGridWithPeopleData(enPeopleFilters.Third_Name, tbSearchBox.Text);
                            break;
                        }
                    case "Last Name":
                        {
                            _FillDataGridWithPeopleData(enPeopleFilters.Last_Name, tbSearchBox.Text);
                            break;
                        }
                    case "Phone":
                        {
                            _FillDataGridWithPeopleData(enPeopleFilters.Phone, tbSearchBox.Text);
                            break;
                        }
                    case "Nationality":
                        {
                            _FillDataGridWithPeopleData(enPeopleFilters.Nationality, tbSearchBox.Text);
                            break;
                        }
                    case "Email":
                        {
                            _FillDataGridWithPeopleData(enPeopleFilters.Email, tbSearchBox.Text);
                            break;
                        }
                    default:
                        break;
                }
            }

            
        }


        private void rbMale_CheckedChanged(object sender, EventArgs e)
        {
            if (rbMale.Checked)
            {
                _FillDataGridWithPeopleData(enPeopleFilters.Gender, "0");
            }
            else
            {
                if (!rbFemale.Checked)
                {
                    _FillDataGridWithPeopleData(enPeopleFilters.None, "");
                }
            }
        }


        private void rbFemale_CheckedChanged(object sender, EventArgs e)
        {
            if (rbFemale.Checked)
            {
                _FillDataGridWithPeopleData(enPeopleFilters.Gender, "1");
            }
            else
            {
                if (!rbMale.Checked)
                {
                    _FillDataGridWithPeopleData(enPeopleFilters.None, "");
                }
            }
        }


        private void cbFilters_SelectedIndexChanged(object sender, EventArgs e)
        {
            tbSearchBox.Visible = false;
            tbSearchBox.Text = string.Empty;
            tbSearchBox.KeyPress -= tbSearchBox_KeyPress;

            plGender.Visible = false;
            rbFemale.Checked = false;
            rbMale.Checked = false;


            switch (cbFilters.Text)
            {
                    case "None":
                    {
                        _FillDataGridWithPeopleData(enPeopleFilters.None, "");
                        break;
                    }
                    case "Person ID":
                    {
                        tbSearchBox.Visible = true;
                        _currentMode = enInputMode.NumbersOnly;
                        tbSearchBox.KeyPress += tbSearchBox_KeyPress;      
                        break;
                    }
                case "National Number":
                    {
                        tbSearchBox.Visible = true;
                        break;
                    }
                case "First Name":
                    {
                        tbSearchBox.Visible = true;
                        _currentMode = enInputMode.LettersOnly;
                        tbSearchBox.KeyPress += tbSearchBox_KeyPress;
                        break;
                    }
                case "Second Name":
                    {
                        tbSearchBox.Visible = true;
                        _currentMode = enInputMode.LettersOnly;
                        tbSearchBox.KeyPress += tbSearchBox_KeyPress;
                        break;
                    }
                case "Third Name":
                    {
                        tbSearchBox.Visible = true;
                        _currentMode = enInputMode.LettersOnly;
                        tbSearchBox.KeyPress += tbSearchBox_KeyPress;
                        break;
                    }
                case "Last Name":
                    {
                        tbSearchBox.Visible = true;
                        _currentMode = enInputMode.LettersOnly;
                        tbSearchBox.KeyPress += tbSearchBox_KeyPress;
                        break;
                    }
                case "Nationality":
                    {
                        tbSearchBox.Visible = true;
                        _currentMode = enInputMode.LettersOnly;
                        tbSearchBox.KeyPress += tbSearchBox_KeyPress;
                        break;
                    }
                case "Gender":
                    {
                        plGender.Visible = true;
                        break;
                    }
                case "Phone":
                    {
                        tbSearchBox.Visible = true;
                        _currentMode = enInputMode.NumbersOnly;
                        tbSearchBox.KeyPress += tbSearchBox_KeyPress;
                        break;
                    }
                case "Email":
                    {
                        tbSearchBox.Visible = true;
                        break;
                    }

                default:
                    break;
            }



        }


        private void msiShowDetails_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                if (int.TryParse(dataGridView1.SelectedRows[0].Cells["dgvColPersonID"].Value.ToString(), out int PrsId))
                    _ShowPersonDetails(PrsId);


            }

                
        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }


        private void msiSendEmail_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This feature is not implemented yet!","Careful",MessageBoxButtons.OK,MessageBoxIcon.Warning);
        }


        private void msiPhoneCall_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This feature is not implemented yet!", "Careful", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        }


        private void msiDelete_Click(object sender, EventArgs e)
        {
            _DeletePerson();

        }


        private void _AddNewPerson()
        {
            frmAdd_EditPerson AddNewPerson = new frmAdd_EditPerson(clsShared.enPrsnMode.enAddingNewPerson);

            AddNewPerson.ShowDialog();
            _FillDataGridWithPeopleData(enPeopleFilters.None, "");
            cbFilters.Text = "None";
        }

        private void btnAddPerson_Click(object sender, EventArgs e)
        {
            _AddNewPerson();

        }

        private void msiAddNewPerson_Click(object sender, EventArgs e)
        {
            _AddNewPerson();
        }


        private void _EditPersonData()
        {
            if (dataGridView1.SelectedRows.Count > 0 &&
int.TryParse(dataGridView1.SelectedRows[0].Cells["dgvColPersonID"].Value.ToString(), out int PrsId))
            {
                frmAdd_EditPerson EditPersonData = new frmAdd_EditPerson(clsShared.enPrsnMode.enUpdatingNewPerson, PrsId);

                EditPersonData.ShowDialog();

                _FillDataGridWithPeopleData(enPeopleFilters.None, "");
                cbFilters.Text = "None";
            }
        }

        private void msiEdit_Click(object sender, EventArgs e)
        {
            _EditPersonData();
        }


    }
}
