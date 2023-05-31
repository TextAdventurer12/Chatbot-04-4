using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chatbot_04_4
{
    public class ChainReadersIH : CommonInputHandler
    {
        List<CommonInputHandler> readers = new List<CommonInputHandler>();
        public override string field 
        { 
            get
            {
                foreach (CommonInputHandler IH in readers)
                    Visor.WriteLine(IH.field);
                return "";
            }
            set => base.field = value; 
        }
        public ChainReadersIH(IEnumerable<CommonInputHandler> readers) : base()
        {
            this.readers = readers.ToList();
        }
    }
}