//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Admin_MVC5Bootstrap_Intellivue.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblProductPrice
    {
        public string PriceType { get; set; }
        public int ProdNo { get; set; }
        public System.DateTime EffectiveDatetime { get; set; }
        public Nullable<decimal> IssuePrice { get; set; }
        public Nullable<decimal> NetAsset { get; set; }
        public Nullable<decimal> Redemption { get; set; }
        public Nullable<decimal> InterestRate { get; set; }
        public string StatusFlag { get; set; }
        public Nullable<int> ParentProdNo { get; set; }
        public Nullable<decimal> MER { get; set; }
        public Nullable<System.DateTime> ReinvestIssueDate { get; set; }
        public Nullable<double> DistributionRate { get; set; }
        public Nullable<System.DateTime> LastCHangedDate { get; set; }
        public string InputUserID { get; set; }
        public Nullable<System.DateTime> InputDateTime { get; set; }
        public string VerifyUserID { get; set; }
        public Nullable<System.DateTime> VerifyDateTime { get; set; }
        public Nullable<System.DateTime> ProcessDateTime { get; set; }
        public Nullable<decimal> TotalDistributionAmt { get; set; }
        public Nullable<decimal> ActualDistributionAmt { get; set; }
        public Nullable<decimal> DistDifferenceAmt { get; set; }
        public Nullable<decimal> TotalInterestAmt { get; set; }
        public Nullable<decimal> ActualInterestAmt { get; set; }
        public Nullable<decimal> InterestDifferenceAmt { get; set; }
        public Nullable<double> AllocationInterestRate { get; set; }
        public Nullable<System.DateTime> NextEffectiveDateTime { get; set; }
    }
}
