﻿using System;
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
            OPERATION,
            CAST

        }

        public static Dictionary<InstructionEnum, byte> IToByte = new Dictionary<InstructionEnum, byte>()
        {
            {InstructionEnum.NOP, 0},
            {InstructionEnum.EXIT, 1},
            {InstructionEnum.SET_FIX_SIZE_FIX_MEM_TO_FIX_VAL, 2},
            {InstructionEnum.COPY_FIX_SIZE_FROM_FIX_MEM_TO_FIX_MEM, 3},
            {InstructionEnum.COPY_FIX_SIZE_FROM_VAR_MEM_TO_VAR_MEM, 4},
            {InstructionEnum.COPY_VAR_SIZE_FROM_VAR_MEM_TO_VAR_MEM, 5},
            {InstructionEnum.OPERATION, 10},
            {InstructionEnum.CAST, 15},
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
            almostCompiledCode.Add(new AlmostByte(IToByte[InstructionEnum.COPY_FIX_SIZE_FROM_VAR_MEM_TO_VAR_MEM]));
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

            //Console.WriteLine($" + <DOING EXPRESSION {tok}   RESULT: {resAddr}   LAYER: {layer}>");


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
                int varSize1 = GetSizeFromVarToken(tok.Variable);
                //int varSize2 = GetSizeFromVarToken((cTok as SetVarToken).SetExpression.Variable);

                almostCompiledCode.Add(new AlmostByte($"Calculation of {tok} into {resAddr}"));
                almostCompiledCode.Add(new AlmostByte(IToByte[InstructionEnum.COPY_FIX_SIZE_FROM_VAR_MEM_TO_VAR_MEM]));
                // SIZE OF TYPE
                almostCompiledCode.Add(new AlmostByte((byte)varSize1));
                // FROM
                almostCompiledCode.Add(new AlmostByte(tok.Variable));
                // TO
                almostCompiledCode.Add(new AlmostByte(BEC.UInt64ToByteArr((ulong)resAddr)));

                return;
            }

            if (tok.IsCast)
            {
                long lAddr = GetLeftOpRegisterFromLayer(layer);

                var exprTypeLeft = GetTypeFromExpression(tok.Cast.ToCast);
                BasicValueToken.BasicValueTypeEnum castType = GetTypeFromExpression(tok);

                // Clear left address
                WriteBytesToAddr(almostCompiledCode, lAddr, new byte[8]);

                //int sizeExprLeft = GetTypeFromExpression(tok);
                CompileExpression(tok.Cast.ToCast, almostCompiledCode, lAddr, layer + 1);
                //CopyXBytesFromTo(almostCompiledCode, resAddr, lAddr, DaTyToSize[exprTypeLeft]);

                //almostCompiledCode.Add(new AlmostByte($"Calculation of casting {tok.Cast.ToCast} into {tok.Cast.CastType} (at {resAddr})"));
                CastXToY(almostCompiledCode, lAddr, exprTypeLeft, resAddr, castType);
                //almostCompiledCode.Add(new AlmostByte(IToByte[InstructionEnum.OPERATION]));
                //almostCompiledCode.Add(new AlmostByte(OpToByte[tok.Operator.Operator]));
                //almostCompiledCode.Add(new AlmostByte(DaTyToByte[exprTypeLeft]));

                //almostCompiledCode.Add(new AlmostByte(BEC.UInt64ToByteArr((ulong)lAddr)));
                //almostCompiledCode.Add(new AlmostByte(BEC.UInt64ToByteArr((ulong)resAddr)));

                return;

                // use a cast operation
                throw new Exception("CASTING IS NOT SUPPORTED IN COMPILETIME YET");
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

                if (exprTypeLeft != strongerType)
                {
                    throw new Exception($"CASTING IS NOT SUPPORTED IN COMPILETIME YET! ({exprTypeLeft} => {strongerType})  ({tok.Left})");
                }
                if (exprTypeRight != strongerType)
                {
                    throw new Exception($"CASTING IS NOT SUPPORTED IN COMPILETIME YET! ({exprTypeRight} => {strongerType})  ({tok.Right})");
                }

                // Clear both laddresses
                WriteBytesToAddr(almostCompiledCode, lAddr, new byte[16]);

                //int sizeExprLeft = GetTypeFromExpression(tok);
                CompileExpression(tok.Left, almostCompiledCode, lAddr, layer + 1);
                //CopyXBytesFromTo(almostCompiledCode, resAddr, lAddr, DaTyToSize[exprTypeLeft]);
                CompileExpression(tok.Right, almostCompiledCode, lAddr + 8, layer + 1);
                //CopyXBytesFromTo(almostCompiledCode, resAddr, lAddr + 8, DaTyToSize[exprTypeLeft]);

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

        public static List<byte> Compile(Parser.ParsedStuff stuff)
        {
            Console.WriteLine();

            List<AlmostByte> almostCompiledCode = new List<AlmostByte>();


            almostCompiledCode.Add(new AlmostByte("VARIABLE DATA"));
            foreach (var usedVar in stuff.Variables)
                almostCompiledCode.Add(new AlmostByte(usedVar.Value));//reservedMemory.Add(new ReservedMemoryChunk(usedVar.Value));




            almostCompiledCode.Add(new AlmostByte("DATA FOR MATH STUFF"));
            StartingOperationAddr = GetLenghtOfByteList(almostCompiledCode);
            StartingOperationIndex = almostCompiledCode.Count;
            //Console.WriteLine($"STARTING OP INDEX (RESULT) = {StartingOperationAddr}");
            MaxOperationDeepness = 1;
            almostCompiledCode.Add(new AlmostByte(new byte[(1 + 2 * MaxOperationDeepness) * 8])); // 1x 8 Bytes for result 20x 8 Bytes for 10 Left and Right Operands
            
            
            //almostCompiledCode.Add(new AlmostByte($""));

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
                    almostCompiledCode.Add(new AlmostByte($"SETTING {(cTok as SetVarToken).VarName} TO {val}"));

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
                    //COPY_FIX_SIZE_FROM_VAR_MEM_TO_VAR_MEM

                    int varSize1 = GetSizeFromVarToken((cTok as SetVarToken).VarName);
                    int varSize2 = GetSizeFromVarToken((cTok as SetVarToken).SetExpression.Variable);
                    almostCompiledCode.Add(new AlmostByte($"COPY DATA FROM {(cTok as SetVarToken).VarName} TO {(cTok as SetVarToken).SetExpression.Variable}"));


                    //BasicValueToken val = (cTok as SetVarToken).SetExpression.ConstValue;
                    //[2][Size of Value in bytes (1 Byte)][Address (8 Bytes)][Fixed Value (x Bytes)]
                    almostCompiledCode.Add(new AlmostByte(IToByte[InstructionEnum.COPY_FIX_SIZE_FROM_VAR_MEM_TO_VAR_MEM]));
                    // SIZE OF TYPE
                    almostCompiledCode.Add(new AlmostByte((byte)varSize2));
                    // FROM
                    almostCompiledCode.Add(new AlmostByte((cTok as SetVarToken).SetExpression.Variable));
                    // TO
                    almostCompiledCode.Add(new AlmostByte((cTok as SetVarToken).VarName));

                    if (varSize1 != varSize2)
                        throw new Exception($"CANNOT WRITE {varSize2} BYTES INTO INTO {varSize1} BYTES! ({cTok})");
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
                    almostCompiledCode.Add(new AlmostByte(IToByte[InstructionEnum.COPY_FIX_SIZE_FROM_VAR_MEM_TO_VAR_MEM]));
                    // SIZE OF TYPE
                    almostCompiledCode.Add(new AlmostByte((byte)varSize));
                    // FROM
                    almostCompiledCode.Add(new AlmostByte(BEC.UInt64ToByteArr((ulong)StartingOperationAddr)));
                    // TO
                    almostCompiledCode.Add(new AlmostByte((cTok as SetVarToken).VarName));
                }
                #endregion



                else
                {
                    Console.WriteLine($"<ERR: Compiler can't compile Token: {cTok}!>");
                    //throw new Exception($"Compiler can't compile Token: {cTok}!");
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
            public string Comment = null;
            public bool IsComment = false;

            public AlmostByte(string comment)
            {
                Comment = comment;
                IsComment = true;
                Size = 0;
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
