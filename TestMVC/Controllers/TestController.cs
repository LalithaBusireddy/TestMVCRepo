using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using WebApplication1.DAL;
using System.Data;
namespace WebApplication1.Controllers
{
    public class TestController : Controller
    {
        public ActionResult Index(int id)
        {
            Employee emp = new Employee();
            DbAccess dba = new DbAccess();
            DataTable dt = dba.GetEmployee(id);
            if (dt.Rows.Count > 0)
            {
                emp.EmployeeId = Convert.ToInt32(dt.Rows[0]["EmpId"]);
                emp.EmployeeName = dt.Rows[0]["EmpName"].ToString();
                emp.Location = dt.Rows[0]["Location"].ToString();

            }
        
            ViewData["emp"] = emp;
            return View("testview");
        }

        public ActionResult Employees()
        {
            List<Employee> employees = new List<Employee>();
            DbAccess dba = new DbAccess();
            DataTable dt = dba.GetEmployees();
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    Employee emp = new Employee();
                    emp.EmployeeId = Convert.ToInt32(dr["Empid"]);
                    emp.EmployeeName = dr["EmpName"].ToString();
                    emp.Location = dr ["Location"].ToString();
                    employees.Add(emp);
                }

            }
            return View("DisplayEmployee", employees);
        }

        public ActionResult Edit(int employeeId)
        {
            Employee emp = new Employee();
            DbAccess dba = new DbAccess();
            DataTable dt = dba.GetEmployee(employeeId);
            if (dt.Rows.Count > 0)
            {
                emp.EmployeeId = Convert.ToInt32(dt.Rows[0]["EmpId"]);
                emp.EmployeeName = dt.Rows[0]["EmpName"].ToString();
                emp.Location = dt.Rows[0]["Location"].ToString();

            }

            return View("EmployeeForm", emp);
        }
        public ActionResult Update(Employee employee)
        {
            DbAccess db = new DbAccess();
            db.SaveEmployee(employee, false);
            return RedirectToAction("employees", "test");
        }
        public ActionResult AddNew(Employee employee)
        {
            DbAccess db = new DbAccess();
            db.SaveEmployee(employee, true);
            return RedirectToAction("employees", "test");
        }
        public ActionResult deleteEmployee(int id)
        {
            DbAccess db = new DbAccess();
            db.DeleteEmployee(id);
            return RedirectToAction("employees", "test");


        }
        //public string GetString()
        //{
        //    Customer cust = new Customer();
        //    cust.CustomerId = 1;
        //    cust.Name = "Test Customer Ltd";
        //    cust.Email = "test@abcd.com";
        //    return cust.ToString();
        //}
        ////[HttpGet]
        //public JsonResult JsonOutput()
        //{
        //    Customer cust = new Customer();
        //    cust.CustomerId = 1;
        //    cust.Name = "Test Customer Ltd";
        //    cust.Email = "test@abcd.com";
        //    return Json(cust, JsonRequestBehavior.AllowGet);
        //}


    }
}