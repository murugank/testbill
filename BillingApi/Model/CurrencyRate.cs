using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BillingApi.Model
{
    public class CurrencyRate
    {
        public int CurrencyRateId { get; set; } = 0;
        public string CurrencyRateCode { get; set; } = "INR";
        public decimal CurrencyValue { get; set; } = 1;
        public bool IsActive { get; set; } = true;
        public DateTime CreatedOn { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? LastModifiedon { get; set; }
        public int? LastModifiedBy { get; set; }
    }
}
