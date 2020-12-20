using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BillingApi.Model;

namespace BillingApi.Dtos.AppsRateDtos
{
    public class AddAppsRateDto
    {

        public int AppId { get; set; }
        public decimal AppRate { get; set; } = 0;
        public decimal AppGst { get; set; } = 0;
        public int RangeFrom { get; set; } = 1;
        public int RangeTo { get; set; } = 5;
        public int CreatedBy { get; set; } = 0;
        

    }
}
