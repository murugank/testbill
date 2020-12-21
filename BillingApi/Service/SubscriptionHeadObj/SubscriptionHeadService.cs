using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BillingApi.Data;
using BillingApi.Dtos.SubscriptionHeadDtos;
using BillingApi.Model;

namespace BillingApi.Service.SubscriptionHeadServiceObj
{
    public class SubscriptionHeadService : ISubscriptionHeadService
    {
        private readonly IMapper _mapper;
        private readonly DataContext _dataContext;

        public SubscriptionHeadService(IMapper mapper,DataContext dataContext)
        {
            _mapper = mapper;
            _dataContext = dataContext;
        }
       
        public async Task<ServiceResponce<List<GetSubscriptionHeadDto>>> AddSubscriptionHead(AddSubscriptionHeadDto newsubscriptionhead)
        {
            ServiceResponce<List<GetSubscriptionHeadDto>> serviceResponse = new ServiceResponce<List<GetSubscriptionHeadDto>>();
            
            if (await ValidateSubscriptionExists(newsubscriptionhead.CompanyId) == false)
            {
                SubscriptionHead subscriptionhead = _mapper.Map<SubscriptionHead>(newsubscriptionhead);
                subscriptionhead.StartDate = DateTime.Now.Date;
                subscriptionhead.IsActive = true;
                subscriptionhead.CreatedOn = DateTime.Now;
                await _dataContext.SubscriptionHeads.AddAsync(subscriptionhead);
                await _dataContext.SaveChangesAsync();
                serviceResponse.Data = await _dataContext.SubscriptionHeads.Where(x => x.IsActive == true).Select(c => _mapper.Map<GetSubscriptionHeadDto>(c)).ToListAsync();
            }
            else
            {
                serviceResponse.Success = false;
                serviceResponse.Message = "Already Exists";
            }
            return serviceResponse;  
        }
        public async Task<bool> ValidateSubscriptionExists(int CompanyId)
        {
            bool status = false;
            SubscriptionHead subscriptionhead = await _dataContext.SubscriptionHeads.FirstOrDefaultAsync(c => c.CompanyId == CompanyId  && c.IsActive == true);
            if (subscriptionhead != null)
            {
                status = true;
            }

            return status;
        }
        public async Task<ServiceResponce<List<GetSubscriptionHeadDto>>> GetAllSubscriptionHeads()
        {
            ServiceResponce<List<GetSubscriptionHeadDto>> serviceResponce = new ServiceResponce<List<GetSubscriptionHeadDto>>();
            List<SubscriptionHead> DbSubscriptionHeads = await _dataContext.SubscriptionHeads.Where(x => x.IsActive == true).ToListAsync();
            serviceResponce.Data = DbSubscriptionHeads.Select(c=> _mapper.Map<GetSubscriptionHeadDto>(c)).ToList();
            return serviceResponce;
        }

        public async Task<ServiceResponce<GetSubscriptionHeadDto>> GetSubscriptionHead(int ID)
        {
            ServiceResponce<GetSubscriptionHeadDto> serviceResponce = new ServiceResponce<GetSubscriptionHeadDto>();
            SubscriptionHead subscriptionhead = await _dataContext.SubscriptionHeads.FirstOrDefaultAsync(c => c.SubscriptionHeadId == ID && c.IsActive == true);
            if (subscriptionhead != null)
            {
                serviceResponce.Data = _mapper.Map<GetSubscriptionHeadDto>(subscriptionhead);
            }
            else
            {
                serviceResponce.Success = false;
                serviceResponce.Message = "No Record Found";
            }
            return serviceResponce;
        }
       
        public async Task<ServiceResponce<GetSubscriptionHeadDto>> UpdateSubscriptionHead(UpdatedSubscriptionHeadDto updatedSubscriptionHead)
        {
            ServiceResponce<GetSubscriptionHeadDto> serviceResponce = new ServiceResponce<GetSubscriptionHeadDto>();
            try {
                SubscriptionHead subscriptionhead = await _dataContext.SubscriptionHeads.FirstOrDefaultAsync(c => c.SubscriptionHeadId == updatedSubscriptionHead.SubscriptionHeadId && c.IsActive == true);
                if (subscriptionhead.StartDate.ToString("yyyyMMdd") != DateTime.Now.ToString("yyyyMMdd"))
                {
                    subscriptionhead.EndDate = DateTime.Now.AddDays(-1).Date;
                }
                else
                {
                    subscriptionhead.FullName = updatedSubscriptionHead.FullName;
                    subscriptionhead.Email = updatedSubscriptionHead.Email;
                    //subscriptionhead.AppRate = updatedSubscriptionHead.AppRate;
                    //subscriptionhead.AppGst = updatedSubscriptionHead.AppGst;
                }
                subscriptionhead.LastModifiedBy = updatedSubscriptionHead.LastModifiedBy;
                subscriptionhead.LastModifiedon = DateTime.Now;
                _dataContext.SubscriptionHeads.Update(subscriptionhead);
                await _dataContext.SaveChangesAsync();

                ///add new start
                if (subscriptionhead.StartDate.ToString("yyyyMMdd") != DateTime.Now.ToString("yyyyMMdd"))
                {
                    AddSubscriptionHeadDto newsubscriptionhead = new AddSubscriptionHeadDto();
                    newsubscriptionhead.CompanyId = subscriptionhead.CompanyId;
                    newsubscriptionhead.CurrencyCode = subscriptionhead.CurrencyCode; 
                    newsubscriptionhead.FullName = updatedSubscriptionHead.FullName;
                    newsubscriptionhead.Email = updatedSubscriptionHead.Email;
                    newsubscriptionhead.CreatedBy = updatedSubscriptionHead.LastModifiedBy;
                    //await AddSubscriptionHead(newsubscriptionhead);
                    SubscriptionHead subscriptionheadnew = _mapper.Map<SubscriptionHead>(newsubscriptionhead);
                    subscriptionheadnew.StartDate = DateTime.Now.Date;
                    subscriptionheadnew.IsActive = true;
                    subscriptionheadnew.CreatedOn = DateTime.Now;
                    await _dataContext.SubscriptionHeads.AddAsync(subscriptionheadnew);
                    await _dataContext.SaveChangesAsync();
                    serviceResponce.Data = _mapper.Map<GetSubscriptionHeadDto>(subscriptionheadnew);
                }
                else
                {
                    ///add new end
                    serviceResponce.Data = _mapper.Map<GetSubscriptionHeadDto>(subscriptionhead);
                }
            }
            catch(Exception e) {
                serviceResponce.Success = false;
                serviceResponce.Message = e.Message;
            }
            return serviceResponce;

        }

        public async Task<ServiceResponce<List<GetSubscriptionHeadDto>>> DeleteSubscriptionHead(int ID)
        {
            ServiceResponce<List<GetSubscriptionHeadDto>> serviceResponce = new ServiceResponce<List<GetSubscriptionHeadDto>>();
            try
            {
                SubscriptionHead subscriptionhead = await _dataContext.SubscriptionHeads.FirstAsync(c => c.SubscriptionHeadId == ID);
                subscriptionhead.IsActive = false;
                subscriptionhead.LastModifiedon = DateTime.Now;
                _dataContext.SubscriptionHeads.Update(subscriptionhead);
                await _dataContext.SaveChangesAsync();
                serviceResponce.Data = await (_dataContext.SubscriptionHeads.Where(x => x.IsActive == true).Select(c => _mapper.Map<GetSubscriptionHeadDto>(c))).ToListAsync();
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
