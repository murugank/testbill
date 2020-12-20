using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BillingApi.Dtos.CurrencyRateDtos;
using BillingApi.Model;

namespace BillingApi.Service.CurrencyRateServiceObj
{
    public interface ICurrencyRateService
    {
        Task<ServiceResponce<List<GetCurrencyRateDto>>> GetAllCurrencyRates();
        Task<ServiceResponce<GetCurrencyRateDto>> GetCurrencyRate(int ID);
        Task<ServiceResponce<List<GetCurrencyRateDto>>> AddCurrencyRate(AddCurrencyRateDto currencyrate);

        Task<ServiceResponce<GetCurrencyRateDto>> UpdateCurrencyRate(UpdatedCurrencyRateDto updatedCurrencyRate);

        Task<ServiceResponce<List<GetCurrencyRateDto>>> DeleteCurrencyRate(int ID);
    }
}
