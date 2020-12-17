using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BillingApi.Model;

namespace BillingApi.Dtos.CharacterDtos
{
    public class GetCharacterDto
    {
        public int Id { get; set; } = 0;
        public string Model { get; set; } = "v0";
        public string Color { get; set; } = "red";
        public CharacterType CharacterType { get; set; } = CharacterType.TwoWeeler;
        public int EntityID { get; set; } = 0;
        public bool IsActive { get; set; } = true;
        public DateTime CreatedOn { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? LastModifiedon { get; set; }
        public int? LastModifiedBy { get; set; }
    }
}
