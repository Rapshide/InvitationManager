﻿namespace InvitationManagerAPI.Models
{
    public class User
    {

        public Guid ID { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Password { get; set; }
        public int PhoneNumber { get; set; } = 0;
        public string Email { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
    }
}
