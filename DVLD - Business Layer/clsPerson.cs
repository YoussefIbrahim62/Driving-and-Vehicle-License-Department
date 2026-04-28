using DVLD___DataAccess_Layer;
using DVLD___SharedItems;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;


namespace DVLD___Business_Layer
{
    public class clsPerson
    {
        public enum enMode
        {
            NewPersonMode,
            UpdateMode
        }


        public enMode PersonMode = enMode.NewPersonMode;

        public int PersonId {  get; set; }
        public string NationalNumber { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string ThirdName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public clsShared.enGender Gender { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int CountryId { get; set; }
        public string ImagePath { get; set; }


        public clsPerson()
        {

            
            this.NationalNumber = "";
            this.FirstName = "";
            this.SecondName = "";
            this.ThirdName = "";
            this.LastName = "";
            this.DateOfBirth = DateTime.MinValue;
            this.Gender = clsShared.enGender.enMale;
            this.Address = "";
            this.Phone = "";
            this.Email = "";
            this.CountryId = 0;
            this.ImagePath = "";
            this.PersonMode = enMode.NewPersonMode;

        }


        private clsPerson(
            int personId,
            string nationalNumber,
            string firstName,
            string secondName,
            string thirdName,
            string lastName,
            DateTime dateOfBirth,
            clsShared.enGender gender,
            string address,
            string phone,
            string email,
            int countryId,
            string imagePath)
        {
            this.PersonId = personId;
            this.NationalNumber = nationalNumber;
            this.FirstName = firstName;
            this.SecondName = secondName;
            this.ThirdName = thirdName;
            this.LastName = lastName;
            this.DateOfBirth = dateOfBirth;
            this.Gender = gender;
            this.Address = address;
            this.Phone = phone;
            this.Email = email;
            this.CountryId = countryId;
            this.ImagePath = imagePath;
            this.PersonMode = enMode.UpdateMode;
        }


        #region Private Helper functions


        private bool _IsAgeLessThan18(DateTime PersonDOB)
        {
            bool _IsLessThan18 = false;

            int age = DateTime.Now.Year - PersonDOB.Year;

            if (DateTime.Now < PersonDOB.AddYears(age))
                age--;

            if(age < 18)
                _IsLessThan18 = true;

            return _IsLessThan18;
        }


        private bool _ValidatePersonDataForAddingNewPerson(clsPerson clsprson)
        {
            bool _IsValid;

            if (string.IsNullOrWhiteSpace(clsprson.NationalNumber) ||
                IsPersonExistedByNationalNumber(clsprson.NationalNumber) ||
                string.IsNullOrWhiteSpace(clsprson.FirstName) ||
                string.IsNullOrWhiteSpace(clsprson.SecondName) ||
                string.IsNullOrWhiteSpace(clsprson.LastName) ||
                string.IsNullOrWhiteSpace(clsprson.Address) ||
                string.IsNullOrWhiteSpace(clsprson.Phone) ||
                clsprson.DateOfBirth == DateTime.MinValue||
                    _IsAgeLessThan18(clsprson.DateOfBirth))

            {
                _IsValid = false;
            }
            else
                _IsValid = true;


            return _IsValid;

        }


        private bool _ValidatePersonDataForUpdatingPerson(clsPerson clsprson)
        {
            bool _IsValid;

            clsPerson CompareNationalNumberPerson = FindPersonById(clsprson.PersonId);

            if(CompareNationalNumberPerson!= null )
            {
                if(CompareNationalNumberPerson.NationalNumber != clsprson.NationalNumber)
                    return false;
            }



            if (string.IsNullOrWhiteSpace(clsprson.NationalNumber) ||
                string.IsNullOrWhiteSpace(clsprson.FirstName) ||
                string.IsNullOrWhiteSpace(clsprson.SecondName) ||
                string.IsNullOrWhiteSpace(clsprson.LastName) ||
                string.IsNullOrWhiteSpace(clsprson.Address) ||
                string.IsNullOrWhiteSpace(clsprson.Phone) ||
                clsprson.DateOfBirth == DateTime.MinValue ||
                    _IsAgeLessThan18(clsprson.DateOfBirth))

            {
                _IsValid = false;
            }
            else
                _IsValid = true;


            return _IsValid;

        }


        private clsShared.stPerson _FillStPersonWithClsPersonData(clsPerson clsprson)
        {
            clsShared.stPerson NewPerson = new clsShared.stPerson();

            if(clsprson.PersonMode == enMode.UpdateMode)
                NewPerson.PersonId = clsprson.PersonId;

            NewPerson.FirstName = clsprson.FirstName;
            NewPerson.SecondName = clsprson.SecondName;
            NewPerson.ThirdName = clsprson.ThirdName;
            NewPerson.LastName = clsprson.LastName;
            NewPerson.Address = clsprson.Address;

            NewPerson.Phone = clsprson.Phone;
            NewPerson.Email = clsprson.Email;
            NewPerson.Gender = clsprson.Gender;
            NewPerson.ImagePath = clsprson.ImagePath;
            NewPerson.DateOfBirth = clsprson.DateOfBirth;
            NewPerson.NationalNumber = clsprson.NationalNumber;
            NewPerson.CountryId = clsprson.CountryId;

            return NewPerson;

        }


        private bool _AddNewUser()
        {
            if (_ValidatePersonDataForAddingNewPerson(this))
            {
                clsShared.stPerson NewPerson = _FillStPersonWithClsPersonData(this);

                int NewId = clsPersonDataAccess.AddNewPersonInDataBase(NewPerson);

                return (NewId != -1);

            }
            else
                return false;

        }



        private bool _UpdateUser()
        {
            if (_ValidatePersonDataForUpdatingPerson(this))
            {
                clsShared.stPerson UpdatedPersonInfo = _FillStPersonWithClsPersonData(this);

                return clsPersonDataAccess.UpdatePersonInfoInDataBase(UpdatedPersonInfo);

            }
            return false;
        }



        #endregion




        public static clsPerson FindPersonById(int PersonID)
        {
            clsShared.stPerson Person = new clsShared.stPerson();

            if(clsPersonDataAccess.FindPersonByIdInDataBase(PersonID, ref Person))
            {

                return new clsPerson
                    (
                    Person.PersonId,
                    Person.NationalNumber,
                    Person.FirstName,
                    Person.LastName,
                    Person.ThirdName,
                    Person.LastName,
                    Person.DateOfBirth,
                    Person.Gender,
                    Person.Address,
                    Person.Phone,
                    Person.Email,
                    Person.CountryId,
                    Person.ImagePath
                    );

            }
            else
                return null;

        }


        public static bool IsPersonExistedByNationalNumber(string NationalNumber)
        {
            return clsPersonDataAccess.IsPersonExisted(NationalNumber);
        }


        public static int Delete(int PersonId)
        {
            return clsPersonDataAccess.DeletePersonFromDataBaseByPersonId(PersonId);
        }




        public bool Save()
        {
            switch (this.PersonMode)
            {
                case enMode.NewPersonMode:
                    {
                        if(_AddNewUser())
                        {
                            this.PersonMode = enMode.UpdateMode;
                            return true;
                        }
                        return false;
                    }
                case enMode.UpdateMode:
                    {
                        return _UpdateUser();
                    }
                default:
                    return false;
            }


        }





        #region Get Data From Database 

        public static DataTable GetPersonById(int id)
        {
            return clsPersonDataAccess.GetAllPeopleFromDataBaseByParameter(clsShared.enSearchParams.enPeronsId, id.ToString());

        }


        public static DataTable GetPersonByPhoneNumber(string PhoneNumber)
        {
            return clsPersonDataAccess.GetAllPeopleFromDataBaseByParameter(clsShared.enSearchParams.enPhone, PhoneNumber);
        }


        public static DataTable GetPersonByEmail(string Email)
        {
            return clsPersonDataAccess.GetAllPeopleFromDataBaseByParameter(clsShared.enSearchParams.enEmail, Email);
        }


        public static DataTable ListAllPeople()
        {

            return clsPersonDataAccess.GetAllPeopleFromDataBaseByParameter(clsShared.enSearchParams.enAllPeople, "");
        }


        public static DataTable ListAllPeopleByNationalId(string NationalId)
        {
            return clsPersonDataAccess.GetAllPeopleFromDataBaseByParameter(clsShared.enSearchParams.enNationalId, NationalId);
        }


        public static DataTable ListAllPeopleByFirstName(string FirstName)
        {
            return clsPersonDataAccess.GetAllPeopleFromDataBaseByParameter(clsShared.enSearchParams.enFirstName, FirstName);
        }


        public static DataTable ListAllPeopleBySecondName(string SecondName)
        {
            return clsPersonDataAccess.GetAllPeopleFromDataBaseByParameter(clsShared.enSearchParams.enSecondName, SecondName);
        }


        public static DataTable ListAllPeopleByThirdName(string ThirdName)
        {
            return clsPersonDataAccess.GetAllPeopleFromDataBaseByParameter(clsShared.enSearchParams.enThirdName, ThirdName);
        }


        public static DataTable ListAllPeopleByLastName(string LastName)
        {
            return clsPersonDataAccess.GetAllPeopleFromDataBaseByParameter(clsShared.enSearchParams.enLastName, LastName);
        }


        public static DataTable ListAllPeopleByGender(clsShared.enGender Gender)
        {

            if (Gender == clsShared.enGender.enMale)
                return clsPersonDataAccess.GetAllPeopleFromDataBaseByParameter(clsShared.enSearchParams.enGender, clsShared.enGender.enMale.ToString());
            else
                return clsPersonDataAccess.GetAllPeopleFromDataBaseByParameter(clsShared.enSearchParams.enGender, clsShared.enGender.enFemale.ToString());
        }


        public static DataTable ListAllPeopleByCountryID(int CountryId)
        {
            return clsPersonDataAccess.GetAllPeopleFromDataBaseByParameter(clsShared.enSearchParams.enCountryId, CountryId.ToString());
        }


        public static DataTable ListAllPeopleByCountryName(string CountryName)
        {
            return clsPersonDataAccess.GetAllPeopleFromDataBaseByParameter(clsShared.enSearchParams.enCountryName, CountryName);
        }

        #endregion




    }







}
