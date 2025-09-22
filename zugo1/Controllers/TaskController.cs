using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using zugo1.Models;

namespace zugo1.Controllers
{
    public class TaskController : Controller
    {
        // GET: Task
        public ActionResult Add()
        {
            return View();
        }
        public ActionResult PostTask(Task task)
        {

            object res;
            try
            {
                string connectionString = HomeController.GetConnectionString();
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlTransaction trans = conn.BeginTransaction();
                    string insertSql = $@"Insert into task (taskDescription, taskDate) values('{task.taskDescription}','{task.taskDate}')";
                    using (SqlCommand cmd = new SqlCommand(insertSql, conn, trans))
                    {
                        cmd.ExecuteNonQuery();
                    }
                    trans.Commit();
                }
                res = new { success = true, message = "Task Added" };
            }
            catch (Exception ex)
            {
                res = new { success = false, message = ex.Message };
            }
            return Json(res, JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetTasks()
        {

            object res;
            List<Task> tasks = new List<Task>();
            try
            {
                string connectionString = HomeController.GetConnectionString();
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlTransaction trans = conn.BeginTransaction();
                    string insertSql = $@"Select * from Task";
                    using (SqlCommand cmd = new SqlCommand(insertSql, conn, trans))
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {

                            tasks.Add(new Task()
                            {
                                id = Convert.ToInt32(dr["id"]),
                                taskDescription = dr["taskDescription"] == DBNull.Value ? "" : dr["taskDescription"].ToString(),
                                taskDate = dr["taskDate"] == DBNull.Value ? "" : dr["taskDate"].ToString(),
                            });
                        }

                    }
                    trans.Commit();
                }
                res = new { success = true, data = tasks };
            }
            catch (Exception ex)
            {
                res = new { success = false, message = ex.Message };
            }
            return Json(res,JsonRequestBehavior.AllowGet);
        }
    }
}