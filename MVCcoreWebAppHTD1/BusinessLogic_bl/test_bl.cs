using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using MVCcoreWebAppHTD1.Models;

namespace MVCcoreWebAppHTD1.BusinessLogic_bl
{
    public class test_bl
    {
        public static List<testModel> carty()
        {
            var dbconfig = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json").Build();
            string dbconnectionstr = dbconfig["ConnectionStrings:DefaultConnection"];
            List<testModel> obj = new List<testModel>();
            using (SqlConnection con = new SqlConnection(dbconnectionstr))
            {
                string query = "sp_Getcar";
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            obj.Add(new testModel
                            {
                                cartype = Convert.ToString(sdr["cartype"])
                            });
                        }
                    }
                    con.Close();
                }
            }
            return obj;
        }
        public static List<testModel> getbycar(string? cartype)
        {
            var dbconfig = new ConfigurationBuilder()
                         .SetBasePath(Directory.GetCurrentDirectory())
                         .AddJsonFile("appsettings.json").Build();
            string dbconnectionstr = dbconfig["ConnectionStrings:DefaultConnection"];
            using (SqlConnection con = new SqlConnection(dbconnectionstr))
            {
                SqlCommand cmd = new SqlCommand("select * from tbl_cars where cartype=@cartype", con);
                cmd.Parameters.AddWithValue("@cartype", cartype);

                con.Open();
                SqlDataReader idr = cmd.ExecuteReader();
                List<testModel> cars = new List<testModel>();
                if (idr.HasRows)
                {
                    while (idr.Read())
                    {
                        cars.Add(new testModel
                        {
                            cartype = Convert.ToString(idr["cartype"]),
                            commodity = Convert.ToString(idr["commodity"]),
                            credits = Convert.ToInt32(idr["credits"]),
                            Notified = Convert.ToDateTime(idr["Notified"]),
                            Arrived = Convert.ToDateTime(idr["Arrived"]),
                            missedswitch = Convert.ToInt32(idr["missedswitch"]),
                        });
                    }
                }
                return cars;
            }
        }
    }
}
    
