﻿namespace Dunbar.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string FirebaseId { get; }
        public string UserName { get; set; }
        public string Email { get; set; }
    }
}
