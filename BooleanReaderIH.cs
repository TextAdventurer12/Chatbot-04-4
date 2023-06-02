using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chatbot_04_4
{
    // Reads in a yes/no input from the user
    // The constructor will expect:
    // Replies for if the user says yes
    // Replies for if the user says no
    // The question that the question asks
    // Values are read from the field property. There is no need to define this, as the getter will automatically invoke all functions to fill the value AT GETTER CALL. This involves a call to ReadLine(), so should be managed
    // This class only has three calls that should be made: Construction, field getting, and reply.
    internal class BooleanReaderIH : CommonIH
    {
        // Arrays of keywords to indicate the reply in a sentence
        private static string[] positives = { "true", "correct", "agree", "like", "love"};
        private static string[] f_positive = { "yes", "ye", "yeah", "yep", "yup", "aye" };
        private static string[] negatives = { "false", "incorrect", "disagree", "dislike", "hate", "despise" };
        private static string[] f_negative = { "no", "nope", "nay", "nah" };
        private static string[] inverters = { "not", "don't" };
        // holds possible replies of the input handler based on the user's input
        private List<string> neg_replies;
        private List<string> pos_replies;
        // whether or not the input handler must know of the reply
        private bool certainty;
        // checks for inverting keywords that reverse the meaning of the reply
        private bool is_inverted()
        {
            foreach (string s in input_words)
                if (inverters.Contains(s.ToLower()))
                    return true;
            return false;
        }
        // checks for the positve and negative keywords of the input
        private bool get_type()
        {
            foreach(string s in input_words)
                if (positives.Contains(new StringHandler(s).remove_special_chars().ToLower()))
                    return is_inverted() ? false : true;
            foreach (string s in input_words)
                if (negatives.Contains(new StringHandler(s).remove_special_chars().ToLower()))
                    return is_inverted() ? true : false;
            foreach (string s in input_words)
                if (f_positive.Contains(new StringHandler(s).remove_special_chars().ToLower()))
                    return true;
            foreach (string s in input_words)
                if (f_negative.Contains(new StringHandler(s).remove_special_chars().ToLower()))
                    return false;
            throw new Exception();
        }
        // selects a reply from the two lists depending on the user's input
        public override string reply(bool was_yes, string user_name)
        {
            string sel = was_yes ? Utils.get_random(pos_replies) : Utils.get_random(neg_replies);
            List<string> sels = sel.Split('$').ToList();
            if (sels.Count == 1)
                return sel;
            if (sels.Count > 2)
                throw new Exception();
            // TODO: this code is dangerous and questionable
            for (int i = 0; i < sels.Count; i++)
                if (sels[i].Contains('$'))
                    sels[i].Remove('$');
            return sels[0] + user_name + sels[1];
        }
        // function for filling the input handler's field (refer to CommonIH for field definition)
        public override string find_field()
        {
            ConsoleVisor.Visor.WriteLine(question);
            user_input = ConsoleVisor.Visor.ReadLine();
            string feld;
            try
            {
                feld = get_type() ? "yes" : "no";
            }
            catch
            {
                if (certainty)
                {
                    ConsoleVisor.Visor.WriteLine("Sorry, I'm not sure what you mean, please say that again");
                    return find_field();
                }
                feld = "?";
            }
            return feld;
        }
        // Constructor
        public BooleanReaderIH(IEnumerable<string> pos_replies, IEnumerable<string> neg_replies, string question) : base(question)
        {
            this.certainty = true;
            this.pos_replies = new List<string>();
            foreach (string s in pos_replies)
                this.pos_replies.Add(new string(s));
            this.neg_replies = new List<string>();
            foreach (string s in neg_replies)
                this.neg_replies.Add(new string(s));
        }
    }
}