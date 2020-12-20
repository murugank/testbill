using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BillingApi.Model;

namespace BillingApi.Dtos.BillingandDueDayDtos
{
    public class UpdatedBillingandDueDayDto
    {
        public int BillingandDueDayId { get; set; } = 0;
        public int BillingDay { get; set; } = 1;
        public int BillingDueDay { get; set; } = 5;
        public int LastModifiedBy { get; set; } = 0;

    }
}
