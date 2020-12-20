using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BillingApi.Model;

namespace BillingApi.Dtos.BaseCurrencyDtos
{
    public class UpdatedBaseCurrencyDto
    {
        public int BaseCurrencyId { get; set; } = 0;
        public string BaseCurrencyCode { get; set; } = "INR";
        public int LastModifiedBy { get; set; } = 0;

    }
}
