using MySql.Data.MySqlClient;
using ParcelDeliveryTrackingLib.Interfaces;
using ParcelDeliveryTrackingLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParcelDeliveryTrackingLib.Repositories
{
    public class ParcelRepository : IParcelRepository
    {
        MySqlConnection sqlConnection;
        MySqlCommand sqlCommand;
        public ParcelRepository(string connectionString)
        {
            sqlConnection = new MySqlConnection(connectionString);
            sqlCommand = new MySqlCommand("", sqlConnection);
        }
        public List<Parcel> GetAllParcels()
        {
            List<Parcel> allParcels = new List<Parcel>();
            string sqlStatementGetAllParcels = "SELECT parcelID, senderID, receiverID, weight, parcelStatus, deliveryDate, additionalNotes FROM parcels";
            sqlCommand.CommandText = sqlStatementGetAllParcels;
            try
            {
                sqlConnection.Open();

                //Execute reader and assign to SqlData
                MySqlDataReader dataReader = sqlCommand.ExecuteReader();

                //Loop through results and create a new broker object for each row
                while (dataReader.Read())
                {
                    allParcels.Add(new Parcel
                    {
                        ParcelId = int.Parse(dataReader["parcelID"].ToString()),
                        SenderID = int.Parse(dataReader["senderID"].ToString()),
                        ReceiverID = int.Parse(dataReader["receiverID"].ToString()),
                        Weight = double.Parse(dataReader["weight"].ToString()),
                        ParcelStatus = dataReader["parcelStatus"].ToString(),
                        DeliveryDate = dataReader.IsDBNull(5) == true ? DateTime.Now.AddDays(5) : DateTime.Parse(dataReader["deliveryDate"].ToString()),
                        AdditionalNotes = dataReader["additionalNotes"].ToString(),
                    });
                }
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
                sqlConnection.Close();
            }

            return allParcels;
        }
    }
}
