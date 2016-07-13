// Convert to C# version by VMCuong , 17/12/2014
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//
//using Microsoft.VisualBasic;
using System.Collections;
using System.Data;
using System.Diagnostics;
using Sourcecode_Intellivue.lib;
using Microsoft.Reporting.WebForms;
namespace Sourcecode_Intellivue.Interfaces.StandardReports
{


    public partial class AdviserOutflowReport : CoreClass
    {

        ReportParameter[] Param = new ReportParameter[13];
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
            //If Session("username").ToString().ToLower() = "intellivue" Then
            //Change the Culture to Australia (for displaying datetime)
            this.Culture = "en-AU";
            user_role = (string)Session["role"];
            if (Session["role"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }
            else if (user_role == "Admin")
            {
                userId_edit = (string)Session["userId_edit"];
                user_edit_command = (string)Session["user_info_command"];
                username_edit = (string)Session["username_edit"];
                Initial();
            }
            else
            {
                string accessright = GlobalClass.GetAccessRight("R4");
                if (accessright == "F")
                {
                    string strscript = "<script>alert('You are not authorization for this page!');window.location.href='../pgHomePage.aspx'</script>";
                    if (!ClientScript.IsClientScriptBlockRegistered("clientscript"))
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "clientscript", strscript);
                    }
                }
                userId_edit = (string)Session["userId"];
                user_edit_command = "edit";
                username_edit = (string)Session["username"];

            }
        }

        protected void Page_Unload(object sender, System.EventArgs e)
        {
            this.objData.CloseData();
        }

        //Initial for the first loading page
        private void Initial()
        {
            LoadCurrentDate(this.DateFrom);
            LoadCurrentDate(this.DateTo);
            LoadDealerGroup();
            LoadProduct();
            LoadAdviserState();
        }

        //This function used to load data again
        //Because of loosing state
        private void SecondInitial()
        {
            //Check valid datetime
            this.CheckDatetime(Request.Form["DateFrom"], "Wrong date input in DateFrom!");
            this.CheckDatetime(Request.Form["DateTo"], "Wrong date input in DateTo!");

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
                Param[0] = new ReportParameter("DateFrom", Request.Form["DateFrom"]);
                Param[1] = new ReportParameter("DateTo", Request.Form["DateTo"]);
                Param[2] = new ReportParameter("DealerGroup", Request.Form["DealerGroup"]);
                Param[3] = new ReportParameter("Adviser", Request.Form["Adviser"]);
                Param[4] = new ReportParameter("Product", Request.Form["Product"]);
                Param[5] = new ReportParameter("InvestmentOption", Request.Form["InvestmentOption"]);
                Param[6] = new ReportParameter("GroupLevel1", Request.Form["GroupLevel1"]);
                Param[7] = new ReportParameter("GroupLevel2", Request.Form["GroupLevel2"]);
                Param[8] = new ReportParameter("GroupLevel3", Request.Form["GroupLevel3"]);
                Param[9] = new ReportParameter("GroupLevel4", Request.Form["GroupLevel4"]);
                Param[10] = new ReportParameter("AdviserState", Request.Form["AdviserState"]);
                Param[11] = new ReportParameter("TopN", Request.Form["TopN"]);

                //*****Need to change UserID*******
                Param[12] = new ReportParameter("UserID", Session["username"].ToString().ToUpper());

                //Me.ReportViewer1.ServerReport.ReportServerUrl = New Uri(System.Configuration.ConfigurationManager.AppSettings("ReportServer"))
                //Me.ReportViewer1.ServerReport.ReportServerUrl = New Uri(fsReportServerConnection())
                //Me.ReportViewer1.ServerReport.ReportPath = System.Configuration.ConfigurationManager.AppSettings("AdviserOutflowReport")
                //Me.ReportViewer1.ShowParameterPrompts = False
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
            this.LoadCombobox(sql, this.DealerGroup);
        }

        //Load Adviser for combobox for second Initial
        private void LoadAdviser(string ParentNo, string AdviserNo)
        {
            string sql = "EXEC sp_getAdviser " + this.FieldCheck(ParentNo);
            this.LoadCombobox(sql, this.Adviser);
            //Set SelectedIndex for the value before submitted
            this.Adviser.SelectedIndex = this.Adviser.Items.IndexOf(this.Adviser.Items.FindByValue(AdviserNo));
        }

        //Load InvestmentOption for combobox for second Initial
        private void LoadInvestmentOption(int ParentNo, int InvestmentOptionNo)
        {
            string sql = "EXEC [sp_getAllInvestmentOption] " + this.FieldCheck(ParentNo);
            this.LoadCombobox(sql, this.InvestmentOption);
            //Set SelectedIndex for the value before submitted
            this.InvestmentOption.SelectedIndex = this.InvestmentOption.Items.IndexOf(this.InvestmentOption.Items.FindByValue(InvestmentOptionNo.ToString()));
        }

        //Load Product for combobox
        private void LoadProduct()
        {
            string sql = "EXEC sp_getAllProduct";
            this.LoadCombobox(sql, this.Product);
        }

        //Load AdviserState for combobox
        private void LoadAdviserState()
        {
            string sql = "EXEC sp_getAdviserState";
            this.LoadCombobox(sql, this.AdviserState);
        }

        //Load TopN for second Initial
        private void LoadTopN(int ValueTopN, int GroupLevel2)
        {
            if (GroupLevel2 != 0)
            {
                ListItem item = default(ListItem);
                item = new ListItem("0 - All Records", "0");
                this.TopN.Items.Clear();
                this.TopN.Items.Add(item);
            }
            else
            {
                //Set SelectedIndex for the value before submitted
                this.TopN.SelectedIndex = this.TopN.Items.IndexOf(this.TopN.Items.FindByValue(ValueTopN.ToString()));
            }

        }

        //Load GroupLevel2 for second Initial
        private void LoadGroupLevel2(int valueLevel1, int valueLevel2)
        {
            int i = 0;
            ListItem item = default(ListItem);
            this.GroupLevel2.Items.Clear();
            item = new ListItem("None", "0");

            //Add the none item
            this.GroupLevel2.Items.Add(item);

            for (i = 0; i <= GroupBy.Length - 1; i++)
            {
                if (valueLevel1 != i + 1)
                {
                    //Index is less than Value
                    item = new ListItem(GroupBy[i].ToString(), (i + 1).ToString());
                    this.GroupLevel2.Items.Add(item);
                }
            }

            //Set SelectedIndex for the value before submitted
            this.GroupLevel2.SelectedIndex = this.GroupLevel2.Items.IndexOf(this.GroupLevel2.Items.FindByValue(valueLevel2.ToString()));
        }

        //Load GroupLevel3 for second Initial
        private void LoadGroupLevel3(int valueLevel1, int valueLevel2, int valueLevel3)
        {
            int i = 0;
            ListItem item = default(ListItem);
            this.GroupLevel3.Items.Clear();
            item = new ListItem("None", "0");

            //Add the none item
            this.GroupLevel3.Items.Add(item);


            for (i = 0; i <= GroupBy.Length - 1; i++)
            {
                if ((valueLevel1 != i + 1) & (valueLevel2 != i + 1))
                {
                    //Index is less than Value
                    item = new ListItem(GroupBy[i].ToString(), (i + 1).ToString());
                    this.GroupLevel3.Items.Add(item);
                }
            }

            //Set SelectedIndex for the value before submitted
            this.GroupLevel3.SelectedIndex = this.GroupLevel3.Items.IndexOf(this.GroupLevel3.Items.FindByValue(valueLevel3.ToString()));
        }

        //Load GroupLevel4 for second Initial
        private void LoadGroupLevel4(int valueLevel1, int valueLevel2, int valueLevel3, int valueLevel4)
        {
            int i = 0;
            ListItem item = default(ListItem);
            this.GroupLevel4.Items.Clear();
            item = new ListItem("None", "0");

            //Add the none item
            this.GroupLevel4.Items.Add(item);


            for (i = 0; i <= GroupBy.Length - 1; i++)
            {
                if ((valueLevel1 != i + 1) & (valueLevel2 != i + 1) & (valueLevel3 != i + 1))
                {
                    //Index is less than Value
                    item = new ListItem(GroupBy[i].ToString(), (i + 1).ToString());
                    this.GroupLevel4.Items.Add(item);
                }
            }

            //Set SelectedIndex for the value before submitted
            this.GroupLevel4.SelectedIndex = this.GroupLevel4.Items.IndexOf(this.GroupLevel4.Items.FindByValue(valueLevel4.ToString()));
        }
        //public AdviserOutflowReport()
        //{
        //    Unload += Page_Unload;
        //    Load += Page_Load;
        //}

    }
}
