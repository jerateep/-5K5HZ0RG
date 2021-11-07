using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppCore.Data;
using WebAppCore.Models;

namespace WebAppCore.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiExplorerSettings(GroupName = "User Info")]
    [ApiController]
    public class UserAPIController : ControllerBase
    {
        private readonly DataContext _db;
        public UserAPIController(DataContext db) => _db = db;

        [HttpGet]
        public List<TBL_User> GetListAllUser()
        {
            return _db.TBL_User.ToList();
        }

        [HttpGet("{_id}")]
        public TBL_User GetUserById(int _id)
        {
            return _db.TBL_User.Find(_id);
        }

        [HttpPost]
        public string InsertUser([FromBody] TBL_User _user)
        {
            _db.TBL_User.Add(new TBL_User
            {
                UserId = _user.UserId,
                FirstName = _user.FirstName,
                LastName = _user.LastName,
                IsActive = _user.IsActive,
                DepId = _user.DepId
            });
            _db.SaveChanges();
            return "OK";
        }

        [HttpPut]
        public string UpdateUser([FromBody] TBL_User _user)
        {
            string Result = "";
            TBL_User user = _db.TBL_User.Find(_user.UserId);
            if (user != null)
            {
                user.FirstName = _user.FirstName;
                user.LastName = _user.LastName;
                user.IsActive = _user.IsActive;
                user.DepId = _user.DepId;
                _db.SaveChanges();
                Result = "Update Complete";
            }
            else
            {
                Result = "No date";
            }
            return Result;
        }

        [HttpDelete]
        public string DeleteUser(int _id)
        {
            string Result = "";
            TBL_User user = _db.TBL_User.Find(_id);
            if (user != null)
            {
                _db.TBL_Salary.RemoveRange(user.Salary);
                _db.TBL_User.Remove(user);
                _db.SaveChanges();
                Result = "Delete Complete";
            }
            else
            {
                Result = "No date";
            }
            return Result;
        }
    }
}
