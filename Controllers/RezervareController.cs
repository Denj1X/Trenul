using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewRepo.Data;
using NewRepo.Helpers.Attributes;
using NewRepo.Models;
using NewRepo.Services.ReservService;

namespace NewRepo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RezervareController: ControllerBase
    {
        private readonly IReservService _reservService;

        public RezervareController(IReservService reservService)
        {
            _reservService = reservService;
        }

        [HttpPost("Adauga-rezervare")]
        public async Task<IActionResult> Create(RezervareDTO rez)
        {
            return await _reservService.CreateRezAsync(rez);
        }

        [HttpGet("{UserId}")]
        public async Task<IActionResult> GetReserv(Guid UserId)
        {
            var rez = await _reservService.GetOrderByUserId(UserId);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateReserv(RezervareDTO rez, bool status)
        {
            return await _reservService.UpdateRezStatus(rez, status);
        }
    }
}