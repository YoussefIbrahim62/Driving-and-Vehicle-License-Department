using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;



namespace DVLD___DataAccess_Layer
{
    public static class clsDataAccess
    {


        public static DataTable GetAllPeopleFromDataBase()
        {
            SqlConnection Connection = new SqlConnection(clsDataSettings.ConnectionString);

            string query = "select * from People";

            SqlCommand Command = new SqlCommand(query, Connection);

            DataTable dataTable = new DataTable();


            try
            {
                Connection.Open();

                SqlDataReader reader = Command.ExecuteReader();

                dataTable.Load(reader);

                reader.Close();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Connection.Close();
            }

            return dataTable;


        }



    }
}
