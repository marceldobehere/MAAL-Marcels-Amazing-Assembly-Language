using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MAAL
{
    using Parsing;
    using Compiling;
    using System.IO;

    // MAAL
    // Marcels Amazing Assembly Language

    // MAAB
    // Marcels Amazing Assembly Bytecode
    class Program
    {
        private static readonly string[] stages = new string[] { "starting", "parsing", "compiling", "writing to file" };
        private static int stage = 0;

        static void Main(string[] args)
        {
            bool catchErr = true;
            //catchErr = false;

            if (catchErr)
            {
                try
                {
                    DoStuff(args);
                }
                catch (Exception e)
                {
                    Console.WriteLine("\n\n\n");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"An Error occured while {stages[stage]}!");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine(new String('-', Console.WindowWidth - 1));
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(e.Message);
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine(e);
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine(new String('-', Console.WindowWidth - 1));
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
            else
                DoStuff(args);



            Console.WriteLine("\n\nEnd.");
            Console.ReadLine();
        }

        static void DoStuff(string[] args)
        {
            stage = 0;
            if (args.Length != 1)
            {
                Console.WriteLine("No Files selected!");
                return;
            }
            if (!File.Exists(args[0]))
            {
                Console.WriteLine("Selected File does not exist!");
                return;
            }

            stage = 1;
            Console.WriteLine("> Parsing file...");
            Parser.ParsedStuff stuff = Parser.ParseFile(args[0]);
            Console.WriteLine("> Parsing done!");


            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine($"Variables: (Count: {stuff.Variables.Count})");
            foreach (var token in stuff.Variables.Values)
                Console.WriteLine($" - {token}");
            Console.WriteLine();
            Console.WriteLine($"Locations: (Count: {stuff.Locations.Count})");
            foreach (var token in stuff.Locations.Values)
                Console.WriteLine($" - {token}");
            Console.WriteLine();
            Console.WriteLine($"Subroutines: (Count: {stuff.Subroutines.Count})");
            foreach (var token in stuff.Subroutines.Values)
                Console.WriteLine($" - {token}");
            Console.WriteLine();

            Console.WriteLine(new String('-', 40) + "\n");

            Console.WriteLine($"Tokens: (Count: {stuff.parsedTokens.Count})");
            foreach (Token token in stuff.parsedTokens)
            {
                if (token is DefineLocationToken || token is DefineSubroutineToken)
                    Console.WriteLine();

                Console.Write($"{token} ");

                if (token is EndCommandToken || token is SetVarToken || token is DefineLocationToken ||
                    token is DefineSubroutineToken || token is ExitToken || token is ReturnToken ||
                    token is ConditionalJumpToken || token is FixedJumpToken || token is SyscallToken || token is PrintToken)
                    Console.WriteLine();
            }
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();

            stage = 2;
            Console.WriteLine("> Compiling file...");
            List<byte> compiledData = Compiler.Compile(stuff);
            Console.WriteLine("> Compiling done!");

            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("Compiled Data:");
            //foreach (var data in compiledData)
            //Console.WriteLine($"{data} ({(char)data})");
            Console.WriteLine(String.Join(", ", compiledData));

            Console.WriteLine();
            Console.WriteLine($"Compiled Data Size: {compiledData.Count} Bytes.");
            Console.WriteLine();



            stage = 3;
            Console.WriteLine("> Writing to file...");
            using (BinaryWriter writer = new BinaryWriter(new FileStream($"{args[0]}.maab", FileMode.Create)))
            {
                writer.Write(compiledData.ToArray());
            }
            Console.WriteLine("> Writing to file done!");
        }
    }
}
