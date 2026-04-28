using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD___DataAccess_Layer
{
    public static class clsCountryDataAccess
    {

        public static string GetCountryNameByIdFromDataBase(int CountryId)
        {
            string CountryName = "";

            SqlConnection Connection = new SqlConnection(clsDataSettings.ConnectionString);

            string query = @"select CountryName from Countries where CountryID = @CountryId";

            SqlCommand command = new SqlCommand(query, Connection);

            command.Parameters.AddWithValue("@CountryId", CountryId);

            try
            {
                Connection.Open();
                
                object Result = command.ExecuteScalar();

                if(Result != null)
                    CountryName = Result.ToString();

            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                Connection.Close();
            }

            return CountryName;
        }


        public static DataTable ListAllCountries()
        {
            DataTable CountriesDT = new DataTable();

            SqlConnection Connection = new SqlConnection(clsDataSettings.ConnectionString);

            string query = @"select * from Countries";

            SqlCommand command = new SqlCommand(query, Connection);

            try
            {
                Connection.Open();

                SqlDataReader Reader = command.ExecuteReader();

                CountriesDT.Load(Reader);

            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                Connection.Close();
            }

            return CountriesDT;
        }


        public static int GetCountryIdByNameFromDataBase(string CountryName)
        {
            int CountryId = -1;

            SqlConnection Connection = new SqlConnection(clsDataSettings.ConnectionString);

            string query = @"select CountryID from Countries where CountryName = @CountryName";

            SqlCommand command = new SqlCommand(query, Connection);

            command.Parameters.AddWithValue("@CountryName", CountryName);

            try
            {
                Connection.Open();

                object Result = command.ExecuteScalar();

                if (Result != null && int.TryParse(Result.ToString(),out int CntryID))
                    CountryId = CntryID;

            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                Connection.Close();
            }

            return CountryId;
        }


    }
}
