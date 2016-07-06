using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WFA_test.Models;

namespace WFA_test.Controllers
{
    class TableController
    {
        Table t = new Table();

        public IEnumerable<Table> getAll()
        {
            try
            {
                return t.getAll();
            }
            catch
            {
                return null;
            }
        }
    }
}
