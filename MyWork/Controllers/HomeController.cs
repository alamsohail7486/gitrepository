using MyWork.Models;
using MyWork.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyWork.Controllers
{
    public class HomeController : Controller
    {
        EmployeeContext empCon = new EmployeeContext();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        //Creating  the employee data..
        public ActionResult CreateEmployee()
        {
            return View();
        }
        //Inserting  the employee data..
        public void InsertEmployee(employee employee)
        {
            empCon.InsertEmployee(employee);
        }

        // To inherit the employee data are done from here
        public JsonResult GetEmployee()
        {
            List<employee> employees = empCon.GetEmployee();
            return Json(employees, JsonRequestBehavior.AllowGet);
        }
        //To Deleting the employee data....
        public void DeleteEmployee(int Id)
        {
           empCon.DeleteEmployee (Id);
        }
        //To selecting the employee data from here...
        public JsonResult SelectEmployee(int Id)
        {
            employee emp = empCon.SelectEmployee(Id);
            return Json(emp, JsonRequestBehavior.AllowGet);
        }
        //To updating the employee data from here...
        public void Update(employee employee)
        {
            empCon.Update(employee);
        }
    }
}
