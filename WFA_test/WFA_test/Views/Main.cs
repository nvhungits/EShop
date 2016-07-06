using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WFA_test.Models;
using WFA_test.Controllers;

namespace WFA_test.Views
{
    public partial class Main : Form
    {
        TableController t_ctrl = new TableController();
        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            
        }
    }
}
