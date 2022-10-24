using System;
using System.Collections.Generic;
using System.Globalization;

namespace MAAL.Parsing
{
    public class Token
    {
        public override string ToString()
            => $"<Generic Token>";
    }
    public class EndCommandToken : Token
    {
        public override string ToString()
            => $"<;>";
    }
    public class OperatorToken : Token
    {
        public enum OperatorEnum
        {
            Plus,
            Minus,
            Star,
            Divide,
            Mod,
            Equal,
            NotEqual,
            Greater,
            Less,
            GreaterEqual,
            LessEqual,
            And,
            Or,
            Not,
            BitAnd,
            BitOr,
            BitNot,
            BitShiftLeft,
            BitShiftRight,
            Increment,
            Decrement,
            Unknown,
            Set,
            PlusEquals,
            MinusEquals,
            TimesEquals,
            DivideEquals,
            ModEquals,
        }
        public static Dictionary<string, OperatorEnum> OpStringDict = new Dictionary<string, OperatorEnum>
            {
            {"+",  OperatorEnum.Plus},           {"++", OperatorEnum.Increment},    {"=",  OperatorEnum.Set},
            {"-",  OperatorEnum.Minus},          {"--", OperatorEnum.Decrement},
            {"*",  OperatorEnum.Star},           {"/",  OperatorEnum.Divide},       {"%",  OperatorEnum.Mod},
            {">",  OperatorEnum.Greater},        {"<",  OperatorEnum.Less},         {"!=", OperatorEnum.NotEqual},
            {"==", OperatorEnum.Equal},          {">=", OperatorEnum.GreaterEqual}, {"<=", OperatorEnum.LessEqual},
            {"&&", OperatorEnum.And},            {"||", OperatorEnum.Or},           {"!",  OperatorEnum.Not},
            {"&",  OperatorEnum.BitAnd},         {"|",  OperatorEnum.BitOr},        {"~",  OperatorEnum.BitNot},
            {">>", OperatorEnum.BitShiftRight},  {"<<", OperatorEnum.BitShiftLeft},
            {"+=", OperatorEnum.PlusEquals},     {"-=", OperatorEnum.MinusEquals},  {"%=", OperatorEnum.ModEquals},
            {"*=", OperatorEnum.TimesEquals},    {"/=", OperatorEnum.DivideEquals},
            };
        public static int maxOpLen = 2;
        public static string uniqueOpCharList = "+-*/%<>=&|!~";

        public OperatorToken(OperatorEnum @operator)
            => Operator = @operator;

        public OperatorToken(string op)
        {
            Operator = OperatorEnum.Unknown;
            if (OpStringDict.TryGetValue(op, out OperatorEnum opEnum))
                Operator = opEnum;
        }

        public override string ToString()
            => $"<O {Operator}>";

        public OperatorEnum Operator;
    }

    public class KeywordToken : Token
    {
        public static List<string> KeywordList = new List<string>()
        {
            "if_jump", "__TEST__"
        };

        public string Keyword = "";
        public bool IsValid = false;

        public KeywordToken(string str)
        {
            if (KeywordList.Contains(str))
            {
                Keyword = str;
                IsValid = true;
            }
        }

        public override string ToString()
            => $"<K {Keyword}>";
    }

    public class TypeToken : Token
    {
        public static List<string> TypeList = new List<string>()
        {
            "int", "long", "float", "double", "ulong", "byte", "char", "bool"
        };

        public string BaseType = String.Empty;
        public int PointerCount = 0;
        public bool IsValid = false;

        public static bool IsType(string str)
            => TypeList.Contains(str.TrimEnd('*'));

        public TypeToken(string str)
        {
            string baseStr = str.TrimEnd('*');
            PointerCount = str.Length - baseStr.Length;
            IsValid = TypeList.Contains(baseStr);
            if (IsValid)
                BaseType = baseStr;
        }

        public override string ToString()
            => $"<T {BaseType}{new String('*', PointerCount)}>";
    }

    public class BasicValueToken : Token
    {
        public enum BasicValueTypeEnum
        {
            INT,
            LONG,
            FLOAT,
            CHAR,
            CHAR_POINTER,
            BOOL
        }

        public BasicValueTypeEnum ValueType;

        public int Value_Int = 0;
        public long Value_Long = 0;
        public float Value_Float = 0;
        public char Value_Char = (char)0;
        public string Value_CharPointer = string.Empty;
        public bool Value_Bool = false;

        public BasicValueToken(int val)
        {
            Value_Int = val;
            ValueType = BasicValueTypeEnum.INT;
        }
        public BasicValueToken(long val)
        {
            Value_Long = val;
            ValueType = BasicValueTypeEnum.LONG;
        }
        public BasicValueToken(float val)
        {
            Value_Float = val;
            ValueType = BasicValueTypeEnum.FLOAT;
        }
        public BasicValueToken(char val)
        {
            Value_Char = val;
            ValueType = BasicValueTypeEnum.CHAR;
        }
        public BasicValueToken(string val)
        {
            Value_CharPointer = val;
            ValueType = BasicValueTypeEnum.CHAR_POINTER;
        }
        public BasicValueToken(bool val)
        {
            Value_Bool = val;
            ValueType = BasicValueTypeEnum.BOOL;
        }


        public override string ToString()
        {
            switch (ValueType)
            {
                case BasicValueTypeEnum.INT:
                    return $"<VI {Value_Int}>";
                case BasicValueTypeEnum.LONG:
                    return $"<VL {Value_Long}>";
                case BasicValueTypeEnum.FLOAT:
                    return $"<VF {Value_Float.ToString(CultureInfo.InvariantCulture)}>";
                case BasicValueTypeEnum.CHAR:
                    return $"<VC '{Value_Char}'>";
                case BasicValueTypeEnum.CHAR_POINTER:
                    return $"<VS \"{Value_CharPointer}\">";
                case BasicValueTypeEnum.BOOL:
                    return $"<VB {Value_Bool}>";

                default:
                    return "<V?>";
            }
        }
    }
    public class BracketOpenToken : Token
    {
        public override string ToString()
            => $"<(>";
    }
    public class BracketCloseToken : Token
    {
        public override string ToString()
            => $"<)>";
    }
    public class GenericNameToken : Token
    {
        public string Name;

        public GenericNameToken(string name)
            => Name = name;

        public override string ToString()
           => $"<Name: \"{Name}\">";
    }



    public class VarNameToken : Token
    {
        public string VarName;
        public TypeToken VarType;
        public int DereferenceCount = 0;
        public bool UseAddr = false;

        public VarNameToken(string name, TypeToken typeToken)
        {
            VarName = name;
            VarType = typeToken;
            DereferenceCount = 0;
            UseAddr = false;
        }

        public override string ToString()
        {
            int dif = VarType.PointerCount - DereferenceCount;
            if (dif < 0)
                throw new Exception("Too many Dereferences!");

            VarType.PointerCount -= DereferenceCount;
            string res = String.Empty;
            if (UseAddr)
                res = $"<VAR: \"{VarName}\" (&{VarType})>";
            else
                res = $"<VAR: \"{VarName}\" ({VarType})>";
            VarType.PointerCount += DereferenceCount;
            return res;
        }

    }
    public class CastTypeToken : Token
    {
        public TypeToken CastType;

        public CastTypeToken(TypeToken castType)
            => CastType = castType;

        public override string ToString()
            => $"<({CastType})>";
    }
    public class CastToken : Token
    {
        public TypeToken CastType;
        public ExpressionToken ToCast;

        public CastToken(ExpressionToken toCast, TypeToken castType)
        {
            ToCast = toCast;
            CastType = castType;
        }

        public override string ToString()
            => $"<(({CastType}){ToCast})>";
    }
    public class DeclareVarToken : Token
    {
        public string VarName;
        public TypeToken VarType;

        public DeclareVarToken(string varName, TypeToken varType)
        {
            VarName = varName;
            VarType = varType;
        }

        public override string ToString()
            => $"<{VarType} \"{VarName}\">";
    }

    public class ExpressionToken : Token
    {
        public OperatorToken Operator = null;
        public ExpressionToken Left = null, Right = null;
        public BasicValueToken ConstValue = null;
        public VarNameToken Variable = null;
        public CastToken Cast = null;
        public bool IsConstValue = false;
        public bool OnlyUseLeft = false;
        public bool IsVariable = false;
        public bool IsCast = false;

        public ExpressionToken(ExpressionToken left, OperatorToken op, ExpressionToken right)
        {
            Left = left;
            Right = right;
            Operator = op;
            Variable = null;
            ConstValue = null;
            Cast = null;

            OnlyUseLeft = false;
            IsConstValue = false;
            IsVariable = false;
            IsCast = false;
        }
        public ExpressionToken(BasicValueToken val)
        {
            Left = null;
            Right = null;
            Operator = null;
            Variable = null;
            ConstValue = val;
            Cast = null;

            OnlyUseLeft = false;
            IsConstValue = true;
            IsVariable = false;
            IsCast = false;
        }
        public ExpressionToken(VarNameToken val)
        {
            Left = null;
            Right = null;
            Operator = null;
            Variable = val;
            ConstValue = null;
            Cast = null;

            OnlyUseLeft = false;
            IsConstValue = false;
            IsVariable = true;
            IsCast = false;
        }
        public ExpressionToken(CastToken val)
        {
            Left = null;
            Right = null;
            Operator = null;
            Variable = null;
            ConstValue = null;
            Cast = val;

            OnlyUseLeft = false;
            IsConstValue = false;
            IsVariable = false;
            IsCast = true;
        }
        public ExpressionToken(OperatorToken op, ExpressionToken left)
        {
            Left = left;
            Right = null;
            Operator = op;
            Variable = null;
            ConstValue = null;
            Cast = null;

            OnlyUseLeft = true;
            IsConstValue = false;
            IsVariable = false;
            IsCast = false;
        }

        public override string ToString()
        {
            if (IsConstValue)
                return $"{ConstValue}";
            if (IsVariable)
                return $"{Variable}";
            if (IsCast)
                return $"{Cast}";

            if (OnlyUseLeft)
                return $"<{Operator} {Left}>";
            else
                return $"<{Left} {Operator} {Right}>";
        }
    }

    public class SetVarToken : Token
    {
        public VarNameToken VarName;
        public ExpressionToken SetExpression;

        public SetVarToken(VarNameToken varName, ExpressionToken set)
        {
            VarName = varName;
            SetExpression = set;
        }

        public override string ToString()
            => $"<{VarName} = {SetExpression}>";
    }
}
