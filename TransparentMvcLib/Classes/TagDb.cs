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
    public class TagDb : BaseObj
    {
        public IEnumerable<Tag> GetTags()
        {
            var lst = new List<Tag>();

            using (var con = new SqlConnection(connectionString: ConfigurationManager.ConnectionStrings["dbConnString"].ConnectionString))
            {
                using (var cmd = new SqlCommand("dbo.TagSelect", con))
                {
                    con.Open();

                    using (var rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        while (rdr.Read())
                        {
                            lst.Add(new Tag
                            {
                                Id = (int)rdr["id"],
                                Name = rdr["name"].ToString()
                            });
                        }
                    }

                }
            }

            return lst;
        }
    }



}
