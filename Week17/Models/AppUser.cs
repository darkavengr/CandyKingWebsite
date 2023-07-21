﻿using Microsoft.AspNetCore.Identity;

namespace Week17.Models
{
    public class AppUser : IdentityUser
    {        
        
        public string FirstName { get; set; }
        public string LastName { get; set; }    
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Email { get; set; }  
        public string PhoneNumber { get; set; }                

    }
}
