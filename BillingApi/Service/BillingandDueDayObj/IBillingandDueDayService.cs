using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BillingApi.Dtos.BillingandDueDayDtos;
using BillingApi.Model;

namespace BillingApi.Service.BillingandDueDayServiceObj
{
    public interface IBillingandDueDayService
    {
        Task<ServiceResponce<List<GetBillingandDueDayDto>>> GetAllBillingandDueDays();
        Task<ServiceResponce<GetBillingandDueDayDto>> GetBillingandDueDay(int ID);
        Task<ServiceResponce<List<GetBillingandDueDayDto>>> AddBillingandDueDay(AddBillingandDueDayDto basecurrency);

        Task<ServiceResponce<GetBillingandDueDayDto>> UpdateBillingandDueDay(UpdatedBillingandDueDayDto updatedBillingandDueDay);

        Task<ServiceResponce<List<GetBillingandDueDayDto>>> DeleteBillingandDueDay(int ID);
    }
}
