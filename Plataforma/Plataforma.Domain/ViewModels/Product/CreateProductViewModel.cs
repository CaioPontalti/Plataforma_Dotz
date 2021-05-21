using Plataforma.Domain.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Plataforma.Domain.ViewModels.Product
{
    public class CreateProductViewModel
    {
        public string Name { get; set; }
        public int Value { get; set; }
        public int Quantity { get; set; }

        public Notification Validate()
        {
            var notifications = new Notification();

            if (string.IsNullOrEmpty(Name))
                notifications.TransactionMessages.Add("O Nome é obrigatório");

            if (Value <= 0)
                notifications.TransactionMessages.Add("É necessário informar um valor de pontos maior que 0.");

            if (Quantity < 0)
                notifications.TransactionMessages.Add("É necessário informar a quantidade disponível do produto 0.");

            return notifications;
        }
    }
}
