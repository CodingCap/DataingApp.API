﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataingApp.API.Models;

namespace DataingApp.API.Dtos
{
    public class UserforDetailDto
    {
        public int ID { get; set; }
        public string UserName { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public string KnownAs { get; set; }
        public DateTime Created { get; set; }
        public DateTime LastActive { get; set; }
        public string Introduction { get; set; }
        public string Interests { get; set; }
        public string City { get; set; }
        public string Country { get; set; }

        public string PhotoUrl { get; set; }

        public ICollection<PhotosForDetailedDto> Photos { get; set; }
    }
}
