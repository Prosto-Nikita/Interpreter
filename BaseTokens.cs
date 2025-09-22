using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interpreter
{
    abstract class BaseTokens
    {
        public BaseTokens(int tokenNumberPos, int numberStr)
        {
            TokenNumberPos = tokenNumberPos;
            NumberStr = numberStr;
        }

        public int TokenNumberPos { get; set; }
        public string TokenType { get; set; }
        public string TokenValue { get; set; }

        public int NumberStr { get; set; }
        public int NumberPos { get; set; }

        public virtual void WriteAllInfo(int index = 0)
        {
            StaticMetods.OutputAllInfo(this, index);
        }

        public virtual string CheckingErrors(in List<BaseTokens> tokens, ref string error, int pos_now)
        {
            return error;
        }

        public virtual int GetPositionInLine()
        {
            return NumberPos;
        }
    }
}