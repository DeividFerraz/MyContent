using System;

namespace meuSuperBanco
{
    class Program
    {
        static void Main(string[] args)
        {
            meuSuperBanco.ContaBanco contaB = new ContaBanco("Deivid", 1000);

            Console.WriteLine($"A conta {contaB.Numero} de {contaB.Dono} foi criada com {contaB.Saldo}");

            contaB.Sacar(300, DateTime.Now, "Fiz as compras");
            Console.WriteLine($"A conta está com {contaB.Saldo}");

            try
            {
                contaB.Sacar(100000, DateTime.Now, "Vou pagar");
                Console.WriteLine($"A conta está com {contaB.Saldo}");
            }catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);  
            }
            catch (Exception ex)
            {
                Console.WriteLine("Operação não realizada");
            }

            contaB.Sacar(1500, DateTime.Now, "Pagar a escola das crianças");
            Console.WriteLine($"A conta está com {contaB.Saldo}");

            contaB.Sacar(2000, DateTime.Now, "Alugues");
            Console.WriteLine($"A conta está com {contaB.Saldo}");
        }
    }
}