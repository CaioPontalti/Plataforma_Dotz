using Plataforma.Domain.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Plataforma.Domain.ViewModels.Order
{
    public class CreateOrderViewModel
    {
        public string Id { get; set; }
        public string IdUser { get; set; }
        public string IdProduct { get; set; }
        public int Quantity { get; set; }
        public int Points { get; set; }

        public Notification Validate()
        {
            var notifications = new Notification();

            if (string.IsNullOrEmpty(IdUser))
                notifications.TransactionMessages.Add("Id do usuário é obrigatório");

            if (string.IsNullOrEmpty(IdProduct))
                notifications.TransactionMessages.Add("Id do Produto é obrigatório");

            return notifications;
        }
    }
}
