using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BillingApi.Model;

namespace BillingApi.Dtos.CurrencyRateDtos
{
    public class AddCurrencyRateDto
    {
       
        public string CurrencyRateCode { get; set; } = "INR";
        public decimal CurrencyValue { get; set; } = 1;
        public int CreatedBy { get; set; } = 0;
        

    }
}
