using CRUDEntity.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace CRUDEntity.Controllers
{
    public class DepartmentController : Controller
    {
        // khởi tạo DB
        EmployeeDBContext db = new EmployeeDBContext();

        // GET: Department list show
        public ActionResult Index()
        {
            return View(db.Departments.ToList());
        }

        // detail 
        public ActionResult Details (int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Department depart = db.Departments.Find(id);
            return View(db.Departments.Find(id));
        }

        // Create new Employee
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken] // security
        public ActionResult Create([Bind(Include = "DepartmentID, NameOfDepart")] Department department)
        {
            if (ModelState.IsValid)
            {
                db.Departments.Add(department);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            if (department == null)
            {
                return HttpNotFound();
            }
            return View(department);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Department depart = db.Departments.Find(id);
            return View(db.Departments.Find(id));
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            Department department = db.Departments.Find(id);
            db.Departments.Remove(department);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Department department = db.Departments.Find(id);
            if (department == null)
            {
                return HttpNotFound();
            }
            return View(department);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "NameOfDepart")] Department department)
        {
            if (ModelState.IsValid)
            {
                db.Entry(department).State = EntityState.Modified; // edit
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(department);
        }
    }
}