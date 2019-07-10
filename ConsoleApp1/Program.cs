using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        public interface IPalprimeFinder
        {
            /// <summary>
            /// retrieve all palprimes numbers less than max asynchronously  
            /// </summary>
            /// <param name="max">the max value</param>
            /// <param name="toBase">the base of the palprimes (2-> binary, 10-> decimal ...)</param>
            /// <returns></returns>
            Task<IEnumerable<string>> FindPalprimesAsync(int max, int toBase);

            /// <summary>
            /// Get all palprimes number iteratively
            /// </summary>
            /// <param name="max">the max value</param>
            /// <param name="toBase">the base of the palprimes (2-> binary, 10-> decimal ...)</param>
            /// <returns></returns>
            IEnumerable<string> FindPalprimes(int max, int toBase);

        }

        public class PalprimeFinder : IPalprimeFinder
        {
            /// <inheritdoc />
            public async Task<IEnumerable<string>> FindPalprimesAsync(int max, int toBase)
            {
                return await Task.Run(() => FindPalprimes(max, toBase));
            }

            /// <inheritdoc />
            public IEnumerable<string> FindPalprimes(int max, int toBase)
            {
                foreach (var item in GetPrimes(max))
                {
                    if (Convert.ToString(item, toBase).Count() == 1)
                        yield return Convert.ToString(item, toBase);
                    else if (Convert.ToString(item, toBase).SequenceEqual(Convert.ToString(item, toBase).Reverse()))
                        yield return Convert.ToString(item, toBase);

                }
            }

            /// <summary>
            /// Retrieve all prime numbers less tan max iteratively 
            /// </summary>
            /// <param name="max">the maximum value</param>
            /// <returns></returns>
            private IEnumerable<int> GetPrimes(int max)
            {
                for (int i = 2; i < max; i++)
                {
                    for (int j = 2; j <= i / 2; j++)
                    {
                        if (i % j == 0)
                            goto Next;
                    }
                    yield return i;
                Next:;
                }
            }
        }

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
