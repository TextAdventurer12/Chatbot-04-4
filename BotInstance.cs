using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chatbot_04_4
{
    internal class BotInstance
    {
        public List<CommonInputHandler> inputHandlers = new List<CommonInputHandler>();
        public BotInstance()
        {
            id = hash_time(DateTime.Now.ToString());
            Converse();
        }
        private static int hash_time(string time)
        {
            int sum = 0;
            foreach (char c in time)
                sum += Math.Abs((int)(c * Math.Sin(c + (c << 3) / (c >> 5))));
            return sum;
        }
        int id;
        string user_name;
        public void Converse()
        {
            Console.WriteLine($"Hello! I am ChatBot {id}");
            foreach (CommonInputHandler IH in inputHandlers)
                Console.WriteLine(IH.reply(IH.field == "yes"));
        }
    }
}
