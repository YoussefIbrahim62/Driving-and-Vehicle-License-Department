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
using static DVLD___SharedItems.clsShared;

namespace DVLD___Presentation_Layer
{
    public partial class TestForm : Form
    {
        public TestForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //clsPerson TestPerson = clsPerson.FindPersonById(1028);

            //if (TestPerson != null)
            //{
            //    tbID.Text = TestPerson.PersonId.ToString();
            //    tbNationalId.Text = TestPerson.NationalNumber;
            //    tbFirstName.Text = TestPerson.FirstName;
            //    tbSecondName.Text = TestPerson.SecondName;
            //    tbThridName.Text = TestPerson.ThirdName;    
            //    tbLastName.Text = TestPerson.LastName;
            //    tbEmail.Text = TestPerson.Email;
            //    tbPhone.Text = TestPerson.Phone;
            //    tbAddress.Text = TestPerson.Address;
            //    tbDOB.Text = TestPerson.DateOfBirth.ToString();
            //    tbGender.Text = TestPerson.Gender.ToString();
            //    tbCountryId.Text = TestPerson.CountryId.ToString();
            //    tbImagePath.Text = TestPerson.ImagePath;

            //}

            DataTable countries = clsCountry.ListAllCountries();

            foreach (DataRow row in countries.Rows)
            {
                comboBox1.Items.Add(row[1]);
            }

            //tbCountryId.Text = clsCountry.GetCountryNameById(102);

            tbCountryId.Text = clsCountry.GetCountryId("Egypt").ToString();

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (comboBox1.Text == "Gender")
            //{
            //    DataTable dt = clsPerson.ListAllPeopleByGender(clsShared.enGender.enFemale);

            //    if (dt.Rows.Count != 0)
            //    {
            //        dataGridView1.DataSource = dt;
            //    }
            //    else
            //    {
            //        MessageBox.Show("No Available Records");
            //    }
            //}


        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //if(!string.IsNullOrEmpty(tbFirstName.Text))
            //{
            //    DataTable dt = clsPerson.GetPersonByEmail(tbFirstName.Text);

            //    if (dt.Rows.Count != 0)
            //    {
            //        dataGridView1.DataSource = dt;
            //    }
            //    else
            //    {
            //        dataGridView1.DataSource = null;
            //    }


            //}


        }

        private void btnAddPerson_Click(object sender, EventArgs e)
        {

            //if(clsPerson.IsPersonExistedByNationalNumber(tbNationalId.Text))
            //{
            //    MessageBox.Show("This NationalId alreayd exits");
            //}
            //else
            //{
            //    clsPerson TestPerson = new clsPerson();

            //    TestPerson.NationalNumber = tbNationalId.Text;
            //    TestPerson.FirstName = tbFirstName.Text;
            //    TestPerson.SecondName = tbSecondName.Text;
            //    TestPerson.ThirdName = tbThridName.Text;
            //    TestPerson.LastName = tbLastName.Text;
            //    TestPerson.Email = tbEmail.Text;
            //    TestPerson.Phone = tbPhone.Text;
            //    TestPerson.Address = tbAddress.Text;
            //    TestPerson.DateOfBirth = dateTimePicker1.Value;
            //    TestPerson.Gender = (clsShared.enGender)Enum.Parse(typeof(clsShared.enGender), tbGender.Text);
            //    TestPerson.CountryId = int.Parse(tbCountryId.Text);
            //    TestPerson.ImagePath = tbImagePath.Text;

            //    if(TestPerson.Save())
            //    {
            //        MessageBox.Show("Person Added succesfully");
            //    }
            //    else
            //    {
            //        MessageBox.Show("Couldn't add it please try again");
            //    }


            //}






        }

        private void button1_Click(object sender, EventArgs e)
        {
            //clsPerson TestPerson = clsPerson.FindPersonById(1035);


            //    TestPerson.NationalNumber = tbNationalId.Text;
            //    TestPerson.FirstName = tbFirstName.Text;
            //    TestPerson.SecondName = tbSecondName.Text;
            //    TestPerson.ThirdName = tbThridName.Text;
            //    TestPerson.LastName = tbLastName.Text;
            //    TestPerson.Email = tbEmail.Text;
            //    TestPerson.Phone = tbPhone.Text;
            //    TestPerson.Address = tbAddress.Text;
            //    TestPerson.DateOfBirth = dateTimePicker1.Value;
            //    TestPerson.Gender = (clsShared.enGender)Enum.Parse(typeof(clsShared.enGender), tbGender.Text);
            //    TestPerson.CountryId = int.Parse(tbCountryId.Text);
            //    TestPerson.ImagePath = tbImagePath.Text;

            //    if (TestPerson.Save())
            //    {
            //        MessageBox.Show("Person updated succesfully");
            //    }
            //    else
            //    {
            //        MessageBox.Show("Couldn't update it please try again");
            //    }

            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //clsPerson TestPerson = clsPerson.FindPersonById(109);

            //if (TestPerson != null)
            //{
            //    tbID.Text = TestPerson.PersonId.ToString();
            //    tbNationalId.Text = TestPerson.NationalNumber;
            //    tbFirstName.Text = TestPerson.FirstName;
            //    tbSecondName.Text = TestPerson.SecondName;
            //    tbThridName.Text = TestPerson.ThirdName;
            //    tbLastName.Text = TestPerson.LastName;
            //    tbEmail.Text = TestPerson.Email;
            //    tbPhone.Text = TestPerson.Phone;
            //    tbAddress.Text = TestPerson.Address;
            //    tbDOB.Text = TestPerson.DateOfBirth.ToString();
            //    tbGender.Text = TestPerson.Gender.ToString();
            //    tbCountryId.Text = TestPerson.CountryId.ToString();
            //    tbImagePath.Text = TestPerson.ImagePath;
            //}

        }

        private void button3_Click(object sender, EventArgs e)
        {
            //int Result = clsPerson.Delete(int.Parse(tbID.Text));

            //switch (Result)
            //{
            //    case 1:
            //        MessageBox.Show("Deleted Successfully");
            //        break;
            //    case -1:
            //        MessageBox.Show("Couldn't delete it");
            //        break;
            //    case 0:
            //        MessageBox.Show("Couldn't delete it becasue it has data linked to it");
            //        break;

            //}


        }
    }
}
