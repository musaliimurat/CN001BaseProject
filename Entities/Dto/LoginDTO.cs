﻿using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dto
{
    public class LoginDTO : IDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
