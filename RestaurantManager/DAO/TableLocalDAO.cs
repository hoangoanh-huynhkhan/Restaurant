using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;

namespace DAO
{
    public class TableLocalDAO
    {
        public static List<TableLocal> GetAll()
        {
            using (DBContext db = new DBContext())
            {
                return db.TableLocals.Where(x => x.is__delete == 0).ToList();
            }
        }
    }
}
