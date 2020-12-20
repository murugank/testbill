using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BillingApi.Model;

namespace BillingApi.Dtos.AppDtos
{
    public class AddAppDto
    {
        public int AppId { get; set; } = 0;
        public string AppName { get; set; } = "";
        public string AppCode { get; set; } = "";
        public int CreatedBy { get; set; } = 0;
        

    }
}
