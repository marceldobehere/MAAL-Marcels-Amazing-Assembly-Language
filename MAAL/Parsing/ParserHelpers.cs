using System;

namespace MAAL.Parsing
{
    internal static class ParserHelpers
    {
        public static bool TryCast(ExpressionToken parentTok, TypeToken toType, BasicValueToken val)
        {
            string toStr = toType.ToPureString();
            //Console.WriteLine($"Trying to cast {BasicValueToken.TypeEnumToString[val.ValueType]} to {toStr}");

            // I made another script just for this

            #region TO INT
            if (toStr.Equals("int"))
            {
                if (val.ValueType == BasicValueToken.BasicValueTypeEnum.INT)
                {
                    parentTok.IsConstValue = true;
                    parentTok.ConstValue = new BasicValueToken((int)val.Value_Int);
                    return true;
                }
                else if (val.ValueType == BasicValueToken.BasicValueTypeEnum.UINT)
                {
                    parentTok.IsConstValue = true;
                    parentTok.ConstValue = new BasicValueToken((int)val.Value_UInt);
                    return true;
                }
                else if (val.ValueType == BasicValueToken.BasicValueTypeEnum.SHORT)
                {
                    parentTok.IsConstValue = true;
                    parentTok.ConstValue = new BasicValueToken((int)val.Value_Short);
                    return true;
                }
                else if (val.ValueType == BasicValueToken.BasicValueTypeEnum.USHORT)
                {
                    parentTok.IsConstValue = true;
                    parentTok.ConstValue = new BasicValueToken((int)val.Value_UShort);
                    return true;
                }
                else if (val.ValueType == BasicValueToken.BasicValueTypeEnum.LONG)
                {
                    parentTok.IsConstValue = true;
                    parentTok.ConstValue = new BasicValueToken((int)val.Value_Long);
                    return true;
                }
                else if (val.ValueType == BasicValueToken.BasicValueTypeEnum.ULONG)
                {
                    parentTok.IsConstValue = true;
                    parentTok.ConstValue = new BasicValueToken((int)val.Value_ULong);
                    return true;
                }
                else if (val.ValueType == BasicValueToken.BasicValueTypeEnum.CHAR)
                {
                    parentTok.IsConstValue = true;
                    parentTok.ConstValue = new BasicValueToken((int)val.Value_Char);
                    return true;
                }
                else if (val.ValueType == BasicValueToken.BasicValueTypeEnum.FLOAT)
                {
                    parentTok.IsConstValue = true;
                    parentTok.ConstValue = new BasicValueToken((int)val.Value_Float);
                    return true;
                }
                else if (val.ValueType == BasicValueToken.BasicValueTypeEnum.DOUBLE)
                {
                    parentTok.IsConstValue = true;
                    parentTok.ConstValue = new BasicValueToken((int)val.Value_Double);
                    return true;
                }
            }
            #endregion
            #region TO UINT
            else if (toStr.Equals("uint"))
            {
                if (val.ValueType == BasicValueToken.BasicValueTypeEnum.INT)
                {
                    parentTok.IsConstValue = true;
                    parentTok.ConstValue = new BasicValueToken((uint)val.Value_Int);
                    return true;
                }
                else if (val.ValueType == BasicValueToken.BasicValueTypeEnum.UINT)
                {
                    parentTok.IsConstValue = true;
                    parentTok.ConstValue = new BasicValueToken((uint)val.Value_UInt);
                    return true;
                }
                else if (val.ValueType == BasicValueToken.BasicValueTypeEnum.SHORT)
                {
                    parentTok.IsConstValue = true;
                    parentTok.ConstValue = new BasicValueToken((uint)val.Value_Short);
                    return true;
                }
                else if (val.ValueType == BasicValueToken.BasicValueTypeEnum.USHORT)
                {
                    parentTok.IsConstValue = true;
                    parentTok.ConstValue = new BasicValueToken((uint)val.Value_UShort);
                    return true;
                }
                else if (val.ValueType == BasicValueToken.BasicValueTypeEnum.LONG)
                {
                    parentTok.IsConstValue = true;
                    parentTok.ConstValue = new BasicValueToken((uint)val.Value_Long);
                    return true;
                }
                else if (val.ValueType == BasicValueToken.BasicValueTypeEnum.ULONG)
                {
                    parentTok.IsConstValue = true;
                    parentTok.ConstValue = new BasicValueToken((uint)val.Value_ULong);
                    return true;
                }
                else if (val.ValueType == BasicValueToken.BasicValueTypeEnum.CHAR)
                {
                    parentTok.IsConstValue = true;
                    parentTok.ConstValue = new BasicValueToken((uint)val.Value_Char);
                    return true;
                }
                else if (val.ValueType == BasicValueToken.BasicValueTypeEnum.FLOAT)
                {
                    parentTok.IsConstValue = true;
                    parentTok.ConstValue = new BasicValueToken((uint)val.Value_Float);
                    return true;
                }
                else if (val.ValueType == BasicValueToken.BasicValueTypeEnum.DOUBLE)
                {
                    parentTok.IsConstValue = true;
                    parentTok.ConstValue = new BasicValueToken((uint)val.Value_Double);
                    return true;
                }
            }
            #endregion
            #region TO SHORT
            else if (toStr.Equals("short"))
            {
                if (val.ValueType == BasicValueToken.BasicValueTypeEnum.INT)
                {
                    parentTok.IsConstValue = true;
                    parentTok.ConstValue = new BasicValueToken((short)val.Value_Int);
                    return true;
                }
                else if (val.ValueType == BasicValueToken.BasicValueTypeEnum.UINT)
                {
                    parentTok.IsConstValue = true;
                    parentTok.ConstValue = new BasicValueToken((short)val.Value_UInt);
                    return true;
                }
                else if (val.ValueType == BasicValueToken.BasicValueTypeEnum.SHORT)
                {
                    parentTok.IsConstValue = true;
                    parentTok.ConstValue = new BasicValueToken((short)val.Value_Short);
                    return true;
                }
                else if (val.ValueType == BasicValueToken.BasicValueTypeEnum.USHORT)
                {
                    parentTok.IsConstValue = true;
                    parentTok.ConstValue = new BasicValueToken((short)val.Value_UShort);
                    return true;
                }
                else if (val.ValueType == BasicValueToken.BasicValueTypeEnum.LONG)
                {
                    parentTok.IsConstValue = true;
                    parentTok.ConstValue = new BasicValueToken((short)val.Value_Long);
                    return true;
                }
                else if (val.ValueType == BasicValueToken.BasicValueTypeEnum.ULONG)
                {
                    parentTok.IsConstValue = true;
                    parentTok.ConstValue = new BasicValueToken((short)val.Value_ULong);
                    return true;
                }
                else if (val.ValueType == BasicValueToken.BasicValueTypeEnum.CHAR)
                {
                    parentTok.IsConstValue = true;
                    parentTok.ConstValue = new BasicValueToken((short)val.Value_Char);
                    return true;
                }
                else if (val.ValueType == BasicValueToken.BasicValueTypeEnum.FLOAT)
                {
                    parentTok.IsConstValue = true;
                    parentTok.ConstValue = new BasicValueToken((short)val.Value_Float);
                    return true;
                }
                else if (val.ValueType == BasicValueToken.BasicValueTypeEnum.DOUBLE)
                {
                    parentTok.IsConstValue = true;
                    parentTok.ConstValue = new BasicValueToken((short)val.Value_Double);
                    return true;
                }
            }
            #endregion
            #region TO USHORT
            else if (toStr.Equals("ushort"))
            {
                if (val.ValueType == BasicValueToken.BasicValueTypeEnum.INT)
                {
                    parentTok.IsConstValue = true;
                    parentTok.ConstValue = new BasicValueToken((ushort)val.Value_Int);
                    return true;
                }
                else if (val.ValueType == BasicValueToken.BasicValueTypeEnum.UINT)
                {
                    parentTok.IsConstValue = true;
                    parentTok.ConstValue = new BasicValueToken((ushort)val.Value_UInt);
                    return true;
                }
                else if (val.ValueType == BasicValueToken.BasicValueTypeEnum.SHORT)
                {
                    parentTok.IsConstValue = true;
                    parentTok.ConstValue = new BasicValueToken((ushort)val.Value_Short);
                    return true;
                }
                else if (val.ValueType == BasicValueToken.BasicValueTypeEnum.USHORT)
                {
                    parentTok.IsConstValue = true;
                    parentTok.ConstValue = new BasicValueToken((ushort)val.Value_UShort);
                    return true;
                }
                else if (val.ValueType == BasicValueToken.BasicValueTypeEnum.LONG)
                {
                    parentTok.IsConstValue = true;
                    parentTok.ConstValue = new BasicValueToken((ushort)val.Value_Long);
                    return true;
                }
                else if (val.ValueType == BasicValueToken.BasicValueTypeEnum.ULONG)
                {
                    parentTok.IsConstValue = true;
                    parentTok.ConstValue = new BasicValueToken((ushort)val.Value_ULong);
                    return true;
                }
                else if (val.ValueType == BasicValueToken.BasicValueTypeEnum.CHAR)
                {
                    parentTok.IsConstValue = true;
                    parentTok.ConstValue = new BasicValueToken((ushort)val.Value_Char);
                    return true;
                }
                else if (val.ValueType == BasicValueToken.BasicValueTypeEnum.FLOAT)
                {
                    parentTok.IsConstValue = true;
                    parentTok.ConstValue = new BasicValueToken((ushort)val.Value_Float);
                    return true;
                }
                else if (val.ValueType == BasicValueToken.BasicValueTypeEnum.DOUBLE)
                {
                    parentTok.IsConstValue = true;
                    parentTok.ConstValue = new BasicValueToken((ushort)val.Value_Double);
                    return true;
                }
            }
            #endregion
            #region TO LONG
            else if (toStr.Equals("long"))
            {
                if (val.ValueType == BasicValueToken.BasicValueTypeEnum.INT)
                {
                    parentTok.IsConstValue = true;
                    parentTok.ConstValue = new BasicValueToken((long)val.Value_Int);
                    return true;
                }
                else if (val.ValueType == BasicValueToken.BasicValueTypeEnum.UINT)
                {
                    parentTok.IsConstValue = true;
                    parentTok.ConstValue = new BasicValueToken((long)val.Value_UInt);
                    return true;
                }
                else if (val.ValueType == BasicValueToken.BasicValueTypeEnum.SHORT)
                {
                    parentTok.IsConstValue = true;
                    parentTok.ConstValue = new BasicValueToken((long)val.Value_Short);
                    return true;
                }
                else if (val.ValueType == BasicValueToken.BasicValueTypeEnum.USHORT)
                {
                    parentTok.IsConstValue = true;
                    parentTok.ConstValue = new BasicValueToken((long)val.Value_UShort);
                    return true;
                }
                else if (val.ValueType == BasicValueToken.BasicValueTypeEnum.LONG)
                {
                    parentTok.IsConstValue = true;
                    parentTok.ConstValue = new BasicValueToken((long)val.Value_Long);
                    return true;
                }
                else if (val.ValueType == BasicValueToken.BasicValueTypeEnum.ULONG)
                {
                    parentTok.IsConstValue = true;
                    parentTok.ConstValue = new BasicValueToken((long)val.Value_ULong);
                    return true;
                }
                else if (val.ValueType == BasicValueToken.BasicValueTypeEnum.CHAR)
                {
                    parentTok.IsConstValue = true;
                    parentTok.ConstValue = new BasicValueToken((long)val.Value_Char);
                    return true;
                }
                else if (val.ValueType == BasicValueToken.BasicValueTypeEnum.FLOAT)
                {
                    parentTok.IsConstValue = true;
                    parentTok.ConstValue = new BasicValueToken((long)val.Value_Float);
                    return true;
                }
                else if (val.ValueType == BasicValueToken.BasicValueTypeEnum.DOUBLE)
                {
                    parentTok.IsConstValue = true;
                    parentTok.ConstValue = new BasicValueToken((long)val.Value_Double);
                    return true;
                }
            }
            #endregion
            #region TO ULONG
            else if (toStr.Equals("ulong"))
            {
                if (val.ValueType == BasicValueToken.BasicValueTypeEnum.INT)
                {
                    parentTok.IsConstValue = true;
                    parentTok.ConstValue = new BasicValueToken((ulong)val.Value_Int);
                    return true;
                }
                else if (val.ValueType == BasicValueToken.BasicValueTypeEnum.UINT)
                {
                    parentTok.IsConstValue = true;
                    parentTok.ConstValue = new BasicValueToken((ulong)val.Value_UInt);
                    return true;
                }
                else if (val.ValueType == BasicValueToken.BasicValueTypeEnum.SHORT)
                {
                    parentTok.IsConstValue = true;
                    parentTok.ConstValue = new BasicValueToken((ulong)val.Value_Short);
                    return true;
                }
                else if (val.ValueType == BasicValueToken.BasicValueTypeEnum.USHORT)
                {
                    parentTok.IsConstValue = true;
                    parentTok.ConstValue = new BasicValueToken((ulong)val.Value_UShort);
                    return true;
                }
                else if (val.ValueType == BasicValueToken.BasicValueTypeEnum.LONG)
                {
                    parentTok.IsConstValue = true;
                    parentTok.ConstValue = new BasicValueToken((ulong)val.Value_Long);
                    return true;
                }
                else if (val.ValueType == BasicValueToken.BasicValueTypeEnum.ULONG)
                {
                    parentTok.IsConstValue = true;
                    parentTok.ConstValue = new BasicValueToken((ulong)val.Value_ULong);
                    return true;
                }
                else if (val.ValueType == BasicValueToken.BasicValueTypeEnum.CHAR)
                {
                    parentTok.IsConstValue = true;
                    parentTok.ConstValue = new BasicValueToken((ulong)val.Value_Char);
                    return true;
                }
                else if (val.ValueType == BasicValueToken.BasicValueTypeEnum.FLOAT)
                {
                    parentTok.IsConstValue = true;
                    parentTok.ConstValue = new BasicValueToken((ulong)val.Value_Float);
                    return true;
                }
                else if (val.ValueType == BasicValueToken.BasicValueTypeEnum.DOUBLE)
                {
                    parentTok.IsConstValue = true;
                    parentTok.ConstValue = new BasicValueToken((ulong)val.Value_Double);
                    return true;
                }
            }
            #endregion
            #region TO CHAR
            else if (toStr.Equals("char"))
            {
                if (val.ValueType == BasicValueToken.BasicValueTypeEnum.INT)
                {
                    parentTok.IsConstValue = true;
                    parentTok.ConstValue = new BasicValueToken((char)val.Value_Int);
                    return true;
                }
                else if (val.ValueType == BasicValueToken.BasicValueTypeEnum.UINT)
                {
                    parentTok.IsConstValue = true;
                    parentTok.ConstValue = new BasicValueToken((char)val.Value_UInt);
                    return true;
                }
                else if (val.ValueType == BasicValueToken.BasicValueTypeEnum.SHORT)
                {
                    parentTok.IsConstValue = true;
                    parentTok.ConstValue = new BasicValueToken((char)val.Value_Short);
                    return true;
                }
                else if (val.ValueType == BasicValueToken.BasicValueTypeEnum.USHORT)
                {
                    parentTok.IsConstValue = true;
                    parentTok.ConstValue = new BasicValueToken((char)val.Value_UShort);
                    return true;
                }
                else if (val.ValueType == BasicValueToken.BasicValueTypeEnum.LONG)
                {
                    parentTok.IsConstValue = true;
                    parentTok.ConstValue = new BasicValueToken((char)val.Value_Long);
                    return true;
                }
                else if (val.ValueType == BasicValueToken.BasicValueTypeEnum.ULONG)
                {
                    parentTok.IsConstValue = true;
                    parentTok.ConstValue = new BasicValueToken((char)val.Value_ULong);
                    return true;
                }
                else if (val.ValueType == BasicValueToken.BasicValueTypeEnum.CHAR)
                {
                    parentTok.IsConstValue = true;
                    parentTok.ConstValue = new BasicValueToken((char)val.Value_Char);
                    return true;
                }
                else if (val.ValueType == BasicValueToken.BasicValueTypeEnum.FLOAT)
                {
                    parentTok.IsConstValue = true;
                    parentTok.ConstValue = new BasicValueToken((char)val.Value_Float);
                    return true;
                }
                else if (val.ValueType == BasicValueToken.BasicValueTypeEnum.DOUBLE)
                {
                    parentTok.IsConstValue = true;
                    parentTok.ConstValue = new BasicValueToken((char)val.Value_Double);
                    return true;
                }
            }
            #endregion
            #region TO FLOAT
            else if (toStr.Equals("float"))
            {
                if (val.ValueType == BasicValueToken.BasicValueTypeEnum.INT)
                {
                    parentTok.IsConstValue = true;
                    parentTok.ConstValue = new BasicValueToken((float)val.Value_Int);
                    return true;
                }
                else if (val.ValueType == BasicValueToken.BasicValueTypeEnum.UINT)
                {
                    parentTok.IsConstValue = true;
                    parentTok.ConstValue = new BasicValueToken((float)val.Value_UInt);
                    return true;
                }
                else if (val.ValueType == BasicValueToken.BasicValueTypeEnum.SHORT)
                {
                    parentTok.IsConstValue = true;
                    parentTok.ConstValue = new BasicValueToken((float)val.Value_Short);
                    return true;
                }
                else if (val.ValueType == BasicValueToken.BasicValueTypeEnum.USHORT)
                {
                    parentTok.IsConstValue = true;
                    parentTok.ConstValue = new BasicValueToken((float)val.Value_UShort);
                    return true;
                }
                else if (val.ValueType == BasicValueToken.BasicValueTypeEnum.LONG)
                {
                    parentTok.IsConstValue = true;
                    parentTok.ConstValue = new BasicValueToken((float)val.Value_Long);
                    return true;
                }
                else if (val.ValueType == BasicValueToken.BasicValueTypeEnum.ULONG)
                {
                    parentTok.IsConstValue = true;
                    parentTok.ConstValue = new BasicValueToken((float)val.Value_ULong);
                    return true;
                }
                else if (val.ValueType == BasicValueToken.BasicValueTypeEnum.CHAR)
                {
                    parentTok.IsConstValue = true;
                    parentTok.ConstValue = new BasicValueToken((float)val.Value_Char);
                    return true;
                }
                else if (val.ValueType == BasicValueToken.BasicValueTypeEnum.FLOAT)
                {
                    parentTok.IsConstValue = true;
                    parentTok.ConstValue = new BasicValueToken((float)val.Value_Float);
                    return true;
                }
                else if (val.ValueType == BasicValueToken.BasicValueTypeEnum.DOUBLE)
                {
                    parentTok.IsConstValue = true;
                    parentTok.ConstValue = new BasicValueToken((float)val.Value_Double);
                    return true;
                }
            }
            #endregion
            #region TO DOUBLE
            else if (toStr.Equals("double"))
            {
                if (val.ValueType == BasicValueToken.BasicValueTypeEnum.INT)
                {
                    parentTok.IsConstValue = true;
                    parentTok.ConstValue = new BasicValueToken((double)val.Value_Int);
                    return true;
                }
                else if (val.ValueType == BasicValueToken.BasicValueTypeEnum.UINT)
                {
                    parentTok.IsConstValue = true;
                    parentTok.ConstValue = new BasicValueToken((double)val.Value_UInt);
                    return true;
                }
                else if (val.ValueType == BasicValueToken.BasicValueTypeEnum.SHORT)
                {
                    parentTok.IsConstValue = true;
                    parentTok.ConstValue = new BasicValueToken((double)val.Value_Short);
                    return true;
                }
                else if (val.ValueType == BasicValueToken.BasicValueTypeEnum.USHORT)
                {
                    parentTok.IsConstValue = true;
                    parentTok.ConstValue = new BasicValueToken((double)val.Value_UShort);
                    return true;
                }
                else if (val.ValueType == BasicValueToken.BasicValueTypeEnum.LONG)
                {
                    parentTok.IsConstValue = true;
                    parentTok.ConstValue = new BasicValueToken((double)val.Value_Long);
                    return true;
                }
                else if (val.ValueType == BasicValueToken.BasicValueTypeEnum.ULONG)
                {
                    parentTok.IsConstValue = true;
                    parentTok.ConstValue = new BasicValueToken((double)val.Value_ULong);
                    return true;
                }
                else if (val.ValueType == BasicValueToken.BasicValueTypeEnum.CHAR)
                {
                    parentTok.IsConstValue = true;
                    parentTok.ConstValue = new BasicValueToken((double)val.Value_Char);
                    return true;
                }
                else if (val.ValueType == BasicValueToken.BasicValueTypeEnum.FLOAT)
                {
                    parentTok.IsConstValue = true;
                    parentTok.ConstValue = new BasicValueToken((double)val.Value_Float);
                    return true;
                }
                else if (val.ValueType == BasicValueToken.BasicValueTypeEnum.DOUBLE)
                {
                    parentTok.IsConstValue = true;
                    parentTok.ConstValue = new BasicValueToken((double)val.Value_Double);
                    return true;
                }
            }
            #endregion
            #region TO BOOL
            else if (toStr.Equals("bool"))
            {
                if (val.ValueType == BasicValueToken.BasicValueTypeEnum.BOOL)
                {
                    parentTok.IsConstValue = true;
                    parentTok.ConstValue = new BasicValueToken((bool)val.Value_Bool);
                    return true;
                }
            }
            #endregion



            return false;
        }





        public static bool TryOptimizeExpressionToken(ExpressionToken tok)
        {
            if (tok.IsVariable)
                return false;
            if (tok.IsConstValue)
                return false;
            if (tok.IsCast)
            {
                bool change = false;
                change |= TryOptimizeExpressionToken(tok.Cast.ToCast);
                Console.WriteLine($"Trying to opt {tok.Cast.ToCast}");
                if (tok.Cast.ToCast.IsConstValue)
                {
                    var val = tok.Cast.ToCast.ConstValue;
                    if (!tok.Cast.CastType.ToPureString().Equals(BasicValueToken.TypeEnumToString[val.ValueType]))
                        change |= TryCast(tok, tok.Cast.CastType, val);
                }


                return change;
            }
            if (tok.OnlyUseLeft)
            {
                if (tok.Operator.Operator == OperatorToken.OperatorEnum.Not)
                {
                    TryOptimizeExpressionToken(tok.Left);
                    if (tok.Left.IsConstValue)
                    {
                        if (tok.Left.ConstValue.ValueType != BasicValueToken.BasicValueTypeEnum.BOOL)
                            throw new Exception("Trying to use NOT on non-bool expression!");
                        tok.IsConstValue = true;
                        tok.ConstValue = new BasicValueToken(!tok.Left.ConstValue.Value_Bool);
                        tok.Left = null;
                        tok.Operator = null;
                    }
                }
                else if (tok.Operator.Operator == OperatorToken.OperatorEnum.BitNot)
                {
                    TryOptimizeExpressionToken(tok.Left);
                    if (tok.Left.IsConstValue)
                    {
                        if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.INT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(~tok.Left.ConstValue.Value_Int);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.LONG)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(~tok.Left.ConstValue.Value_Long);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.CHAR)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(~tok.Left.ConstValue.Value_Char);
                            tok.Left = null;
                            tok.Operator = null;
                        }


                        else
                            throw new Exception("Trying to use BINARY NOT on non-int expression!");

                    }
                }
            }
            else
            {
                // Bro i wrote a program to generate this bc pain

                #region PLUS
                if (tok.Operator.Operator == OperatorToken.OperatorEnum.Plus)
                {
                    TryOptimizeExpressionToken(tok.Left);
                    TryOptimizeExpressionToken(tok.Right);
                    if (tok.Left.IsConstValue && tok.Right.IsConstValue &&
                        tok.Left.ConstValue.ValueType != BasicValueToken.BasicValueTypeEnum.CHAR_POINTER &&
                        tok.Right.ConstValue.ValueType != BasicValueToken.BasicValueTypeEnum.CHAR_POINTER)
                    {
                        #region INT + INT
                        if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.INT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.INT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Int +
                                tok.Right.ConstValue.Value_Int);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region INT + UINT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.INT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.UINT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Int +
                                tok.Right.ConstValue.Value_UInt);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region INT + SHORT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.INT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.SHORT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Int +
                                tok.Right.ConstValue.Value_Short);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region INT + USHORT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.INT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.USHORT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Int +
                                tok.Right.ConstValue.Value_UShort);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region INT + LONG
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.INT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.LONG)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Int +
                                tok.Right.ConstValue.Value_Long);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region INT + CHAR
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.INT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.CHAR)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Int +
                                tok.Right.ConstValue.Value_Char);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region INT + FLOAT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.INT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.FLOAT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Int +
                                tok.Right.ConstValue.Value_Float);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region INT + DOUBLE
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.INT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.DOUBLE)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Int +
                                tok.Right.ConstValue.Value_Double);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion

                        #region UINT + INT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.UINT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.INT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_UInt +
                                tok.Right.ConstValue.Value_Int);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region UINT + UINT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.UINT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.UINT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_UInt +
                                tok.Right.ConstValue.Value_UInt);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region UINT + SHORT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.UINT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.SHORT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_UInt +
                                tok.Right.ConstValue.Value_Short);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region UINT + USHORT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.UINT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.USHORT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_UInt +
                                tok.Right.ConstValue.Value_UShort);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region UINT + LONG
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.UINT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.LONG)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_UInt +
                                tok.Right.ConstValue.Value_Long);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region UINT + CHAR
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.UINT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.CHAR)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_UInt +
                                tok.Right.ConstValue.Value_Char);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region UINT + FLOAT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.UINT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.FLOAT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_UInt +
                                tok.Right.ConstValue.Value_Float);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region UINT + DOUBLE
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.UINT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.DOUBLE)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_UInt +
                                tok.Right.ConstValue.Value_Double);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion

                        #region SHORT + INT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.SHORT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.INT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Short +
                                tok.Right.ConstValue.Value_Int);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region SHORT + UINT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.SHORT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.UINT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Short +
                                tok.Right.ConstValue.Value_UInt);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region SHORT + SHORT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.SHORT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.SHORT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Short +
                                tok.Right.ConstValue.Value_Short);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region SHORT + USHORT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.SHORT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.USHORT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Short +
                                tok.Right.ConstValue.Value_UShort);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region SHORT + LONG
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.SHORT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.LONG)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Short +
                                tok.Right.ConstValue.Value_Long);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region SHORT + CHAR
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.SHORT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.CHAR)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Short +
                                tok.Right.ConstValue.Value_Char);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region SHORT + FLOAT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.SHORT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.FLOAT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Short +
                                tok.Right.ConstValue.Value_Float);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region SHORT + DOUBLE
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.SHORT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.DOUBLE)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Short +
                                tok.Right.ConstValue.Value_Double);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion

                        #region USHORT + INT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.USHORT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.INT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_UShort +
                                tok.Right.ConstValue.Value_Int);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region USHORT + UINT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.USHORT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.UINT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_UShort +
                                tok.Right.ConstValue.Value_UInt);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region USHORT + SHORT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.USHORT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.SHORT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_UShort +
                                tok.Right.ConstValue.Value_Short);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region USHORT + USHORT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.USHORT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.USHORT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_UShort +
                                tok.Right.ConstValue.Value_UShort);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region USHORT + LONG
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.USHORT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.LONG)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_UShort +
                                tok.Right.ConstValue.Value_Long);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region USHORT + CHAR
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.USHORT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.CHAR)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_UShort +
                                tok.Right.ConstValue.Value_Char);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region USHORT + FLOAT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.USHORT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.FLOAT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_UShort +
                                tok.Right.ConstValue.Value_Float);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region USHORT + DOUBLE
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.USHORT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.DOUBLE)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_UShort +
                                tok.Right.ConstValue.Value_Double);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion

                        #region LONG + INT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.LONG &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.INT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Long +
                                tok.Right.ConstValue.Value_Int);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region LONG + UINT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.LONG &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.UINT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Long +
                                tok.Right.ConstValue.Value_UInt);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region LONG + SHORT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.LONG &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.SHORT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Long +
                                tok.Right.ConstValue.Value_Short);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region LONG + USHORT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.LONG &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.USHORT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Long +
                                tok.Right.ConstValue.Value_UShort);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region LONG + LONG
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.LONG &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.LONG)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Long +
                                tok.Right.ConstValue.Value_Long);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region LONG + CHAR
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.LONG &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.CHAR)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Long +
                                tok.Right.ConstValue.Value_Char);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region LONG + FLOAT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.LONG &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.FLOAT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Long +
                                tok.Right.ConstValue.Value_Float);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region LONG + DOUBLE
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.LONG &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.DOUBLE)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Long +
                                tok.Right.ConstValue.Value_Double);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion

                        #region CHAR + INT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.CHAR &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.INT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Char +
                                tok.Right.ConstValue.Value_Int);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region CHAR + UINT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.CHAR &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.UINT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Char +
                                tok.Right.ConstValue.Value_UInt);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region CHAR + SHORT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.CHAR &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.SHORT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Char +
                                tok.Right.ConstValue.Value_Short);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region CHAR + USHORT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.CHAR &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.USHORT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Char +
                                tok.Right.ConstValue.Value_UShort);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region CHAR + LONG
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.CHAR &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.LONG)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Char +
                                tok.Right.ConstValue.Value_Long);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region CHAR + CHAR
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.CHAR &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.CHAR)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Char +
                                tok.Right.ConstValue.Value_Char);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region CHAR + FLOAT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.CHAR &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.FLOAT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Char +
                                tok.Right.ConstValue.Value_Float);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region CHAR + DOUBLE
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.CHAR &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.DOUBLE)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Char +
                                tok.Right.ConstValue.Value_Double);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion

                        #region FLOAT + INT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.FLOAT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.INT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Float +
                                tok.Right.ConstValue.Value_Int);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region FLOAT + UINT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.FLOAT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.UINT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Float +
                                tok.Right.ConstValue.Value_UInt);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region FLOAT + SHORT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.FLOAT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.SHORT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Float +
                                tok.Right.ConstValue.Value_Short);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region FLOAT + USHORT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.FLOAT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.USHORT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Float +
                                tok.Right.ConstValue.Value_UShort);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region FLOAT + LONG
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.FLOAT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.LONG)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Float +
                                tok.Right.ConstValue.Value_Long);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region FLOAT + CHAR
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.FLOAT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.CHAR)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Float +
                                tok.Right.ConstValue.Value_Char);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region FLOAT + FLOAT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.FLOAT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.FLOAT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Float +
                                tok.Right.ConstValue.Value_Float);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region FLOAT + DOUBLE
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.FLOAT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.DOUBLE)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Float +
                                tok.Right.ConstValue.Value_Double);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion

                        #region DOUBLE + INT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.DOUBLE &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.INT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Double +
                                tok.Right.ConstValue.Value_Int);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region DOUBLE + UINT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.DOUBLE &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.UINT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Double +
                                tok.Right.ConstValue.Value_UInt);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region DOUBLE + SHORT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.DOUBLE &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.SHORT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Double +
                                tok.Right.ConstValue.Value_Short);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region DOUBLE + USHORT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.DOUBLE &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.USHORT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Double +
                                tok.Right.ConstValue.Value_UShort);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region DOUBLE + LONG
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.DOUBLE &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.LONG)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Double +
                                tok.Right.ConstValue.Value_Long);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region DOUBLE + CHAR
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.DOUBLE &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.CHAR)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Double +
                                tok.Right.ConstValue.Value_Char);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region DOUBLE + FLOAT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.DOUBLE &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.FLOAT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Double +
                                tok.Right.ConstValue.Value_Float);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region DOUBLE + DOUBLE
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.DOUBLE &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.DOUBLE)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Double +
                                tok.Right.ConstValue.Value_Double);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion

                        #region ULONG + ULONG
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.ULONG &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.ULONG)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_ULong +
                                tok.Right.ConstValue.Value_ULong);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion

                        else
                            throw new Exception($"EXPRESSION {tok.Left} + {tok.Right} cannot be optimized!");
                    }
                }
                #endregion
                #region MINUS
                else if (tok.Operator.Operator == OperatorToken.OperatorEnum.Minus)
                {
                    TryOptimizeExpressionToken(tok.Left);
                    TryOptimizeExpressionToken(tok.Right);
                    if (tok.Left.IsConstValue && tok.Right.IsConstValue)
                    {
                        #region INT - INT
                        if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.INT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.INT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Int -
                                tok.Right.ConstValue.Value_Int);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region INT - UINT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.INT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.UINT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Int -
                                tok.Right.ConstValue.Value_UInt);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region INT - SHORT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.INT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.SHORT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Int -
                                tok.Right.ConstValue.Value_Short);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region INT - USHORT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.INT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.USHORT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Int -
                                tok.Right.ConstValue.Value_UShort);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region INT - LONG
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.INT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.LONG)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Int -
                                tok.Right.ConstValue.Value_Long);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region INT - CHAR
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.INT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.CHAR)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Int -
                                tok.Right.ConstValue.Value_Char);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region INT - FLOAT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.INT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.FLOAT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Int -
                                tok.Right.ConstValue.Value_Float);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region INT - DOUBLE
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.INT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.DOUBLE)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Int -
                                tok.Right.ConstValue.Value_Double);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion

                        #region UINT - INT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.UINT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.INT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_UInt -
                                tok.Right.ConstValue.Value_Int);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region UINT - UINT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.UINT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.UINT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_UInt -
                                tok.Right.ConstValue.Value_UInt);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region UINT - SHORT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.UINT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.SHORT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_UInt -
                                tok.Right.ConstValue.Value_Short);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region UINT - USHORT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.UINT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.USHORT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_UInt -
                                tok.Right.ConstValue.Value_UShort);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region UINT - LONG
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.UINT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.LONG)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_UInt -
                                tok.Right.ConstValue.Value_Long);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region UINT - CHAR
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.UINT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.CHAR)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_UInt -
                                tok.Right.ConstValue.Value_Char);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region UINT - FLOAT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.UINT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.FLOAT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_UInt -
                                tok.Right.ConstValue.Value_Float);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region UINT - DOUBLE
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.UINT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.DOUBLE)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_UInt -
                                tok.Right.ConstValue.Value_Double);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion

                        #region SHORT - INT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.SHORT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.INT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Short -
                                tok.Right.ConstValue.Value_Int);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region SHORT - UINT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.SHORT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.UINT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Short -
                                tok.Right.ConstValue.Value_UInt);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region SHORT - SHORT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.SHORT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.SHORT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Short -
                                tok.Right.ConstValue.Value_Short);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region SHORT - USHORT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.SHORT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.USHORT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Short -
                                tok.Right.ConstValue.Value_UShort);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region SHORT - LONG
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.SHORT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.LONG)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Short -
                                tok.Right.ConstValue.Value_Long);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region SHORT - CHAR
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.SHORT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.CHAR)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Short -
                                tok.Right.ConstValue.Value_Char);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region SHORT - FLOAT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.SHORT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.FLOAT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Short -
                                tok.Right.ConstValue.Value_Float);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region SHORT - DOUBLE
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.SHORT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.DOUBLE)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Short -
                                tok.Right.ConstValue.Value_Double);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion

                        #region USHORT - INT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.USHORT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.INT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_UShort -
                                tok.Right.ConstValue.Value_Int);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region USHORT - UINT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.USHORT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.UINT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_UShort -
                                tok.Right.ConstValue.Value_UInt);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region USHORT - SHORT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.USHORT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.SHORT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_UShort -
                                tok.Right.ConstValue.Value_Short);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region USHORT - USHORT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.USHORT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.USHORT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_UShort -
                                tok.Right.ConstValue.Value_UShort);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region USHORT - LONG
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.USHORT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.LONG)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_UShort -
                                tok.Right.ConstValue.Value_Long);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region USHORT - CHAR
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.USHORT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.CHAR)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_UShort -
                                tok.Right.ConstValue.Value_Char);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region USHORT - FLOAT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.USHORT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.FLOAT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_UShort -
                                tok.Right.ConstValue.Value_Float);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region USHORT - DOUBLE
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.USHORT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.DOUBLE)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_UShort -
                                tok.Right.ConstValue.Value_Double);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion

                        #region LONG - INT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.LONG &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.INT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Long -
                                tok.Right.ConstValue.Value_Int);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region LONG - UINT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.LONG &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.UINT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Long -
                                tok.Right.ConstValue.Value_UInt);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region LONG - SHORT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.LONG &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.SHORT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Long -
                                tok.Right.ConstValue.Value_Short);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region LONG - USHORT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.LONG &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.USHORT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Long -
                                tok.Right.ConstValue.Value_UShort);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region LONG - LONG
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.LONG &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.LONG)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Long -
                                tok.Right.ConstValue.Value_Long);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region LONG - CHAR
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.LONG &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.CHAR)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Long -
                                tok.Right.ConstValue.Value_Char);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region LONG - FLOAT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.LONG &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.FLOAT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Long -
                                tok.Right.ConstValue.Value_Float);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region LONG - DOUBLE
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.LONG &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.DOUBLE)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Long -
                                tok.Right.ConstValue.Value_Double);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion

                        #region CHAR - INT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.CHAR &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.INT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Char -
                                tok.Right.ConstValue.Value_Int);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region CHAR - UINT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.CHAR &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.UINT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Char -
                                tok.Right.ConstValue.Value_UInt);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region CHAR - SHORT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.CHAR &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.SHORT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Char -
                                tok.Right.ConstValue.Value_Short);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region CHAR - USHORT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.CHAR &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.USHORT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Char -
                                tok.Right.ConstValue.Value_UShort);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region CHAR - LONG
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.CHAR &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.LONG)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Char -
                                tok.Right.ConstValue.Value_Long);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region CHAR - CHAR
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.CHAR &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.CHAR)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Char -
                                tok.Right.ConstValue.Value_Char);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region CHAR - FLOAT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.CHAR &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.FLOAT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Char -
                                tok.Right.ConstValue.Value_Float);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region CHAR - DOUBLE
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.CHAR &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.DOUBLE)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Char -
                                tok.Right.ConstValue.Value_Double);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion

                        #region FLOAT - INT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.FLOAT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.INT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Float -
                                tok.Right.ConstValue.Value_Int);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region FLOAT - UINT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.FLOAT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.UINT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Float -
                                tok.Right.ConstValue.Value_UInt);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region FLOAT - SHORT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.FLOAT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.SHORT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Float -
                                tok.Right.ConstValue.Value_Short);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region FLOAT - USHORT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.FLOAT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.USHORT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Float -
                                tok.Right.ConstValue.Value_UShort);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region FLOAT - LONG
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.FLOAT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.LONG)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Float -
                                tok.Right.ConstValue.Value_Long);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region FLOAT - CHAR
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.FLOAT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.CHAR)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Float -
                                tok.Right.ConstValue.Value_Char);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region FLOAT - FLOAT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.FLOAT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.FLOAT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Float -
                                tok.Right.ConstValue.Value_Float);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region FLOAT - DOUBLE
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.FLOAT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.DOUBLE)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Float -
                                tok.Right.ConstValue.Value_Double);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion

                        #region DOUBLE - INT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.DOUBLE &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.INT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Double -
                                tok.Right.ConstValue.Value_Int);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region DOUBLE - UINT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.DOUBLE &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.UINT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Double -
                                tok.Right.ConstValue.Value_UInt);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region DOUBLE - SHORT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.DOUBLE &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.SHORT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Double -
                                tok.Right.ConstValue.Value_Short);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region DOUBLE - USHORT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.DOUBLE &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.USHORT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Double -
                                tok.Right.ConstValue.Value_UShort);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region DOUBLE - LONG
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.DOUBLE &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.LONG)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Double -
                                tok.Right.ConstValue.Value_Long);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region DOUBLE - CHAR
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.DOUBLE &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.CHAR)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Double -
                                tok.Right.ConstValue.Value_Char);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region DOUBLE - FLOAT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.DOUBLE &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.FLOAT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Double -
                                tok.Right.ConstValue.Value_Float);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region DOUBLE - DOUBLE
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.DOUBLE &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.DOUBLE)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Double -
                                tok.Right.ConstValue.Value_Double);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion

                        #region ULONG - ULONG
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.ULONG &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.ULONG)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_ULong -
                                tok.Right.ConstValue.Value_ULong);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion

                        else
                            throw new Exception($"EXPRESSION {tok.Left} - {tok.Right} cannot be optimized!");
                    }
                }
                #endregion
                #region MULT
                else if (tok.Operator.Operator == OperatorToken.OperatorEnum.Star)
                {
                    TryOptimizeExpressionToken(tok.Left);
                    TryOptimizeExpressionToken(tok.Right);
                    if (tok.Left.IsConstValue && tok.Right.IsConstValue)
                    {
                        #region INT * INT
                        if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.INT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.INT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Int *
                                tok.Right.ConstValue.Value_Int);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region INT * UINT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.INT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.UINT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Int *
                                tok.Right.ConstValue.Value_UInt);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region INT * SHORT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.INT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.SHORT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Int *
                                tok.Right.ConstValue.Value_Short);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region INT * USHORT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.INT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.USHORT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Int *
                                tok.Right.ConstValue.Value_UShort);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region INT * LONG
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.INT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.LONG)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Int *
                                tok.Right.ConstValue.Value_Long);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region INT * CHAR
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.INT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.CHAR)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Int *
                                tok.Right.ConstValue.Value_Char);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region INT * FLOAT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.INT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.FLOAT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Int *
                                tok.Right.ConstValue.Value_Float);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region INT * DOUBLE
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.INT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.DOUBLE)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Int *
                                tok.Right.ConstValue.Value_Double);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion

                        #region UINT * INT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.UINT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.INT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_UInt *
                                tok.Right.ConstValue.Value_Int);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region UINT * UINT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.UINT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.UINT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_UInt *
                                tok.Right.ConstValue.Value_UInt);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region UINT * SHORT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.UINT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.SHORT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_UInt *
                                tok.Right.ConstValue.Value_Short);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region UINT * USHORT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.UINT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.USHORT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_UInt *
                                tok.Right.ConstValue.Value_UShort);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region UINT * LONG
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.UINT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.LONG)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_UInt *
                                tok.Right.ConstValue.Value_Long);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region UINT * CHAR
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.UINT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.CHAR)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_UInt *
                                tok.Right.ConstValue.Value_Char);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region UINT * FLOAT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.UINT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.FLOAT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_UInt *
                                tok.Right.ConstValue.Value_Float);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region UINT * DOUBLE
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.UINT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.DOUBLE)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_UInt *
                                tok.Right.ConstValue.Value_Double);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion

                        #region SHORT * INT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.SHORT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.INT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Short *
                                tok.Right.ConstValue.Value_Int);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region SHORT * UINT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.SHORT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.UINT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Short *
                                tok.Right.ConstValue.Value_UInt);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region SHORT * SHORT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.SHORT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.SHORT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Short *
                                tok.Right.ConstValue.Value_Short);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region SHORT * USHORT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.SHORT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.USHORT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Short *
                                tok.Right.ConstValue.Value_UShort);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region SHORT * LONG
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.SHORT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.LONG)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Short *
                                tok.Right.ConstValue.Value_Long);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region SHORT * CHAR
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.SHORT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.CHAR)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Short *
                                tok.Right.ConstValue.Value_Char);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region SHORT * FLOAT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.SHORT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.FLOAT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Short *
                                tok.Right.ConstValue.Value_Float);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region SHORT * DOUBLE
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.SHORT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.DOUBLE)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Short *
                                tok.Right.ConstValue.Value_Double);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion

                        #region USHORT * INT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.USHORT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.INT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_UShort *
                                tok.Right.ConstValue.Value_Int);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region USHORT * UINT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.USHORT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.UINT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_UShort *
                                tok.Right.ConstValue.Value_UInt);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region USHORT * SHORT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.USHORT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.SHORT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_UShort *
                                tok.Right.ConstValue.Value_Short);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region USHORT * USHORT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.USHORT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.USHORT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_UShort *
                                tok.Right.ConstValue.Value_UShort);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region USHORT * LONG
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.USHORT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.LONG)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_UShort *
                                tok.Right.ConstValue.Value_Long);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region USHORT * CHAR
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.USHORT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.CHAR)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_UShort *
                                tok.Right.ConstValue.Value_Char);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region USHORT * FLOAT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.USHORT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.FLOAT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_UShort *
                                tok.Right.ConstValue.Value_Float);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region USHORT * DOUBLE
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.USHORT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.DOUBLE)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_UShort *
                                tok.Right.ConstValue.Value_Double);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion

                        #region LONG * INT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.LONG &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.INT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Long *
                                tok.Right.ConstValue.Value_Int);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region LONG * UINT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.LONG &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.UINT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Long *
                                tok.Right.ConstValue.Value_UInt);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region LONG * SHORT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.LONG &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.SHORT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Long *
                                tok.Right.ConstValue.Value_Short);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region LONG * USHORT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.LONG &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.USHORT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Long *
                                tok.Right.ConstValue.Value_UShort);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region LONG * LONG
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.LONG &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.LONG)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Long *
                                tok.Right.ConstValue.Value_Long);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region LONG * CHAR
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.LONG &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.CHAR)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Long *
                                tok.Right.ConstValue.Value_Char);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region LONG * FLOAT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.LONG &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.FLOAT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Long *
                                tok.Right.ConstValue.Value_Float);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region LONG * DOUBLE
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.LONG &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.DOUBLE)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Long *
                                tok.Right.ConstValue.Value_Double);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion

                        #region CHAR * INT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.CHAR &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.INT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Char *
                                tok.Right.ConstValue.Value_Int);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region CHAR * UINT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.CHAR &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.UINT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Char *
                                tok.Right.ConstValue.Value_UInt);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region CHAR * SHORT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.CHAR &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.SHORT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Char *
                                tok.Right.ConstValue.Value_Short);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region CHAR * USHORT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.CHAR &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.USHORT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Char *
                                tok.Right.ConstValue.Value_UShort);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region CHAR * LONG
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.CHAR &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.LONG)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Char *
                                tok.Right.ConstValue.Value_Long);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region CHAR * CHAR
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.CHAR &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.CHAR)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Char *
                                tok.Right.ConstValue.Value_Char);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region CHAR * FLOAT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.CHAR &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.FLOAT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Char *
                                tok.Right.ConstValue.Value_Float);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region CHAR * DOUBLE
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.CHAR &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.DOUBLE)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Char *
                                tok.Right.ConstValue.Value_Double);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion

                        #region FLOAT * INT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.FLOAT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.INT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Float *
                                tok.Right.ConstValue.Value_Int);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region FLOAT * UINT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.FLOAT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.UINT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Float *
                                tok.Right.ConstValue.Value_UInt);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region FLOAT * SHORT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.FLOAT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.SHORT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Float *
                                tok.Right.ConstValue.Value_Short);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region FLOAT * USHORT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.FLOAT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.USHORT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Float *
                                tok.Right.ConstValue.Value_UShort);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region FLOAT * LONG
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.FLOAT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.LONG)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Float *
                                tok.Right.ConstValue.Value_Long);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region FLOAT * CHAR
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.FLOAT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.CHAR)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Float *
                                tok.Right.ConstValue.Value_Char);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region FLOAT * FLOAT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.FLOAT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.FLOAT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Float *
                                tok.Right.ConstValue.Value_Float);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region FLOAT * DOUBLE
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.FLOAT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.DOUBLE)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Float *
                                tok.Right.ConstValue.Value_Double);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion

                        #region DOUBLE * INT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.DOUBLE &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.INT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Double *
                                tok.Right.ConstValue.Value_Int);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region DOUBLE * UINT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.DOUBLE &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.UINT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Double *
                                tok.Right.ConstValue.Value_UInt);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region DOUBLE * SHORT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.DOUBLE &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.SHORT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Double *
                                tok.Right.ConstValue.Value_Short);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region DOUBLE * USHORT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.DOUBLE &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.USHORT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Double *
                                tok.Right.ConstValue.Value_UShort);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region DOUBLE * LONG
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.DOUBLE &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.LONG)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Double *
                                tok.Right.ConstValue.Value_Long);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region DOUBLE * CHAR
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.DOUBLE &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.CHAR)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Double *
                                tok.Right.ConstValue.Value_Char);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region DOUBLE * FLOAT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.DOUBLE &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.FLOAT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Double *
                                tok.Right.ConstValue.Value_Float);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region DOUBLE * DOUBLE
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.DOUBLE &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.DOUBLE)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Double *
                                tok.Right.ConstValue.Value_Double);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion

                        #region ULONG * ULONG
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.ULONG &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.ULONG)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_ULong *
                                tok.Right.ConstValue.Value_ULong);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion

                        else
                            throw new Exception($"EXPRESSION {tok.Left} * {tok.Right} cannot be optimized!");
                    }
                }
                #endregion
                #region DIV
                else if (tok.Operator.Operator == OperatorToken.OperatorEnum.Divide)
                {
                    TryOptimizeExpressionToken(tok.Left);
                    TryOptimizeExpressionToken(tok.Right);
                    if (tok.Left.IsConstValue && tok.Right.IsConstValue)
                    {
                        #region INT / INT
                        if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.INT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.INT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Int /
                                tok.Right.ConstValue.Value_Int);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region INT / UINT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.INT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.UINT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Int /
                                tok.Right.ConstValue.Value_UInt);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region INT / SHORT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.INT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.SHORT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Int /
                                tok.Right.ConstValue.Value_Short);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region INT / USHORT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.INT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.USHORT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Int /
                                tok.Right.ConstValue.Value_UShort);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region INT / LONG
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.INT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.LONG)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Int /
                                tok.Right.ConstValue.Value_Long);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region INT / CHAR
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.INT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.CHAR)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Int /
                                tok.Right.ConstValue.Value_Char);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region INT / FLOAT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.INT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.FLOAT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Int /
                                tok.Right.ConstValue.Value_Float);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region INT / DOUBLE
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.INT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.DOUBLE)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Int /
                                tok.Right.ConstValue.Value_Double);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion

                        #region UINT / INT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.UINT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.INT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_UInt /
                                tok.Right.ConstValue.Value_Int);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region UINT / UINT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.UINT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.UINT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_UInt /
                                tok.Right.ConstValue.Value_UInt);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region UINT / SHORT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.UINT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.SHORT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_UInt /
                                tok.Right.ConstValue.Value_Short);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region UINT / USHORT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.UINT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.USHORT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_UInt /
                                tok.Right.ConstValue.Value_UShort);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region UINT / LONG
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.UINT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.LONG)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_UInt /
                                tok.Right.ConstValue.Value_Long);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region UINT / CHAR
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.UINT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.CHAR)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_UInt /
                                tok.Right.ConstValue.Value_Char);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region UINT / FLOAT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.UINT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.FLOAT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_UInt /
                                tok.Right.ConstValue.Value_Float);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region UINT / DOUBLE
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.UINT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.DOUBLE)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_UInt /
                                tok.Right.ConstValue.Value_Double);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion

                        #region SHORT / INT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.SHORT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.INT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Short /
                                tok.Right.ConstValue.Value_Int);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region SHORT / UINT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.SHORT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.UINT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Short /
                                tok.Right.ConstValue.Value_UInt);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region SHORT / SHORT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.SHORT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.SHORT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Short /
                                tok.Right.ConstValue.Value_Short);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region SHORT / USHORT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.SHORT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.USHORT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Short /
                                tok.Right.ConstValue.Value_UShort);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region SHORT / LONG
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.SHORT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.LONG)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Short /
                                tok.Right.ConstValue.Value_Long);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region SHORT / CHAR
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.SHORT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.CHAR)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Short /
                                tok.Right.ConstValue.Value_Char);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region SHORT / FLOAT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.SHORT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.FLOAT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Short /
                                tok.Right.ConstValue.Value_Float);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region SHORT / DOUBLE
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.SHORT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.DOUBLE)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Short /
                                tok.Right.ConstValue.Value_Double);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion

                        #region USHORT / INT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.USHORT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.INT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_UShort /
                                tok.Right.ConstValue.Value_Int);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region USHORT / UINT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.USHORT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.UINT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_UShort /
                                tok.Right.ConstValue.Value_UInt);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region USHORT / SHORT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.USHORT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.SHORT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_UShort /
                                tok.Right.ConstValue.Value_Short);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region USHORT / USHORT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.USHORT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.USHORT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_UShort /
                                tok.Right.ConstValue.Value_UShort);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region USHORT / LONG
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.USHORT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.LONG)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_UShort /
                                tok.Right.ConstValue.Value_Long);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region USHORT / CHAR
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.USHORT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.CHAR)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_UShort /
                                tok.Right.ConstValue.Value_Char);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region USHORT / FLOAT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.USHORT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.FLOAT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_UShort /
                                tok.Right.ConstValue.Value_Float);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region USHORT / DOUBLE
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.USHORT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.DOUBLE)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_UShort /
                                tok.Right.ConstValue.Value_Double);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion

                        #region LONG / INT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.LONG &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.INT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Long /
                                tok.Right.ConstValue.Value_Int);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region LONG / UINT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.LONG &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.UINT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Long /
                                tok.Right.ConstValue.Value_UInt);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region LONG / SHORT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.LONG &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.SHORT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Long /
                                tok.Right.ConstValue.Value_Short);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region LONG / USHORT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.LONG &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.USHORT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Long /
                                tok.Right.ConstValue.Value_UShort);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region LONG / LONG
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.LONG &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.LONG)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Long /
                                tok.Right.ConstValue.Value_Long);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region LONG / CHAR
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.LONG &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.CHAR)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Long /
                                tok.Right.ConstValue.Value_Char);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region LONG / FLOAT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.LONG &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.FLOAT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Long /
                                tok.Right.ConstValue.Value_Float);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region LONG / DOUBLE
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.LONG &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.DOUBLE)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Long /
                                tok.Right.ConstValue.Value_Double);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion

                        #region CHAR / INT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.CHAR &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.INT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Char /
                                tok.Right.ConstValue.Value_Int);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region CHAR / UINT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.CHAR &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.UINT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Char /
                                tok.Right.ConstValue.Value_UInt);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region CHAR / SHORT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.CHAR &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.SHORT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Char /
                                tok.Right.ConstValue.Value_Short);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region CHAR / USHORT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.CHAR &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.USHORT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Char /
                                tok.Right.ConstValue.Value_UShort);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region CHAR / LONG
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.CHAR &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.LONG)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Char /
                                tok.Right.ConstValue.Value_Long);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region CHAR / CHAR
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.CHAR &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.CHAR)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Char /
                                tok.Right.ConstValue.Value_Char);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region CHAR / FLOAT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.CHAR &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.FLOAT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Char /
                                tok.Right.ConstValue.Value_Float);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region CHAR / DOUBLE
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.CHAR &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.DOUBLE)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Char /
                                tok.Right.ConstValue.Value_Double);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion

                        #region FLOAT / INT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.FLOAT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.INT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Float /
                                tok.Right.ConstValue.Value_Int);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region FLOAT / UINT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.FLOAT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.UINT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Float /
                                tok.Right.ConstValue.Value_UInt);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region FLOAT / SHORT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.FLOAT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.SHORT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Float /
                                tok.Right.ConstValue.Value_Short);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region FLOAT / USHORT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.FLOAT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.USHORT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Float /
                                tok.Right.ConstValue.Value_UShort);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region FLOAT / LONG
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.FLOAT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.LONG)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Float /
                                tok.Right.ConstValue.Value_Long);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region FLOAT / CHAR
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.FLOAT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.CHAR)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Float /
                                tok.Right.ConstValue.Value_Char);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region FLOAT / FLOAT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.FLOAT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.FLOAT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Float /
                                tok.Right.ConstValue.Value_Float);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region FLOAT / DOUBLE
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.FLOAT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.DOUBLE)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Float /
                                tok.Right.ConstValue.Value_Double);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion

                        #region DOUBLE / INT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.DOUBLE &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.INT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Double /
                                tok.Right.ConstValue.Value_Int);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region DOUBLE / UINT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.DOUBLE &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.UINT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Double /
                                tok.Right.ConstValue.Value_UInt);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region DOUBLE / SHORT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.DOUBLE &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.SHORT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Double /
                                tok.Right.ConstValue.Value_Short);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region DOUBLE / USHORT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.DOUBLE &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.USHORT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Double /
                                tok.Right.ConstValue.Value_UShort);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region DOUBLE / LONG
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.DOUBLE &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.LONG)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Double /
                                tok.Right.ConstValue.Value_Long);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region DOUBLE / CHAR
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.DOUBLE &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.CHAR)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Double /
                                tok.Right.ConstValue.Value_Char);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region DOUBLE / FLOAT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.DOUBLE &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.FLOAT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Double /
                                tok.Right.ConstValue.Value_Float);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region DOUBLE / DOUBLE
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.DOUBLE &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.DOUBLE)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Double /
                                tok.Right.ConstValue.Value_Double);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion

                        #region ULONG / ULONG
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.ULONG &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.ULONG)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_ULong /
                                tok.Right.ConstValue.Value_ULong);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion

                        else
                            throw new Exception($"EXPRESSION {tok.Left} / {tok.Right} cannot be optimized!");
                    }
                }
                #endregion
                #region MOD
                else if (tok.Operator.Operator == OperatorToken.OperatorEnum.Mod)
                {
                    TryOptimizeExpressionToken(tok.Left);
                    TryOptimizeExpressionToken(tok.Right);
                    if (tok.Left.IsConstValue && tok.Right.IsConstValue)
                    {
                        #region INT % INT
                        if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.INT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.INT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Int %
                                tok.Right.ConstValue.Value_Int);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region INT % UINT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.INT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.UINT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Int %
                                tok.Right.ConstValue.Value_UInt);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region INT % SHORT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.INT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.SHORT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Int %
                                tok.Right.ConstValue.Value_Short);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region INT % USHORT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.INT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.USHORT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Int %
                                tok.Right.ConstValue.Value_UShort);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region INT % LONG
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.INT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.LONG)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Int %
                                tok.Right.ConstValue.Value_Long);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region INT % CHAR
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.INT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.CHAR)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Int %
                                tok.Right.ConstValue.Value_Char);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region INT % FLOAT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.INT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.FLOAT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Int %
                                tok.Right.ConstValue.Value_Float);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region INT % DOUBLE
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.INT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.DOUBLE)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Int %
                                tok.Right.ConstValue.Value_Double);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion

                        #region UINT % INT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.UINT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.INT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_UInt %
                                tok.Right.ConstValue.Value_Int);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region UINT % UINT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.UINT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.UINT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_UInt %
                                tok.Right.ConstValue.Value_UInt);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region UINT % SHORT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.UINT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.SHORT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_UInt %
                                tok.Right.ConstValue.Value_Short);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region UINT % USHORT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.UINT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.USHORT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_UInt %
                                tok.Right.ConstValue.Value_UShort);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region UINT % LONG
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.UINT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.LONG)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_UInt %
                                tok.Right.ConstValue.Value_Long);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region UINT % CHAR
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.UINT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.CHAR)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_UInt %
                                tok.Right.ConstValue.Value_Char);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region UINT % FLOAT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.UINT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.FLOAT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_UInt %
                                tok.Right.ConstValue.Value_Float);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region UINT % DOUBLE
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.UINT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.DOUBLE)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_UInt %
                                tok.Right.ConstValue.Value_Double);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion

                        #region SHORT % INT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.SHORT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.INT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Short %
                                tok.Right.ConstValue.Value_Int);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region SHORT % UINT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.SHORT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.UINT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Short %
                                tok.Right.ConstValue.Value_UInt);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region SHORT % SHORT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.SHORT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.SHORT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Short %
                                tok.Right.ConstValue.Value_Short);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region SHORT % USHORT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.SHORT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.USHORT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Short %
                                tok.Right.ConstValue.Value_UShort);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region SHORT % LONG
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.SHORT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.LONG)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Short %
                                tok.Right.ConstValue.Value_Long);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region SHORT % CHAR
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.SHORT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.CHAR)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Short %
                                tok.Right.ConstValue.Value_Char);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region SHORT % FLOAT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.SHORT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.FLOAT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Short %
                                tok.Right.ConstValue.Value_Float);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region SHORT % DOUBLE
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.SHORT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.DOUBLE)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Short %
                                tok.Right.ConstValue.Value_Double);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion

                        #region USHORT % INT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.USHORT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.INT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_UShort %
                                tok.Right.ConstValue.Value_Int);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region USHORT % UINT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.USHORT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.UINT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_UShort %
                                tok.Right.ConstValue.Value_UInt);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region USHORT % SHORT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.USHORT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.SHORT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_UShort %
                                tok.Right.ConstValue.Value_Short);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region USHORT % USHORT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.USHORT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.USHORT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_UShort %
                                tok.Right.ConstValue.Value_UShort);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region USHORT % LONG
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.USHORT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.LONG)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_UShort %
                                tok.Right.ConstValue.Value_Long);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region USHORT % CHAR
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.USHORT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.CHAR)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_UShort %
                                tok.Right.ConstValue.Value_Char);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region USHORT % FLOAT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.USHORT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.FLOAT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_UShort %
                                tok.Right.ConstValue.Value_Float);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region USHORT % DOUBLE
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.USHORT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.DOUBLE)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_UShort %
                                tok.Right.ConstValue.Value_Double);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion

                        #region LONG % INT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.LONG &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.INT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Long %
                                tok.Right.ConstValue.Value_Int);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region LONG % UINT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.LONG &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.UINT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Long %
                                tok.Right.ConstValue.Value_UInt);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region LONG % SHORT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.LONG &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.SHORT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Long %
                                tok.Right.ConstValue.Value_Short);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region LONG % USHORT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.LONG &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.USHORT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Long %
                                tok.Right.ConstValue.Value_UShort);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region LONG % LONG
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.LONG &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.LONG)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Long %
                                tok.Right.ConstValue.Value_Long);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region LONG % CHAR
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.LONG &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.CHAR)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Long %
                                tok.Right.ConstValue.Value_Char);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region LONG % FLOAT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.LONG &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.FLOAT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Long %
                                tok.Right.ConstValue.Value_Float);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region LONG % DOUBLE
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.LONG &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.DOUBLE)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Long %
                                tok.Right.ConstValue.Value_Double);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion

                        #region CHAR % INT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.CHAR &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.INT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Char %
                                tok.Right.ConstValue.Value_Int);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region CHAR % UINT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.CHAR &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.UINT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Char %
                                tok.Right.ConstValue.Value_UInt);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region CHAR % SHORT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.CHAR &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.SHORT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Char %
                                tok.Right.ConstValue.Value_Short);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region CHAR % USHORT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.CHAR &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.USHORT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Char %
                                tok.Right.ConstValue.Value_UShort);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region CHAR % LONG
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.CHAR &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.LONG)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Char %
                                tok.Right.ConstValue.Value_Long);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region CHAR % CHAR
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.CHAR &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.CHAR)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Char %
                                tok.Right.ConstValue.Value_Char);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region CHAR % FLOAT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.CHAR &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.FLOAT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Char %
                                tok.Right.ConstValue.Value_Float);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region CHAR % DOUBLE
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.CHAR &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.DOUBLE)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Char %
                                tok.Right.ConstValue.Value_Double);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion

                        #region FLOAT % INT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.FLOAT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.INT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Float %
                                tok.Right.ConstValue.Value_Int);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region FLOAT % UINT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.FLOAT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.UINT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Float %
                                tok.Right.ConstValue.Value_UInt);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region FLOAT % SHORT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.FLOAT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.SHORT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Float %
                                tok.Right.ConstValue.Value_Short);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region FLOAT % USHORT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.FLOAT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.USHORT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Float %
                                tok.Right.ConstValue.Value_UShort);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region FLOAT % LONG
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.FLOAT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.LONG)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Float %
                                tok.Right.ConstValue.Value_Long);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region FLOAT % CHAR
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.FLOAT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.CHAR)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Float %
                                tok.Right.ConstValue.Value_Char);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region FLOAT % FLOAT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.FLOAT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.FLOAT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Float %
                                tok.Right.ConstValue.Value_Float);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region FLOAT % DOUBLE
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.FLOAT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.DOUBLE)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Float %
                                tok.Right.ConstValue.Value_Double);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion

                        #region DOUBLE % INT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.DOUBLE &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.INT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Double %
                                tok.Right.ConstValue.Value_Int);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region DOUBLE % UINT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.DOUBLE &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.UINT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Double %
                                tok.Right.ConstValue.Value_UInt);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region DOUBLE % SHORT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.DOUBLE &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.SHORT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Double %
                                tok.Right.ConstValue.Value_Short);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region DOUBLE % USHORT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.DOUBLE &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.USHORT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Double %
                                tok.Right.ConstValue.Value_UShort);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region DOUBLE % LONG
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.DOUBLE &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.LONG)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Double %
                                tok.Right.ConstValue.Value_Long);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region DOUBLE % CHAR
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.DOUBLE &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.CHAR)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Double %
                                tok.Right.ConstValue.Value_Char);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region DOUBLE % FLOAT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.DOUBLE &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.FLOAT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Double %
                                tok.Right.ConstValue.Value_Float);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region DOUBLE % DOUBLE
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.DOUBLE &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.DOUBLE)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Double %
                                tok.Right.ConstValue.Value_Double);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion

                        #region ULONG % ULONG
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.ULONG &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.ULONG)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_ULong %
                                tok.Right.ConstValue.Value_ULong);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion

                        else
                            throw new Exception($"EXPRESSION {tok.Left} % {tok.Right} cannot be optimized!");
                    }
                }
                #endregion
                #region EQUAL
                else if (tok.Operator.Operator == OperatorToken.OperatorEnum.Equal)
                {
                    TryOptimizeExpressionToken(tok.Left);
                    TryOptimizeExpressionToken(tok.Right);
                    if (tok.Left.IsConstValue && tok.Right.IsConstValue)
                    {
                        #region INT == INT
                        if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.INT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.INT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Int ==
                                tok.Right.ConstValue.Value_Int);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region INT == UINT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.INT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.UINT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Int ==
                                tok.Right.ConstValue.Value_UInt);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region INT == SHORT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.INT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.SHORT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Int ==
                                tok.Right.ConstValue.Value_Short);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region INT == USHORT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.INT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.USHORT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Int ==
                                tok.Right.ConstValue.Value_UShort);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region INT == LONG
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.INT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.LONG)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Int ==
                                tok.Right.ConstValue.Value_Long);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region INT == CHAR
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.INT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.CHAR)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Int ==
                                tok.Right.ConstValue.Value_Char);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region INT == FLOAT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.INT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.FLOAT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Int ==
                                tok.Right.ConstValue.Value_Float);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region INT == DOUBLE
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.INT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.DOUBLE)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Int ==
                                tok.Right.ConstValue.Value_Double);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion

                        #region UINT == INT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.UINT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.INT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_UInt ==
                                tok.Right.ConstValue.Value_Int);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region UINT == UINT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.UINT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.UINT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_UInt ==
                                tok.Right.ConstValue.Value_UInt);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region UINT == SHORT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.UINT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.SHORT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_UInt ==
                                tok.Right.ConstValue.Value_Short);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region UINT == USHORT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.UINT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.USHORT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_UInt ==
                                tok.Right.ConstValue.Value_UShort);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region UINT == LONG
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.UINT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.LONG)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_UInt ==
                                tok.Right.ConstValue.Value_Long);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region UINT == CHAR
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.UINT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.CHAR)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_UInt ==
                                tok.Right.ConstValue.Value_Char);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region UINT == FLOAT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.UINT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.FLOAT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_UInt ==
                                tok.Right.ConstValue.Value_Float);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region UINT == DOUBLE
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.UINT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.DOUBLE)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_UInt ==
                                tok.Right.ConstValue.Value_Double);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion

                        #region SHORT == INT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.SHORT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.INT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Short ==
                                tok.Right.ConstValue.Value_Int);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region SHORT == UINT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.SHORT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.UINT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Short ==
                                tok.Right.ConstValue.Value_UInt);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region SHORT == SHORT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.SHORT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.SHORT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Short ==
                                tok.Right.ConstValue.Value_Short);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region SHORT == USHORT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.SHORT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.USHORT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Short ==
                                tok.Right.ConstValue.Value_UShort);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region SHORT == LONG
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.SHORT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.LONG)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Short ==
                                tok.Right.ConstValue.Value_Long);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region SHORT == CHAR
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.SHORT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.CHAR)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Short ==
                                tok.Right.ConstValue.Value_Char);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region SHORT == FLOAT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.SHORT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.FLOAT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Short ==
                                tok.Right.ConstValue.Value_Float);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region SHORT == DOUBLE
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.SHORT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.DOUBLE)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Short ==
                                tok.Right.ConstValue.Value_Double);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion

                        #region USHORT == INT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.USHORT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.INT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_UShort ==
                                tok.Right.ConstValue.Value_Int);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region USHORT == UINT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.USHORT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.UINT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_UShort ==
                                tok.Right.ConstValue.Value_UInt);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region USHORT == SHORT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.USHORT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.SHORT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_UShort ==
                                tok.Right.ConstValue.Value_Short);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region USHORT == USHORT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.USHORT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.USHORT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_UShort ==
                                tok.Right.ConstValue.Value_UShort);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region USHORT == LONG
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.USHORT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.LONG)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_UShort ==
                                tok.Right.ConstValue.Value_Long);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region USHORT == CHAR
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.USHORT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.CHAR)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_UShort ==
                                tok.Right.ConstValue.Value_Char);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region USHORT == FLOAT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.USHORT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.FLOAT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_UShort ==
                                tok.Right.ConstValue.Value_Float);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region USHORT == DOUBLE
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.USHORT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.DOUBLE)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_UShort ==
                                tok.Right.ConstValue.Value_Double);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion

                        #region LONG == INT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.LONG &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.INT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Long ==
                                tok.Right.ConstValue.Value_Int);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region LONG == UINT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.LONG &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.UINT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Long ==
                                tok.Right.ConstValue.Value_UInt);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region LONG == SHORT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.LONG &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.SHORT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Long ==
                                tok.Right.ConstValue.Value_Short);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region LONG == USHORT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.LONG &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.USHORT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Long ==
                                tok.Right.ConstValue.Value_UShort);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region LONG == LONG
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.LONG &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.LONG)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Long ==
                                tok.Right.ConstValue.Value_Long);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region LONG == CHAR
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.LONG &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.CHAR)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Long ==
                                tok.Right.ConstValue.Value_Char);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region LONG == FLOAT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.LONG &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.FLOAT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Long ==
                                tok.Right.ConstValue.Value_Float);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region LONG == DOUBLE
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.LONG &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.DOUBLE)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Long ==
                                tok.Right.ConstValue.Value_Double);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion

                        #region CHAR == INT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.CHAR &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.INT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Char ==
                                tok.Right.ConstValue.Value_Int);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region CHAR == UINT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.CHAR &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.UINT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Char ==
                                tok.Right.ConstValue.Value_UInt);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region CHAR == SHORT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.CHAR &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.SHORT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Char ==
                                tok.Right.ConstValue.Value_Short);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region CHAR == USHORT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.CHAR &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.USHORT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Char ==
                                tok.Right.ConstValue.Value_UShort);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region CHAR == LONG
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.CHAR &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.LONG)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Char ==
                                tok.Right.ConstValue.Value_Long);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region CHAR == CHAR
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.CHAR &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.CHAR)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Char ==
                                tok.Right.ConstValue.Value_Char);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region CHAR == FLOAT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.CHAR &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.FLOAT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Char ==
                                tok.Right.ConstValue.Value_Float);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region CHAR == DOUBLE
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.CHAR &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.DOUBLE)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Char ==
                                tok.Right.ConstValue.Value_Double);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion

                        #region FLOAT == INT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.FLOAT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.INT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Float ==
                                tok.Right.ConstValue.Value_Int);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region FLOAT == UINT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.FLOAT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.UINT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Float ==
                                tok.Right.ConstValue.Value_UInt);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region FLOAT == SHORT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.FLOAT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.SHORT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Float ==
                                tok.Right.ConstValue.Value_Short);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region FLOAT == USHORT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.FLOAT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.USHORT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Float ==
                                tok.Right.ConstValue.Value_UShort);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region FLOAT == LONG
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.FLOAT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.LONG)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Float ==
                                tok.Right.ConstValue.Value_Long);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region FLOAT == CHAR
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.FLOAT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.CHAR)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Float ==
                                tok.Right.ConstValue.Value_Char);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region FLOAT == FLOAT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.FLOAT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.FLOAT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Float ==
                                tok.Right.ConstValue.Value_Float);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region FLOAT == DOUBLE
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.FLOAT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.DOUBLE)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Float ==
                                tok.Right.ConstValue.Value_Double);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion

                        #region DOUBLE == INT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.DOUBLE &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.INT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Double ==
                                tok.Right.ConstValue.Value_Int);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region DOUBLE == UINT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.DOUBLE &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.UINT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Double ==
                                tok.Right.ConstValue.Value_UInt);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region DOUBLE == SHORT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.DOUBLE &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.SHORT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Double ==
                                tok.Right.ConstValue.Value_Short);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region DOUBLE == USHORT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.DOUBLE &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.USHORT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Double ==
                                tok.Right.ConstValue.Value_UShort);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region DOUBLE == LONG
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.DOUBLE &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.LONG)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Double ==
                                tok.Right.ConstValue.Value_Long);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region DOUBLE == CHAR
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.DOUBLE &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.CHAR)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Double ==
                                tok.Right.ConstValue.Value_Char);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region DOUBLE == FLOAT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.DOUBLE &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.FLOAT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Double ==
                                tok.Right.ConstValue.Value_Float);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region DOUBLE == DOUBLE
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.DOUBLE &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.DOUBLE)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Double ==
                                tok.Right.ConstValue.Value_Double);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion

                        #region BOOL == BOOL
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.BOOL &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.BOOL)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Bool ==
                                tok.Right.ConstValue.Value_Bool);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region CHAR_POINTER == CHAR_POINTER
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.CHAR_POINTER &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.CHAR_POINTER)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_CharPointer ==
                                tok.Right.ConstValue.Value_CharPointer);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region ULONG == ULONG
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.ULONG &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.ULONG)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_ULong ==
                                tok.Right.ConstValue.Value_ULong);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion

                        else
                            throw new Exception($"EXPRESSION {tok.Left} == {tok.Right} cannot be optimized!");
                    }
                }
                #endregion
                #region NOT EQUAL
                else if (tok.Operator.Operator == OperatorToken.OperatorEnum.NotEqual)
                {
                    TryOptimizeExpressionToken(tok.Left);
                    TryOptimizeExpressionToken(tok.Right);
                    if (tok.Left.IsConstValue && tok.Right.IsConstValue)
                    {
                        #region INT != INT
                        if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.INT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.INT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Int !=
                                tok.Right.ConstValue.Value_Int);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region INT != UINT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.INT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.UINT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Int !=
                                tok.Right.ConstValue.Value_UInt);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region INT != SHORT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.INT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.SHORT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Int !=
                                tok.Right.ConstValue.Value_Short);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region INT != USHORT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.INT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.USHORT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Int !=
                                tok.Right.ConstValue.Value_UShort);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region INT != LONG
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.INT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.LONG)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Int !=
                                tok.Right.ConstValue.Value_Long);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region INT != CHAR
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.INT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.CHAR)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Int !=
                                tok.Right.ConstValue.Value_Char);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region INT != FLOAT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.INT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.FLOAT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Int !=
                                tok.Right.ConstValue.Value_Float);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region INT != DOUBLE
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.INT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.DOUBLE)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Int !=
                                tok.Right.ConstValue.Value_Double);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion

                        #region UINT != INT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.UINT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.INT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_UInt !=
                                tok.Right.ConstValue.Value_Int);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region UINT != UINT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.UINT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.UINT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_UInt !=
                                tok.Right.ConstValue.Value_UInt);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region UINT != SHORT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.UINT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.SHORT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_UInt !=
                                tok.Right.ConstValue.Value_Short);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region UINT != USHORT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.UINT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.USHORT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_UInt !=
                                tok.Right.ConstValue.Value_UShort);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region UINT != LONG
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.UINT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.LONG)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_UInt !=
                                tok.Right.ConstValue.Value_Long);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region UINT != CHAR
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.UINT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.CHAR)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_UInt !=
                                tok.Right.ConstValue.Value_Char);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region UINT != FLOAT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.UINT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.FLOAT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_UInt !=
                                tok.Right.ConstValue.Value_Float);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region UINT != DOUBLE
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.UINT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.DOUBLE)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_UInt !=
                                tok.Right.ConstValue.Value_Double);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion

                        #region SHORT != INT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.SHORT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.INT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Short !=
                                tok.Right.ConstValue.Value_Int);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region SHORT != UINT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.SHORT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.UINT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Short !=
                                tok.Right.ConstValue.Value_UInt);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region SHORT != SHORT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.SHORT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.SHORT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Short !=
                                tok.Right.ConstValue.Value_Short);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region SHORT != USHORT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.SHORT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.USHORT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Short !=
                                tok.Right.ConstValue.Value_UShort);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region SHORT != LONG
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.SHORT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.LONG)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Short !=
                                tok.Right.ConstValue.Value_Long);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region SHORT != CHAR
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.SHORT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.CHAR)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Short !=
                                tok.Right.ConstValue.Value_Char);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region SHORT != FLOAT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.SHORT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.FLOAT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Short !=
                                tok.Right.ConstValue.Value_Float);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region SHORT != DOUBLE
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.SHORT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.DOUBLE)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Short !=
                                tok.Right.ConstValue.Value_Double);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion

                        #region USHORT != INT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.USHORT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.INT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_UShort !=
                                tok.Right.ConstValue.Value_Int);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region USHORT != UINT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.USHORT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.UINT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_UShort !=
                                tok.Right.ConstValue.Value_UInt);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region USHORT != SHORT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.USHORT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.SHORT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_UShort !=
                                tok.Right.ConstValue.Value_Short);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region USHORT != USHORT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.USHORT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.USHORT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_UShort !=
                                tok.Right.ConstValue.Value_UShort);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region USHORT != LONG
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.USHORT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.LONG)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_UShort !=
                                tok.Right.ConstValue.Value_Long);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region USHORT != CHAR
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.USHORT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.CHAR)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_UShort !=
                                tok.Right.ConstValue.Value_Char);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region USHORT != FLOAT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.USHORT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.FLOAT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_UShort !=
                                tok.Right.ConstValue.Value_Float);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region USHORT != DOUBLE
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.USHORT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.DOUBLE)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_UShort !=
                                tok.Right.ConstValue.Value_Double);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion

                        #region LONG != INT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.LONG &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.INT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Long !=
                                tok.Right.ConstValue.Value_Int);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region LONG != UINT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.LONG &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.UINT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Long !=
                                tok.Right.ConstValue.Value_UInt);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region LONG != SHORT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.LONG &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.SHORT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Long !=
                                tok.Right.ConstValue.Value_Short);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region LONG != USHORT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.LONG &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.USHORT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Long !=
                                tok.Right.ConstValue.Value_UShort);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region LONG != LONG
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.LONG &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.LONG)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Long !=
                                tok.Right.ConstValue.Value_Long);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region LONG != CHAR
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.LONG &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.CHAR)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Long !=
                                tok.Right.ConstValue.Value_Char);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region LONG != FLOAT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.LONG &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.FLOAT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Long !=
                                tok.Right.ConstValue.Value_Float);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region LONG != DOUBLE
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.LONG &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.DOUBLE)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Long !=
                                tok.Right.ConstValue.Value_Double);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion

                        #region CHAR != INT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.CHAR &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.INT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Char !=
                                tok.Right.ConstValue.Value_Int);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region CHAR != UINT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.CHAR &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.UINT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Char !=
                                tok.Right.ConstValue.Value_UInt);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region CHAR != SHORT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.CHAR &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.SHORT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Char !=
                                tok.Right.ConstValue.Value_Short);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region CHAR != USHORT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.CHAR &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.USHORT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Char !=
                                tok.Right.ConstValue.Value_UShort);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region CHAR != LONG
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.CHAR &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.LONG)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Char !=
                                tok.Right.ConstValue.Value_Long);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region CHAR != CHAR
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.CHAR &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.CHAR)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Char !=
                                tok.Right.ConstValue.Value_Char);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region CHAR != FLOAT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.CHAR &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.FLOAT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Char !=
                                tok.Right.ConstValue.Value_Float);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region CHAR != DOUBLE
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.CHAR &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.DOUBLE)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Char !=
                                tok.Right.ConstValue.Value_Double);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion

                        #region FLOAT != INT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.FLOAT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.INT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Float !=
                                tok.Right.ConstValue.Value_Int);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region FLOAT != UINT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.FLOAT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.UINT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Float !=
                                tok.Right.ConstValue.Value_UInt);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region FLOAT != SHORT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.FLOAT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.SHORT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Float !=
                                tok.Right.ConstValue.Value_Short);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region FLOAT != USHORT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.FLOAT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.USHORT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Float !=
                                tok.Right.ConstValue.Value_UShort);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region FLOAT != LONG
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.FLOAT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.LONG)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Float !=
                                tok.Right.ConstValue.Value_Long);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region FLOAT != CHAR
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.FLOAT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.CHAR)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Float !=
                                tok.Right.ConstValue.Value_Char);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region FLOAT != FLOAT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.FLOAT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.FLOAT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Float !=
                                tok.Right.ConstValue.Value_Float);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region FLOAT != DOUBLE
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.FLOAT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.DOUBLE)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Float !=
                                tok.Right.ConstValue.Value_Double);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion

                        #region DOUBLE != INT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.DOUBLE &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.INT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Double !=
                                tok.Right.ConstValue.Value_Int);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region DOUBLE != UINT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.DOUBLE &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.UINT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Double !=
                                tok.Right.ConstValue.Value_UInt);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region DOUBLE != SHORT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.DOUBLE &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.SHORT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Double !=
                                tok.Right.ConstValue.Value_Short);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region DOUBLE != USHORT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.DOUBLE &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.USHORT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Double !=
                                tok.Right.ConstValue.Value_UShort);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region DOUBLE != LONG
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.DOUBLE &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.LONG)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Double !=
                                tok.Right.ConstValue.Value_Long);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region DOUBLE != CHAR
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.DOUBLE &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.CHAR)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Double !=
                                tok.Right.ConstValue.Value_Char);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region DOUBLE != FLOAT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.DOUBLE &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.FLOAT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Double !=
                                tok.Right.ConstValue.Value_Float);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region DOUBLE != DOUBLE
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.DOUBLE &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.DOUBLE)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Double !=
                                tok.Right.ConstValue.Value_Double);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion

                        #region BOOL != BOOL
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.BOOL &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.BOOL)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Bool !=
                                tok.Right.ConstValue.Value_Bool);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region CHAR_POINTER != CHAR_POINTER
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.CHAR_POINTER &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.CHAR_POINTER)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_CharPointer !=
                                tok.Right.ConstValue.Value_CharPointer);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region ULONG != ULONG
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.ULONG &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.ULONG)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_ULong !=
                                tok.Right.ConstValue.Value_ULong);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion

                        else
                            throw new Exception($"EXPRESSION {tok.Left} != {tok.Right} cannot be optimized!");
                    }
                }
                #endregion
                #region GREATER EQUAL
                else if (tok.Operator.Operator == OperatorToken.OperatorEnum.GreaterEqual)
                {
                    TryOptimizeExpressionToken(tok.Left);
                    TryOptimizeExpressionToken(tok.Right);
                    if (tok.Left.IsConstValue && tok.Right.IsConstValue)
                    {
                        #region INT >= INT
                        if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.INT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.INT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Int >=
                                tok.Right.ConstValue.Value_Int);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region INT >= UINT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.INT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.UINT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Int >=
                                tok.Right.ConstValue.Value_UInt);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region INT >= SHORT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.INT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.SHORT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Int >=
                                tok.Right.ConstValue.Value_Short);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region INT >= USHORT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.INT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.USHORT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Int >=
                                tok.Right.ConstValue.Value_UShort);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region INT >= LONG
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.INT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.LONG)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Int >=
                                tok.Right.ConstValue.Value_Long);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region INT >= CHAR
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.INT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.CHAR)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Int >=
                                tok.Right.ConstValue.Value_Char);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region INT >= FLOAT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.INT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.FLOAT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Int >=
                                tok.Right.ConstValue.Value_Float);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region INT >= DOUBLE
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.INT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.DOUBLE)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Int >=
                                tok.Right.ConstValue.Value_Double);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion

                        #region UINT >= INT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.UINT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.INT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_UInt >=
                                tok.Right.ConstValue.Value_Int);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region UINT >= UINT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.UINT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.UINT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_UInt >=
                                tok.Right.ConstValue.Value_UInt);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region UINT >= SHORT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.UINT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.SHORT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_UInt >=
                                tok.Right.ConstValue.Value_Short);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region UINT >= USHORT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.UINT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.USHORT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_UInt >=
                                tok.Right.ConstValue.Value_UShort);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region UINT >= LONG
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.UINT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.LONG)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_UInt >=
                                tok.Right.ConstValue.Value_Long);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region UINT >= CHAR
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.UINT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.CHAR)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_UInt >=
                                tok.Right.ConstValue.Value_Char);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region UINT >= FLOAT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.UINT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.FLOAT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_UInt >=
                                tok.Right.ConstValue.Value_Float);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region UINT >= DOUBLE
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.UINT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.DOUBLE)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_UInt >=
                                tok.Right.ConstValue.Value_Double);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion

                        #region SHORT >= INT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.SHORT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.INT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Short >=
                                tok.Right.ConstValue.Value_Int);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region SHORT >= UINT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.SHORT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.UINT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Short >=
                                tok.Right.ConstValue.Value_UInt);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region SHORT >= SHORT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.SHORT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.SHORT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Short >=
                                tok.Right.ConstValue.Value_Short);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region SHORT >= USHORT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.SHORT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.USHORT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Short >=
                                tok.Right.ConstValue.Value_UShort);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region SHORT >= LONG
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.SHORT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.LONG)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Short >=
                                tok.Right.ConstValue.Value_Long);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region SHORT >= CHAR
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.SHORT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.CHAR)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Short >=
                                tok.Right.ConstValue.Value_Char);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region SHORT >= FLOAT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.SHORT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.FLOAT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Short >=
                                tok.Right.ConstValue.Value_Float);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region SHORT >= DOUBLE
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.SHORT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.DOUBLE)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Short >=
                                tok.Right.ConstValue.Value_Double);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion

                        #region USHORT >= INT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.USHORT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.INT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_UShort >=
                                tok.Right.ConstValue.Value_Int);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region USHORT >= UINT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.USHORT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.UINT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_UShort >=
                                tok.Right.ConstValue.Value_UInt);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region USHORT >= SHORT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.USHORT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.SHORT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_UShort >=
                                tok.Right.ConstValue.Value_Short);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region USHORT >= USHORT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.USHORT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.USHORT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_UShort >=
                                tok.Right.ConstValue.Value_UShort);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region USHORT >= LONG
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.USHORT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.LONG)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_UShort >=
                                tok.Right.ConstValue.Value_Long);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region USHORT >= CHAR
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.USHORT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.CHAR)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_UShort >=
                                tok.Right.ConstValue.Value_Char);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region USHORT >= FLOAT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.USHORT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.FLOAT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_UShort >=
                                tok.Right.ConstValue.Value_Float);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region USHORT >= DOUBLE
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.USHORT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.DOUBLE)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_UShort >=
                                tok.Right.ConstValue.Value_Double);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion

                        #region LONG >= INT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.LONG &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.INT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Long >=
                                tok.Right.ConstValue.Value_Int);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region LONG >= UINT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.LONG &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.UINT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Long >=
                                tok.Right.ConstValue.Value_UInt);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region LONG >= SHORT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.LONG &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.SHORT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Long >=
                                tok.Right.ConstValue.Value_Short);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region LONG >= USHORT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.LONG &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.USHORT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Long >=
                                tok.Right.ConstValue.Value_UShort);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region LONG >= LONG
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.LONG &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.LONG)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Long >=
                                tok.Right.ConstValue.Value_Long);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region LONG >= CHAR
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.LONG &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.CHAR)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Long >=
                                tok.Right.ConstValue.Value_Char);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region LONG >= FLOAT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.LONG &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.FLOAT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Long >=
                                tok.Right.ConstValue.Value_Float);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region LONG >= DOUBLE
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.LONG &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.DOUBLE)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Long >=
                                tok.Right.ConstValue.Value_Double);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion

                        #region CHAR >= INT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.CHAR &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.INT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Char >=
                                tok.Right.ConstValue.Value_Int);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region CHAR >= UINT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.CHAR &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.UINT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Char >=
                                tok.Right.ConstValue.Value_UInt);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region CHAR >= SHORT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.CHAR &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.SHORT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Char >=
                                tok.Right.ConstValue.Value_Short);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region CHAR >= USHORT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.CHAR &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.USHORT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Char >=
                                tok.Right.ConstValue.Value_UShort);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region CHAR >= LONG
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.CHAR &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.LONG)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Char >=
                                tok.Right.ConstValue.Value_Long);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region CHAR >= CHAR
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.CHAR &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.CHAR)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Char >=
                                tok.Right.ConstValue.Value_Char);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region CHAR >= FLOAT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.CHAR &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.FLOAT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Char >=
                                tok.Right.ConstValue.Value_Float);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region CHAR >= DOUBLE
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.CHAR &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.DOUBLE)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Char >=
                                tok.Right.ConstValue.Value_Double);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion

                        #region FLOAT >= INT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.FLOAT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.INT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Float >=
                                tok.Right.ConstValue.Value_Int);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region FLOAT >= UINT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.FLOAT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.UINT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Float >=
                                tok.Right.ConstValue.Value_UInt);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region FLOAT >= SHORT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.FLOAT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.SHORT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Float >=
                                tok.Right.ConstValue.Value_Short);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region FLOAT >= USHORT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.FLOAT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.USHORT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Float >=
                                tok.Right.ConstValue.Value_UShort);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region FLOAT >= LONG
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.FLOAT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.LONG)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Float >=
                                tok.Right.ConstValue.Value_Long);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region FLOAT >= CHAR
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.FLOAT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.CHAR)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Float >=
                                tok.Right.ConstValue.Value_Char);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region FLOAT >= FLOAT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.FLOAT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.FLOAT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Float >=
                                tok.Right.ConstValue.Value_Float);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region FLOAT >= DOUBLE
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.FLOAT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.DOUBLE)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Float >=
                                tok.Right.ConstValue.Value_Double);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion

                        #region DOUBLE >= INT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.DOUBLE &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.INT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Double >=
                                tok.Right.ConstValue.Value_Int);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region DOUBLE >= UINT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.DOUBLE &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.UINT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Double >=
                                tok.Right.ConstValue.Value_UInt);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region DOUBLE >= SHORT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.DOUBLE &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.SHORT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Double >=
                                tok.Right.ConstValue.Value_Short);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region DOUBLE >= USHORT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.DOUBLE &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.USHORT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Double >=
                                tok.Right.ConstValue.Value_UShort);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region DOUBLE >= LONG
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.DOUBLE &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.LONG)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Double >=
                                tok.Right.ConstValue.Value_Long);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region DOUBLE >= CHAR
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.DOUBLE &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.CHAR)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Double >=
                                tok.Right.ConstValue.Value_Char);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region DOUBLE >= FLOAT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.DOUBLE &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.FLOAT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Double >=
                                tok.Right.ConstValue.Value_Float);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region DOUBLE >= DOUBLE
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.DOUBLE &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.DOUBLE)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Double >=
                                tok.Right.ConstValue.Value_Double);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion

                        #region ULONG >= ULONG
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.ULONG &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.ULONG)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_ULong >=
                                tok.Right.ConstValue.Value_ULong);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion

                        else
                            throw new Exception($"EXPRESSION {tok.Left} >= {tok.Right} cannot be optimized!");
                    }
                }
                #endregion
                #region LESS EQUALS
                else if (tok.Operator.Operator == OperatorToken.OperatorEnum.LessEqual)
                {
                    TryOptimizeExpressionToken(tok.Left);
                    TryOptimizeExpressionToken(tok.Right);
                    if (tok.Left.IsConstValue && tok.Right.IsConstValue)
                    {
                        #region INT <= INT
                        if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.INT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.INT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Int <=
                                tok.Right.ConstValue.Value_Int);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region INT <= UINT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.INT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.UINT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Int <=
                                tok.Right.ConstValue.Value_UInt);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region INT <= SHORT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.INT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.SHORT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Int <=
                                tok.Right.ConstValue.Value_Short);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region INT <= USHORT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.INT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.USHORT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Int <=
                                tok.Right.ConstValue.Value_UShort);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region INT <= LONG
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.INT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.LONG)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Int <=
                                tok.Right.ConstValue.Value_Long);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region INT <= CHAR
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.INT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.CHAR)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Int <=
                                tok.Right.ConstValue.Value_Char);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region INT <= FLOAT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.INT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.FLOAT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Int <=
                                tok.Right.ConstValue.Value_Float);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region INT <= DOUBLE
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.INT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.DOUBLE)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Int <=
                                tok.Right.ConstValue.Value_Double);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion

                        #region UINT <= INT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.UINT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.INT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_UInt <=
                                tok.Right.ConstValue.Value_Int);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region UINT <= UINT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.UINT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.UINT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_UInt <=
                                tok.Right.ConstValue.Value_UInt);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region UINT <= SHORT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.UINT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.SHORT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_UInt <=
                                tok.Right.ConstValue.Value_Short);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region UINT <= USHORT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.UINT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.USHORT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_UInt <=
                                tok.Right.ConstValue.Value_UShort);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region UINT <= LONG
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.UINT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.LONG)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_UInt <=
                                tok.Right.ConstValue.Value_Long);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region UINT <= CHAR
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.UINT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.CHAR)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_UInt <=
                                tok.Right.ConstValue.Value_Char);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region UINT <= FLOAT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.UINT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.FLOAT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_UInt <=
                                tok.Right.ConstValue.Value_Float);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region UINT <= DOUBLE
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.UINT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.DOUBLE)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_UInt <=
                                tok.Right.ConstValue.Value_Double);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion

                        #region SHORT <= INT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.SHORT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.INT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Short <=
                                tok.Right.ConstValue.Value_Int);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region SHORT <= UINT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.SHORT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.UINT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Short <=
                                tok.Right.ConstValue.Value_UInt);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region SHORT <= SHORT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.SHORT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.SHORT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Short <=
                                tok.Right.ConstValue.Value_Short);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region SHORT <= USHORT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.SHORT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.USHORT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Short <=
                                tok.Right.ConstValue.Value_UShort);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region SHORT <= LONG
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.SHORT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.LONG)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Short <=
                                tok.Right.ConstValue.Value_Long);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region SHORT <= CHAR
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.SHORT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.CHAR)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Short <=
                                tok.Right.ConstValue.Value_Char);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region SHORT <= FLOAT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.SHORT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.FLOAT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Short <=
                                tok.Right.ConstValue.Value_Float);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region SHORT <= DOUBLE
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.SHORT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.DOUBLE)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Short <=
                                tok.Right.ConstValue.Value_Double);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion

                        #region USHORT <= INT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.USHORT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.INT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_UShort <=
                                tok.Right.ConstValue.Value_Int);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region USHORT <= UINT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.USHORT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.UINT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_UShort <=
                                tok.Right.ConstValue.Value_UInt);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region USHORT <= SHORT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.USHORT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.SHORT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_UShort <=
                                tok.Right.ConstValue.Value_Short);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region USHORT <= USHORT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.USHORT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.USHORT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_UShort <=
                                tok.Right.ConstValue.Value_UShort);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region USHORT <= LONG
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.USHORT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.LONG)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_UShort <=
                                tok.Right.ConstValue.Value_Long);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region USHORT <= CHAR
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.USHORT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.CHAR)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_UShort <=
                                tok.Right.ConstValue.Value_Char);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region USHORT <= FLOAT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.USHORT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.FLOAT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_UShort <=
                                tok.Right.ConstValue.Value_Float);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region USHORT <= DOUBLE
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.USHORT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.DOUBLE)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_UShort <=
                                tok.Right.ConstValue.Value_Double);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion

                        #region LONG <= INT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.LONG &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.INT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Long <=
                                tok.Right.ConstValue.Value_Int);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region LONG <= UINT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.LONG &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.UINT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Long <=
                                tok.Right.ConstValue.Value_UInt);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region LONG <= SHORT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.LONG &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.SHORT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Long <=
                                tok.Right.ConstValue.Value_Short);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region LONG <= USHORT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.LONG &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.USHORT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Long <=
                                tok.Right.ConstValue.Value_UShort);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region LONG <= LONG
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.LONG &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.LONG)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Long <=
                                tok.Right.ConstValue.Value_Long);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region LONG <= CHAR
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.LONG &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.CHAR)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Long <=
                                tok.Right.ConstValue.Value_Char);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region LONG <= FLOAT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.LONG &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.FLOAT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Long <=
                                tok.Right.ConstValue.Value_Float);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region LONG <= DOUBLE
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.LONG &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.DOUBLE)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Long <=
                                tok.Right.ConstValue.Value_Double);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion

                        #region CHAR <= INT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.CHAR &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.INT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Char <=
                                tok.Right.ConstValue.Value_Int);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region CHAR <= UINT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.CHAR &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.UINT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Char <=
                                tok.Right.ConstValue.Value_UInt);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region CHAR <= SHORT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.CHAR &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.SHORT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Char <=
                                tok.Right.ConstValue.Value_Short);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region CHAR <= USHORT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.CHAR &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.USHORT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Char <=
                                tok.Right.ConstValue.Value_UShort);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region CHAR <= LONG
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.CHAR &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.LONG)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Char <=
                                tok.Right.ConstValue.Value_Long);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region CHAR <= CHAR
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.CHAR &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.CHAR)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Char <=
                                tok.Right.ConstValue.Value_Char);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region CHAR <= FLOAT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.CHAR &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.FLOAT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Char <=
                                tok.Right.ConstValue.Value_Float);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region CHAR <= DOUBLE
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.CHAR &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.DOUBLE)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Char <=
                                tok.Right.ConstValue.Value_Double);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion

                        #region FLOAT <= INT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.FLOAT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.INT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Float <=
                                tok.Right.ConstValue.Value_Int);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region FLOAT <= UINT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.FLOAT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.UINT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Float <=
                                tok.Right.ConstValue.Value_UInt);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region FLOAT <= SHORT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.FLOAT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.SHORT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Float <=
                                tok.Right.ConstValue.Value_Short);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region FLOAT <= USHORT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.FLOAT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.USHORT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Float <=
                                tok.Right.ConstValue.Value_UShort);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region FLOAT <= LONG
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.FLOAT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.LONG)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Float <=
                                tok.Right.ConstValue.Value_Long);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region FLOAT <= CHAR
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.FLOAT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.CHAR)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Float <=
                                tok.Right.ConstValue.Value_Char);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region FLOAT <= FLOAT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.FLOAT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.FLOAT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Float <=
                                tok.Right.ConstValue.Value_Float);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region FLOAT <= DOUBLE
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.FLOAT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.DOUBLE)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Float <=
                                tok.Right.ConstValue.Value_Double);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion

                        #region DOUBLE <= INT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.DOUBLE &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.INT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Double <=
                                tok.Right.ConstValue.Value_Int);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region DOUBLE <= UINT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.DOUBLE &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.UINT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Double <=
                                tok.Right.ConstValue.Value_UInt);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region DOUBLE <= SHORT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.DOUBLE &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.SHORT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Double <=
                                tok.Right.ConstValue.Value_Short);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region DOUBLE <= USHORT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.DOUBLE &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.USHORT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Double <=
                                tok.Right.ConstValue.Value_UShort);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region DOUBLE <= LONG
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.DOUBLE &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.LONG)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Double <=
                                tok.Right.ConstValue.Value_Long);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region DOUBLE <= CHAR
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.DOUBLE &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.CHAR)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Double <=
                                tok.Right.ConstValue.Value_Char);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region DOUBLE <= FLOAT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.DOUBLE &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.FLOAT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Double <=
                                tok.Right.ConstValue.Value_Float);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region DOUBLE <= DOUBLE
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.DOUBLE &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.DOUBLE)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Double <=
                                tok.Right.ConstValue.Value_Double);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion

                        #region ULONG <= ULONG
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.ULONG &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.ULONG)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_ULong <=
                                tok.Right.ConstValue.Value_ULong);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion

                        else
                            throw new Exception($"EXPRESSION {tok.Left} <= {tok.Right} cannot be optimized!");
                    }
                }
                #endregion
                #region GREATER
                else if (tok.Operator.Operator == OperatorToken.OperatorEnum.Greater)
                {
                    TryOptimizeExpressionToken(tok.Left);
                    TryOptimizeExpressionToken(tok.Right);
                    if (tok.Left.IsConstValue && tok.Right.IsConstValue)
                    {
                        #region INT > INT
                        if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.INT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.INT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Int >
                                tok.Right.ConstValue.Value_Int);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region INT > UINT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.INT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.UINT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Int >
                                tok.Right.ConstValue.Value_UInt);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region INT > SHORT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.INT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.SHORT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Int >
                                tok.Right.ConstValue.Value_Short);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region INT > USHORT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.INT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.USHORT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Int >
                                tok.Right.ConstValue.Value_UShort);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region INT > LONG
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.INT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.LONG)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Int >
                                tok.Right.ConstValue.Value_Long);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region INT > CHAR
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.INT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.CHAR)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Int >
                                tok.Right.ConstValue.Value_Char);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region INT > FLOAT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.INT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.FLOAT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Int >
                                tok.Right.ConstValue.Value_Float);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region INT > DOUBLE
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.INT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.DOUBLE)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Int >
                                tok.Right.ConstValue.Value_Double);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion

                        #region UINT > INT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.UINT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.INT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_UInt >
                                tok.Right.ConstValue.Value_Int);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region UINT > UINT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.UINT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.UINT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_UInt >
                                tok.Right.ConstValue.Value_UInt);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region UINT > SHORT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.UINT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.SHORT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_UInt >
                                tok.Right.ConstValue.Value_Short);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region UINT > USHORT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.UINT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.USHORT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_UInt >
                                tok.Right.ConstValue.Value_UShort);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region UINT > LONG
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.UINT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.LONG)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_UInt >
                                tok.Right.ConstValue.Value_Long);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region UINT > CHAR
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.UINT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.CHAR)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_UInt >
                                tok.Right.ConstValue.Value_Char);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region UINT > FLOAT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.UINT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.FLOAT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_UInt >
                                tok.Right.ConstValue.Value_Float);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region UINT > DOUBLE
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.UINT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.DOUBLE)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_UInt >
                                tok.Right.ConstValue.Value_Double);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion

                        #region SHORT > INT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.SHORT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.INT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Short >
                                tok.Right.ConstValue.Value_Int);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region SHORT > UINT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.SHORT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.UINT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Short >
                                tok.Right.ConstValue.Value_UInt);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region SHORT > SHORT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.SHORT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.SHORT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Short >
                                tok.Right.ConstValue.Value_Short);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region SHORT > USHORT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.SHORT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.USHORT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Short >
                                tok.Right.ConstValue.Value_UShort);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region SHORT > LONG
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.SHORT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.LONG)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Short >
                                tok.Right.ConstValue.Value_Long);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region SHORT > CHAR
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.SHORT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.CHAR)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Short >
                                tok.Right.ConstValue.Value_Char);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region SHORT > FLOAT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.SHORT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.FLOAT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Short >
                                tok.Right.ConstValue.Value_Float);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region SHORT > DOUBLE
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.SHORT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.DOUBLE)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Short >
                                tok.Right.ConstValue.Value_Double);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion

                        #region USHORT > INT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.USHORT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.INT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_UShort >
                                tok.Right.ConstValue.Value_Int);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region USHORT > UINT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.USHORT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.UINT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_UShort >
                                tok.Right.ConstValue.Value_UInt);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region USHORT > SHORT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.USHORT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.SHORT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_UShort >
                                tok.Right.ConstValue.Value_Short);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region USHORT > USHORT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.USHORT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.USHORT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_UShort >
                                tok.Right.ConstValue.Value_UShort);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region USHORT > LONG
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.USHORT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.LONG)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_UShort >
                                tok.Right.ConstValue.Value_Long);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region USHORT > CHAR
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.USHORT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.CHAR)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_UShort >
                                tok.Right.ConstValue.Value_Char);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region USHORT > FLOAT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.USHORT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.FLOAT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_UShort >
                                tok.Right.ConstValue.Value_Float);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region USHORT > DOUBLE
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.USHORT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.DOUBLE)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_UShort >
                                tok.Right.ConstValue.Value_Double);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion

                        #region LONG > INT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.LONG &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.INT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Long >
                                tok.Right.ConstValue.Value_Int);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region LONG > UINT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.LONG &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.UINT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Long >
                                tok.Right.ConstValue.Value_UInt);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region LONG > SHORT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.LONG &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.SHORT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Long >
                                tok.Right.ConstValue.Value_Short);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region LONG > USHORT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.LONG &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.USHORT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Long >
                                tok.Right.ConstValue.Value_UShort);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region LONG > LONG
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.LONG &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.LONG)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Long >
                                tok.Right.ConstValue.Value_Long);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region LONG > CHAR
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.LONG &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.CHAR)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Long >
                                tok.Right.ConstValue.Value_Char);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region LONG > FLOAT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.LONG &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.FLOAT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Long >
                                tok.Right.ConstValue.Value_Float);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region LONG > DOUBLE
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.LONG &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.DOUBLE)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Long >
                                tok.Right.ConstValue.Value_Double);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion

                        #region CHAR > INT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.CHAR &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.INT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Char >
                                tok.Right.ConstValue.Value_Int);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region CHAR > UINT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.CHAR &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.UINT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Char >
                                tok.Right.ConstValue.Value_UInt);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region CHAR > SHORT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.CHAR &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.SHORT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Char >
                                tok.Right.ConstValue.Value_Short);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region CHAR > USHORT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.CHAR &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.USHORT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Char >
                                tok.Right.ConstValue.Value_UShort);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region CHAR > LONG
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.CHAR &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.LONG)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Char >
                                tok.Right.ConstValue.Value_Long);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region CHAR > CHAR
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.CHAR &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.CHAR)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Char >
                                tok.Right.ConstValue.Value_Char);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region CHAR > FLOAT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.CHAR &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.FLOAT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Char >
                                tok.Right.ConstValue.Value_Float);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region CHAR > DOUBLE
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.CHAR &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.DOUBLE)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Char >
                                tok.Right.ConstValue.Value_Double);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion

                        #region FLOAT > INT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.FLOAT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.INT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Float >
                                tok.Right.ConstValue.Value_Int);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region FLOAT > UINT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.FLOAT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.UINT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Float >
                                tok.Right.ConstValue.Value_UInt);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region FLOAT > SHORT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.FLOAT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.SHORT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Float >
                                tok.Right.ConstValue.Value_Short);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region FLOAT > USHORT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.FLOAT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.USHORT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Float >
                                tok.Right.ConstValue.Value_UShort);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region FLOAT > LONG
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.FLOAT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.LONG)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Float >
                                tok.Right.ConstValue.Value_Long);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region FLOAT > CHAR
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.FLOAT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.CHAR)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Float >
                                tok.Right.ConstValue.Value_Char);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region FLOAT > FLOAT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.FLOAT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.FLOAT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Float >
                                tok.Right.ConstValue.Value_Float);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region FLOAT > DOUBLE
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.FLOAT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.DOUBLE)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Float >
                                tok.Right.ConstValue.Value_Double);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion

                        #region DOUBLE > INT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.DOUBLE &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.INT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Double >
                                tok.Right.ConstValue.Value_Int);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region DOUBLE > UINT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.DOUBLE &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.UINT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Double >
                                tok.Right.ConstValue.Value_UInt);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region DOUBLE > SHORT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.DOUBLE &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.SHORT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Double >
                                tok.Right.ConstValue.Value_Short);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region DOUBLE > USHORT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.DOUBLE &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.USHORT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Double >
                                tok.Right.ConstValue.Value_UShort);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region DOUBLE > LONG
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.DOUBLE &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.LONG)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Double >
                                tok.Right.ConstValue.Value_Long);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region DOUBLE > CHAR
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.DOUBLE &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.CHAR)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Double >
                                tok.Right.ConstValue.Value_Char);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region DOUBLE > FLOAT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.DOUBLE &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.FLOAT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Double >
                                tok.Right.ConstValue.Value_Float);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region DOUBLE > DOUBLE
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.DOUBLE &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.DOUBLE)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Double >
                                tok.Right.ConstValue.Value_Double);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion

                        #region ULONG > ULONG
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.ULONG &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.ULONG)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_ULong >
                                tok.Right.ConstValue.Value_ULong);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion

                        else
                            throw new Exception($"EXPRESSION {tok.Left} > {tok.Right} cannot be optimized!");
                    }
                }
                #endregion
                #region LESS
                else if (tok.Operator.Operator == OperatorToken.OperatorEnum.Less)
                {
                    TryOptimizeExpressionToken(tok.Left);
                    TryOptimizeExpressionToken(tok.Right);
                    if (tok.Left.IsConstValue && tok.Right.IsConstValue)
                    {
                        #region INT < INT
                        if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.INT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.INT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Int <
                                tok.Right.ConstValue.Value_Int);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region INT < UINT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.INT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.UINT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Int <
                                tok.Right.ConstValue.Value_UInt);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region INT < SHORT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.INT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.SHORT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Int <
                                tok.Right.ConstValue.Value_Short);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region INT < USHORT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.INT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.USHORT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Int <
                                tok.Right.ConstValue.Value_UShort);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region INT < LONG
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.INT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.LONG)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Int <
                                tok.Right.ConstValue.Value_Long);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region INT < CHAR
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.INT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.CHAR)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Int <
                                tok.Right.ConstValue.Value_Char);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region INT < FLOAT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.INT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.FLOAT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Int <
                                tok.Right.ConstValue.Value_Float);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region INT < DOUBLE
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.INT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.DOUBLE)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Int <
                                tok.Right.ConstValue.Value_Double);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion

                        #region UINT < INT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.UINT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.INT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_UInt <
                                tok.Right.ConstValue.Value_Int);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region UINT < UINT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.UINT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.UINT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_UInt <
                                tok.Right.ConstValue.Value_UInt);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region UINT < SHORT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.UINT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.SHORT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_UInt <
                                tok.Right.ConstValue.Value_Short);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region UINT < USHORT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.UINT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.USHORT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_UInt <
                                tok.Right.ConstValue.Value_UShort);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region UINT < LONG
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.UINT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.LONG)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_UInt <
                                tok.Right.ConstValue.Value_Long);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region UINT < CHAR
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.UINT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.CHAR)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_UInt <
                                tok.Right.ConstValue.Value_Char);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region UINT < FLOAT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.UINT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.FLOAT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_UInt <
                                tok.Right.ConstValue.Value_Float);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region UINT < DOUBLE
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.UINT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.DOUBLE)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_UInt <
                                tok.Right.ConstValue.Value_Double);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion

                        #region SHORT < INT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.SHORT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.INT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Short <
                                tok.Right.ConstValue.Value_Int);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region SHORT < UINT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.SHORT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.UINT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Short <
                                tok.Right.ConstValue.Value_UInt);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region SHORT < SHORT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.SHORT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.SHORT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Short <
                                tok.Right.ConstValue.Value_Short);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region SHORT < USHORT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.SHORT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.USHORT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Short <
                                tok.Right.ConstValue.Value_UShort);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region SHORT < LONG
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.SHORT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.LONG)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Short <
                                tok.Right.ConstValue.Value_Long);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region SHORT < CHAR
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.SHORT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.CHAR)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Short <
                                tok.Right.ConstValue.Value_Char);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region SHORT < FLOAT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.SHORT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.FLOAT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Short <
                                tok.Right.ConstValue.Value_Float);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region SHORT < DOUBLE
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.SHORT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.DOUBLE)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Short <
                                tok.Right.ConstValue.Value_Double);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion

                        #region USHORT < INT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.USHORT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.INT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_UShort <
                                tok.Right.ConstValue.Value_Int);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region USHORT < UINT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.USHORT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.UINT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_UShort <
                                tok.Right.ConstValue.Value_UInt);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region USHORT < SHORT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.USHORT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.SHORT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_UShort <
                                tok.Right.ConstValue.Value_Short);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region USHORT < USHORT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.USHORT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.USHORT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_UShort <
                                tok.Right.ConstValue.Value_UShort);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region USHORT < LONG
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.USHORT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.LONG)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_UShort <
                                tok.Right.ConstValue.Value_Long);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region USHORT < CHAR
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.USHORT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.CHAR)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_UShort <
                                tok.Right.ConstValue.Value_Char);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region USHORT < FLOAT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.USHORT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.FLOAT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_UShort <
                                tok.Right.ConstValue.Value_Float);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region USHORT < DOUBLE
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.USHORT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.DOUBLE)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_UShort <
                                tok.Right.ConstValue.Value_Double);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion

                        #region LONG < INT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.LONG &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.INT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Long <
                                tok.Right.ConstValue.Value_Int);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region LONG < UINT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.LONG &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.UINT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Long <
                                tok.Right.ConstValue.Value_UInt);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region LONG < SHORT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.LONG &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.SHORT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Long <
                                tok.Right.ConstValue.Value_Short);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region LONG < USHORT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.LONG &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.USHORT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Long <
                                tok.Right.ConstValue.Value_UShort);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region LONG < LONG
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.LONG &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.LONG)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Long <
                                tok.Right.ConstValue.Value_Long);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region LONG < CHAR
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.LONG &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.CHAR)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Long <
                                tok.Right.ConstValue.Value_Char);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region LONG < FLOAT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.LONG &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.FLOAT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Long <
                                tok.Right.ConstValue.Value_Float);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region LONG < DOUBLE
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.LONG &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.DOUBLE)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Long <
                                tok.Right.ConstValue.Value_Double);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion

                        #region CHAR < INT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.CHAR &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.INT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Char <
                                tok.Right.ConstValue.Value_Int);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region CHAR < UINT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.CHAR &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.UINT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Char <
                                tok.Right.ConstValue.Value_UInt);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region CHAR < SHORT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.CHAR &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.SHORT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Char <
                                tok.Right.ConstValue.Value_Short);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region CHAR < USHORT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.CHAR &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.USHORT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Char <
                                tok.Right.ConstValue.Value_UShort);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region CHAR < LONG
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.CHAR &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.LONG)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Char <
                                tok.Right.ConstValue.Value_Long);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region CHAR < CHAR
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.CHAR &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.CHAR)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Char <
                                tok.Right.ConstValue.Value_Char);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region CHAR < FLOAT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.CHAR &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.FLOAT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Char <
                                tok.Right.ConstValue.Value_Float);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region CHAR < DOUBLE
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.CHAR &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.DOUBLE)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Char <
                                tok.Right.ConstValue.Value_Double);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion

                        #region FLOAT < INT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.FLOAT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.INT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Float <
                                tok.Right.ConstValue.Value_Int);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region FLOAT < UINT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.FLOAT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.UINT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Float <
                                tok.Right.ConstValue.Value_UInt);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region FLOAT < SHORT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.FLOAT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.SHORT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Float <
                                tok.Right.ConstValue.Value_Short);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region FLOAT < USHORT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.FLOAT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.USHORT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Float <
                                tok.Right.ConstValue.Value_UShort);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region FLOAT < LONG
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.FLOAT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.LONG)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Float <
                                tok.Right.ConstValue.Value_Long);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region FLOAT < CHAR
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.FLOAT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.CHAR)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Float <
                                tok.Right.ConstValue.Value_Char);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region FLOAT < FLOAT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.FLOAT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.FLOAT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Float <
                                tok.Right.ConstValue.Value_Float);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region FLOAT < DOUBLE
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.FLOAT &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.DOUBLE)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Float <
                                tok.Right.ConstValue.Value_Double);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion

                        #region DOUBLE < INT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.DOUBLE &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.INT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Double <
                                tok.Right.ConstValue.Value_Int);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region DOUBLE < UINT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.DOUBLE &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.UINT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Double <
                                tok.Right.ConstValue.Value_UInt);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region DOUBLE < SHORT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.DOUBLE &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.SHORT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Double <
                                tok.Right.ConstValue.Value_Short);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region DOUBLE < USHORT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.DOUBLE &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.USHORT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Double <
                                tok.Right.ConstValue.Value_UShort);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region DOUBLE < LONG
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.DOUBLE &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.LONG)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Double <
                                tok.Right.ConstValue.Value_Long);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region DOUBLE < CHAR
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.DOUBLE &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.CHAR)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Double <
                                tok.Right.ConstValue.Value_Char);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region DOUBLE < FLOAT
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.DOUBLE &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.FLOAT)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Double <
                                tok.Right.ConstValue.Value_Float);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion
                        #region DOUBLE < DOUBLE
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.DOUBLE &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.DOUBLE)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_Double <
                                tok.Right.ConstValue.Value_Double);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion

                        #region ULONG < ULONG
                        else if (tok.Left.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.ULONG &&
                            tok.Right.ConstValue.ValueType == BasicValueToken.BasicValueTypeEnum.ULONG)
                        {
                            tok.IsConstValue = true;
                            tok.ConstValue = new BasicValueToken(
                                tok.Left.ConstValue.Value_ULong <
                                tok.Right.ConstValue.Value_ULong);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion

                        else
                            throw new Exception($"EXPRESSION {tok.Left} < {tok.Right} cannot be optimized!");
                    }
                }
                #endregion


            }

            return false;
        }
    }
}
