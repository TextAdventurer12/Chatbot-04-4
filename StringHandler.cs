using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chatbot_04_4
{
    // witch magic
    // Structure to represent a simple sentence that can be a boolean question
    internal class StringHandler
    {
        string str;
        private const string SPECIAL_CHARS = "!@#$%^&*()? /,.'\" \\";
        private const string CAPS = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        public List<string> get_capitalised()
        {
            List<string>? capital_words = new List<string>();
            List<string> words = str.Split(' ').ToList();
            foreach (string s in words)
                if (CAPS.Contains(s[0]))
                    capital_words.Add(new StringHandler(s).remove_special_chars());
            if (capital_words.Count == 0)
                throw new Exception();
            return capital_words;
        }
        // a boolean function that determines if a string contains any character of another string
        public bool contains_any(string keys)
        {
            foreach (char key in keys)
                if (str.Contains(key))
                    return true;
            return false;
        }
        // returns a new string that is the input string with all special characters removed
        public string remove_special_chars()
        {
            while (contains_any(SPECIAL_CHARS))
            {
                int i;
                for (i = 0; !SPECIAL_CHARS.Contains(str[i]); i++) ;
                str = str.Remove(i, 1);
            }
            return str;
        }
        // returns a new string with an escape sequence on grammatical capitals
        // TODO: make this work
        public void mark_grammatical_caps()
        {
            for (int i = 0; i < str.Length; i++)
            {
                if (SPECIAL_CHARS.Contains(str[i]))
                    for (int j = i + 1; j < str.Length; j++)
                        if (str[j] >= 'A' && str[j] <= 'Z')
                        {
                            str.Insert(j - 1, "|");
                            j = str.Length;
                        }
            }
        }
        public string[] split_any(string keys)
        {
            List<string> strings = str.Split(keys[0]).ToList();
            for (int i = 1; i < keys.Length; i++)
            {
                List<string> nx_str = new List<string>();
                foreach(string str in strings)
                {
                    string[] t_str = str.Split(keys[i]);
                    foreach (string t in t_str)
                        nx_str.Add(t);
                }
                strings = nx_str;
            }
            return strings.ToArray();
        }
        public StringHandler(string str)
        {
            this.str = str;
        }
        public static implicit operator string(StringHandler str) => str.str;
        public static explicit operator StringHandler(string str) => new StringHandler(str);
        public static StringHandler operator +(StringHandler a, string b) => new StringHandler(a.str + b);
        public char this[int index] => str[index];
        public StringHandler Remove(int start_index, int count) => new StringHandler(str.Remove(start_index, count));
    }
}