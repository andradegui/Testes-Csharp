using System;
using Alura.LeilaoOnline.Core;

namespace Alura.LeilaoOnline.ConsoleApp
{
    class Program
    {
        private static void Verifica(double esperado, double obtido)
        {
            var cor = Console.ForegroundColor;
            if (esperado == obtido)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("TESTE OK");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(
                    $"TESTE FALHOU! Esperado: {esperado}, obtido: {obtido}");
            }
            Console.ForegroundColor = cor; 
            Console.ForegroundColor = cor; 

        }
        private static void LeilaoComVariosLances()
        {
            //Arranje - cenário
            var leilao = new Leilao("Van Gogh");

            var joao = new Interessada("Joao", leilao);
            var maria = new Interessada("Maria", leilao);

            leilao.RecebeLance(joao, 800);
            leilao.RecebeLance(maria, 800);
            leilao.RecebeLance(joao, 1000);
            leilao.RecebeLance(maria, 900);

            //Act - método sob teste
            leilao.TerminaPregao();

            //Assert
            var valorEsperado = 1000;
            var valorObtido = leilao.Ganhador.Valor;
            Verifica(valorEsperado, valorObtido);
           
        }

        private static void LeilaoComUmLance()
        {
            //Arranje - cenário
            var leilao = new Leilao("Van Gogh");

            var joao = new Interessada("Joao", leilao);
           

            leilao.RecebeLance(joao, 800);
           

            //Act - método sob teste
            leilao.TerminaPregao();

            //Assert
            var valorEsperado = 800;
            var valorObtido = leilao.Ganhador.Valor;
            Verifica(valorEsperado, valorObtido);
        }
        static void Main(string[] args)  
        {
            LeilaoComVariosLances();
            LeilaoComUmLance();
        }
    }
}
