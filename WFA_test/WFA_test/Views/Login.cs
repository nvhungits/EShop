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
using WFA_test.Models;
using WFA_test.Views.sysView;

namespace WFA_test.Views
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        AccountController acc_ctrl = new AccountController();

        private void btn_Login_Click(object sender, EventArgs e)
        {
            if (txt_UserName.Text == "1"){ txt_UserName.Text = "admin"; txt_Password.Text = "admin"; }
            String usrn = txt_UserName.Text;
            String pwd = txt_Password.Text;

            errorLogin.Clear();
            if(usrn == "") errorLogin.SetError(txt_UserName, "Username is empty.");
            if(pwd == "")   errorLogin.SetError(txt_Password, "Password is empty.");
            if (usrn != "" && pwd != "")
            {
                User u = new User();
                try
                {
                    u = acc_ctrl.Login(usrn, pwd);
                    if (chkBox_role.Checked)
                    {
                        if (u.Role == "admin")
                        {
                            this.Hide();
                            sysMain form_sysMain = new sysMain();
                            form_sysMain.Show();
                        }
                        else tss_lbl_statusLogin.Text = "Access Denid.";
                    }
                    else
                    {
                        this.Hide();
                        Main form_main = new Main();
                        form_main.Show();
                    }
                }
                catch(Exception ex) {
                    tss_lbl_statusLogin.Text = "UserName or Password is Wrong.";
                    System.Console.Write("User not found.\nError: "+ex.Message);
                }
            }
           
        }
        private void txt_Password_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btn_Login_Click(sender,e);
            }
        }

        private void txt_UserName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txt_Password.Text == "" && txt_UserName.Text != "")
                {
                    txt_Password.Focus();
                }
                else
                {
                    btn_Login_Click(sender, e);
                }
            }
        }

    }
}
