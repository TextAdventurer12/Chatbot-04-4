using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chatbot_04_4
{
    class ConsoleVisor
    {
        public ConsoleColor BotColor;
        public ConsoleColor UsrColor;
        public ConsoleVisor(ConsoleColor BotColor, ConsoleColor UsrColor)
        {
            this.BotColor = BotColor;
            this.UsrColor = UsrColor;
        }
        public void WriteLine(string str)
        {
            Write(str + "\n");
        }
        public void Write(string str)
        {
            Console.ForegroundColor = BotColor;
            foreach (char c in str)
            {
                Console.Write(c);
                Threading.Thread.Sleep(15);
            }
        }
        public string ReadLine(string qry)
        {
            WriteLine(qry);
            return ReadLine();
        }
        public string ReadLine()
        {
            Console.ForegroundColor = UsrColor;
            return Utils.non_nullable(Console.ReadLine());
        }
    }
    public static ConsoleVisor Visor = new ConsoleVisor(ConsoleColor.Red, ConsoleColor.Blue);
}