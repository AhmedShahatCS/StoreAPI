using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Store.Core.Entity.Identity
{
    public class AppUser:IdentityUser
    {
        public string DisplayName {  get; set; }
        public Address Address { get; set; }


    }
}
