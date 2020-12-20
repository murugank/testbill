using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BillingApi.Dtos.AppDtos;
using BillingApi.Model;

namespace BillingApi.Service.AppServiceObj
{
    public interface IAppService
    {
        Task<ServiceResponce<List<GetAppDto>>> GetAllApps();
        Task<ServiceResponce<GetAppDto>> GetApp(int ID);
        Task<ServiceResponce<List<GetAppDto>>> AddApp(AddAppDto app);

        Task<ServiceResponce<GetAppDto>> UpdateApp(UpdatedAppDto updatedApp);

        Task<ServiceResponce<List<GetAppDto>>> DeleteApp(int ID);
    }
}
