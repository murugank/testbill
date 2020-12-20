using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BillingApi.Model;

namespace BillingApi.Dtos.PlatformPriceDtos
{
    public class UpdatedPlatformPriceDto
    {
        public int PlatformPriceId { get; set; } = 0;
        public decimal PlatformRate { get; set; } = 0;
        public decimal GstPlatformRate { get; set; } = 0;
        public int LastModifiedBy { get; set; } = 0;

    }
}
