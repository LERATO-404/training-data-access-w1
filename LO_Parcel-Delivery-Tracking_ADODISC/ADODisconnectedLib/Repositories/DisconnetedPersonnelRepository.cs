using ADODisconnectedLib.Interfaces;
using ADODisconnectedLib.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace ADODisconnectedLib.Repositories
{
    public class DisconnetedPersonnelRepository : IDisconnectedPersonnelRepository
    {
        string _connectionString;

        public DisconnetedPersonnelRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        private DataSet GetAllPersonnelToDataSet()
        {
            string sqlGetAllPersonnelToDs = @"SELECT personnelID, firstName, lastname, phoneNumber, emailAddress, personnelRole, availability  FROM personnel";
            DataSet results = new DataSet();

            IDbConnection dbConnection = new MySqlConnection(_connectionString);
            IDbCommand dbCommand = new MySqlCommand(sqlGetAllPersonnelToDs, (MySqlConnection)dbConnection);

            IDbDataAdapter dbDataAdapter = new MySqlDataAdapter();
            dbDataAdapter.SelectCommand = dbCommand;

            try
            {
                dbConnection.Open();
                dbDataAdapter.Fill(results);

            }
            catch (MySqlException sqle) //catch database exceptions
            {
                Console.WriteLine("A database error occured - Message {0}, Inner Exception {1}", sqle.Message, sqle.InnerException);
            }
            catch (Exception e) //catch all other exceptions
            {
                Console.WriteLine("Unexpected error {0}", e.Message);
            }
            finally //connection should always be closed
            {
                dbConnection.Close();
            }

            return results;
        }

        public void CreatePersonnel(Personnel personnel)
        {
            string sqlInsertPersonnel = "INSERT INTO personnel(firstName, lastName, phoneNumber, emailAddress, personnelRole, availability) " +
                "VALUES ('" + personnel.FirstName + "', '" + personnel.LastName + "','" + personnel.PhoneNumber + "', '" + personnel.EmailAddress + "','" + personnel.PersonnelRole + "', '" + personnel.Availability + "')";

            IDbConnection dbConnection = new MySqlConnection(_connectionString);

            IDbDataAdapter dbDataAdapter = new MySqlDataAdapter();

            try
            {
                dbConnection.Open();
                dbDataAdapter.InsertCommand = new MySqlCommand(sqlInsertPersonnel, (MySqlConnection)dbConnection);
                dbDataAdapter.InsertCommand.ExecuteNonQuery();
            }
            catch (MySqlException sqle) //catch database exceptions
            {
                Console.WriteLine("A database error occured - Message {0}, Inner Exception {1}", sqle.Message, sqle.InnerException);
            }
            catch (Exception e) //catch all other exceptions
            {
                Console.WriteLine("Unexpected error {0}", e.Message);
            }
            finally //connection should always be closed
            {
                dbConnection.Close();
            }
        }

        public List<Personnel> GetAllPersonnel()
        {
            List<Personnel> brokerList = new List<Personnel>();
            DataSet dataSet = GetAllPersonnelToDataSet();
            
            foreach (DataRow row in dataSet.Tables[0].Rows)
            {
                brokerList.Add(new Personnel()
                {
                    PersonnelId = int.Parse((row["personnelID"].ToString())),
                    FirstName = row["firstName"].ToString(),
                    LastName = row["lastname"].ToString(),
                    PhoneNumber = row["phoneNumber"].ToString(),
                    EmailAddress = row["emailAddress"].ToString(),
                    PersonnelRole = row["personnelRole"].ToString(),
                    Availability = row["availability"].ToString()
                });
            }
            return brokerList;
        }

        public Personnel GetPersonnelById(int id)
        {
            Personnel _personnel = new Personnel();
            DataSet dataSet = GetAllPersonnelToDataSet();

            foreach (DataRow row in dataSet.Tables[0].Rows)
            {
                if (int.Parse((row["personnelID"].ToString())) == id)
                {
                    _personnel.PersonnelId = int.Parse((row["personnelID"].ToString()));
                    _personnel.FirstName = row["firstName"].ToString();
                    _personnel.LastName = row["lastname"].ToString();
                    _personnel.PhoneNumber = row["phoneNumber"].ToString();
                    _personnel.EmailAddress = row["emailAddress"].ToString();
                    _personnel.PersonnelRole = row["personnelRole"].ToString();
                    _personnel.Availability = row["availability"].ToString();
                }
            }
            return _personnel;
        }
    }
}
