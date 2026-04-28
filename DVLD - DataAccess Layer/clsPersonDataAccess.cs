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
    public static class clsPersonDataAccess
    {


        private static string _SelectInnerJoinQuery()
        {
            string SubQuery = @"select P.PersonID,P.NationalNo,P.FirstName,
		P.SecondName,P.ThirdName,P.LastName,
		P.Gender, P.DateOfBirth, Countries.CountryName,
		P.Phone, P.Email,P.Address,P.ImagePath
from People as P
inner join Countries
on p.NationalityCountryID = Countries.CountryID";

            return SubQuery;
        }


        private static SqlCommand _GenerateCommand(clsShared.enSearchParams SearchParameter, string Parameter, SqlConnection Connection)
        {
            SqlCommand Command = new SqlCommand();
            Command.Connection = Connection;

            switch (SearchParameter)
            {
                case (clsShared.enSearchParams.enAllPeople):
                    {
                        Command.CommandText = _SelectInnerJoinQuery();
                        return Command;
                    }
                case (clsShared.enSearchParams.enPeronsId):
                    {
                        Command.CommandText = $"{_SelectInnerJoinQuery()} where PersonID = @PersonID";

                        if (int.TryParse(Parameter, out int personID))
                            Command.Parameters.AddWithValue("@PersonID", personID);
                        else
                            Command.Parameters.AddWithValue("@PersonID", -1);

                        return Command;
                    }
                case (clsShared.enSearchParams.enNationalId):
                    {
                        Command.CommandText = $"{_SelectInnerJoinQuery()} where NationalNo Like '' + @NationalId + '%'";
                        Command.Parameters.AddWithValue("@NationalId", Parameter);

                        return Command;
                    }
                case (clsShared.enSearchParams.enFirstName):
                    {
                        Command.CommandText = $"{_SelectInnerJoinQuery()} where FirstName Like '' + @FirstName + '%'";
                        Command.Parameters.AddWithValue("@FirstName", Parameter);

                        return Command;
                    }
                case (clsShared.enSearchParams.enSecondName):
                    {
                        Command.CommandText = $"{_SelectInnerJoinQuery()} where SecondName Like '' + @SecondName + '%'";
                        Command.Parameters.AddWithValue("@SecondName", Parameter);

                        return Command;
                    }
                case (clsShared.enSearchParams.enThirdName):
                    {
                        Command.CommandText = $"{_SelectInnerJoinQuery()} where ThirdName Like '' + @ThirdName + '%'";
                        Command.Parameters.AddWithValue("@ThirdName", Parameter);

                        return Command;
                    }
                case (clsShared.enSearchParams.enLastName):
                    {
                        Command.CommandText = $"{_SelectInnerJoinQuery()} where LastName Like '' + @LastName + '%'";
                        Command.Parameters.AddWithValue("@LastName", Parameter);

                        return Command;
                    }
                case (clsShared.enSearchParams.enGender):
                    {
                        if (Parameter == clsShared.enGender.enMale.ToString())
                            Command.CommandText = $"{_SelectInnerJoinQuery()} where Gender = 0;";
                        else if (Parameter == clsShared.enGender.enFemale.ToString())
                            Command.CommandText = $"{_SelectInnerJoinQuery()} where Gender = 1";

                        return Command;
                    }
                case (clsShared.enSearchParams.enCountryId):
                    {
                        Command.CommandText = $"{_SelectInnerJoinQuery()} where NationalityCountryID = @CountryId";

                        if (int.TryParse(Parameter, out int CountryId))
                            Command.Parameters.AddWithValue("@CountryId", CountryId);
                        else
                            Command.Parameters.AddWithValue("@CountryId", -1);

                        return Command;
                    }
                case (clsShared.enSearchParams.enCountryName):
                    {
                        Command.CommandText = $"{_SelectInnerJoinQuery()} where Countries.CountryName like '' + @CountryName + '%'";

                        Command.Parameters.AddWithValue("@CountryName", Parameter);

                        return Command;
                    }
                case (clsShared.enSearchParams.enPhone):
                    {
                        Command.CommandText = $"{_SelectInnerJoinQuery()} where Phone like '' + @PhoneNumber + '%' ;";

                        Command.Parameters.AddWithValue("@PhoneNumber", Parameter);

                        return Command;
                    }
                case (clsShared.enSearchParams.enEmail):
                    {
                        Command.CommandText = $"{_SelectInnerJoinQuery()} where Email like '' + @Email + '%' ";

                        Command.Parameters.AddWithValue("@Email", Parameter);

                        return Command;
                    }

                default:
                    return Command;
            }

        }


        private static clsShared.stPerson _FillEmptyStPerson()
        {
            clsShared.stPerson EmptyPerson = new clsShared.stPerson();

            EmptyPerson.PersonId = -1;
            EmptyPerson.NationalNumber = "";
            EmptyPerson.FirstName = "";
            EmptyPerson.SecondName = "";
            EmptyPerson.ThirdName = "";
            EmptyPerson.LastName = "";
            EmptyPerson.Email = "";
            EmptyPerson.Phone = "";
            EmptyPerson.Address = "";
            EmptyPerson.CountryId = -1;
            EmptyPerson.Gender = 0;
            EmptyPerson.DateOfBirth = DateTime.Now;
            EmptyPerson.ImagePath = "";

            return EmptyPerson;

        }


        private static clsShared.stPerson _FillFullStPerson(SqlDataReader Reader)
        {
            clsShared.stPerson FoundPerson = new clsShared.stPerson();

            FoundPerson.PersonId = (int)Reader["PersonID"];
            FoundPerson.NationalNumber = (string)Reader["NationalNo"];
            FoundPerson.FirstName = (string)Reader["FirstName"];
            FoundPerson.SecondName = (string)Reader["SecondName"];

            FoundPerson.ThirdName = Reader["ThirdName"] == DBNull.Value ? "" : (string)Reader["ThirdName"];

            FoundPerson.LastName = (string)Reader["LastName"];

            FoundPerson.Email = Reader["Email"] == DBNull.Value ? "" : (string)Reader["Email"];

            FoundPerson.Phone = (string)Reader["Phone"];
            FoundPerson.Address = (string)Reader["Address"];
            FoundPerson.CountryId = (int)Reader["NationalityCountryID"];
            FoundPerson.Gender = (clsShared.enGender)Convert.ToInt32(Reader["Gender"]);
            FoundPerson.DateOfBirth = (DateTime)Reader["DateOfBirth"]; ;
            FoundPerson.ImagePath = Reader["ImagePath"] == DBNull.Value ? "" : (string)Reader["ImagePath"];


            return FoundPerson;
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
                throw;
            }
            finally
            {
                Connection.Close();
            }

            return dataTable;


        }


        public static bool FindPersonByIdInDataBase(int PersonId, ref clsShared.stPerson stPerson1)
        {
            bool _IsFound = false;

            SqlConnection Connection = new SqlConnection(clsDataSettings.ConnectionString);

            string query = "select * from People\r\nwhere PersonID = @PersonID";

            SqlCommand sqlCommand = new SqlCommand(query, Connection);

            sqlCommand.Parameters.AddWithValue("@PersonID", PersonId);

            try
            {
                Connection.Open();

                SqlDataReader reader = sqlCommand.ExecuteReader();

                if (reader.Read())
                {

                    stPerson1 = _FillFullStPerson(reader);

                    _IsFound = true;
                }
                else
                {
                    stPerson1 = _FillEmptyStPerson();
                    _IsFound = false;
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                Connection.Close();
            }


            return _IsFound;
        }


        public static bool IsPersonExisted(string NationalNumber)
        {
            bool _IsFound = false;

            SqlConnection Connection = new SqlConnection(clsDataSettings.ConnectionString);

            string query = "SELECT COUNT(1) FROM People WHERE NationalNo = @NationalNum";

            SqlCommand Command = new SqlCommand(query, Connection);

            Command.Parameters.AddWithValue("@NationalNum", NationalNumber);


            try
            {
                Connection.Open();

                int NumberOfRows = (int)Command.ExecuteScalar();

                if(NumberOfRows > 0)
                    _IsFound = true;

            }
            catch(Exception ex)
            {
                throw;
            }
            finally
            {
                Connection.Close();
            }


            return _IsFound;
        }


        public static int AddNewPersonInDataBase(clsShared.stPerson stNewPerson)
        {
            int _PersonId = -1;

            SqlConnection Connection = new SqlConnection(clsDataSettings.ConnectionString);


            string query = @"
INSERT INTO [dbo].[People]
           ([NationalNo]
           ,[FirstName]
           ,[SecondName]
           ,[ThirdName]
           ,[LastName]
           ,[DateOfBirth]
           ,[Gender]
           ,[Address]
           ,[Phone]
           ,[Email]
           ,[NationalityCountryID]
           ,[ImagePath])
     VALUES
           (@NationalNumber,
           @FirstName,
           @SecondName,
           @ThirdName,
           @LastName,
           @DateOfBirth,
           @Gender,
           @Address,
           @Phone,
           @Email,
           @CountryId,
           @ImagePath);
            Select SCOPE_IDENTITY();";


            SqlCommand Command = new SqlCommand(query, Connection);




            Command.Parameters.AddWithValue("@NationalNumber", stNewPerson.NationalNumber);
            Command.Parameters.AddWithValue("@FirstName", stNewPerson.FirstName);
            Command.Parameters.AddWithValue("@SecondName", stNewPerson.SecondName);
            Command.Parameters.AddWithValue("@LastName", stNewPerson.LastName);
            Command.Parameters.AddWithValue("@DateOfBirth", stNewPerson.DateOfBirth);
            Command.Parameters.AddWithValue("@Gender", (byte)stNewPerson.Gender);
            Command.Parameters.AddWithValue("@Address", stNewPerson.Address);
            Command.Parameters.AddWithValue("@Phone", stNewPerson.Phone);
            Command.Parameters.AddWithValue("@CountryId", stNewPerson.CountryId);


            if (stNewPerson.ThirdName == "")
                Command.Parameters.AddWithValue("@ThirdName", DBNull.Value);
            else
                Command.Parameters.AddWithValue("@ThirdName", stNewPerson.ThirdName);



            if (stNewPerson.Email == "")
                Command.Parameters.AddWithValue("@Email", DBNull.Value);
            else
                Command.Parameters.AddWithValue("@Email", stNewPerson.Email);


            if (stNewPerson.ImagePath == "")
                Command.Parameters.AddWithValue("@ImagePath", DBNull.Value);
            else
                Command.Parameters.AddWithValue("@ImagePath", stNewPerson.ImagePath);



            try
            {
                Connection.Open();

                object Result = Command.ExecuteScalar();

                if (Result != null && int.TryParse(Result.ToString(), out int InsertedNewId))
                {
                    _PersonId = InsertedNewId;
                }

            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                Connection.Close();
            }


            return _PersonId;
        }


        public static bool UpdatePersonInfoInDataBase(clsShared.stPerson stUpdatePerson)
        {
            bool _IsUpdated = false;

            SqlConnection Connection = new SqlConnection(clsDataSettings.ConnectionString);

            string query = @"
UPDATE [dbo].[People]
   SET [NationalNo] = @NationalNumber
      ,[FirstName] = @FirstName
      ,[SecondName] = @SecondName
      ,[ThirdName] = @ThirdName
      ,[LastName] = @LastName
      ,[DateOfBirth] = @DateOfBirth
      ,[Gender] = @Gender
      ,[Address] = @Address
      ,[Phone] = @Phone
      ,[Email] = @Email
      ,[NationalityCountryID] = @CountryId
      ,[ImagePath] = @ImagePath
 WHERE PersonID = @PersonId";

            SqlCommand Command = new SqlCommand(query, Connection);



            Command.Parameters.AddWithValue("@PersonId", stUpdatePerson.PersonId);
            Command.Parameters.AddWithValue("@NationalNumber", stUpdatePerson.NationalNumber);
            Command.Parameters.AddWithValue("@FirstName", stUpdatePerson.FirstName);
            Command.Parameters.AddWithValue("@SecondName", stUpdatePerson.SecondName);
            Command.Parameters.AddWithValue("@LastName", stUpdatePerson.LastName);
            Command.Parameters.AddWithValue("@DateOfBirth", stUpdatePerson.DateOfBirth);
            Command.Parameters.AddWithValue("@Gender", (byte)stUpdatePerson.Gender);
            Command.Parameters.AddWithValue("@Address", stUpdatePerson.Address);
            Command.Parameters.AddWithValue("@Phone", stUpdatePerson.Phone);
            Command.Parameters.AddWithValue("@CountryId", stUpdatePerson.CountryId);

            if (stUpdatePerson.ThirdName == "")
                Command.Parameters.AddWithValue("@ThirdName", DBNull.Value);
            else
                Command.Parameters.AddWithValue("@ThirdName", stUpdatePerson.ThirdName);


            if (stUpdatePerson.Email == "")
                Command.Parameters.AddWithValue("@Email", DBNull.Value);
            else
                Command.Parameters.AddWithValue("@Email", stUpdatePerson.Email);


            if (stUpdatePerson.ImagePath == "")
                Command.Parameters.AddWithValue("@ImagePath", DBNull.Value);
            else
                Command.Parameters.AddWithValue("@ImagePath", stUpdatePerson.ImagePath);

            try
            {
                Connection.Open();

                int NumberOfRows = Command.ExecuteNonQuery();

                if (NumberOfRows > 0)
                    _IsUpdated = true;

            }
            catch(Exception ex)
            {
                throw;
            }
            finally
            {
                Connection.Close();
            }


            return _IsUpdated;
        }



        public static int DeletePersonFromDataBaseByPersonId(int PersonId)
        {
            int _Result = -1;

            SqlConnection Connection = new SqlConnection(clsDataSettings.ConnectionString);

            string query = "DELETE FROM [dbo].[People] WHERE PersonID = @PersonId";

            SqlCommand Command = new SqlCommand(query, Connection);

            Command.Parameters.AddWithValue("@PersonId", PersonId);

            try
            {
                Connection.Open();

                int NumberOfRows = Command.ExecuteNonQuery();

                if(NumberOfRows > 0)
                    _Result = 1;

            }
            catch (SqlException  ex)
            {
                if (ex.Number == 547)
                    _Result = 0;
                else
                    throw;
            }
            finally
            {
                Connection.Close();
            }


            return _Result;
        }





    }



}
