using Plataforma.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Plataforma.Domain.Entities
{
    public class Order
    {
        public Order()
        {
            Id = Guid.NewGuid().ToString();
        }

        public string Id { get; set; }
        public string IdUser { get; set; }
        public string IdProduct { get; set; }
        public int Quantity { get; set; }
        public int Points { get; set; }
        public EStatusOrder EStatusOrder { get; set; }
    }
}
