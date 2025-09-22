using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace zugo1.Controllers
{
    public class TaskController : Controller
    {
        // GET: Task
        public ActionResult Add()
        {
            return View();
        }
        public ActionResult PostTask(object task)
        {

            object res;
            try
            {
                string connectionString = HomeController.GetConnectionString();
                res = new { success = true, message = "Task Added" };
            }
            catch (Exception ex)
            {
                res = new { success = false, message = ex.Message };
            }
            return Json(res);
        }
    }
}