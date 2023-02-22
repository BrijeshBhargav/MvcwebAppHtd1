using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using MVCcoreWebAppHTD1.Models;
using MVCcoreWebAppHTD1.encrypteddata;

namespace MVCcoreWebAppHTD1.BusinessLogic_bl
{
    public class encrypt_bl
    {
        public static bool InsertData(EncryptedModel obj)
        {
            bool res = false;
            var dbconfig = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json").Build();
            string dbconnectionstr = dbconfig["ConnectionStrings:DefaultConnection"];
            using (SqlConnection con = new SqlConnection(dbconnectionstr))
            {
                try
                {

                    con.Open();
                    SqlCommand cmd = new SqlCommand("sp_encryptdata", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                  
                    cmd.Parameters.AddWithValue("@EmailID", EncryptionLibrary.EncryptText(obj.EmailID));
                    cmd.Parameters.AddWithValue("@Password", EncryptionLibrary.EncryptText(obj.Password));

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

                }
                finally
                {
                    con.Close();
                }
                return res = true;


            }
        }
        public static DataTable ReadData(EncryptedModel obj)
        {
            var dbconfig = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json").Build();
            string dbconnectionstr = dbconfig["ConnectionStrings:DefaultConnection"];
            using (SqlConnection con = new SqlConnection(dbconnectionstr))
            {
                SqlCommand cmd = new SqlCommand("sp_readencryptdata", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@EmailID",EncryptionLibrary.EncryptText( obj.EmailID));
                cmd.Parameters.AddWithValue("@PASSWORD", EncryptionLibrary.EncryptText(obj.Password));
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;

            }
        }
    }
}
