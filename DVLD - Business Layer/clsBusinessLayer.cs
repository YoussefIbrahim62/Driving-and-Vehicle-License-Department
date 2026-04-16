using DVLD___DataAccess_Layer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD___Business_Layer
{
    public static class clsBusinessLayer
    {


        public static DataTable ListAllPeople()
        {
            return clsDataAccess.GetAllPeopleFromDataBase();
        }


    }
}
