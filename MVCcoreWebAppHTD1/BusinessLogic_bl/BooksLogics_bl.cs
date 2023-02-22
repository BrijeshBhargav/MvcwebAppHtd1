using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using MVCcoreWebAppHTD1.Models;


namespace WebApplicationAzureTask.BusinessLogics_bl
{
    public class BooksLogics_bl
    {
        public static bool InsertData(Books obj)
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
                    SqlCommand cmd = new SqlCommand("SP_INSERT_TBL_BOOKDATA", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@TITLE", obj.TITLE);
                    cmd.Parameters.AddWithValue("@AUTHOR", obj.AUTHOR);
                    cmd.Parameters.AddWithValue("@DESCRIPTION", obj.DESCRIPTION);
                    cmd.Parameters.AddWithValue("@PUBLISHED_YEAR", Convert.ToDateTime(obj.PUBLISHED_YEAR));
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
                catch (Exception ex)
                {



                }
                finally
                {
                    con.Close();
                }
                return res = true;
            }
        }

        public static List<Books> Getalldata()
        {
            List<Books> obj = new List<Books>();
            bool res = false;
            var dbconfig = new ConfigurationBuilder()
           .SetBasePath(Directory.GetCurrentDirectory())
           .AddJsonFile("appsettings.json").Build();
            string dbconnectionstr = dbconfig["ConnectionStrings:DefaultConnection"];
            using (SqlConnection con = new SqlConnection(dbconnectionstr))
            {
                SqlDataAdapter da = new SqlDataAdapter("SP_GETBOOKDATA", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    obj.Add(
                        new Books
                        {
                            ID = Convert.ToInt32(dr["ID"].ToString()),
                            TITLE = dr["TITLE"].ToString(),
                            AUTHOR = dr["AUTHOR"].ToString(),
                            DESCRIPTION = dr["DESCRIPTION"].ToString(),
                            PUBLISHED_YEAR = Convert.ToDateTime(dr["PUBLISHED_YEAR"].ToString())
                        }
                        );
                }
                return obj;
            }
        }

        public static Books GetDataByID(int ID)
        {
            Books obj = null;
            var dbconfig = new ConfigurationBuilder()
                         .SetBasePath(Directory.GetCurrentDirectory())
                         .AddJsonFile("appsettings.json").Build();
            string dbconnectionstr = dbconfig["ConnectionStrings:DefaultConnection"];
            using (SqlConnection con = new SqlConnection(dbconnectionstr))
            {
                SqlCommand cmd = new SqlCommand("SP_GETBOOKDATABYID", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", ID);
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                DataSet ds = new DataSet();
                da.Fill(ds);
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    obj = new Books();
                    obj.ID = Convert.ToInt32(ds.Tables[0].Rows[i]["ID"].ToString());
                    obj.TITLE = ds.Tables[0].Rows[i]["TITLE"].ToString();
                    obj.AUTHOR = ds.Tables[0].Rows[i]["AUTHOR"].ToString();
                    obj.DESCRIPTION = ds.Tables[0].Rows[i]["DESCRIPTION"].ToString();
                    obj.PUBLISHED_YEAR = Convert.ToDateTime(ds.Tables[0].Rows[i]["PUBLISHED_YEAR"].ToString());
                }
                return obj;
            }
        }

        public static bool UpdateData(Books obj)
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
                    SqlCommand cmd = new SqlCommand("SP_UPDATEBOOKDATA", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID", obj.ID);
                    cmd.Parameters.AddWithValue("@TITLE", obj.TITLE);
                    cmd.Parameters.AddWithValue("@AUTHOR", obj.AUTHOR);
                    cmd.Parameters.AddWithValue("@DESCRIPTION", obj.DESCRIPTION);
                    cmd.Parameters.AddWithValue("@PUBLISHED_YEAR", Convert.ToDateTime(obj.PUBLISHED_YEAR));
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

        public static bool deletedata(int id)
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
                    SqlCommand cmd = new SqlCommand("SP_DELETE_TBL_BOOKDATA", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID", id);
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
                catch (Exception ex)
                {
                }
                finally
                {
                    con.Close();
                }
                return res = true;
            }
        }
    }
}