using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chatbot_04_4
{
    class ConsoleVisor
    {
        // Colour used in all Write calls
        public ConsoleColor BotColor;
        // Colour used in all Read calls
        public ConsoleColor UsrColor;
        // Constructor
        public ConsoleVisor(ConsoleColor BotColor, ConsoleColor UsrColor)
        {
            this.BotColor = BotColor;
            this.UsrColor = UsrColor;
        }
        // Will write the string str to the screen and then begin a new line
        public void WriteLine(string str)
        {
            Write(str + "\n");
        }
        // Will write the string str to the string with some display customisation
        public void Write(string str)
        {
            Console.ForegroundColor = BotColor;
            foreach (char c in str)
            {
                Console.Write(c);
                Threading.Thread.Sleep(15);
            }
        }
        // Will get some user input after displaying the string qry
        public string ReadLine(string qry)
        {
            WriteLine(qry);
            return ReadLine();
        }
        // Will get some user input
        public string ReadLine()
        {
            Console.ForegroundColor = UsrColor;
            return Utils.non_nullable(Console.ReadLine());
        }
    }
    // Instance of the Visor class that is to be called directly, no class instances should be made anywhere else
    public static ConsoleVisor Visor = new ConsoleVisor(ConsoleColor.Red, ConsoleColor.Blue);
}