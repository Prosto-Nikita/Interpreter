using Interpreter;
using System;
using System.Collections.Generic;

namespace KeyWordsClasses
{
    class If : BaseTokens
    {
        public If(int numberPos, int numberStr) : base(numberPos, numberStr)
        {
            TokenNumberPos = numberPos;
            TokenType = "Ключевое слово";
            TokenValue = "if";
            NumberPos = numberPos;
        }

        public override string CheckingErrors(in List<BaseTokens> tokens, ref string errors, int pos_now)
        {
            int temp_pos = pos_now;

            if (temp_pos >= tokens.Count - 1)
            {
                errors += $"Строка {NumberStr}, Позиция {GetPositionInLine()}: После ключевого слова 'if' должен идти символ \"(\".\n";
                return errors;
            }

            if (tokens[temp_pos + 1].TokenValue != "(")
            {
                errors += $"Строка {NumberStr}, Позиция {GetPositionInLine()}: После ключевого слова 'if' должен идти символ \"(\".\n";
                return errors;
            }

            int parenCount = 0;
            temp_pos++;
            while (temp_pos < tokens.Count)
            {
                if (tokens[temp_pos].TokenValue == "(")
                    parenCount++;
                else if (tokens[temp_pos].TokenValue == ")")
                {
                    parenCount--;
                    if (parenCount == 0)
                        break;
                }
                temp_pos++;
            }

            if (temp_pos >= tokens.Count || tokens[temp_pos].TokenValue != ")")
            {
                errors += $"Строка {NumberStr}, Позиция {GetPositionInLine()}: Не найдена закрывающая скобка \")\" для условия 'if'.\n";
                return errors;
            }

            if (temp_pos >= tokens.Count - 1 || tokens[temp_pos + 1].TokenValue != "{")
            {
                errors += $"Строка {tokens[temp_pos].NumberStr}, Позиция {tokens[temp_pos].GetPositionInLine()}: После закрывающей скобки условия \")\" должна идти скобка \"{{\".\n";
                return errors;
            }

            int braceCount = 0;
            temp_pos++;
            while (temp_pos < tokens.Count)
            {
                if (tokens[temp_pos].TokenValue == "{")
                    braceCount++;
                else if (tokens[temp_pos].TokenValue == "}")
                {
                    braceCount--;
                    if (braceCount == 0)
                        break;
                }
                temp_pos++;
            }

            if (temp_pos >= tokens.Count || tokens[temp_pos].TokenValue != "}")
            {
                errors += $"Строка {NumberStr}, Позиция {GetPositionInLine()}: Не найдена закрывающая скобка \"}}\" для блока кода 'if'.\n";
                return errors;
            }

            return errors;
        }
    }

    class Other : BaseTokens
    {
        public Other(int numberPos, int numberStr) : base(numberPos, numberStr)
        {
            TokenNumberPos = numberPos;
            TokenType = "Ключевое слово";
            TokenValue = "other";
            NumberPos = numberPos;
        }

        public override string CheckingErrors(in List<BaseTokens> tokens, ref string errors, int pos_now)
        {
            int temp_pos = pos_now;

            if (temp_pos >= tokens.Count - 1)
            {
                errors += $"Строка {NumberStr}, Позиция {GetPositionInLine()}: После ключевого слова 'other' должен идти символ \"{{\".\n";
                return errors;
            }

            if (tokens[temp_pos + 1].TokenValue != "{")
            {
                errors += $"Строка {NumberStr}, Позиция {GetPositionInLine()}: После ключевого слова 'other' должен идти символ \"{{\".\n";
                return errors;
            }

            int braceCount = 0;
            temp_pos++;
            while (temp_pos < tokens.Count)
            {
                if (tokens[temp_pos].TokenValue == "{")
                    braceCount++;
                else if (tokens[temp_pos].TokenValue == "}")
                {
                    braceCount--;
                    if (braceCount == 0)
                        break;
                }
                temp_pos++;
            }

            if (temp_pos >= tokens.Count || tokens[temp_pos].TokenValue != "}")
            {
                errors += $"Строка {NumberStr}, Позиция {GetPositionInLine()}: Не найдена закрывающая скобка \"}}\" для блока кода 'other'.\n";
                return errors;
            }

            return errors;
        }
    }

    class While : BaseTokens
    {
        public While(int numberPos, int numberStr) : base(numberPos, numberStr)
        {
            TokenNumberPos = numberPos;
            TokenType = "Ключевое слово";
            TokenValue = "while";
            NumberPos = numberPos;
        }

        public override string CheckingErrors(in List<BaseTokens> tokens, ref string errors, int pos_now)
        {
            int temp_pos = pos_now;

            if (temp_pos >= tokens.Count - 1)
            {
                errors += $"Строка {NumberStr}, Позиция {GetPositionInLine()}: После ключевого слова 'while' должен идти символ \"(\".\n";
                return errors;
            }

            if (tokens[temp_pos + 1].TokenValue != "(")
            {
                errors += $"Строка {NumberStr}, Позиция {GetPositionInLine()}: После ключевого слова 'while' должен идти символ \"(\".\n";
                return errors;
            }

            int parenCount = 0;
            temp_pos++;
            while (temp_pos < tokens.Count)
            {
                if (tokens[temp_pos].TokenValue == "(")
                    parenCount++;
                else if (tokens[temp_pos].TokenValue == ")")
                {
                    parenCount--;
                    if (parenCount == 0)
                        break;
                }
                temp_pos++;
            }

            if (temp_pos >= tokens.Count || tokens[temp_pos].TokenValue != ")")
            {
                errors += $"Строка {NumberStr}, Позиция {GetPositionInLine()}: Не найдена закрывающая скобка \")\" для условия 'while'.\n";
                return errors;
            }

            if (temp_pos >= tokens.Count - 1 || tokens[temp_pos + 1].TokenValue != "{")
            {
                errors += $"Строка {tokens[temp_pos].NumberStr}, Позиция {tokens[temp_pos].GetPositionInLine()}: После закрывающей скобки условия \")\" должна идти скобка \"{{\".\n";
                return errors;
            }

            int braceCount = 0;
            temp_pos++;
            while (temp_pos < tokens.Count)
            {
                if (tokens[temp_pos].TokenValue == "{")
                    braceCount++;
                else if (tokens[temp_pos].TokenValue == "}")
                {
                    braceCount--;
                    if (braceCount == 0)
                        break;
                }
                temp_pos++;
            }

            if (temp_pos >= tokens.Count || tokens[temp_pos].TokenValue != "}")
            {
                errors += $"Строка {NumberStr}, Позиция {GetPositionInLine()}: Не найдена закрывающая скобка \"}}\" для блока кода 'while'.\n";
                return errors;
            }

            return errors;
        }
    }

    class For : BaseTokens
    {
        public For(int numberPos, int numberStr) : base(numberPos, numberStr)
        {
            TokenNumberPos = numberPos;
            TokenType = "Ключевое слово";
            TokenValue = "for";
            NumberPos = numberPos;
        }

        public override string CheckingErrors(in List<BaseTokens> tokens, ref string errors, int pos_now)
        {
            int temp_pos = pos_now;

            if (temp_pos >= tokens.Count - 1)
            {
                errors += $"Строка {NumberStr}, Позиция {GetPositionInLine()}: После ключевого слова 'for' должен идти символ \"(\".\n";
                return errors;
            }

            if (tokens[temp_pos + 1].TokenValue != "(")
            {
                errors += $"Строка {NumberStr}, Позиция {GetPositionInLine()}: После ключевого слова 'for' должен идти символ \"(\".\n";
                return errors;
            }

            int parenCount = 0;
            temp_pos++;
            while (temp_pos < tokens.Count)
            {
                if (tokens[temp_pos].TokenValue == "(")
                    parenCount++;
                else if (tokens[temp_pos].TokenValue == ")")
                {
                    parenCount--;
                    if (parenCount == 0)
                        break;
                }
                temp_pos++;
            }

            if (temp_pos >= tokens.Count || tokens[temp_pos].TokenValue != ")")
            {
                errors += $"Строка {NumberStr}, Позиция {GetPositionInLine()}: Не найдена закрывающая скобка \")\" для заголовка 'for'.\n";
                return errors;
            }

            if (temp_pos >= tokens.Count - 1 || tokens[temp_pos + 1].TokenValue != "{")
            {
                errors += $"Строка {tokens[temp_pos].NumberStr}, Позиция {tokens[temp_pos].GetPositionInLine()}: После закрывающей скобки заголовка \")\" должна идти скобка \"{{\".\n";
                return errors;
            }

            int braceCount = 0;
            temp_pos++;
            while (temp_pos < tokens.Count)
            {
                if (tokens[temp_pos].TokenValue == "{")
                    braceCount++;
                else if (tokens[temp_pos].TokenValue == "}")
                {
                    braceCount--;
                    if (braceCount == 0)
                        break;
                }
                temp_pos++;
            }

            if (temp_pos >= tokens.Count || tokens[temp_pos].TokenValue != "}")
            {
                errors += $"Строка {NumberStr}, Позиция {GetPositionInLine()}: Не найдена закрывающая скобка \"}}\" для блока кода 'for'.\n";
                return errors;
            }

            return errors;
        }
    }

    class Func : BaseTokens
    {
        public Func(int numberPos, int numberStr) : base(numberPos, numberStr)
        {
            TokenNumberPos = numberPos;
            TokenType = "Ключевое слово";
            TokenValue = "func";
            NumberPos = numberPos;
        }

        public override string CheckingErrors(in List<BaseTokens> tokens, ref string errors, int pos_now)
        {
            int temp_pos = pos_now;

            // Проверка возвращаемого типа
            if (temp_pos >= tokens.Count - 1)
            {
                errors += $"Строка {NumberStr}, Позиция {GetPositionInLine()}: После ключевого слова 'func' ожидается возвращаемый тип.\n";
                return errors;
            }

            var returnTypeToken = tokens[temp_pos + 1];
            if (!StaticMetods._data_type.Contains(returnTypeToken.TokenValue) && returnTypeToken.TokenValue != "void")
            {
                errors += $"Строка {NumberStr}, Позиция {GetPositionInLine()}: После ключевого слова 'func' ожидается возвращаемый тип (num, frac, str, bool, void).\n";
                return errors;
            }

            // Проверка имени функции
            if (temp_pos + 2 >= tokens.Count)
            {
                errors += $"Строка {NumberStr}, Позиция {GetPositionInLine()}: После возвращаемого типа ожидается имя функции.\n";
                return errors;
            }

            var funcNameToken = tokens[temp_pos + 2];
            if (funcNameToken.TokenType != "Название переменной")
            {
                errors += $"Строка {NumberStr}, Позиция {GetPositionInLine()}: После возвращаемого типа ожидается имя функции.\n";
                return errors;
            }

            // Проверка параметров в круглых скобках
            if (temp_pos + 3 >= tokens.Count || tokens[temp_pos + 3].TokenValue != "(")
            {
                errors += $"Строка {funcNameToken.NumberStr}, Позиция {funcNameToken.GetPositionInLine()}: После имени функции ожидается символ \"(\" для параметров.\n";
                return errors;
            }

            int parenCount = 0;
            temp_pos += 3;
            bool hasReturnStatement = false;

            while (temp_pos < tokens.Count)
            {
                if (tokens[temp_pos].TokenValue == "(")
                    parenCount++;
                else if (tokens[temp_pos].TokenValue == ")")
                {
                    parenCount--;
                    if (parenCount == 0)
                        break;
                }
                temp_pos++;
            }

            if (temp_pos >= tokens.Count || tokens[temp_pos].TokenValue != ")")
            {
                errors += $"Строка {NumberStr}, Позиция {GetPositionInLine()}: Не найдена закрывающая скобка \")\" для параметров функции.\n";
                return errors;
            }

            // Проверка тела функции в фигурных скобках
            if (temp_pos >= tokens.Count - 1 || tokens[temp_pos + 1].TokenValue != "{")
            {
                errors += $"Строка {tokens[temp_pos].NumberStr}, Позиция {tokens[temp_pos].GetPositionInLine()}: После параметров функции должна идти скобка \"{{\" для тела функции.\n";
                return errors;
            }

            int braceCount = 0;
            temp_pos++;

            // Проверка наличия return для не-void функций
            if (returnTypeToken.TokenValue != "void")
            {
                while (temp_pos < tokens.Count)
                {
                    if (tokens[temp_pos].TokenValue == "{")
                        braceCount++;
                    else if (tokens[temp_pos].TokenValue == "}")
                    {
                        braceCount--;
                        if (braceCount == 0)
                            break;
                    }
                    else if (tokens[temp_pos] is Return)
                    {
                        hasReturnStatement = true;
                    }
                    temp_pos++;
                }

                if (!hasReturnStatement)
                {
                    errors += $"Строка {NumberStr}, Позиция {GetPositionInLine()}: Функция с возвращаемым типом '{returnTypeToken.TokenValue}' должна содержать оператор 'return'.\n";
                }
            }
            else
            {
                // Для void функций просто проверяем баланс скобок
                while (temp_pos < tokens.Count)
                {
                    if (tokens[temp_pos].TokenValue == "{")
                        braceCount++;
                    else if (tokens[temp_pos].TokenValue == "}")
                    {
                        braceCount--;
                        if (braceCount == 0)
                            break;
                    }
                    temp_pos++;
                }
            }

            if (temp_pos >= tokens.Count || tokens[temp_pos].TokenValue != "}")
            {
                errors += $"Строка {NumberStr}, Позиция {GetPositionInLine()}: Не найдена закрывающая скобка \"}}\" для тела функции.\n";
                return errors;
            }

            return errors;
        }
    }

    class Return : BaseTokens
    {
        public Return(int numberPos, int numberStr) : base(numberPos, numberStr)
        {
            TokenNumberPos = numberPos;
            TokenType = "Ключевое слово";
            TokenValue = "return";
            NumberPos = numberPos;
        }

        public override string CheckingErrors(in List<BaseTokens> tokens, ref string errors, int pos_now)
        {
            bool insideFunction = false;
            for (int i = pos_now; i >= 0; i--)
            {
                if (tokens[i] is Func)
                {
                    insideFunction = true;
                    break;
                }
            }

            if (!insideFunction)
            {
                errors += $"Строка {NumberStr}, Позиция {GetPositionInLine()}: Ключевое слово 'return' может использоваться только внутри функции.\n";
            }

            return errors;
        }
    }

    // Остальные классы (Yes, No, NameVariable, Border, Comment, Operator, Literal, Print, Input) остаются без изменений
    class Yes : BaseTokens
    {
        public Yes(int numberPos, int numberStr) : base(numberPos, numberStr)
        {
            TokenNumberPos = numberPos;
            TokenType = "Ключевое слово";
            TokenValue = "yes";
            NumberPos = numberPos;
        }

        public override string CheckingErrors(in List<BaseTokens> tokens, ref string errors, int pos_now)
        {
            return errors;
        }
    }

    class No : BaseTokens
    {
        public No(int numberPos, int numberStr) : base(numberPos, numberStr)
        {
            TokenNumberPos = numberPos;
            TokenType = "Ключевое слово";
            TokenValue = "no";
            NumberPos = numberPos;
        }

        public override string CheckingErrors(in List<BaseTokens> tokens, ref string errors, int pos_now)
        {
            return errors;
        }
    }

    class NameVariable : BaseTokens
    {
        public NameVariable(int numberPos, string value, int numberStr) : base(numberPos, numberStr)
        {
            TokenNumberPos = numberPos;
            TokenValue = value;
            TokenType = "Название переменной";
            NumberPos = numberPos;
        }

        public override string CheckingErrors(in List<BaseTokens> tokens, ref string errors, int pos_now)
        {
            if (string.IsNullOrEmpty(TokenValue) || !char.IsLetter(TokenValue[0]))
            {
                errors += $"Строка {NumberStr}, Позиция {GetPositionInLine()}: Недопустимое имя переменной: '{TokenValue}'. Имя должно начинаться с буквы.\n";
            }

            return errors;
        }
    }

    class Border : BaseTokens
    {
        public Border(int numberPos, string value, int numberStr) : base(numberPos, numberStr)
        {
            TokenNumberPos = numberPos;
            TokenValue = value;
            TokenType = "Символ границы";
            NumberPos = numberPos;
        }

        public override string CheckingErrors(in List<BaseTokens> tokens, ref string errors, int pos_now)
        {
            return errors;
        }
    }

    class Comment : BaseTokens
    {
        public Comment(int numberPos, string value, int numberStr) : base(numberPos, numberStr)
        {
            TokenNumberPos = numberPos;
            TokenValue = value;
            TokenType = "Комментарий";
            NumberPos = numberPos;
        }

        public override string CheckingErrors(in List<BaseTokens> tokens, ref string errors, int pos_now)
        {
            return errors;
        }
    }

    class Operator : BaseTokens
    {
        public Operator(int numberPos, string value, int numberStr) : base(numberPos, numberStr)
        {
            TokenNumberPos = numberPos;
            TokenValue = value;
            TokenType = "Оператор";
            NumberPos = numberPos;
        }

        public override string CheckingErrors(in List<BaseTokens> tokens, ref string errors, int pos_now)
        {
            if (pos_now == 0 || pos_now == tokens.Count - 1)
            {
                errors += $"Строка {NumberStr}, Позиция {GetPositionInLine()}: Некорректное использование оператора '{TokenValue}'.\n";
                return errors;
            }

            var prevToken = tokens[pos_now - 1];
            var nextToken = tokens[pos_now + 1];

            if (prevToken.TokenType == "Знак границы" && prevToken.TokenValue != ")" && prevToken.TokenValue != "]")
            {
                errors += $"Строка {NumberStr}, Позиция {GetPositionInLine()}: Некорректное использование оператора '{TokenValue}'.\n";
            }

            if (nextToken.TokenType == "Знак границы" && nextToken.TokenValue != "(" && nextToken.TokenValue != "[")
            {
                errors += $"Строка {NumberStr}, Позиция {GetPositionInLine()}: Некорректное использование оператора '{TokenValue}'.\n";
            }

            return errors;
        }
    }

    class Literal : BaseTokens
    {
        public Literal(int numberPos, string value, string type, int numberStr) : base(numberPos, numberStr)
        {
            TokenNumberPos = numberPos;
            TokenValue = value;
            TokenType = $"Литерал ({type})";
            NumberPos = numberPos;
        }

        public override string CheckingErrors(in List<BaseTokens> tokens, ref string errors, int pos_now)
        {
            if (TokenType.Contains("число") && !double.TryParse(TokenValue, out _))
            {
                errors += $"Строка {NumberStr}, Позиция {GetPositionInLine()}: Некорректный числовой литерал: '{TokenValue}'.\n";
            }

            return errors;
        }
    }

    class Print : BaseTokens
    {
        public Print(int numberPos, int numberStr) : base(numberPos, numberStr)
        {
            TokenNumberPos = numberPos;
            TokenType = "Ключевое слово";
            TokenValue = "print";
            NumberPos = numberPos;
        }

        public override string CheckingErrors(in List<BaseTokens> tokens, ref string errors, int pos_now)
        {
            int temp_pos = pos_now;

            if (temp_pos >= tokens.Count - 1)
            {
                errors += $"Строка {NumberStr}, Позиция {GetPositionInLine()}: После ключевого слова 'print' должен идти символ \"(\".\n";
                return errors;
            }

            if (tokens[temp_pos + 1].TokenValue != "(")
            {
                errors += $"Строка {NumberStr}, Позиция {GetPositionInLine()}: После ключевого слова 'print' должен идти символ \"(\".\n";
                return errors;
            }

            int parenCount = 0;
            temp_pos++;
            while (temp_pos < tokens.Count)
            {
                if (tokens[temp_pos].TokenValue == "(")
                    parenCount++;
                else if (tokens[temp_pos].TokenValue == ")")
                {
                    parenCount--;
                    if (parenCount == 0)
                        break;
                }
                temp_pos++;
            }

            if (temp_pos >= tokens.Count || tokens[temp_pos].TokenValue != ")")
            {
                errors += $"Строка {NumberStr}, Позиция {GetPositionInLine()}: Не найдена закрывающая скобка \")\" для функции 'print'.\n";
                return errors;
            }

            return errors;
        }
    }

    class Input : BaseTokens
    {
        public Input(int numberPos, int numberStr) : base(numberPos, numberStr)
        {
            TokenNumberPos = numberPos;
            TokenType = "Ключевое слово";
            TokenValue = "input";
            NumberPos = numberPos;
        }

        public override string CheckingErrors(in List<BaseTokens> tokens, ref string errors, int pos_now)
        {
            int temp_pos = pos_now;

            if (temp_pos >= tokens.Count - 1)
            {
                errors += $"Строка {NumberStr}, Позиция {GetPositionInLine()}: После ключевого слова 'input' должен идти символ \"(\".\n";
                return errors;
            }

            if (tokens[temp_pos + 1].TokenValue != "(")
            {
                errors += $"Строка {NumberStr}, Позиция {GetPositionInLine()}: После ключевого слова 'input' должен идти символ \"(\".\n";
                return errors;
            }

            int parenCount = 0;
            temp_pos++;
            while (temp_pos < tokens.Count)
            {
                if (tokens[temp_pos].TokenValue == "(")
                    parenCount++;
                else if (tokens[temp_pos].TokenValue == ")")
                {
                    parenCount--;
                    if (parenCount == 0)
                        break;
                }
                temp_pos++;
            }

            if (temp_pos >= tokens.Count || tokens[temp_pos].TokenValue != ")")
            {
                errors += $"Строка {NumberStr}, Позиция {GetPositionInLine()}: Не найдена закрывающая скобка \")\" для функции 'input'.\n";
                return errors;
            }

            return errors;
        }
    }
}