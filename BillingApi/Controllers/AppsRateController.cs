using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BillingApi.Dtos.AppsRateDtos;
using BillingApi.Model;
using BillingApi.Service.AppsRateServiceObj;

namespace BillingApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AppsRateController : ControllerBase
    {
        
        public IAppsRateService _AppsRateService { get; }
        public AppsRateController(IAppsRateService appsrateService)
        {
            _AppsRateService = appsrateService;
        }

        [HttpGet("getall")]
        public async Task<ActionResult> GetAllAppsRates()
        {
            return Ok(await _AppsRateService.GetAllAppsRates());
        }

        [HttpGet("{ID}")]
        public async Task<ActionResult> GetAppsRateByID(int ID)
        {
            return Ok(await _AppsRateService.GetAppsRate(ID));
        }

        [HttpPost]
        public async Task<ActionResult> AddAppsRate(AddAppsRateDto newappsrate)
        {
            return Ok(await _AppsRateService.AddAppsRate(newappsrate));
        }


        [HttpPut]
        public async Task<ActionResult> UpdateAppsRate(UpdatedAppsRateDto updatedAppsRate)
        {
            ServiceResponce<GetAppsRateDto> serviceResponce = new ServiceResponce<GetAppsRateDto>();
             serviceResponce= await _AppsRateService.UpdateAppsRate(updatedAppsRate);
            if(serviceResponce.Data==null)
            {
                return NotFound(serviceResponce);
            }
            return Ok(serviceResponce);
        }


        [HttpDelete("{ID}")]
        public async Task<ActionResult> DeleteAppsRate(int ID)
        {
            ServiceResponce<List<GetAppsRateDto>> serviceResponce = new ServiceResponce<List<GetAppsRateDto>>();
            serviceResponce =await _AppsRateService.DeleteAppsRate(ID);
            if(serviceResponce.Data==null)
            {
                return NotFound(serviceResponce);
            }
            return Ok(serviceResponce);
        }
    }
}
