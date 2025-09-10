using System;

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

    static class Output
    {
        public static void OutputAllInfo(ITokens tokens)
        {
            Console.WriteLine($"Номер: {tokens.TokenNamberPos ?? -1}; Тип: {tokens.TokenType}; Значение: {tokens.TokenValue};\n");
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
            Output.OutputAllInfo(this);
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
            Output.OutputAllInfo(this);
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
            Output.OutputAllInfo(this);
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
            Output.OutputAllInfo(this);
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
            Output.OutputAllInfo(this);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            
        }
    }
}
