using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewRepo.Data;
using NewRepo.Helpers.Attributes;
using NewRepo.Models.DTOs.TrenDTO;
using NewRepo.Models.Enums;
using NewRepo.Services.TrenService;

namespace NewRepo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrenController : ControllerBase
    {
        private readonly ITrenService _trenService;
        private readonly DataBaseContext _context;

        public TrenController(ITrenService trenService, DataBaseContext context)
        {
            _trenService = trenService;
            _context = context;
        }

        [Authorization(Role.Admin)]
        [HttpGet("admin")]
        [HttpPost]
        public async Task<IActionResult> AddTren(TrenDTO tren)
        {
            return await _trenService.AddTren(tren);
        }

        [HttpPut("{id}")]
        public async Task<TrenDTO> UpdateTren(TrenDTO tren, string sosire)
        {
            return await _trenService.UpdateTren(tren, sosire);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTren(Guid id)
        {
            var tren = await _trenService.GetTren(id);
            if(tren == null)
            {
                return NotFound();
            }

            var currUser = HttpContext.User;
            if (!currUser.Identity.IsAuthenticated) return Forbid();

            if(currUser.IsInRole("Admin"))
            {
                await _trenService.DeleteTren(id);
                return NoContent();
            }

            else
            {
                return Forbid();
            }
        }
    }
}