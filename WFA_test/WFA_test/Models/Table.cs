using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WFA_test.ServerToTest;

namespace WFA_test.Models
{
    class Table:sysTable
    {
        Data d = new Data();
        public String TableName { set; get; }
        public String Type { set; get; }
        public bool Active { set; get; }
        public Table()
        {

        }
        public Table(String tbl, bool active)
        {
            this.TableName = tbl;
            this.Active = active;
        }
        
        public List<Table> getAll()
        {
            IEnumerable<Table> lst_t = from obj_t in d.TableItems() select obj_t;
            return lst_t.ToList();
        }
    }
}
