﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace MAAL.Parsing
{
    public partial class Parser
    {
        public static int GenIdCounter = 0;

        public class ParsedStuff
        {
            public List<DeclareVarToken> Variables = new List<DeclareVarToken>();
            public List<DefineLocationToken> Locations = new List<DefineLocationToken>();
            public List<DefineSubroutineToken> Subroutines = new List<DefineSubroutineToken>();
            public List<string> Strings = new List<string>();
            public List<string> Namespaces = new List<string>();

            public List<Token> parsedTokens = new List<Token>();

            public DeclareVarToken GetVarFromNameAndNamespace(string namespacePref, string varName)
            {
                foreach (var v in Variables)
                    if (v.NamespacePrefix.Equals(namespacePref) && v.VarName.Equals(varName))
                        return v;

                return null;
            }
            public DefineLocationToken GetLocFromNameAndNamespace(string namespacePref, string locName)
            {
                foreach (var v in Locations)
                    if (v.NamespacePrefix.Equals(namespacePref) && v.LocationName.Equals(locName))
                        return v;

                return null;
            }
            public DefineSubroutineToken GetSubFromNameAndNamespace(string namespacePref, string subName)
            {
                foreach (var v in Subroutines)
                    if (v.NamespacePrefix.Equals(namespacePref) && v.SubroutineName.Equals(subName))
                        return v;

                return null;
            }

            public bool HasVarFromNameAndNamespace(string namespacePref, string tName)
            {
                return GetVarFromNameAndNamespace(namespacePref, tName) != null;
            }
            public bool HasLocFromNameAndNamespace(string namespacePref, string tName)
            {
                return GetLocFromNameAndNamespace(namespacePref, tName) != null;
            }
            public bool HasSubFromNameAndNamespace(string namespacePref, string tName)
            {
                return GetSubFromNameAndNamespace(namespacePref, tName) != null;
            }


        }

        public static ParsedStuff ParseFile(string filename)
        {
            using (StreamReader reader = new StreamReader(filename))
            {
                return ParseStringAdvanced(ParseStringBasic(reader.ReadToEnd()));
            }
        }

        #region Operators and Orders
        static readonly OperatorToken.OperatorEnum[] OpOrderArr2 = new OperatorToken.OperatorEnum[]
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

        static readonly OperatorToken.OperatorEnum[] OpOrderArr1 = new OperatorToken.OperatorEnum[]
        { 
            // BIT
            OperatorToken.OperatorEnum.BitNot, // BIT NOT
            // BOOL
            OperatorToken.OperatorEnum.Not,     // NOT
        };
        #endregion

        #region Expression Stuff
        public static ExpressionToken ConvToExpressionToken(Token tok)
        {
            if (tok is BasicValueToken)
                return new ExpressionToken(tok as BasicValueToken);
            else if (tok is VarNameToken)
                return new ExpressionToken(tok as VarNameToken);
            else if (tok is DerefToken)
                return new ExpressionToken(tok as DerefToken);
            else if (tok is ExpressionToken)
                return (tok as ExpressionToken);
            else if (tok is CastToken)
                return new ExpressionToken(tok as CastToken);
            else
                return null;
        }

        private static bool CouldBeExpessionToken(Token tok)
        {
            return tok is ExpressionToken || tok is BasicValueToken || tok is VarNameToken || tok is DerefToken;
        }
        #endregion

        public static void AddStringIfPossible(BasicValueToken tok, ParsedStuff stuff)
        {
            if (tok.ValueType != BasicValueToken.BasicValueTypeEnum.CHAR_POINTER)
                return;

            if (!stuff.Strings.Contains(tok.Value_CharPointer))
                stuff.Strings.Add(tok.Value_CharPointer);
        }

        public static void AddStringIfPossible(ExpressionToken tok, ParsedStuff stuff)
        {
            if (tok.IsConstValue)
                AddStringIfPossible(tok.ConstValue, stuff);
        }

        public static ParsedStuff ParseStringAdvanced(List<Token> data, ParsedStuff stuff = null)
        {
            if (stuff == null)
                stuff = new ParsedStuff();

            // MAIN PARSE
            bool change = true;
            while (change)
            {
                change = false;

                foreach (OperatorToken.OperatorEnum currentOp in OpOrderArr2)
                {
                    for (int mIndex = 0; mIndex < data.Count; mIndex++)
                    {
                        Token cTok = data[mIndex];

                        #region NAMESPACE
                        if (cTok is KeywordToken && mIndex + 2 < data.Count &&
                           (cTok as KeywordToken).Keyword.Equals("namespace") &&
                           data[mIndex + 1] is GenericNameToken &&
                           data[mIndex + 2] is CurlyBracketOpenToken)
                        {
                            string namespaceName = (data[mIndex + 1] as GenericNameToken).Name + "::";
                            string namespacePref = (data[mIndex + 1] as GenericNameToken).NamespacePrefix;

                            int cCloseIndex = -1;
                            int layer = 1;
                            for (int tI = mIndex + 3; layer > 0 && tI < data.Count; tI++)
                            {
                                if (data[tI] is CurlyBracketOpenToken)
                                    layer++;
                                if (data[tI] is CurlyBracketCloseToken)
                                    layer--;
                                if (layer == 0)
                                    cCloseIndex = tI;
                            }
                            if (layer != 0)
                            {
                                throw new Exception($"NAMESPACE WAS NOT CLOSED!");
                            }

                            for (int tI = mIndex + 3; tI < cCloseIndex; tI++)
                                data[tI].NamespacePrefix += namespaceName;
                            stuff.Namespaces.Add(namespacePref + namespaceName);

                            data.RemoveAt(cCloseIndex);
                            data.RemoveAt(mIndex + 2);
                            data.RemoveAt(mIndex + 1);
                            data.RemoveAt(mIndex);

                            change = true;
                            break;
                        }
                        #endregion
                        #region NAMESPACE::
                        else if (cTok is GenericNameToken && mIndex + 1 < data.Count &&
                            data[mIndex + 1] is DoubleColonToken)
                        {
                            string pref = (cTok as GenericNameToken).NamespacePrefix;
                            string name = (cTok as GenericNameToken).Name;

                            int sIndex = mIndex + 1;

                            string tPref = pref;

                            if (name.ToLower().Equals("global"))
                            {
                                tPref = "";
                            }
                            else
                                tPref += name + "::";
                            //if (name.ToLower().Equals("global"))
                            //{
                            //    data[mIndex] = new NamespaceUseToken("");
                            //    data.RemoveAt(mIndex + 1);
                            //    change = true;
                            //    break;
                            //}

                            int wIndex = mIndex + 2;

                            while (wIndex + 1 < data.Count &&
                                (data[wIndex] is GenericNameToken) &&
                                (data[wIndex + 1] is DoubleColonToken))
                            {
                                tPref += (data[wIndex] as GenericNameToken).Name + "::";
                                wIndex += 2;
                            }

                            if (!tPref.Equals("") && !stuff.Namespaces.Contains(tPref))
                            {
                                continue;
                                //throw new Exception($"NAMESPACE {tPref} DOES NOT EXIST! {cTok}");
                            }


                            int eIndex = wIndex - 2;
                            data[mIndex] = new NamespaceUseToken(tPref);
                            for (int i = sIndex; i < wIndex; i++)
                                data.RemoveAt(sIndex);

                            change = true;
                            break;
                        }
                        #endregion
                        #region NAMESPACE::x
                        else if (cTok is NamespaceUseToken && mIndex + 1 < data.Count)
                        {
                            //Console.WriteLine($" - 1: {data[mIndex + 1]}");
                            data[mIndex + 1].NamespacePrefix = (cTok as NamespaceUseToken).NamespacePrefix;
                            //Console.WriteLine($" - 2: {data[mIndex + 1]}\n");
                            data.RemoveAt(mIndex);
                            change = true;
                            break;
                        }
                        #endregion


                        #region STRINGS
                        else if (cTok is BasicValueToken && (cTok as BasicValueToken).ValueType == BasicValueToken.BasicValueTypeEnum.CHAR_POINTER)
                        {
                            //GlobalStuff.WriteLine("BRUH");
                            BasicValueToken sTok = (cTok as BasicValueToken);
                            if (!stuff.Strings.Contains(sTok.Value_CharPointer))
                                stuff.Strings.Add(sTok.Value_CharPointer);
                        }
                        #endregion

                        #region DEFINE LOCATION AND SUB
                        // loc MAIN:
                        if (cTok is KeywordToken && mIndex + 2 < data.Count &&
                            data[mIndex + 1] is GenericNameToken && data[mIndex + 2] is ColonToken)
                        {
                            string kWord = (cTok as KeywordToken).Keyword;

                            if (kWord.Equals("loc") || kWord.Equals("location"))
                            {
                                string locName = (data[mIndex + 1] as GenericNameToken).Name;
                                data[mIndex] = new DefineLocationToken(locName, (data[mIndex + 1] as GenericNameToken).NamespacePrefix);
                                stuff.Locations.Add(data[mIndex] as DefineLocationToken);
                                data.RemoveAt(mIndex + 1);
                                data.RemoveAt(mIndex + 1);
                                change = true;
                                break;
                            }
                            else if (kWord.Equals("sub") || kWord.Equals("subroutine"))
                            {
                                string locName = (data[mIndex + 1] as GenericNameToken).Name;
                                data[mIndex] = new DefineSubroutineToken(locName, (data[mIndex + 1] as GenericNameToken).NamespacePrefix);
                                stuff.Subroutines.Add(data[mIndex] as DefineSubroutineToken);
                                data.RemoveAt(mIndex + 1);
                                data.RemoveAt(mIndex + 1);
                                change = true;
                                break;
                            }


                        }
                        #endregion
                        #region EXIT AND RETURN
                        // exit;
                        if (cTok is KeywordToken && mIndex + 1 < data.Count &&
                            data[mIndex + 1] is EndCommandToken)
                        {
                            string kWord = (cTok as KeywordToken).Keyword;

                            if (kWord.Equals("exit"))
                            {
                                data[mIndex] = new ExitToken();
                                data.RemoveAt(mIndex + 1);
                                change = true;
                                break;
                            }
                            else if (kWord.Equals("ret") || kWord.Equals("return"))
                            {
                                data[mIndex] = new ReturnToken();
                                data.RemoveAt(mIndex + 1);
                                change = true;
                                break;
                            }
                        }
                        #endregion

                        #region #INCLUDE
                        if (cTok is KeywordToken && mIndex + 1 < data.Count &&
                            (cTok as KeywordToken).Keyword.Equals("#include") &&
                            data[mIndex + 1] is BasicValueToken &&
                            (data[mIndex + 1] as BasicValueToken).ValueType == BasicValueToken.BasicValueTypeEnum.CHAR_POINTER)
                        {
                            string tempFilePath = (data[mIndex + 1] as BasicValueToken).Value_CharPointer;
                            data.RemoveAt(mIndex);
                            data.RemoveAt(mIndex);

                            string nPath = (cTok as KeywordToken).RelFilePath;
                            if (nPath.Equals(""))
                                nPath = ".";
                            nPath += $"/{tempFilePath}";


                            //Console.WriteLine($"OLD:   {(cTok as KeywordToken).RelFilePath}");
                            //Console.WriteLine($"FILE:  {tempFilePath}");
                            //Console.WriteLine($"nPATH: {nPath}");
                            if (!File.Exists(nPath))
                                throw new Exception($"FILE AT \"{nPath}\" DOES NOT EXIST!");
                            string newBasePath = Directory.GetParent(nPath).FullName;
                            //Console.WriteLine($"ROOT:  {newBasePath}");

                            //Console.WriteLine();

                            List<Token> tempList = ParseStringBasic(new StreamReader(nPath).ReadToEnd());
                            foreach (var t in tempList)
                            {
                                t.NamespacePrefix = cTok.NamespacePrefix;
                                if (t is KeywordToken)
                                    (t as KeywordToken).RelFilePath = newBasePath;
                            }


                            data.InsertRange(mIndex, tempList);

                            change = true;
                            break;
                        }
                        #endregion

                        #region CLS
                        else if (cTok is KeywordToken && mIndex + 1 < data.Count &&
                            (cTok as KeywordToken).Keyword.Equals("cls") &&
                        data[mIndex + 1] is EndCommandToken)
                        {
                            data[mIndex] = new ClsToken();
                            data.RemoveAt(mIndex + 1);

                            change = true;
                            break;
                        }
                        #endregion
                        #region COLOR
                        else if (cTok is KeywordToken && mIndex + 3 < data.Count &&
                            (cTok as KeywordToken).Keyword.Equals("color") &&
                            data[mIndex + 3] is EndCommandToken &&
                            data[mIndex + 1] is KeywordToken &&
                            ((data[mIndex + 1] as KeywordToken).Keyword.Equals("FG") || (data[mIndex + 1] as KeywordToken).Keyword.Equals("BG")) &&
                            CouldBeExpessionToken(data[mIndex + 2]))
                        {
                            data[mIndex] = new SetColorToken(ConvToExpressionToken(data[mIndex + 2]), (data[mIndex + 1] as KeywordToken).Keyword.Equals("FG"));
                            AddStringIfPossible(ConvToExpressionToken(data[mIndex + 2]), stuff);
                            data.RemoveAt(mIndex + 1);
                            data.RemoveAt(mIndex + 1);
                            data.RemoveAt(mIndex + 1);

                            change = true;
                            break;
                        }
                        #endregion



                        #region PRINT
                        else if (cTok is KeywordToken && mIndex + 2 < data.Count &&
                            (cTok as KeywordToken).Keyword.Equals("print") &&
                            data[mIndex + 2] is EndCommandToken &&
                            CouldBeExpessionToken(data[mIndex + 1]))
                        {
                            data[mIndex] = new PrintToken(ConvToExpressionToken(data[mIndex + 1]));
                            AddStringIfPossible(ConvToExpressionToken(data[mIndex + 1]), stuff);
                            data.RemoveAt(mIndex + 1);
                            data.RemoveAt(mIndex + 1);

                            change = true;
                            break;
                        }
                        #endregion

                        #region FREE
                        else if (cTok is KeywordToken && mIndex + 2 < data.Count &&
                            (cTok as KeywordToken).Keyword.Equals("free") &&
                            data[mIndex + 2] is EndCommandToken &&
                            CouldBeExpessionToken(data[mIndex + 1]))
                        {
                            data[mIndex] = new FreeToken(ConvToExpressionToken(data[mIndex + 1]));
                            data.RemoveAt(mIndex + 1);
                            data.RemoveAt(mIndex + 1);

                            change = true;
                            break;
                        }
                        #endregion
                        #region MALLOC
                        else if (cTok is KeywordToken && mIndex + 3 < data.Count &&
                            (cTok as KeywordToken).Keyword.Equals("malloc") &&
                            data[mIndex + 3] is EndCommandToken &&
                            CouldBeExpessionToken(data[mIndex + 1]) &&
                            CouldBeExpessionToken(data[mIndex + 2]))
                        {
                            data[mIndex] = new MallocToken(ConvToExpressionToken(data[mIndex + 1]), ConvToExpressionToken(data[mIndex + 2]));
                            data.RemoveAt(mIndex + 1);
                            data.RemoveAt(mIndex + 1);
                            data.RemoveAt(mIndex + 1);

                            change = true;
                            break;
                        }
                        #endregion

                        #region SLEEP
                        else if (cTok is KeywordToken && mIndex + 2 < data.Count &&
                            (cTok as KeywordToken).Keyword.Equals("sleep") &&
                            data[mIndex + 2] is EndCommandToken &&
                            CouldBeExpessionToken(data[mIndex + 1]))
                        {
                            data[mIndex] = new SleepToken(ConvToExpressionToken(data[mIndex + 1]));
                            data.RemoveAt(mIndex + 1);
                            data.RemoveAt(mIndex + 1);

                            change = true;
                            break;
                        }
                        #endregion

                        #region GET RND ULONG
                        else if (cTok is KeywordToken && mIndex + 2 < data.Count &&
                            (cTok as KeywordToken).Keyword.Equals("getRandomUlong") &&
                            data[mIndex + 2] is EndCommandToken &&
                            CouldBeExpessionToken(data[mIndex + 1]))
                        {
                            data[mIndex] = new GetRandomUlongToken(ConvToExpressionToken(data[mIndex + 1]));
                            data.RemoveAt(mIndex + 1);
                            data.RemoveAt(mIndex + 1);

                            change = true;
                            break;
                        }
                        #endregion
                        #region GET RND Double
                        else if (cTok is KeywordToken && mIndex + 2 < data.Count &&
                            (cTok as KeywordToken).Keyword.Equals("getRandomDouble") &&
                            data[mIndex + 2] is EndCommandToken &&
                            CouldBeExpessionToken(data[mIndex + 1]))
                        {
                            data[mIndex] = new GetRandomDoubleToken(ConvToExpressionToken(data[mIndex + 1]));
                            data.RemoveAt(mIndex + 1);
                            data.RemoveAt(mIndex + 1);

                            change = true;
                            break;
                        }
                        #endregion

                        #region GET KEY STATE
                        else if (cTok is KeywordToken && mIndex + 3 < data.Count &&
                            (cTok as KeywordToken).Keyword.Equals("getKeyboardState") &&
                            data[mIndex + 3] is EndCommandToken &&
                            CouldBeExpessionToken(data[mIndex + 1]) &&
                            CouldBeExpessionToken(data[mIndex + 2]))
                        {
                            var c1 = ConvToExpressionToken(new CastToken(ConvToExpressionToken(data[mIndex + 1]), new TypeToken("char")));
                            data[mIndex] = new GetKeyboardStateToken(c1, ConvToExpressionToken(data[mIndex + 2]));
                            data.RemoveAt(mIndex + 1);
                            data.RemoveAt(mIndex + 1);
                            data.RemoveAt(mIndex + 1);

                            change = true;
                            break;
                        }
                        #endregion
                        #region GET MOUSE STATE
                        else if (cTok is KeywordToken && mIndex + 3 < data.Count &&
                            (cTok as KeywordToken).Keyword.Equals("getMouseState") &&
                            data[mIndex + 3] is EndCommandToken &&
                            CouldBeExpessionToken(data[mIndex + 1]) &&
                            CouldBeExpessionToken(data[mIndex + 2]))
                        {
                            var c1 = ConvToExpressionToken(new CastToken(ConvToExpressionToken(data[mIndex + 1]), new TypeToken("char")));
                            data[mIndex] = new GetMouseStateToken(c1, ConvToExpressionToken(data[mIndex + 2]));
                            data.RemoveAt(mIndex + 1);
                            data.RemoveAt(mIndex + 1);
                            data.RemoveAt(mIndex + 1);

                            change = true;
                            break;
                        }
                        #endregion


                        #region CREATE WINDOW
                        else if (cTok is KeywordToken && mIndex + 2 < data.Count &&
                            (cTok as KeywordToken).Keyword.Equals("createWindow") &&
                            data[mIndex + 2] is EndCommandToken &&
                            CouldBeExpessionToken(data[mIndex + 1]))
                        {
                            CastToken castTok = new CastToken(ConvToExpressionToken(data[mIndex + 1]), new TypeToken("long"));

                            data[mIndex] = new CreateWindowToken(ConvToExpressionToken(castTok));

                            data.RemoveAt(mIndex + 1);
                            data.RemoveAt(mIndex + 1);

                            change = true;
                            break;
                        }
                        #endregion
                        #region DELETE WINDOW
                        else if (cTok is KeywordToken && mIndex + 2 < data.Count &&
                            (cTok as KeywordToken).Keyword.Equals("deleteWindow") &&
                            data[mIndex + 2] is EndCommandToken &&
                            CouldBeExpessionToken(data[mIndex + 1]))
                        {
                            CastToken castTok = new CastToken(ConvToExpressionToken(data[mIndex + 1]), new TypeToken("long"));

                            data[mIndex] = new DeleteWindowToken(ConvToExpressionToken(castTok));
                            data.RemoveAt(mIndex + 1);
                            data.RemoveAt(mIndex + 1);

                            change = true;
                            break;
                        }
                        #endregion

                        #region SET WINDOW ATTR
                        else if (cTok is KeywordToken && mIndex + 4 < data.Count &&
                            (cTok as KeywordToken).Keyword.Equals("setWindowAttr") &&
                            data[mIndex + 4] is EndCommandToken &&
                            CouldBeExpessionToken(data[mIndex + 1]) &&
                            CouldBeExpessionToken(data[mIndex + 2]) &&
                            CouldBeExpessionToken(data[mIndex + 3]))
                        {
                            CastToken castTok = new CastToken(ConvToExpressionToken(data[mIndex + 1]), new TypeToken("long"));
                            AddStringIfPossible(ConvToExpressionToken(data[mIndex + 3]), stuff);
                            data[mIndex] = new SetWindowAttrToken(
                                ConvToExpressionToken(castTok),
                                ConvToExpressionToken(data[mIndex + 2]),
                                ConvToExpressionToken(data[mIndex + 3]));
                            data.RemoveAt(mIndex + 1);
                            data.RemoveAt(mIndex + 1);
                            data.RemoveAt(mIndex + 1);
                            data.RemoveAt(mIndex + 1);

                            change = true;
                            break;
                        }
                        #endregion
                        #region GET WINDOW ATTR
                        else if (cTok is KeywordToken && mIndex + 4 < data.Count &&
                            (cTok as KeywordToken).Keyword.Equals("getWindowAttr") &&
                            data[mIndex + 4] is EndCommandToken &&
                            CouldBeExpessionToken(data[mIndex + 1]) &&
                            CouldBeExpessionToken(data[mIndex + 2]) &&
                            CouldBeExpessionToken(data[mIndex + 3]))
                        {
                            CastToken castTok = new CastToken(ConvToExpressionToken(data[mIndex + 1]), new TypeToken("long"));

                            data[mIndex] = new GetWindowAttrToken(
                                ConvToExpressionToken(castTok),
                                ConvToExpressionToken(data[mIndex + 2]),
                                ConvToExpressionToken(data[mIndex + 3]));
                            data.RemoveAt(mIndex + 1);
                            data.RemoveAt(mIndex + 1);
                            data.RemoveAt(mIndex + 1);
                            data.RemoveAt(mIndex + 1);

                            change = true;
                            break;
                        }
                        #endregion

                        #region CREATE COMP (NO PARENT)
                        else if (cTok is KeywordToken && mIndex + 4 < data.Count &&
                            (cTok as KeywordToken).Keyword.Equals("createComponentWithId") &&
                            data[mIndex + 4] is EndCommandToken &&
                            CouldBeExpessionToken(data[mIndex + 1]) &&
                            CouldBeExpessionToken(data[mIndex + 2]) &&
                            CouldBeExpessionToken(data[mIndex + 3]))
                        {
                            CastToken castTok1 = new CastToken(ConvToExpressionToken(data[mIndex + 1]), new TypeToken("long"));
                            CastToken castTok2 = new CastToken(ConvToExpressionToken(data[mIndex + 2]), new TypeToken("long"));


                            data[mIndex] = new CreateComponentToken(
                                ConvToExpressionToken(castTok1),
                                ConvToExpressionToken(castTok2),
                                ConvToExpressionToken(data[mIndex + 3]),
                                ConvToExpressionToken(new BasicValueToken((long)-1)));
                            data.RemoveAt(mIndex + 1);
                            data.RemoveAt(mIndex + 1);
                            data.RemoveAt(mIndex + 1);
                            data.RemoveAt(mIndex + 1);

                            change = true;
                            break;
                        }
                        #endregion
                        #region CREATE COMP (WITH PARENT)
                        else if (cTok is KeywordToken && mIndex + 5 < data.Count &&
                            (cTok as KeywordToken).Keyword.Equals("createComponentWithId") &&
                            data[mIndex + 5] is EndCommandToken &&
                            CouldBeExpessionToken(data[mIndex + 1]) &&
                            CouldBeExpessionToken(data[mIndex + 2]) &&
                            CouldBeExpessionToken(data[mIndex + 3]) &&
                            CouldBeExpessionToken(data[mIndex + 4]))
                        {
                            CastToken castTok1 = new CastToken(ConvToExpressionToken(data[mIndex + 1]), new TypeToken("long"));
                            CastToken castTok2 = new CastToken(ConvToExpressionToken(data[mIndex + 2]), new TypeToken("long"));
                            CastToken castTok3 = new CastToken(ConvToExpressionToken(data[mIndex + 4]), new TypeToken("long"));

                            data[mIndex] = new CreateComponentToken(
                                ConvToExpressionToken(castTok1),
                                ConvToExpressionToken(castTok2),
                                ConvToExpressionToken(data[mIndex + 3]),
                                ConvToExpressionToken(castTok3));
                            data.RemoveAt(mIndex + 1);
                            data.RemoveAt(mIndex + 1);
                            data.RemoveAt(mIndex + 1);
                            data.RemoveAt(mIndex + 1);
                            data.RemoveAt(mIndex + 1);

                            change = true;
                            break;
                        }
                        #endregion

                        #region DELETE COMP
                        else if (cTok is KeywordToken && mIndex + 4 < data.Count &&
                            (cTok as KeywordToken).Keyword.Equals("deleteComponentWithId") &&
                            data[mIndex + 4] is EndCommandToken &&
                            CouldBeExpessionToken(data[mIndex + 1]) &&
                            CouldBeExpessionToken(data[mIndex + 2]) &&
                            CouldBeExpessionToken(data[mIndex + 3]))
                        {
                            CastToken castTok1 = new CastToken(ConvToExpressionToken(data[mIndex + 1]), new TypeToken("long"));
                            CastToken castTok2 = new CastToken(ConvToExpressionToken(data[mIndex + 2]), new TypeToken("long"));
                            CastToken castTok3 = new CastToken(ConvToExpressionToken(data[mIndex + 3]), new TypeToken("bool"));
                            
                            data[mIndex] = new DeleteComponentToken(
                                ConvToExpressionToken(castTok1),
                                ConvToExpressionToken(castTok2),
                                ConvToExpressionToken(castTok3));
                            data.RemoveAt(mIndex + 1);
                            data.RemoveAt(mIndex + 1);
                            data.RemoveAt(mIndex + 1);
                            data.RemoveAt(mIndex + 1);

                            change = true;
                            break;
                        }
                        #endregion


                        #region SET BASE COMP ATTR
                        else if (cTok is KeywordToken && mIndex + 5 < data.Count &&
                            (cTok as KeywordToken).Keyword.Equals("setBaseComponentAttr") &&
                            data[mIndex + 5] is EndCommandToken &&
                            CouldBeExpessionToken(data[mIndex + 1]) &&
                            CouldBeExpessionToken(data[mIndex + 2]) &&
                            CouldBeExpessionToken(data[mIndex + 3]) &&
                            CouldBeExpessionToken(data[mIndex + 4]))
                        {
                            CastToken castTok1 = new CastToken(ConvToExpressionToken(data[mIndex + 1]), new TypeToken("long"));
                            CastToken castTok2 = new CastToken(ConvToExpressionToken(data[mIndex + 2]), new TypeToken("long"));
                            AddStringIfPossible(ConvToExpressionToken(data[mIndex + 4]), stuff);

                            data[mIndex] = new SetBaseComponentAttrToken(
                                ConvToExpressionToken(castTok1),
                                ConvToExpressionToken(castTok2),
                                ConvToExpressionToken(data[mIndex + 3]),
                                ConvToExpressionToken(data[mIndex + 4]));
                            data.RemoveAt(mIndex + 1);
                            data.RemoveAt(mIndex + 1);
                            data.RemoveAt(mIndex + 1);
                            data.RemoveAt(mIndex + 1);
                            data.RemoveAt(mIndex + 1);

                            change = true;
                            break;
                        }
                        #endregion
                        #region GET BASE COMP ATTR
                        else if (cTok is KeywordToken && mIndex + 5 < data.Count &&
                            (cTok as KeywordToken).Keyword.Equals("getBaseComponentAttr") &&
                            data[mIndex + 5] is EndCommandToken &&
                            CouldBeExpessionToken(data[mIndex + 1]) &&
                            CouldBeExpessionToken(data[mIndex + 2]) &&
                            CouldBeExpessionToken(data[mIndex + 3]) &&
                            CouldBeExpessionToken(data[mIndex + 4]))
                        {
                            CastToken castTok1 = new CastToken(ConvToExpressionToken(data[mIndex + 1]), new TypeToken("long"));
                            CastToken castTok2 = new CastToken(ConvToExpressionToken(data[mIndex + 2]), new TypeToken("long"));

                            data[mIndex] = new GetBaseComponentAttrToken(
                                ConvToExpressionToken(castTok1),
                                ConvToExpressionToken(castTok2),
                                ConvToExpressionToken(data[mIndex + 3]),
                                ConvToExpressionToken(data[mIndex + 4]));
                            data.RemoveAt(mIndex + 1);
                            data.RemoveAt(mIndex + 1);
                            data.RemoveAt(mIndex + 1);
                            data.RemoveAt(mIndex + 1);
                            data.RemoveAt(mIndex + 1);

                            change = true;
                            break;
                        }
                        #endregion

                        #region SET SPEC COMP ATTR
                        else if (cTok is KeywordToken && mIndex + 5 < data.Count &&
                            (cTok as KeywordToken).Keyword.Equals("setSpecificComponentAttr") &&
                            data[mIndex + 5] is EndCommandToken &&
                            CouldBeExpessionToken(data[mIndex + 1]) &&
                            CouldBeExpessionToken(data[mIndex + 2]) &&
                            CouldBeExpessionToken(data[mIndex + 3]) &&
                            CouldBeExpessionToken(data[mIndex + 4]))
                        {
                            CastToken castTok1 = new CastToken(ConvToExpressionToken(data[mIndex + 1]), new TypeToken("long"));
                            CastToken castTok2 = new CastToken(ConvToExpressionToken(data[mIndex + 2]), new TypeToken("long"));
                            AddStringIfPossible(ConvToExpressionToken(data[mIndex + 4]), stuff);

                            data[mIndex] = new SetSpecificComponentAttrToken(
                                ConvToExpressionToken(castTok1),
                                ConvToExpressionToken(castTok2),
                                ConvToExpressionToken(data[mIndex + 3]),
                                ConvToExpressionToken(data[mIndex + 4]));
                            data.RemoveAt(mIndex + 1);
                            data.RemoveAt(mIndex + 1);
                            data.RemoveAt(mIndex + 1);
                            data.RemoveAt(mIndex + 1);
                            data.RemoveAt(mIndex + 1);

                            change = true;
                            break;
                        }
                        #endregion
                        #region GET SPEC COMP ATTR
                        else if (cTok is KeywordToken && mIndex + 5 < data.Count &&
                            (cTok as KeywordToken).Keyword.Equals("getSpecificComponentAttr") &&
                            data[mIndex + 5] is EndCommandToken &&
                            CouldBeExpessionToken(data[mIndex + 1]) &&
                            CouldBeExpessionToken(data[mIndex + 2]) &&
                            CouldBeExpessionToken(data[mIndex + 3]) &&
                            CouldBeExpessionToken(data[mIndex + 4]))
                        {
                            CastToken castTok1 = new CastToken(ConvToExpressionToken(data[mIndex + 1]), new TypeToken("long"));
                            CastToken castTok2 = new CastToken(ConvToExpressionToken(data[mIndex + 2]), new TypeToken("long"));

                            data[mIndex] = new GetSpecificComponentAttrToken(
                                ConvToExpressionToken(castTok1),
                                ConvToExpressionToken(castTok2),
                                ConvToExpressionToken(data[mIndex + 3]),
                                ConvToExpressionToken(data[mIndex + 4]));
                            data.RemoveAt(mIndex + 1);
                            data.RemoveAt(mIndex + 1);
                            data.RemoveAt(mIndex + 1);
                            data.RemoveAt(mIndex + 1);
                            data.RemoveAt(mIndex + 1);

                            change = true;
                            break;
                        }
                        #endregion

                        #region SET WINDOW SCREEN
                        else if (cTok is KeywordToken && mIndex + 3 < data.Count &&
                            (cTok as KeywordToken).Keyword.Equals("windowSetActiveScreen") &&
                            data[mIndex + 3] is EndCommandToken &&
                            CouldBeExpessionToken(data[mIndex + 1]))
                        {
                            CastToken castTok1 = new CastToken(ConvToExpressionToken(data[mIndex + 1]), new TypeToken("long"));
                            CastToken castTok2 = new CastToken(ConvToExpressionToken(data[mIndex + 2]), new TypeToken("long"));

                            data[mIndex] = new SetWindowActiveScreenToken(
                                ConvToExpressionToken(castTok1),
                                ConvToExpressionToken(castTok2));
                            data.RemoveAt(mIndex + 1);
                            data.RemoveAt(mIndex + 1);
                            data.RemoveAt(mIndex + 1);

                            change = true;
                            break;
                        }
                        #endregion
                        #region GET WINDOW SCREEN
                        else if (cTok is KeywordToken && mIndex + 3 < data.Count &&
                            (cTok as KeywordToken).Keyword.Equals("windowGetActiveScreen") &&
                            data[mIndex + 3] is EndCommandToken &&
                            CouldBeExpessionToken(data[mIndex + 1]))
                        {
                            CastToken castTok = new CastToken(ConvToExpressionToken(data[mIndex + 1]), new TypeToken("long"));

                            data[mIndex] = new GetWindowActiveScreenToken(ConvToExpressionToken(castTok),
                                ConvToExpressionToken(data[mIndex + 2]));
                            data.RemoveAt(mIndex + 1);
                            data.RemoveAt(mIndex + 1);
                            data.RemoveAt(mIndex + 1);

                            change = true;
                            break;
                        }
                        #endregion


                        #region READLINE
                        else if (cTok is KeywordToken && mIndex + 2 < data.Count &&
                            (cTok as KeywordToken).Keyword.Equals("readline") &&
                            data[mIndex + 2] is EndCommandToken &&
                            CouldBeExpessionToken(data[mIndex + 1]))
                        {
                            data[mIndex] = new ReadLineToken(ConvToExpressionToken(data[mIndex + 1]));
                            data.RemoveAt(mIndex + 1);
                            data.RemoveAt(mIndex + 1);

                            change = true;
                            break;
                        }
                        #endregion

                        #region POINTERS  INT**
                        // int*
                        if (cTok is TypeToken && mIndex + 1 < data.Count &&
                            data[mIndex + 1] is OperatorToken && (data[mIndex + 1] as OperatorToken).Operator == OperatorToken.OperatorEnum.Star)
                        {
                            (data[mIndex] as TypeToken).PointerCount++;
                            data.RemoveAt(mIndex + 1);
                            change = true;
                            break;
                        }
                        #endregion
                        #region CAST BRACKET
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
                        #endregion
                        #region SINGLE VALUE BRACKETS
                        // (5), (x), (test)
                        if (cTok is BracketOpenToken && mIndex + 2 < data.Count &&
                            data[mIndex + 2] is BracketCloseToken &&
                            (data[mIndex + 1] is BasicValueToken || data[mIndex + 1] is ExpressionToken ||
                            data[mIndex + 1] is GenericNameToken || data[mIndex + 1] is VarNameToken))
                        {
                            if (CouldBeExpessionToken(data[mIndex + 1]))
                                AddStringIfPossible(ConvToExpressionToken(data[mIndex + 1]), stuff);
                            data.RemoveAt(mIndex);
                            data.RemoveAt(mIndex + 1);
                            change = true;
                            break;
                        }
                        #endregion


                        #region VARIABLE NAMES
                        // x
                        if (cTok is GenericNameToken && (stuff.HasVarFromNameAndNamespace((cTok as GenericNameToken).NamespacePrefix, (cTok as GenericNameToken).Name)) &&
                            (mIndex < 1 || (!(data[mIndex - 1] is DoubleColonToken) && !(data[mIndex - 1] is NamespaceUseToken))))
                        {
                            DeclareVarToken tTok = stuff.GetVarFromNameAndNamespace((cTok as GenericNameToken).NamespacePrefix, (cTok as GenericNameToken).Name);
                            data[mIndex] = new VarNameToken(tTok.VarName, tTok.VarType, (cTok as GenericNameToken).NamespacePrefix);
                            change = true;
                            break;
                        }
                        #endregion
                        #region LOCATION NAMES
                        // location test:
                        // ...
                        //
                        // test
                        if (cTok is GenericNameToken && (stuff.HasLocFromNameAndNamespace((cTok as GenericNameToken).NamespacePrefix, (cTok as GenericNameToken).Name)) &&
                            (mIndex < 1 || (!(data[mIndex - 1] is DoubleColonToken) && !(data[mIndex - 1] is NamespaceUseToken))))
                        {
                            data[mIndex] = new LocationNameToken(stuff.GetLocFromNameAndNamespace((cTok as GenericNameToken).NamespacePrefix, (cTok as GenericNameToken).Name));
                            change = true;
                            break;
                        }
                        #endregion
                        #region SUBROUTINE NAMES
                        // subroutine testrout:
                        // ...
                        // ret;
                        //
                        // testrout
                        if (cTok is GenericNameToken && (stuff.HasSubFromNameAndNamespace((cTok as GenericNameToken).NamespacePrefix, (cTok as GenericNameToken).Name)) &&
                            (mIndex < 1 || (!(data[mIndex - 1] is DoubleColonToken) && !(data[mIndex - 1] is NamespaceUseToken))))
                        {
                            data[mIndex] = new SubroutineNameToken(stuff.GetSubFromNameAndNamespace((cTok as GenericNameToken).NamespacePrefix, (cTok as GenericNameToken).Name));
                            change = true;
                            break;
                        }
                        #endregion



                        #region JUMP
                        // jump TEST;
                        if (cTok is KeywordToken && ((cTok as KeywordToken).Keyword.Equals("jump")) && mIndex + 2 < data.Count &&
                            (data[mIndex + 1] is LocationNameToken || CouldBeExpessionToken(data[mIndex + 1])) && data[mIndex + 2] is EndCommandToken)
                        {
                            if (data[mIndex + 1] is LocationNameToken)
                                data[mIndex] = new FixedJumpToken(data[mIndex + 1] as LocationNameToken);
                            else
                            {
                                AddStringIfPossible(ConvToExpressionToken(data[mIndex + 1]), stuff);
                                data[mIndex] = new FixedJumpToken(new LocationNameToken(ConvToExpressionToken(data[mIndex + 1])));
                            }


                            data.RemoveAt(mIndex + 1);
                            data.RemoveAt(mIndex + 1);
                            change = true;
                            break;
                        }
                        #endregion
                        #region SUB
                        // sub TEST;
                        if (cTok is KeywordToken && ((cTok as KeywordToken).Keyword.Equals("sub")) && mIndex + 2 < data.Count &&
                            data[mIndex + 1] is SubroutineNameToken && data[mIndex + 2] is EndCommandToken)
                        {
                            data[mIndex] = new FixedJumpToken(data[mIndex + 1] as SubroutineNameToken);

                            data.RemoveAt(mIndex + 1);
                            data.RemoveAt(mIndex + 1);
                            change = true;
                            break;
                        }
                        #endregion

                        #region IF_JUMP
                        // if_jump (1==1) 10;
                        if (cTok is KeywordToken && ((cTok as KeywordToken).Keyword.Equals("if_jump")) && mIndex + 3 < data.Count &&
                            CouldBeExpessionToken(data[mIndex + 1]) &&
                            (data[mIndex + 2] is LocationNameToken || CouldBeExpessionToken(data[mIndex + 2])) &&
                            data[mIndex + 3] is EndCommandToken)
                        {
                            LocationNameToken loc = null;
                            if (data[mIndex + 2] is LocationNameToken)
                                loc = data[mIndex + 2] as LocationNameToken;
                            else
                            {
                                loc = new LocationNameToken(ConvToExpressionToken(data[mIndex + 2]));
                                AddStringIfPossible(ConvToExpressionToken(data[mIndex + 2]), stuff);
                            }


                            data[mIndex] = new ConditionalJumpToken(ConvToExpressionToken(data[mIndex + 1]), loc);
                            AddStringIfPossible(ConvToExpressionToken(data[mIndex + 1]), stuff);

                            data.RemoveAt(mIndex + 1);
                            data.RemoveAt(mIndex + 1);
                            data.RemoveAt(mIndex + 1);
                            change = true;
                            break;
                        }
                        #endregion
                        #region IF_SUB
                        // if_sub (x==x) bruh;
                        if (cTok is KeywordToken && ((cTok as KeywordToken).Keyword.Equals("if_sub")) && mIndex + 3 < data.Count &&
                            CouldBeExpessionToken(data[mIndex + 1]) &&
                            (data[mIndex + 2] is SubroutineNameToken) &&
                            data[mIndex + 3] is EndCommandToken)
                        {
                            data[mIndex] = new ConditionalJumpToken(ConvToExpressionToken(data[mIndex + 1]), data[mIndex + 2] as SubroutineNameToken);
                            AddStringIfPossible(ConvToExpressionToken(data[mIndex + 1]), stuff);
                            data.RemoveAt(mIndex + 1);
                            data.RemoveAt(mIndex + 1);
                            data.RemoveAt(mIndex + 1);
                            change = true;
                            break;
                        }
                        #endregion

                        #region DEREF EXPR
                        //*test
                        if (cTok is OperatorToken && ((cTok as OperatorToken).Operator == OperatorToken.OperatorEnum.Star) &&
                            mIndex + 1 < data.Count &&
                            CouldBeExpessionToken(data[mIndex + 1]) &&
                            (mIndex == 0 || !CouldBeExpessionToken(data[mIndex - 1])))
                        {
                            data[mIndex] = new DerefToken(ConvToExpressionToken(data[mIndex + 1]));
                            data.RemoveAt(mIndex + 1);
                            change = true;
                            break;
                        }
                        #endregion
                        #region GET ADDRESS
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
                        #endregion


                        #region BOOL-NOT AND BIT-NOT
                        foreach (OperatorToken.OperatorEnum cOp in OpOrderArr1)
                        {
                            //!test
                            if (cTok is OperatorToken && ((cTok as OperatorToken).Operator == cOp) && mIndex + 1 < data.Count &&
                                CouldBeExpessionToken(data[mIndex + 1]))
                            {
                                ExpressionToken tTok = ConvToExpressionToken(data[mIndex + 1]);
                                AddStringIfPossible(tTok, stuff);

                                data[mIndex] = new ExpressionToken(new OperatorToken(cOp), tTok);
                                data.RemoveAt(mIndex + 1);
                                change = true;
                                break;
                            }
                        }
                        #endregion


                        #region NEGATIVE NUMBERS
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
                        #endregion
                        #region NEGATIVE EXPRESSIONS
                        // -x
                        if (cTok is OperatorToken && mIndex + 1 < data.Count &&
                            (cTok as OperatorToken).Operator == OperatorToken.OperatorEnum.Minus &&
                            (mIndex < 1 || !CouldBeExpessionToken(data[mIndex - 1])) &&
                            CouldBeExpessionToken(data[mIndex + 1]) &&
                            (mIndex + 2 >= data.Count || !CouldBeExpessionToken(data[mIndex + 2]))
                            )
                        // data[mIndex - 1] data[mIndex + 1]  data[mIndex + 2]
                        {
                            ExpressionToken valTok = ConvToExpressionToken(data[mIndex + 1]);
                            ExpressionToken minusTok = new ExpressionToken(new ExpressionToken(new BasicValueToken(0)), new OperatorToken(OperatorToken.OperatorEnum.Minus), valTok);
                            data[mIndex + 1] = minusTok;
                            data.RemoveAt(mIndex);
                            change = true;
                            break;
                        }
                        #endregion


                        #region MULTI VALUE BRACKETS
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


                            //GlobalStuff.WriteLine("\n\n<START>");

                            //GlobalStuff.WriteLine("Input Tokens:");
                            List<Token> tempList = new List<Token>();
                            data.RemoveAt(mIndex);
                            for (int x = mIndex + 1; x < tIndex; x++)
                            {
                                //GlobalStuff.WriteLine($" - {data[mIndex]}");
                                tempList.Add(data[mIndex]);
                                data.RemoveAt(mIndex);
                            }
                            //GlobalStuff.WriteLine();

                            ParsedStuff tempParsedStuff = new ParsedStuff();
                            foreach (var thingy in stuff.Variables)
                                tempParsedStuff.Variables.Add(thingy);
                            ParseStringAdvanced(tempList, tempParsedStuff);
                            stuff.Strings.AddRange(tempParsedStuff.Strings);


                            if (tempParsedStuff.parsedTokens[0] is TypeToken)
                                tempParsedStuff.parsedTokens[0] = new CastTypeToken(tempParsedStuff.parsedTokens[0] as TypeToken);

                            //GlobalStuff.WriteLine("Token Result:");
                            //foreach (Token token in tempParsedStuff.other)
                            //    GlobalStuff.WriteLine($" - {token}");


                            //GlobalStuff.WriteLine("<END>");
                            //GlobalStuff.ReadLine();

                            if (tempParsedStuff.parsedTokens.Count != 1)
                                throw new Exception($"COUNT IS NOT 1");



                            data[mIndex] = tempParsedStuff.parsedTokens[0];

                            change = true;
                            break;
                        }
                        #endregion
                        #region FREESTANDING EXPRESSION    1 + b
                        // a (OP) b
                        //foreach (OperatorToken.OperatorEnum currentOp in OpOrderArr2)
                        {
                            if (cTok is OperatorToken && mIndex > 0 && mIndex + 1 < data.Count &&
                                ((cTok as OperatorToken).Operator == currentOp) &&
                                CouldBeExpessionToken(data[mIndex - 1]) &&
                                CouldBeExpessionToken(data[mIndex + 1])
                                )
                            {
                                ExpressionToken lTok = ConvToExpressionToken(data[mIndex - 1]);
                                ExpressionToken rTok = ConvToExpressionToken(data[mIndex + 1]);
                                AddStringIfPossible(lTok, stuff);
                                AddStringIfPossible(rTok, stuff);

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
                        #endregion
                        #region CASTING VALUE
                        // (int)10
                        if (cTok is CastTypeToken && mIndex + 1 < data.Count &&
                            CouldBeExpessionToken(data[mIndex + 1]))
                        {
                            ExpressionToken exprTok = ConvToExpressionToken(data[mIndex + 1]);
                            AddStringIfPossible(exprTok, stuff);

                            data[mIndex] = new ExpressionToken(new CastToken(exprTok, (cTok as CastTypeToken).CastType));
                            data.RemoveAt(mIndex + 1);
                            change = true;
                            break;
                        }
                        #endregion

                        #region SYSCALL
                        else if (cTok is KeywordToken && mIndex + 1 < data.Count &&
                            (cTok as KeywordToken).Keyword.Equals("syscall"))
                        {
                            bool syscallReady = true;
                            int argumentCount = 0;
                            while (mIndex + argumentCount + 1 < data.Count &&
                                !(data[mIndex + argumentCount + 1] is EndCommandToken))
                            {
                                if (!CouldBeExpessionToken(data[mIndex + argumentCount + 1]))
                                {
                                    syscallReady = false;
                                    break;
                                }
                                AddStringIfPossible(ConvToExpressionToken(data[mIndex + argumentCount + 1]), stuff);

                                argumentCount++;
                            }

                            //GlobalStuff.WriteLine($"SYSCALL: ARGS: {argumentCount}, READY: {syscallReady}, {cTok}");

                            if (syscallReady && argumentCount > 0 &&
                                mIndex + argumentCount + 1 < data.Count)
                            {
                                List<ExpressionToken> args = new List<ExpressionToken>();
                                for (int i = 0; i < argumentCount; i++)
                                    args.Add(ConvToExpressionToken(data[mIndex + 1 + i]));

                                data[mIndex] = new SyscallToken(args);
                                for (int i = 0; i < argumentCount + 1; i++)
                                    data.RemoveAt(mIndex + 1);

                                change = true;
                                break;
                            }
                        }
                        #endregion


                        #region SIMPLE VAR DEFINITON   INT X;
                        // int x;
                        if (cTok is TypeToken && mIndex + 2 < data.Count &&
                            (data[mIndex + 1] is GenericNameToken) && (data[mIndex + 2] is EndCommandToken))
                        {
                            string varName = (data[mIndex + 1] as GenericNameToken).Name;
                            DeclareVarToken tok = new DeclareVarToken(varName, (data[mIndex] as TypeToken), (data[mIndex + 1] as GenericNameToken).NamespacePrefix);

                            stuff.Variables.Add(tok);

                            data.RemoveAt(mIndex);
                            data.RemoveAt(mIndex);
                            data.RemoveAt(mIndex);
                            change = true;
                            break;
                        }
                        #endregion
                        #region ADVANCED VAR DEFINITION      INT X = 0;
                        // int x = 0; int y = a; int z = (1+2);
                        if (cTok is TypeToken && mIndex + 4 < data.Count &&
                            (data[mIndex + 1] is GenericNameToken) && (data[mIndex + 4] is EndCommandToken) &&
                            (data[mIndex + 2] is OperatorToken) && (data[mIndex + 2] as OperatorToken).Operator == OperatorToken.OperatorEnum.Set &&
                            CouldBeExpessionToken(data[mIndex + 3]))
                        {
                            string varName = (data[mIndex + 1] as GenericNameToken).Name;
                            DeclareVarToken tok = new DeclareVarToken(
                                varName,
                                (data[mIndex] as TypeToken),
                                (data[mIndex + 1] as GenericNameToken).NamespacePrefix);

                            stuff.Variables.Add(tok);

                            data.RemoveAt(mIndex);
                            change = true;
                            break;
                        }
                        #endregion
                        #region SET VAR       X = 10;
                        // x = 10; y = (1+2);
                        if (cTok is VarNameToken && mIndex + 3 < data.Count &&
                            (data[mIndex + 3] is EndCommandToken) &&
                            (data[mIndex + 1] is OperatorToken) && (data[mIndex + 1] as OperatorToken).Operator == OperatorToken.OperatorEnum.Set &&
                            CouldBeExpessionToken(data[mIndex + 2]))
                        {
                            string varName = (cTok as VarNameToken).VarName;

                            ExpressionToken exprTok = ConvToExpressionToken(data[mIndex + 2]);
                            AddStringIfPossible(exprTok, stuff);
                            SetVarToken tok = new SetVarToken(cTok as VarNameToken, exprTok);

                            data[mIndex] = tok;
                            data.RemoveAt(mIndex + 1);
                            data.RemoveAt(mIndex + 1);
                            data.RemoveAt(mIndex + 1);
                            change = true;
                            break;
                        }
                        #endregion
                        #region OLD SET VAR
                        /*
                        
                        #region SET VAR       X = 10;
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
                        #endregion

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
                        */
                        #endregion
                        #region SET MEM DIRECTLY    ((ulong)10) = 5;
                        // 10 = 5;
                        if ((cTok is OperatorToken) && (cTok as OperatorToken).Operator == OperatorToken.OperatorEnum.Set &&
                            mIndex + 2 < data.Count && mIndex > 0 &&
                            (data[mIndex + 2] is EndCommandToken) &&
                            (CouldBeExpessionToken(data[mIndex - 1])) &&
                            CouldBeExpessionToken(data[mIndex + 1]))
                        {
                            ExpressionToken exprTok = ConvToExpressionToken(data[mIndex + 1]);
                            AddStringIfPossible(exprTok, stuff);
                            SetVarToken tok = new SetVarToken(ConvToExpressionToken(data[mIndex - 1]), exprTok);
                            AddStringIfPossible(ConvToExpressionToken(data[mIndex - 1]), stuff);

                            data[mIndex] = tok;
                            data.RemoveAt(mIndex + 1);
                            data.RemoveAt(mIndex + 1);
                            data.RemoveAt(mIndex - 1);
                            change = true;
                            break;
                        }
                        #endregion

                        #region INCREMENT AND DECREMENT
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
                                    new ExpressionToken(new CastToken(new ExpressionToken(new BasicValueToken(1)), (data[mIndex - 1] as VarNameToken).VarType))
                                    )
                                );

                            mIndex--;
                            data[mIndex] = tok;
                            data.RemoveAt(mIndex + 1);
                            data.RemoveAt(mIndex + 1);
                            change = true;
                            break;
                        }
                        #endregion
                        #region OPEQUALS     Y += 5;
                        // x   +=   5 ;
                        // -1  0    1 2
                        if (cTok is OperatorToken && mIndex > 0 && mIndex + 3 < data.Count &&
                            data[mIndex - 1] is VarNameToken && data[mIndex + 2] is EndCommandToken &&
                            CouldBeExpessionToken(data[mIndex + 1]) &&
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

                            ExpressionToken exprTok = ConvToExpressionToken(data[mIndex + 1]);
                            AddStringIfPossible(exprTok, stuff);

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
                        #endregion


                        #region WHILE
                        // while (x) {}
                        else if (cTok is KeywordToken && (cTok as KeywordToken).Keyword.Equals("while") &&
                            mIndex + 3 < data.Count && CouldBeExpessionToken(data[mIndex + 1]) &&
                            data[mIndex + 2] is CurlyBracketOpenToken)
                        {
                            int sIndex = mIndex + 2;
                            int eIndex = -1;
                            int layer = 1;
                            for (int i = sIndex + 1; layer > 0 && i < data.Count; i++)
                            {
                                if (data[i] is CurlyBracketOpenToken)
                                    layer++;
                                if (data[i] is CurlyBracketCloseToken)
                                    layer--;
                                if (layer == 0)
                                    eIndex = i;
                            }
                            if (layer != 0)
                                throw new Exception($"CURLY BRACKET WAS NOT CLOSED! {cTok}");
                            string basePref = cTok.NamespacePrefix;

                            string baseLabelId = $"GENERATED_LABEL_WHILE_{GenIdCounter++}_";

                            string labelEnd = baseLabelId + "END";
                            string labelLoop = baseLabelId + "LOOP";


                            var endLoc = new DefineLocationToken(labelEnd, basePref);
                            var loopLoc = new DefineLocationToken(labelLoop, basePref);
                            data.Insert(eIndex + 1, endLoc);
                            data[eIndex] = new FixedJumpToken(new LocationNameToken(loopLoc));


                            data[sIndex] = new ConditionalJumpToken(new ExpressionToken(
                                new OperatorToken(OperatorToken.OperatorEnum.Not), ConvToExpressionToken(data[mIndex + 1])),
                                new LocationNameToken(endLoc));
                            data[sIndex - 1] = loopLoc;
                            data.RemoveAt(mIndex);

                            change = true;
                            break;
                        }
                        #endregion
                        #region IF
                        // if (x) {}
                        else if (cTok is KeywordToken && (cTok as KeywordToken).Keyword.Equals("if") &&
                            mIndex + 3 < data.Count && CouldBeExpessionToken(data[mIndex + 1]) &&
                            data[mIndex + 2] is CurlyBracketOpenToken)
                        {
                            int sIndex = mIndex + 2;
                            int eIndex = -1;
                            int layer = 1;
                            for (int i = sIndex + 1; layer > 0 && i < data.Count; i++)
                            {
                                if (data[i] is CurlyBracketOpenToken)
                                    layer++;
                                if (data[i] is CurlyBracketCloseToken)
                                    layer--;
                                if (layer == 0)
                                    eIndex = i;
                            }
                            if (layer != 0)
                                throw new Exception($"CURLY BRACKET WAS NOT CLOSED! {cTok}");
                            string basePref = cTok.NamespacePrefix;

                            string baseLabelId = $"GENERATED_LABEL_IF_{GenIdCounter++}_";

                            string labelEnd = baseLabelId + "END";

                            var endLoc = new DefineLocationToken(labelEnd, basePref);
                            data[eIndex] = endLoc;


                            data[mIndex] = new ConditionalJumpToken(new ExpressionToken(
                                new OperatorToken(OperatorToken.OperatorEnum.Not), ConvToExpressionToken(data[mIndex + 1])),
                                new LocationNameToken(endLoc));
                            //data[sIndex - 1] = loopLoc;
                            data.RemoveAt(mIndex + 1);
                            data.RemoveAt(mIndex + 1);

                            change = true;
                            break;
                        }
                        #endregion



                    }
                    if (change)
                        break;

                }


            }

            #region OPTIMIZATIONS
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
                    if (cTok is SetVarToken && ParserHelpers.TryOptimizeExpressionToken((cTok as SetVarToken).SetExpression))
                    {
                        change = true;
                        break;
                    }
                    if (cTok is SetVarToken && (cTok as SetVarToken).SetLocation && ParserHelpers.TryOptimizeExpressionToken((cTok as SetVarToken).VarLocation))
                    {
                        change = true;
                        break;
                    }
                    if (cTok is SleepToken && ParserHelpers.TryOptimizeExpressionToken((cTok as SleepToken).Duration))
                    {
                        change = true;
                        break;
                    }

                    if (cTok is CreateWindowToken && ParserHelpers.TryOptimizeExpressionToken((cTok as CreateWindowToken).WindowID))
                    {
                        change = true;
                        break;
                    }
                    if (cTok is DeleteWindowToken && ParserHelpers.TryOptimizeExpressionToken((cTok as DeleteWindowToken).WindowID))
                    {
                        change = true;
                        break;
                    }

                    if (cTok is CreateComponentToken && (
                        ParserHelpers.TryOptimizeExpressionToken((cTok as CreateComponentToken).WindowID) ||
                        ParserHelpers.TryOptimizeExpressionToken((cTok as CreateComponentToken).CompID) ||
                        ParserHelpers.TryOptimizeExpressionToken((cTok as CreateComponentToken).ParentID)))
                    {
                        change = true;
                        break;
                    }

                    if (cTok is DeleteComponentToken && (
                        ParserHelpers.TryOptimizeExpressionToken((cTok as DeleteComponentToken).WindowID) ||
                        ParserHelpers.TryOptimizeExpressionToken((cTok as DeleteComponentToken).CompID) ||
                        ParserHelpers.TryOptimizeExpressionToken((cTok as DeleteComponentToken).DeleteChildren)))
                    {
                        change = true;
                        break;
                    }

                    if (cTok is SetWindowAttrToken && (
                        ParserHelpers.TryOptimizeExpressionToken((cTok as SetWindowAttrToken).WindowID) ||
                        ParserHelpers.TryOptimizeExpressionToken((cTok as SetWindowAttrToken).Value) ||
                        ParserHelpers.TryOptimizeExpressionToken((cTok as SetWindowAttrToken).AttrType)
                        ))
                    {
                        change = true;
                        break;
                    }
                    if (cTok is GetWindowAttrToken && (
                        ParserHelpers.TryOptimizeExpressionToken((cTok as GetWindowAttrToken).WindowID) ||
                        ParserHelpers.TryOptimizeExpressionToken((cTok as GetWindowAttrToken).WriteTo) ||
                        ParserHelpers.TryOptimizeExpressionToken((cTok as GetWindowAttrToken).AttrType)
                        ))
                    {
                        change = true;
                        break;
                    }

                    if (cTok is SetWindowActiveScreenToken && (
                        ParserHelpers.TryOptimizeExpressionToken((cTok as SetWindowActiveScreenToken).WindowID) ||
                        ParserHelpers.TryOptimizeExpressionToken((cTok as SetWindowActiveScreenToken).ScreenID)
                        ))
                    {
                        change = true;
                        break;
                    }
                    if (cTok is GetWindowActiveScreenToken && (
                        ParserHelpers.TryOptimizeExpressionToken((cTok as GetWindowActiveScreenToken).WindowID) ||
                        ParserHelpers.TryOptimizeExpressionToken((cTok as GetWindowActiveScreenToken).WriteTo) 
                        ))
                    {
                        change = true;
                        break;
                    }

                    if (cTok is GetMouseStateToken && (
                        ParserHelpers.TryOptimizeExpressionToken((cTok as GetMouseStateToken).State) ||
                        ParserHelpers.TryOptimizeExpressionToken((cTok as GetMouseStateToken).WriteTo)))
                    {
                        change = true;
                        break;
                    }

                    if (cTok is GetKeyboardStateToken && (
                        ParserHelpers.TryOptimizeExpressionToken((cTok as GetKeyboardStateToken).Scancode) ||
                        ParserHelpers.TryOptimizeExpressionToken((cTok as GetKeyboardStateToken).WriteTo)))
                    {
                        change = true;
                        break;
                    }


                    if (cTok is SetBaseComponentAttrToken && (
                        ParserHelpers.TryOptimizeExpressionToken((cTok as SetBaseComponentAttrToken).WindowID) ||
                        ParserHelpers.TryOptimizeExpressionToken((cTok as SetBaseComponentAttrToken).CompID) ||
                        ParserHelpers.TryOptimizeExpressionToken((cTok as SetBaseComponentAttrToken).Value) ||
                        ParserHelpers.TryOptimizeExpressionToken((cTok as SetBaseComponentAttrToken).AttrType)
                        ))
                    {
                        change = true;
                        break;
                    }
                    if (cTok is GetBaseComponentAttrToken && (
                        ParserHelpers.TryOptimizeExpressionToken((cTok as GetBaseComponentAttrToken).WindowID) ||
                        ParserHelpers.TryOptimizeExpressionToken((cTok as GetBaseComponentAttrToken).CompID) ||
                        ParserHelpers.TryOptimizeExpressionToken((cTok as GetBaseComponentAttrToken).WriteTo) ||
                        ParserHelpers.TryOptimizeExpressionToken((cTok as GetBaseComponentAttrToken).AttrType)
                        ))
                    {
                        change = true;
                        break;
                    }

                    if (cTok is SetSpecificComponentAttrToken && (
                        ParserHelpers.TryOptimizeExpressionToken((cTok as SetSpecificComponentAttrToken).WindowID) ||
                        ParserHelpers.TryOptimizeExpressionToken((cTok as SetSpecificComponentAttrToken).CompID) ||
                        ParserHelpers.TryOptimizeExpressionToken((cTok as SetSpecificComponentAttrToken).Value) ||
                        ParserHelpers.TryOptimizeExpressionToken((cTok as SetSpecificComponentAttrToken).AttrType)
                        ))
                    {
                        change = true;
                        break;
                    }
                    if (cTok is GetSpecificComponentAttrToken && (
                        ParserHelpers.TryOptimizeExpressionToken((cTok as GetSpecificComponentAttrToken).WindowID) ||
                        ParserHelpers.TryOptimizeExpressionToken((cTok as GetSpecificComponentAttrToken).CompID) ||
                        ParserHelpers.TryOptimizeExpressionToken((cTok as GetSpecificComponentAttrToken).WriteTo) ||
                        ParserHelpers.TryOptimizeExpressionToken((cTok as GetSpecificComponentAttrToken).AttrType)
                        ))
                    {
                        change = true;
                        break;
                    }





                    if (cTok is CastToken && ParserHelpers.TryOptimizeExpressionToken((cTok as CastToken).ToCast))
                    {
                        change = true;
                        break;
                    }
                    if (cTok is ExpressionToken && ParserHelpers.TryOptimizeExpressionToken(cTok as ExpressionToken))
                    {
                        change = true;
                        break;
                    }
                    if (cTok is LocationNameToken && (cTok as LocationNameToken).JumpToFixedAddress &&
ParserHelpers.TryOptimizeExpressionToken((cTok as LocationNameToken).Address))
                    {
                        change = true;
                        break;
                    }
                    if (cTok is FixedJumpToken && (cTok as FixedJumpToken).IsLocation && (cTok as FixedJumpToken).Location.JumpToFixedAddress
                        && ParserHelpers.TryOptimizeExpressionToken((cTok as FixedJumpToken).Location.Address))
                    {
                        change = true;
                        break;
                    }
                    if (cTok is ConditionalJumpToken && (cTok as ConditionalJumpToken).IsLocation && (cTok as ConditionalJumpToken).Location.JumpToFixedAddress
                        && ParserHelpers.TryOptimizeExpressionToken((cTok as ConditionalJumpToken).Location.Address))
                    {
                        change = true;
                        break;
                    }
                    if (cTok is SyscallToken)
                    {
                        SyscallToken sTok = cTok as SyscallToken;
                        for (int i = 0; i < sTok.Arguments.Count; i++)
                            change |= ParserHelpers.TryOptimizeExpressionToken(sTok.Arguments[i]);
                        if (change)
                            break;
                    }
                    if (cTok is PrintToken && ParserHelpers.TryOptimizeExpressionToken((cTok as PrintToken).Argument))
                    {
                        change = true;
                        break;
                    }
                }
            }
            #endregion


            stuff.parsedTokens.AddRange(data);
            return stuff;
        }

        #region Convert String To Token
        public static Token ConvertStringToToken(string str)
        {
            if (TypeToken.IsType(str))
                return new TypeToken(str);

            if (KeywordToken.KeywordList.Contains(str))
                return new KeywordToken(str);

            if (str.Length > 2 && str.Length % 2 == 0 && str[0] == '0' && str[1] == 'x')
            {
                string str2 = str.Substring(2);
                if (str2.Length == 2 && byte.TryParse(str2, NumberStyles.HexNumber, null, out byte val8)) // ubyte
                    return new BasicValueToken(val8);
                else if (str2.Length == 4 && ushort.TryParse(str2, NumberStyles.HexNumber, null, out ushort val16)) // ushort
                    return new BasicValueToken(val16);
                else if (str2.Length == 8 && uint.TryParse(str2, NumberStyles.HexNumber, null, out uint val32)) // uint
                    return new BasicValueToken(val32);
                else if (str2.Length == 16 && ulong.TryParse(str2, NumberStyles.HexNumber, null, out ulong val64)) // ulong
                    return new BasicValueToken(val64);
            }

            if (str.Length > 1 && str[str.Length - 1] == 'd' && double.TryParse(str.Substring(0, str.Length - 1), NumberStyles.Float, CultureInfo.InvariantCulture, out double vD))
                return new BasicValueToken(vD);
            if (str.Length > 1 && str[str.Length - 1] == 'f' && float.TryParse(str.Substring(0, str.Length - 1), NumberStyles.Float, CultureInfo.InvariantCulture, out float vF2))
                return new BasicValueToken(vF2);
            if (str.Length > 1 && str[str.Length - 1] == 'c' && int.TryParse(str.Substring(0, str.Length - 1), NumberStyles.Integer, CultureInfo.InvariantCulture, out int vC2))
                return new BasicValueToken((char)vC2);


            if (str.Length > 2 && str[str.Length - 2] == 'u' && str[str.Length - 1] == 'i' &&
                uint.TryParse(str.Substring(0, str.Length - 2), NumberStyles.Integer, CultureInfo.InvariantCulture,
                out uint vUI2))
                return new BasicValueToken(vUI2);

            if (str.Length > 2 && str[str.Length - 2] == 'u' && str[str.Length - 1] == 's' &&
                ushort.TryParse(str.Substring(0, str.Length - 2), NumberStyles.Integer, CultureInfo.InvariantCulture,
                out ushort vUS2))
                return new BasicValueToken(vUS2);

            if (str.Length > 2 && str[str.Length - 2] == 'u' && str[str.Length - 1] == 'l' &&
                ulong.TryParse(str.Substring(0, str.Length - 2), NumberStyles.Integer, CultureInfo.InvariantCulture,
                out ulong vUL2))
                return new BasicValueToken(vUL2);



            if (str.Length > 1 && str[str.Length - 1] == 'i' && 
                int.TryParse(str.Substring(0, str.Length - 1), NumberStyles.Integer, CultureInfo.InvariantCulture, 
                out int vI2))
                return new BasicValueToken(vI2);
            if (str.Length > 1 && str[str.Length - 1] == 's' &&
                short.TryParse(str.Substring(0, str.Length - 1), NumberStyles.Integer, CultureInfo.InvariantCulture,
                out short vS2))
                return new BasicValueToken(vS2);

            if (str.Length > 1 && str[str.Length - 1] == 'l' &&
                long.TryParse(str.Substring(0, str.Length - 1), NumberStyles.Integer, CultureInfo.InvariantCulture,
                out long vL2))
                return new BasicValueToken(vL2);



            if (!str.Contains(".") && int.TryParse(str, NumberStyles.Number, CultureInfo.InvariantCulture, out int vI))
                return new BasicValueToken(vI);
            if (!str.Contains(".") && long.TryParse(str, NumberStyles.Number, CultureInfo.InvariantCulture, out long vL))
                return new BasicValueToken(vL);
            if (float.TryParse(str, NumberStyles.Float, CultureInfo.InvariantCulture, out float vF))
                return new BasicValueToken(vF);
            if (str.ToLower().Equals("true"))
                return new BasicValueToken(true);
            if (str.ToLower().Equals("false"))
                return new BasicValueToken(false);

            return new GenericNameToken(str);
        }
        #endregion

        #region BASIC PARSER / LEXER
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
                else if (tChar == '{')
                {
                    if (tempString != "")
                        tokens.Add(ConvertStringToToken(tempString));
                    tempString = "";
                    tokens.Add(new CurlyBracketOpenToken());
                }
                else if (tChar == '}')
                {
                    if (tempString != "")
                        tokens.Add(ConvertStringToToken(tempString));
                    tempString = "";
                    tokens.Add(new CurlyBracketCloseToken());
                }
                else if (tChar == ':')
                {
                    if (tempString != "")
                        tokens.Add(ConvertStringToToken(tempString));
                    tempString = "";
                    if (mIndex + 1 < len && data[mIndex + 1] == ':')
                    {
                        tokens.Add(new DoubleColonToken());
                        mIndex++;
                    }
                    else
                        tokens.Add(new ColonToken());
                }
                else if (tChar == '"')
                {
                    if (tempString != "")
                        tokens.Add(ConvertStringToToken(tempString));
                    tempString = "";

                    string tempCharPointerString = "";
                    for (mIndex++; mIndex < len && data[mIndex] != '"'; mIndex++)
                        if (data[mIndex] == '\\' && mIndex + 1 < len)
                        {
                            mIndex++;
                            if (data[mIndex] == 'n')
                            {
                                tempCharPointerString += '\n';
                            }
                            else
                                tempCharPointerString += data[mIndex];
                        }
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
        #endregion
    }
}
