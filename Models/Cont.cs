using System;
using System.Text.Json.Serialization;
using NewRepo.Models.Base;
using NewRepo.Models.Enums;

namespace NewRepo.Models
{
	public class Cont: BaseEntity
	{   
        public string UserName { get; set; }
        [JsonIgnore]
        public Guid? UserId { get; set; }
        public Role Role { get; set; }
        public string PasswordHash { get; set; }
    }
}
