using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BillingApi.Dtos.CharacterDtos;
using BillingApi.Model;
using BillingApi.Dtos.AppDtos;

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
        }
    }
}
