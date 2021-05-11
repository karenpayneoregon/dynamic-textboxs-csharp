using System.Data;
using System.Data.SqlClient;
using CreateDynamicTextBoxes_CS;

namespace CreateDynamicTextBoxes.Classes
{
    /// <summary>
    /// Backend database operations
    /// All statements use stored procedures
    /// </summary>
    /// <remarks>
    /// Steps to take prior to running this code.
    /// 1. Create the database and tables using the provided scripts
    /// 2. Change the database server specified in the server parameter for 
    ///    the new constructor in this class which is passed in from the main form.
    /// </remarks>
    public class DataOperations
    {
        private readonly string ConnectionString;
        public DataOperations(string Server)
        {
            ConnectionString = $"Data Source={Server};Initial Catalog=NorthWindAzure5;Integrated Security=True";
        }
        /// <summary>
        /// Get orders for customer when clicking a button
        /// </summary>
        /// <param name="CustomerIdentifier"></param>
        /// <returns></returns>
        public DataTable GetOrders(int CustomerIdentifier)
        {
            var dt = new DataTable();
            using (var cn = new SqlConnection() { ConnectionString = ConnectionString })
            {
                using (var cmd = new SqlCommand() { Connection = cn, CommandText = "CustOrdersOrders1", CommandType = CommandType.StoredProcedure })
                {
                    cmd.Parameters.AddWithValue("@CustomerID", CustomerIdentifier);
                    cn.Open();
                    dt.Load(cmd.ExecuteReader());
                }
            }
            return dt;

        }
        public DataTable PopulateInitial()
        {
            var dt = new DataTable();
            using (var cn = new SqlConnection() { ConnectionString = ConnectionString })
            {
                using (var cmd = new SqlCommand() { Connection = cn, CommandText = "Customers1", CommandType = CommandType.StoredProcedure })
                {
                    cn.Open();
                    dt.Load(cmd.ExecuteReader());
                }
            }
            return dt;
        }
        public Customer GetCustomer(int CustomerIdentifier)
        {
            var customer = new Customer();
            using (var cn = new SqlConnection() { ConnectionString = ConnectionString })
            {
                using (var cmd = new SqlCommand() { Connection = cn, CommandText = "Customers2", CommandType = CommandType.StoredProcedure })
                {
                    cmd.Parameters.AddWithValue("@id", CustomerIdentifier);
                    cn.Open();
                    var reader = cmd.ExecuteReader();
                    
                    if (!reader.HasRows) return customer;
                    
                    reader.Read();
                    
                    customer.CustomerIdentifier = CustomerIdentifier;
                    customer.CompanyName = reader.GetString(0);
                    customer.ContactName = reader.GetString(1);
                    customer.ContactTitle = reader.GetString(2);
                }
            }
            
            return customer;
        }
    }
}
