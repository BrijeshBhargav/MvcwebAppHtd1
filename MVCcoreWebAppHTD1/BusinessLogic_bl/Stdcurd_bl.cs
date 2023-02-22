using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using MVCcoreWebAppHTD1.Models;
namespace MVCcoreWebAppHTD1.BusinessLogic_bl
{
    public class Stdcurd_bl
    {
        public static bool InsertData(studentdatamodel obj)
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
                    SqlCommand cmd = new SqlCommand("sp_studentdata", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Rollno", obj.Rollno);
                    cmd.Parameters.AddWithValue("@Name", obj.Name);
                    cmd.Parameters.AddWithValue("@EmailID", obj.EmailId);
                    cmd.Parameters.AddWithValue("@PASSWORD", obj.Password);
                    cmd.Parameters.AddWithValue("@Mobile", obj.Mobile);
                    cmd.Parameters.AddWithValue("@Gender", obj.Gender);
                    cmd.Parameters.AddWithValue("@DOB", Convert.ToDateTime(obj.DOB));
                    cmd.Parameters.AddWithValue("@Fee", obj.Fee);
                    cmd.Parameters.AddWithValue("@Branch", obj.Branch);
                    cmd.Parameters.AddWithValue("@status", obj.status);
                    cmd.Parameters.AddWithValue("@role", obj.role);

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
        public static DataTable Login(Loginstudentdatamodel obj)
        {
            var dbconfig = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json").Build();
            string dbconnectionstr = dbconfig["ConnectionStrings:DefaultConnection"];
            using (SqlConnection con = new SqlConnection(dbconnectionstr))
            {
                SqlCommand cmd = new SqlCommand("sp_studentlogin", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@EmailID", obj.EmailId);
                cmd.Parameters.AddWithValue("@PASSWORD", obj.Password);
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;

            }
        }
        public static bool InsertData(checkdatamodel obj)
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
                    string msg = "";

                    if (obj.qualification == true)
                    {
                        msg = msg + "Inter" + "";
                    }

                    if (obj.qualification1 == true)
                    {
                        msg = msg + "-B-tech" + "";
                    }
                    if (obj.qualification2 == true)
                    {
                        msg = msg + "-M-tech" + "";
                    }
                    con.Open();
                    SqlCommand cmd = new SqlCommand("sp_checkbox", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@name", obj.name);

                    cmd.Parameters.AddWithValue("@emailid", obj.emailid);
                    cmd.Parameters.AddWithValue("@qualification", msg);


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
        public static List<studentdatamodel> GetAllData()
        {
            List<studentdatamodel> obj = new List<studentdatamodel>();
            var dbconfig = new ConfigurationBuilder()
                        .SetBasePath(Directory.GetCurrentDirectory())
                        .AddJsonFile("appsettings.json").Build();
            string dbconnectionstr = dbconfig["ConnectionStrings:DefaultConnection"];
            using (SqlConnection con = new SqlConnection(dbconnectionstr))
            {
                SqlDataAdapter da = new SqlDataAdapter("sp_Getalldata", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    obj.Add(
                        new studentdatamodel
                        {
                            RefID = Convert.ToInt32(dr["RefID"].ToString()),
                            Rollno = dr["Rollno"].ToString(),
                            Name = dr["Name"].ToString(),
                            EmailId = dr["EmailId"].ToString(),
                            Password = dr["Password"].ToString(),
                            Mobile = dr["Mobile"].ToString(),
                            Gender = dr["Gender"].ToString(),
                            DOB = Convert.ToDateTime(dr["DOB"].ToString()),
                            Fee = Convert.ToInt32(dr["Fee"].ToString()),
                            Branch = dr["Branch"].ToString(),
                            status = Convert.ToBoolean(dr["status"].ToString()),
                            role = dr["role"].ToString(),

                        }
                        );
                }

                return obj;

            }
        }
        public static studentdatamodel GetDataByID(int refid)
        {
            studentdatamodel obj = null;
            var dbconfig = new ConfigurationBuilder()
                        .SetBasePath(Directory.GetCurrentDirectory())
                        .AddJsonFile("appsettings.json").Build();
            string dbconnectionstr = dbconfig["ConnectionStrings:DefaultConnection"];
            using (SqlConnection con = new SqlConnection(dbconnectionstr))
            {
                SqlCommand cmd = new SqlCommand("Sp_getDatabyid", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@RefID", refid);



                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                DataSet ds = new DataSet();
                da.Fill(ds);
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    obj = new studentdatamodel();

                    obj.RefID = Convert.ToInt32(ds.Tables[0].Rows[i]["RefID"].ToString());
                    obj.Rollno = ds.Tables[0].Rows[i]["Rollno"].ToString();
                    obj.Name = ds.Tables[0].Rows[i]["Name"].ToString();
                    obj.EmailId = ds.Tables[0].Rows[i]["EmailId"].ToString();
                    obj.Password = ds.Tables[0].Rows[i]["Password"].ToString();
                    obj.Mobile = ds.Tables[0].Rows[i]["Mobile"].ToString();
                    obj.Gender = ds.Tables[0].Rows[i]["Gender"].ToString();
                    obj.DOB = Convert.ToDateTime(ds.Tables[0].Rows[i]["DOB"].ToString());
                    obj.Fee = Convert.ToInt32(ds.Tables[0].Rows[i]["Fee"].ToString());
                    obj.Branch = ds.Tables[0].Rows[i]["Branch"].ToString();
                    obj.status = Convert.ToBoolean(ds.Tables[0].Rows[i]["status"].ToString());
                    obj.role = ds.Tables[0].Rows[i]["role"].ToString();

                }
                return obj;
            }
        }
        public static bool UpdateData(studentdatamodel obj)
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
                    SqlCommand cmd = new SqlCommand("sp_update_studentdata", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Rollno", obj.Rollno);
                    cmd.Parameters.AddWithValue("@Name", obj.Name);
                    cmd.Parameters.AddWithValue("@EmailID", obj.EmailId);
                    cmd.Parameters.AddWithValue("@PASSWORD", obj.Password);
                    cmd.Parameters.AddWithValue("@Mobile", obj.Mobile);
                    cmd.Parameters.AddWithValue("@Gender", obj.Gender);
                    cmd.Parameters.AddWithValue("@DOB", Convert.ToDateTime(obj.DOB));
                    cmd.Parameters.AddWithValue("@Fee", obj.Fee);
                    cmd.Parameters.AddWithValue("@Branch", obj.Branch);
                    cmd.Parameters.AddWithValue("@status", obj.status);
                    cmd.Parameters.AddWithValue("@role", obj.role);
                    cmd.Parameters.AddWithValue("@RefID", obj.RefID);
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
        public static bool DeleteData(int refid)
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
                    SqlCommand cmd = new SqlCommand("Sp_DeleteDatabyid", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@refid", refid);

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
        public static DataTable forgotpass(studentdatamodel obj)
        {
            var dbconfig = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json").Build();
            string dbconnectionstr = dbconfig["ConnectionStrings:DefaultConnection"];
            using (SqlConnection con = new SqlConnection(dbconnectionstr))
            {
                SqlCommand cmd = new SqlCommand("sp_Forgotpwd", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@EmailID", obj.EmailId);

                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;

            }
        }

        public static bool Resetpassword(resetpasswordmodel obj)

        {

            var dbconfig = new ConfigurationBuilder()

                .SetBasePath(Directory.GetCurrentDirectory())

                .AddJsonFile("appsettings.json").Build();

            string dbconnectionstr = dbconfig["ConnectionStrings:DefaultConnection"];

            using (SqlConnection con = new SqlConnection(dbconnectionstr))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("sp_resetpassword", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@EmailID", obj.EmailID);
                    cmd.Parameters.AddWithValue("@password", obj.Newpassword);
                    int result = cmd.ExecuteNonQuery();
                    if (result > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                catch (Exception ex)
                {

                }
                finally
                {
                    con.Close();
                }
                return true;

            }
        }

        public static bool Jqinsert(bulkmodel obj)
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
                    SqlCommand cmd = new SqlCommand("Sp_jgridinsert", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@EmployeeID", obj.EmployeeID);
                    cmd.Parameters.AddWithValue("@Name", obj.Name);
                    cmd.Parameters.AddWithValue("@Role", obj.Role);
                    cmd.Parameters.AddWithValue("@Age", obj.Age);
                    cmd.Parameters.AddWithValue("@Salary", obj.Salary);
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

        public static bool Bulkinsert(Customer obj)
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
                    SqlCommand cmd = new SqlCommand("Sp_bulkinsert", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Name", obj.Name);
                    cmd.Parameters.AddWithValue("@OrderId", obj.OrderId);
                    cmd.Parameters.AddWithValue("@Price", obj.Price);


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
        public static bool SaveBulkData(string empdata)//WebMethod to Save the data  
        {
            // var serializeData = JsonConvert.DeserializeObject<List<ContactInfo>>(empdata);

            List<ContactInfo> ci = new List<ContactInfo> { new ContactInfo { ID = 0, ContactName = "", ContactNo = "", Emailid = "" } };
            var dbconfig = new ConfigurationBuilder()
                        .SetBasePath(Directory.GetCurrentDirectory())
                        .AddJsonFile("appsettings.json").Build();
            string dbconnectionstr = dbconfig["ConnectionStrings:DefaultConnection"];
            using (SqlConnection con = new SqlConnection(dbconnectionstr))
            {
                foreach (var data in ci)
                {
                    using (SqlCommand cmd = new SqlCommand("sp_bulkdataa"))
                    {
                        //con.Open();

                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@ContactName", data.ContactName);
                        cmd.Parameters.AddWithValue("@ContactNo", data.ContactNo);
                        cmd.Parameters.AddWithValue("@Emailid", data.Emailid);
                        cmd.Connection = con;
                        if (con.State == ConnectionState.Closed)
                        {
                            con.Open();
                        }
                        cmd.ExecuteNonQuery();

                        //con.Close(); 
                    }
                }
            }
            return true;
        }

        public static bool contactdata(Contactdata obj)
        {
            List<Contactdata> ci = new List<Contactdata> { new Contactdata { ContactName = "", ContactNo = "" } };
            var dbconfig = new ConfigurationBuilder()
                        .SetBasePath(Directory.GetCurrentDirectory())
                        .AddJsonFile("appsettings.json").Build();
            string dbconnectionstr = dbconfig["ConnectionStrings:DefaultConnection"];
            using (SqlConnection con = new SqlConnection(dbconnectionstr))
            {
                foreach (var data in ci)
                {
                    using (SqlCommand cmd = new SqlCommand("sp_conbulk"))
                    {
                        //con.Open();

                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@ContactName", data.ContactName);
                        cmd.Parameters.AddWithValue("@ContactNo", data.ContactNo);

                        cmd.Connection = con;
                        if (con.State == ConnectionState.Closed)
                        {
                            con.Open();
                        }
                        cmd.ExecuteNonQuery();

                        //con.Close(); 
                    }
                }
            }
            return true;
        }


        public static bool DROPDOWNcheckbox(checkboxModel1 obj)

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
                    string msg = "";
                    if (obj.qualification == true)
                    {
                        msg = msg + "SSC" + ",";
                    }
                    if (obj.qualification1 == true)
                    {
                        msg = msg + "INTER" + ",";
                    }
                    if (obj.qualification2 == true)
                    {
                        msg = msg + "DIPLOMA" + ",";
                    }
                    if (obj.qualification3 == true)
                    {
                        msg = msg + "B.TECH" + ",";
                    }
                    if (obj.qualification4 == true)
                    {
                        msg = msg + "M.TECH" + ",";
                    }
                    if (obj.qualification5 == true)
                    {
                        msg = msg + "M.B.A" + ",";
                    }
                    con.Open();
                    SqlCommand cmd = new SqlCommand("sp_tbl_dropdown", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@qualification", msg);

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

        public static bool InsertCal1(CalcModel2 obj)
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
                    SqlCommand cmd = new SqlCommand("sp_caldata", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@number1", obj.number1);
                    cmd.Parameters.AddWithValue("@number2", obj.number2);
                    cmd.Parameters.AddWithValue("@operations", obj.operations);
                    cmd.Parameters.AddWithValue("@result", obj.result);
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
        public static bool InsertCal(CalcModel obj)
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
                    SqlCommand cmd = new SqlCommand("sp_caldata2", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@firstNumber", obj.firstNumber);
                    cmd.Parameters.AddWithValue("@secondNumber", obj.secondNumber);
                    cmd.Parameters.AddWithValue("@operations", obj.operations);
                    cmd.Parameters.AddWithValue("@result", obj.result);
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
        public static bool insertcalculator(calculator3 obj)
        {

            string result = obj.result;
            string operation = "";
            int length = 0;
            int number1 = 0;
            int number2 = 0;
            float result2 = 0;
            if (result.Contains("+"))
            {
                operation = "+";
                length = result.Length - result.IndexOf(operation) - 1;
                number1 = Convert.ToInt32(result.Substring(0, result.IndexOf(operation)));
                number2 = Convert.ToInt32(result.Substring(result.IndexOf(operation) + 1, length));
                result2 = number1 + number2;
            }
            if (result.Contains("-"))
            {
                operation = "-";
                length = result.Length - result.IndexOf(operation) - 1;
                number1 = Convert.ToInt32(result.Substring(0, result.IndexOf(operation)));
                number2 = Convert.ToInt32(result.Substring(result.IndexOf(operation) + 1, length));
                result2 = number1 - number2;
            }
            if (result.Contains("*"))
            {
                operation = "*";
                length = result.Length - result.IndexOf(operation) - 1;
                number1 = Convert.ToInt32(result.Substring(0, result.IndexOf(operation)));
                number2 = Convert.ToInt32(result.Substring(result.IndexOf(operation) + 1, length));
                result2 = number1 * number2;
            }
            if (result.Contains("/"))
            {
                operation = "/";
                length = result.Length - result.IndexOf(operation) - 1;
                number1 = Convert.ToInt32(result.Substring(0, result.IndexOf(operation)));
                number2 = Convert.ToInt32(result.Substring(result.IndexOf(operation) + 1, length));
                result2 = number1 / number2;

            }

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
                    SqlCommand cmd = new SqlCommand("insert into Calculator3 values (@number1,@number2,@operation,@result)", con);
                    // cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@number1", number1);
                    cmd.Parameters.AddWithValue("@number2", number2);
                    cmd.Parameters.AddWithValue("@operation", operation);
                    cmd.Parameters.AddWithValue("@result", result2);

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
        public string GetResult(calculator3 str1, string str)
        {
            List<char> symbleList = new List<char>();
            char[] charSymble = { '+', '-', '*', '/' };
            string[] st = str.Split(charSymble);
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == '+' || str[i] == '-' || str[i] == '*' || str[i] == '/')
                {
                    symbleList.Add(str[i]);
                }
            }
            double result = Convert.ToDouble(st[0]);
            for (int i = 1; i < st.Length; i++)
            {
                double num = Convert.ToDouble(st[i]);
                int j = i - 1;
                switch (symbleList[j])
                {
                    case '+':
                        result = result + num;
                        break;
                    case '-':
                        result = result - num;
                        break;
                    case '*':
                        result = result * num;
                        break;
                    case '/':
                        result = result / num;
                        break;
                    default:
                        result = 0.0;
                        break;
                }
            }
            return result.ToString();
        }
        public static List<CalculatorModel1> GetALlData()
        {
            List<CalculatorModel1> obj = new List<CalculatorModel1>();
            var dbconfig = new ConfigurationBuilder()
                        .SetBasePath(Directory.GetCurrentDirectory())
                        .AddJsonFile("appsettings.json").Build();
            string dbconnectionstr = dbconfig["ConnectionStrings:DefaultConnection"];
            using (SqlConnection con = new SqlConnection(dbconnectionstr))
            {
                SqlDataAdapter da = new SqlDataAdapter("select*from Calculator3", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    obj.Add(
                        new CalculatorModel1
                        {
                            number1 = Convert.ToInt32(dr["number1"].ToString()),
                            number2 = Convert.ToInt32(dr["number2"].ToString()),
                            operation = dr["operation"].ToString(),
                            result = dr["result"].ToString()
                        }
                        );
                }
                return obj;
            }
        }




        public static bool InsertData2(InsertModel obj)
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
                    SqlCommand cmd = new SqlCommand("sp_tb_Insert", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", obj.Id);
                    cmd.Parameters.AddWithValue("@Name", obj.Name);
                    cmd.Parameters.AddWithValue("@EmailId", obj.EmailId);
                    cmd.Parameters.AddWithValue("@Password", obj.Password);
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
        public static InsertModel GetDataByID2(int Id)
        {
            InsertModel obj = null;
            var dbconfig = new ConfigurationBuilder()
                        .SetBasePath(Directory.GetCurrentDirectory())
                        .AddJsonFile("appsettings.json").Build();
            string dbconnectionstr = dbconfig["ConnectionStrings:DefaultConnection"];
            using (SqlConnection con = new SqlConnection(dbconnectionstr))
            {
                SqlCommand cmd = new SqlCommand("sp_getdatabyId1", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", Id);
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                DataSet ds = new DataSet();
                da.Fill(ds);
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    obj = new InsertModel();



                    obj.Id = Convert.ToInt32(ds.Tables[0].Rows[i]["Id"].ToString());

                    obj.Name = ds.Tables[0].Rows[i]["Name"].ToString();
                    obj.EmailId = ds.Tables[0].Rows[i]["EmailId"].ToString();
                    obj.Password = ds.Tables[0].Rows[i]["Password"].ToString();


                }
                return obj;
            }
        }
        public static bool UpdateData2(InsertModel obj)
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
                    SqlCommand cmd = new SqlCommand("SP_update1", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", obj.Id);
                    cmd.Parameters.AddWithValue("@Name", obj.Name);
                    cmd.Parameters.AddWithValue("@EmailId", obj.EmailId);
                    cmd.Parameters.AddWithValue("@Password", obj.Password);

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
        public static List<InsertModel> GetAllData2()
        {
            List<InsertModel> obj = new List<InsertModel>();
            var dbconfig = new ConfigurationBuilder()
                        .SetBasePath(Directory.GetCurrentDirectory())
                        .AddJsonFile("appsettings.json").Build();
            string dbconnectionstr = dbconfig["ConnectionStrings:DefaultConnection"];
            using (SqlConnection con = new SqlConnection(dbconnectionstr))
            {
                SqlDataAdapter da = new SqlDataAdapter("sp_Getalldata22", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    obj.Add(
                        new InsertModel
                        {
                            Id = Convert.ToInt32(dr["Id"].ToString()),

                            Name = dr["Name"].ToString(),
                            EmailId = dr["EmailId"].ToString(),
                            Password = dr["Password"].ToString(),


                        }
                        );
                }

                return obj;

            }
        }
        public static bool Delete(int Id)
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
                    SqlCommand cmd = new SqlCommand("SP_Delete1", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", Id);

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
    


