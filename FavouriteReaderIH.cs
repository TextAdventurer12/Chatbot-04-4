using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chatbot_04_4
{
    internal class FavouriteReaderIH : CommonInputHandler
    {
        List<string> options;
        List<List<string>> replies;
        public FavouriteReaderIH(IEnumerable<string> options, IEnumerable<IEnumerable<string>> replies, string question) : base(question)
        {
            this.options = options;
            this.replies = replies;
        }
        public override string reply(string user_name)
        {
            string sel = Utils.get_random(replies[options.IndexOf(field)]);
            List<string> sels = sel.Split('$');
            if (sels.Count == 1)
                return sel;
            if (sels.Count > 2)
                throw new Exception();
            for (int i = 0; i < sels.Count; i++)
                sels[i].Remove('$');
            return sels[0] + user_name + sels[1];
        }
        public override string find_field()
        {
            Menu selector = new Menu(options);
            return selector.interact();
            /*foreach(string s in options)
                if (input_words.Contains(s))
                    return s;
            return "else";*/
        }
    }
}