using System;
using System.Collections.Generic;
using System.Linq;
using DataTypeClasses;
using KeyWordsClasses;

namespace Interpreter
{
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

            List<BaseTokens> tokens = new List<BaseTokens>();
            int pos = 0;
            int max_position = input_str.Length;
            int stroke = 1;
            int pos_in_stroke = 1;

            while (pos < max_position)
            {
                char currentChar = input_str[pos];

                if (char.IsWhiteSpace(currentChar))
                {
                    if (currentChar == '\n')
                    {
                        stroke++;
                        pos_in_stroke = 1;
                    }
                    else if (currentChar == '\r')
                    {
                        // Игнорируем \r
                    }
                    else
                    {
                        pos_in_stroke++;
                    }
                    pos++;
                    continue;
                }

                if (currentChar == '#')
                {
                    int start = pos;
                    int startPosInLine = pos_in_stroke;
                    int startStroke = stroke;

                    // Ищем конец строки или конец файла
                    while (pos < max_position && input_str[pos] != '\n')
                    {
                        pos++;
                        pos_in_stroke++;
                    }

                    string comment = input_str.Substring(start, pos - start);
                    var commentToken = new Comment(start, comment, startStroke);
                    commentToken.NumberPos = startPosInLine;
                    tokens.Add(commentToken);

                    if (pos < max_position && input_str[pos] == '\n')
                    {
                        stroke++;
                        pos_in_stroke = 1;
                        pos++;
                    }
                    continue;
                }

                if (StaticMetods._border.Contains(currentChar.ToString()))
                {
                    var borderToken = new Border(pos, currentChar.ToString(), stroke);
                    borderToken.NumberPos = pos_in_stroke;
                    tokens.Add(borderToken);
                    pos++;
                    pos_in_stroke++;
                    continue;
                }

                string potentialOperator = currentChar.ToString();
                if (pos + 1 < max_position && StaticMetods._operators.Contains(currentChar.ToString() + input_str[pos + 1]))
                {
                    potentialOperator = currentChar.ToString() + input_str[pos + 1];
                    var operatorToken = new Operator(pos, potentialOperator, stroke);
                    operatorToken.NumberPos = pos_in_stroke;
                    tokens.Add(operatorToken);
                    pos += 2;
                    pos_in_stroke += 2;
                    continue;
                }
                else if (StaticMetods._operators.Contains(currentChar.ToString()))
                {
                    var operatorToken = new Operator(pos, currentChar.ToString(), stroke);
                    operatorToken.NumberPos = pos_in_stroke;
                    tokens.Add(operatorToken);
                    pos++;
                    pos_in_stroke++;
                    continue;
                }

                if (currentChar == '"')
                {
                    int start = pos;
                    int startPosInLine = pos_in_stroke;

                    pos++;
                    pos_in_stroke++;

                    while (pos < max_position && input_str[pos] != '"')
                    {
                        if (input_str[pos] == '\\')
                        {
                            pos++;
                            pos_in_stroke++;
                            if (pos >= max_position) break;
                        }
                        pos++;
                        pos_in_stroke++;
                    }

                    if (pos >= max_position)
                    {
                        Console.WriteLine("Незакрытая строковая константа.");
                        break;
                    }

                    pos++;
                    pos_in_stroke++;

                    string stringValue = input_str.Substring(start, pos - start);
                    var literalToken = new Literal(start, stringValue, "строка", stroke);
                    literalToken.NumberPos = startPosInLine;
                    tokens.Add(literalToken);
                    continue;
                }

                if (char.IsDigit(currentChar))
                {
                    int start = pos;
                    int startPosInLine = pos_in_stroke;

                    while (pos < max_position && (char.IsDigit(input_str[pos]) || input_str[pos] == '.'))
                    {
                        pos++;
                        pos_in_stroke++;
                    }

                    string numberValue = input_str.Substring(start, pos - start);
                    var literalToken = new Literal(start, numberValue, "число", stroke);
                    literalToken.NumberPos = startPosInLine;
                    tokens.Add(literalToken);
                    continue;
                }

                if (char.IsLetter(currentChar) || currentChar == '_')
                {
                    int start = pos;
                    int startPosInLine = pos_in_stroke;

                    while (pos < max_position && (char.IsLetterOrDigit(input_str[pos]) || input_str[pos] == '_'))
                    {
                        pos++;
                        pos_in_stroke++;
                    }

                    string identifier = input_str.Substring(start, pos - start);

                    BaseTokens token;
                    if (StaticMetods._keywords.Contains(identifier))
                    {
                        switch (identifier)
                        {
                            case "if": token = new If(start, stroke); break;
                            case "other": token = new Other(start, stroke); break;
                            case "while": token = new While(start, stroke); break;
                            case "for": token = new For(start, stroke); break;
                            case "func": token = new Func(start, stroke); break;
                            case "return": token = new Return(start, stroke); break;
                            case "yes": token = new Yes(start, stroke); break;
                            case "no": token = new No(start, stroke); break;
                            default: token = new NameVariable(start, identifier, stroke); break;
                        }
                    }
                    else if (StaticMetods._data_type.Contains(identifier))
                    {
                        switch (identifier)
                        {
                            case "num": token = new Num(start, stroke); break;
                            case "frac": token = new Frac(start, stroke); break;
                            case "str": token = new DataTypeClasses.String(start, stroke); break;
                            case "bool": token = new Bool(start, stroke); break;
                            default: token = new NameVariable(start, identifier, stroke); break;
                        }
                    }
                    else
                    {
                        token = new NameVariable(start, identifier, stroke);
                    }

                    token.NumberPos = startPosInLine;
                    tokens.Add(token);
                    continue;
                }

                Console.WriteLine($"Неизвестный символ: '{currentChar}' в строке {stroke}, позиция {pos_in_stroke}");
                pos++;
                pos_in_stroke++;
            }

            return tokens;
        }

        public bool CheckForErrors(List<BaseTokens> tokens)
        {
            string errors = "";

            for (int i = 0; i < tokens.Count; i++)
            {
                tokens[i].CheckingErrors(in tokens, ref errors, i);

                if (!string.IsNullOrEmpty(errors))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nОШИБКИ КОМПИЛЯЦИИ:");
                    Console.ResetColor();
                    Console.WriteLine(errors);
                    return true;
                }
            }

            int bracketBalance = 0;
            int parenBalance = 0;
            int braceBalance = 0;

            foreach (var token in tokens)
            {
                switch (token.TokenValue)
                {
                    case "[": bracketBalance++; break;
                    case "]": bracketBalance--; break;
                    case "(": parenBalance++; break;
                    case ")": parenBalance--; break;
                    case "{": braceBalance++; break;
                    case "}": braceBalance--; break;
                }
            }

            if (bracketBalance != 0)
            {
                errors += $"Несбалансированность квадратных скобок: разница {bracketBalance}\n";
            }

            if (parenBalance != 0)
            {
                errors += $"Несбалансированность круглых скобок: разница {parenBalance}\n";
            }

            if (braceBalance != 0)
            {
                errors += $"Несбалансированность фигурных скобок: разница {braceBalance}\n";
            }

            if (!string.IsNullOrEmpty(errors))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nОШИБКИ КОМПИЛЯЦИИ:");
                Console.ResetColor();
                Console.WriteLine(errors);
                return true;
            }

            return false;
        }

        public void Output_Info(List<BaseTokens> tokens)
        {
            if (tokens.Count == 0)
            {
                Console.WriteLine("Токены не найдены.");
                return;
            }

            if (CheckForErrors(tokens))
            {
                return;
            }

            StaticMetods.PrintTableHeader();

            for (int i = 0; i < tokens.Count; i++)
            {
                tokens[i].WriteAllInfo(i + 1);
            }

            StaticMetods.PrintTableFooter();

            Console.WriteLine($"\nВсего токенов: {tokens.Count}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== ИНТЕРПРЕТАТОР ЯЗЫКА ===");

            string filePath;
            Console.WriteLine("Введите путь к файлу с кодом:");
            filePath = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(filePath))
            {
                Console.WriteLine("Файл не указан.\n");
                return;
            }

            if (!File.Exists(filePath))
            {
                Console.WriteLine($"Файл '{filePath}' не найден.\n");
                return;
            }

            try
            {
                string code = System.IO.File.ReadAllText(filePath, System.Text.Encoding.UTF8);
                Console.WriteLine($"\n=== АНАЛИЗ ФАЙЛА: {Path.GetFileName(filePath)} ===\n");

                Parser parser = new Parser(code);
                List<BaseTokens> tokens = parser.Bypass();
                parser.Output_Info(tokens);
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Ошибка при чтении файла: {ex.Message}");
                Console.ResetColor();
            }

            Console.WriteLine("\nНажмите любую клавишу для выхода...");
            Console.ReadKey();
        }

    }
}