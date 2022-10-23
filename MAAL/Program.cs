using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAAL
{
    // MAAL
    // Marcels Amazing Assembly Language

    // MAAB
    // Marcels Amazing Assembly Bytecode
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != 1)
            {
                Console.WriteLine("No Files selected!");
                goto end;
            }    



            end:
            Console.WriteLine("\n\nEnd.");
            Console.ReadLine();
        }
    }
}
