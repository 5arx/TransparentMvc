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
    public class ProductTagDb : BaseObj
    {
        public IEnumerable<ProductTag> GetTags() {
            var lst = new List<ProductTag>();

            using (var con = new SqlConnection(connectionString: ConfigurationManager.ConnectionStrings["dbConnString"].ConnectionString))
            {
                using (var cmd = new SqlCommand("dbo.ProductTagSelect", con))
                {
                    con.Open();

                    using (var rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        while (rdr.Read())
                        {
                            lst.Add(new ProductTag
                            {
                                Id = (int)rdr["id"],
                                Name = rdr["tagname"].ToString(),
                                ProductId = (int)rdr["ProductId"],
                                TagId = (int)rdr["TagId"]
                            });
                        }
                    }

                }
            }

            return lst;
        }
    }



}
