using System;
using System.Collections.Generic;
using System.Text;

namespace Plataforma.Domain.Entities
{
    public class AddressUser
    {
        public AddressUser()
        {
            Id = Guid.NewGuid().ToString();
            Activo = true;
        }

        public string Id { get; set; }
        public string UserId { get; set; }
        public string Address { get; set; }
        public string Number { get; set; }
        public string Complement { get; set; }
        public string ZipCode { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public bool Activo { get; set; }
    }
}
