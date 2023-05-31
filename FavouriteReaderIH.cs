using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chatbot_04_4
{
    // Class for finding the user's favourite from a set of options.
    // The Constructor expects:
    // A list of options
    // A lsit of lists of replies, where each list of replies corresponds to the entry in another option
    internal class FavouriteReaderIH : CommonIH
    {
        // The options that the user may choose from
        List<string> options;
        // A set of replies based on each option. Each index in the top level list is the set of replies for the corresponding index
        List<List<string>> replies;
        // Takes in the options set, then the set of replies sets, then the question that is passed to the base CommonIH class
        public FavouriteReaderIH(IEnumerable<string> options, IEnumerable<IEnumerable<string>> replies, string question) : base(question)
        {
            this.options = options.ToList();
            this.replies = new List<List<string>>();
            foreach (IEnumerable<string> s_l in replies)
                this.replies.Add(s_l.ToList());
        }
        // Reply method. The boolean argument is there for compatability, and is not used.
        public override string reply(bool was_yes, string user_name)
        {
            string sel = Utils.get_random(replies[options.IndexOf(field)]);
            List<string> sels = sel.Split('$').ToList();
            if (sels.Count == 1)
                return sel;
            if (sels.Count > 2)
                throw new Exception();
            for (int i = 0; i < sels.Count; i++)
                sels[i].Remove('$');
            return sels[0] + user_name + sels[1];
        }
        // Invokes the general menu class to find the field
        public override string find_field()
        {
            Menu selector = new Menu(options, question);
            return selector.interact();
            /*foreach(string s in options)
                if (input_words.Contains(s))
                    return s;
            return "else";*/
        }
    }
}