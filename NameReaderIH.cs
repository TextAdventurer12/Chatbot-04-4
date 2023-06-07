using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chatbot_04_4
{
    // Class to read the user's name
    // The constructor expects:
    // The question to be asked beforehand
    // Is invoked similarly to other input handlers, but there is no reply method
    // This means that the general invocation is just reading the field property
    internal class NameReaderIH : CommonIH
    {
        // returns whether or not the given string is a valid name
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
        // invokes the get_name() method to find the field
        public override string find_field()
        {
            ConsoleVisor.Visor.WriteLine(question);
            return get_name();
        }
        // looks through user input to find the user's name
        public string get_name()
        {
            List<string> names;
            try
            {
                names = new StringHandler(user_input).get_capitalised().Where((word) => is_valid_name(word)).ToList();
                if (names.Count == 0)
                    throw new Exception();
            }
            catch
            {
                ConsoleVisor.Visor.WriteLine("Please start your name with a capital letter");
                user_input = ConsoleVisor.Visor.ReadLine();
                return get_name();
            }
            if (names.Count > 1)
            {
                ConsoleVisor.Visor.WriteLine("Sorry, please don't use too many words that start with capital letters");
                user_input = ConsoleVisor.Visor.ReadLine();
                return get_name();
            }
            return names[0];
        }
        public NameReaderIH(string question) : base(question)
        {
            
        }
    }
}