using System;
using System.Collections.Generic;
using System.Text;

namespace Plataforma.Domain.Response.Product
{
    public class ProductResponse
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int Value { get; set; }
        public int Quantity { get; set; }
    }
}
