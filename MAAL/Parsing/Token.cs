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
            => $"<Command End>";
    }
    public class GeneralOperatorToken : Token
    {
        public override string ToString()
            => $"<Operator: \"{Operator}\">";
        public string Operator = "<Default>";
    }
    //public class TwoOperatorToken : Token
    //{
    //    public enum TwoOperatorEnum
    //    {
    //        Plus,
    //        Minus,
    //        Multiply,
    //        Divide,
    //        Set
    //    }

    //    public Token Left, Right;
    //    public TwoOperatorEnum Operator;
    //}
    public class KeywordToken : Token
    {
        public override string ToString()
           => $"<Keyword: \"{Keyword}\">";
        public string Keyword = "<Default>";
    }

    //public class ValueTypeClass
    //{
    //    public static List<string> ValueTypeList = new List<string>()
    //    {
    //        "int", "long", "float", "double", "ulong", "byte", "char"
    //    };

    //    public string ValueTypeName = "char*";
    //    public bool IsPointer { get => ValueTypeName.EndsWith("*"); }
    //}

    public class BasicValueToken : Token
    {
        public enum BasicValueTypeEnum
        {
            INT,
            LONG,
            FLOAT,
            CHAR,
            CHAR_POINTER
        }

        public BasicValueTypeEnum ValueType;

        public int Value_Int = 0;
        public long Value_Long = 0;
        public float Value_Float = 0;
        public char Value_Char = (char)0;
        public string Value_CharPointer = string.Empty;

        public override string ToString()
        {
            switch (ValueType)
            {
                case BasicValueTypeEnum.INT:
                    return $"<INT: {Value_Int}>";
                case BasicValueTypeEnum.LONG:
                    return $"<LONG: {Value_Long}>";
                case BasicValueTypeEnum.FLOAT:
                    return $"<FLOAT: {Value_Float.ToString(CultureInfo.InvariantCulture)}>";
                case BasicValueTypeEnum.CHAR:
                    return $"<CHAR: '{Value_Char}'>";
                case BasicValueTypeEnum.CHAR_POINTER:
                    return $"<STR: \"{Value_CharPointer}\">";

                default:
                    return "<Generic Value>";
            }
        }
    }
    public class GenericNameToken : Token
    {
        public string Name;
        public override string ToString()
           => $"<Name: \"{Name}\">";
    }
    public class VarNameToken : Token
    {
        public string Name;
        public override string ToString()
           => $"<Varname: \"{Name}\">";
    }
    public class TypeToken : Token
    {
        public string Name;
        public override string ToString()
           => $"<Type: \"{Name}\">";
    }
}
