using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chatbot_04_4
{
    class LinkMenu<T>
    {
        public string? title;
        public ref IEnumerable<T> r_list;
        private int index;
        public Menu(ref IEnumerable<T> r_list, string? title = null)
        {
            this.r_list = r_list;
            index = 0;
            this.title = title;
        }
        public string interact() => r_list[get_index()];
        public int get_index()
        {
            Console.Clear();
            while (true)
            {
                Console.SetCursorPosition(0, 0);
                Console.BackgroundColor = ConsoleColor.Black;
                if (title != null)
                    Console.WriteLine(title);
                for (int i = 0; i < r_list.Count; i++)
                {
                    if (i == index)
                        Console.BackgroundColor = ConsoleColor.White;
                    else
                        Console.BackgroundColor = ConsoleColor.Black;
                    Console.WriteLine(r_list[i]);
                }
                ConsoleKeyInfo key = Console.ReadKey();
                if (key.Key == ConsoleKey.W || key.Key == ConsoleKey.UpArrow)
                    index--;
                if (key.Key == ConsoleKey.S || key.Key == ConsoleKey.DownArrow)
                    index++;
                if (key.Key == ConsoleKey.Enter)
                    return index;
                index = index < 0 ? r_list.Count - 1 : index % r_list.Count;
            }
        }
    }
}