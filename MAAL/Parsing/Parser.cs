using System;
using System.Collections.Generic;
using System.Globalization;
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
                return ParseStringAdvanced(ParseStringBasic(reader.ReadToEnd()));
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

        public static List<Token> ParseStringAdvanced(List<Token> data)
        {
            List<Token> tokens = new List<Token>();

            tokens.AddRange(data);

            return tokens;
        }


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
