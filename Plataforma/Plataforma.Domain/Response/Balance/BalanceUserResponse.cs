using System;
using System.Collections.Generic;
using System.Text;

namespace Plataforma.Domain.Response.Balance
{
    public class BalanceUserResponse
    {
        public int TotalCredit { get; set; }
        public int TotalDebit { get; set; }
        public int Total { get; set; }
    }
}
