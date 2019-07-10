using System.Collections.Generic;
using System.Threading.Tasks;

namespace PalprimeFinder
{
    partial class Program
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
    }
}
