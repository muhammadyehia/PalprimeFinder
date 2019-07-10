using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PalprimeFinder
{
    partial class Program
    {
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
    }
}
