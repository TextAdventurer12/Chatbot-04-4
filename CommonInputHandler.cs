using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chatbot_04_4
{
    internal class CommonInputHandler
    {
        public double d_opinion;
        public string? _field;
        public string field
        {
            get
            {
                if (_field == null)
                    _field = find_field();
                return _field;
            }
            set
            {
                _field = value;
            }
        }
        public string question;
        private string? _user_input { get; set; }
        public string user_input { get => _user_input;  protected set
            {
                input_words = value.Split(' ').ToList();
                _user_input = value;
            }
        }
        public virtual string reply() => Utils.get_random(replies);
        public virtual string reply(bool was_yes, string user_name) => "";
        public virtual string reply(string user_name) => "";
        public List<string> replies;
        public List<string> get_words_type(string type) => input_words.Where((word) => word_classifier.is_type(word, type)).ToList();
        public bool first_word(string word, List<List<string>> phrase)
        {
            foreach (List<string> sentence in phrase)
                if (word == sentence[0])
                    return true;
            return false;
        }
        public virtual string find_field() => "";
        public List<string>? input_words { get; protected set; }
        public bool is_question() => user_input.Contains('?');
        public CommonInputHandler(List<string> replies, string question)
        {
            this.question = question;
            d_opinion = 0;
            this.replies = replies;
        }
        public CommonInputHandler(string question)
        {
            this.question = question;
            d_opinion = 0;
            this.replies = new List<string>();
        }
    }
}