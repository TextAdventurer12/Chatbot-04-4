using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chatbot_04_4
{
    // This class is used to manage an instance of the ChatBot
    // There is very little logic here, and it mostly just iterates through the inputHandler list that it is passed
    // The constructor expects
    // nameGetter, the NameReader that will find the user's name
    // inputHandlers, a list of IHs that will be all of the questions that the bot asks. These are done in a random order, so if sequencing is desired then ChainReaders should be used
    // The main usages of this class is the constructor and the Converse() method. Any other usage is not intended, but is unlikely to have a detrimental effect
    internal class BotInstance
    {
        // This is a list of all questions that the bot will ask. It can contain any InputHandler, and will call its defined field getter and reply functions
        public List<CommonIH> inputHandlers = new List<CommonIH>();
        // This is a unique Input Handler because the user_name variable must be set, and is dependant specifically on the NameReaderIH
        public NameReaderIH nameGetter = new NameReaderIH();
        // This is the basic constructor, asking for the name getter and all other questions
        public BotInstance(NameReaderIH nameGetter, List<CommonIH> inputHandlers)
        {
            this.inputHandlers = inputHandlers;
            id = hash_time(DateTime.Now.ToString());
            Converse();
        }
        // simple function to get a relatively unique id for the chatbot at every instance
        // This could probably just call r.Next, but there's no real need
        private static int hash_time(string time)
        {
            int sum = 0;
            foreach (char c in time)
                sum += Math.Abs((int)(c * Math.Sin(c + (c << 3) / (c >> 5))));
            return sum;
        }
        // This is the chatbot's name
        int id;
        // This is the user's name, and will replace any $ characters inside of replies (if my code works, so it won't)
        string user_name;
        // This is the main function of this class, and will just randomly iterate through the question list
        public void Converse()
        {
            Visor.WriteLine($"Hello! I am ChatBot {id}");
            user_name = nameGetter.field;
            while (inputHandlers.Count > 0)
            {
                int ind = Utils.r.Next(0, inputHandlers.Count);
                Console.WriteLine(inputHandlers.values[ind].reply(inputHandlers.values[ind].field == "yes", user_name));
                inputHandlers.RemoveAt(ind);
            }
        }
    }
}