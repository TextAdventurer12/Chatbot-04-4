using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chatbot_04_4
{
    internal class Utils
    {
        public static Random r = new Random();
        public static T get_random<T>(List<T> ls)
        {
            return ls[r.Next(0, ls.Count)];
        }
        public static string non_nullable(string? msg)
        {
            if (msg == null)
                throw new Exception("Hella Cringe!");
            return msg;
        }
        public static void loading_screen(ref Task<RestSharp.RestResponse> request)
        {
            Console.Clear();
            Console.Write("Loading");
            for (int i = 0; i < 3; i++)
            {
                Console.Write(".");
                System.Threading.Thread.Sleep(100);
            }
            if (!request.IsCompleted)
                loading_screen(ref request);
            Console.Clear();
        }
    }
}
