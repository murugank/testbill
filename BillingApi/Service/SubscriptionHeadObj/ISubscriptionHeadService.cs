using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BillingApi.Dtos.SubscriptionHeadDtos;
using BillingApi.Model;

namespace BillingApi.Service.SubscriptionHeadServiceObj
{
    public interface ISubscriptionHeadService
    {
        Task<ServiceResponce<List<GetSubscriptionHeadDto>>> GetAllSubscriptionHeads();
        Task<ServiceResponce<GetSubscriptionHeadDto>> GetSubscriptionHead(int ID);
        Task<ServiceResponce<List<GetSubscriptionHeadDto>>> AddSubscriptionHead(AddSubscriptionHeadDto subscriptionhead);

        Task<ServiceResponce<GetSubscriptionHeadDto>> UpdateSubscriptionHead(UpdatedSubscriptionHeadDto updatedSubscriptionHead);

        Task<ServiceResponce<List<GetSubscriptionHeadDto>>> DeleteSubscriptionHead(int ID);
    }
}
