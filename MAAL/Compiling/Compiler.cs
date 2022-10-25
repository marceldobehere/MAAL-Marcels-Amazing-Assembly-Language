using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAAL.Compiling
{
    using MAAL.Parsing;
    using MAAL.Tools;

    public class Compiler
    {
        public static List<byte> Compile(Parser.ParsedStuff stuff)
        {
            List<ReservedMemoryChunk> reservedMemory = new List<ReservedMemoryChunk>();

            foreach (var usedVar in stuff.Variables)
                reservedMemory.Add(new ReservedMemoryChunk(usedVar.Value));

            Console.WriteLine("Used Memory:");
            foreach (var usedVar in reservedMemory)
                Console.WriteLine($" - {usedVar.Amount} Bytes");


            List<AlmostByte> almostCompiledCode = new List<AlmostByte>();






            List<byte> compiledCode = new List<byte>();
            
            
            
            return compiledCode;
        }

        public class AlmostByte
        {
            public int Size;
            public byte[] FixedData;
            public bool IsFixedData;


            public AlmostByte(byte[] fixedData)
            {
                FixedData = fixedData;
                Size = FixedData.Length;
                IsFixedData = true;
            }
        }

        public class ReservedMemoryChunk
        {
            public int Amount = 0;
            public int Address = -1;
            public DeclareVarToken DeclaredVar;

            public ReservedMemoryChunk(int amount)
            {
                Amount = amount;
                Address = -1;
                DeclaredVar = null;
            }

            public ReservedMemoryChunk(DeclareVarToken declareVar)
            {
                DeclaredVar = declareVar;
                if (declareVar.VarType.PointerCount > 0)
                    Amount = 8;
                else
                    Amount = TypeToken.TypeSizeList[TypeToken.TypeList.IndexOf(declareVar.VarType.BaseType)];




            }
        }
    }
}
