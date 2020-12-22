using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BillingApi.Dtos.SubscriptionHeadDtos;
using BillingApi.Model;
using BillingApi.Service.SubscriptionHeadServiceObj;

namespace BillingApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SubscriptionHeadController : ControllerBase
    {
        
        public ISubscriptionHeadService _SubscriptionHeadService { get; }
        public SubscriptionHeadController(ISubscriptionHeadService subscriptionheadService)
        {
            _SubscriptionHeadService = subscriptionheadService;
        }

        [HttpGet("getall")]
        public async Task<ActionResult> GetAllSubscriptionHeads()
        {
            return Ok(await _SubscriptionHeadService.GetAllSubscriptionHeads());
        }

        [HttpGet("{ID}")]
        public async Task<ActionResult> GetSubscriptionHeadByID(int ID)
        {
            return Ok(await _SubscriptionHeadService.GetSubscriptionHead(ID));
        }

        [HttpPost]
        public async Task<ActionResult> AddSubscriptionHead(AddSubscriptionHeadDto newsubscriptionhead)
        {
            return Ok(await _SubscriptionHeadService.AddSubscriptionHead(newsubscriptionhead));
        }


        [HttpPut]
        public async Task<ActionResult> UpdateSubscriptionHead(UpdatedSubscriptionHeadDto updatedSubscriptionHead)
        {
            ServiceResponce<GetSubscriptionHeadDto> serviceResponce = new ServiceResponce<GetSubscriptionHeadDto>();
             serviceResponce= await _SubscriptionHeadService.UpdateSubscriptionHead(updatedSubscriptionHead);
            if(serviceResponce.Data==null)
            {
                return NotFound(serviceResponce);
            }
            return Ok(serviceResponce);
        }


        [HttpDelete("{ID}")]
        public async Task<ActionResult> DeleteSubscriptionHead(int ID)
        {
            ServiceResponce<List<GetSubscriptionHeadDto>> serviceResponce = new ServiceResponce<List<GetSubscriptionHeadDto>>();
            serviceResponce =await _SubscriptionHeadService.DeleteSubscriptionHead(ID);
            if(serviceResponce.Data==null)
            {
                return NotFound(serviceResponce);
            }
            return Ok(serviceResponce);
        }
    }
}
