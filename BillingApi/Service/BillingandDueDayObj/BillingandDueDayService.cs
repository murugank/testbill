using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BillingApi.Data;
using BillingApi.Dtos.BillingandDueDayDtos;
using BillingApi.Model;

namespace BillingApi.Service.BillingandDueDayServiceObj
{
    public class BillingandDueDayService : IBillingandDueDayService
    {
        private readonly IMapper _mapper;
        private readonly DataContext _dataContext;

        public BillingandDueDayService(IMapper mapper,DataContext dataContext)
        {
            _mapper = mapper;
            _dataContext = dataContext;
        }
       
        public async Task<ServiceResponce<List<GetBillingandDueDayDto>>> AddBillingandDueDay(AddBillingandDueDayDto newbasecurrency)
        {
            ServiceResponce<List<GetBillingandDueDayDto>> serviceResponse = new ServiceResponce<List<GetBillingandDueDayDto>>();
            BillingandDueDay basecurrency = _mapper.Map<BillingandDueDay>(newbasecurrency);
            basecurrency.IsActive = true;
            basecurrency.CreatedOn = DateTime.Now;
            await _dataContext.BillingandDueDays.AddAsync(basecurrency);
            await _dataContext.SaveChangesAsync();
            serviceResponse.Data = await _dataContext.BillingandDueDays.Where(x => x.IsActive == true).Select(c => _mapper.Map<GetBillingandDueDayDto>(c)).ToListAsync();


            return serviceResponse;  
        }

        public async Task<ServiceResponce<List<GetBillingandDueDayDto>>> GetAllBillingandDueDays()
        {
            ServiceResponce<List<GetBillingandDueDayDto>> serviceResponce = new ServiceResponce<List<GetBillingandDueDayDto>>();
            List<BillingandDueDay> DbBillingandDueDays = await _dataContext.BillingandDueDays.Where(x => x.IsActive == true).ToListAsync();
            serviceResponce.Data = DbBillingandDueDays.Select(c=> _mapper.Map<GetBillingandDueDayDto>(c)).ToList();
            return serviceResponce;
        }

        public async Task<ServiceResponce<GetBillingandDueDayDto>> GetBillingandDueDay(int ID)
        {
            ServiceResponce<GetBillingandDueDayDto> serviceResponce = new ServiceResponce<GetBillingandDueDayDto>();
            BillingandDueDay basecurrency = await _dataContext.BillingandDueDays.FirstOrDefaultAsync(c => c.BillingandDueDayId == ID && c.IsActive == true);
            if (basecurrency != null)
            {
                serviceResponce.Data = _mapper.Map<GetBillingandDueDayDto>(basecurrency);
            }
            else
            {
                serviceResponce.Success = false;
                serviceResponce.Message = "No Record Found";
            }
            return serviceResponce;
        }
        
        public async Task<ServiceResponce<GetBillingandDueDayDto>> UpdateBillingandDueDay(UpdatedBillingandDueDayDto updatedBillingandDueDay)
        {
            ServiceResponce<GetBillingandDueDayDto> serviceResponce = new ServiceResponce<GetBillingandDueDayDto>();
            try {
                BillingandDueDay basecurrency = await _dataContext.BillingandDueDays.FirstOrDefaultAsync(c => c.BillingandDueDayId == updatedBillingandDueDay.BillingandDueDayId && c.IsActive == true);
                basecurrency.BillingDay = updatedBillingandDueDay.BillingDay;
                basecurrency.BillingDueDay = updatedBillingandDueDay.BillingDueDay;
                basecurrency.LastModifiedBy = updatedBillingandDueDay.LastModifiedBy;
                basecurrency.LastModifiedon = DateTime.Now;
                _dataContext.BillingandDueDays.Update(basecurrency);
                await _dataContext.SaveChangesAsync();
                serviceResponce.Data = _mapper.Map<GetBillingandDueDayDto>(basecurrency);
            }
            catch(Exception e) {
                serviceResponce.Success = false;
                serviceResponce.Message = e.Message;
            }
            return serviceResponce;

        }

        public async Task<ServiceResponce<List<GetBillingandDueDayDto>>> DeleteBillingandDueDay(int ID)
        {
            ServiceResponce<List<GetBillingandDueDayDto>> serviceResponce = new ServiceResponce<List<GetBillingandDueDayDto>>();
            try
            {
                BillingandDueDay basecurrency = await _dataContext.BillingandDueDays.FirstAsync(c => c.BillingandDueDayId == ID);
                basecurrency.IsActive = false;
                basecurrency.LastModifiedon = DateTime.Now;
                _dataContext.BillingandDueDays.Update(basecurrency);
                await _dataContext.SaveChangesAsync();
                serviceResponce.Data = await (_dataContext.BillingandDueDays.Where(x => x.IsActive == true).Select(c => _mapper.Map<GetBillingandDueDayDto>(c))).ToListAsync();
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
