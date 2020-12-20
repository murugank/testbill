using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using BillingApi.Model;

namespace BillingApi.Dtos.AppsRateDtos
{
    public class GetAppsRateDto
    {
        public int AppsRateId { get; set; } = 0;
        public int AppId { get; set; }
        public decimal AppRate { get; set; } = 0;
        public decimal AppGst { get; set; } = 0;
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public int RangeFrom { get; set; }
        public int RangeTo { get; set; }
        public bool IsActive { get; set; } = true;
        public DateTime CreatedOn { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? LastModifiedon { get; set; }
        public int? LastModifiedBy { get; set; }
    }
}
