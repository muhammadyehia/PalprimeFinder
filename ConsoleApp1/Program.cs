using System;
using System.Linq;

namespace PalprimeFinder
{
    partial class Program
    {

        static void Main(string[] args)
        {
            var palprimesFinder = new PalprimeFinder();
            do
            {
                try
                {
                    int numBase = Menu();
                    foreach (var item in palprimesFinder.FindPalprimes(1000, numBase))
                    {
                        Console.WriteLine($" ->{item}");
                    }
                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                }
            } while (true);
        }
        /// <summary>
        /// Show the menu to ask for the base
        /// </summary>
        /// <returns>the base</returns>
        public static int Menu()
        {
            string input = "";
            while (string.IsNullOrEmpty(input) || !input.All(char.IsDigit))
            {
                Console.WriteLine("Please provide the numbering system (2,10,16,..)");
                input = Console.ReadLine();
            }

            return int.Parse(input);

        }
    }
}
