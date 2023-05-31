using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chatbot_04_4
{
    // Basic utility functions
    internal class Utils
    {
        public static Random r = new Random();
        public static T get_random<T>(List<T> ls) => ls[r.Next(0, ls.Count)];
        public static string non_nullable(string? msg)
        {
            if (msg == null)
                throw new Exception("Hella Cringe!");
            return msg;
        }
    }
}
