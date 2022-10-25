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
        public enum InstructionEnum
        {
            NOP,
            EXIT,
            SET_FIX_SIZE_FIX_MEM_TO_FIX_VAL,
            COPY_FIX_SIZE_FROM_FIX_MEM_TO_FIX_MEM,
            COPY_FIX_SIZE_FROM_VAR_MEM_TO_VAR_MEM,
            COPY_VAR_SIZE_FROM_VAR_MEM_TO_VAR_MEM,

        }

        public static Dictionary<InstructionEnum, byte> IToByte = new Dictionary<InstructionEnum, byte>()
        {
            {InstructionEnum.NOP, 0},
            {InstructionEnum.EXIT, 1},
            {InstructionEnum.SET_FIX_SIZE_FIX_MEM_TO_FIX_VAL, 2},
            {InstructionEnum.COPY_FIX_SIZE_FROM_FIX_MEM_TO_FIX_MEM, 3},
            {InstructionEnum.COPY_FIX_SIZE_FROM_VAR_MEM_TO_VAR_MEM, 4},
            {InstructionEnum.COPY_VAR_SIZE_FROM_VAR_MEM_TO_VAR_MEM, 5},
        };

        public static List<byte> Compile(Parser.ParsedStuff stuff)
        {
            //List<ReservedMemoryChunk> reservedMemory = new List<ReservedMemoryChunk>();

            //foreach (var usedVar in stuff.Variables)
            //    reservedMemory.Add(new ReservedMemoryChunk(usedVar.Value));

            //// Add reserverd Memory for const char*

            //Console.WriteLine("Used Memory:");
            //foreach (var usedVar in reservedMemory)
            //    Console.WriteLine($" - {usedVar.Amount} Bytes");
            //Console.WriteLine();



            List<AlmostByte> almostCompiledCode = new List<AlmostByte>();


            foreach (var usedVar in stuff.Variables)
                almostCompiledCode.Add(new AlmostByte(usedVar.Value));//reservedMemory.Add(new ReservedMemoryChunk(usedVar.Value));




            foreach (var cTok in stuff.parsedTokens)
            {
                if (cTok is ExitToken)
                {
                    almostCompiledCode.Add(new AlmostByte(IToByte[InstructionEnum.EXIT]));
                }
                #region SET VAR TO CONST
                else if (cTok is SetVarToken && !(cTok as SetVarToken).SetLocation &&
                    (cTok as SetVarToken).SetExpression.IsConstValue &&
                    (cTok as SetVarToken).SetExpression.ConstValue.ValueType != BasicValueToken.BasicValueTypeEnum.CHAR_POINTER)
                {
                    BasicValueToken val = (cTok as SetVarToken).SetExpression.ConstValue;
                    //[2][Size of Value in bytes (1 Byte)][Address (8 Bytes)][Fixed Value (x Bytes)]
                    almostCompiledCode.Add(new AlmostByte(IToByte[InstructionEnum.SET_FIX_SIZE_FIX_MEM_TO_FIX_VAL]));
                    // SIZE OF TYPE
                    //int varSize = TypeToken.TypeSizeList[TypeToken.TypeList.IndexOf(BasicValueToken.TypeEnumToString[val.ValueType])];
                    byte[] varData = BasicValueToArr(val);
                    almostCompiledCode.Add(new AlmostByte((byte)varData.Length));
                    // ADDRESS OF VAR
                    almostCompiledCode.Add(new AlmostByte((cTok as SetVarToken).VarName));
                    // VALUE
                    almostCompiledCode.Add(new AlmostByte(varData));

                    int varSize = GetSizeFromVarToken((cTok as SetVarToken).VarName);
                    if (varSize != varData.Length)
                        throw new Exception($"CANNOT WRITE {varData.Length} BYTES INTO {varSize} BYTES! ({cTok})");
                }
                #endregion
                #region SET ADDR TO CONST
                else if (cTok is SetVarToken && (cTok as SetVarToken).SetLocation &&
                    (cTok as SetVarToken).VarLocation.IsConstValue &&
                    (cTok as SetVarToken).VarLocation.ConstValue.ValueType != BasicValueToken.BasicValueTypeEnum.CHAR_POINTER &&
                    (cTok as SetVarToken).SetExpression.IsConstValue &&
                    (cTok as SetVarToken).SetExpression.ConstValue.ValueType != BasicValueToken.BasicValueTypeEnum.CHAR_POINTER)
                {
                    BasicValueToken val = (cTok as SetVarToken).SetExpression.ConstValue;
                    BasicValueToken var = (cTok as SetVarToken).VarLocation.ConstValue;
                    //[2][Size of Value in bytes (1 Byte)][Address (8 Bytes)][Fixed Value (x Bytes)]
                    almostCompiledCode.Add(new AlmostByte(IToByte[InstructionEnum.SET_FIX_SIZE_FIX_MEM_TO_FIX_VAL]));
                    // SIZE OF TYPE
                    //int varSize = TypeToken.TypeSizeList[TypeToken.TypeList.IndexOf(BasicValueToken.TypeEnumToString[val.ValueType])];
                    byte[] varData = BasicValueToArr(val);
                    almostCompiledCode.Add(new AlmostByte((byte)varData.Length));
                    // ADDRESS OF VAR
                    byte[] valData = BasicValueToArr(var);
                    almostCompiledCode.Add(new AlmostByte(valData));
                    // VALUE
                    almostCompiledCode.Add(new AlmostByte(varData));

                    if (valData.Length != 8)
                        throw new Exception($"CANNOT USE NON 8 BYTE VALUE AS ADDRESS! (AMOUNT OF BYTES: {valData.Length}) {(cTok as SetVarToken).VarLocation.ConstValue}");
                }
                #endregion



                else
                {
                    Console.WriteLine($"<ERR: Compiler can't compile Token: {cTok}!>");
                    //throw new Exception($"Compiler can't compile Token: {cTok}!");
                }
            }





            Console.WriteLine("Almost Bytes:");
            foreach (var almostByte in almostCompiledCode)
                Console.WriteLine($" - {almostByte}");
            Console.WriteLine();


            List<byte> compiledCode = new List<byte>();




            compiledCode.Add(IToByte[InstructionEnum.EXIT]);

            return compiledCode;
        }

        public class AlmostByte
        {
            public int Size = 0;
            public byte[] FixedData = null;
            public bool IsFixedData = false;
            public VarNameToken VarName = null;
            public bool IsVarName = false;
            //public bool I
            public DeclareVarToken DeclaredVarName = null;
            public bool IsDeclaredVarName;


            public AlmostByte(byte[] fixedData)
            {
                FixedData = fixedData;
                Size = FixedData.Length;
                IsFixedData = true;
            }

            public AlmostByte(byte fixedByte)
            {
                FixedData = new byte[1] { fixedByte };
                Size = 1;
                IsFixedData = true;
            }

            public AlmostByte(VarNameToken varName)
            {
                //FixedData = new byte[8];
                Size = 8;
                IsVarName = true;
                VarName = varName;
            }

            public AlmostByte(DeclareVarToken decVarName)
            {
                //FixedData = new byte[8];
                Size = GetSizeFromTypeToken(decVarName.VarType);
                IsDeclaredVarName = true;
                DeclaredVarName = decVarName;
            }

            public override string ToString()
            {
                if (IsFixedData)
                    return $"<{String.Join(" ", FixedData)}>";
                if (IsVarName)
                    return $"<{Size} Bytes for Addr of {VarName}>";
                if (IsDeclaredVarName)
                    return $"<{Size} Bytes reserved for - {DeclaredVarName}>";

                return "<Unknown>";
            }
        }


        public static byte[] BasicValueToArr(BasicValueToken val)
        {
            // int varSize = TypeToken.TypeSizeList[TypeToken.TypeList.IndexOf(BasicValueToken.TypeEnumToString[val.ValueType])];
            if (val.ValueType == BasicValueToken.BasicValueTypeEnum.INT)
                return BEC.Int32ToByteArr(val.Value_Int);
            if (val.ValueType == BasicValueToken.BasicValueTypeEnum.UINT)
                return BEC.UInt32ToByteArr(val.Value_UInt);
            else if (val.ValueType == BasicValueToken.BasicValueTypeEnum.SHORT)
                return BEC.Int16ToByteArr(val.Value_Short);
            else if (val.ValueType == BasicValueToken.BasicValueTypeEnum.USHORT)
                return BEC.UInt16ToByteArr(val.Value_UShort);
            else if (val.ValueType == BasicValueToken.BasicValueTypeEnum.LONG)
                return BEC.Int64ToByteArr(val.Value_Long);
            else if (val.ValueType == BasicValueToken.BasicValueTypeEnum.ULONG)
                return BEC.UInt64ToByteArr(val.Value_ULong);
            else if (val.ValueType == BasicValueToken.BasicValueTypeEnum.CHAR)
                return new byte[1] { (byte)val.Value_Char };
            else if (val.ValueType == BasicValueToken.BasicValueTypeEnum.BOOL)
                return new byte[1] { (byte)(val.Value_Bool ? 1 : 0) };
            else if (val.ValueType == BasicValueToken.BasicValueTypeEnum.FLOAT)
                return BEC.FloatToByteArr(val.Value_Float);
            else if (val.ValueType == BasicValueToken.BasicValueTypeEnum.DOUBLE)
                return BEC.DoubleToByteArr(val.Value_Double);

            throw new Exception($"Can't convert {val} to byte[]!");
            return null;
        }

        public static int GetSizeFromVarToken(VarNameToken var)
        {
            if (var.VarType.PointerCount - var.DereferenceCount > 0)
                return 8; // Pointers are 8 bytes
            return TypeToken.TypeSizeList[TypeToken.TypeList.IndexOf(var.VarType.BaseType)];
        }

        public static int GetSizeFromTypeToken(TypeToken var)
        {
            if (var.PointerCount > 0)
                return 8; // Pointers are 8 bytes
            return TypeToken.TypeSizeList[TypeToken.TypeList.IndexOf(var.BaseType)];
        }
    }
}
