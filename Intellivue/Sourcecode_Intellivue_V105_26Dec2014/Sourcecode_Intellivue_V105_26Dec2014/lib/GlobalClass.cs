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
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using System.Collections;
using System.Text;

namespace Sourcecode_Intellivue.lib
{
    public class GlobalClass
    {
        public static void Session_Get_Set(string session_FormName, string KeyName, object KeyValue)
        {
            Hashtable htb = (Hashtable)HttpContext.Current.Session[session_FormName];

            if (htb == null)
            {
                htb = new Hashtable();
            }

            if (htb.Contains(KeyName))
            {
                htb[KeyName] = KeyValue;
            }
            else
            {
                htb.Add(KeyName, KeyValue);
            }

            HttpContext.Current.Session[session_FormName] = htb;

        }
        public static object Session_Get_Set(string session_FormName, string KeyName)
        {

            Hashtable htb = (Hashtable)HttpContext.Current.Session[session_FormName];

            if (htb == null)
            {
                return null;
            }
            else
            {
                if (htb.Contains(KeyName))
                {
                    return htb[KeyName];
                }
                else
                {
                    return null;
                }
            }
        }
        public static void Session_RemoveAt(string session_FormName, string KeyName)
        {
            Hashtable htb = (Hashtable)HttpContext.Current.Session[session_FormName];

            if (htb == null)
            {
                return;
            }
            else
            {
                if (htb.Contains(KeyName))
                {
                    htb.Remove(KeyName);
                }
            }

            HttpContext.Current.Session[session_FormName] = htb;
        }
        public static void Session_Remove(string session_FormName)
        {
            if ((HttpContext.Current.Session[session_FormName] != null))
            {
                HttpContext.Current.Session.Remove(session_FormName);
            }
        }
        public static string getMD5Hash(MD5 md5Hash, string input)
        {


            // Convert the input string to a byte array and compute the hash. 
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Create a new Stringbuilder to collect the bytes 
            // and create a string. 
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data  
            // and format each one as a hexadecimal string. 
            int i = 0;
            for (i = 0; i <= data.Length - 1; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string. 
            return sBuilder.ToString();

        }

        public static bool VerifyMd5Hash(MD5 md5Hash, string input, string hash)
        {
            // Hash the input. 
            string hashOfInput = getMD5Hash(md5Hash, input);

            // Create a StringComparer an compare the hashes. 
            StringComparer comparer = StringComparer.OrdinalIgnoreCase;

            if (0 == comparer.Compare(hashOfInput, hash))
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        // end function VerifyMd5Hash

        public static string GetAccessRight(string check)
        {

            string[,] arrUserRight = (string[,])System.Web.HttpContext.Current.Session["accessright"];

            for (int i = 0; i <= arrUserRight.GetUpperBound(0); i++)
            {
                if (check == arrUserRight[i, 0])
                {
                    return arrUserRight[i, 1];
                }

            }
            return "F";
        }
        public static string ConvertToMMDDYYYY(string date1)
        {
            string str = "";
            string [] arr  = date1.Split('/');
            string date2 = arr[1].ToString() + "/" + arr[0].ToString() + "/" + arr[2].ToString();
            str = date2;
            return str;
        }
    }

    
}
