using Managing_Teacher_Work.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Managing_Teacher_Work.DAO
{
    public class StudentDao
    {
        MTWDbContext db = null;

        public StudentDao()
        {
            db = new MTWDbContext();
        }
        public IEnumerable<Student> Listpg(int page, int pageSize)
        {
            return db.Student.OrderByDescending(x => x.CreatedDate).ToPagedList(page, pageSize);
        }
        public List<Student> ListAll()
        {
            return db.Student.ToList();
        }
        public bool Delete(int id)
        {
            try
            {
                var user = db.Student.Find(id);
                db.Student.Remove(user);
                db.SaveChanges();
                return true;

            }
            catch (Exception)
            {
                return false;
            }

        }
    }
}