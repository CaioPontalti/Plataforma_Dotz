using System;
using System.Collections.Generic;
using System.Text;

namespace Plataforma.Domain.Entities
{
    public class Product
    {
        public Product()
        {
            Id = Guid.NewGuid().ToString();
        }
        public string Id { get; set; }
        public string Name { get; set; }
        public int Points { get; set; }
        public int Quantity { get; set; }
    }
}
