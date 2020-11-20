using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PermissionsWebApp.Models;

namespace PermissionsWebApp.Controllers
{
    public class PermissionsController : Controller
    {
        private PermissionsDBContext db = new PermissionsDBContext();

        // GET: Permissions
        public ActionResult Index()
        {
            //Returns a list of all the Values in the Permissions Table on the database
            return View(db.Permissions.ToList());
        }

        // GET: Permissions/Details/{value}
        public ActionResult Details(int? id)
        {
            //If the Id Value given from the view is null, returns a bad request status code
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            //Returns the Permission matching the variable 'id' value
            Permission permission = db.Permissions.Find(id);
            if (permission == null)
            {
                //if it doesn't find any with that value returns a Not found error
                return HttpNotFound();
            }
            //Returns view with the permission found
            return View(permission);
        }

        // GET: Permissions/Create
        public ActionResult Create()
        {
            //Charges the Dropdown in the Create view with all the PermissionType values
            ViewBag.PermissionTypeId = new SelectList(db.PermissionTypes, "Id", "Description");
            return View(new Permission());
        }

        // POST: Permissions/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,EmployeeFirstName,EmployeeLastName,PermissionTypeId,PermissionDate")] Permission permission)
        {
            //If the modelstate is valid, add the permission after the 'Create' button is clicked
            if (ModelState.IsValid)
            {             
                //Adds it to the database, saves changes and redirects to Permissions/Index
                db.Permissions.Add(permission);
                db.SaveChanges();
                return RedirectToAction("Index");
            }          
                //Charges the dropdown and returns the view
                ViewBag.PermissionTypeId = new SelectList(db.PermissionTypes, "Id", "Description");
                return View(permission);
        }

        // GET: Permissions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Permission permission = db.Permissions.Find(id);
            if (permission == null)
            {
                return HttpNotFound();
            }
            ViewBag.PermissionTypeId = new SelectList(db.PermissionTypes, "Id", "Description");
            return View(permission);
        }

        // POST: Permissions/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,EmployeeFirstName,EmployeeLastName,PermissionTypeId,PermissionDate")] Permission permission)
        {
            if (ModelState.IsValid)
            {
                db.Entry(permission).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PermissionTypeId = new SelectList(db.PermissionTypes, "Id", "Description");
            return View(permission);

        }

        // GET: Permissions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Permission permission = db.Permissions.Find(id);
            if (permission == null)
            {
                return HttpNotFound();
            }
            return View(permission);
        }

        // POST: Permissions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            
            Permission permission = db.Permissions.Find(id);
            //Removes the permission found from the database and saves changes
            db.Permissions.Remove(permission);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
