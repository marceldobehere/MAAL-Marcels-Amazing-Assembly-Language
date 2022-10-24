using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace MAAL.Parsing
{
    public partial class Parser
    {
        public class ParsedStuff
        {
            public List<List<Token>> Commands = new List<List<Token>>();
            public Dictionary<string, DeclareVarToken> Variables = new Dictionary<string, DeclareVarToken>();
            public List<Token> other = new List<Token>();
        }

        public static ParsedStuff ParseFile(string filename)
        {
            using (StreamReader reader = new StreamReader(filename))
            {
                return ParseStringAdvanced(ParseStringBasic(reader.ReadToEnd()));
            }
        }

        static OperatorToken.OperatorEnum[] OpOrderArr2 = new OperatorToken.OperatorEnum[]
        { 
            // MATH
            OperatorToken.OperatorEnum.Star,   OperatorToken.OperatorEnum.Divide, OperatorToken.OperatorEnum.Mod,
            OperatorToken.OperatorEnum.Plus,   OperatorToken.OperatorEnum.Minus,
            // BIT
            OperatorToken.OperatorEnum.BitShiftLeft, OperatorToken.OperatorEnum.BitShiftRight,
            OperatorToken.OperatorEnum.BitAnd, OperatorToken.OperatorEnum.BitOr, // BIT NOT
            // BOOL
            OperatorToken.OperatorEnum.And,    OperatorToken.OperatorEnum.Or,     // NOT
            // COMPARISON
            OperatorToken.OperatorEnum.Equal,  OperatorToken.OperatorEnum.NotEqual,
            OperatorToken.OperatorEnum.Greater, OperatorToken.OperatorEnum.Less,
            OperatorToken.OperatorEnum.GreaterEqual, OperatorToken.OperatorEnum.LessEqual
        };

        static OperatorToken.OperatorEnum[] OpOrderArr1 = new OperatorToken.OperatorEnum[]
        { 
            // BIT
            OperatorToken.OperatorEnum.BitNot, // BIT NOT
            // BOOL
            OperatorToken.OperatorEnum.Not,     // NOT
        };

        public static ParsedStuff ParseStringAdvanced(List<Token> data, ParsedStuff stuff = null)
        {
            if (stuff == null)
                stuff = new ParsedStuff();

            // MAIN PARSE
            bool change = true;
            while (change)
            {
                change = false;
                for (int mIndex = 0; mIndex < data.Count; mIndex++)
                {
                    Token cTok = data[mIndex];

                    // int*
                    if (cTok is TypeToken && mIndex + 1 < data.Count &&
                        data[mIndex + 1] is OperatorToken && (data[mIndex + 1] as OperatorToken).Operator == OperatorToken.OperatorEnum.Star)
                    {
                        (data[mIndex] as TypeToken).PointerCount++;
                        data.RemoveAt(mIndex + 1);
                        change = true;
                        break;
                    }

                    // (int)
                    if (cTok is BracketOpenToken && mIndex + 2 < data.Count &&
                        data[mIndex + 2] is BracketCloseToken && data[mIndex + 1] is TypeToken)
                    {
                        CastTypeToken castTok = new CastTypeToken(data[mIndex + 1] as TypeToken);
                        data[mIndex] = castTok;
                        data.RemoveAt(mIndex + 1);
                        data.RemoveAt(mIndex + 1);
                        change = true;
                        break;
                    }

                    // (5), (x), (test)
                    if (cTok is BracketOpenToken && mIndex + 2 < data.Count &&
                        data[mIndex + 2] is BracketCloseToken &&
                        (data[mIndex + 1] is BasicValueToken ||
                        data[mIndex + 1] is GenericNameToken || data[mIndex + 1] is VarNameToken))
                    {
                        data.RemoveAt(mIndex);
                        data.RemoveAt(mIndex + 1);
                        change = true;
                        break;
                    }

                    // x
                    if (cTok is GenericNameToken && (stuff.Variables.ContainsKey((cTok as GenericNameToken).Name)))
                    {
                        DeclareVarToken tTok = stuff.Variables[(cTok as GenericNameToken).Name];
                        data[mIndex] = new VarNameToken(tTok.VarName, tTok.VarType);
                        change = true;
                        break;
                    }

                    //*test
                    if (cTok is OperatorToken && ((cTok as OperatorToken).Operator == OperatorToken.OperatorEnum.Star) && mIndex + 1 < data.Count && data[mIndex + 1] is VarNameToken)
                    {
                        VarNameToken tok = data[mIndex + 1] as VarNameToken;
                        tok.DereferenceCount++;
                        data.RemoveAt(mIndex);
                        change = true;
                        break;
                    }

                    //&test
                    if (cTok is OperatorToken && ((cTok as OperatorToken).Operator == OperatorToken.OperatorEnum.BitAnd) && mIndex + 1 < data.Count && data[mIndex + 1] is VarNameToken)
                    {
                        VarNameToken tok = data[mIndex + 1] as VarNameToken;
                        if (tok.UseAddr)
                            throw new Exception("Cannot show address of address bruh");
                        tok.UseAddr = true;
                        data.RemoveAt(mIndex);
                        change = true;
                        break;
                    }

                    foreach (OperatorToken.OperatorEnum cOp in OpOrderArr1)
                    {
                        //!test
                        if (cTok is OperatorToken && ((cTok as OperatorToken).Operator == cOp) && mIndex + 1 < data.Count &&
                            (data[mIndex + 1] is VarNameToken || data[mIndex + 1] is BasicValueToken || data[mIndex + 1] is ExpressionToken))
                        {
                            ExpressionToken tTok = null;
                            if (data[mIndex + 1] is BasicValueToken)
                                tTok = new ExpressionToken((data[mIndex + 1] as BasicValueToken));
                            else if (data[mIndex + 1] is VarNameToken)
                                tTok = new ExpressionToken((data[mIndex + 1] as VarNameToken));
                            else if (data[mIndex + 1] is ExpressionToken)
                                tTok = (data[mIndex + 1] as ExpressionToken);

                            data[mIndex] = new ExpressionToken(new OperatorToken(cOp), tTok);
                            data.RemoveAt(mIndex + 1);
                            change = true;
                            break;
                        }
                    }

                    // -5
                    if (cTok is OperatorToken && mIndex + 1 < data.Count &&
                        (mIndex < 1 || 
                        (!(data[mIndex - 1] is BasicValueToken) && 
                        !(data[mIndex - 1] is VarNameToken) && 
                        !(data[mIndex - 1] is ExpressionToken))) &&
                        (cTok as OperatorToken).Operator == OperatorToken.OperatorEnum.Minus
                        && data[mIndex + 1] is BasicValueToken && (
                        (data[mIndex + 1] as BasicValueToken).ValueType == BasicValueToken.BasicValueTypeEnum.INT ||
                        (data[mIndex + 1] as BasicValueToken).ValueType == BasicValueToken.BasicValueTypeEnum.LONG ||
                        (data[mIndex + 1] as BasicValueToken).ValueType == BasicValueToken.BasicValueTypeEnum.FLOAT
                        ))
                    {
                        BasicValueToken valTok = (data[mIndex + 1] as BasicValueToken);
                        if (valTok.ValueType == BasicValueToken.BasicValueTypeEnum.INT)
                            valTok.Value_Int *= -1;
                        if (valTok.ValueType == BasicValueToken.BasicValueTypeEnum.LONG)
                            valTok.Value_Long *= -1;
                        if (valTok.ValueType == BasicValueToken.BasicValueTypeEnum.FLOAT)
                            valTok.Value_Float *= -1;

                        data.RemoveAt(mIndex);
                        change = true;
                        break;
                    }

                    // (1 + 2)
                    if (cTok is BracketOpenToken && mIndex + 3 < data.Count && !(data[mIndex + 1] is BracketCloseToken) && !(data[mIndex + 2] is BracketCloseToken))
                    {
                        int tIndex = mIndex + 1;
                        int layer = 1;
                        for (; tIndex < data.Count && layer > 0; tIndex++)
                        {
                            if (data[tIndex] is BracketOpenToken)
                                layer++;
                            else if (data[tIndex] is BracketCloseToken)
                                layer--;
                        }
                        tIndex--;
                        if (layer > 0)
                            throw new Exception("Bracket was not closed!");


                        //Console.WriteLine("\n\n<START>");

                        //Console.WriteLine("Input Tokens:");
                        List<Token> tempList = new List<Token>();
                        data.RemoveAt(mIndex);
                        for (int x = mIndex + 1; x < tIndex; x++)
                        {
                            //Console.WriteLine($" - {data[mIndex]}");
                            tempList.Add(data[mIndex]);
                            data.RemoveAt(mIndex);
                        }
                        //Console.WriteLine();

                        ParsedStuff tempParsedStuff = new ParsedStuff();
                        foreach (var pair in stuff.Variables)
                            tempParsedStuff.Variables.Add(pair.Key, pair.Value);
                        ParseStringAdvanced(tempList, tempParsedStuff);


                        if (tempParsedStuff.other[0] is TypeToken)
                            tempParsedStuff.other[0] = new CastTypeToken(tempParsedStuff.other[0] as TypeToken);

                        //Console.WriteLine("Token Result:");
                        //foreach (Token token in tempParsedStuff.other)
                        //    Console.WriteLine($" - {token}");


                        //Console.WriteLine("<END>");
                        //Console.ReadLine();

                        if (tempParsedStuff.other.Count != 1)
                            throw new Exception($"COUNT IS NOT 1");



                        data[mIndex] = tempParsedStuff.other[0];

                        change = true;
                        break;
                    }

                    {
                        // a (OP) b
                        foreach (OperatorToken.OperatorEnum currentOp in OpOrderArr2)
                        {
                            if (cTok is OperatorToken && mIndex > 0 && mIndex + 1 < data.Count &&
                                ((cTok as OperatorToken).Operator == currentOp) &&
                                ((data[mIndex - 1] is BasicValueToken) || (data[mIndex - 1] is VarNameToken) || (data[mIndex - 1] is ExpressionToken)) &&
                                ((data[mIndex + 1] is BasicValueToken) || (data[mIndex + 1] is VarNameToken) || (data[mIndex + 1] is ExpressionToken))
                                )
                            {
                                ExpressionToken lTok = null;
                                if (data[mIndex - 1] is BasicValueToken)
                                    lTok = new ExpressionToken((data[mIndex - 1] as BasicValueToken));
                                else if (data[mIndex - 1] is VarNameToken)
                                    lTok = new ExpressionToken((data[mIndex - 1] as VarNameToken));
                                else if (data[mIndex - 1] is ExpressionToken)
                                    lTok = (data[mIndex - 1] as ExpressionToken);

                                ExpressionToken rTok = null;
                                if (data[mIndex + 1] is BasicValueToken)
                                    rTok = new ExpressionToken((data[mIndex + 1] as BasicValueToken));
                                else if (data[mIndex + 1] is VarNameToken)
                                    rTok = new ExpressionToken((data[mIndex + 1] as VarNameToken));
                                else if (data[mIndex + 1] is ExpressionToken)
                                    rTok = (data[mIndex + 1] as ExpressionToken);

                                data[mIndex - 1] = new ExpressionToken(
                                    lTok,
                                    new OperatorToken(currentOp),
                                    rTok
                                    );
                                data.RemoveAt(mIndex);
                                data.RemoveAt(mIndex);
                                change = true;
                                break;
                            }
                        }
                    }

                    // (int)10
                    if (cTok is CastTypeToken && mIndex + 1 < data.Count &&
                        (data[mIndex + 1] is ExpressionToken || data[mIndex + 1] is BasicValueToken || data[mIndex + 1] is VarNameToken))
                    {
                        ExpressionToken exprTok = null;
                        if (data[mIndex + 1] is ExpressionToken)
                            exprTok = data[mIndex + 1] as ExpressionToken;
                        if (data[mIndex + 1] is BasicValueToken)
                            exprTok = new ExpressionToken(data[mIndex + 1] as BasicValueToken);
                        if (data[mIndex + 1] is VarNameToken)
                            exprTok = new ExpressionToken(data[mIndex + 1] as VarNameToken);


                        data[mIndex] = new ExpressionToken(new CastToken(exprTok, (cTok as CastTypeToken).CastType));
                        data.RemoveAt(mIndex + 1);
                        change = true;
                        break;
                    }


                    // int x;
                    if (cTok is TypeToken && mIndex + 2 < data.Count &&
                        (data[mIndex + 1] is GenericNameToken) && (data[mIndex + 2] is EndCommandToken))
                    {
                        string varName = (data[mIndex + 1] as GenericNameToken).Name;
                        DeclareVarToken tok = new DeclareVarToken(
                            varName,
                            (data[mIndex] as TypeToken));

                        stuff.Variables.Add(varName, tok);

                        data.RemoveAt(mIndex);
                        data.RemoveAt(mIndex);
                        data.RemoveAt(mIndex);
                        change = true;
                        break;
                    }

                    // int x = 0; int y = a; int z = (1+2);
                    if (cTok is TypeToken && mIndex + 4 < data.Count &&
                        (data[mIndex + 1] is GenericNameToken) && (data[mIndex + 4] is EndCommandToken) &&
                        (data[mIndex + 2] is OperatorToken) && (data[mIndex + 2] as OperatorToken).Operator == OperatorToken.OperatorEnum.Set &&
                        ((data[mIndex + 3] is GenericNameToken) || (data[mIndex + 3] is VarNameToken) || (data[mIndex + 3] is BasicValueToken) || (data[mIndex + 3] is ExpressionToken)))
                    {
                        string varName = (data[mIndex + 1] as GenericNameToken).Name;
                        DeclareVarToken tok = new DeclareVarToken(
                            varName,
                            (data[mIndex] as TypeToken));

                        stuff.Variables.Add(varName, tok);

                        data.RemoveAt(mIndex);
                        change = true;
                        break;
                    }



                    // x = 10; y = (1+2);
                    if (cTok is VarNameToken && mIndex + 3 < data.Count &&
                        (data[mIndex + 3] is EndCommandToken) &&
                        (data[mIndex + 1] is OperatorToken) && (data[mIndex + 1] as OperatorToken).Operator == OperatorToken.OperatorEnum.Set &&
                        ((data[mIndex + 2] is BasicValueToken) || (data[mIndex + 2] is ExpressionToken)))
                    {
                        string varName = (cTok as VarNameToken).VarName;

                        SetVarToken tok = null;// = new SetVarToken(varName, null);
                        Token tempTok = data[mIndex + 2];
                        if (tempTok is BasicValueToken)
                        {
                            ExpressionToken exprTok = new ExpressionToken(tempTok as BasicValueToken);
                            tok = new SetVarToken(cTok as VarNameToken, exprTok);
                        }
                        else if (tempTok is ExpressionToken)
                        {
                            tok = new SetVarToken(cTok as VarNameToken, tempTok as ExpressionToken);
                        }
                        else
                            throw new Exception("BRO WAT IS GOING ON???");

                        data[mIndex] = tok;
                        data.RemoveAt(mIndex + 1);
                        data.RemoveAt(mIndex + 1);
                        data.RemoveAt(mIndex + 1);
                        change = true;
                        break;
                    }

                    // x = a;
                    if (cTok is VarNameToken && mIndex + 3 < data.Count &&
                        (data[mIndex + 3] is EndCommandToken) &&
                        (data[mIndex + 1] is OperatorToken) && (data[mIndex + 1] as OperatorToken).Operator == OperatorToken.OperatorEnum.Set &&
                        (data[mIndex + 2] is VarNameToken))
                    {
                        string varName = (cTok as VarNameToken).VarName;

                        ExpressionToken exprTok = new ExpressionToken(data[mIndex + 2] as VarNameToken);
                        SetVarToken tok = new SetVarToken(cTok as VarNameToken, exprTok);

                        data[mIndex] = tok;
                        data.RemoveAt(mIndex + 1);
                        data.RemoveAt(mIndex + 1);
                        data.RemoveAt(mIndex + 1);
                        change = true;
                        break;
                    }

                    // x++;
                    if (cTok is OperatorToken && mIndex > 0 && mIndex + 1 < data.Count &&
                        data[mIndex - 1] is VarNameToken && data[mIndex + 1] is EndCommandToken &&
                        ((cTok as OperatorToken).Operator == OperatorToken.OperatorEnum.Increment ||
                        (cTok as OperatorToken).Operator == OperatorToken.OperatorEnum.Decrement))
                    {
                        string varName = (data[mIndex - 1] as VarNameToken).VarName;

                        SetVarToken tok = null;
                        OperatorToken.OperatorEnum cOp = OperatorToken.OperatorEnum.Unknown;
                        if ((cTok as OperatorToken).Operator == OperatorToken.OperatorEnum.Increment)
                            cOp = OperatorToken.OperatorEnum.Plus;
                        else
                            cOp = OperatorToken.OperatorEnum.Minus;

                        tok = new SetVarToken((data[mIndex - 1] as VarNameToken),
                            new ExpressionToken(
                                new ExpressionToken(data[mIndex - 1] as VarNameToken),
                                new OperatorToken(cOp),
                                new ExpressionToken(new BasicValueToken(1))
                                )
                            );

                        mIndex--;
                        data[mIndex] = tok;
                        data.RemoveAt(mIndex + 1);
                        data.RemoveAt(mIndex + 1);
                        change = true;
                        break;
                    }



                    // x   +=   5 ;
                    // -1  0    1 2
                    if (cTok is OperatorToken && mIndex > 0 && mIndex + 3 < data.Count &&
                        data[mIndex - 1] is VarNameToken && data[mIndex + 2] is EndCommandToken &&
                        ((data[mIndex + 1] is BasicValueToken) || (data[mIndex + 1] is ExpressionToken) || (data[mIndex + 1] is VarNameToken)) &&
                        ((cTok as OperatorToken).Operator == OperatorToken.OperatorEnum.PlusEquals ||
                        (cTok as OperatorToken).Operator == OperatorToken.OperatorEnum.MinusEquals ||
                        (cTok as OperatorToken).Operator == OperatorToken.OperatorEnum.TimesEquals ||
                        (cTok as OperatorToken).Operator == OperatorToken.OperatorEnum.DivideEquals ||
                        (cTok as OperatorToken).Operator == OperatorToken.OperatorEnum.ModEquals
                        ))
                    {
                        string varName = (data[mIndex - 1] as VarNameToken).VarName;

                        SetVarToken tok = null;
                        OperatorToken.OperatorEnum cOp = OperatorToken.OperatorEnum.Unknown;
                        if ((cTok as OperatorToken).Operator == OperatorToken.OperatorEnum.PlusEquals)
                            cOp = OperatorToken.OperatorEnum.Plus;
                        else if ((cTok as OperatorToken).Operator == OperatorToken.OperatorEnum.MinusEquals)
                            cOp = OperatorToken.OperatorEnum.Minus;
                        else if ((cTok as OperatorToken).Operator == OperatorToken.OperatorEnum.TimesEquals)
                            cOp = OperatorToken.OperatorEnum.Star;
                        else if ((cTok as OperatorToken).Operator == OperatorToken.OperatorEnum.DivideEquals)
                            cOp = OperatorToken.OperatorEnum.Divide;
                        else if ((cTok as OperatorToken).Operator == OperatorToken.OperatorEnum.ModEquals)
                            cOp = OperatorToken.OperatorEnum.Mod;

                        ExpressionToken exprTok = null;
                        if (data[mIndex + 1] is ExpressionToken)
                            exprTok = data[mIndex + 1] as ExpressionToken;
                        if (data[mIndex + 1] is BasicValueToken)
                            exprTok = new ExpressionToken(data[mIndex + 1] as BasicValueToken);
                        if (data[mIndex + 1] is VarNameToken)
                            exprTok = new ExpressionToken(data[mIndex + 1] as VarNameToken);

                        tok = new SetVarToken((data[mIndex - 1] as VarNameToken),
                        new ExpressionToken(
                            new ExpressionToken(data[mIndex - 1] as VarNameToken),
                            new OperatorToken(cOp),
                                exprTok
                            )
                        );

                        mIndex--;
                        data[mIndex] = tok;
                        data.RemoveAt(mIndex + 1);
                        data.RemoveAt(mIndex + 1);
                        data.RemoveAt(mIndex + 1);
                        change = true;
                        break;
                    }

                }
            }

            // EXPRESSION OPTIMIZATIONS
            change = true;
            while (change)
            {
                change = false;
                // Set Var
                // Expression
                // Cast
                for (int mIndex = 0; mIndex < data.Count; mIndex++)
                {
                    Token cTok = data[mIndex];
                    if (cTok is SetVarToken && TryOptimizeExpressionToken((cTok as SetVarToken).SetExpression))
                    {
                        change = true;
                        break;
                    }
                    if (cTok is CastToken && TryOptimizeExpressionToken((cTok as CastToken).ToCast))
                    {
                        change = true;
                        break;
                    }
                    if (cTok is ExpressionToken && TryOptimizeExpressionToken(cTok as ExpressionToken))
                    {
                        change = true;
                        break;
                    }
                }
            }




            stuff.other.AddRange(data);
            return stuff;
        }

        public static bool TryOptimizeExpressionToken(ExpressionToken tok)
        {
            if (tok.IsVariable)
                return false;
            if (tok.IsConstValue)
                return false;
            if (tok.IsCast)
                return TryOptimizeExpressionToken(tok.Cast.ToCast);
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

                        else
                            throw new Exception("Trying to use BINARY NOT on non-int expression!");
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
                        #region INT + INT
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
                        #region INT + LONG
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
                        #region INT + CHAR
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

                        #region LONG + INT
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
                        #region LONG + LONG
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
                        #region LONG + CHAR
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

                        #region CHAR + INT
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
                        #region CHAR + LONG
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
                        #region CHAR + CHAR
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

                        else
                            throw new Exception("Trying to use BINARY NOT on non-int expression!");
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
                        #region INT + INT
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
                        #region INT + LONG
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
                        #region INT + CHAR
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

                        #region LONG + INT
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
                        #region LONG + LONG
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
                        #region LONG + CHAR
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

                        #region CHAR + INT
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
                        #region CHAR + LONG
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
                        #region CHAR + CHAR
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

                        else
                            throw new Exception("Trying to use BINARY NOT on non-int expression!");
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
                        #region INT + INT
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
                        #region INT + LONG
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
                        #region INT + CHAR
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

                        #region LONG + INT
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
                        #region LONG + LONG
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
                        #region LONG + CHAR
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

                        #region CHAR + INT
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
                        #region CHAR + LONG
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
                        #region CHAR + CHAR
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

                        else
                            throw new Exception("Trying to use BINARY NOT on non-int expression!");
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
                        #region INT + INT
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
                        #region INT + LONG
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
                        #region INT + CHAR
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

                        #region LONG + INT
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
                        #region LONG + LONG
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
                        #region LONG + CHAR
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

                        #region CHAR + INT
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
                        #region CHAR + LONG
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
                        #region CHAR + CHAR
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

                        else
                            throw new Exception("Trying to use BINARY NOT on non-int expression!");
                    }
                }
                #endregion

                #region EQUALS
                else if (tok.Operator.Operator == OperatorToken.OperatorEnum.Equal)
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
                                tok.Left.ConstValue.Value_Int ==
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
                                tok.Left.ConstValue.Value_Int ==
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
                                tok.Left.ConstValue.Value_Int ==
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
                                tok.Left.ConstValue.Value_Int ==
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
                                tok.Left.ConstValue.Value_Long ==
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
                                tok.Left.ConstValue.Value_Long ==
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
                                tok.Left.ConstValue.Value_Long ==
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
                                tok.Left.ConstValue.Value_Long ==
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
                                tok.Left.ConstValue.Value_Char ==
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
                                tok.Left.ConstValue.Value_Char ==
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
                                tok.Left.ConstValue.Value_Char ==
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
                                tok.Left.ConstValue.Value_Char ==
                                tok.Right.ConstValue.Value_Float);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion

                        #region BOOL + BOOL
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

                        else
                            throw new Exception("Trying to use BINARY NOT on non-int expression!");
                    }
                }
                #endregion
                #region NOT EQUALS
                else if (tok.Operator.Operator == OperatorToken.OperatorEnum.NotEqual)
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
                                tok.Left.ConstValue.Value_Int !=
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
                                tok.Left.ConstValue.Value_Int !=
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
                                tok.Left.ConstValue.Value_Int !=
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
                                tok.Left.ConstValue.Value_Int !=
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
                                tok.Left.ConstValue.Value_Long !=
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
                                tok.Left.ConstValue.Value_Long !=
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
                                tok.Left.ConstValue.Value_Long !=
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
                                tok.Left.ConstValue.Value_Long !=
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
                                tok.Left.ConstValue.Value_Char !=
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
                                tok.Left.ConstValue.Value_Char !=
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
                                tok.Left.ConstValue.Value_Char !=
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
                                tok.Left.ConstValue.Value_Char !=
                                tok.Right.ConstValue.Value_Float);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion

                        #region BOOL + BOOL
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

                        else
                            throw new Exception("Trying to use BINARY NOT on non-int expression!");
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
                        #region INT + INT
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
                        #region INT + LONG
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
                        #region INT + CHAR
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
                        #region INT + FLOAT
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

                        #region LONG + INT
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
                        #region LONG + LONG
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
                        #region LONG + CHAR
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
                        #region LONG + FLOAT
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

                        #region CHAR + INT
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
                        #region CHAR + LONG
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
                        #region CHAR + CHAR
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
                        #region CHAR + FLOAT
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

                        else
                            throw new Exception("Trying to use BINARY NOT on non-int expression!");
                    }
                }
                #endregion
                #region LESS
                else if (tok.Operator.Operator == OperatorToken.OperatorEnum.Greater)
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
                                tok.Left.ConstValue.Value_Int <
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
                                tok.Left.ConstValue.Value_Int <
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
                                tok.Left.ConstValue.Value_Int <
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
                                tok.Left.ConstValue.Value_Int <
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
                                tok.Left.ConstValue.Value_Long <
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
                                tok.Left.ConstValue.Value_Long <
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
                                tok.Left.ConstValue.Value_Long <
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
                                tok.Left.ConstValue.Value_Long <
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
                                tok.Left.ConstValue.Value_Char <
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
                                tok.Left.ConstValue.Value_Char <
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
                                tok.Left.ConstValue.Value_Char <
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
                                tok.Left.ConstValue.Value_Char <
                                tok.Right.ConstValue.Value_Float);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion

                        else
                            throw new Exception("Trying to use BINARY NOT on non-int expression!");
                    }
                }
                #endregion
                #region GREATER EQUAL
                else if (tok.Operator.Operator == OperatorToken.OperatorEnum.Greater)
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
                                tok.Left.ConstValue.Value_Int >=
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
                                tok.Left.ConstValue.Value_Int >=
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
                                tok.Left.ConstValue.Value_Int >=
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
                                tok.Left.ConstValue.Value_Int >=
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
                                tok.Left.ConstValue.Value_Long >=
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
                                tok.Left.ConstValue.Value_Long >=
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
                                tok.Left.ConstValue.Value_Long >=
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
                                tok.Left.ConstValue.Value_Long >=
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
                                tok.Left.ConstValue.Value_Char >=
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
                                tok.Left.ConstValue.Value_Char >=
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
                                tok.Left.ConstValue.Value_Char >=
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
                                tok.Left.ConstValue.Value_Char >=
                                tok.Right.ConstValue.Value_Float);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion

                        else
                            throw new Exception("Trying to use BINARY NOT on non-int expression!");
                    }
                }
                #endregion
                #region LESS EQUAL
                else if (tok.Operator.Operator == OperatorToken.OperatorEnum.Greater)
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
                                tok.Left.ConstValue.Value_Int <=
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
                                tok.Left.ConstValue.Value_Int <=
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
                                tok.Left.ConstValue.Value_Int <=
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
                                tok.Left.ConstValue.Value_Int <=
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
                                tok.Left.ConstValue.Value_Long <=
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
                                tok.Left.ConstValue.Value_Long <=
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
                                tok.Left.ConstValue.Value_Long <=
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
                                tok.Left.ConstValue.Value_Long <=
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
                                tok.Left.ConstValue.Value_Char <=
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
                                tok.Left.ConstValue.Value_Char <=
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
                                tok.Left.ConstValue.Value_Char <=
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
                                tok.Left.ConstValue.Value_Char <=
                                tok.Right.ConstValue.Value_Float);
                            tok.Left = null;
                            tok.Operator = null;
                        }
                        #endregion

                        else
                            throw new Exception("Trying to use BINARY NOT on non-int expression!");
                    }
                }
                #endregion

            }




            return false;
        }


        //public static ExpressionToken CalcExpressionTokenFromList(List<Token> data)
        //{
        //    List<Token> cTokList = new List<Token>();
        //    cTokList.AddRange(data);

        //    Console.WriteLine("\n\n\n<DEBUG START>");
        //    Console.WriteLine("Items: ");
        //    foreach (Token tok in cTokList)
        //        Console.WriteLine($" - {tok}");


        //    Console.WriteLine("<END>");
        //    Console.ReadLine();

        //    while (cTokList.Count > 1)
        //    {

        //    }

        //    if (cTokList.Count != 1)
        //        throw new Exception("Parsing Brackets into Expression Toket failed!");
        //    if (!(cTokList[0] is ExpressionToken))
        //        throw new Exception("Could not Parse brackets into ExpressionToken!");
        //    return (cTokList[0] as ExpressionToken);
        //}



        public static Token ConvertStringToToken(string str)
        {
            if (TypeToken.IsType(str))
                return new TypeToken(str);

            if (KeywordToken.KeywordList.Contains(str))
                return new KeywordToken(str);

            if (int.TryParse(str, NumberStyles.Number, CultureInfo.InvariantCulture, out int vI))
                return new BasicValueToken(vI);
            if (long.TryParse(str, NumberStyles.Number, CultureInfo.InvariantCulture, out long vL))
                return new BasicValueToken(vL);
            if (float.TryParse(str, NumberStyles.Float, CultureInfo.InvariantCulture, out float vF))
                return new BasicValueToken(vF);
            if (str.ToLower().Equals("true"))
                return new BasicValueToken(true);
            if (str.ToLower().Equals("false"))
                return new BasicValueToken(false);

            return new GenericNameToken(str);
        }


        public static List<Token> ParseStringBasic(string data)
        {
            List<Token> tokens = new List<Token>();

            string tempString = "";

            int mIndex = 0;
            int len = data.Length;
            for (; mIndex < len; mIndex++)
            {
                char tChar = data[mIndex];
                if ("\n\r\t ".Contains(tChar))
                {
                    if (tempString != "")
                        tokens.Add(ConvertStringToToken(tempString));
                    tempString = "";
                    continue;
                }
                else if (tChar == ';')
                {
                    if (tempString != "")
                        tokens.Add(ConvertStringToToken(tempString));
                    tokens.Add(new EndCommandToken());
                    tempString = "";
                }
                else if (tChar == '"')
                {
                    if (tempString != "")
                        tokens.Add(ConvertStringToToken(tempString));
                    tempString = "";

                    string tempCharPointerString = "";
                    for (mIndex++; mIndex < len && data[mIndex] != '"'; mIndex++)
                        if (data[mIndex] == '\\' && mIndex + 1 < len)
                            tempCharPointerString += data[++mIndex];
                        else
                            tempCharPointerString += data[mIndex];

                    if (mIndex == len)
                        break;

                    tokens.Add(new BasicValueToken(tempCharPointerString));
                }
                else if (tChar == '\'')
                {
                    if (tempString != "")
                        tokens.Add(ConvertStringToToken(tempString));
                    tempString = "";

                    string tempCharString = "";
                    for (mIndex++; mIndex < len && data[mIndex] != '\''; mIndex++)
                        if (data[mIndex] == '\\' && mIndex + 1 < len)
                            tempCharString += data[++mIndex];
                        else
                            tempCharString += data[mIndex];

                    if (mIndex == len)
                        break;
                    if (tempCharString.Length != 1)
                        break;

                    tokens.Add(new BasicValueToken(tempCharString[0]));
                }
                else if (tChar == '/' && mIndex + 1 < len && data[mIndex + 1] == '/')
                {
                    if (tempString != "")
                        tokens.Add(ConvertStringToToken(tempString));
                    tempString = "";

                    mIndex += 2;
                    while (mIndex < len && data[mIndex] != '\n')
                        mIndex++;
                }
                else if (tChar == '/' && mIndex + 1 < len && data[mIndex + 1] == '*')
                {
                    if (tempString != "")
                        tokens.Add(ConvertStringToToken(tempString));
                    tempString = "";

                    mIndex += 2;
                    while (mIndex + 1 < len && (data[mIndex] != '*' || data[mIndex + 1] != '/'))
                        mIndex++;
                    if (mIndex + 1 < len)
                        mIndex++;
                }
                else if (OperatorToken.uniqueOpCharList.Contains(tChar))
                {
                    if (tempString != "")
                        tokens.Add(ConvertStringToToken(tempString));
                    tempString = "";

                    int sIndex = mIndex;
                    OperatorToken.OperatorEnum lastFound = OperatorToken.OperatorEnum.Unknown;

                    int mLen = Math.Min(OperatorToken.maxOpLen, (len - mIndex));
                    for (int i = mLen; i > 0; i--)
                        if (OperatorToken.OpStringDict.TryGetValue(data.Substring(sIndex, i), out OperatorToken.OperatorEnum opEnum))
                        {
                            lastFound = opEnum;
                            mIndex += i - 1;
                            break;
                        }

                    tokens.Add(new OperatorToken(lastFound));
                }
                else if (tChar == '(')
                {
                    if (tempString != "")
                        tokens.Add(ConvertStringToToken(tempString));
                    tempString = "";
                    tokens.Add(new BracketOpenToken());
                }
                else if (tChar == ')')
                {
                    if (tempString != "")
                        tokens.Add(ConvertStringToToken(tempString));
                    tempString = "";
                    tokens.Add(new BracketCloseToken());
                }
                else
                    tempString += tChar;
            }
            if (tempString != "")
                tokens.Add(ConvertStringToToken(tempString));


            return tokens;
        }
    }
}
