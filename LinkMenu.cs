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
            }
        }
    }
}