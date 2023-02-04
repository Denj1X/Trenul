﻿using System;
using System.ComponentModel.DataAnnotations;

namespace NewRepo.Models.DTOs.UserDTO
{
    public class ContRequestDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
