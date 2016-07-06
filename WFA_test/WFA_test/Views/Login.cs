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

        AccountController acc_ctrl = new AccountController();

        private async void btn_Login_Click(object sender, EventArgs e)
        {
             txt_UserName.Text = "admin";    txt_Password.Text = "admin";
            bool flag = true;
            int time = 0;
            String usrn = txt_UserName.Text;
            String pwd = txt_Password.Text;

            errorLogin.Clear();
            if (txt_UserName.Text == "")
            {
                errorLogin.SetError(txt_UserName, "Username is empty.");
                flag = false;
            }
            if (txt_Password.Text == "")
            {
                errorLogin.SetError(txt_Password, "Password is empty.");
                flag = false;
            }
            if (flag)
            {
                tss_lbl_statusLogin.Text = "Waiting...";
                this.Cursor = Cursors.WaitCursor;
                this.Enabled = false;
                await Task.Delay(time);
                tss_lbl_statusLogin.Text = acc_ctrl.Login(usrn, pwd);
                if (tss_lbl_statusLogin.Text == "Login Successful.")
                {
                    String message = "Data is loading";
                    tss_lbl_statusLogin.Text = message;
                    for (int i = 0; i < 7; i++)
                    {
                        tss_lbl_statusLogin.Text += ".";
                        if (i == 3)
                            tss_lbl_statusLogin.Text = message;
                       // await Task.Delay(1000);
                    }
                    this.Hide();
                    Main form_Main = new Main();
                    form_Main.Show();
                }
                else
                {
                    this.Enabled = true;
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
