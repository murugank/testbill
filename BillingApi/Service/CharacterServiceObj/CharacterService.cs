using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BillingApi.Data;
using BillingApi.Dtos.CharacterDtos;
using BillingApi.Model;

namespace BillingApi.Service.CharacterServiceObj
{
    public class CharacterService : ICharacterService
    {
        private readonly IMapper _mapper;
        private readonly DataContext _dataContext;

        public CharacterService(IMapper mapper,DataContext dataContext)
        {
            _mapper = mapper;
            _dataContext = dataContext;
        }
        private static List<Character> characters = new List<Character>()
        {
            new Character(),
            new Character{Id=1,Model="v1",Color="White",CharacterType=CharacterType.ThreeWeeler}
        };
        

        public async Task<ServiceResponce<List<GetCharacterDto>>> AddCharacter(AddCharacterDto newcharacter)
        {
            ServiceResponce<List<GetCharacterDto>> serviceResponse = new ServiceResponce<List<GetCharacterDto>>();
            Character character = _mapper.Map<Character>(newcharacter);
            //character.Id = characters.Max(c => c.Id) + 1;
            //characters.Add(character);
            //serviceResponse.Data = characters.Select(c=>_mapper.Map<GetCharacterDto>(c)).ToList();
            character.IsActive = true;
            character.CreatedOn = DateTime.Now;
            await _dataContext.Characters.AddAsync(character);
            await _dataContext.SaveChangesAsync();
            serviceResponse.Data = await _dataContext.Characters.Where(x => x.IsActive == true).Select(c => _mapper.Map<GetCharacterDto>(c)).ToListAsync();


            return serviceResponse;  
        }

        public async Task<ServiceResponce<List<GetCharacterDto>>> GetAllCharacters()
        {
            ServiceResponce<List<GetCharacterDto>> serviceResponce = new ServiceResponce<List<GetCharacterDto>>();
            List<Character> DbCharacters = await _dataContext.Characters.Where(x => x.IsActive == true).ToListAsync();
            serviceResponce.Data = DbCharacters.Select(c=> _mapper.Map<GetCharacterDto>(c)).ToList();
            return serviceResponce;
        }

        public async Task<ServiceResponce<GetCharacterDto>> GetCharacter(int ID)
        {
            ServiceResponce<GetCharacterDto> serviceResponce = new ServiceResponce<GetCharacterDto>();
            //Character character = characters.FirstOrDefault(c => c.Id == ID);
            Character character = await _dataContext.Characters.FirstOrDefaultAsync(c => c.Id == ID);
            if (character != null)
            {
                serviceResponce.Data = _mapper.Map<GetCharacterDto>(character);
            }
            else
            {
                serviceResponce.Success = false;
                serviceResponce.Message = "No Record Found";
            }
            return serviceResponce;
        }
        
        public async Task<ServiceResponce<GetCharacterDto>> UpdateCharacter(UpdatedCharacterDto updatedCharacter)
        {
            ServiceResponce<GetCharacterDto> serviceResponce = new ServiceResponce<GetCharacterDto>();
            try {
                //Character character = characters.FirstOrDefault(c => c.Id == updatedCharacter.Id);
                Character character = await _dataContext.Characters.FirstOrDefaultAsync(c => c.Id == updatedCharacter.Id);
                character.Model = updatedCharacter.Model;
                character.Color = updatedCharacter.Color;
                character.CharacterType = updatedCharacter.CharacterType;
                character.LastModifiedBy = updatedCharacter.LastModifiedBy;
                character.LastModifiedon = DateTime.Now;
                _dataContext.Characters.Update(character);
                await _dataContext.SaveChangesAsync();
                serviceResponce.Data = _mapper.Map<GetCharacterDto>(character);
            }
            catch(Exception e) {
                serviceResponce.Success = false;
                serviceResponce.Message = e.Message;
            }
            return serviceResponce;

        }

        public async Task<ServiceResponce<List<GetCharacterDto>>> DeleteCharacter(int ID)
        {
            ServiceResponce<List<GetCharacterDto>> serviceResponce = new ServiceResponce<List<GetCharacterDto>>();
            try
            {
                //Character character = characters.First(c => c.Id == ID);
                //characters.Remove(character);
                //serviceResponce.Data = (characters.Select(c => _mapper.Map<GetCharacterDto>(c))).ToList();
                Character character = await _dataContext.Characters.FirstAsync(c => c.Id == ID);
                //character.LastModifiedBy = updatedCharacter.LastModifiedBy;
                character.IsActive = false;
                character.LastModifiedon = DateTime.Now;
                _dataContext.Characters.Update(character);
                //_dataContext.Characters.Remove(character);
                await _dataContext.SaveChangesAsync();
                serviceResponce.Data = await (_dataContext.Characters.Where(x => x.IsActive == true).Select(c => _mapper.Map<GetCharacterDto>(c))).ToListAsync();
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
