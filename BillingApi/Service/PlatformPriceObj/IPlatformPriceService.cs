using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BillingApi.Dtos.PlatformPriceDtos;
using BillingApi.Model;

namespace BillingApi.Service.PlatformPriceServiceObj
{
    public interface IPlatformPriceService
    {
        Task<ServiceResponce<List<GetPlatformPriceDto>>> GetAllPlatformPrices();
        Task<ServiceResponce<GetPlatformPriceDto>> GetPlatformPrice(int ID);
        Task<ServiceResponce<List<GetPlatformPriceDto>>> AddPlatformPrice(AddPlatformPriceDto platformprice);

        Task<ServiceResponce<GetPlatformPriceDto>> UpdatePlatformPrice(UpdatedPlatformPriceDto updatedPlatformPrice);

        Task<ServiceResponce<List<GetPlatformPriceDto>>> DeletePlatformPrice(int ID);
    }
}
