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
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;


namespace DVLD___Presentation_Layer
{
    public partial class ctrlAdd_EditPersonInfo : UserControl
    {
        public ctrlAdd_EditPersonInfo()
        {
            InitializeComponent();
        }



        

        private DateTime _Deduct_18_YearsFromNow()
        {
            return DateTime.Now.AddYears(-18);
        }

        private DateTime _Deduct_150_YearsFromNow()
        {
            return DateTime.Now.AddYears(-110);

        }

        private void _FillCountryCBWithCountries()
        {
            DataTable countries = clsCountry.ListAllCountries();

            foreach (DataRow row in countries.Rows)
            {
                cbCountrties.Items.Add(row[1]);
            }
        }

        public clsPerson Person = new clsPerson();

        private void ctrlAdd_EditPersonInfo_Load(object sender, EventArgs e)
        {
            _FillCountryCBWithCountries();
            cbCountrties.SelectedIndex = 50;

            dateTimePicker1.MaxDate = _Deduct_18_YearsFromNow();

            dateTimePicker1.MinDate = _Deduct_150_YearsFromNow();

            if(pbPersonPicture.ImageLocation == null)
            {
                if (rbMale.Checked)
                    pbPersonPicture.Image = Resources.Male_512;
                else if(rbFemale.Checked)
                    pbPersonPicture.Image = Resources.Female_512;
                llSetImage.Visible = true;
            }
            else
            {
                llRemoveImage.Visible = true;
                llSetImage.Visible = false;
            }


        }


        private void _ValidateTextBox(TextBox txtBox, CancelEventArgs e)
        {

            if (string.IsNullOrEmpty(txtBox.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtBox, "Must have a value");
            }
            else if (!Regex.IsMatch(txtBox.Text.Trim(), @"^[a-zA-Z]{2,}$"))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtBox, "Enter a valid name; ex:Ahmed");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtBox, "");
            }
        }

        private void tbFirstName_Validating(object sender, CancelEventArgs e)
        {

            _ValidateTextBox(tbFirstName, e);
        }

        private void tbSecondName_Validating(object sender, CancelEventArgs e)
        {
            _ValidateTextBox(tbSecondName, e);
        }

        private void tbLastName_Validating(object sender, CancelEventArgs e)
        {
            _ValidateTextBox(tbLastName, e);
        }

        private void tbNationalNumber_Validating(object sender, CancelEventArgs e)
        {
            string input = tbNationalNumber.Text.Trim();

            if (string.IsNullOrWhiteSpace(input))
            {
                e.Cancel = true;
                errorProvider1.SetError(tbNationalNumber, "Must have a value");
            }
            else if (!Regex.IsMatch(input, @"^N\d+$"))
            {
                e.Cancel = true;
                errorProvider1.SetError(tbNationalNumber, "Invalid format. ex: N1001");
            }
            else if (clsPerson.IsPersonExistedByNationalNumber(input))
            {
                e.Cancel = true;
                errorProvider1.SetError(tbNationalNumber, "This number is used for another person");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(tbNationalNumber, "");
            }
        }


        private void tbEmail_Validating(object sender, CancelEventArgs e)
        {
            if (!(string.IsNullOrWhiteSpace(tbEmail.Text)))
            {
                if (!Regex.IsMatch(tbEmail.Text, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
                {
                    e.Cancel = true;
                    errorProvider1.SetError(tbEmail, "Enter a valid email");
                }
                else
                {
                    e.Cancel = false;
                    errorProvider1.SetError(tbEmail, "");
                }
            }

        }


        private void tbAddress_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(tbAddress.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(tbAddress, "Must have a value");
            }
            else if (tbAddress.Text.Length < 4)
            {
                e.Cancel = true;
                errorProvider1.SetError(tbAddress, "Enter a valid Address; ex:123 Main St");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(tbAddress, "");
            }
        }


        private void tbPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
                return;
            }

            if (char.IsDigit(e.KeyChar)&& tbPhone.Text.Length >= 11)
            {
                e.Handled = true;
            }

        }


        private void tbPhone_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(tbPhone.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(tbPhone,"Must have a value!");
            }
            else if(tbPhone.Text.Length < 11)
            {
                e.Cancel = true;
                errorProvider1.SetError(tbPhone, "Enter a valid phone; ex:01000000000");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(tbPhone, "");
            }



        }


        private void llRemoveImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if(pbPersonPicture.ImageLocation != null)
            {
                string PhotoPath = pbPersonPicture.ImageLocation;

                if (File.Exists(PhotoPath))
                    File.Delete(PhotoPath);

                pbPersonPicture.ImageLocation = null;

                if (rbFemale.Checked)
                    pbPersonPicture.Image = Resources.Female_512;
                else
                    pbPersonPicture.Image = Resources.Male_512;

                llRemoveImage.Visible = false;
                llSetImage.Visible = true;
            }
        }


        private string _CopyImageToCdrive(string PhotoPath)
        {
            string DirectoryPath = @"F:\DVLD Photos";

            if(!Directory.Exists(DirectoryPath))
            {
                Directory.CreateDirectory(DirectoryPath);
            }
            string PhotoExtension = Path.GetExtension(PhotoPath);

            string NewPhotoName = Guid.NewGuid().ToString() + PhotoExtension;

            string DestinationPath = Path.Combine(DirectoryPath, NewPhotoName);

            File.Copy(PhotoPath, DestinationPath, true);
            
            return DestinationPath;
        }

        private void _SetImage()
        {
            openFileDialog1.InitialDirectory = @"C:\Users\Win -11\Pictures";
            openFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";
            openFileDialog1.Title = "Choose a photo";
            openFileDialog1.FileName = "";


            if(openFileDialog1.ShowDialog()==DialogResult.OK)
            {
                pbPersonPicture.ImageLocation = _CopyImageToCdrive(openFileDialog1.FileName);
                pbPersonPicture.Tag = "Photo";
                llRemoveImage.Visible = true;
                llSetImage.Visible = false;
            }

        }


        private void llSetImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            _SetImage();

        }

        private bool _ValidateInputsHaveValues()
        {
            bool valid = false;

            if ((
                  !string.IsNullOrEmpty(tbFirstName.Text)
                && !string.IsNullOrEmpty(tbSecondName.Text)
                && !string.IsNullOrEmpty(tbLastName.Text)
                && !string.IsNullOrEmpty(tbPhone.Text)
                && !string.IsNullOrEmpty(tbAddress.Text)
                && !string.IsNullOrEmpty(tbNationalNumber.Text)
                && (rbFemale.Checked || rbMale.Checked)
                && (cbCountrties.SelectedIndex != -1)
                ))
            {
                valid = true;
            }

            return valid;
        }


        public void LoadPersonData(int PersonId)
        {
            _FillCountryCBWithCountries();

            Person = clsPerson.FindPersonById(PersonId);

            if(Person != null)
            {
                tbNationalNumber.Text = Person.NationalNumber;
                tbNationalNumber.Enabled = false;
                tbFirstName.Text = Person.FirstName;
                tbSecondName.Text = Person.SecondName;
                tbThirdName.Text = Person.ThirdName;
                tbLastName.Text = Person.LastName;
                tbEmail.Text = Person.Email;
                tbAddress.Text = Person.Address;
                tbPhone.Text = Person.Phone;
                dateTimePicker1.Value = Person.DateOfBirth;

                if(Person.Gender == clsShared.enGender.enFemale)
                {
                    rbFemale.Checked = true;
                    rbMale.Checked = false;
                }
                    
                else
                {
                    rbMale.Checked = true;
                    rbFemale.Checked = false;
                }

                
                cbCountrties.SelectedIndex = Person.CountryId - 1;

                if(Person.ImagePath != ""&& File.Exists(Person.ImagePath))
                {

                     pbPersonPicture.ImageLocation = Person.ImagePath;
                     llRemoveImage.Visible = true;
                     llSetImage.Visible = false;
                }
                else
                {
                    if (rbFemale.Checked)
                        pbPersonPicture.Image = Resources.Female_512;
                    else
                        pbPersonPicture.Image = Resources.Male_512;

                    llRemoveImage.Visible = false;
                }
                    
                    
            }
            
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            if(_ValidateInputsHaveValues())
            {
                clsPerson NewPerson = Person;

                NewPerson.FirstName = tbFirstName.Text;
                NewPerson.SecondName = tbSecondName.Text;
                NewPerson.ThirdName = tbThirdName.Text;
                NewPerson.Phone = tbPhone.Text;
                NewPerson.Address = tbAddress.Text;
                NewPerson.NationalNumber = tbNationalNumber.Text;
                NewPerson.Email = tbEmail.Text;

                if(cbCountrties.SelectedIndex != -1)
                    NewPerson.CountryId = cbCountrties.SelectedIndex + 1;

                if (rbFemale.Checked)
                    NewPerson.Gender = clsShared.enGender.enFemale;
                else
                    NewPerson.Gender = clsShared.enGender.enMale;


                if (pbPersonPicture.ImageLocation == null)
                    NewPerson.ImagePath = "";
                else
                    NewPerson.ImagePath = pbPersonPicture.ImageLocation.ToString();

                NewPerson.DateOfBirth = dateTimePicker1.Value;
                NewPerson.LastName = tbLastName.Text;

                if(NewPerson.Save())
                    MessageBox.Show("Data saved successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("Couldn't save the data", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);


            }
            else
            {
                MessageBox.Show("Please Fill the required fields","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
          

        }

        private void rbFemale_CheckedChanged(object sender, EventArgs e)
        {
            if (pbPersonPicture.ImageLocation == null)
            {
                pbPersonPicture.Image = Resources.Female_512;
                rbMale.Checked = false;
            }
                
        }

        private void rbMale_CheckedChanged(object sender, EventArgs e)
        {
            if (pbPersonPicture.ImageLocation == null)
            {
                pbPersonPicture.Image = Resources.Male_512;
                rbFemale.Checked = false;
            }
                
        }


    }
}
