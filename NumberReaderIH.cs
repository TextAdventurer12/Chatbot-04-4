using System;

namespace Chatbot_04_4
{
    class NumberReaderIH : CommonIH
    {
        public List<double> barrier;
        public List<List<string>> replies;
        public double? getNumbers()
        {
            double re;
            foreach (string str in input_words)
                if (double.TryParse(str, re))
                    return re;
            return null;
        }
        public int get_loc()
        {
            for (int i = 0; i < barrier.Count; i++)
                if (double.Parse(field) < barrier[i])
                    return i;
        }
        public override string reply(bool was_yes, string user_name) => Utils.get_random<string>(replies[ind]);
        public override string find_field()
        {
            Visor.WriteLine(question);
            double? d = getNumbers();
            if (d == null)
                throw new Exception();
            return d.ToString();
        }
        public NumberReaderIH(string question, IEnumerable<double> barrier, IEnumerable<IEnumerable<string>> replies) : base(question)
        {
            this.barrier = barrier;
            this.replies = replies;
        }
    }
}