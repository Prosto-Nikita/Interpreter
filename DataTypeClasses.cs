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
            TokenNamberPos = numberPos;
            TokenType = "Тип данных";
            TokenValue = "frac";
        }

        public override string CheckingErrors(in List<BaseTokens> tokens, ref string errors, int pos_now)
        {
            return errors;
        }
    }
    class String : BaseTokens
    {
        public String(int numberPos, int numberStr) : base(numberPos, numberStr)
        {
            TokenNamberPos = numberPos;
            TokenType = "Тип данных";
            TokenValue = "str";
        }


        public override string CheckingErrors(in List<BaseTokens> tokens, ref string errors, int pos_now)
        {
            return errors;
        }
    }
    class Bool : BaseTokens
    {
        public Bool(int numberPos, int numberStr) : base(numberPos, numberStr)
        {
            TokenNamberPos = numberPos;
            TokenType = "Тип данных";
            TokenValue = "bool";
        }

        public override string CheckingErrors(in List<BaseTokens> tokens, ref string errors, int pos_now)
        {
            return errors;
        }
    }
    class Num : BaseTokens
    {
        public Num(int numberPos, int numberStr) : base(numberPos, numberStr)
        {
            TokenNamberPos = numberPos;
            TokenType = "Тип данных";
            TokenValue = "num";
        }

        public override string CheckingErrors(in List<BaseTokens> tokens, ref string errors, int pos_now)
        {
            return errors;
        }
    }
}
