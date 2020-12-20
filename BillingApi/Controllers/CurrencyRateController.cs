using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BillingApi.Dtos.CurrencyRateDtos;
using BillingApi.Model;
using BillingApi.Service.CurrencyRateServiceObj;

namespace BillingApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CurrencyRateController : ControllerBase
    {
        
        public ICurrencyRateService _CurrencyRateService { get; }
        public CurrencyRateController(ICurrencyRateService currencyrateService)
        {
            _CurrencyRateService = currencyrateService;
        }

        [HttpGet("getall")]
        public async Task<ActionResult> GetAllCurrencyRates()
        {
            return Ok(await _CurrencyRateService.GetAllCurrencyRates());
        }

        [HttpGet("{ID}")]
        public async Task<ActionResult> GetCurrencyRateByID(int ID)
        {
            return Ok(await _CurrencyRateService.GetCurrencyRate(ID));
        }

        [HttpPost]
        public async Task<ActionResult> AddCurrencyRate(AddCurrencyRateDto newcurrencyrate)
        {
            return Ok(await _CurrencyRateService.AddCurrencyRate(newcurrencyrate));
        }


        [HttpPut]
        public async Task<ActionResult> UpdateCurrencyRate(UpdatedCurrencyRateDto updatedCurrencyRate)
        {
            ServiceResponce<GetCurrencyRateDto> serviceResponce = new ServiceResponce<GetCurrencyRateDto>();
             serviceResponce= await _CurrencyRateService.UpdateCurrencyRate(updatedCurrencyRate);
            if(serviceResponce.Data==null)
            {
                return NotFound(serviceResponce);
            }
            return Ok(serviceResponce);
        }


        [HttpDelete("{ID}")]
        public async Task<ActionResult> DeleteCurrencyRate(int ID)
        {
            ServiceResponce<List<GetCurrencyRateDto>> serviceResponce = new ServiceResponce<List<GetCurrencyRateDto>>();
            serviceResponce =await _CurrencyRateService.DeleteCurrencyRate(ID);
            if(serviceResponce.Data==null)
            {
                return NotFound(serviceResponce);
            }
            return Ok(serviceResponce);
        }
    }
}
