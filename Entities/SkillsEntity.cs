using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ContactWebAPI.Entities
{
    public class SkillsEntity
    {
        [JsonIgnore]
        public Guid SkillId { get; set; }
        [Required(ErrorMessage = "Please Provide Skill Name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please Provide Level (expertise)")]
        [Range(minimum: 1, maximum: 3, ErrorMessage = "Please Provide expertise between 1 to 3")]
        public int Level { get; set; }
        [JsonIgnore]
        public ICollection<ContactEntity> ContactEntities { get; set; }
    }
}
