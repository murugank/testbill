using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BillingApi.Data;
using BillingApi.Dtos.BaseCurrencyDtos;
using BillingApi.Model;

namespace BillingApi.Service.BaseCurrencyServiceObj
{
    public class BaseCurrencyService : IBaseCurrencyService
    {
        private readonly IMapper _mapper;
        private readonly DataContext _dataContext;

        public BaseCurrencyService(IMapper mapper,DataContext dataContext)
        {
            _mapper = mapper;
            _dataContext = dataContext;
        }
       
        public async Task<ServiceResponce<List<GetBaseCurrencyDto>>> AddBaseCurrency(AddBaseCurrencyDto newbasecurrency)
        {
            ServiceResponce<List<GetBaseCurrencyDto>> serviceResponse = new ServiceResponce<List<GetBaseCurrencyDto>>();
            BaseCurrency basecurrency = _mapper.Map<BaseCurrency>(newbasecurrency);
            basecurrency.IsActive = true;
            basecurrency.CreatedOn = DateTime.Now;
            await _dataContext.BaseCurrencys.AddAsync(basecurrency);
            await _dataContext.SaveChangesAsync();
            serviceResponse.Data = await _dataContext.BaseCurrencys.Where(x => x.IsActive == true).Select(c => _mapper.Map<GetBaseCurrencyDto>(c)).ToListAsync();


            return serviceResponse;  
        }

        public async Task<ServiceResponce<List<GetBaseCurrencyDto>>> GetAllBaseCurrencys()
        {
            ServiceResponce<List<GetBaseCurrencyDto>> serviceResponce = new ServiceResponce<List<GetBaseCurrencyDto>>();
            List<BaseCurrency> DbBaseCurrencys = await _dataContext.BaseCurrencys.Where(x => x.IsActive == true).ToListAsync();
            serviceResponce.Data = DbBaseCurrencys.Select(c=> _mapper.Map<GetBaseCurrencyDto>(c)).ToList();
            return serviceResponce;
        }

        public async Task<ServiceResponce<GetBaseCurrencyDto>> GetBaseCurrency(int ID)
        {
            ServiceResponce<GetBaseCurrencyDto> serviceResponce = new ServiceResponce<GetBaseCurrencyDto>();
            BaseCurrency basecurrency = await _dataContext.BaseCurrencys.FirstOrDefaultAsync(c => c.BaseCurrencyId == ID && c.IsActive == true);
            if (basecurrency != null)
            {
                serviceResponce.Data = _mapper.Map<GetBaseCurrencyDto>(basecurrency);
            }
            else
            {
                serviceResponce.Success = false;
                serviceResponce.Message = "No Record Found";
            }
            return serviceResponce;
        }
        
        public async Task<ServiceResponce<GetBaseCurrencyDto>> UpdateBaseCurrency(UpdatedBaseCurrencyDto updatedBaseCurrency)
        {
            ServiceResponce<GetBaseCurrencyDto> serviceResponce = new ServiceResponce<GetBaseCurrencyDto>();
            try {
                BaseCurrency basecurrency = await _dataContext.BaseCurrencys.FirstOrDefaultAsync(c => c.BaseCurrencyId == updatedBaseCurrency.BaseCurrencyId && c.IsActive == true);
                basecurrency.BaseCurrencyCode = updatedBaseCurrency.BaseCurrencyCode;
                basecurrency.LastModifiedBy = updatedBaseCurrency.LastModifiedBy;
                basecurrency.LastModifiedon = DateTime.Now;
                _dataContext.BaseCurrencys.Update(basecurrency);
                await _dataContext.SaveChangesAsync();
                serviceResponce.Data = _mapper.Map<GetBaseCurrencyDto>(basecurrency);
            }
            catch(Exception e) {
                serviceResponce.Success = false;
                serviceResponce.Message = e.Message;
            }
            return serviceResponce;

        }

        public async Task<ServiceResponce<List<GetBaseCurrencyDto>>> DeleteBaseCurrency(int ID)
        {
            ServiceResponce<List<GetBaseCurrencyDto>> serviceResponce = new ServiceResponce<List<GetBaseCurrencyDto>>();
            try
            {
                BaseCurrency basecurrency = await _dataContext.BaseCurrencys.FirstAsync(c => c.BaseCurrencyId == ID);
                basecurrency.IsActive = false;
                basecurrency.LastModifiedon = DateTime.Now;
                _dataContext.BaseCurrencys.Update(basecurrency);
                await _dataContext.SaveChangesAsync();
                serviceResponce.Data = await (_dataContext.BaseCurrencys.Where(x => x.IsActive == true).Select(c => _mapper.Map<GetBaseCurrencyDto>(c))).ToListAsync();
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
