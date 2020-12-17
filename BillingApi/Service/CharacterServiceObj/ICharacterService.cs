using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BillingApi.Dtos.CharacterDtos;
using BillingApi.Model;

namespace BillingApi.Service.CharacterServiceObj
{
    public interface ICharacterService
    {
        Task<ServiceResponce<List<GetCharacterDto>>> GetAllCharacters();
        Task<ServiceResponce<GetCharacterDto>> GetCharacter(int ID);
        Task<ServiceResponce<List<GetCharacterDto>>> AddCharacter(AddCharacterDto character);

        Task<ServiceResponce<GetCharacterDto>> UpdateCharacter(UpdatedCharacterDto updatedCharacter);

        Task<ServiceResponce<List<GetCharacterDto>>> DeleteCharacter(int ID);
    }
}
