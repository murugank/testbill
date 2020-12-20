using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BillingApi.Dtos.BillingandDueDayDtos;
using BillingApi.Model;
using BillingApi.Service.BillingandDueDayServiceObj;

namespace BillingApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BillingandDueDayController : ControllerBase
    {
        
        public IBillingandDueDayService _BillingandDueDayService { get; }
        public BillingandDueDayController(IBillingandDueDayService billingandduedayService)
        {
            _BillingandDueDayService = billingandduedayService;
        }

        [HttpGet("getall")]
        public async Task<ActionResult> GetAllBillingandDueDays()
        {
            return Ok(await _BillingandDueDayService.GetAllBillingandDueDays());
        }

        [HttpGet("{ID}")]
        public async Task<ActionResult> GetBillingandDueDayByID(int ID)
        {
            return Ok(await _BillingandDueDayService.GetBillingandDueDay(ID));
        }

        [HttpPost]
        public async Task<ActionResult> AddBillingandDueDay(AddBillingandDueDayDto newbillinganddueday)
        {
            return Ok(await _BillingandDueDayService.AddBillingandDueDay(newbillinganddueday));
        }


        [HttpPut]
        public async Task<ActionResult> UpdateBillingandDueDay(UpdatedBillingandDueDayDto updatedBillingandDueDay)
        {
            ServiceResponce<GetBillingandDueDayDto> serviceResponce = new ServiceResponce<GetBillingandDueDayDto>();
             serviceResponce= await _BillingandDueDayService.UpdateBillingandDueDay(updatedBillingandDueDay);
            if(serviceResponce.Data==null)
            {
                return NotFound(serviceResponce);
            }
            return Ok(serviceResponce);
        }


        [HttpDelete("{ID}")]
        public async Task<ActionResult> DeleteBillingandDueDay(int ID)
        {
            ServiceResponce<List<GetBillingandDueDayDto>> serviceResponce = new ServiceResponce<List<GetBillingandDueDayDto>>();
            serviceResponce =await _BillingandDueDayService.DeleteBillingandDueDay(ID);
            if(serviceResponce.Data==null)
            {
                return NotFound(serviceResponce);
            }
            return Ok(serviceResponce);
        }
    }
}
