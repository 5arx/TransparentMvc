using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace TransparentMvcLib.Classes
{
    public class ProductDb : BaseObj
    {
        public IEnumerable<Product> GetProducts()
        {
            var lst = new List<Product>();

            using (var con = new SqlConnection(connectionString: ConfigurationManager.ConnectionStrings["dbConnString"].ConnectionString))
            {
                using (var cmd = new SqlCommand("dbo.ProductSelect", con))
                {
                    con.Open();

                    using (var rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        while (rdr.Read())
                        {
                            lst.Add(new Product
                            {
                                 Id = (int)rdr["id"]
                                ,Name = rdr["name"].ToString()
                                ,Description = rdr["Description"].ToString()
                                //,ManufacturerId = (int)rdr["ManufacturerId"]
                            });
                        }
                    }

                }
            }

            return lst;
        }

        public void Save(Product p) {
            using (var con = new SqlConnection(connectionString: ConfigurationManager.ConnectionStrings["dbConnString"].ConnectionString))
            {
                using (var cmd = new SqlCommand("dbo.ProductUpdate", con))
                {
                    con.Open();
                    cmd.Parameters.Add(new SqlParameter { ParameterName = "@Name", Value= p.Name, Direction = ParameterDirection.Input, SqlDbType = SqlDbType.NVarChar });
                    cmd.Parameters.Add(new SqlParameter { ParameterName = "@Description", Value = p.Description, Direction = ParameterDirection.Input, SqlDbType = SqlDbType.NVarChar });
                    cmd.Parameters.Add(new SqlParameter { ParameterName = "@Name", Value = p.Name, Direction = ParameterDirection.Input, SqlDbType = SqlDbType.NVarChar });
                    cmd.Parameters.Add(new SqlParameter { ParameterName = "@Name", Value = p.Name, Direction = ParameterDirection.Input, SqlDbType = SqlDbType.NVarChar });

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
