using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BillingApi.Model
{
    public class BillingandDueDay
    {
        public int BillingandDueDayId { get; set; } = 0;
        public int BillingDay { get; set; } = 1;
        public int BillingDueDay { get; set; } = 5;
        public bool IsActive { get; set; } = true;
        public DateTime CreatedOn { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? LastModifiedon { get; set; }
        public int? LastModifiedBy { get; set; }
    }
}
