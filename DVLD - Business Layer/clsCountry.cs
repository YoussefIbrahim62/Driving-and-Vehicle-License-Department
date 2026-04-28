using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVLD___DataAccess_Layer;
using DVLD___SharedItems;

namespace DVLD___Business_Layer
{
    public class clsCountry
    {
        public int CountryId {  get; set; }

        public string CountryName { get; set; }


        public static DataTable ListAllCountries()
        {
            return clsCountryDataAccess.ListAllCountries();
        }

        public static string GetCountryNameById(int CountryId)
        {
            return clsCountryDataAccess.GetCountryNameByIdFromDataBase(CountryId);
        }

        public static int GetCountryId(string CountryName)
        {
            return clsCountryDataAccess.GetCountryIdByNameFromDataBase(CountryName);
        }

    }
}
