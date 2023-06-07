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
        List<List<string>> options;
        // A set of replies based on each option. Each index in the top level list is the set of replies for the corresponding index
        // The final item in this array is the else case
        List<List<string>> replies;
        // Takes in the options set, then the set of replies sets, then the question that is passed to the base CommonIH class
        public FavouriteReaderIH(IEnumerable<string>[] options, IEnumerable<IEnumerable<string>> replies, string question) : base(question)
        {
            this.options = new List<List<string>>();
            for (int i = 0; i < options.Count(); i++)
            {
                this.options.Add(new List<string>());
                foreach (string str in options[i])
                    this.options[i].Add(str.ToLower());
            }
            this.replies = new List<List<string>>();
            foreach (IEnumerable<string> s_l in replies)
                this.replies.Add(s_l.ToList());
        }
        public int fieldIndex()
        {
            for (int i = 0; i < options.Count; i++)
                if (options[i].Contains(field.ToLower()))
                    return i;
            return replies.Count - 1;
        }
        // Reply method. The boolean argument is there for compatability, and is not used.
        public override string reply(bool was_yes, string user_name) => Utils.get_random(replies[fieldIndex()]).Replace("$", user_name);
        // Invokes the general menu class to find the field
        public override string find_field()
        {
            ConsoleVisor.Visor.WriteLine(question);
            foreach (List<string> s in options)
                foreach (string str in s)
                    foreach (string b in input_words)
                        if (new StringHandler(b.ToLower()).remove_special_chars() == str)
                            return str;
            return "else";
        }
    }
}