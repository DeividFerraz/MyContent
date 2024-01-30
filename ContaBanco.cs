using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace meuSuperBanco
{
    public class ContaBanco
    {
        public string Numero { get; }
        public string Dono { get; set; }
        public decimal Saldo 
        {
            get
            {
                decimal saldo = 0;
                foreach (var item in todasTransacoes)
                {
                    saldo += item.Valor;
                }
                return saldo;
            }
                
        }

        public static int numeroConta = 1234567890;

        private List<Transacao> todasTransacoes = new List<Transacao>();

        public ContaBanco()
        {

        }

        public ContaBanco(string dono, decimal valor)
        {
            this.Dono = dono;
            numeroConta++;

            this.Numero = numeroConta.ToString();
            Depositar(valor, DateTime.Now, "Saldo inicial");
        }

        public void Depositar(decimal valor, DateTime data, string obs)
        {
            if (valor <= 0) {
                throw new ArgumentOutOfRangeException(nameof(valor),
                    "Não aceitamos depositos de valor negativo");
            }
            Transacao trans = new Transacao(valor, data, obs);
            todasTransacoes.Add(trans);
        }

        public void Sacar(decimal valor, DateTime data, string obs)
        {
            if (valor <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(valor), "impossivel realizar o saque");
            }
            if (Saldo - valor <0)
            {
                throw new InvalidOperationException("Essa operação não é permitida");
            }
            Transacao trans = new Transacao(-valor, data, obs);
            todasTransacoes.Add(trans);
        }

        public string PegarMovimentacao()
        {
            var movimentacao = new StringBuilder();
            movimentacao.AppendLine("Data5\t\tvalor5\tobs");

            foreach (var item in todasTransacoes)
            {
                movimentacao.AppendLine($"{item.Data}, \t {item.Valor}, \t{item.Obs}");
            }

            return movimentacao.ToString();
        }

    }
}
