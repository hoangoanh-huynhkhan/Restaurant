using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;

namespace DAO
{
    public class TableDAO
    {
        public static List<Table> GetAll()
        {
            using(DBContext db = new DBContext())
            {
                return db.Tables.Where(x => x.is__delete == 0).ToList();
            }
        }
    }
}
