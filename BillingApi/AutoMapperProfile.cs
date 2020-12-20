using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BillingApi.Dtos.CharacterDtos;
using BillingApi.Model;
using BillingApi.Dtos.AppDtos;
using BillingApi.Dtos.BaseCurrencyDtos;
using BillingApi.Dtos.CurrencyRateDtos;
using BillingApi.Dtos.PlatformPriceDtos;
using BillingApi.Dtos.BillingandDueDayDtos;

namespace WebapiTest3
{
    public class AutoMapperProfile: Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Character, GetCharacterDto>();
            CreateMap<AddCharacterDto,Character>();
            CreateMap<UpdatedCharacterDto, Character>();

            CreateMap<App, GetAppDto>();
            CreateMap<AddAppDto, App>();
            CreateMap<UpdatedAppDto, App>();

            CreateMap<BaseCurrency, GetBaseCurrencyDto>();
            CreateMap<AddBaseCurrencyDto, BaseCurrency>();
            CreateMap<UpdatedBaseCurrencyDto, BaseCurrency>();

            CreateMap<CurrencyRate, GetCurrencyRateDto>();
            CreateMap<AddCurrencyRateDto, CurrencyRate>();
            CreateMap<UpdatedCurrencyRateDto, CurrencyRate>();

            CreateMap<PlatformPrice, GetPlatformPriceDto>();
            CreateMap<AddPlatformPriceDto, PlatformPrice>();
            CreateMap<UpdatedPlatformPriceDto, PlatformPrice>();

            CreateMap<BillingandDueDay, GetBillingandDueDayDto>();
            CreateMap<AddBillingandDueDayDto, BillingandDueDay>();
            CreateMap<UpdatedBillingandDueDayDto, BillingandDueDay>();
        }
    }
}
