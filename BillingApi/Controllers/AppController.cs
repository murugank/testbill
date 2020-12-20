using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BillingApi.Dtos.AppDtos;
using BillingApi.Model;
using BillingApi.Service.AppServiceObj;

namespace BillingApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AppController : ControllerBase
    {
        
        public IAppService _AppService { get; }
        public AppController(IAppService appService)
        {
            _AppService = appService;
        }

        [HttpGet("getall")]
        public async Task<ActionResult> GetAllApps()
        {
            return Ok(await _AppService.GetAllApps());
        }

        [HttpGet("{ID}")]
        public async Task<ActionResult> GetAppByID(int ID)
        {
            return Ok(await _AppService.GetApp(ID));
        }

        [HttpPost]
        public async Task<ActionResult> AddApp(AddAppDto newapp)
        {
            return Ok(await _AppService.AddApp(newapp));
        }


        [HttpPut]
        public async Task<ActionResult> UpdateApp(UpdatedAppDto updatedApp)
        {
            ServiceResponce<GetAppDto> serviceResponce = new ServiceResponce<GetAppDto>();
             serviceResponce= await _AppService.UpdateApp(updatedApp);
            if(serviceResponce.Data==null)
            {
                return NotFound(serviceResponce);
            }
            return Ok(serviceResponce);
        }


        [HttpDelete("{ID}")]
        public async Task<ActionResult> DeleteApp(int ID)
        {
            ServiceResponce<List<GetAppDto>> serviceResponce = new ServiceResponce<List<GetAppDto>>();
            serviceResponce =await _AppService.DeleteApp(ID);
            if(serviceResponce.Data==null)
            {
                return NotFound(serviceResponce);
            }
            return Ok(serviceResponce);
        }
    }
}
