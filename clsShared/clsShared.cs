using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD___SharedItems
{
    public class clsShared
    {
        public enum enSearchParams
        {
            enAllPeople,
            enPeronsId,
            enNationalId,
            enFirstName,
            enSecondName,
            enThirdName,
            enLastName,
            enCountryId,
            enCountryName,
            enGender,
            enPhone,
            enEmail

        }


        public enum enGender 
        {
            enMale = 0,

            enFemale = 1,
        }

        public enum enPrsnMode
        {
            enAddingNewPerson = 0,
            enUpdatingNewPerson = 1
        }

        public struct stPerson
        {

            public int PersonId;
            public string NationalNumber;
            public string FirstName;
            public string SecondName;
            public string ThirdName;
            public string LastName;
            public DateTime DateOfBirth;
            public enGender Gender;
            public string Address;
            public string Phone;
            public string Email;
            public int CountryId;
            public string ImagePath;

        }





    }
}
