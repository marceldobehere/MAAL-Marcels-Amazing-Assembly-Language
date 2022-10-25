using System;

namespace MAAL.Parsing
{
    internal static class ParserHelpers
    {
        public static bool TryCast(ExpressionToken parentTok, TypeToken toType, BasicValueToken val)
        {
            string toStr = toType.ToPureString();
            //Console.WriteLine($"Trying to cast {BasicValueToken.TypeEnumToString[val.ValueType]} to {toStr}");


            #region TO INT
            if (toStr.Equals("int"))
            {
                if (val.ValueType == BasicValueToken.BasicValueTypeEnum.INT)
                {
                    parentTok.IsConstValue = true;
                    parentTok.ConstValue = new BasicValueToken((int)val.Value_Int);
                    return true;
                }
                else if (val.ValueType == BasicValueToken.BasicValueTypeEnum.LONG)
                {
                    parentTok.IsConstValue = true;
                    parentTok.ConstValue = new BasicValueToken((int)val.Value_Long);
                    return true;
                }
                else if (val.ValueType == BasicValueToken.BasicValueTypeEnum.FLOAT)
                {
                    parentTok.IsConstValue = true;
                    parentTok.ConstValue = new BasicValueToken((int)val.Value_Float);
                    return true;
                }
                else if (val.ValueType == BasicValueToken.BasicValueTypeEnum.CHAR)
                {
                    parentTok.IsConstValue = true;
                    parentTok.ConstValue = new BasicValueToken((int)val.Value_Char);
                    return true;
                }
                else if (val.ValueType == BasicValueToken.BasicValueTypeEnum.BOOL)
                {
                    throw new Exception("Trying to cast BOOL to INT!");
                }
                else if (val.ValueType == BasicValueToken.BasicValueTypeEnum.CHAR_POINTER)
                {
                    throw new Exception("Trying to cast CHAR* to INT!");
                }
            }
            #endregion
            #region TO LONG
            if (toStr.Equals("long"))
            {
                if (val.ValueType == BasicValueToken.BasicValueTypeEnum.INT)
                {
                    parentTok.IsConstValue = true;
                    parentTok.ConstValue = new BasicValueToken((long)val.Value_Int);
                    return true;
                }
                else if (val.ValueType == BasicValueToken.BasicValueTypeEnum.LONG)
                {
                    parentTok.IsConstValue = true;
                    parentTok.ConstValue = new BasicValueToken((long)val.Value_Long);
                    return true;
                }
                else if (val.ValueType == BasicValueToken.BasicValueTypeEnum.FLOAT)
                {
                    parentTok.IsConstValue = true;
                    parentTok.ConstValue = new BasicValueToken((long)val.Value_Float);
                    return true;
                }
                else if (val.ValueType == BasicValueToken.BasicValueTypeEnum.CHAR)
                {
                    parentTok.IsConstValue = true;
                    parentTok.ConstValue = new BasicValueToken((long)val.Value_Char);
                    return true;
                }
                else if (val.ValueType == BasicValueToken.BasicValueTypeEnum.BOOL)
                {
                    throw new Exception("Trying to cast BOOL to LONG!");
                }
                else if (val.ValueType == BasicValueToken.BasicValueTypeEnum.CHAR_POINTER)
                {
                    throw new Exception("Trying to cast CHAR* to LONG!");
                }
            }
            #endregion
            #region TO CHAR
            if (toStr.Equals("char"))
            {
                if (val.ValueType == BasicValueToken.BasicValueTypeEnum.INT)
                {
                    parentTok.IsConstValue = true;
                    parentTok.ConstValue = new BasicValueToken((char)val.Value_Int);
                    return true;
                }
                else if (val.ValueType == BasicValueToken.BasicValueTypeEnum.LONG)
                {
                    parentTok.IsConstValue = true;
                    parentTok.ConstValue = new BasicValueToken((char)val.Value_Long);
                    return true;
                }
                else if (val.ValueType == BasicValueToken.BasicValueTypeEnum.FLOAT)
                {
                    parentTok.IsConstValue = true;
                    parentTok.ConstValue = new BasicValueToken((char)val.Value_Float);
                    return true;
                }
                else if (val.ValueType == BasicValueToken.BasicValueTypeEnum.CHAR)
                {
                    parentTok.IsConstValue = true;
                    parentTok.ConstValue = new BasicValueToken((char)val.Value_Char);
                    return true;
                }
                else if (val.ValueType == BasicValueToken.BasicValueTypeEnum.BOOL)
                {
                    throw new Exception("Trying to cast BOOL to CHAR!");
                }
                else if (val.ValueType == BasicValueToken.BasicValueTypeEnum.CHAR_POINTER)
                {
                    throw new Exception("Trying to cast CHAR* to CHAR!");
                }
            }
            #endregion
            #region TO FLOAT
            if (toStr.Equals("float"))
            {
                if (val.ValueType == BasicValueToken.BasicValueTypeEnum.INT)
                {
                    parentTok.IsConstValue = true;
                    parentTok.ConstValue = new BasicValueToken((float)val.Value_Int);
                    return true;
                }
                else if (val.ValueType == BasicValueToken.BasicValueTypeEnum.LONG)
                {
                    parentTok.IsConstValue = true;
                    parentTok.ConstValue = new BasicValueToken((float)val.Value_Long);
                    return true;
                }
                else if (val.ValueType == BasicValueToken.BasicValueTypeEnum.FLOAT)
                {
                    parentTok.IsConstValue = true;
                    parentTok.ConstValue = new BasicValueToken((float)val.Value_Float);
                    return true;
                }
                else if (val.ValueType == BasicValueToken.BasicValueTypeEnum.CHAR)
                {
                    parentTok.IsConstValue = true;
                    parentTok.ConstValue = new BasicValueToken((float)val.Value_Char);
                    return true;
                }
                else if (val.ValueType == BasicValueToken.BasicValueTypeEnum.BOOL)
                {
                    throw new Exception("Trying to cast BOOL to FLOAT!");
                }
                else if (val.ValueType == BasicValueToken.BasicValueTypeEnum.CHAR_POINTER)
                {
                    throw new Exception("Trying to cast CHAR* to FLOAT!");
                }
            }
            #endregion
            #region TO BOOL
            if (toStr.Equals("bool"))
            {
                if (val.ValueType == BasicValueToken.BasicValueTypeEnum.INT)
                {
                    throw new Exception("Trying to cast INT to BOOL!");
                }
                else if (val.ValueType == BasicValueToken.BasicValueTypeEnum.LONG)
                {
                    throw new Exception("Trying to cast LONG to BOOL!");
                }
                else if (val.ValueType == BasicValueToken.BasicValueTypeEnum.FLOAT)
                {
                    throw new Exception("Trying to cast FLOAT to BOOL!");
                }
                else if (val.ValueType == BasicValueToken.BasicValueTypeEnum.CHAR)
                {
                    throw new Exception("Trying to cast CHAR to BOOL!");
                }
                else if (val.ValueType == BasicValueToken.BasicValueTypeEnum.BOOL)
                {
                    parentTok.IsConstValue = true;
                    parentTok.ConstValue = new BasicValueToken(val.Value_Bool);
                    return true;
                }
                else if (val.ValueType == BasicValueToken.BasicValueTypeEnum.CHAR_POINTER)
                {
                    throw new Exception("Trying to cast CHAR* to BOOL!");
                }
            }
            #endregion
            #region TO CHAR*
            if (toStr.Equals("char*"))
            {
                if (val.ValueType == BasicValueToken.BasicValueTypeEnum.INT)
                {
                    throw new Exception("Trying to cast INT to CHAR*!");
                }
                else if (val.ValueType == BasicValueToken.BasicValueTypeEnum.LONG)
                {
                    throw new Exception("Trying to cast LONG to CHAR*!");
                }
                else if (val.ValueType == BasicValueToken.BasicValueTypeEnum.FLOAT)
                {
                    throw new Exception("Trying to cast FLOAT to CHAR*!");
                }
                else if (val.ValueType == BasicValueToken.BasicValueTypeEnum.CHAR)
                {
                    throw new Exception("Trying to cast CHAR to CHAR*!");
                }
                else if (val.ValueType == BasicValueToken.BasicValueTypeEnum.BOOL)
                {
                    throw new Exception("Trying to cast BOOL to CHAR*!");
                }
                else if (val.ValueType == BasicValueToken.BasicValueTypeEnum.CHAR_POINTER)
                {
                    parentTok.IsConstValue = true;
                    parentTok.ConstValue = new BasicValueToken(val.Value_CharPointer);
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
                    if (tok.Left.IsConstValue && tok.Right.IsConstValue)
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
