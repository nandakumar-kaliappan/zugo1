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
            try
            {

                string dbc = HomeController.GetConnectionString();
                using (SqlConnection conn = new SqlConnection(dbc))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("select * from employee", conn))
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {

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