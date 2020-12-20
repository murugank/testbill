using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BillingApi.Data;
using BillingApi.Dtos.AppsRateDtos;
using BillingApi.Model;

namespace BillingApi.Service.AppsRateServiceObj
{
    public class AppsRateService : IAppsRateService
    {
        private readonly IMapper _mapper;
        private readonly DataContext _dataContext;

        public AppsRateService(IMapper mapper,DataContext dataContext)
        {
            _mapper = mapper;
            _dataContext = dataContext;
        }
       
        public async Task<ServiceResponce<List<GetAppsRateDto>>> AddAppsRate(AddAppsRateDto newappsrate)
        {
            ServiceResponce<List<GetAppsRateDto>> serviceResponse = new ServiceResponce<List<GetAppsRateDto>>();
            
            if (await ValidateApprateExists(newappsrate.AppId,newappsrate.RangeFrom,newappsrate.RangeTo) == false)
            {
                AppsRate appsrate = _mapper.Map<AppsRate>(newappsrate);
                appsrate.DateFrom = DateTime.Now.Date;
                appsrate.IsActive = true;
                appsrate.CreatedOn = DateTime.Now;
                await _dataContext.AppsRates.AddAsync(appsrate);
                await _dataContext.SaveChangesAsync();
                serviceResponse.Data = await _dataContext.AppsRates.Where(x => x.IsActive == true).Select(c => _mapper.Map<GetAppsRateDto>(c)).ToListAsync();
            }
            else
            {
                serviceResponse.Success = false;
                serviceResponse.Message = "Already Exists";
            }
            return serviceResponse;  
        }
        public async Task<bool> ValidateApprateExists(int AppId,int RangeFrom,int RangeTo)
        {
            bool status = false;
            AppsRate appsrate = await _dataContext.AppsRates.FirstOrDefaultAsync(c => c.AppId == AppId && ((c.RangeFrom <= RangeFrom && c.RangeTo >= RangeFrom)|| (c.RangeFrom <= RangeTo && c.RangeTo >= RangeTo)) && c.IsActive == true);
            if (appsrate != null)
            {
                status = true;
            }

            return status;
        }
        public async Task<ServiceResponce<List<GetAppsRateDto>>> GetAllAppsRates()
        {
            ServiceResponce<List<GetAppsRateDto>> serviceResponce = new ServiceResponce<List<GetAppsRateDto>>();
            List<AppsRate> DbAppsRates = await _dataContext.AppsRates.Where(x => x.IsActive == true).ToListAsync();
            serviceResponce.Data = DbAppsRates.Select(c=> _mapper.Map<GetAppsRateDto>(c)).ToList();
            return serviceResponce;
        }

        public async Task<ServiceResponce<GetAppsRateDto>> GetAppsRate(int ID)
        {
            ServiceResponce<GetAppsRateDto> serviceResponce = new ServiceResponce<GetAppsRateDto>();
            AppsRate appsrate = await _dataContext.AppsRates.FirstOrDefaultAsync(c => c.AppsRateId == ID && c.IsActive == true);
            if (appsrate != null)
            {
                serviceResponce.Data = _mapper.Map<GetAppsRateDto>(appsrate);
            }
            else
            {
                serviceResponce.Success = false;
                serviceResponce.Message = "No Record Found";
            }
            return serviceResponce;
        }
       
        public async Task<ServiceResponce<GetAppsRateDto>> UpdateAppsRate(UpdatedAppsRateDto updatedAppsRate)
        {
            ServiceResponce<GetAppsRateDto> serviceResponce = new ServiceResponce<GetAppsRateDto>();
            try {
                AppsRate appsrate = await _dataContext.AppsRates.FirstOrDefaultAsync(c => c.AppsRateId == updatedAppsRate.AppsRateId && c.IsActive == true);
                if (appsrate.DateFrom.ToString("yyyyMMdd") != DateTime.Now.ToString("yyyyMMdd"))
                {
                    appsrate.DateTo = DateTime.Now.AddDays(-1).Date;
                }
                else
                {
                    appsrate.AppRate = updatedAppsRate.AppRate;
                    appsrate.AppGst = updatedAppsRate.AppGst;
                }
                appsrate.LastModifiedBy = updatedAppsRate.LastModifiedBy;
                appsrate.LastModifiedon = DateTime.Now;
                _dataContext.AppsRates.Update(appsrate);
                await _dataContext.SaveChangesAsync();

                ///add new start
                if (appsrate.DateFrom.ToString("yyyyMMdd") != DateTime.Now.ToString("yyyyMMdd"))
                {
                    AddAppsRateDto newappsrate = new AddAppsRateDto();
                    newappsrate.AppId = appsrate.AppId;
                    newappsrate.AppRate = updatedAppsRate.AppRate;
                    newappsrate.AppGst = updatedAppsRate.AppGst;
                    newappsrate.RangeFrom = appsrate.RangeFrom;
                    newappsrate.RangeTo = appsrate.RangeTo;
                    newappsrate.CreatedBy = updatedAppsRate.LastModifiedBy;
                    //await AddAppsRate(newappsrate);
                    AppsRate appsratenew = _mapper.Map<AppsRate>(newappsrate);
                    appsratenew.DateFrom = DateTime.Now.Date;
                    appsratenew.IsActive = true;
                    appsratenew.CreatedOn = DateTime.Now;
                    await _dataContext.AppsRates.AddAsync(appsratenew);
                    await _dataContext.SaveChangesAsync();
                    serviceResponce.Data = _mapper.Map<GetAppsRateDto>(appsratenew);
                }
                else
                {
                    ///add new end
                    serviceResponce.Data = _mapper.Map<GetAppsRateDto>(appsrate);
                }
            }
            catch(Exception e) {
                serviceResponce.Success = false;
                serviceResponce.Message = e.Message;
            }
            return serviceResponce;

        }

        public async Task<ServiceResponce<List<GetAppsRateDto>>> DeleteAppsRate(int ID)
        {
            ServiceResponce<List<GetAppsRateDto>> serviceResponce = new ServiceResponce<List<GetAppsRateDto>>();
            try
            {
                AppsRate appsrate = await _dataContext.AppsRates.FirstAsync(c => c.AppsRateId == ID);
                appsrate.IsActive = false;
                appsrate.LastModifiedon = DateTime.Now;
                _dataContext.AppsRates.Update(appsrate);
                await _dataContext.SaveChangesAsync();
                serviceResponce.Data = await (_dataContext.AppsRates.Where(x => x.IsActive == true).Select(c => _mapper.Map<GetAppsRateDto>(c))).ToListAsync();
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
