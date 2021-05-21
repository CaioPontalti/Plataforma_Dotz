using Plataforma.Domain.Core;
using Plataforma.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Plataforma.Domain.ViewModels.Balance
{
    public class CreateMovementViewModel
    {
        public string UserId { get; set; }
        public int Points { get; set; }
        public EMovementType Type { get; set; }

        public Notification Validate()
        {
            var notifications = new Notification();

            if (string.IsNullOrEmpty(UserId))
                notifications.TransactionMessages.Add("Id do Usuário é obrigatório");

            if (Points <= 0 )
                notifications.TransactionMessages.Add("É necessário informar um valor de pontos maior que 0 para movimentação.");

            if ((int)Type != 1 && (int)Type != 2)
                notifications.TransactionMessages.Add("Tipo inválido. Informe 1 para débito e 2 para crédito.");

            return notifications;
        }
    }
}
