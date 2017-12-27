using System;
using System.ComponentModel.DataAnnotations;

namespace Monilyzer.Model
{
    public class UsernamePassword
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
    }
}