using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BillingApi.Model;

namespace BillingApi.Dtos.BaseCurrencyDtos
{
    public class AddBaseCurrencyDto
    {
        
        public string BaseCurrencyCode { get; set; } = "INR";
        public int CreatedBy { get; set; } = 0;
        

    }
}
