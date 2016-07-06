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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btn_Login_Click(object sender, EventArgs e)
        {
            txt_UserName.Text = "admin";    txt_Password.Text = "admin";
            UserController u_ctrl = new UserController();
            errorLogin.Clear();
            if (u_ctrl.Validate(txt_UserName.Text, txt_Password.Text))
            {
                tss_lbl_statusLogin.Text = "Waiting...";
                this.Cursor = Cursors.WaitCursor;
                this.Enabled = false;
                WaitSomeTime(2000);
            }
            else
            {
                tss_lbl_statusLogin.Text = "Login Failed.";
                if (txt_UserName.Text == "")
                    errorLogin.SetError(txt_UserName, "Username is empty.");
                if (txt_Password.Text == "")
                    errorLogin.SetError(txt_Password, "Password is empty.");
            }
        }

        public async void WaitSomeTime(int t)
        {
            await Task.Delay(t);
            tss_lbl_statusLogin.Text = "Login Successful.";
            await Task.Delay(t/2);
            this.Hide();
            Main fMain = new Main();
            fMain.Show();
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
