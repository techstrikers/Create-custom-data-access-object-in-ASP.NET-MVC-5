using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataAccessLayer;

namespace MVCCustomObject.Controllers
{
    public class EmployeeController : Controller
    {
        //
        // GET: /Employee/

        public ActionResult Index()
        {
            DataAccessLib db = new DataAccessLib();
            List<Employee> employee = db.GetEmployees;
            return View(employee);
        }

        public ActionResult Details(int id = 0)
        {
            DataAccessLib db = new DataAccessLib();
            List<Employee> employee = db.GetEmployees;
            Employee emp = employee.Single(m => m.Id == id);
            if (emp == null)
            {
                return HttpNotFound();
            }
            return View(emp);
        }


        [ActionName("Insert")]
        [HttpGet]
        public ActionResult Index_insert()
        {
            return View();
        }

        [ActionName("Insert")]
        [HttpPost]
        public ActionResult Index_insert(Employee emp)
        {
            DataAccessLib db = new DataAccessLib();
            db.AddEmployees(emp);

            return RedirectToAction("Index");
        }

        [ActionName("Delete")]
        [HttpGet]
        public ActionResult Delete(int id = 0)
        {
            DataAccessLib db = new DataAccessLib();
            List<Employee> employee = db.GetEmployees;
            Employee emp = employee.Single(m => m.Id == id);
            if (emp == null)
            {
                return HttpNotFound();
            }
            return View(emp);
        }

        [ActionName("Delete")]
        [HttpPost]
        public ActionResult Index_delete(Employee emp)
        {
            DataAccessLib db = new DataAccessLib();
            db.DeleteEmployees(emp.Id);

            return RedirectToAction("Index");
        }

        [ActionName("Update")]
        [HttpGet]
        public ActionResult Index_update(int id = 0)
        {
            DataAccessLib db = new DataAccessLib();
            List<Employee> employee = db.GetEmployees;
            Employee emp = employee.Single(m => m.Id == id);
            if (emp == null)
            {
                return HttpNotFound();
            }
            return View(emp);
        }

        [ActionName("Update")]
        [HttpPost]
        public ActionResult Index_update(Employee emp)
        {
            DataAccessLib db = new DataAccessLib();
            db.UpdateEmployees(emp);

            return RedirectToAction("Index");
        }

    }
}