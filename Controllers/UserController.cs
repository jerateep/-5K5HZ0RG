using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppCore.Data;
using WebAppCore.Models;

namespace WebAppCore.Controllers
{
    public class UserController : Controller
    {
        private readonly DataContext _db;
        public UserController(DataContext db) => _db = db;

        public IActionResult UserIndex()
        {
            ViewBag.Message = TempData["Message"] as string;
            List<TBL_User> LstUser = _db.TBL_User.ToList();
            return View(LstUser);
        }

        public IActionResult Create()
        {
            var ddl_Dep = _db.TBL_Department.Where(o => o.IsActive).ToList();
            ddl_Dep.Insert(0, new TBL_Department { DepId = 0, DepName = "-- Select --" });
            ViewBag.ddl_Dep = new SelectList(ddl_Dep, nameof(TBL_Department.DepId), nameof(TBL_Department.DepName));
            return View();
        }

        public IActionResult Edit(int _id)
        {
            TBL_User user = _db.TBL_User.Find(_id);
            var ddl_Dep = _db.TBL_Department.Where(o => o.IsActive).ToList();
            ddl_Dep.Insert(0, new TBL_Department { DepId = 0, DepName = "-- Select --" });
            ViewBag.ddl_Dep = new SelectList(ddl_Dep, nameof(TBL_Department.DepId), nameof(TBL_Department.DepName));
            return View(user);
        }

        public IActionResult Insert(TBL_User _user)
        {
            TBL_User user = _db.TBL_User.Find(_user.UserId);
            if (user != null)
            {
                TempData["Message"] = "Data Duplicate";
            }
            else
            {
                _db.TBL_User.Add(new TBL_User 
                { 
                    UserId = _user.UserId,
                    FirstName = _user.FirstName,
                    LastName = _user.LastName,
                    IsActive = _user.IsActive,
                    DepId = _user.Department.DepId
                });
                _db.SaveChanges();
                TempData["Message"] = "Insert Complete";
            }
            return RedirectToAction("Index","User");
        }

        public IActionResult Update(TBL_User _user)
        {
            TBL_User user = _db.TBL_User.Find(_user.UserId);
            if (user != null)
            {
                user.FirstName = _user.FirstName;
                user.LastName = _user.LastName;
                user.IsActive = _user.IsActive;
                user.DepId = _user.Department.DepId;
                _db.SaveChanges();
                TempData["Message"] = "Update Complete";
            }
            else
            {
                TempData["Message"] = "No date";
            }
            return RedirectToAction("Index", "User");
        }

        public IActionResult Delete(int _id)
        {
            TBL_User user = _db.TBL_User.Find(_id);
            if (user != null)
            {
                _db.TBL_Salary.RemoveRange(user.Salary);
                _db.TBL_User.Remove(user);
                _db.SaveChanges();
                TempData["Message"] = "Delete Complete";
            }
            else
            {
                TempData["Message"] = "No date";
            }
            return RedirectToAction("Index", "User");
        }
    }
}
