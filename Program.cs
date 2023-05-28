using System;
namespace Chatbot_04_4
{
    class Program
    {
        static void Main()
        {
            Dictionary<string, CommonInputHandler> inputHandlers = new Dictionary<string, CommonInputHandler>();
            inputHandlers.Add("Names", new NameReaderIH(new List<string>
            {
                ""
            }, "What is your name?"));
            inputHandlers.Add("Cat", new BooleanReaderIH(
            new string[]
            {
                "I like them too!",
                "I love animals!",
                "They're so fluffy and cute!"
            },
            new string[]
            {
                "I guess they're not for everyone",
                "I like them myself",
                "That's a shame"
            }, true, "Do you like cats?"));
            inputHandlers.Add("Dog", new BooleanReaderIH(new string[]
            {
                "They're quite cute, aren't they!",
                "Some dogs are scary",
                "My family's always wanted a dog, but digital dogs have a strong byte"
            },
            new string[]
            {
                "Dog's aren't my favourite either",
                "I get it, some people just don't like some animals",
                "That's interesting"
            }, true, "Then what about dogs?"));
            while (true)
            {
                List<string> keys = inputHandlers.keys.ToList();
                keys.RemoveAt(0);
                keys.Add("New");
                keys.Add("Complete");
                Menu bot_details = new Menu(
                    keys,
                    "Questions"
                );
                string selected = bot_details.interact();
                if (selected = "New")
                {
                    Console.WriteLine("What is the name for this question?");
                    inputHandlers.Add(Utils.non_nullable(Console.ReadLine()), new BooleanReaderIH(new string[], new string[], true, "Q"));
                }
                else if (selected = "Complete")
                    break;
                else
                {
                    Menu instant = new Menu(new string[]
                    {
                        "Question",
                        "Positive Replies",
                        "Negative Replies"
                    }, selected);
                    string i_selected = instant.interact();
                    if (i_selected == "Question")
                    {
                        Console.Clear();
                        Console.WriteLine(inputHandlers[selected].question);
                        inputHandlers[selected].question = Utils.non_nullable(Console.ReadLine());
                    }
                    else if (i_selected == "Positive Replies")
                    {
                        List<string> reps = inputHandlers[selected].pos_replies;
                        reps.Add("New");
                        Menu men = new Menu(inputHandlers[selected].pos_replies.ToArray(), "Positive Replies");
                        int sel_reply = men.interact_for_index();
                        Console.Clear();
                        Console.WriteLine(inputHandlers[selected].pos_replies[sel_reply]);
                        inputHandlers[selected].pos_replies[sel_reply] = Utils.non_nullable(Console.ReadLine());
                    }
                    else if (i_selected == "Negative Replies")
                    {
                        Menu men = new Menu(inputHandlers[selected].neg_replies.ToArray(), "Negative Replies");
                        int sel_reply = men.interact_for_index();
                        Console.Clear();
                        Console.WriteLine(inputHandlers[selected].neg_replies[sel_reply]);
                        inputHandlers[selected].neg_replies[sel_reply] = Utils.non_nullable(Console.ReadLine());
                    }
                }
            }
            while (will_make.field == "yes")
            {
                Console.WriteLine("What is your question?");
                string q = Utils.non_nullable(Console.ReadLine());
                Console.WriteLine("What are your positive replies?");
                Console.WriteLine("Say END to finish replies");
                string _in = "";
                List<string> pos_replies = new List<string>();
                while (true)
                {
                    _in = Utils.non_nullable(Console.ReadLine());
                    if (_in == "END")
                        break;
                    pos_replies.Add(_in);
                }
                Console.WriteLine("Same thing, but for negative replies");
                _in = "";
                List<string> neg_replies = new List<string>();
                while (true)
                {
                    _in = Utils.non_nullable(Console.ReadLine());
                    if (_in == "END")
                        break;
                    pos_replies.Add(_in);
                }
                Console.WriteLine("What is an easy, one word label for this question?");
                bot.inputHandlers.Add(Utils.non_nullable(Console.ReadLine()), new BooleanReaderIH(pos_replies, neg_replies, true, q));
                will_make.field = null;
                will_make.question = "Would you like to make another?";
            }
            Console.WriteLine("Thanks for using!");
        }
    }
}