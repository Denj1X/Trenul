using System;
using NewRepo.Helpers.JwtUtils;
using NewRepo.Services.UserService;

namespace proiect.Helpers.Middleware
{
    public class JwtMiddleware
    {
        private readonly RequestDelegate _nextRequestDelegate;

        public JwtMiddleware(RequestDelegate nextRequestDelegate)
        {
            _nextRequestDelegate = nextRequestDelegate;
        }

        public async Task Invoke(HttpContext httpcontext, IUserService userService, IJwtUtils jwtUtils)
        {
            var token = httpcontext.Request.Headers["Authorization"].FirstOrDefault()?.Split("").Last();
            var userId = jwtUtils.ValidateJwtToken(token);

            if (userId != Guid.Empty)
            {
                httpcontext.Items["User"] = userService.GetById(userId);
            }

            await _nextRequestDelegate(httpcontext);
        }
    }
}