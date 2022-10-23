using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAAL
{
    using Parsing;
    using System.IO;

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
            if (!File.Exists(args[0]))
            {
                Console.WriteLine("Selected File does not exist!");
                goto end;
            }


            List<Token> tokens = Parser.ParseFile(args[0]);
            Console.WriteLine($"Tokens: (Count: {tokens.Count})");
            foreach(Token token in tokens)
                Console.WriteLine($" - {token}");
            Console.WriteLine();




            end:
            Console.WriteLine("\n\nEnd.");
            Console.ReadLine();
        }
    }
}
