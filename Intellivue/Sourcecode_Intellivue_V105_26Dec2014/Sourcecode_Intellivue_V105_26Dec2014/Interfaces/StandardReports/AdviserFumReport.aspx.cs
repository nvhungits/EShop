// Convert to C# version by VMCuong , 17/12/2014
using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
//
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//
using Microsoft.Reporting.WebForms;
using Sourcecode_Intellivue.lib;
namespace Sourcecode_Intellivue.Interfaces.StandardReports
{
    public partial class AdviserFumReport : CoreClass
    {
        ReportParameter[] Param = new ReportParameter[12];
        string[] GroupBy = {
		("InvestmentOption"),
		("Product"),
		("Adviser"),
		("DealerGroup"),
		("AdviserState")
	};
        GlobalClass an;
        string userId_edit = "";
        string username_edit = "";
        string user_edit_command = "";
        string user_name = "";

        string user_role = "";
        protected void Page_Load(object sender, System.EventArgs e)
        {
            //Change the Culture to Australia (for displaying datetime)
            this.Culture = "en-AU";
            user_role = Session["role"] != null ? Session["role"].ToString() : "";

            if (Session["role"] == null)
            {
                Response.Redirect("~/Default.aspx");

            }
            else if (user_role == "Admin")
            {
                userId_edit = Session["userId_edit"] != null ? Session["userId_edit"].ToString() : "";
                user_edit_command = Session["user_info_command"] != null ? Session["user_info_command"].ToString() : "";
                username_edit = Session["username_edit"] != null ? Session["username_edit"].ToString() : ""; //Session["username_edit"].ToString();
                if (!Page.IsPostBack)
                {
                    Initial();
                }

            }
            else
            {
                string accessright = GlobalClass.GetAccessRight("R1");
                if (accessright == "F")
                {
                    string strscript = "<script>alert('You are not authorization for this page!');window.location.href='../pgHomePage.aspx'</script>";
                    if (!ClientScript.IsClientScriptBlockRegistered("clientscript"))
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "clientscript", strscript);
                    }
                }
                userId_edit = Session["userId"].ToString();
                user_edit_command = "edit";
                username_edit = Session["username"].ToString();

            }
        }

        protected void Page_Unload(object sender, System.EventArgs e)
        {
            this.objData.CloseData();
        }

        //Initial for the first loading page
        private void Initial()
        {

            LoadCurrentDate(this.evaluationdate);
            LoadDealerGroup();
            LoadProduct();
            LoadAdviserState();
        }

        //This function used to load data again
        //Because of loosing state
        private void SecondInitial()
        {
            //Check Valid Datetime
            this.CheckDatetime(Request.Form["EvaluationDate"], "Wrong date input !");


            LoadAdviser(Request.Form["DealerGroup"], Request.Form["Adviser"]);
            LoadInvestmentOption(Int32.Parse(Request.Form["Product"]), Int32.Parse(Request.Form["InvestmentOption"]));
            LoadTopN(Int32.Parse(Request.Form["TopN"]), Int32.Parse(Request.Form["GroupLevel2"]));
            LoadGroupLevel2(Int32.Parse(Request.Form["GroupLevel1"]), Int32.Parse(Request.Form["GroupLevel2"]));
            LoadGroupLevel3(Int32.Parse(Request.Form["GroupLevel1"]), Int32.Parse(Request.Form["GroupLevel2"]), Int32.Parse(Request.Form["GroupLevel3"]));
            LoadGroupLevel4(Int32.Parse(Request.Form["GroupLevel1"]), Int32.Parse(Request.Form["GroupLevel2"]), Int32.Parse(Request.Form["GroupLevel3"]), Int32.Parse(Request.Form["GroupLevel4"]));
            loadReportViewer();
        }

        //This function used to load the Report
        //Based on Request Input
        private void loadReportViewer()
        {
            try
            {
                Param[0] = new Microsoft.Reporting.WebForms.ReportParameter("DealerGroup", Request.Form["DealerGroup"]);
                Param[1] = new Microsoft.Reporting.WebForms.ReportParameter("Adviser", Request.Form["Adviser"]);
                Param[2] = new Microsoft.Reporting.WebForms.ReportParameter("Product", Request.Form["Product"]);
                Param[3] = new Microsoft.Reporting.WebForms.ReportParameter("InvestmentOption", Request.Form["InvestmentOption"]);
                Param[4] = new Microsoft.Reporting.WebForms.ReportParameter("AdviserState", Request.Form["AdviserState"]);
                Param[5] = new Microsoft.Reporting.WebForms.ReportParameter("EvaluationDate", Request.Form["EvaluationDate"]);
                Param[6] = new Microsoft.Reporting.WebForms.ReportParameter("GroupLevel1", Request.Form["GroupLevel1"]);
                Param[7] = new Microsoft.Reporting.WebForms.ReportParameter("GroupLevel2", Request.Form["GroupLevel2"]);
                Param[8] = new Microsoft.Reporting.WebForms.ReportParameter("GroupLevel3", Request.Form["GroupLevel3"]);
                Param[9] = new Microsoft.Reporting.WebForms.ReportParameter("GroupLevel4", Request.Form["GroupLevel4"]);
                Param[10] = new Microsoft.Reporting.WebForms.ReportParameter("TopN", Request.Form["TopN"]);

                //*****Need to change UserID*******
                Param[11] = new Microsoft.Reporting.WebForms.ReportParameter("UserID", Session["username"].ToString().ToUpper());


                //Me.ReportViewer1.ServerReport.ReportServerUrl = New Uri(System.Configuration.ConfigurationManager.AppSettings("ReportServer"))
                // Me.reportviewer1.ServerReport.ReportServerUrl = New Uri(fsReportServerConnection())
                //   Me.ReportViewer1.ServerReport.ReportPath = System.Configuration.ConfigurationManager.AppSettings("AdviserFumReport")
                // Me.ReportViewer1.ShowParameterPrompts = False
                //Me.ReportViewer1.ServerReport.SetParameters(Param)
            }
            catch (Exception ex)
            {
                //Response.Write(ex.Message)
                ASPNET_MessageBox(ex.Message);
            }

        }

        //Load DealerGroup for combobox
        private void LoadDealerGroup()
        {
            string sql = "EXEC sp_getAdviserGroup";
            this.LoadCombobox(sql, this.dealergroup);
        }

        //Load Adviser for combobox for second Initial
        private void LoadAdviser(string ParentNo, string AdviserNo)
        {
            lblMsg.Text = ParentNo;
            string sql = "EXEC sp_getAdviser " + this.FieldCheck(ParentNo);
            this.LoadCombobox(sql, this.adviser);
            //Set SelectedIndex for the value before submitted
            this.adviser.SelectedIndex = this.adviser.Items.IndexOf(this.adviser.Items.FindByValue(AdviserNo));
        }

        //Load InvestmentOption for combobox for second Initial
        private void LoadInvestmentOption(int ParentNo, int InvestmentOptionNo)
        {
            string sql = "EXEC [sp_getAllInvestmentOption] " + this.FieldCheck(ParentNo);
            this.LoadCombobox(sql, this.investmentoption);
            //Set SelectedIndex for the value before submitted
            this.investmentoption.SelectedIndex = this.investmentoption.Items.IndexOf(this.investmentoption.Items.FindByValue(InvestmentOptionNo.ToString()));
        }

        //Load Product for combobox
        private void LoadProduct()
        {
            string sql = "EXEC sp_getAllProduct";
            this.LoadCombobox(sql, this.product);
        }

        //Load AdviserState for combobox
        private void LoadAdviserState()
        {
            string sql = "EXEC sp_getAdviserState";
            this.LoadCombobox(sql, this.adviserstate);
        }

        //Load TopN for second Initial
        private void LoadTopN(int ValueTopN, int GroupLevel2)
        {
            if (GroupLevel2 != 0)
            {
                ListItem item = default(ListItem);
                item = new ListItem("0 - All Records", "0");
                this.topn.Items.Clear();
                this.topn.Items.Add(item);
            }
            else
            {
                //Set SelectedIndex for the value before submitted
                this.topn.SelectedIndex = this.topn.Items.IndexOf(this.topn.Items.FindByValue(ValueTopN.ToString()));
            }

        }

        //Load GroupLevel2 for second Initial
        private void LoadGroupLevel2(int valueLevel1, int valueLevel2)
        {
            int i = 0;
            ListItem item = default(ListItem);
            this.grouplevel2.Items.Clear();
            item = new ListItem("None", "0");

            //Add the none item
            this.grouplevel2.Items.Add(item);

            for (i = 0; i <= GroupBy.Length - 1; i++)
            {
                if (valueLevel1 != i + 1)
                {
                    //Index is less than Value
                    item = new ListItem(GroupBy[i].ToString(), (i + 1).ToString());
                    this.grouplevel2.Items.Add(item);
                }
            }

            //Set SelectedIndex for the value before submitted
            this.grouplevel2.SelectedIndex = this.grouplevel2.Items.IndexOf(this.grouplevel2.Items.FindByValue(valueLevel2.ToString()));
        }

        //Load GroupLevel3 for second Initial
        private void LoadGroupLevel3(int valueLevel1, int valueLevel2, int valueLevel3)
        {
            int i = 0;
            ListItem item = default(ListItem);
            this.grouplevel3.Items.Clear();
            item = new ListItem("None", "0");

            //Add the none item
            this.grouplevel3.Items.Add(item);


            for (i = 0; i <= GroupBy.Length - 1; i++)
            {
                if ((valueLevel1 != i + 1) & (valueLevel2 != i + 1))
                {
                    //Index is less than Value
                    item = new ListItem(GroupBy[i].ToString(), (i + 1).ToString());
                    this.grouplevel3.Items.Add(item);
                }
            }

            //Set SelectedIndex for the value before submitted
            this.grouplevel3.SelectedIndex = this.grouplevel3.Items.IndexOf(this.grouplevel3.Items.FindByValue(valueLevel3.ToString()));
        }

        //Load GroupLevel4 for second Initial
        private void LoadGroupLevel4(int valueLevel1, int valueLevel2, int valueLevel3, int valueLevel4)
        {
            int i = 0;
            ListItem item = default(ListItem);
            this.grouplevel4.Items.Clear();
            item = new ListItem("None", "0");

            //Add the none item
            this.grouplevel4.Items.Add(item);


            for (i = 0; i <= GroupBy.Length - 1; i++)
            {
                if ((valueLevel1 != i + 1) & (valueLevel2 != i + 1) & (valueLevel3 != i + 1))
                {
                    //Index is less than Value
                    item = new ListItem(GroupBy[i].ToString(), (i + 1).ToString());
                    this.grouplevel4.Items.Add(item);
                }
            }

            //Set SelectedIndex for the value before submitted
            this.grouplevel4.SelectedIndex = this.grouplevel4.Items.IndexOf(this.grouplevel4.Items.FindByValue(valueLevel4.ToString()));
        }

        protected void loadAdviserAll_Click(object sender, System.EventArgs e)
        {
            string sql = "EXEC sp_getAdviser ";
            this.LoadCombobox(sql, this.adviser);
        }
        //public AdviserFumReport()
        //{
        //    Unload += Page_Unload;
        //    Load += Page_Load;
        //}
    }
}