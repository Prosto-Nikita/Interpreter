using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interpreter
{
    class BaseTokens
    {
        public BaseTokens(int tokenNamberPos, int numberStr)
        {
            TokenNamberPos = tokenNamberPos;
            NumberStr = numberStr;
        }

        public int TokenNamberPos { get; set; }
        public string TokenType { get; set; }
        public string TokenValue { get; set; }

        public int NumberStr { get; set; }
        public int NumberPos { get; set; }
        public virtual void WriteAllInfo()
        {
            StaticMetods.OutputAllInfo(this);
        }

        public virtual string CheckingErrors(in List<BaseTokens> tokens, ref string error, int pos_now) { return error; }
    }
}
