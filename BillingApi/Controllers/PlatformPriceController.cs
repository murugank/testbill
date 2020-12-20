using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BillingApi.Dtos.PlatformPriceDtos;
using BillingApi.Model;
using BillingApi.Service.PlatformPriceServiceObj;

namespace BillingApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PlatformPriceController : ControllerBase
    {
        
        public IPlatformPriceService _PlatformPriceService { get; }
        public PlatformPriceController(IPlatformPriceService platformpriceService)
        {
            _PlatformPriceService = platformpriceService;
        }

        [HttpGet("getall")]
        public async Task<ActionResult> GetAllPlatformPrices()
        {
            return Ok(await _PlatformPriceService.GetAllPlatformPrices());
        }

        [HttpGet("{ID}")]
        public async Task<ActionResult> GetPlatformPriceByID(int ID)
        {
            return Ok(await _PlatformPriceService.GetPlatformPrice(ID));
        }

        [HttpPost]
        public async Task<ActionResult> AddPlatformPrice(AddPlatformPriceDto newplatformprice)
        {
            return Ok(await _PlatformPriceService.AddPlatformPrice(newplatformprice));
        }


        [HttpPut]
        public async Task<ActionResult> UpdatePlatformPrice(UpdatedPlatformPriceDto updatedPlatformPrice)
        {
            ServiceResponce<GetPlatformPriceDto> serviceResponce = new ServiceResponce<GetPlatformPriceDto>();
             serviceResponce= await _PlatformPriceService.UpdatePlatformPrice(updatedPlatformPrice);
            if(serviceResponce.Data==null)
            {
                return NotFound(serviceResponce);
            }
            return Ok(serviceResponce);
        }


        [HttpDelete("{ID}")]
        public async Task<ActionResult> DeletePlatformPrice(int ID)
        {
            ServiceResponce<List<GetPlatformPriceDto>> serviceResponce = new ServiceResponce<List<GetPlatformPriceDto>>();
            serviceResponce =await _PlatformPriceService.DeletePlatformPrice(ID);
            if(serviceResponce.Data==null)
            {
                return NotFound(serviceResponce);
            }
            return Ok(serviceResponce);
        }
    }
}
