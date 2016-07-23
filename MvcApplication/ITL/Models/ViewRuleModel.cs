using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;


namespace ITL.Models
{
    public class ViewRuleModel:ViewRule
    {
        private List<ViewRuleModel> view_rule_list = new List<ViewRuleModel>();
        private ConnectDB con = new ConnectDB("ITLDB","ViewRule");
        private SqlDataReader sqlr;
        public List<ViewRuleModel> getAll()
        {
            try
            {
                this.con.sqlcmd.Connection.Open();
                this.sqlr = this.con.sqlcmd.ExecuteReader();
                while (this.sqlr.Read())
                {
                    ViewRuleModel viewrule = new ViewRuleModel();
                    int i = 0;
                    viewrule.SysId = this.sqlr.GetString(i); i++;
                    viewrule.Updated = this.sqlr.GetDateTime(i); i++;
                    viewrule.Created = this.sqlr.GetDateTime(i); i++;
                    viewrule.Active = this.sqlr.GetInt32(i); i++;
                    viewrule.TableRef = this.sqlr.GetString(i); i++;
                    viewrule.Name = this.sqlr.GetString(i); i++;
                    viewrule.Title = this.sqlr.GetString(i); i++;
                    viewrule.ColumnName = this.sqlr.GetString(i); i++;
                    viewrule.ColumnLabel = this.sqlr.GetString(i); i++;
                    viewrule.OrderSQ = this.sqlr.GetInt32(i); i++;
                    //add to list
                    this.view_rule_list.Add(viewrule);
                }
            }
            catch (Exception e)
            {
                System.Console.Out.WriteLine("Error ITL: " + e.Message);
            }
            finally
            {
                this.con.Close();
            }
            return this.view_rule_list;
        }

        public List<ViewRuleModel> getByTableRef(String TableRef)
        {
            IEnumerable<ViewRuleModel> view_rule_list = from v in this.getAll()
                                                        where v.TableRef == TableRef && v.Active == 1
                                                        orderby v.OrderSQ
                                                        select v;
            return view_rule_list.ToList();
        }

        public List<ViewRuleModel> limit(int max)
        {
            this.view_rule_list.Take(max);
            return this.view_rule_list;
        }
    }
}