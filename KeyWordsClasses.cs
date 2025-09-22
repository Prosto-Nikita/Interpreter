using Interpreter;
using System;

namespace KeyWordsClasses
{
    class If : BaseTokens
    {
        public If(int numberPos, int numberStr) : base(numberPos, numberStr)
        {
            TokenNamberPos = numberPos;
            TokenType = "Ключевое слово";
            TokenValue = "if";
        }

        public override string CheckingErrors(in List<BaseTokens> tokens, ref string errors, int pos_now)
        {
            int temp_pos = pos_now;
            if(temp_pos == tokens.Count - 1)
            {
                errors = $"После ключевого слова if должен идти символ \"[\". Позиция: {TokenNamberPos + TokenValue.Length}\n"; return errors ;
            }
            if(temp_pos < tokens.Count - 1)
            {
                if (tokens[temp_pos + 1].TokenValue != "[")
                {
                    errors = $"После ключевого слова if должен идти символ \"[\". Позиция: {TokenNamberPos + TokenValue.Length}\n"; return errors;
                }
            }
            while(temp_pos < tokens.Count - 1)
            {
                if (tokens[temp_pos].TokenValue == "]")
                {
                    //Проверка правильности математического выражения

                    temp_pos++;

                    if (tokens[temp_pos].TokenValue != "(")
                    {
                        errors = $"После закрывающей скобки условия \"]\" должна идти скобка \"(\". Позиция: {tokens[temp_pos - 1].TokenNamberPos + 1}\n"; return errors;
                    }
                    while (temp_pos < tokens.Count - 1)
                    {
                        if (tokens[temp_pos].TokenValue == ")")
                        {
                            return errors;
                        }
                        temp_pos++;
                    }
                    errors = $"Нет закрывающей скобки \")\" для if. Позция if: {TokenNamberPos}"; return errors;
                }
                temp_pos++;
            }
            errors = $"Нет закрывающей скобки \"]\" для if. Позция if: {TokenNamberPos}";
            return errors;
        }
    }
    class Other : BaseTokens
    {
        public Other(int numberPos, int numberStr) : base(numberPos, numberStr)
        {
            TokenNamberPos = numberPos;
            TokenType = "Ключевое слово";
            TokenValue = "other";
        }
        
        public override string CheckingErrors(in List<BaseTokens> tokens, ref string errors, int pos_now)
        {
            int temp_pos = pos_now;
            if (temp_pos == tokens.Count - 1)
            {
                errors = $"После ключевого слова other должен идти символ \"[\" или \"(\". Позиция: {TokenNamberPos + TokenValue.Length}\n"; return errors;
            }
            if (temp_pos < tokens.Count - 1)
            {
                if (tokens[temp_pos + 1].TokenValue == "[")
                {
                    while (temp_pos < tokens.Count - 1)
                    {
                        if (tokens[temp_pos].TokenValue == "]")
                        {
                            //Проверка правильности математического выражения

                            temp_pos++;

                            if (tokens[temp_pos].TokenValue != "(")
                            {
                                errors = $"После закрывающей скобки условия \"]\" должна идти скобка \"(\". Позиция: {tokens[temp_pos - 1].TokenNamberPos + 1}\n"; return errors;
                            }
                            while (temp_pos < tokens.Count - 1)
                            {
                                if (tokens[temp_pos].TokenValue == ")")
                                {
                                    return errors;
                                }
                                temp_pos++;
                            }
                            errors = $"Нет закрывающей скобки \")\" для other. Позция other: {TokenNamberPos}"; return errors;
                        }
                        temp_pos++;
                    }
                    errors = $"Нет закрывающей скобки \"]\" для other. Позция other: {TokenNamberPos}";
                    return errors;
                }
                else 
                {
                    while (temp_pos < tokens.Count)
                    {
                        if (tokens[temp_pos].TokenValue == ")")
                        {
                            return errors;
                        }
                        temp_pos++;
                    }
                    errors = $"Нет закрывающей скобки \")\" для \"other\". Позция other: {TokenNamberPos}"; return errors;
                }
            }
            return errors;
        }
    }

    class While : BaseTokens
    {
        public While(int numberPos, int numberStr) : base(numberPos, numberStr)
        {
            TokenNamberPos = numberPos;
            TokenType = "Ключевое слово";
            TokenValue = "while";
        }

        public override string CheckingErrors(in List<BaseTokens> tokens, ref string errors, int pos_now)
        {
            int temp_pos = pos_now;
            if (temp_pos == tokens.Count - 1)
            {
                errors = $"После ключевого слова while должен идти символ \"[\". Позиция: {TokenNamberPos + TokenValue.Length}\n"; return errors;
            }
            if (temp_pos < tokens.Count - 1)
            {
                if (tokens[temp_pos + 1].TokenValue != "[")
                {
                    errors = $"После ключевого слова while должен идти символ \"[\". Позиция: {TokenNamberPos + TokenValue.Length}\n"; return errors;
                }
            }
            while (temp_pos < tokens.Count - 1)
            {
                if (tokens[temp_pos].TokenValue == "]")
                {
                    //Проверка правильности математического выражения

                    temp_pos++;

                    if (tokens[temp_pos].TokenValue != "(")
                    {
                        errors = $"После закрывающей скобки условия \"]\" должна идти скобка \"(\". Позиция: {tokens[temp_pos - 1].TokenNamberPos + 1}\n"; return errors;
                    }
                    while (temp_pos < tokens.Count - 1)
                    {
                        if (tokens[temp_pos].TokenValue == ")")
                        {
                            return errors;
                        }
                        temp_pos++;
                    }
                    errors = $"Нет закрывающей скобки \")\" для while. Позция while: {TokenNamberPos}"; return errors;
                }
                temp_pos++;
            }
            errors = $"Нет закрывающей скобки \"]\" для while. Позция while: {TokenNamberPos}";
            return errors;
        }
    }

    class For : BaseTokens
    {
        public For(int numberPos, int numberStr) : base(numberPos, numberStr)
        {
            TokenNamberPos = numberPos;
            TokenType = "Ключевое слово";
            TokenValue = "for";
        }

        public string CheckingErrors(in List<BaseTokens> tokens, ref string errors, int pos_now)
        {
            return errors;
        }
    }

    class Func : BaseTokens
    {
        public Func(int numberPos, int numberStr) : base (numberPos, numberStr)
        {
            TokenNamberPos = numberPos;
            TokenType = "Ключевое слово";
            TokenValue = "func";
        }
        public override string CheckingErrors(in List<BaseTokens> tokens, ref string errors, int pos_now)
        {
            return errors;
        }
    }

    class Return : BaseTokens
    {
        public Return(int numberPos, int numberStr) : base(numberPos, numberStr)
        {
            TokenNamberPos = numberPos;
            TokenType = "Ключевое слово";
            TokenValue = "return";
        }
        public override string CheckingErrors(in List<BaseTokens> tokens, ref string errors, int pos_now)
        {
            return errors;
        }
    }

    class Yes : BaseTokens
    {
        public Yes(int numberPos, int numberStr) : base(numberPos, numberStr)
        {
            TokenNamberPos = numberPos;
            TokenType = "Ключевое слово";
            TokenValue = "yes";
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
            TokenNamberPos = numberPos;
            TokenType = "Ключевое слово";
            TokenValue = "no";
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
            TokenNamberPos = numberPos;
            TokenValue = value;
            TokenType = "Название переменной";
        }
        public override string CheckingErrors(in List<BaseTokens> tokens, ref string errors, int pos_now)
        {
            return errors;
        }
    }

    class Border : BaseTokens
    {
        public Border(int numberPos, string value, int numberStr) : base(numberPos, numberStr)
        {
            TokenNamberPos = numberPos;
            TokenValue = value;
            TokenType = "Знак границы";
        }

        public override string CheckingErrors(in List<BaseTokens> tokens, ref string errors, int pos_now)
        {
            return errors;
        }
    }

    class Comments : BaseTokens 
    {
        public Comments(int numberPos, int begin, int end, string value, int numberStr) : base(numberPos, numberStr)
        {
            TokenNamberPos = numberPos;
            begin_pos = begin;
            end_pos = end;
            TokenValue = value;
            TokenType = "Знак границы";
        }
        public int begin_pos {  get; }
        public int end_pos { get; }
        public override void WriteAllInfo()
        {
            
        }
        public override string CheckingErrors(in List<BaseTokens> tokens, ref string errors, int pos_now)
        {
            return errors;
        }
    }
}
