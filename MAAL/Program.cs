using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MAAL
{
    using Parsing;
    using Compiling;
    using System.IO;
    using System.Diagnostics;

    public static class GlobalStuff
    {
        public static bool ShowText = true;
        public static bool ShowTimeStats = true;

        public static void WriteLine(string str)
        {
            if (ShowText)
                Console.WriteLine(str);
        }
        public static void WriteLine()
        {
            if (ShowText)
                Console.WriteLine();
        }
        public static void Write(string str)
        {
            if (ShowText)
                Console.Write(str);
        }
        public static ConsoleColor ForegroundColor
        {
            get
                => Console.ForegroundColor;
            set
            {
                if (ShowText)
                    Console.ForegroundColor = value;
            }
        }
        public static ConsoleColor BackgroundColor
        {
            get
                => Console.BackgroundColor;
            set
            {
                if (ShowText)
                    Console.BackgroundColor = value;
            }
        }
    }


    // MAAL
    // Marcels Amazing Assembly Language

    // MAAB
    // Marcels Amazing Assembly Bytecode
    public class Program
    {
        private static readonly string[] stages = new string[] { "starting", "parsing", "compiling", "writing to file" };
        private static int stage = 0;


        static void Main(string[] args)
        {
            bool catchErr = true;
            //catchErr = false;
            GlobalStuff.ShowText = false;
            GlobalStuff.ShowTimeStats = false;


            if (args.Length > 1)
            {
                if (args.ToList().Contains("-yes_debug_out"))
                    GlobalStuff.ShowText = true;
                if (args.ToList().Contains("-yes_time_out"))
                    GlobalStuff.ShowTimeStats = true;
            }


            if (catchErr)
            {
                try
                {
                    DoStuff(args);
                }
                catch (Exception e)
                {
                    GlobalStuff.WriteLine("\n\n\n");
                    Console.ForegroundColor = ConsoleColor.Red;
                    {
                        string msg = "COMPILATION FAILED";
                        int w = Console.WindowWidth - msg.Length;
                        Console.Write(new string('-', w / 2));
                        Console.Write(msg);
                        Console.WriteLine(new string('-', w - (w / 2)));
                    }
                    Console.ForegroundColor = ConsoleColor.White;

                    Console.WriteLine("\n");
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
            if (args.Length < 1)
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

            Stopwatch timerParse = Stopwatch.StartNew();
            GlobalStuff.WriteLine("> Parsing file...");
            Parser.ParsedStuff stuff = Parser.ParseFile(args[0]);
            GlobalStuff.WriteLine("> Parsing done!");
            timerParse.Stop();

            GlobalStuff.WriteLine();
            GlobalStuff.WriteLine();
            GlobalStuff.WriteLine($"Variables: (Count: {stuff.Variables.Count})");
            foreach (var token in stuff.Variables.Values)
                GlobalStuff.WriteLine($" - {token}");
            GlobalStuff.WriteLine();
            GlobalStuff.WriteLine($"Locations: (Count: {stuff.Locations.Count})");
            foreach (var token in stuff.Locations.Values)
                GlobalStuff.WriteLine($" - {token}");
            GlobalStuff.WriteLine();
            GlobalStuff.WriteLine($"Subroutines: (Count: {stuff.Subroutines.Count})");
            foreach (var token in stuff.Subroutines.Values)
                GlobalStuff.WriteLine($" - {token}");
            GlobalStuff.WriteLine();

            GlobalStuff.WriteLine(new String('-', 40) + "\n");

            GlobalStuff.WriteLine($"Tokens: (Count: {stuff.parsedTokens.Count})");
            foreach (Token token in stuff.parsedTokens)
            {
                if (token is DefineLocationToken || token is DefineSubroutineToken)
                    GlobalStuff.WriteLine();

                GlobalStuff.Write($"{token} ");

                if (token is EndCommandToken || token is SetVarToken || token is DefineLocationToken ||
                    token is DefineSubroutineToken || token is ExitToken || token is ReturnToken ||
                    token is ConditionalJumpToken || token is FixedJumpToken || token is SyscallToken || 
                    token is PrintToken || token is MallocToken || token is FreeToken)
                    GlobalStuff.WriteLine();
            }
            GlobalStuff.WriteLine();
            GlobalStuff.WriteLine();
            GlobalStuff.WriteLine();


            Stopwatch timerCompile = Stopwatch.StartNew();
            stage = 2;
            GlobalStuff.WriteLine("> Compiling file...");
            List<byte> compiledData = Compiler.Compile(stuff);
            GlobalStuff.WriteLine("> Compiling done!");
            timerCompile.Stop();

            GlobalStuff.WriteLine();
            GlobalStuff.WriteLine();

            GlobalStuff.WriteLine("Compiled Data:");
            //foreach (var data in compiledData)
            //GlobalStuff.WriteLine($"{data} ({(char)data})");
            GlobalStuff.WriteLine(String.Join(", ", compiledData));

            GlobalStuff.WriteLine();
            GlobalStuff.WriteLine($"Compiled Data Size: {compiledData.Count} Bytes.");
            GlobalStuff.WriteLine();



            stage = 3;
            Stopwatch timerWrite = Stopwatch.StartNew();
            GlobalStuff.WriteLine("> Writing to file...");
            using (BinaryWriter writer = new BinaryWriter(new FileStream($"{args[0]}.maab", FileMode.Create)))
            {
                writer.Write(compiledData.ToArray());
            }
            GlobalStuff.WriteLine("> Writing to file done!");
            timerWrite.Stop();

            GlobalStuff.WriteLine();
            GlobalStuff.WriteLine();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Cyan;
            {
                string msg = "COMPILATION SUCCESSFUL";
                int w = Console.WindowWidth - msg.Length;
                Console.Write(new string('-', w / 2));
                Console.Write(msg);
                Console.WriteLine(new string('-', w - (w / 2)));
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
            Console.WriteLine($"Compiled to:  \"{args[0]}.maab\". ({compiledData.Count} Bytes)");
            if (GlobalStuff.ShowTimeStats)
            {
                Console.WriteLine();
                Console.WriteLine($"Parse Time:   {timerParse.Elapsed.TotalMilliseconds} ms.");
                Console.WriteLine($"Compile Time: {timerCompile.Elapsed.TotalMilliseconds} ms.");
                Console.WriteLine($"Write Time:   {timerWrite.Elapsed.TotalMilliseconds} ms.");
                Console.WriteLine();
                Console.WriteLine($"Total Time:   {timerParse.Elapsed.TotalMilliseconds + timerCompile.Elapsed.TotalMilliseconds + timerWrite.Elapsed.TotalMilliseconds} ms.");
            }

        }
    }
}
