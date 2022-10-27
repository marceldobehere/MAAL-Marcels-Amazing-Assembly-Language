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
            __DANGEROUS_MIX_UP__COPY_FIX_SIZE_FROM_VAR_MEM_TO_VAR_MEM,
            COPY_VAR_SIZE_FROM_VAR_MEM_TO_VAR_MEM,
            OPERATION,
            CAST,
            RETURN,
            JUMP_FIX,
            ENTER_SUBROUTINE_FIX,
            JUMP_VAR,
            ENTER_SUBROUTINE_VAR,
            IF_JUMP_FIX,
            IF_JUMP_VAR,
            IF_SUB_FIX,
            IF_SUB_VAR

        }

        public static Dictionary<InstructionEnum, byte> IToByte = new Dictionary<InstructionEnum, byte>()
        {
            {InstructionEnum.NOP, 0},
            {InstructionEnum.EXIT, 1},
            {InstructionEnum.SET_FIX_SIZE_FIX_MEM_TO_FIX_VAL, 2},
            {InstructionEnum.COPY_FIX_SIZE_FROM_FIX_MEM_TO_FIX_MEM, 3},
            {InstructionEnum.__DANGEROUS_MIX_UP__COPY_FIX_SIZE_FROM_VAR_MEM_TO_VAR_MEM, 4},
            {InstructionEnum.COPY_VAR_SIZE_FROM_VAR_MEM_TO_VAR_MEM, 5},
            {InstructionEnum.OPERATION, 10},
            {InstructionEnum.CAST, 15},
            {InstructionEnum.RETURN, 30},
            {InstructionEnum.JUMP_FIX, 20},
            {InstructionEnum.ENTER_SUBROUTINE_FIX, 25},
            {InstructionEnum.JUMP_VAR, 21},
            {InstructionEnum.ENTER_SUBROUTINE_VAR, 26},

            {InstructionEnum.IF_JUMP_FIX, 40},
            {InstructionEnum.IF_JUMP_VAR, 41},
            {InstructionEnum.IF_SUB_FIX, 45},
            {InstructionEnum.IF_SUB_VAR, 46},
        };

        #region OP AND VARTYPE STUFF
        public static Dictionary<OperatorToken.OperatorEnum, byte> OpToByte = new Dictionary<OperatorToken.OperatorEnum, byte>()
        {
            {OperatorToken.OperatorEnum.Plus, 0},
            {OperatorToken.OperatorEnum.Minus, 1},
            {OperatorToken.OperatorEnum.Star, 2},
            {OperatorToken.OperatorEnum.Divide, 3},
            {OperatorToken.OperatorEnum.Mod, 4},
            {OperatorToken.OperatorEnum.Equal, 5},
            {OperatorToken.OperatorEnum.NotEqual, 6},
            {OperatorToken.OperatorEnum.Greater, 7},
            {OperatorToken.OperatorEnum.GreaterEqual, 8},
            {OperatorToken.OperatorEnum.Less, 9},
            {OperatorToken.OperatorEnum.LessEqual, 10},
            {OperatorToken.OperatorEnum.And, 11},
            {OperatorToken.OperatorEnum.Or, 12},
            {OperatorToken.OperatorEnum.Not, 13},
            {OperatorToken.OperatorEnum.BitAnd, 14},
            {OperatorToken.OperatorEnum.BitOr, 15},
            {OperatorToken.OperatorEnum.BitNot, 16},
            {OperatorToken.OperatorEnum.BitShiftLeft, 17},
            {OperatorToken.OperatorEnum.BitShiftRight, 18},

        };


        public static Dictionary<BasicValueToken.BasicValueTypeEnum, byte> DaTyToByte = new Dictionary<BasicValueToken.BasicValueTypeEnum, byte>()
        {
            {BasicValueToken.BasicValueTypeEnum.INT , 0},
            {BasicValueToken.BasicValueTypeEnum.UINT , 1},
            {BasicValueToken.BasicValueTypeEnum.SHORT , 2},
            {BasicValueToken.BasicValueTypeEnum.USHORT , 3},
            {BasicValueToken.BasicValueTypeEnum.LONG , 4},
            {BasicValueToken.BasicValueTypeEnum.ULONG , 5},
            {BasicValueToken.BasicValueTypeEnum.CHAR , 6},
            {BasicValueToken.BasicValueTypeEnum.BOOL , 7},
            {BasicValueToken.BasicValueTypeEnum.FLOAT , 8},
            {BasicValueToken.BasicValueTypeEnum.DOUBLE , 9},
        };

        public static Dictionary<BasicValueToken.BasicValueTypeEnum, byte> DaTyToSize = new Dictionary<BasicValueToken.BasicValueTypeEnum, byte>()
        {
            {BasicValueToken.BasicValueTypeEnum.INT , 4},
            {BasicValueToken.BasicValueTypeEnum.UINT , 4},
            {BasicValueToken.BasicValueTypeEnum.SHORT , 2},
            {BasicValueToken.BasicValueTypeEnum.USHORT , 2},
            {BasicValueToken.BasicValueTypeEnum.LONG , 8},
            {BasicValueToken.BasicValueTypeEnum.ULONG , 8},
            {BasicValueToken.BasicValueTypeEnum.CHAR , 1},
            {BasicValueToken.BasicValueTypeEnum.BOOL , 1},
            {BasicValueToken.BasicValueTypeEnum.FLOAT , 4},
            {BasicValueToken.BasicValueTypeEnum.DOUBLE , 8},
        };
        #endregion



        public static long StartingOperationAddr = -1;
        public static long GetLeftOpRegisterFromLayer(int layer)
            => StartingOperationAddr + (1 + layer * 2) * 8;
        public static int StartingOperationIndex = -1;
        public static int MaxOperationDeepness = 1;
        public static long StartingGeneralUseAddr = -1;

        public static BasicValueToken.BasicValueTypeEnum GetResultTypeBasedOnTokensAndOperation(BasicValueToken.BasicValueTypeEnum left, OperatorToken.OperatorEnum op, BasicValueToken.BasicValueTypeEnum right)
        {
            #region STUFF

            // conditionals will return bool
            if (op == OperatorToken.OperatorEnum.Equal || op == OperatorToken.OperatorEnum.NotEqual ||
                op == OperatorToken.OperatorEnum.Greater || op == OperatorToken.OperatorEnum.GreaterEqual ||
                op == OperatorToken.OperatorEnum.Less || op == OperatorToken.OperatorEnum.LessEqual ||
                op == OperatorToken.OperatorEnum.And || op == OperatorToken.OperatorEnum.Or ||
                op == OperatorToken.OperatorEnum.Not
                )
                return BasicValueToken.BasicValueTypeEnum.BOOL;

            // bitshifting always returns a number based on the type of the number which gets bitshifted (left)
            if (op == OperatorToken.OperatorEnum.BitShiftLeft || op == OperatorToken.OperatorEnum.BitShiftRight || op == OperatorToken.OperatorEnum.BitNot)
                return left;

            // Normal And Bitwise Operators will return the HIGHER TYPE
            if (op == OperatorToken.OperatorEnum.Plus || op == OperatorToken.OperatorEnum.Minus ||
                op == OperatorToken.OperatorEnum.Minus || op == OperatorToken.OperatorEnum.Star ||
                op == OperatorToken.OperatorEnum.Mod ||

                op == OperatorToken.OperatorEnum.BitAnd || op == OperatorToken.OperatorEnum.BitOr

                )
            {
                #region CHAR + 
                if (left == BasicValueToken.BasicValueTypeEnum.CHAR)
                {
                    if (right == BasicValueToken.BasicValueTypeEnum.DOUBLE)
                        return BasicValueToken.BasicValueTypeEnum.DOUBLE;
                    if (right == BasicValueToken.BasicValueTypeEnum.FLOAT)
                        return BasicValueToken.BasicValueTypeEnum.FLOAT;

                    if (right == BasicValueToken.BasicValueTypeEnum.ULONG)
                        return BasicValueToken.BasicValueTypeEnum.ULONG;
                    if (right == BasicValueToken.BasicValueTypeEnum.LONG)
                        return BasicValueToken.BasicValueTypeEnum.LONG;

                    if (right == BasicValueToken.BasicValueTypeEnum.UINT)
                        return BasicValueToken.BasicValueTypeEnum.UINT;
                    if (right == BasicValueToken.BasicValueTypeEnum.INT)
                        return BasicValueToken.BasicValueTypeEnum.INT;

                    if (right == BasicValueToken.BasicValueTypeEnum.USHORT)
                        return BasicValueToken.BasicValueTypeEnum.USHORT;
                    if (right == BasicValueToken.BasicValueTypeEnum.SHORT)
                        return BasicValueToken.BasicValueTypeEnum.SHORT;

                    if (right == BasicValueToken.BasicValueTypeEnum.CHAR)
                        return BasicValueToken.BasicValueTypeEnum.CHAR;
                }
                #endregion
                #region SHORT + 
                if (left == BasicValueToken.BasicValueTypeEnum.INT)
                {
                    if (right == BasicValueToken.BasicValueTypeEnum.DOUBLE)
                        return BasicValueToken.BasicValueTypeEnum.DOUBLE;
                    if (right == BasicValueToken.BasicValueTypeEnum.FLOAT)
                        return BasicValueToken.BasicValueTypeEnum.FLOAT;

                    if (right == BasicValueToken.BasicValueTypeEnum.ULONG)
                        return BasicValueToken.BasicValueTypeEnum.ULONG;
                    if (right == BasicValueToken.BasicValueTypeEnum.LONG)
                        return BasicValueToken.BasicValueTypeEnum.LONG;

                    if (right == BasicValueToken.BasicValueTypeEnum.UINT)
                        return BasicValueToken.BasicValueTypeEnum.UINT;
                    if (right == BasicValueToken.BasicValueTypeEnum.INT)
                        return BasicValueToken.BasicValueTypeEnum.INT;

                    if (right == BasicValueToken.BasicValueTypeEnum.USHORT)
                        return BasicValueToken.BasicValueTypeEnum.USHORT;

                    return BasicValueToken.BasicValueTypeEnum.SHORT;
                }
                #endregion
                #region USHORT + 
                if (left == BasicValueToken.BasicValueTypeEnum.USHORT)
                {
                    if (right == BasicValueToken.BasicValueTypeEnum.DOUBLE)
                        return BasicValueToken.BasicValueTypeEnum.DOUBLE;
                    if (right == BasicValueToken.BasicValueTypeEnum.FLOAT)
                        return BasicValueToken.BasicValueTypeEnum.FLOAT;

                    if (right == BasicValueToken.BasicValueTypeEnum.ULONG)
                        return BasicValueToken.BasicValueTypeEnum.ULONG;
                    if (right == BasicValueToken.BasicValueTypeEnum.LONG)
                        return BasicValueToken.BasicValueTypeEnum.LONG;

                    if (right == BasicValueToken.BasicValueTypeEnum.UINT)
                        return BasicValueToken.BasicValueTypeEnum.UINT;
                    if (right == BasicValueToken.BasicValueTypeEnum.INT)
                        return BasicValueToken.BasicValueTypeEnum.INT;

                    return BasicValueToken.BasicValueTypeEnum.USHORT;
                }
                #endregion
                #region INT + 
                if (left == BasicValueToken.BasicValueTypeEnum.INT)
                {
                    if (right == BasicValueToken.BasicValueTypeEnum.DOUBLE)
                        return BasicValueToken.BasicValueTypeEnum.DOUBLE;
                    if (right == BasicValueToken.BasicValueTypeEnum.FLOAT)
                        return BasicValueToken.BasicValueTypeEnum.FLOAT;

                    if (right == BasicValueToken.BasicValueTypeEnum.ULONG)
                        return BasicValueToken.BasicValueTypeEnum.ULONG;
                    if (right == BasicValueToken.BasicValueTypeEnum.LONG)
                        return BasicValueToken.BasicValueTypeEnum.LONG;

                    if (right == BasicValueToken.BasicValueTypeEnum.UINT)
                        return BasicValueToken.BasicValueTypeEnum.UINT;
                    return BasicValueToken.BasicValueTypeEnum.INT;
                }
                #endregion
                #region UINT + 
                if (left == BasicValueToken.BasicValueTypeEnum.UINT)
                {
                    if (right == BasicValueToken.BasicValueTypeEnum.DOUBLE)
                        return BasicValueToken.BasicValueTypeEnum.DOUBLE;
                    if (right == BasicValueToken.BasicValueTypeEnum.FLOAT)
                        return BasicValueToken.BasicValueTypeEnum.FLOAT;

                    if (right == BasicValueToken.BasicValueTypeEnum.ULONG)
                        return BasicValueToken.BasicValueTypeEnum.ULONG;
                    if (right == BasicValueToken.BasicValueTypeEnum.LONG)
                        return BasicValueToken.BasicValueTypeEnum.LONG;

                    return BasicValueToken.BasicValueTypeEnum.UINT;
                }
                #endregion
                #region LONG + 
                if (left == BasicValueToken.BasicValueTypeEnum.LONG)
                {
                    if (right == BasicValueToken.BasicValueTypeEnum.DOUBLE)
                        return BasicValueToken.BasicValueTypeEnum.DOUBLE;
                    if (right == BasicValueToken.BasicValueTypeEnum.FLOAT)
                        return BasicValueToken.BasicValueTypeEnum.FLOAT;

                    if (right == BasicValueToken.BasicValueTypeEnum.ULONG)
                        return BasicValueToken.BasicValueTypeEnum.ULONG;
                    return BasicValueToken.BasicValueTypeEnum.LONG;
                }
                #endregion
                #region ULONG + 
                if (left == BasicValueToken.BasicValueTypeEnum.ULONG)
                {
                    if (right == BasicValueToken.BasicValueTypeEnum.DOUBLE)
                        return BasicValueToken.BasicValueTypeEnum.DOUBLE;
                    if (right == BasicValueToken.BasicValueTypeEnum.FLOAT)
                        return BasicValueToken.BasicValueTypeEnum.FLOAT;

                    return BasicValueToken.BasicValueTypeEnum.ULONG;
                }
                #endregion
                #region FLOAT + 
                if (left == BasicValueToken.BasicValueTypeEnum.FLOAT)
                {
                    if (right == BasicValueToken.BasicValueTypeEnum.DOUBLE)
                        return BasicValueToken.BasicValueTypeEnum.DOUBLE;
                    return BasicValueToken.BasicValueTypeEnum.FLOAT;
                }
                #endregion
                #region DOUBLE + 
                if (left == BasicValueToken.BasicValueTypeEnum.DOUBLE)
                {
                    return BasicValueToken.BasicValueTypeEnum.DOUBLE;
                }
                #endregion

            }


            #endregion

            throw new Exception($"Cant find Resulting Type From Operation! ({left} {op} {right})");
        }

        public static BasicValueToken.BasicValueTypeEnum GetStrongerType(BasicValueToken.BasicValueTypeEnum left, BasicValueToken.BasicValueTypeEnum right)
        {
            if (left == right)
                return left;

            #region CHAR + 
            if (left == BasicValueToken.BasicValueTypeEnum.CHAR)
            {
                if (right == BasicValueToken.BasicValueTypeEnum.DOUBLE)
                    return BasicValueToken.BasicValueTypeEnum.DOUBLE;
                if (right == BasicValueToken.BasicValueTypeEnum.FLOAT)
                    return BasicValueToken.BasicValueTypeEnum.FLOAT;

                if (right == BasicValueToken.BasicValueTypeEnum.ULONG)
                    return BasicValueToken.BasicValueTypeEnum.ULONG;
                if (right == BasicValueToken.BasicValueTypeEnum.LONG)
                    return BasicValueToken.BasicValueTypeEnum.LONG;

                if (right == BasicValueToken.BasicValueTypeEnum.UINT)
                    return BasicValueToken.BasicValueTypeEnum.UINT;
                if (right == BasicValueToken.BasicValueTypeEnum.INT)
                    return BasicValueToken.BasicValueTypeEnum.INT;

                if (right == BasicValueToken.BasicValueTypeEnum.USHORT)
                    return BasicValueToken.BasicValueTypeEnum.USHORT;
                if (right == BasicValueToken.BasicValueTypeEnum.SHORT)
                    return BasicValueToken.BasicValueTypeEnum.SHORT;

                if (right == BasicValueToken.BasicValueTypeEnum.CHAR)
                    return BasicValueToken.BasicValueTypeEnum.CHAR;
            }
            #endregion
            #region SHORT + 
            if (left == BasicValueToken.BasicValueTypeEnum.INT)
            {
                if (right == BasicValueToken.BasicValueTypeEnum.DOUBLE)
                    return BasicValueToken.BasicValueTypeEnum.DOUBLE;
                if (right == BasicValueToken.BasicValueTypeEnum.FLOAT)
                    return BasicValueToken.BasicValueTypeEnum.FLOAT;

                if (right == BasicValueToken.BasicValueTypeEnum.ULONG)
                    return BasicValueToken.BasicValueTypeEnum.ULONG;
                if (right == BasicValueToken.BasicValueTypeEnum.LONG)
                    return BasicValueToken.BasicValueTypeEnum.LONG;

                if (right == BasicValueToken.BasicValueTypeEnum.UINT)
                    return BasicValueToken.BasicValueTypeEnum.UINT;
                if (right == BasicValueToken.BasicValueTypeEnum.INT)
                    return BasicValueToken.BasicValueTypeEnum.INT;

                if (right == BasicValueToken.BasicValueTypeEnum.USHORT)
                    return BasicValueToken.BasicValueTypeEnum.USHORT;

                return BasicValueToken.BasicValueTypeEnum.SHORT;
            }
            #endregion
            #region USHORT + 
            if (left == BasicValueToken.BasicValueTypeEnum.USHORT)
            {
                if (right == BasicValueToken.BasicValueTypeEnum.DOUBLE)
                    return BasicValueToken.BasicValueTypeEnum.DOUBLE;
                if (right == BasicValueToken.BasicValueTypeEnum.FLOAT)
                    return BasicValueToken.BasicValueTypeEnum.FLOAT;

                if (right == BasicValueToken.BasicValueTypeEnum.ULONG)
                    return BasicValueToken.BasicValueTypeEnum.ULONG;
                if (right == BasicValueToken.BasicValueTypeEnum.LONG)
                    return BasicValueToken.BasicValueTypeEnum.LONG;

                if (right == BasicValueToken.BasicValueTypeEnum.UINT)
                    return BasicValueToken.BasicValueTypeEnum.UINT;
                if (right == BasicValueToken.BasicValueTypeEnum.INT)
                    return BasicValueToken.BasicValueTypeEnum.INT;

                return BasicValueToken.BasicValueTypeEnum.USHORT;
            }
            #endregion
            #region INT + 
            if (left == BasicValueToken.BasicValueTypeEnum.INT)
            {
                if (right == BasicValueToken.BasicValueTypeEnum.DOUBLE)
                    return BasicValueToken.BasicValueTypeEnum.DOUBLE;
                if (right == BasicValueToken.BasicValueTypeEnum.FLOAT)
                    return BasicValueToken.BasicValueTypeEnum.FLOAT;

                if (right == BasicValueToken.BasicValueTypeEnum.ULONG)
                    return BasicValueToken.BasicValueTypeEnum.ULONG;
                if (right == BasicValueToken.BasicValueTypeEnum.LONG)
                    return BasicValueToken.BasicValueTypeEnum.LONG;

                if (right == BasicValueToken.BasicValueTypeEnum.UINT)
                    return BasicValueToken.BasicValueTypeEnum.UINT;
                return BasicValueToken.BasicValueTypeEnum.INT;
            }
            #endregion
            #region UINT + 
            if (left == BasicValueToken.BasicValueTypeEnum.UINT)
            {
                if (right == BasicValueToken.BasicValueTypeEnum.DOUBLE)
                    return BasicValueToken.BasicValueTypeEnum.DOUBLE;
                if (right == BasicValueToken.BasicValueTypeEnum.FLOAT)
                    return BasicValueToken.BasicValueTypeEnum.FLOAT;

                if (right == BasicValueToken.BasicValueTypeEnum.ULONG)
                    return BasicValueToken.BasicValueTypeEnum.ULONG;
                if (right == BasicValueToken.BasicValueTypeEnum.LONG)
                    return BasicValueToken.BasicValueTypeEnum.LONG;

                return BasicValueToken.BasicValueTypeEnum.UINT;
            }
            #endregion
            #region LONG + 
            if (left == BasicValueToken.BasicValueTypeEnum.LONG)
            {
                if (right == BasicValueToken.BasicValueTypeEnum.DOUBLE)
                    return BasicValueToken.BasicValueTypeEnum.DOUBLE;
                if (right == BasicValueToken.BasicValueTypeEnum.FLOAT)
                    return BasicValueToken.BasicValueTypeEnum.FLOAT;

                if (right == BasicValueToken.BasicValueTypeEnum.ULONG)
                    return BasicValueToken.BasicValueTypeEnum.ULONG;
                return BasicValueToken.BasicValueTypeEnum.LONG;
            }
            #endregion
            #region ULONG + 
            if (left == BasicValueToken.BasicValueTypeEnum.ULONG)
            {
                if (right == BasicValueToken.BasicValueTypeEnum.DOUBLE)
                    return BasicValueToken.BasicValueTypeEnum.DOUBLE;
                if (right == BasicValueToken.BasicValueTypeEnum.FLOAT)
                    return BasicValueToken.BasicValueTypeEnum.FLOAT;

                return BasicValueToken.BasicValueTypeEnum.ULONG;
            }
            #endregion
            #region FLOAT + 
            if (left == BasicValueToken.BasicValueTypeEnum.FLOAT)
            {
                if (right == BasicValueToken.BasicValueTypeEnum.DOUBLE)
                    return BasicValueToken.BasicValueTypeEnum.DOUBLE;
                return BasicValueToken.BasicValueTypeEnum.FLOAT;
            }
            #endregion
            #region DOUBLE + 
            if (left == BasicValueToken.BasicValueTypeEnum.DOUBLE)
            {
                return BasicValueToken.BasicValueTypeEnum.DOUBLE;
            }
            #endregion


            throw new Exception($"Cant find Stronger Type From Types! ({left} and {right})");
        }

        public static BasicValueToken.BasicValueTypeEnum GetTypeFromExpression(ExpressionToken tok)
        {
            if (tok.IsConstValue)
            {
                return tok.ConstValue.ValueType;
            }
            if (tok.IsCast)
            {
                if (tok.Cast.CastType.PointerCount > 0)
                    return BasicValueToken.BasicValueTypeEnum.ULONG;
                else
                {
                    string typeAsString = tok.Cast.CastType.BaseType;
                    return TypeToken.TypeEnumList[TypeToken.TypeList.IndexOf(typeAsString)];
                }


                throw new Exception($"CANT GET TYPE OF CAST EXPRESSION TOKEN! {tok}");
            }
            if (tok.IsVariable)
            {
                if (tok.Variable.UseAddr || tok.Variable.DereferenceCount < tok.Variable.VarType.PointerCount)
                    return BasicValueToken.BasicValueTypeEnum.ULONG;

                string typeAsString = tok.Variable.VarType.BaseType;
                return TypeToken.TypeEnumList[TypeToken.TypeList.IndexOf(typeAsString)];
            }

            if (tok.OnlyUseLeft)
            {
                return GetTypeFromExpression(tok.Left);
            }

            // tok is Expression
            {
                BasicValueToken.BasicValueTypeEnum l = GetTypeFromExpression(tok.Left);
                BasicValueToken.BasicValueTypeEnum r = GetTypeFromExpression(tok.Right);
                BasicValueToken.BasicValueTypeEnum res = GetResultTypeBasedOnTokensAndOperation(l, tok.Operator.Operator, r);
                return res;
            }


            throw new Exception($"CANT GET TYPE OF EXPRESSION TOKEN! {tok}");
        }

        public static void CopyXBytesFromTo(List<AlmostByte> almostCompiledCode, long from, long to, byte amount)
        {
            almostCompiledCode.Add(new AlmostByte($"COPYING {amount} BYTES FROM {from} TO {to}"));
            almostCompiledCode.Add(new AlmostByte(IToByte[InstructionEnum.COPY_FIX_SIZE_FROM_FIX_MEM_TO_FIX_MEM]));
            // SIZE OF TYPE
            almostCompiledCode.Add(new AlmostByte(amount));
            // FROM
            almostCompiledCode.Add(new AlmostByte(BEC.UInt64ToByteArr((ulong)from)));
            // TO
            almostCompiledCode.Add(new AlmostByte(BEC.UInt64ToByteArr((ulong)to)));
        }

        public static void WriteBytesToAddr(List<AlmostByte> almostCompiledCode, long addr, byte[] data)
        {
            almostCompiledCode.Add(new AlmostByte($"WRITING <{String.Join(", ", data)}> TO {addr}"));
            almostCompiledCode.Add(new AlmostByte(IToByte[InstructionEnum.SET_FIX_SIZE_FIX_MEM_TO_FIX_VAL]));
            // SIZE OF TYPE
            almostCompiledCode.Add(new AlmostByte((byte)data.Length));
            // ADDRESS OF VAR
            almostCompiledCode.Add(new AlmostByte(BEC.UInt64ToByteArr((ulong)addr)));
            // VALUE
            almostCompiledCode.Add(new AlmostByte(data));
        }
        public static void WriteByteToAddr(List<AlmostByte> almostCompiledCode, long addr, byte data)
        {
            almostCompiledCode.Add(new AlmostByte($"WRITING <{String.Join(", ", data)}> TO {addr}"));
            almostCompiledCode.Add(new AlmostByte(IToByte[InstructionEnum.SET_FIX_SIZE_FIX_MEM_TO_FIX_VAL]));
            // SIZE OF TYPE
            almostCompiledCode.Add(new AlmostByte((byte)1));
            // ADDRESS OF VAR
            almostCompiledCode.Add(new AlmostByte(BEC.UInt64ToByteArr((ulong)addr)));
            // VALUE
            almostCompiledCode.Add(new AlmostByte(data));
        }

        public static void CastXToY(List<AlmostByte> almostCompiledCode, long addrX, BasicValueToken.BasicValueTypeEnum typeX, long addrY, BasicValueToken.BasicValueTypeEnum typeY)
        {
            almostCompiledCode.Add(new AlmostByte($"CASTING {typeX} (at {addrX}) to {typeY} (at {addrY})"));
            almostCompiledCode.Add(new AlmostByte(IToByte[InstructionEnum.CAST]));
            // TXPE X
            almostCompiledCode.Add(new AlmostByte(DaTyToByte[typeX]));
            // TXPE Y
            almostCompiledCode.Add(new AlmostByte(DaTyToByte[typeY]));
            // ADDR X
            almostCompiledCode.Add(new AlmostByte(BEC.UInt64ToByteArr((ulong)addrX)));
            // ADDR Y
            almostCompiledCode.Add(new AlmostByte(BEC.UInt64ToByteArr((ulong)addrY)));
        }
        public static void CastVarXToY(List<AlmostByte> almostCompiledCode, VarNameToken var, BasicValueToken.BasicValueTypeEnum typeX, long addrY, BasicValueToken.BasicValueTypeEnum typeY)
        {
            almostCompiledCode.Add(new AlmostByte($"CASTING {var} to {typeY} (at {addrY})"));
            almostCompiledCode.Add(new AlmostByte(IToByte[InstructionEnum.CAST]));
            // TXPE X
            almostCompiledCode.Add(new AlmostByte(DaTyToByte[typeX]));
            // TXPE Y
            almostCompiledCode.Add(new AlmostByte(DaTyToByte[typeY]));
            // ADDR X
            almostCompiledCode.Add(new AlmostByte(var));
            // ADDR Y
            almostCompiledCode.Add(new AlmostByte(BEC.UInt64ToByteArr((ulong)addrY)));
        }

        public static void CompileExpression(ExpressionToken tok, List<AlmostByte> almostCompiledCode, long resAddr = -1, int layer = 0)
        {
            if (resAddr == -1)
                resAddr = StartingOperationAddr;
            if (layer + 1 > MaxOperationDeepness)
                MaxOperationDeepness = layer + 1;


            if (tok.IsConstValue)
            {
                BasicValueToken val = tok.ConstValue;
                //[2][Size of Value in bytes (1 Byte)][Address (8 Bytes)][Fixed Value (x Bytes)]
                almostCompiledCode.Add(new AlmostByte($"Calculation of {val} into {resAddr}"));

                almostCompiledCode.Add(new AlmostByte(IToByte[InstructionEnum.SET_FIX_SIZE_FIX_MEM_TO_FIX_VAL]));
                // SIZE OF TYPE
                //int varSize = TypeToken.TypeSizeList[TypeToken.TypeList.IndexOf(BasicValueToken.TypeEnumToString[val.ValueType])];
                byte[] varData = BasicValueToArr(val);
                almostCompiledCode.Add(new AlmostByte((byte)varData.Length));
                // ADDRESS OF RES
                almostCompiledCode.Add(new AlmostByte(BEC.UInt64ToByteArr((ulong)resAddr)));
                // VALUE
                almostCompiledCode.Add(new AlmostByte(varData));

                return;
            }

            if (tok.IsVariable)
            {
                if (tok.Variable.UseAddr)
                {
                    almostCompiledCode.Add(new AlmostByte($"Calculation of Address of {tok.Variable} to {resAddr}"));

                    almostCompiledCode.Add(new AlmostByte(IToByte[InstructionEnum.SET_FIX_SIZE_FIX_MEM_TO_FIX_VAL]));
                    // SIZE OF TYPE
                    almostCompiledCode.Add(new AlmostByte((byte)8));
                    // ADDRESS OF VAR
                    almostCompiledCode.Add(new AlmostByte(BEC.UInt64ToByteArr((ulong)resAddr)));
                    // VALUE
                    almostCompiledCode.Add(new AlmostByte(tok.Variable));

                }
                else
                {
                    int varSize1 = GetSizeFromVarToken(tok.Variable);
                    //int varSize2 = GetSizeFromVarToken((cTok as SetVarToken).SetExpression.Variable);

                    almostCompiledCode.Add(new AlmostByte($"Calculation of {tok} into {resAddr}"));
                    almostCompiledCode.Add(new AlmostByte(IToByte[InstructionEnum.COPY_FIX_SIZE_FROM_FIX_MEM_TO_FIX_MEM]));
                    // SIZE OF TYPE
                    almostCompiledCode.Add(new AlmostByte((byte)varSize1));
                    // FROM
                    almostCompiledCode.Add(new AlmostByte(tok.Variable));
                    // TO
                    almostCompiledCode.Add(new AlmostByte(BEC.UInt64ToByteArr((ulong)resAddr)));
                }
                return;
            }

            if (tok.IsCast)
            {
                long lAddr = GetLeftOpRegisterFromLayer(layer);

                var exprTypeLeft = GetTypeFromExpression(tok.Cast.ToCast);
                var castType = GetTypeFromExpression(tok);

                WriteBytesToAddr(almostCompiledCode, lAddr, new byte[8]);

                CompileExpression(tok.Cast.ToCast, almostCompiledCode, lAddr, layer + 1);

                CastXToY(almostCompiledCode, lAddr, exprTypeLeft, resAddr, castType);
                return;
            }


            if (tok.OnlyUseLeft)
            {
                long lAddr = GetLeftOpRegisterFromLayer(layer);

                var exprTypeLeft = GetTypeFromExpression(tok.Left);


                // Clear left address
                WriteBytesToAddr(almostCompiledCode, lAddr, new byte[8]);

                //int sizeExprLeft = GetTypeFromExpression(tok);
                CompileExpression(tok.Left, almostCompiledCode, lAddr, layer + 1);
                //CopyXBytesFromTo(almostCompiledCode, resAddr, lAddr, DaTyToSize[exprTypeLeft]);

                almostCompiledCode.Add(new AlmostByte($"Calculation of {tok.Operator} {tok.Left} into {resAddr}"));
                almostCompiledCode.Add(new AlmostByte(IToByte[InstructionEnum.OPERATION]));
                almostCompiledCode.Add(new AlmostByte(OpToByte[tok.Operator.Operator]));
                almostCompiledCode.Add(new AlmostByte(DaTyToByte[exprTypeLeft]));

                almostCompiledCode.Add(new AlmostByte(BEC.UInt64ToByteArr((ulong)lAddr)));
                almostCompiledCode.Add(new AlmostByte(BEC.UInt64ToByteArr((ulong)resAddr)));

                return;
            }

            {

                long lAddr = GetLeftOpRegisterFromLayer(layer);

                var exprTypeLeft = GetTypeFromExpression(tok.Left);
                var exprTypeRight = GetTypeFromExpression(tok.Right);

                var strongerType = GetStrongerType(exprTypeLeft, exprTypeRight);



                // Clear both laddresses
                WriteBytesToAddr(almostCompiledCode, lAddr, new byte[16]);

                //int sizeExprLeft = GetTypeFromExpression(tok);
                CompileExpression(tok.Left, almostCompiledCode, lAddr, layer + 1);
                //CopyXBytesFromTo(almostCompiledCode, resAddr, lAddr, DaTyToSize[exprTypeLeft]);
                CompileExpression(tok.Right, almostCompiledCode, lAddr + 8, layer + 1);
                //CopyXBytesFromTo(almostCompiledCode, resAddr, lAddr + 8, DaTyToSize[exprTypeLeft]);

                if (exprTypeLeft != strongerType)
                {
                    CastXToY(almostCompiledCode, lAddr, exprTypeLeft, lAddr, strongerType);
                    //throw new Exception($"CASTING IS NOT SUPPORTED IN COMPILETIME YET! ({exprTypeLeft} => {strongerType})  ({tok.Left})");
                }
                if (exprTypeRight != strongerType)
                {
                    CastXToY(almostCompiledCode, lAddr + 8, exprTypeRight, lAddr + 8, strongerType);
                    //throw new Exception($"CASTING IS NOT SUPPORTED IN COMPILETIME YET! ({exprTypeRight} => {strongerType})  ({tok.Right})");
                }


                almostCompiledCode.Add(new AlmostByte($"Calculation of {tok.Left} {tok.Operator} {tok.Right} into {resAddr}"));
                almostCompiledCode.Add(new AlmostByte(IToByte[InstructionEnum.OPERATION]));
                almostCompiledCode.Add(new AlmostByte(OpToByte[tok.Operator.Operator]));
                almostCompiledCode.Add(new AlmostByte(DaTyToByte[strongerType]));

                almostCompiledCode.Add(new AlmostByte(BEC.UInt64ToByteArr((ulong)lAddr)));
                almostCompiledCode.Add(new AlmostByte(BEC.UInt64ToByteArr((ulong)lAddr + 8)));
                almostCompiledCode.Add(new AlmostByte(BEC.UInt64ToByteArr((ulong)resAddr)));
            }



        }

        public static long GetLenghtOfByteList(List<AlmostByte> almostCompiledCode)
        {
            long size = 0;
            for (int i = 0; i < almostCompiledCode.Count; i++)
                size += almostCompiledCode[i].Size;

            return size;
        }

        public static ulong GetAddrOfAlmostByte(List<AlmostByte> almostCompiledCode, AlmostByte toSearchFor)
        {
            ulong addr = 0;// (ulong)-1;
            for (int i = 0; i < almostCompiledCode.Count; i++)
            {
                if (almostCompiledCode[i] == toSearchFor)
                    return addr;
                addr += (ulong)almostCompiledCode[i].Size;
            }
            throw new Exception($"ADDR OF {toSearchFor} NOT FOUND!");
        }


        public static List<byte> Compile(Parser.ParsedStuff stuff)
        {
            Console.WriteLine();

            List<AlmostByte> almostCompiledCode = new List<AlmostByte>();


            almostCompiledCode.Add(new AlmostByte("1 BYTE RESERVED BC NO NULL POINTERS HERE"));
            almostCompiledCode.Add(new AlmostByte(0));

            almostCompiledCode.Add(new AlmostByte("VARIABLE DATA"));
            foreach (var usedVar in stuff.Variables)
                almostCompiledCode.Add(new AlmostByte(usedVar.Value));//reservedMemory.Add(new ReservedMemoryChunk(usedVar.Value));

            almostCompiledCode.Add(new AlmostByte("DATA FOR GENERAL STUFF"));
            StartingGeneralUseAddr = GetLenghtOfByteList(almostCompiledCode);
            almostCompiledCode.Add(new AlmostByte(new byte[2 * 8]));


            almostCompiledCode.Add(new AlmostByte("DATA FOR MATH STUFF"));
            StartingOperationAddr = GetLenghtOfByteList(almostCompiledCode);
            StartingOperationIndex = almostCompiledCode.Count;
            //Console.WriteLine($"STARTING OP INDEX (RESULT) = {StartingOperationAddr}");
            MaxOperationDeepness = 1;
            almostCompiledCode.Add(new AlmostByte(new byte[(1 + 2 * MaxOperationDeepness) * 8])); // 1x 8 Bytes for result 20x 8 Bytes for 10 Left and Right Operands
            
            
            //almostCompiledCode.Add(new AlmostByte($""));

            foreach (var cTok in stuff.parsedTokens)
            {
                #region EXIT
                if (cTok is ExitToken)
                {
                    almostCompiledCode.Add(new AlmostByte(IToByte[InstructionEnum.EXIT]));
                }
                #endregion
                #region RETURN
                else if (cTok is ReturnToken)
                {
                    almostCompiledCode.Add(new AlmostByte(IToByte[InstructionEnum.RETURN]));
                }
                #endregion
                #region SET VAR TO CONST
                else if (cTok is SetVarToken && !(cTok as SetVarToken).SetLocation &&
                    (cTok as SetVarToken).SetExpression.IsConstValue &&
                    (cTok as SetVarToken).SetExpression.ConstValue.ValueType != BasicValueToken.BasicValueTypeEnum.CHAR_POINTER)
                {
                    BasicValueToken val = (cTok as SetVarToken).SetExpression.ConstValue;
                    almostCompiledCode.Add(new AlmostByte($"Setting {(cTok as SetVarToken).VarName} to {val}"));

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
                    almostCompiledCode.Add(new AlmostByte($"SETTING ADDR {var} TO {val}"));
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
                #region SET VAR TO VAR
                else if (cTok is SetVarToken && !(cTok as SetVarToken).SetLocation &&
                    (cTok as SetVarToken).SetExpression.IsVariable)
                {
                    SetVarToken sTok = (cTok as SetVarToken);
                    if (sTok.SetExpression.Variable.UseAddr)
                    {
                        almostCompiledCode.Add(new AlmostByte($"Setting {sTok.VarName} to Address of {sTok.SetExpression.Variable}"));
                        
                        almostCompiledCode.Add(new AlmostByte(IToByte[InstructionEnum.SET_FIX_SIZE_FIX_MEM_TO_FIX_VAL]));
                        // SIZE OF TYPE
                        almostCompiledCode.Add(new AlmostByte((byte)8));
                        // ADDRESS OF VAR
                        almostCompiledCode.Add(new AlmostByte(sTok.VarName));
                        // VALUE
                        almostCompiledCode.Add(new AlmostByte(sTok.SetExpression.Variable));

                        int varSize = GetSizeFromVarToken(sTok.VarName);
                        if (varSize != 8)
                            throw new Exception($"CANNOT WRITE {8} BYTES INTO {varSize} BYTES! ({cTok})");
                    }
                    else
                    {
                        int varSize1 = GetSizeFromVarToken(sTok.VarName);
                        int varSize2 = GetSizeFromVarToken(sTok.SetExpression.Variable);
                        almostCompiledCode.Add(new AlmostByte($"Copy Data from {sTok.SetExpression.Variable} to {sTok.VarName}"));

                        almostCompiledCode.Add(new AlmostByte(IToByte[InstructionEnum.COPY_FIX_SIZE_FROM_FIX_MEM_TO_FIX_MEM]));
                        // SIZE OF TYPE
                        almostCompiledCode.Add(new AlmostByte((byte)varSize2));
                        // FROM
                        almostCompiledCode.Add(new AlmostByte(sTok.SetExpression.Variable));
                        // TO
                        almostCompiledCode.Add(new AlmostByte(sTok.VarName));

                        if (varSize1 != varSize2)
                            throw new Exception($"CANNOT WRITE {varSize2} BYTES INTO INTO {varSize1} BYTES! ({cTok})");
                    }
                }
                #endregion
                #region SET VAR TO EXPR
                else if (cTok is SetVarToken && !(cTok as SetVarToken).SetLocation &&
                    !(cTok as SetVarToken).SetExpression.IsCast && 
                    !(cTok as SetVarToken).SetExpression.IsConstValue &&
                    !(cTok as SetVarToken).SetExpression.IsVariable)
                {
                    var exprType = GetTypeFromExpression((cTok as SetVarToken).SetExpression);
                    var exprTypeSize = DaTyToSize[exprType];
                    var varSize = GetSizeFromVarToken((cTok as SetVarToken).VarName);
                    if (exprTypeSize != varSize)
                        throw new Exception($"CANNOT WRITE {exprTypeSize} BYTES INTO {varSize} BYTES! {cTok}  {exprType} -> {(cTok as SetVarToken).VarName}");


                    //Console.WriteLine($"<DO EXPRESSION {cTok}>");
                    CompileExpression((cTok as SetVarToken).SetExpression, almostCompiledCode);
                    //Console.WriteLine($"<DID EXPRESSION {cTok}>");


                    almostCompiledCode.Add(new AlmostByte($"Writing Result of Expression into Var"));
                    almostCompiledCode.Add(new AlmostByte(IToByte[InstructionEnum.COPY_FIX_SIZE_FROM_FIX_MEM_TO_FIX_MEM]));
                    // SIZE OF TYPE
                    almostCompiledCode.Add(new AlmostByte((byte)varSize));
                    // FROM
                    almostCompiledCode.Add(new AlmostByte(BEC.UInt64ToByteArr((ulong)StartingOperationAddr)));
                    // TO
                    almostCompiledCode.Add(new AlmostByte((cTok as SetVarToken).VarName));
                }
                #endregion
                #region SET EXPR TO EXPR
                else if (cTok is SetVarToken && (cTok as SetVarToken).SetLocation &&
                    !(cTok as SetVarToken).VarLocation.IsConstValue)
                {
                    SetVarToken sTok = cTok as SetVarToken;

                    byte setExprSize = DaTyToSize[GetTypeFromExpression(sTok.SetExpression)];

                    // Compile Left-hand side into GeneralUseAddr (ADDR TO SET)
                    CompileExpression(sTok.VarLocation, almostCompiledCode, StartingGeneralUseAddr);
                    // Compile Right side into GeneralUseAddr + 8
                    CompileExpression(sTok.SetExpression, almostCompiledCode, StartingGeneralUseAddr + 8);

                    // Set GeneralUseAddr + 16 to GeneralUseAddr + 8 (ADDR TO GET FROM)
                    WriteBytesToAddr(almostCompiledCode, StartingGeneralUseAddr + 16, BEC.UInt64ToByteArr((ulong)StartingGeneralUseAddr + 8));


                    // USE InstructionEnum.__DANGEROUS_MIX_UP__COPY_FIX_SIZE_FROM_VAR_MEM_TO_VAR_MEM

                    almostCompiledCode.Add(new AlmostByte($"Setting The Address {sTok.VarLocation} to {sTok.SetExpression}"));

                    almostCompiledCode.Add(new AlmostByte(IToByte[InstructionEnum.__DANGEROUS_MIX_UP__COPY_FIX_SIZE_FROM_VAR_MEM_TO_VAR_MEM]));

                    almostCompiledCode.Add(new AlmostByte(setExprSize));

                    almostCompiledCode.Add(new AlmostByte(BEC.UInt64ToByteArr((ulong)(StartingGeneralUseAddr + 16))));

                    almostCompiledCode.Add(new AlmostByte(BEC.UInt64ToByteArr((ulong)(StartingGeneralUseAddr))));

                }
                #endregion
                #region DEFINE LOCATION
                else if (cTok is DefineLocationToken)
                {
                    almostCompiledCode.Add(new AlmostByte($"LOCATION: {cTok}"));
                    almostCompiledCode.Add(new AlmostByte(cTok as DefineLocationToken));
                }
                #endregion
                #region DEFINE SUBROUTINE
                else if (cTok is DefineSubroutineToken)
                {
                    almostCompiledCode.Add(new AlmostByte($"SUBROUTINE: {cTok}"));
                    almostCompiledCode.Add(new AlmostByte(cTok as DefineSubroutineToken));
                }
                #endregion
                #region JUMP
                else if (cTok is FixedJumpToken && (cTok as FixedJumpToken).IsLocation)
                {
                    FixedJumpToken jTok = (cTok as FixedJumpToken);
                    LocationNameToken lTok = jTok.Location;
                    if (lTok.JumpToFixedAddress)
                    {
                        CompileExpression(lTok.Address, almostCompiledCode, StartingGeneralUseAddr);

                        almostCompiledCode.Add(new AlmostByte($"JUMPING TO LOCATION: {lTok.Address}"));
                        almostCompiledCode.Add(new AlmostByte(IToByte[InstructionEnum.JUMP_VAR]));
                        almostCompiledCode.Add(new AlmostByte(BEC.UInt64ToByteArr((ulong)StartingGeneralUseAddr)));
                    }
                    else
                    {
                        almostCompiledCode.Add(new AlmostByte($"JUMPING TO LOCATION: {lTok}"));
                        almostCompiledCode.Add(new AlmostByte(IToByte[InstructionEnum.JUMP_FIX]));
                        almostCompiledCode.Add(new AlmostByte(lTok));
                    }
                }
                #endregion
                #region SUB
                else if (cTok is FixedJumpToken && (cTok as FixedJumpToken).IsSubroutine)
                {
                    FixedJumpToken jTok = (cTok as FixedJumpToken);
                    SubroutineNameToken sTok = jTok.Subroutine;

                    almostCompiledCode.Add(new AlmostByte($"ENTERING SUB AT LOCATION: {sTok}"));
                    almostCompiledCode.Add(new AlmostByte(IToByte[InstructionEnum.ENTER_SUBROUTINE_FIX]));
                    almostCompiledCode.Add(new AlmostByte(sTok));
                }
                #endregion
                #region IF_JUMP
                else if (cTok is ConditionalJumpToken && (cTok as ConditionalJumpToken).IsLocation)
                {
                    ConditionalJumpToken jTok = (cTok as ConditionalJumpToken);
                    LocationNameToken lTok = jTok.Location;
                    if (lTok.JumpToFixedAddress)
                    {
                        CompileExpression(lTok.Address, almostCompiledCode, StartingGeneralUseAddr);

                        CompileExpression(jTok.Condition, almostCompiledCode, StartingGeneralUseAddr + 8);

                        almostCompiledCode.Add(new AlmostByte($"JUMPING TO LOCATION {lTok.Address} IF {jTok.Condition}"));
                        almostCompiledCode.Add(new AlmostByte(IToByte[InstructionEnum.IF_JUMP_VAR]));
                        almostCompiledCode.Add(new AlmostByte(BEC.UInt64ToByteArr((ulong)StartingGeneralUseAddr + 8)));
                        almostCompiledCode.Add(new AlmostByte(BEC.UInt64ToByteArr((ulong)StartingGeneralUseAddr)));
                    }
                    else
                    {
                        CompileExpression(jTok.Condition, almostCompiledCode, StartingGeneralUseAddr + 8);

                        almostCompiledCode.Add(new AlmostByte($"JUMPING TO LOCATION {lTok} IF {jTok.Condition}"));
                        almostCompiledCode.Add(new AlmostByte(IToByte[InstructionEnum.IF_JUMP_FIX]));
                        almostCompiledCode.Add(new AlmostByte(BEC.UInt64ToByteArr((ulong)StartingGeneralUseAddr + 8)));
                        almostCompiledCode.Add(new AlmostByte(lTok));
                    }
                }
                #endregion
                #region IF_SUB
                else if (cTok is ConditionalJumpToken && (cTok as ConditionalJumpToken).IsSubroutine)
                {
                    ConditionalJumpToken jTok = (cTok as ConditionalJumpToken);
                    SubroutineNameToken sTok = jTok.Subroutine;

                    CompileExpression(jTok.Condition, almostCompiledCode, StartingGeneralUseAddr + 8);

                    almostCompiledCode.Add(new AlmostByte($"ENTERING SUB AT LOCATION: {sTok}"));
                    almostCompiledCode.Add(new AlmostByte(IToByte[InstructionEnum.IF_SUB_FIX]));
                    almostCompiledCode.Add(new AlmostByte(BEC.UInt64ToByteArr((ulong)StartingGeneralUseAddr + 8)));
                    almostCompiledCode.Add(new AlmostByte(sTok));
                }
                #endregion



                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"<ERROR: COMPILER CANT COMPILE {cTok}!>");
                    Console.ForegroundColor = ConsoleColor.White;
                    throw new Exception($"<ERROR: COMPILER CANT COMPILE {cTok}!>");
                }
            }

            Console.WriteLine($"\nMAX OP DEEPNESS: {MaxOperationDeepness}");
            almostCompiledCode[StartingOperationIndex] = new AlmostByte(new byte[(1 + 2 * MaxOperationDeepness) * 8]);

            Console.WriteLine("\n\nAlmost Bytes:");
            foreach (var almostByte in almostCompiledCode)
            {
                Console.ForegroundColor = ConsoleColor.White;
                if (almostByte.IsComment)
                {
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Cyan;
                }
                Console.WriteLine($" - {almostByte}");
            }
            Console.WriteLine();

            Dictionary<string, ulong> varAddresses = new Dictionary<string, ulong>();
            Dictionary<string, ulong> locAddresses = new Dictionary<string, ulong>();
            Dictionary<string, ulong> subAddresses = new Dictionary<string, ulong>();

            foreach (AlmostByte aByte in almostCompiledCode)
            {
                if (aByte.IsDefineLocation)
                {
                    locAddresses.Add(aByte.DefineLocation.LocationName, GetAddrOfAlmostByte(almostCompiledCode, aByte));
                    //compiledCode.AddRange(aByte.FixedData);
                }
                else if (aByte.IsDefineSubroutine)
                {
                    subAddresses.Add(aByte.DefineSubroutine.SubroutineName, GetAddrOfAlmostByte(almostCompiledCode, aByte));
                    //compiledCode.AddRange(aByte.FixedData);
                }
                else if (aByte.IsDeclaredVarName)
                {
                    varAddresses.Add(aByte.DeclaredVarName.VarName, GetAddrOfAlmostByte(almostCompiledCode, aByte));
                    //compiledCode.AddRange(aByte.FixedData);
                }

            }





            Console.WriteLine();
            List<byte> compiledCode = new List<byte>();
            foreach (AlmostByte aByte in almostCompiledCode)
            {
                if (aByte.IsComment)
                    continue;
                else if (aByte.IsFixedData)
                    compiledCode.AddRange(aByte.FixedData);
                else if (aByte.IsDefineLocation)
                {
                    compiledCode.AddRange(aByte.FixedData);
                }
                else if (aByte.IsDefineSubroutine)
                {
                    compiledCode.AddRange(aByte.FixedData);
                }
                else if (aByte.IsDeclaredVarName)
                {
                    compiledCode.AddRange(aByte.FixedData);
                }
                else if (aByte.IsVarName)
                {
                    compiledCode.AddRange(BEC.UInt64ToByteArr(varAddresses[aByte.VarName.VarName]));
                }
                else if (aByte.IsLocationName)
                {
                    compiledCode.AddRange(BEC.UInt64ToByteArr(locAddresses[aByte.LocationName.Location.LocationName]));
                }
                else if (aByte.IsSubroutineName)
                {
                    compiledCode.AddRange(BEC.UInt64ToByteArr(subAddresses[aByte.SubroutineName.Subroutine.SubroutineName]));
                }


                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"<ERROR: CANT COMPILE {aByte}!>");
                    Console.ForegroundColor = ConsoleColor.White;
                    throw new Exception($"<ERROR: CANT COMPILE {aByte}!>");
                }
            }




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
            public string Comment = null;
            public bool IsComment = false;

            public DefineLocationToken DefineLocation = null;
            public bool IsDefineLocation = false;
            public DefineSubroutineToken DefineSubroutine = null;
            public bool IsDefineSubroutine = false;

            public LocationNameToken LocationName = null;
            public bool IsLocationName = false;

            public SubroutineNameToken SubroutineName = null;
            public bool IsSubroutineName = false;



            public AlmostByte(LocationNameToken loc)
            {
                LocationName = loc;
                IsLocationName = true;
                FixedData = new byte[8];
                Size = FixedData.Length;
            }

            public AlmostByte(SubroutineNameToken sub)
            {
                SubroutineName = sub;
                IsSubroutineName = true;
                FixedData = new byte[8];
                Size = FixedData.Length;
            }



            public AlmostByte(string comment)
            {
                Comment = comment;
                IsComment = true;
                Size = 0;
            }

            public AlmostByte(DefineSubroutineToken sub)
            {
                DefineSubroutine = sub;
                IsDefineSubroutine = true;
                Size = 1;
                FixedData = new byte[1] { 0 };
            }

            public AlmostByte(DefineLocationToken loc)
            {
                DefineLocation = loc;
                IsDefineLocation = true;
                Size = 1;
                FixedData = new byte[1] { 0 };
            }

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
                FixedData = new byte[Size];
                IsVarName = true;
                VarName = varName;
            }

            public AlmostByte(DeclareVarToken decVarName)
            {
                //FixedData = new byte[8];
                Size = GetSizeFromTypeToken(decVarName.VarType);
                FixedData = new byte[Size];
                IsDeclaredVarName = true;
                DeclaredVarName = decVarName;
            }

            public override string ToString()
            {
                if (IsFixedData)
                {
                    if (FixedData.Length < 10)
                        return $"<{String.Join(" ", FixedData)}>";
                    else
                        return $"<[{FixedData.Length}] {String.Join(" ", FixedData)}>";
                }
                if (IsVarName)
                    return $"<{Size} Bytes for Addr of {VarName}>";
                if (IsDeclaredVarName)
                    return $"<{Size} Bytes reserved for - {DeclaredVarName}>";
                if (IsComment)
                    return $"<COMMENT: {Comment}>";
                if (IsDefineLocation)
                    return $"<1 Byte (0) serving as Location Point>";
                if (IsDefineSubroutine)
                    return $"<1 Byte (0) serving as Subroutine Location Point>";
                if (IsLocationName)
                    return $"<{Size} Bytes for Addr of {LocationName}>";
                if (IsSubroutineName)
                    return $"<{Size} Bytes for Addr of {SubroutineName}>";

                return "<Unknown>";
            }
        }

        //almostCompiledCode.Add(new AlmostByte($""));

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
        }

        public static int GetSizeFromVarToken(VarNameToken var)
        {
            if (var.VarType.PointerCount - var.DereferenceCount > 0)
                return 8; // Pointers are 8 bytes
            if (var.UseAddr)
                return 8;
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
