using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BillingApi.Model
{
    public class SubscriptionDetail
    {
        public int SubscriptionDetailId { get; set; } = 0;
        public int SubscriptionHeadId { get; set; } = 0;
        [ForeignKey("SubscriptionHeadId")]
        public SubscriptionHead SubscriptionHead { get; set; }
        public int AppId { get; set; } = 0;
        [ForeignKey("AppId")]
        public App App { get; set; }
        public int UserCount { get; set; } = 0;
        public decimal AppRate { get; set; } = 0;
        public decimal AppGst { get; set; } = 0;
        public decimal CalculatedAppAmount { get; set; } = 0;
        public decimal CalculatedGSTAmount { get; set; } = 0;
        public decimal Total { get; set; } = 0;
        public int CompanyId { get; set; } = 0;
        public string CurrencyCode { get; set; } = "INR";
        public bool IsActive { get; set; } = true;
        public DateTime CreatedOn { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? LastModifiedon { get; set; }
        public int? LastModifiedBy { get; set; }
    }
}
