using Plataforma.Domain.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Plataforma.Api.ViewModels.User
{
    public class CreateUserViewModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }

        public Notification Validate()
        {
            var notifications = new Notification();

            if (string.IsNullOrEmpty(Name))
                notifications.TransactionMessages.Add("Nome é obrigatório");

            if (string.IsNullOrEmpty(Email))
                notifications.TransactionMessages.Add("Email é obrigatório");

            if (string.IsNullOrEmpty(Password))
                notifications.TransactionMessages.Add("Senha é obrigatória");

            if (Password != ConfirmPassword)
                notifications.TransactionMessages.Add("Senha e Confirmação de Senha precisam ser iguais.");

            if (Password.Length > 8 )
                notifications.TransactionMessages.Add("Senha pode ter no máximo 8 digitos");

            return notifications;
        }
    }
}
