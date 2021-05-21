using System;
using System.Collections.Generic;
using System.Text;

namespace Plataforma.Domain.Core
{
    public class Notification
    {
        public Notification()
        {
            TransactionMessages = new List<string>();
        }    
        public List<string> TransactionMessages { get; set; }
    }
}
