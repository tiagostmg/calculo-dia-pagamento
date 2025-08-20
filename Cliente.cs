using System;

namespace src
{
    public class Cliente
    {
        public string? Nome { get; set; }
        public int DiaPagamento { get; set; }

        public Cliente(string Nome, int DiaPagamento)
        {
            this.Nome = Nome;
            this.DiaPagamento = DiaPagamento;
        }
    }
}