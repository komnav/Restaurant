﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantLayer.Dtos.Account.Responses
{
    public class AuthResponse
    {
        public required string Token { get; set; }
    }
}
