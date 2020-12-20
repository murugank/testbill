using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BillingApi.Dtos.BaseCurrencyDtos;
using BillingApi.Model;
using BillingApi.Service.BaseCurrencyServiceObj;

namespace BillingApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BaseCurrencyController : ControllerBase
    {
        
        public IBaseCurrencyService _BaseCurrencyService { get; }
        public BaseCurrencyController(IBaseCurrencyService basecurrencyService)
        {
            _BaseCurrencyService = basecurrencyService;
        }

        [HttpGet("getall")]
        public async Task<ActionResult> GetAllBaseCurrencys()
        {
            return Ok(await _BaseCurrencyService.GetAllBaseCurrencys());
        }

        [HttpGet("{ID}")]
        public async Task<ActionResult> GetBaseCurrencyByID(int ID)
        {
            return Ok(await _BaseCurrencyService.GetBaseCurrency(ID));
        }

        [HttpPost]
        public async Task<ActionResult> AddBaseCurrency(AddBaseCurrencyDto newbasecurrency)
        {
            return Ok(await _BaseCurrencyService.AddBaseCurrency(newbasecurrency));
        }


        [HttpPut]
        public async Task<ActionResult> UpdateBaseCurrency(UpdatedBaseCurrencyDto updatedBaseCurrency)
        {
            ServiceResponce<GetBaseCurrencyDto> serviceResponce = new ServiceResponce<GetBaseCurrencyDto>();
             serviceResponce= await _BaseCurrencyService.UpdateBaseCurrency(updatedBaseCurrency);
            if(serviceResponce.Data==null)
            {
                return NotFound(serviceResponce);
            }
            return Ok(serviceResponce);
        }


        [HttpDelete("{ID}")]
        public async Task<ActionResult> DeleteBaseCurrency(int ID)
        {
            ServiceResponce<List<GetBaseCurrencyDto>> serviceResponce = new ServiceResponce<List<GetBaseCurrencyDto>>();
            serviceResponce =await _BaseCurrencyService.DeleteBaseCurrency(ID);
            if(serviceResponce.Data==null)
            {
                return NotFound(serviceResponce);
            }
            return Ok(serviceResponce);
        }
    }
}
