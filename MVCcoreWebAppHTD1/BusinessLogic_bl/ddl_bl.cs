using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using MVCcoreWebAppHTD1.Models;
namespace MVCcoreWebAppHTD1.BusinessLogic_bl
{
    public class ddl_bl
    {
        public static List<DDLModelClass> PopulateData()
        {
            var dbconfig = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json").Build();
            string dbconnectionstr = dbconfig["ConnectionStrings:DefaultConnection"];
            List<DDLModelClass> obj = new List<DDLModelClass>();
            using (SqlConnection con = new SqlConnection(dbconnectionstr))
            {
                string query = "sp_GetDistcustomer";
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            obj.Add(new DDLModelClass
                            {
                                CustomerID = Convert.ToString(sdr["CustomerID"])
                            });
                        }

                    }
                    con.Close();
                }
            }
            return obj;
        }
        public static List<OrdersModel> GetOrdersByCust(string? CustomerID)
        {
            var dbconfig = new ConfigurationBuilder()
                         .SetBasePath(Directory.GetCurrentDirectory())
                         .AddJsonFile("appsettings.json").Build();



            string dbconnectionstr = dbconfig["ConnectionStrings:DefaultConnection"];
            using (SqlConnection con = new SqlConnection(dbconnectionstr))
            {
                SqlCommand cmd = new SqlCommand("select * from orders where CustomerID=@CustomerID", con);
                cmd.Parameters.AddWithValue("@CustomerID", CustomerID);

                con.Open();
                SqlDataReader idr = cmd.ExecuteReader();
                List<OrdersModel> customers = new List<OrdersModel>();
                if (idr.HasRows)
                {
                    while (idr.Read())
                    {
                        customers.Add(new OrdersModel
                        {
                            OrderID = Convert.ToInt32(idr["OrderID"]),
                            CustomerID = Convert.ToString(idr["CustomerID"]),
                            EmployeeID = Convert.ToInt32(idr["EmployeeID"]),
                            OrderDate = Convert.ToDateTime(idr["OrderDate"]),
                            RequiredDate = Convert.ToDateTime(idr["RequiredDate"]),
                            ShippedDate = Convert.ToDateTime(idr["ShippedDate"]),
                        });
                    }
                }
                return customers;
            }
        }
        public static List<DDLModelClass> PopData()
        {
            var dbconfig = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json").Build();
            string dbconnectionstr = dbconfig["ConnectionStrings:DefaultConnection"];
            List<DDLModelClass> obj = new List<DDLModelClass>();
            using (SqlConnection con = new SqlConnection(dbconnectionstr))
            {
                string query = "sp_getord";
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            obj.Add(new DDLModelClass
                            {
                                OrderDate = Convert.ToDateTime(sdr["OrderDate"])
                            });
                        }

                    }
                    con.Close();
                }
            }
            return obj;
        }
        public static List<OrdersModel> GetdatByOrder(DateTime ? FromDate, DateTime? ToDate, string? OrderDate)
        {

            var dbconfig = new ConfigurationBuilder()
              .SetBasePath(Directory.GetCurrentDirectory())
              .AddJsonFile("appsettings.json").Build();
            string dbconnectionstr = dbconfig["ConnectionStrings:DefaultConnection"];
            SqlConnection sqlcon = new SqlConnection(dbconnectionstr);
            string Sqlquery = "select * from Orders where OrderDate between '" + FromDate + "'and'" + ToDate + "'";
                SqlCommand Sqlcomm = new SqlCommand(Sqlquery, sqlcon);
              sqlcon.Open();
            SqlDataAdapter sda = new SqlDataAdapter (Sqlcomm);
            DataSet ds= new DataSet();
            sda.Fill(ds);
            List<OrdersModel> obj = new List<OrdersModel>(); 
            foreach(DataRow dr in ds.Tables[0].Rows)
            {
                obj.Add(new OrdersModel
                {
                    OrderID = Convert.ToInt32(dr["OrderID"]),
                    CustomerID = Convert.ToString(dr["CustomerID"]),
                    EmployeeID = Convert.ToInt32(dr["EmployeeID"]),

                    RequiredDate = Convert.ToDateTime(dr["RequiredDate"]),
                    ShippedDate = Convert.ToDateTime(dr["ShippedDate"]),
                });
            }
            sqlcon.Close();
            return obj;

        }

        public static List<DDLModelClass> Popcoun()
        {
            var dbconfig = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json").Build();
            string dbconnectionstr = dbconfig["ConnectionStrings:DefaultConnection"];
            List<DDLModelClass> obj = new List<DDLModelClass>();
            using (SqlConnection con = new SqlConnection(dbconnectionstr))
            {
                string query = "sp_OrdbyCountry";
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            obj.Add(new DDLModelClass
                            {
                                ShipCountry = Convert.ToString(sdr["ShipCountry"])
                            });
                        }

                    }
                    con.Close();
                }
            }
            return obj;
        }
        public static List<OrdersModel> GetCoun(string? ShipCountry)
        {
            var dbconfig = new ConfigurationBuilder()
                         .SetBasePath(Directory.GetCurrentDirectory())
                         .AddJsonFile("appsettings.json").Build();



            string dbconnectionstr = dbconfig["ConnectionStrings:DefaultConnection"];
            using (SqlConnection con = new SqlConnection(dbconnectionstr))
            {
                SqlCommand cmd = new SqlCommand("select * from orders where ShipCountry=@ShipCountry", con);
                cmd.Parameters.AddWithValue("@ShipCountry", ShipCountry);

                con.Open();
                SqlDataReader idr = cmd.ExecuteReader();
                List<OrdersModel> country = new List<OrdersModel>();
                if (idr.HasRows)
                {
                    while (idr.Read())
                    {
                        country.Add(new OrdersModel
                        {
                            OrderID = Convert.ToInt32(idr["OrderID"]),
                            ShipCountry = Convert.ToString(idr["ShipCountry"]),
                            EmployeeID = Convert.ToInt32(idr["EmployeeID"]),
                            OrderDate = Convert.ToDateTime(idr["OrderDate"]),
                            RequiredDate = Convert.ToDateTime(idr["RequiredDate"]),
                            ShippedDate = Convert.ToDateTime(idr["ShippedDate"]),
                        });
                    }
                }
                return country;
            }
        }
        public static List<DDLModelClass> ShipData()
        {
            var dbconfig = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json").Build();
            string dbconnectionstr = dbconfig["ConnectionStrings:DefaultConnection"];
            List<DDLModelClass> obj = new List<DDLModelClass>();
            using (SqlConnection con = new SqlConnection(dbconnectionstr))
            {
                string query = "sp_GetShipDate";
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            obj.Add(new DDLModelClass
                            {
                                ShippedDate = Convert.ToDateTime(sdr["ShippedDate"])
                            });
                        }

                    }
                    con.Close();
                }
            }
            return obj;
        }
        

        public static List<OrdersModel> GetorderbyShip(DateTime? ShippedDate)
        {
            var dbconfig = new ConfigurationBuilder()
                         .SetBasePath(Directory.GetCurrentDirectory())
                         .AddJsonFile("appsettings.json").Build();

            string dbconnectionstr = dbconfig["ConnectionStrings:DefaultConnection"];
            using (SqlConnection con = new SqlConnection(dbconnectionstr))
            {
                SqlCommand cmd = new SqlCommand("sp_GetDataByShipDate", con);
                cmd.CommandType=CommandType.StoredProcedure;    
                cmd.Parameters.AddWithValue("@ShippedDate", ShippedDate);

                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                List<OrdersModel> obj = new List<OrdersModel>();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    
                        {
                        obj.Add(new OrdersModel
                        {
                            OrderID = Convert.ToInt32(dr["OrderID"]),
                            CustomerID = Convert.ToString(dr["CustomerID"]),
                            EmployeeID = Convert.ToInt32(dr["EmployeeID"]),
                            OrderDate = Convert.ToDateTime(dr["OrderDate"]),
                            RequiredDate = Convert.ToDateTime(dr["RequiredDate"]),
                            ShippedDate = Convert.ToDateTime(dr["ShippedDate"]),
                            ShipVia = Convert.ToInt32(dr["ShipVia"]),
                            ShipName = Convert.ToString(dr["ShipName"]),
                            ShipCity = Convert.ToString(dr["ShipCity"]),  
                            ShipCountry = Convert.ToString(dr["ShipCountry"])
                        });
                    }
                }
               
                return obj;
            }
        }
    }
}




