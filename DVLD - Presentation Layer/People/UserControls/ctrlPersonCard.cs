using DVLD___Business_Layer;
using DVLD___Presentation_Layer.Properties;
using DVLD___SharedItems;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD___Presentation_Layer
{
    public partial class ctrlPersonCard : UserControl
    {
        public int _PersonId { get; set; }

        public ctrlPersonCard()
        {
            InitializeComponent();
        }

        private void _FillPersonData(DataTable PersonData)
        {

            if (PersonData != null && PersonData.Rows.Count > 0)
            {
                lbPersonID.Text = PersonData.Rows[0]["PersonID"].ToString();

                lbNationalNo.Text = PersonData.Rows[0]["NationalNo"].ToString();

                lbFullName.Text = PersonData.Rows[0]["FirstName"].ToString() + " " +
                                  PersonData.Rows[0]["SecondName"].ToString() + " " +
                                  PersonData.Rows[0]["ThirdName"].ToString() + " " +
                                  PersonData.Rows[0]["LastName"].ToString();

                if (PersonData.Rows[0]["Gender"].ToString() == "0")
                {
                    lbGender.Text = "Male";
                    pbGenderIcon.Image = Resources.Man_32;
                    pbPersonImage.Image = Resources.Male_512;
                }
                else
                {
                    lbGender.Text = "Female";
                    pbGenderIcon.Image = Resources.Woman_32;
                    pbPersonImage.Image = Resources.Female_512;
                }

                if (PersonData.Rows[0]["Email"].ToString() == "")
                    lbEmail.Text = "N/A";
                else
                    lbEmail.Text = PersonData.Rows[0]["Email"].ToString();

                lbPhone.Text = PersonData.Rows[0]["Phone"].ToString();

                lbCountry.Text = PersonData.Rows[0]["CountryName"].ToString();

                lbDOB.Text = Convert.ToDateTime(PersonData.Rows[0]["DateOfBirth"]).ToShortDateString();

                lbAddress.Text = PersonData.Rows[0]["Address"].ToString();

                var ImagePath = PersonData.Rows[0]["ImagePath"].ToString();

                if (!string.IsNullOrWhiteSpace(ImagePath) && System.IO.File.Exists(ImagePath))
                    pbPersonImage.ImageLocation = ImagePath;


            }
            

        }



        public void LoadPersonData(int PersnId)
        {
            _PersonId = PersnId;

            DataTable PersonData = clsPerson.GetPersonById(_PersonId);
            _FillPersonData(PersonData);
    
        }

        private void llEditPerson_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmAdd_EditPerson EditPersonForm = new frmAdd_EditPerson(clsShared.enPrsnMode.enUpdatingNewPerson, _PersonId);
            EditPersonForm.ShowDialog();

            LoadPersonData(_PersonId);
        }
    }
}
