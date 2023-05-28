using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chatbot_04_4
{
    internal class NameReaderIH : CommonInputHandler
    {
        public override string reply(string user_name)
        {
            return $"Hello {user_name}! It's nice to meet you!";
        }
        private bool is_valid_name(string name)
        {
            if (name[0] > 'Z')
                return false;
            if (name != ((StringHandler)name).remove_special_chars())
                return false;
            if (name == "I")
                return false;
            return true;
        }
        public override string find_field()
        {
            Console.WriteLine(question);
            user_input = Utils.non_nullable(Console.ReadLine());
            return get_name();
        }
        public string get_name()
        {
            List<string> names;
            try
            {
                names = new StringHandler(user_input).get_capitalised().Where((word) => is_valid_name(word)).ToList();
                var name_getter = new StringHandler(user_input).split_any(".!?");
                var encapsulated = new List<List<string>>();
                foreach (string name in name_getter)
                    encapsulated.Add(name.Split(' ').ToList());
                if (names.Count == 0)
                    throw new Exception();
                if (names.Count > 1)
                    names = names.Where((word) => !first_word(word, encapsulated)).ToList();
            }
            catch
            {
                Console.WriteLine("Please start your name with a capital letter");
                d_opinion -= 0.1;
                user_input = Utils.non_nullable(Console.ReadLine());
                return get_name();
            }
            if (names.Count > 1)
            {
                Console.WriteLine("Sorry, please don't use too many words that start with capital letters");
                d_opinion -= 0.1;
                user_input = Utils.non_nullable(Console.ReadLine());
                return get_name();
            }
            return names[0];
        }
        public NameReaderIH(List<string> replies, string question) : base(replies, question)
        {
            
        }
    }
}