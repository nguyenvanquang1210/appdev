using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FptBook.Models;
using Microsoft.AspNetCore.Identity;

namespace FptBook.Areas.Identity.Data;

// Add profile data for application users by adding properties to the FptBookUser class
public class FptBookUser : IdentityUser
{
    public string Fullname { get; set; }
    public DateTime? Dob { get; set; }
    public string? Address { get; set; }
   // public string? Gender { get; set; }
    public Store? Store { get; set; } // 1 app user co the co store or khong co
    public virtual ICollection<Order>? Orders { get; set; }
    public virtual ICollection<Cart>? Carts { get; set; }

    
  
}

