using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WFA_test.ServerToTest;

namespace WFA_test.Models
{
    class Table
    {
        Data d = new Data();

        public String TableName { set; get; }
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
            IEnumerable<Table> tables = from t in d.TableItems() select t;
            return tables.ToList();
        }
    }
}
