using System;
using System.Collections.Generic;
using System.Globalization;
using TotalAmount.Model;

namespace TotalAmount
{
    class Program
    {
        static void Main()
        {
            char sair;

            decimal dAmount;

            int iCod, iQtd = 0;

            List<Purchase> compras = new List<Purchase>();

            NumberStyles style = NumberStyles.Number | NumberStyles.AllowCurrencySymbol;
            CultureInfo culture = CultureInfo.CreateSpecificCulture("en-GB");

            string sAmount, sCod, sQtd = "";

            do
            {
                sair = 'n';
                Purchase compra = new Purchase();

                Console.Write("Código do Produto: ");                
                sCod = Console.ReadLine();
                if (int.TryParse(sCod, out iCod))
                    compra.Cod = iCod;
                else
                {
                    Console.WriteLine("Formato de Código inválido!");
                    sair = 's';
                }                

                if (sair == 'n')
                {
                    Console.WriteLine();
                    Console.Write("Quantidade do Produto: ");
                    sQtd = Console.ReadLine();
                    if (int.TryParse(sQtd, out iQtd))
                        compra.Qtd = iQtd;
                    else
                    {
                        Console.WriteLine("Quantidade de Produto inválida!");
                        sair = 's';
                    }
                }

                if (sair == 'n')
                {
                    Console.WriteLine();
                    Console.Write("Valor do Produto: ");
                    sAmount = Console.ReadLine();
                    if (decimal.TryParse(sAmount, style, culture, out dAmount))
                        compra.Amount = dAmount;
                    else
                    {
                        Console.WriteLine("Valor do Produto inválido!");
                        sair = 's';
                    }
                }                

                Console.WriteLine();              

                if (sair == 'n')
                {
                    compras.Add(compra);

                    Console.WriteLine();

                    Console.Write("Finalizar? S (sim) / N (não): ");
                    sair = char.Parse(Console.ReadLine());
                    Console.WriteLine();
                }

                Console.WriteLine("-----------------------------------------------------------");

            } while (sair != 's' && sair != 'S');

            decimal total = 0;

            foreach (Purchase c in compras)            
                total += c.Amount * c.Qtd;

            Console.WriteLine($"VALOR A PAGAR: {total.ToString("F2", CultureInfo.InvariantCulture)}");
        }
    }
}
