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
        public string nPhone { get; set; }
        public Cont UserName { get; set; }
        public Role Role { get; set; }
        public Cont UserId { get; set; }
        public List<Rezervare> rez { get; set; } = new List<Rezervare>();
    }
}
