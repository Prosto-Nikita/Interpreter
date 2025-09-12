using System;
using System.Collections.Generic;

namespace Interpreter
{
    interface ILiterals
    {

    }
    interface IIdentifier
    {

    }
    interface IKeywords
    {

    }
    interface IOperators
    {

    }
    interface ITokens
    {
        int? TokenNamberPos { get; }
        string TokenType { get;}
        string TokenValue { get;}

        void WriteAllInfo();
    }

    static class StaticMetods
    {
        public static readonly HashSet<string> _keywords = new()
        {
            "if", "else", "while", "for", "func",
            "return", "yes", "no", "null"
        };
        public static readonly HashSet<string> _border = new()
        {
            "(", ")", ";", " "
        };
        public static void OutputAllInfo(ITokens tokens)
        {
            Console.WriteLine($"Номер: {tokens.TokenNamberPos ?? -1}; Тип: {tokens.TokenType}; Значение: {tokens.TokenValue};\n");
        }
    }
    class Parser
    {
        public string input_str { get; }
        public Parser(string input_str) => this.input_str = input_str;

        public List<ITokens> Bypass()
        {
            List <ITokens> tokens = new List <ITokens>();
            int pos = 0;
            int max_position = input_str.Length;
            while (pos < max_position)
            {
                string temp = "";
                while (StaticMetods._border.Contains((input_str[pos]).ToString()))
                {
                    temp += input_str[pos];
                    pos++;
                }

                if (StaticMetods._keywords.Contains(temp))
                {
                    foreach(var it in StaticMetods._keywords)
                    {
                        tokens.Add(new )
                    }
                }

                temp = "";
                pos++;
            }



            return new List<ITokens>();
        }
    }
    class Frac : ITokens
    {
        public Frac(int number) => TokenNamberPos = number;

        public int? TokenNamberPos { get; }
        public string TokenType { get; } = "Тип данных";
        public string TokenValue { get; } = "frac";

        public void WriteAllInfo()
        {
            StaticMetods.OutputAllInfo(this);
        }
    }
    class String : ITokens
    {
        public String(int number) => TokenNamberPos = number;

        public int? TokenNamberPos { get; }
        public string TokenType { get; } = "Тип данных";
        public string TokenValue { get; } = "str";

        public void WriteAllInfo()
        {
            StaticMetods.OutputAllInfo(this);
        }
    }
    class Bool : ITokens
    {
        public Bool(int number) => TokenNamberPos = number;

        public int? TokenNamberPos { get; }
        public string TokenType { get; } = "Тип данных";
        public string TokenValue { get; } = "bool";

        public void WriteAllInfo()
        {
            StaticMetods.OutputAllInfo(this);
        }
    }
    class Num : ITokens
    {
        public Num(int number) => TokenNamberPos = number;
        public int? TokenNamberPos { get; }
        public string TokenType { get; } = "Тип данных";
        public string TokenValue { get; } = "num";

        public void WriteAllInfo()
        {
            StaticMetods.OutputAllInfo(this);
        }
    }
    class IF : ITokens, IKeywords
    {
        public IF(int number) => TokenNamberPos = number;
        public int? TokenNamberPos { get; }
        public string TokenType { get; } = "Ключевое слово";
        public string TokenValue { get; } = "if";

        public void WriteAllInfo()
        {
            StaticMetods.OutputAllInfo(this);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            
        }
    }
}
