using Plataforma.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Plataforma.Domain.Entities
{
    public class Balance
    {
        public Balance()
        {
            Id = Guid.NewGuid().ToString();
        }

        public string Id { get; set; }
        public string UserId { get; set; }
        public int Points { get; set; }
        public int TypeMovement { get; set; }
    }
}
