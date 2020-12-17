using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BillingApi.Dtos.CharacterDtos;
using BillingApi.Model;
using BillingApi.Service.CharacterServiceObj;

namespace BillingApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CharacterController : ControllerBase
    {
        //private static List<Character> characters = new List<Character>()
        //{
        //    new Character(),
        //    new Character{Id=1,Model="v1",Color="White",CharacterType=CharacterType.ThreeWeeler}
        //};
        public ICharacterService _CharacterService { get; }
        public CharacterController(ICharacterService characterService)
        {
            _CharacterService = characterService;
        }

        [HttpGet("getall")]
        public async Task<ActionResult> GetAllCharacters()
        {
            return Ok(await _CharacterService.GetAllCharacters());
        }

        [HttpGet("{ID}")]
        public async Task<ActionResult> GetCharacterByID(int ID)
        {
            return Ok(await _CharacterService.GetCharacter(ID));
        }

        [HttpPost]
        public async Task<ActionResult> AddCharacter(AddCharacterDto newcharacter)
        {
            return Ok(await _CharacterService.AddCharacter(newcharacter));
        }


        [HttpPut]
        public async Task<ActionResult> UpdateCharacter(UpdatedCharacterDto updatedCharacter)
        {
            ServiceResponce<GetCharacterDto> serviceResponce = new ServiceResponce<GetCharacterDto>();
             serviceResponce= await _CharacterService.UpdateCharacter(updatedCharacter);
            if(serviceResponce.Data==null)
            {
                return NotFound(serviceResponce);
            }
            return Ok(serviceResponce);
        }


        [HttpDelete("{ID}")]
        public async Task<ActionResult> DeleteCharacter(int ID)
        {
            ServiceResponce<List<GetCharacterDto>> serviceResponce = new ServiceResponce<List<GetCharacterDto>>();
            serviceResponce =await _CharacterService.DeleteCharacter(ID);
            if(serviceResponce.Data==null)
            {
                return NotFound(serviceResponce);
            }
            return Ok(serviceResponce);
        }
    }
}
