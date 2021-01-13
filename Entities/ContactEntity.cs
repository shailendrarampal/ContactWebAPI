using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ContactWebAPI.Entities
{
    public class ContactEntity
    {

        /*Just to uniquely identify*/
        [JsonIgnore]
        public  Guid ContactId { get; set; }
        [Required(ErrorMessage = "FirstName is required")]
        [StringLength(20,ErrorMessage = "Maximum 20 Character is Allowed for FirstName")]
        public string Firstname { get; set; }
        [Required(ErrorMessage = "LastName is required")]
        [StringLength(20, ErrorMessage = "Maximum 20 Character is Allowed for LastName")]
        public string Lastname { get; set; }

        public string Fullname => Firstname + " " + Lastname;
        [Required(ErrorMessage = "Address is required")]
        [StringLength(20, ErrorMessage = "Maximum 100 Character is Allowed for Address")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Address is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Mobile Number is required")]
        [StringLength(10,ErrorMessage = "Only 10 digit Allowed",MinimumLength = 10)]
        public string MobileNumber { get; set; }
        public ICollection<SkillsEntity> Skills { get; set; }
    }
}
