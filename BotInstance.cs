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
        public NameReaderIH nameGetter = new NameReaderIH();
        public BotInstance(NameReaderIH nameGetter, List<CommonInputHandler> inputHandlers)
        {
            this.inputHandlers = inputHandlers;
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
