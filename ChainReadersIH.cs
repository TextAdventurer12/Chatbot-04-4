using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chatbot_04_4
{
    // This is an ugly class that is dissimilar to any other Input Handler, and would probably do better as some form of IEnumerable, but it would be too difficult to fix it
    // The constructor takes an array of other Input Handlers, which will be called consecutively
    // This is invoked similiarly to other input handlers
    // This class only exists to allow for multiple questions to be asked in a custom order, while allowing general questions to be asked randomly. I don't believe there is a better way to accomplish that
    internal class ChainReaders : CommonIH
    {
        // List of readers that will be called in order
        List<CommonIH> readers = new List<CommonIH>();
        // This will call every item in the readers list consecutively
        public override string reply(bool was_yes, string user_name)
        {
                foreach (CommonIH IH in readers)
                    ConsoleVisor.Visor.WriteLine(IH.reply(IH.field == "yes", user_name));
                return "";
        }
        // simple constructor based on a list of input handlers
        public ChainReaders(IEnumerable<CommonIH> readers) : base()
        {
            this.readers = readers.ToList();
        }
    }
}