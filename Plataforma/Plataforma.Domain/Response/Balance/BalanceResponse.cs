﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Plataforma.Domain.Response.Balance
{
    public class BalanceResponse
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public int Points { get; set; }
        public string TypeMovement { get; set; }
    }
}
