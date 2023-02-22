using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using MVCcoreWebAppHTD1.Models;

namespace MVCcoreWebAppHTD1.BusinessLogic_bl
{
    public class Files_bl
    {
        public static bool Delete(int fileId)
        {
            bool res = false;
            var dbconfig = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json").Build();
            string dbconnectionstr = dbconfig["ConnectionStrings:DefaultConnection"];
            using (SqlConnection con = new SqlConnection(dbconnectionstr))
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("sp_deleteFile", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID", fileId);
                    int x = cmd.ExecuteNonQuery();
                    if (x > 0)
                    {
                        return res = true;
                    }
                    else
                    {
                        return res = false;
                    }

                }
                catch (Exception)
                {
                    return res = true;
                }
                finally
                {
                    con.Close();
                }
            return res = true;
        }


    }
}
