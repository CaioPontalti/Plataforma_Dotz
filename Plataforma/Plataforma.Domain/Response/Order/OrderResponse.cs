using System;
using System.Collections.Generic;
using System.Text;

namespace Plataforma.Domain.Response.Order
{
    public class OrderResponse
    {
        public string Id { get; set; }
        public string IdUser { get; set; }
        public string IdProduct { get; set; }
        public int Quantity { get; set; }
        public int Points { get; set; }
        public string EStatusOrder { get; set; }
    }
}
