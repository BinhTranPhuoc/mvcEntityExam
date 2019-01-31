using CRUDEntity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;

namespace CRUDEntity.Controllers
{
    public class EmployeeController : Controller
    {
        EmployeeDBContext db = new EmployeeDBContext();

        // GET: Employee
        public ActionResult Index()
        {
            var employee = db.Employees.Include(e => e.Department);
            return View(employee.ToList());
        }

        // Create new Employee
        public ActionResult Create(int? id)
        {
            ViewBag.DepartmentID = new SelectList(db.Departments, "DepartmentID", "NameOfDepart");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken] // security
        public ActionResult Create([Bind(Include = "EmployeeID, NameEmployee, DepartmentID")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                db.Employees.Add(employee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            if (employee == null)
            {
                return HttpNotFound();
            }
            ViewBag.DepartmentID = new SelectList(db.Departments, "EmployeeID", "NameEmployee", employee.DepartmentID);
            return View(employee);
        }

        public ActionResult Details (int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            ViewBag.DepartmentID = new SelectList(db.Departments, "DepartmentID", "NameOfDepart");
            return View(db.Employees.Find(id));
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ViewBag.DepartmentID = new SelectList(db.Departments, "DepartmentID", "NameOfDepart");
            return View(db.Employees.Find(id));
        }

        [HttpPost]
        public ActionResult Edit([Bind(Include = "EmployeeID, NameEmployee, DepartmentID")] Employee employee)
        {
            if(ModelState.IsValid)
            {
                db.Entry(employee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DepartmentID = new SelectList(db.Departments, "DepartmentID", "NameOfDepart");
            return View(employee);
        }

        public ActionResult Delete(int? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            return View(employee);
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            Employee employee = db.Employees.Find(id);
            db.Employees.Remove(employee);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}