using System;
using System.Collections.Generic;
using System.Globalization;

namespace MAAL.Parsing
{
    public class Token
    {
        public string NamespacePrefix = string.Empty;

        public override string ToString()
            => $"<Generic Token>";
    }
    public class EndCommandToken : Token
    {
        public override string ToString()
            => $"<;>";
    }
    public class ColonToken : Token
    {
        public override string ToString()
            => $"<:>";
    }
    public class DoubleColonToken : Token
    {
        public override string ToString()
            => $"<::>";
    }
    public class CurlyBracketOpenToken : Token
    {
        public override string ToString()
            => "<{>";
    }
    public class CurlyBracketCloseToken : Token
    {
        public override string ToString()
            => "<}>";
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
        public string RelFilePath = "";

        public static List<string> KeywordList = new List<string>()
        {
            "exit",
            "loc", "location",
            "sub", "subroutine", "jump",
            "ret", "return",
            "if_jump", "if_sub",
            "#include", "syscall",
            "print", "malloc", "free",
            "readline", "namespace",
            "while", "if", "color", 
            "FG", "BG", "cls"
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
            "int", "short", "long", "float", "char", "bool",
            "uint", "ushort", "ulong", "double"
        };
        public static List<int> TypeSizeList = new List<int>()
        {
            4, 2, 8, 4, 1, 1,
            4, 2, 8, 8
        };
        public static List<BasicValueToken.BasicValueTypeEnum> TypeEnumList = new List<BasicValueToken.BasicValueTypeEnum>()
        {
            BasicValueToken.BasicValueTypeEnum.INT, BasicValueToken.BasicValueTypeEnum.SHORT, 
            BasicValueToken.BasicValueTypeEnum.LONG, BasicValueToken.BasicValueTypeEnum.FLOAT,
            BasicValueToken.BasicValueTypeEnum.CHAR, BasicValueToken.BasicValueTypeEnum.BOOL,
            BasicValueToken.BasicValueTypeEnum.UINT, BasicValueToken.BasicValueTypeEnum.USHORT, 
            BasicValueToken.BasicValueTypeEnum.ULONG, BasicValueToken.BasicValueTypeEnum.DOUBLE,
            
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
            => $"<T {ToPureString()}>";

        public string ToPureString()
            => $"{BaseType}{new String('*', PointerCount)}";
    }

    public class BasicValueToken : Token
    {
        public enum BasicValueTypeEnum
        {
            INT,
            UINT,
            SHORT,
            USHORT,
            LONG,
            ULONG,
            FLOAT,
            DOUBLE,
            CHAR,
            CHAR_POINTER,
            BOOL
        }

        public static Dictionary<BasicValueTypeEnum, string> TypeEnumToString = new Dictionary<BasicValueTypeEnum, string>()
        {
            {BasicValueTypeEnum.INT, "int"},
            {BasicValueTypeEnum.UINT, "uint"},
            {BasicValueTypeEnum.SHORT, "short"},
            {BasicValueTypeEnum.USHORT, "ushort"},
            {BasicValueTypeEnum.LONG, "long"},
            {BasicValueTypeEnum.ULONG, "ulong"},
            {BasicValueTypeEnum.FLOAT, "float"},
            {BasicValueTypeEnum.DOUBLE, "double"},
            {BasicValueTypeEnum.CHAR, "char"},
            {BasicValueTypeEnum.CHAR_POINTER, "char*"},
            {BasicValueTypeEnum.BOOL, "bool"}
        };


        public BasicValueTypeEnum ValueType;

        public int Value_Int = 0;
        public uint Value_UInt = 0;
        public short Value_Short = 0;
        public ushort Value_UShort = 0;
        public long Value_Long = 0;
        public ulong Value_ULong = 0;
        public float Value_Float = 0;
        public double Value_Double = 0;
        public char Value_Char = (char)0;
        public string Value_CharPointer = string.Empty;
        public bool Value_Bool = false;

        public BasicValueToken(int val)
        {
            Value_Int = val;
            ValueType = BasicValueTypeEnum.INT;
        }
        public BasicValueToken(uint val)
        {
            Value_UInt = val;
            ValueType = BasicValueTypeEnum.UINT;
        }
        public BasicValueToken(short val)
        {
            Value_Short = val;
            ValueType = BasicValueTypeEnum.SHORT;
        }
        public BasicValueToken(ushort val)
        {
            Value_UShort = val;
            ValueType = BasicValueTypeEnum.USHORT;
        }
        public BasicValueToken(long val)
        {
            Value_Long = val;
            ValueType = BasicValueTypeEnum.LONG;
        }
        public BasicValueToken(ulong val)
        {
            Value_ULong = val;
            ValueType = BasicValueTypeEnum.ULONG;
        }
        public BasicValueToken(float val)
        {
            Value_Float = val;
            ValueType = BasicValueTypeEnum.FLOAT;
        }
        public BasicValueToken(double val)
        {
            Value_Double = val;
            ValueType = BasicValueTypeEnum.DOUBLE;
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
                    return $"<VI  {Value_Int}>";
                case BasicValueTypeEnum.UINT:
                    return $"<VUI {Value_UInt}>";
                case BasicValueTypeEnum.SHORT:
                    return $"<VS  {Value_Short}>";
                case BasicValueTypeEnum.USHORT:
                    return $"<VUS {Value_UShort}>";
                case BasicValueTypeEnum.LONG:
                    return $"<VL  {Value_Long}>";
                case BasicValueTypeEnum.ULONG:
                    return $"<VUL {Value_ULong}>";
                case BasicValueTypeEnum.FLOAT:
                    return $"<VF  {Value_Float.ToString(CultureInfo.InvariantCulture)}>";
                case BasicValueTypeEnum.DOUBLE:
                    return $"<VD  {Value_Double.ToString(CultureInfo.InvariantCulture)}>";
                case BasicValueTypeEnum.CHAR:
                    return $"<VC  '{Value_Char}'>";
                case BasicValueTypeEnum.CHAR_POINTER:
                    return $"<VC* \"{Value_CharPointer}\">";
                case BasicValueTypeEnum.BOOL:
                    return $"<VB  {Value_Bool}>";

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
        public bool UseAddr = false;

        public VarNameToken(string name, TypeToken typeToken, string namespacePref)
        {
            VarName = name;
            VarType = typeToken;
            UseAddr = false;
            NamespacePrefix = namespacePref;
        }

        public override string ToString()
        {
            string res;
            if (UseAddr)
                res = $"<VAR: \"{NamespacePrefix}{VarName}\" (&{VarType})>";
            else
                res = $"<VAR: \"{NamespacePrefix}{VarName}\" ({VarType})>";

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

        public DeclareVarToken(string varName, TypeToken varType, string namespacePref)
        {
            VarName = varName;
            VarType = varType;
            NamespacePrefix = namespacePref;
        }

        public override string ToString()
            => $"<{VarType} \"{NamespacePrefix}{VarName}\">";
    }

    public class DerefToken : Token
    {
        public ExpressionToken ToDeref;

        public DerefToken(ExpressionToken toDeref)
        {
            ToDeref = toDeref;
        }

        public override string ToString()
            => $"<*{ToDeref}>";
    }


    public class ExpressionToken : Token
    {
        public OperatorToken Operator = null;
        public ExpressionToken Left = null, Right = null;
        public BasicValueToken ConstValue = null;
        public VarNameToken Variable = null;
        public CastToken Cast = null;
        public DerefToken Deref = null;
        public bool IsConstValue = false;
        public bool OnlyUseLeft = false;
        public bool IsVariable = false;
        public bool IsCast = false;
        public bool IsDeref = false;

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
        public ExpressionToken(DerefToken val)
        {
            Deref = val;
            IsDeref = true;
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
            if (IsDeref)
                return $"{Deref}";

            if (OnlyUseLeft)
                return $"<{Operator} {Left}>";
            else
                return $"<{Left} {Operator} {Right}>";
        }
    }

    public class SetVarToken : Token
    {
        public VarNameToken VarName;
        public ExpressionToken VarLocation;
        public bool SetLocation;
        public ExpressionToken SetExpression;

        public SetVarToken(VarNameToken varName, ExpressionToken set)
        {
            VarName = varName;
            SetExpression = set;

            VarLocation = null;
            SetLocation = false;
        }

        public SetVarToken(ExpressionToken loc, ExpressionToken set)
        {
            VarName = null;
            SetExpression = set;

            VarLocation = loc;
            SetLocation = true;
        }

        public override string ToString()
        {
            if (SetLocation)
                return $"<[{VarLocation}] = {SetExpression}>";
            else
                return $"<{VarName} = {SetExpression}>";
        }
    }

    public class DefineLocationToken : Token
    {
        public string LocationName;

        public DefineLocationToken(string name, string namespacePref)
        {
            LocationName = name;
            NamespacePrefix = namespacePref;
        }

        public override string ToString()
            => $"<DEF LOCATION {NamespacePrefix}{LocationName}>";
    }
    public class DefineSubroutineToken : Token
    {
        public string SubroutineName;

        public DefineSubroutineToken(string name, string namespacePref)
        {
            SubroutineName = name;
            NamespacePrefix = namespacePref;
        }

        public override string ToString()
            => $"<DEF SUB {NamespacePrefix}{SubroutineName}>";
    }

    public class ExitToken : Token
    {
        public override string ToString()
            => $"<EXIT>";
    }
    public class ReturnToken : Token
    {
        public override string ToString()
            => $"<RETURN>";
    }

    public class LocationNameToken : Token
    {
        public DefineLocationToken Location;
        public ExpressionToken Address;
        public bool JumpToFixedAddress = false;

        public LocationNameToken(DefineLocationToken location)
        {
            Location = location;
            Address = null;
            JumpToFixedAddress = false;
        }

        public LocationNameToken(ExpressionToken address)
        {
            Location = null;
            Address = address;
            JumpToFixedAddress = true;
        }

        public override string ToString()
        {
            if (JumpToFixedAddress)
                return $"<LOCATION {Address}>";
            else
                return $"<LOCATION {Location.NamespacePrefix}{Location.LocationName}>";
        }
    }
    public class SubroutineNameToken : Token
    {
        public DefineSubroutineToken Subroutine;

        public SubroutineNameToken(DefineSubroutineToken subroutine)
        {
            Subroutine = subroutine;
        }

        public override string ToString()
            => $"<SUB {Subroutine.NamespacePrefix}{Subroutine.SubroutineName}>";
    }
    public class FixedJumpToken : Token
    {
        public SubroutineNameToken Subroutine = null;
        public LocationNameToken Location = null;
        public bool IsSubroutine = false;
        public bool IsLocation = false;

        public FixedJumpToken(SubroutineNameToken sub)
        {
            Subroutine = sub;
            Location = null;

            IsSubroutine = true;
            IsLocation = false;
        }

        public FixedJumpToken(LocationNameToken loc)
        {
            Subroutine = null;
            Location = loc;

            IsSubroutine = false;
            IsLocation = true;
        }

        public override string ToString()
        {
            if (IsSubroutine)
                return $"<SUB -> {Subroutine}>";
            else if (IsLocation)
                return $"<JUMP -> {Location}>";
            else
                throw new Exception("UNKNOWN JUMP TYPE!");
        }
    }
    public class ConditionalJumpToken : Token
    {
        public ExpressionToken Condition = null;
        public SubroutineNameToken Subroutine = null;
        public LocationNameToken Location = null;
        public bool IsSubroutine = false;
        public bool IsLocation = false;

        public ConditionalJumpToken(ExpressionToken expr, SubroutineNameToken sub)
        {
            Condition = expr;
            Subroutine = sub;
            Location = null;

            IsSubroutine = true;
            IsLocation = false;
        }

        public ConditionalJumpToken(ExpressionToken expr, LocationNameToken loc)
        {
            Condition = expr;
            Subroutine = null;
            Location = loc;

            IsSubroutine = false;
            IsLocation = true;
        }

        public override string ToString()
        {
            if (IsSubroutine)
                return $"<IF {Condition} -> {Subroutine}>";
            else if (IsLocation)
                return $"<IF {Condition} -> {Location}>";
            else
                throw new Exception("UNKNOWN JUMP TYPE!");
        }
    }

    public class SyscallToken : Token
    {
        public List<ExpressionToken> Arguments;

        public SyscallToken(List<ExpressionToken> arguments)
        {
            Arguments = arguments;
        }


        public override string ToString()
        {
            return $"<SYSCALL {String.Join(", ", Arguments)}>";
        }
    }

    public class PrintToken : Token
    {
        public ExpressionToken Argument;

        public PrintToken(ExpressionToken argument)
        {
            Argument = argument;
        }

        public override string ToString()
        {
            return $"<PRINT {Argument}>";
        }
    }

    public class FreeToken : Token
    {
        public ExpressionToken ToFree;

        public FreeToken(ExpressionToken toFree)
        {
            ToFree = toFree;
        }

        public override string ToString()
        {
            return $"<FREE {ToFree}>";
        }
    }

    public class ReadLineToken : Token
    {
        public ExpressionToken ToReadInto;

        public ReadLineToken(ExpressionToken toReadInto)
        {
            ToReadInto = toReadInto;
        }

        public override string ToString()
        {
            return $"<READ LINE INTO {ToReadInto}>";
        }
    }

    public class SetColorToken : Token
    {
        public bool IsForeground;
        public ExpressionToken ColorVal;

        public SetColorToken(ExpressionToken colorVal, bool setForeground)
        {
            ColorVal = colorVal;
            IsForeground = setForeground;
        }

        public override string ToString()
        {
            return $"<COLOR {ColorVal} {(IsForeground?"FG":"BG")}>";
        }
    }

    public class ClsToken : Token
    {

        public override string ToString()
        {
            return $"<CLS>";
        }
    }

    public class MallocToken : Token
    {
        public ExpressionToken Size, ToMalloc;

        public MallocToken(ExpressionToken size, ExpressionToken toMalloc)
        {
            Size = size;
            ToMalloc = toMalloc;
        }

        public override string ToString()
        {
            return $"<MALLOC {Size} bytes to {ToMalloc}>";
        }
    }

    public class NamespaceUseToken : Token
    {
        public NamespaceUseToken(string namespacePref)
        {
            NamespacePrefix = namespacePref;
        }

        public override string ToString()
        {
            if (NamespacePrefix.Equals(""))
                return $"<NAMESPACE GLOBAL>";
            else
                return $"<NAMESPACE {NamespacePrefix}>";
        }
    }

}

// 12
// ==
//  4 * 4 = 16
//  6 * 2 = 12
//  2 * 1 =  2
//       = 30
