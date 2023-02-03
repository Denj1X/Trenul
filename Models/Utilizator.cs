using System.Text.Json.Serialization;
using NewRepo.Models.Base;
using NewRepo.Models.Enums;


namespace NewRepo.Models
{
	public class User: BaseEntity
	{
		public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        [JsonIgnore]
        public string PasswordHash { get; set; }
        public Role Role { get; set; }
        public Guid? UserId { get; set; }
    }
}
