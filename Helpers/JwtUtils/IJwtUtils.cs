using System;
using NewRepo.Models;

namespace NewRepo.Helpers.JwtUtils
{
	public interface IJwtUtils
	{
		public string GenerateJwtToken(User user);
		public Guid ValidateToken(string token);
	}
}
