using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BillingApi.Model;

namespace BillingApi.Dtos.SubscriptionHeadDtos
{
    public class AddSubscriptionHeadDto
    {

        public string FullName { get; set; }
        public string Email { get; set; }
        public int CompanyId { get; set; } = 0;
        public string CurrencyCode { get; set; } = "INR";
        public int CreatedBy { get; set; } = 0;
        

    }
}
