using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BillingApi.Data;
using BillingApi.Dtos.AppDtos;
using BillingApi.Model;

namespace BillingApi.Service.AppServiceObj
{
    public class AppService : IAppService
    {
        private readonly IMapper _mapper;
        private readonly DataContext _dataContext;

        public AppService(IMapper mapper,DataContext dataContext)
        {
            _mapper = mapper;
            _dataContext = dataContext;
        }
       
        public async Task<ServiceResponce<List<GetAppDto>>> AddApp(AddAppDto newapp)
        {
            ServiceResponce<List<GetAppDto>> serviceResponse = new ServiceResponce<List<GetAppDto>>();
            App app = _mapper.Map<App>(newapp);
            app.IsActive = true;
            app.CreatedOn = DateTime.Now;
            await _dataContext.Apps.AddAsync(app);
            await _dataContext.SaveChangesAsync();
            serviceResponse.Data = await _dataContext.Apps.Where(x => x.IsActive == true).Select(c => _mapper.Map<GetAppDto>(c)).ToListAsync();


            return serviceResponse;  
        }

        public async Task<ServiceResponce<List<GetAppDto>>> GetAllApps()
        {
            ServiceResponce<List<GetAppDto>> serviceResponce = new ServiceResponce<List<GetAppDto>>();
            List<App> DbApps = await _dataContext.Apps.Where(x => x.IsActive == true).ToListAsync();
            serviceResponce.Data = DbApps.Select(c=> _mapper.Map<GetAppDto>(c)).ToList();
            return serviceResponce;
        }

        public async Task<ServiceResponce<GetAppDto>> GetApp(int ID)
        {
            ServiceResponce<GetAppDto> serviceResponce = new ServiceResponce<GetAppDto>();
            App app = await _dataContext.Apps.FirstOrDefaultAsync(c => c.AppId == ID && c.IsActive == true);
            if (app != null)
            {
                serviceResponce.Data = _mapper.Map<GetAppDto>(app);
            }
            else
            {
                serviceResponce.Success = false;
                serviceResponce.Message = "No Record Found";
            }
            return serviceResponce;
        }
        
        public async Task<ServiceResponce<GetAppDto>> UpdateApp(UpdatedAppDto updatedApp)
        {
            ServiceResponce<GetAppDto> serviceResponce = new ServiceResponce<GetAppDto>();
            try {
                App app = await _dataContext.Apps.FirstOrDefaultAsync(c => c.AppId == updatedApp.AppId && c.IsActive == true);
                app.AppName = updatedApp.AppName;
                app.AppCode = updatedApp.AppCode;
                app.LastModifiedBy = updatedApp.LastModifiedBy;
                app.LastModifiedon = DateTime.Now;
                _dataContext.Apps.Update(app);
                await _dataContext.SaveChangesAsync();
                serviceResponce.Data = _mapper.Map<GetAppDto>(app);
            }
            catch(Exception e) {
                serviceResponce.Success = false;
                serviceResponce.Message = e.Message;
            }
            return serviceResponce;

        }

        public async Task<ServiceResponce<List<GetAppDto>>> DeleteApp(int ID)
        {
            ServiceResponce<List<GetAppDto>> serviceResponce = new ServiceResponce<List<GetAppDto>>();
            try
            {
                App app = await _dataContext.Apps.FirstAsync(c => c.AppId == ID);
                app.IsActive = false;
                app.LastModifiedon = DateTime.Now;
                _dataContext.Apps.Update(app);
                await _dataContext.SaveChangesAsync();
                serviceResponce.Data = await (_dataContext.Apps.Where(x => x.IsActive == true).Select(c => _mapper.Map<GetAppDto>(c))).ToListAsync();
            }
            catch (Exception e)
            {
                serviceResponce.Success = false;
                serviceResponce.Message = e.Message;
            }
            return serviceResponce;
        }
    }
}
