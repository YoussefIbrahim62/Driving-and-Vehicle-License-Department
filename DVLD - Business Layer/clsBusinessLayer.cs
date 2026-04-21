using DVLD___DataAccess_Layer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVLD___SharedItems;


namespace DVLD___Business_Layer
{
    public static class clsBusinessLayer
    {
        public enum enSearchParams
        {
            enNationalId,
            enFirstName,
            enSecondName,
            enThirdName,
            enLastName,
            enCountry,
            enGender

        }


        public static DataTable GetPersonById(int id)
        {
            return clsDataAccess.GetAllPeopleFromDataBaseByParameter(clsShared.enSearchParams.enPeronsId, id.ToString());

        }


        public static DataTable GetPersonByPhoneNumber(string PhoneNumber)
        {
            return clsDataAccess.GetAllPeopleFromDataBaseByParameter(clsShared.enSearchParams.enPhone, PhoneNumber);
        }


        public static DataTable GetPersonByEmail(string Email)
        {
            return clsDataAccess.GetAllPeopleFromDataBaseByParameter(clsShared.enSearchParams.enEmail, Email);
        }


        public static DataTable ListAllPeople()
        {
            return clsDataAccess.GetAllPeopleFromDataBaseByParameter(clsShared.enSearchParams.enAllPeople, "");
        }


        public static DataTable ListAllPeopleByNationalId(string NationalId)
        {
            return clsDataAccess.GetAllPeopleFromDataBaseByParameter(clsShared.enSearchParams.enNationalId,NationalId);
        }


        public static DataTable ListAllPeopleByFirstName(string FirstName)
        {
            return clsDataAccess.GetAllPeopleFromDataBaseByParameter(clsShared.enSearchParams.enFirstName, FirstName);
        }


        public static DataTable ListAllPeopleBySecondName(string SecondName)
        {
            return clsDataAccess.GetAllPeopleFromDataBaseByParameter(clsShared.enSearchParams.enSecondName, SecondName);
        }


        public static DataTable ListAllPeopleByThirdName(string ThirdName)
        {
            return clsDataAccess.GetAllPeopleFromDataBaseByParameter(clsShared.enSearchParams.enThirdName, ThirdName);
        }


        public static DataTable ListAllPeopleByLastName(string LastName)
        {
            return clsDataAccess.GetAllPeopleFromDataBaseByParameter(clsShared.enSearchParams.enLastName, LastName);
        }


        public static DataTable ListAllPeopleByGender(clsShared.enGender Gender)
        {

            if(Gender == clsShared.enGender.enMale) 
                return clsDataAccess.GetAllPeopleFromDataBaseByParameter(clsShared.enSearchParams.enGender, clsShared.enGender.enMale.ToString());
            else
                return clsDataAccess.GetAllPeopleFromDataBaseByParameter(clsShared.enSearchParams.enGender, clsShared.enGender.enFemale.ToString());
        }


        public static DataTable ListAllPeopleByCountryID(int CountryId)
        {
            return clsDataAccess.GetAllPeopleFromDataBaseByParameter(clsShared.enSearchParams.enCountry, CountryId.ToString());
        }







    }
}
