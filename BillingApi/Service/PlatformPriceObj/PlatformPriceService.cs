using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BillingApi.Data;
using BillingApi.Dtos.PlatformPriceDtos;
using BillingApi.Model;

namespace BillingApi.Service.PlatformPriceServiceObj
{
    public class PlatformPriceService : IPlatformPriceService
    {
        private readonly IMapper _mapper;
        private readonly DataContext _dataContext;

        public PlatformPriceService(IMapper mapper, DataContext dataContext)
        {
            _mapper = mapper;
            _dataContext = dataContext;
        }

        public async Task<ServiceResponce<List<GetPlatformPriceDto>>> AddPlatformPrice(AddPlatformPriceDto newplatformprice)
        {
            ServiceResponce<List<GetPlatformPriceDto>> serviceResponse = new ServiceResponce<List<GetPlatformPriceDto>>();
            PlatformPrice platformprice = _mapper.Map<PlatformPrice>(newplatformprice);
            platformprice.IsActive = true;
            platformprice.CreatedOn = DateTime.Now;
            await _dataContext.PlatformPrices.AddAsync(platformprice);
            await _dataContext.SaveChangesAsync();
            serviceResponse.Data = await _dataContext.PlatformPrices.Where(x => x.IsActive == true).Select(c => _mapper.Map<GetPlatformPriceDto>(c)).ToListAsync();

            return serviceResponse;
        }
      
        public async Task<ServiceResponce<List<GetPlatformPriceDto>>> GetAllPlatformPrices()
        {
            ServiceResponce<List<GetPlatformPriceDto>> serviceResponce = new ServiceResponce<List<GetPlatformPriceDto>>();
            List<PlatformPrice> DbPlatformPrices = await _dataContext.PlatformPrices.Where(x => x.IsActive == true).ToListAsync();
            serviceResponce.Data = DbPlatformPrices.Select(c => _mapper.Map<GetPlatformPriceDto>(c)).ToList();
            return serviceResponce;
        }

        public async Task<ServiceResponce<GetPlatformPriceDto>> GetPlatformPrice(int ID)
        {
            ServiceResponce<GetPlatformPriceDto> serviceResponce = new ServiceResponce<GetPlatformPriceDto>();
            PlatformPrice platformprice = await _dataContext.PlatformPrices.FirstOrDefaultAsync(c => c.PlatformPriceId == ID && c.IsActive == true);
            if (platformprice != null)
            {
                serviceResponce.Data = _mapper.Map<GetPlatformPriceDto>(platformprice);
            }
            else
            {
                serviceResponce.Success = false;
                serviceResponce.Message = "No Record Found";
            }
            return serviceResponce;
        }

        public async Task<ServiceResponce<GetPlatformPriceDto>> UpdatePlatformPrice(UpdatedPlatformPriceDto updatedPlatformPrice)
        {
            ServiceResponce<GetPlatformPriceDto> serviceResponce = new ServiceResponce<GetPlatformPriceDto>();
            try
            {
                PlatformPrice platformprice = await _dataContext.PlatformPrices.FirstOrDefaultAsync(c => c.PlatformPriceId == updatedPlatformPrice.PlatformPriceId && c.IsActive == true);
                platformprice.PlatformRate = updatedPlatformPrice.PlatformRate;
                platformprice.GstPlatformRate = updatedPlatformPrice.GstPlatformRate;
                platformprice.LastModifiedBy = updatedPlatformPrice.LastModifiedBy;
                platformprice.LastModifiedon = DateTime.Now;
                _dataContext.PlatformPrices.Update(platformprice);
                await _dataContext.SaveChangesAsync();
                serviceResponce.Data = _mapper.Map<GetPlatformPriceDto>(platformprice);
            }
            catch (Exception e)
            {
                serviceResponce.Success = false;
                serviceResponce.Message = e.Message;
            }
            return serviceResponce;

        }

        public async Task<ServiceResponce<List<GetPlatformPriceDto>>> DeletePlatformPrice(int ID)
        {
            ServiceResponce<List<GetPlatformPriceDto>> serviceResponce = new ServiceResponce<List<GetPlatformPriceDto>>();
            try
            {
                PlatformPrice platformprice = await _dataContext.PlatformPrices.FirstAsync(c => c.PlatformPriceId == ID);
                platformprice.IsActive = false;
                platformprice.LastModifiedon = DateTime.Now;
                _dataContext.PlatformPrices.Update(platformprice);
                await _dataContext.SaveChangesAsync();
                serviceResponce.Data = await (_dataContext.PlatformPrices.Where(x => x.IsActive == true).Select(c => _mapper.Map<GetPlatformPriceDto>(c))).ToListAsync();
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
