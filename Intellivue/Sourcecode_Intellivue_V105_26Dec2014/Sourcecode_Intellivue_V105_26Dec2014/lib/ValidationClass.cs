using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Collections;

namespace Sourcecode_Intellivue.lib
{
    public class ValidationClass
    {
        //<summary>
        //Using to validate Null
        //</summary>
        //<param name="arrTextBox">array list of TextBox</param>
        //<param name="arrLabel">array list of Label show validation Message</param>
        //<param name="strMessgeToShow">Message to show validation Message</param>
        //<returns></returns>
        //<remarks></remarks>

        public bool validateNull(ArrayList arrTextBox, ArrayList arrLabel, string strMessgeToShow)
        {
            bool strReturn = true;
            for (Int16 i = 0; i <= arrTextBox.Count - 1; i++)
            {
                if (string.IsNullOrEmpty(((TextBox)arrTextBox[i]).Text.Trim()))
                {
                    ((Label)arrLabel[i]).Visible = true;
                    ((Label)arrLabel[i]).Text = strMessgeToShow;

                    strReturn = false;
                }
                else
                {
                    ((Label)arrLabel[i]).Visible = false;
                }
            }
            return strReturn;
        }

        //<summary>
        //Using to validate Number
        //</summary>
        //<param name="arrTextBox">array list of TextBox</param>
        //<param name="arrLabel">array list of Label show validation Message</param>
        //<param name="strMessgeToShow">Message to show validation Message</param>
        //<returns></returns>
        //<remarks></remarks>

        public bool validateNumber(ArrayList arrTextBox, ArrayList arrLabel, string strMessgeToShow)
        {
            bool strReturn = true;
            string strFormat = "";
            for (Int16 i = 0; i <= arrTextBox.Count - 1; i++)
            {
                try
                {
                    strFormat = ((TextBox)arrTextBox[i]).Text.Trim();
                    double dblFormat = double.Parse(strFormat);
                    ((Label)arrLabel[i]).Visible = false;
                }
                catch (Exception ex)
                {
                    ((Label)arrLabel[i]).Visible = true;
                    ((Label)arrLabel[i]).Text = strMessgeToShow;
                    strReturn = false;
                }
            }
            return strReturn;

        }

        public bool validateStringByArraySpecialCharacter(string strInputString, ArrayList arrSpecialCharacter)
        {
            int i = 0;
            for (i = 0; i <= arrSpecialCharacter.Count - 1; i += i + 1)
            {
                if (strInputString.IndexOf(arrSpecialCharacter[i].ToString(), 0) >= 0)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
