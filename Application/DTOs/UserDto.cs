﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class UserDto
    {
        public string DisplayName { get; set; }
        public string UserName { get; set; }
        public string Token { get; set; }
        public string Image { get; set; }
    }
}
