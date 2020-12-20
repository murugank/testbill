using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BillingApi.Dtos.BaseCurrencyDtos;
using BillingApi.Model;

namespace BillingApi.Service.BaseCurrencyServiceObj
{
    public interface IBaseCurrencyService
    {
        Task<ServiceResponce<List<GetBaseCurrencyDto>>> GetAllBaseCurrencys();
        Task<ServiceResponce<GetBaseCurrencyDto>> GetBaseCurrency(int ID);
        Task<ServiceResponce<List<GetBaseCurrencyDto>>> AddBaseCurrency(AddBaseCurrencyDto basecurrency);

        Task<ServiceResponce<GetBaseCurrencyDto>> UpdateBaseCurrency(UpdatedBaseCurrencyDto updatedBaseCurrency);

        Task<ServiceResponce<List<GetBaseCurrencyDto>>> DeleteBaseCurrency(int ID);
    }
}
