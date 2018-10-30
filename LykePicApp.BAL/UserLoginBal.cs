using LykePicApp.DAL;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;

namespace LykePicApp.BAL
{
    public class UserLoginBAL : BaseBAL
    {
        public void Save(UserLogin login)
        {
            using (var db = new DBContext())
            {
                db.UserLogins.AddOrUpdate(login);
                db.SaveChanges();
            }
        }
    }
}
