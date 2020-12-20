using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BillingApi.Dtos.AppsRateDtos;
using BillingApi.Model;

namespace BillingApi.Service.AppsRateServiceObj
{
    public interface IAppsRateService
    {
        Task<ServiceResponce<List<GetAppsRateDto>>> GetAllAppsRates();
        Task<ServiceResponce<GetAppsRateDto>> GetAppsRate(int ID);
        Task<ServiceResponce<List<GetAppsRateDto>>> AddAppsRate(AddAppsRateDto appsrate);

        Task<ServiceResponce<GetAppsRateDto>> UpdateAppsRate(UpdatedAppsRateDto updatedAppsRate);

        Task<ServiceResponce<List<GetAppsRateDto>>> DeleteAppsRate(int ID);
    }
}
