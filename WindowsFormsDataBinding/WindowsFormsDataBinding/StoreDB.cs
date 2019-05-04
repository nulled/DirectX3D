using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace WindowsFormsDataBinding
{
    public class StoreDB
    {
        static public List<Product> GetProducts()
        {
            SqlConnection con = new SqlConnection(Properties.Settings.Default.connectionString);
            SqlCommand cmd = new SqlCommand("GetProducts", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            List<Product> products = new List<Product>();

            try
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Product product = new Product((string)reader["ModelNumber"],
                                                  (string)reader["ModelName"],
                                                  (decimal)reader["UnitCost"],
                                                  (string)reader["Description"]);

                    products.Add(product);
                }
            }
            finally
            {
                con.Close();
            }

            return products;
        }
    }
}
