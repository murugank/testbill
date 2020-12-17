using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BillingApi.Model;

namespace BillingApi.Dtos.CharacterDtos
{
    public class UpdatedCharacterDto
    {
        public int Id { get; set; } = 0;
        public string Model { get; set; } = "v0";
        public string Color { get; set; } = "red";
        public CharacterType CharacterType { get; set; } = CharacterType.TwoWeeler;
        public int LastModifiedBy { get; set; } = 0;

    }
}
