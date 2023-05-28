using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using RestSharp;

namespace Chatbot_04_4
{
    class word_classifier
    {
        public static async Task<RestResponse> get_type(string word)
        {
            var client = new RestClient("https://lingua-robot.p.rapidapi.com/language/v1/entries/");
            var request = new RestRequest($"/en/{word}");
            request.AddHeader("X-RapidAPI-Key", "1d8d89694amsh047fcf155927b0cp145d65jsnde897c114d2f");
            request.AddHeader("X-RapidAPI-Host", "lingua-robot.p.rapidapi.com");
            return await client.ExecuteAsync(request);
        }
        public static bool contains_any_of_type(string[] words, string type)
        {
            var responses = new List<Task<RestResponse>>();
            foreach (string word in words)
                responses.Add(get_type(word));
            while (responses.Where((task) => !task.IsCompleted).ToList().Count > 0)
                Console.Write(".");
            foreach (Task<RestResponse> task in responses)
            {
                string[] types = read_from_JSON(task.Result.Content);
                foreach (string s in types)
                    if (s.Contains(type))
                        return true;
            }
            return false;
        }
        public static string[] read_from_JSON(string JSON)
        {
            string[] entries = JSON.Split(',');
            string parts = "";
            foreach (string str in entries)
                if (str.Contains("partOfSpeech"))
                    parts += str + "\n";
            string[] a_parts = parts.Split('\n');
            for (int i = 0; i < a_parts.Length; i++)
                a_parts[i] = ((StringHandler)a_parts[i]).remove_special_chars();
            List<string> types = new List<string>();
            foreach (string str in a_parts)
                if (!types.Contains(str))
                    types.Add(str);
            return types.ToArray();
        }
        public static string get_word(ref Task<RestSharp.RestResponse> poll)
        {
            Utils.loading_screen(ref poll);
            if (poll.Result.Content == null)
                throw new Exception("Hella Cringe!");
            return poll.Result.Content;
        }
        public static bool is_type(string word, string type)
        {
            Task<RestSharp.RestResponse> poll = get_type(word);
            string[] types = read_from_JSON(get_word(ref poll));
            foreach (string s in types)
                if (s.Contains(type))
                    return true;
            return false;
        }
    }
}