using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WFA_test.Controllers;

namespace WFA_test.Views
{
    public partial class Main : Form
    {

        public Main()
        {
            InitializeComponent();
        }
        TableController t_ctrl = new TableController();
        private void p_Table_Paint(object sender, PaintEventArgs e)
        {
            dgv_Table.DataSource = t_ctrl.getAll();
        }
    }
}
