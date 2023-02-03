using System;
using System.Text.Json.Serialization;
using NewRepo.Models.Base;
using NewRepo.Models.Enums;

namespace NewRepo.Models
{
	public class Cont: BaseEntity
	{
        public User Email { get; set; }
        public User UserName { get; set; }
        [JsonIgnore]
        public Guid? ClientId { get; set; }
        public string PasswordHash { get; set; }
    }
}
