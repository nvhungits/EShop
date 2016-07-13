using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Sourcecode_Intellivue.Interfaces
{
    public partial class pgUnderConstruction : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["role"].ToString() != "Admin")
                {
                    Response.Redirect("~/Default.aspx");
                }
            }catch
            {
                Response.Redirect("~/Default.aspx");
            }
        }
    }
}
