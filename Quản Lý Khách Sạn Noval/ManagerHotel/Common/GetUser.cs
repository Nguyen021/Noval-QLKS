using ManagerHotel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ManagerHotel.Common
{
    public class GetUser
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public   User GetUserById(int userId)
        {
            var user = db.Users.FirstOrDefault(u => u.UserId == userId);
            return user;
        }
        public  User GetUserByUsername(string username)
        {
            var user = db.Users.FirstOrDefault(u => u.Username == username);
            return user;
        }
    }
}