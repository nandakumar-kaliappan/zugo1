using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace zugo1.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Index()
        {
            string dbc = HomeController.GetConnectionString();
            try
            {
                SqlConnectionStringBuilder cs = new SqlConnectionStringBuilder();
                cs.DataSource = "nandakumar";
                cs.InitialCatalog = "Test";
                cs.UserID = "sa";
                cs.Password = "selsel";
                using (SqlConnection conn = new SqlConnection(cs.ConnectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("select * from employee",conn))
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read()) {

                            string name = dr["name"].ToString();
                            string department = dr["department"].ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return View();
        }
    }
}