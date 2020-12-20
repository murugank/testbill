using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BillingApi.Model
{
    public class BaseCurrency
    {
        public int BaseCurrencyId { get; set; } = 0;
        public string BaseCurrencyCode { get; set; } = "INR";
        public bool IsActive { get; set; } = true;
        public DateTime CreatedOn { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? LastModifiedon { get; set; }
        public int? LastModifiedBy { get; set; }
    }
}
