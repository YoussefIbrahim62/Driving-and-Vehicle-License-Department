using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using DVLD___SharedItems;



namespace DVLD___DataAccess_Layer
{
    public static class clsDataAccess
    {

        private static SqlCommand _GenerateCommand(clsShared.enSearchParams SearchParameter, string Parameter, SqlConnection Connection)
        {
            SqlCommand Command = new SqlCommand();
            Command.Connection = Connection;

            switch (SearchParameter)
            {
                case (clsShared.enSearchParams.enAllPeople):
                    {
                        Command.CommandText = "select * from People";
                        return Command;
                    }
                case (clsShared.enSearchParams.enPeronsId):
                    {
                        Command.CommandText = "select * from People where PersonID = @PersonID";

                        if (int.TryParse(Parameter, out int personID))
                            Command.Parameters.AddWithValue("@PersonID", personID);
                        else
                            Command.Parameters.AddWithValue("@PersonID", -1);

                        return Command;
                    }
                case (clsShared.enSearchParams.enNationalId):
                    {
                        Command.CommandText = "select * from People where NationalNo Like '' + @NationalId + '%'";
                        Command.Parameters.AddWithValue("@NationalId", Parameter);

                        return Command;
                    }
                case (clsShared.enSearchParams.enFirstName):
                    {
                        Command.CommandText = "select * from People where FirstName Like '' + @FirstName + '%'";
                        Command.Parameters.AddWithValue("@FirstName", Parameter);

                        return Command;
                    }
                case (clsShared.enSearchParams.enSecondName):
                    {
                        Command.CommandText = "select * from People where SecondName Like '' + @SecondName + '%'";
                        Command.Parameters.AddWithValue("@SecondName", Parameter);

                        return Command;
                    }
                case (clsShared.enSearchParams.enThirdName):
                    {
                        Command.CommandText = "select * from People where ThirdName Like '' + @ThirdName + '%'";
                        Command.Parameters.AddWithValue("@ThirdName", Parameter);

                        return Command;
                    }
                case (clsShared.enSearchParams.enLastName):
                    {
                        Command.CommandText = "select * from People where LastName Like '' + @LastName + '%'";
                        Command.Parameters.AddWithValue("@LastName", Parameter);

                        return Command;
                    }
                case (clsShared.enSearchParams.enGender):
                    {
                        if (Parameter == clsShared.enGender.enMale.ToString())
                            Command.CommandText = "select * from People where Gender = 0;";
                        else if (Parameter == clsShared.enGender.enFemale.ToString())
                            Command.CommandText = "select * from People where Gender = 1";

                        return Command;
                    }
                case (clsShared.enSearchParams.enCountry):
                    {
                        Command.CommandText = "select * from People where NationalityCountryID = @CountryId";

                        if (int.TryParse(Parameter, out int CountryId))
                            Command.Parameters.AddWithValue("@CountryId", CountryId);
                        else
                            Command.Parameters.AddWithValue("@CountryId", -1);

                        return Command;
                    }
                case (clsShared.enSearchParams.enPhone):
                    {
                        Command.CommandText = "select * from People where Phone = @PhoneNumber";

                        Command.Parameters.AddWithValue("@PhoneNumber", Parameter);

                        return Command;
                    }
                case (clsShared.enSearchParams.enEmail):
                    {
                        Command.CommandText = "select * from People where Email = @Email";

                        Command.Parameters.AddWithValue("@Email", Parameter);

                        return Command;
                    }

                default:
                    return Command;
            }

        }



        public static DataTable GetAllPeopleFromDataBaseByParameter(clsShared.enSearchParams SearchParameter, string Parameter)
        {
            SqlConnection Connection = new SqlConnection(clsDataSettings.ConnectionString);


            SqlCommand Command = _GenerateCommand(SearchParameter, Parameter, Connection);


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
