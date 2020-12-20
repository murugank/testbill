using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BillingApi.Model;

namespace BillingApi.Dtos.PlatformPriceDtos
{
    public class AddPlatformPriceDto
    {
       
        public decimal PlatformRate { get; set; } = 0;
        public decimal GstPlatformRate { get; set; } = 0;
        public decimal CurrencyValue { get; set; } = 1;
        public int CreatedBy { get; set; } = 0;
        

    }
}
