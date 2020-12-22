using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using BillingApi.Dtos.SubscriptionDetailDtos;
using BillingApi.Model;

namespace BillingApi.Dtos.SubscriptionHeadDtos
{
    public class UpdatedSubscriptionHeadDto
    {
        public int SubscriptionHeadId { get; set; } = 0;
        public string FullName { get; set; }
        public string Email { get; set; }
        public int PlatformCount { get; set; } = 0;
        public decimal TotalPlatformAmount { get; set; } = 0;
        public decimal TotalPlatformGstAmount { get; set; } = 0;
        public int LastModifiedBy { get; set; } = 0;
        public List<AddSubscriptionDetailDto> AddSubscriptionDetailDtoList { get; set; }
    }
}
