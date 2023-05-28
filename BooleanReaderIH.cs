using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chatbot_04_4
{
    internal class BooleanReaderIH : CommonInputHandler
    {
        static string[] positives = { "yes", "ye", "yeah", "yep", "yup", "true", "correct", "agree", "like", "love", "aye"};
        static string[] negatives = { "no", "nope", "nay", "nah", "false", "incorrect", "disagree", "dislike", "hate", "nay", "despise" };
        static string[] inverters = { "not", "don't" };
        public List<string> neg_replies;
        public List<string> pos_replies;
        bool certainty;
        public bool is_inverted()
        {
            foreach (string s in input_words)
                if (inverters.Contains(s.ToLower()))
                    return true;
            return false;
        }
        public bool get_type()
        {
            foreach(string s in input_words)
                if (positives.Contains(new StringHandler(s).remove_special_chars().ToLower()))
                    return is_inverted() ? false : true;
            foreach (string s in input_words)
                if (negatives.Contains(new StringHandler(s).remove_special_chars().ToLower()))
                    return is_inverted() ? true : false;
            throw new Exception();
        }
        public override string reply(bool was_yes, string user_name)
        {
            string sel = was_yes ? Utils.get_random(pos_replies) : Utils.get_random(neg_replies);
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
            Console.WriteLine(question);
            user_input = Utils.non_nullable(Console.ReadLine());
            string feld;
            try
            {
                feld = get_type() ? "yes" : "no";
            }
            catch
            {
                if (certainty)
                {
                    Console.WriteLine("Sorry, I'm not sure what you mean, please say that again");
                    return find_field();
                }
                feld = "?";
            }
            return feld;
        }
        public BooleanReaderIH(IEnumerable<string> pos_replies, IEnumerable<string> neg_replies, bool certainty, string question) : base(question)
        {
            this.certainty = certainty;
            this.pos_replies = new List<string>();
            foreach (string s in pos_replies)
                this.pos_replies.Add(new string(s));
            this.neg_replies = new List<string>();
            foreach (string s in neg_replies)
                this.neg_replies.Add(new string(s));
        }
    }
}