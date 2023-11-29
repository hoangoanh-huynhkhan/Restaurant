using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;

namespace DAO
{
    public class EmployerDAO
    {
        public static List<Employer> GetAll()
        {
            using(DBContext db = new DBContext())
            {
                return db.Employers.Where(x => x.is__delete == 0).ToList();
            }
        }
    }
}
