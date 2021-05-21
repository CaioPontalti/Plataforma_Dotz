using Plataforma.Domain.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Plataforma.Domain.ViewModels.User
{
    public class AddressUserViewModel
    {
        public string UserId { get; set; }
        public string Address { get; set; }
        public string Number { get; set; }
        public string Complement { get; set; }
        public string ZipCode { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        
        public Notification Validate()
        {
            var notifications = new Notification();

            if (string.IsNullOrEmpty(UserId))
                notifications.TransactionMessages.Add("Id do usuário obrigatório");

            if (string.IsNullOrEmpty(Address))
                notifications.TransactionMessages.Add("Endereço é obrigatório");

            if (string.IsNullOrEmpty(Number))
                notifications.TransactionMessages.Add("Número é obrigatória");

            if (string.IsNullOrEmpty(ZipCode))
                notifications.TransactionMessages.Add("CEP é obrigatória");

            if (string.IsNullOrEmpty(State))
                notifications.TransactionMessages.Add("Estado é obrigatória");
            
            if (string.IsNullOrEmpty(City))
                notifications.TransactionMessages.Add("Cidade é obrigatória");

            if (string.IsNullOrEmpty(District))
                notifications.TransactionMessages.Add("Bairro é obrigatória");

            return notifications;
        }
    }
}
