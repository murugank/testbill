using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using BillingApi.Model;

namespace BillingApi.Dtos.SubscriptionHeadDtos
{
    public class GetSubscriptionHeadDto
    {
        public int SubscriptionHeadId { get; set; } = 0;
        public string FullName { get; set; }
        public string Email { get; set; }
        public int CompanyId { get; set; } = 0;
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public decimal TotalAppAmount { get; set; } = 0;
        public decimal TotalAppGstAmount { get; set; } = 0;
        public int PlatformCount { get; set; } = 0;
        public decimal TotalPlatformAmount { get; set; } = 0;
        public decimal TotalPlatformGstAmount { get; set; } = 0;
        public bool IsActive { get; set; } = true;
        public DateTime CreatedOn { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? LastModifiedon { get; set; }
        public int? LastModifiedBy { get; set; }
    }
}
