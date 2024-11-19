﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Core.Entity.Identity
{
    public class Address
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string City { get; set; }

        public string Street { get; set; }

        public string Country { get; set; }

        [ForeignKey(nameof(AppUser))]
        public string AppUserId { get; set; }   //fk for Appuser table in address table
        public AppUser AppUser { get; set; }

    }
}
