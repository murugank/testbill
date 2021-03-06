using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using BillingApi.Model;

namespace BillingApi.Dtos.SubscriptionDetailDtos
{
    public class UpdatedSubscriptionDetailDto
    {
        public int SubscriptionDetailId { get; set; } = 0;
        public int SubscriptionHeadId { get; set; } = 0;
        public int AppId { get; set; } = 0;
        public int UserCount { get; set; } = 0;
        public decimal AppRate { get; set; } = 0;
        public decimal AppGst { get; set; } = 0;//its input percent like 0.18 
        public decimal CalculatedAppAmount { get; set; } = 0;//UserCount * AppRate
        public decimal CalculatedGSTAmount { get; set; } = 0;//CalculatedAppAmount * AppGst
        public int LastModifiedBy { get; set; } = 0;

    }
}
