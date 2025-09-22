using Interpreter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTypeClasses
{
    class Frac : BaseTokens
    {
        public Frac(int numberPos, int numberStr) : base(numberPos, numberStr)
        {
            TokenNumberPos = numberPos;
            TokenType = "Тип данных";
            TokenValue = "frac";
            NumberPos = numberPos;
        }

        public override string CheckingErrors(in List<BaseTokens> tokens, ref string errors, int pos_now)
        {
            if (pos_now < tokens.Count - 1)
            {
                var nextToken = tokens[pos_now + 1];
                if (nextToken.TokenType != "Название переменной")
                {
                    errors += $"Строка {NumberStr}, Позиция {GetPositionInLine()}: После типа данных 'frac' ожидается имя переменной.\n";
                }
            }
            else
            {
                errors += $"Строка {NumberStr}, Позиция {GetPositionInLine()}: После типа данных 'frac' ожидается имя переменной.\n";
            }
            return errors;
        }
    }

    class String : BaseTokens
    {
        public String(int numberPos, int numberStr) : base(numberPos, numberStr)
        {
            TokenNumberPos = numberPos;
            TokenType = "Тип данных";
            TokenValue = "str";
            NumberPos = numberPos;
        }

        public override string CheckingErrors(in List<BaseTokens> tokens, ref string errors, int pos_now)
        {
            if (pos_now < tokens.Count - 1)
            {
                var nextToken = tokens[pos_now + 1];
                if (nextToken.TokenType != "Название переменной")
                {
                    errors += $"Строка {NumberStr}, Позиция {GetPositionInLine()}: После типа данных 'str' ожидается имя переменной.\n";
                }
            }
            else
            {
                errors += $"Строка {NumberStr}, Позиция {GetPositionInLine()}: После типа данных 'str' ожидается имя переменной.\n";
            }
            return errors;
        }
    }

    class Bool : BaseTokens
    {
        public Bool(int numberPos, int numberStr) : base(numberPos, numberStr)
        {
            TokenNumberPos = numberPos;
            TokenType = "Тип данных";
            TokenValue = "bool";
            NumberPos = numberPos;
        }

        public override string CheckingErrors(in List<BaseTokens> tokens, ref string errors, int pos_now)
        {
            if (pos_now < tokens.Count - 1)
            {
                var nextToken = tokens[pos_now + 1];
                if (nextToken.TokenType != "Название переменной")
                {
                    errors += $"Строка {NumberStr}, Позиция {GetPositionInLine()}: После типа данных 'bool' ожидается имя переменной.\n";
                }
            }
            else
            {
                errors += $"Строка {NumberStr}, Позиция {GetPositionInLine()}: После типа данных 'bool' ожидается имя переменной.\n";
            }
            return errors;
        }
    }

    class Num : BaseTokens
    {
        public Num(int numberPos, int numberStr) : base(numberPos, numberStr)
        {
            TokenNumberPos = numberPos;
            TokenType = "Тип данных";
            TokenValue = "num";
            NumberPos = numberPos;
        }

        public override string CheckingErrors(in List<BaseTokens> tokens, ref string errors, int pos_now)
        {
            if (pos_now < tokens.Count - 1)
            {
                var nextToken = tokens[pos_now + 1];
                if (nextToken.TokenType != "Название переменной")
                {
                    errors += $"Строка {NumberStr}, Позиция {GetPositionInLine()}: После типа данных 'num' ожидается имя переменной.\n";
                }
            }
            else
            {
                errors += $"Строка {NumberStr}, Позиция {GetPositionInLine()}: После типа данных 'num' ожидается имя переменной.\n";
            }
            return errors;
        }
    }
}