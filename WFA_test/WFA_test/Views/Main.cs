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
using System.IO;

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
            String str = "C:\\Users\\Administrator\\Desktop\\Project\\trunk\\WFA_test\\WFA_test\\Images";
            DirectoryInfo dir = new DirectoryInfo(@str);
            try
            {
                foreach (FileInfo file in dir.GetFiles())
                {
                    this.imgList_Table.Images.Add(Image.FromFile(file.FullName));
                }
            }
            catch
            {
                Console.WriteLine("DirectoryInfo is not found");
            }
            this.lstView_Table.View = View.LargeIcon;
            this.imgList_Table.ImageSize = new Size(100, 100);
            this.lstView_Table.LargeImageList = this.imgList_Table;

            for (int j = 0; j < this.imgList_Table.Images.Count; j++)
            {
                ListViewItem item = new ListViewItem();
                item.ImageIndex = j;
                item.Text = "Bàn " + (j+1);
                
                this.lstView_Table.Items.Add(item);
            }
             
        }

        private void lstView_Table_MouseClick(object sender, MouseEventArgs e)
        {
            MessageBox.Show(sender + "");
        
            if (e.Button.ToString() == "Right")
            {
                cMenuShip_Table.Show(PointToScreen(e.Location));
            }
        }

        private void tsMenuItem_Open_Click(object sender, EventArgs e)
        {

        }
      
    }
}
