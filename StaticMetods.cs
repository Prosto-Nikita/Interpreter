using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interpreter
{
    static class StaticMetods
    {
        public static readonly HashSet<string> _keywords = new()
        {
            "if", "other", "while", "for", "func",
            "return", "yes", "no", "null", "print", "input", "void"
        };

        public static readonly HashSet<string> _border = new()
        {
            "(", ")", ";", " ", "[", "]", "{", "}", ","
        };

        public static readonly HashSet<string> _data_type = new()
        {
            "num", "frac", "str", "bool"
        };

        public static readonly HashSet<string> _operators = new()
        {
            "+", "-", "*", "/", "=", "==", "!=", "<", ">", "<=", ">="
        };

        public static void OutputAllInfo(BaseTokens token, int index)
        {
            string positionInfo = $"Строка {token.NumberStr}, Позиция {token.GetPositionInLine()}";

            string tokenValue = token.TokenValue;
            if (tokenValue.Length > 30)
            {
                tokenValue = tokenValue.Substring(0, 27) + "...";
            }

            string tokenType = token.TokenType;
            if (tokenType.Length > 20)
            {
                tokenType = tokenType.Substring(0, 17) + "...";
            }
            if (tokenValue.Contains("\r"))
            {
                tokenValue = tokenValue.Replace("\r", "");
            }

            tokenValue = tokenValue.Replace("\n", "\\n");

            Console.WriteLine($"| {index,-5} | {tokenType,-20} | {positionInfo,-26} | {tokenValue,-35} |");
        }

        public static void PrintTableHeader()
        {
            Console.WriteLine(new string('=', 99));
            Console.WriteLine($"| {"№",-5} | {"Тип",-20} | {"Позиция",-26} | {"Значение",-35} |");
            Console.WriteLine(new string('=', 99));
        }

        public static void PrintTableFooter()
        {
            Console.WriteLine(new string('=', 99));
        }
    }
}