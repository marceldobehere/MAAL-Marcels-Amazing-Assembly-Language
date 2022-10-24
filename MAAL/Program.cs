using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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


            Parser.ParsedStuff stuff = Parser.ParseFile(args[0]);
            Console.WriteLine($"Variables: (Count: {stuff.Variables.Count})");
            foreach (DeclareVarToken token in stuff.Variables.Values)
                Console.WriteLine($"{token} ");
            Console.WriteLine();


            Console.WriteLine($"Tokens: (Count: {stuff.other.Count})");
            foreach (Token token in stuff.other)
            {
                Console.Write($"{token} ");
                if (token is EndCommandToken || token is SetVarToken)
                    Console.WriteLine("");
            }
            Console.WriteLine();




        end:
            Console.WriteLine("\n\nEnd.");
            Console.ReadLine();
        }
    }
}
