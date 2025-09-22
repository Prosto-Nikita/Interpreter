using System;
using System.Collections.Generic;
using DataTypeClasses;
using KeyWordsClasses;

namespace Interpreter
{
    static class StaticMetods
    {
        public static readonly HashSet<string> _keywords = new()
        {
            "if", "other", "while", "for", "func",
            "return", "yes", "no", "null"
        };
        public static readonly HashSet<string> _border = new()
        {
            "(", ")", ";", " ", "[", "]"
        };
        public static readonly HashSet<string> _data_type = new()
        {
            "num", "frac", "str", "bool"
        };
        public static void OutputAllInfo(BaseTokens tokens)
        {
            Console.WriteLine($"Позиция: {tokens.TokenNamberPos} " + $"Тип: {tokens.TokenType} " + $"Значение: {tokens.TokenValue}\n");
        }
    }
    class Parser
    {
        public string input_str { get; }
        public Parser(string input_str) => this.input_str = input_str;

        public List<BaseTokens> Bypass()
        {
            if (string.IsNullOrWhiteSpace(input_str))
            {
                Console.WriteLine("Код программы отсутствует.");
                return new List<BaseTokens>();
            }
            List <BaseTokens> tokens = new List <BaseTokens>();
            int pos = 0;
            int max_position = input_str.Length;
            string temp = "";
            int stroke = 1;
            int pos_in_stroke = 0;
            while (pos < max_position)
            {
                pos_in_stroke = pos;
                temp = "";
                temp += input_str[pos];
                if(temp == " ") { pos++; pos_in_stroke++; continue; }
                if(temp == "\n" || temp == "\r") { pos++; stroke++; pos_in_stroke -= pos; continue; }
                if (StaticMetods._border.Contains(temp))
                {
                    tokens.Add(new Border(pos_in_stroke, temp, stroke));
                    pos++;
                    if (pos == max_position) { return tokens; }
                    temp = input_str[pos].ToString();
                    continue;
                }

                if (pos >= input_str.Length) { return tokens; }

                temp = "";
                while (!(StaticMetods._border.Contains((input_str[pos]).ToString())))
                {
                    temp += input_str[pos];
                    pos++;
                    if (pos == max_position) { break; }
                }


                if (StaticMetods._keywords.Contains(temp))
                {
                    switch (temp)
                    {
                        case "if":
                            tokens.Add(new If(pos_in_stroke, stroke));
                            break;
                        case "other":
                            tokens.Add(new Other(pos_in_stroke, stroke));
                            break;
                        case "while":
                            tokens.Add(new While(pos_in_stroke, stroke));
                            break;
                        case "for":
                            tokens.Add(new For(pos_in_stroke, stroke));
                            break;
                        case "func":
                            tokens.Add(new Func(pos_in_stroke, stroke));
                            break;
                        case "return":
                            tokens.Add(new Return(pos_in_stroke, stroke));
                            break;
                        case "yes":
                            tokens.Add(new Yes(pos_in_stroke, stroke));
                            break;
                        case "no":
                            tokens.Add(new No(pos_in_stroke, stroke));
                            break;
                    }
                }
                else if (StaticMetods._data_type.Contains(temp))
                {
                    foreach (var it in StaticMetods._data_type)
                    {
                        switch (temp)
                        {
                            case "num":
                                tokens.Add(new Num(pos_in_stroke, stroke));
                                break;
                            case "frac":
                                tokens.Add(new Frac(pos_in_stroke, stroke));
                                break;
                            case "str":
                                tokens.Add(new DataTypeClasses.String(pos_in_stroke, stroke));
                                break;
                            default:
                                tokens.Add(new Bool(pos_in_stroke, stroke));
                                break;
                        }
                    }
                }
                else if (temp.All(c =>
                    (c >= 'A' && c <= 'Z') ||
                    (c >= 'a' && c <= 'z') ||
                    (c >= '0' && c <= '9')))
                {
                    tokens.Add(new NameVariable(pos_in_stroke, temp, stroke));
                }
                else { Console.WriteLine("Непредвиденное значение ввода, либо ошибка в синтаксисе."); break; }

                if (pos == max_position) { return tokens; }
                temp = input_str[pos].ToString();
            }
            return new List<BaseTokens>();
        }
        public void Output_Info(List<BaseTokens> tokens)
        {
            string errors = "";
            if (tokens.Count == 0) { return; }
            Console.WriteLine($"{"|Номер",0} {"|Строка",10} {"|Позиция",20} {"Тип",30} {"|Значение",40} {"|",50}");
            for (int i = 0; i < tokens.Count; i++)
            {
                tokens[i].CheckingErrors(in tokens, ref errors, i);
                tokens[i].WriteAllInfo();
                if(errors != "")
                {
                    Console.WriteLine(errors);
                    return;
                }
            }
            
        }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            string path_file = "C:\\Users\\user\\source\\repos\\Interpreter\\input.txt";
            string input_str;
            try
            {
                input_str = File.ReadAllText(path_file);
            }
            catch { Console.WriteLine("Файл не найден"); return; }

            Parser parser = new Parser(input_str);
            List<BaseTokens> tokens = parser.Bypass();
            //foreach(ITokens token in tokens)
            //{
            //    token.TokenValue
            //}
            parser.Output_Info(tokens);
        }
    }
}
