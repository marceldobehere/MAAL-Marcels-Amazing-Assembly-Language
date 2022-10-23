using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAAL.Parsing
{
    public partial class Parser
    {
        public static List<Token> ParseFile(string filename)
        {
            using (StreamReader reader = new StreamReader(filename))
            {
                return ParseString(reader.ReadToEnd());
            }
        }

        public enum BasicTokenType
        {
            EndCommand,
            Number,
            String,
            Bool,
            Name,
            Type,
            Operator,
            NONE
        }

        public static Token ConvertStringToToken(string str)
        {
            return new Token();
        }

        public static BasicTokenType GetTokenType(string str)
        {
            return BasicTokenType.NONE;
        }

        public static bool StringFitsIntoToken(string str1, string str2)
        {
            BasicTokenType type1 = GetTokenType(str1);
            BasicTokenType type2 = GetTokenType(str2);
            return type1 == type2;
        }

        public static List<Token> ParseString(string data)
        {
            List<Token> tokens = new List<Token>();

            string tempString = "";

            int mIndex = 0;
            int len = data.Length;
            for (; mIndex < len; mIndex++)
            {
                char tChar = data[mIndex];
                if ("\n\r\t ".Contains(tChar))
                    continue;

                if (StringFitsIntoToken(tempString, $"{tChar}"))
                    tempString += tChar;
                else
                {
                    tokens.Add(ConvertStringToToken(tempString));
                    tempString = $"{tChar}";
                }


            }
            if (tempString != "")
                tokens.Add(ConvertStringToToken(tempString));


            return tokens;
        }
    }
}
