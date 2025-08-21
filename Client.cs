using System;

namespace src
{
    public class Client
    {
        public string? Name { get; set; }
        public int PaymentDay { get; set; }

        public Client(string Name, int DiaPagamento)
        {
            this.Name = Name;
            this.PaymentDay = DiaPagamento;
        }
    }
}