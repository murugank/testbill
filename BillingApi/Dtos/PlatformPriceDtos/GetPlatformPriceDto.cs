﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BillingApi.Model;

namespace BillingApi.Dtos.PlatformPriceDtos
{
    public class GetPlatformPriceDto
    {
        public int PlatformPriceId { get; set; } = 0;
        public decimal PlatformRate { get; set; } = 0;
        public decimal GstPlatformRate { get; set; } = 0;
        public bool IsActive { get; set; } = true;
        public DateTime CreatedOn { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? LastModifiedon { get; set; }
        public int? LastModifiedBy { get; set; }
    }
}
