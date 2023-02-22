using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using MVCcoreWebAppHTD1.Models;
using System.Data;

namespace MVCcoreWebAppHTD1.BusinessLogic_bl
{
    public class test2_bl
    {
        public static bool InsertData(BookModel obj)
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
                    SqlCommand cmd = new SqlCommand("sp_Bookdata", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Title", obj.Title);
                    cmd.Parameters.AddWithValue("@Author", obj.Author);
                    cmd.Parameters.AddWithValue("@Description", obj.Description);
                    cmd.Parameters.AddWithValue("@PublishedYear", Convert.ToDateTime(obj.PublishedYear));
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
        public static List<BookModel> GetAllData()
        {
            List<BookModel> obj = new List<BookModel>();
            var dbconfig = new ConfigurationBuilder()
                        .SetBasePath(Directory.GetCurrentDirectory())
                        .AddJsonFile("appsettings.json").Build();
            string dbconnectionstr = dbconfig["ConnectionStrings:DefaultConnection"];
            using (SqlConnection con = new SqlConnection(dbconnectionstr))
            {
                SqlDataAdapter da = new SqlDataAdapter("sp_getdata", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    obj.Add(
                        new BookModel
                        {
                            BookId = Convert.ToInt32(dr["BookId"].ToString()),
                            Title = dr["Title"].ToString(),
                            Author = dr["Author"].ToString(),
                            Description = dr["Description"].ToString(),
                            PublishedYear = Convert.ToDateTime(dr["PublishedYear"].ToString()),


                        }
                        );
                }

                return obj;

            }
        }
        public static BookModel GetDataByID(int BookId)
        {
            BookModel obj = null;
            var dbconfig = new ConfigurationBuilder()
                        .SetBasePath(Directory.GetCurrentDirectory())
                        .AddJsonFile("appsettings.json").Build();
            string dbconnectionstr = dbconfig["ConnectionStrings:DefaultConnection"];
            using (SqlConnection con = new SqlConnection(dbconnectionstr))
            {
                SqlCommand cmd = new SqlCommand("SP_bookbyid", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@BookId", BookId);



                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                DataSet ds = new DataSet();
                da.Fill(ds);
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    obj = new BookModel();



                    obj.BookId = Convert.ToInt32(ds.Tables[0].Rows[i]["BookId"].ToString());
                    obj.Title = ds.Tables[0].Rows[i]["Title"].ToString();
                    obj.Author = ds.Tables[0].Rows[i]["Author"].ToString();
                    obj.Description = ds.Tables[0].Rows[i]["Description"].ToString();
                    obj.PublishedYear = Convert.ToDateTime(ds.Tables[0].Rows[i]["PublishedYear"].ToString());

                }
                return obj;


            }
        }
       
        public static bool UpdateData(BookModel obj)
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
                    SqlCommand cmd = new SqlCommand("SP_Updatebook", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@BookId", obj.BookId);
                    cmd.Parameters.AddWithValue("@Title", obj.Title);
                    cmd.Parameters.AddWithValue("@Author", obj.Author);
                    cmd.Parameters.AddWithValue("@Description", obj.Description);
                    cmd.Parameters.AddWithValue("@PublishedYear", obj.PublishedYear);
                   
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
        public static bool DeleteData(int BookId)
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
                    SqlCommand cmd = new SqlCommand("sp_del", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@BookId", BookId);

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
    }
}
