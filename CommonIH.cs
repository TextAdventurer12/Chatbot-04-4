using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chatbot_04_4
{
    // This is the main core class of the program, and all input handlers inherit from it
    // It has basic capabilities to handle understanding a user's input, though it is not specialised and should not be directly created or invoked
    // The only public use of this class is in generic fields for lists or functions
    // The constructor can either take no input, or take the question that will be asked as input
    // The two main functions to be invoked beyond the constructor are the field property and the reply() method
    // The field property will automatically use the find_field() method to get the user's input and identify the needed output of the class
    // The reply(bool, string) method should select from some reply in the inheritor class.
    internal class CommonIH
    {
        // private variable behind the field property
        private string? _field;
        // This is the main entrance property, and will invoke the find_field() function, which is where most unique behaviour occurs
        public virtual string field
        {
            // this will only invoke the find_field function if _field is null, so to refresh conversations it should be reset
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
        // Question that this IH will ask before getting input
        public string question;
        // Hold's the user's reply
        private string? _user_input { get; set; }
        // This is a property that is used to access the user's reply, and will set it if the hidden value is null
        public string user_input { get {
            if (_user_input == null)
                _user_input = Utils.non_nullable(ConsoleVisor.Visor.ReadLine());
            return _user_input;
        }  set
            {
                _user_input = value;
            }
        }
        // Functions for getting the bot's reply from the user input
        public virtual string reply(bool was_yes, string user_name) => "";
        // this is the main property that controls the behaviour of the input handler
        public virtual string find_field() => "";
        // This is used for if the individual words of the user's input are needed
        public List<string>? input_words { get => user_input.Split(' ').ToList(); }
        public CommonIH(string question)
        {
            this.question = question;
        }
        public CommonIH()
        {
            
        }
    }
}