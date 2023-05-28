using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chatbot_04_4
{
    internal class Menu
    {
        public string? title { get; set; }
        public List<string> items { get; set; }
        private int index;
        public Menu(string[] items, string? title=null)
        {
            this.items = items.ToList();
            this.title = title;
            index = 0;
        }
        public string interact() => items[interact_for_index()];
        // WARNING: REMOVES STDOUT, recommended to put a wait before invoking the function
        public int interact_for_index()
        {
            Console.Clear();
            while (true)
            {
                Console.SetCursorPosition(0, 0);
                Console.ForegroundColor = ConsoleColor.White;
                Console.BackgroundColor = ConsoleColor.Black;
                if (title != null)
                    Console.WriteLine(title);
                for (int i = 0; i < items.Count; i++)
                {
                    if (i == index)
                    {
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.BackgroundColor = ConsoleColor.White;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.BackgroundColor = ConsoleColor.Black;
                    }
                    Console.WriteLine(items[i]);
                }
                ConsoleKeyInfo key = Console.ReadKey();
                if (key.Key == ConsoleKey.W || key.Key == ConsoleKey.UpArrow)
                    index--;
                if (key.Key == ConsoleKey.S || key.Key == ConsoleKey.DownArrow)
                    index++;
                if (key.Key == ConsoleKey.Enter)
                    return index;
                index = index < 0 ? items.Count - 1 : index % items.Count;
            }
        }
    }
}
