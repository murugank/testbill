using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BillingApi.Data;
using BillingApi.Dtos.CurrencyRateDtos;
using BillingApi.Model;

namespace BillingApi.Service.CurrencyRateServiceObj
{
    public class CurrencyRateService : ICurrencyRateService
    {
        private readonly IMapper _mapper;
        private readonly DataContext _dataContext;

        public CurrencyRateService(IMapper mapper,DataContext dataContext)
        {
            _mapper = mapper;
            _dataContext = dataContext;
        }
       
        public async Task<ServiceResponce<List<GetCurrencyRateDto>>> AddCurrencyRate(AddCurrencyRateDto newcurrencyrate)
        {
            ServiceResponce<List<GetCurrencyRateDto>> serviceResponse = new ServiceResponce<List<GetCurrencyRateDto>>();
            
            if (await ValidateCurrencyCodeExists(newcurrencyrate.CurrencyRateCode) == false)
            {
                CurrencyRate currencyrate = _mapper.Map<CurrencyRate>(newcurrencyrate);
                currencyrate.IsActive = true;
                currencyrate.CreatedOn = DateTime.Now;
                await _dataContext.CurrencyRates.AddAsync(currencyrate);
                await _dataContext.SaveChangesAsync();
                serviceResponse.Data = await _dataContext.CurrencyRates.Where(x => x.IsActive == true).Select(c => _mapper.Map<GetCurrencyRateDto>(c)).ToListAsync();
            }
            else
            {
                serviceResponse.Success = false;
                serviceResponse.Message = newcurrencyrate.CurrencyRateCode + " Already Exists";
            }
            return serviceResponse;  
        }
        public async Task<bool> ValidateCurrencyCodeExists(string CurrencyRateCode)
        {
            bool status = false;
            CurrencyRate currencyrate = await _dataContext.CurrencyRates.FirstOrDefaultAsync(c => c.CurrencyRateCode == CurrencyRateCode && c.IsActive == true);
            if (currencyrate != null)
            {
                status = true;
            }

            return status;
        }
        public async Task<ServiceResponce<List<GetCurrencyRateDto>>> GetAllCurrencyRates()
        {
            ServiceResponce<List<GetCurrencyRateDto>> serviceResponce = new ServiceResponce<List<GetCurrencyRateDto>>();
            List<CurrencyRate> DbCurrencyRates = await _dataContext.CurrencyRates.Where(x => x.IsActive == true).ToListAsync();
            serviceResponce.Data = DbCurrencyRates.Select(c=> _mapper.Map<GetCurrencyRateDto>(c)).ToList();
            return serviceResponce;
        }

        public async Task<ServiceResponce<GetCurrencyRateDto>> GetCurrencyRate(int ID)
        {
            ServiceResponce<GetCurrencyRateDto> serviceResponce = new ServiceResponce<GetCurrencyRateDto>();
            CurrencyRate currencyrate = await _dataContext.CurrencyRates.FirstOrDefaultAsync(c => c.CurrencyRateId == ID && c.IsActive == true);
            if (currencyrate != null)
            {
                serviceResponce.Data = _mapper.Map<GetCurrencyRateDto>(currencyrate);
            }
            else
            {
                serviceResponce.Success = false;
                serviceResponce.Message = "No Record Found";
            }
            return serviceResponce;
        }
       
        public async Task<ServiceResponce<GetCurrencyRateDto>> UpdateCurrencyRate(UpdatedCurrencyRateDto updatedCurrencyRate)
        {
            ServiceResponce<GetCurrencyRateDto> serviceResponce = new ServiceResponce<GetCurrencyRateDto>();
            try {
                CurrencyRate currencyrate = await _dataContext.CurrencyRates.FirstOrDefaultAsync(c => c.CurrencyRateId == updatedCurrencyRate.CurrencyRateId && c.IsActive == true);
                //currencyrate.CurrencyRateCode = updatedCurrencyRate.CurrencyRateCode;
                currencyrate.CurrencyValue = updatedCurrencyRate.CurrencyValue;
                currencyrate.LastModifiedBy = updatedCurrencyRate.LastModifiedBy;
                currencyrate.LastModifiedon = DateTime.Now;
                _dataContext.CurrencyRates.Update(currencyrate);
                await _dataContext.SaveChangesAsync();
                serviceResponce.Data = _mapper.Map<GetCurrencyRateDto>(currencyrate);
            }
            catch(Exception e) {
                serviceResponce.Success = false;
                serviceResponce.Message = e.Message;
            }
            return serviceResponce;

        }

        public async Task<ServiceResponce<List<GetCurrencyRateDto>>> DeleteCurrencyRate(int ID)
        {
            ServiceResponce<List<GetCurrencyRateDto>> serviceResponce = new ServiceResponce<List<GetCurrencyRateDto>>();
            try
            {
                CurrencyRate currencyrate = await _dataContext.CurrencyRates.FirstAsync(c => c.CurrencyRateId == ID);
                currencyrate.IsActive = false;
                currencyrate.LastModifiedon = DateTime.Now;
                _dataContext.CurrencyRates.Update(currencyrate);
                await _dataContext.SaveChangesAsync();
                serviceResponce.Data = await (_dataContext.CurrencyRates.Where(x => x.IsActive == true).Select(c => _mapper.Map<GetCurrencyRateDto>(c))).ToListAsync();
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
