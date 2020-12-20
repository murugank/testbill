using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using BillingApi.Model;

namespace BillingApi.Dtos.AppsRateDtos
{
    public class UpdatedAppsRateDto
    {
        public int AppsRateId { get; set; } = 0;
        public decimal AppRate { get; set; } = 0;
        public decimal AppGst { get; set; } = 0;
        public int LastModifiedBy { get; set; } = 0;

    }
}
