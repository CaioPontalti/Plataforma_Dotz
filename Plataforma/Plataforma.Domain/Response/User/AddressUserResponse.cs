using Plataforma.Domain.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Plataforma.Domain.Response.User
{
    public class AddressUserResponse
    {
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
