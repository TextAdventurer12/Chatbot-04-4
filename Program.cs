using System;
namespace Chatbot_04_4
{
    class Program
    {
        static void Main()
        {
            Dictionary<string, CommonInputHandler> inputHandlers = new Dictionary<string, CommonInputHandler>();
            inputHandlers.Add("Name", new NameReaderIH(new List<string>
            {
                ""
            }, "What is your name?"));
            inputHandlers.Add("Cat", new BooleanReaderIH(
            new string[]
            {
                "I like them too!",
                "That's cool $, I also like cats!",
                "I love animals!",
                "They're so fluffy and cute!"
            },
            new string[]
            {
                "I guess they're not for everyone",
                "Ok $, I guess they're just not for you",
                "I like them myself",
                "That's a shame"
            }, true, "Do you like cats?"));
            inputHandlers.Add("Dog", new BooleanReaderIH(new string[]
            {
                "They're quite cute, aren't they!",
                "Some dogs are scary",
                "My family's always wanted a dog, but digital dogs have a strong byte",
                "If you had a dog, what would you name it $?",
            },
            new string[]
            {
                "Dog's aren't my favourite either",
                "Really $? Most people like them",
                "I get it, some people just don't like some animals",
                "That's interesting"
            }, true, "Then what about dogs?"));
            while (true)
            {
                Console.Clear();
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
                        Menu men = new Menu(reps, "Positive Replies");
                        int sel_reply = men.interact_for_ind
            foreach (CommonInputHandler IH in inputHandlers)
                Console.WriteLine(IH.reply(IH.field == "yes"));ex();
                        Console.Clear();
                        if (reps[sel_reply] == "New")
                            inputHandlers[selected].pos_replies.Add(Utils.non_nullable(Console.ReadLine()));
                        else
                        {
                            Console.WriteLine(inputHandlers[selected].pos_replies[sel_reply]);
                            inputHandlers[selected].pos_replies[sel_reply] = Utils.non_nullable(Console.ReadLine());
                            if (inputHandlers[selected].pos_replies[sel_reply] == "")
                                inputHandlers[selected].pos_replies.RemoveAt(sel_reply);
                        }
                    }
                    else if (i_selected == "Negative Replies")
                    {
                        List<string> reps = inputHandlers[selected].neg_replies;
                        reps.Add("New");
                        Menu men = new Menu(reps.ToArray(), "Negative Replies");
                        int sel_reply = men.interact_for_index();
                        Console.Clear();
                        if (reps[sel_reply] == "New")
                            inputHandlers[selected].neg_replies.Add(Utils.non_nullable(Console.ReadLine()));
                        else
                        {
                            Console.WriteLine(inputHandlers[selected].neg_replies[sel_reply]);
                            inputHandlers[selected].neg_replies[sel_reply] = Utils.non_nullable(Console.ReadLine());
                            if (inputHandlers[selected].neg_replies[sel_reply] == "")
                                inputHandlers[selected].neg_replies.RemoveAt(sel_reply);
                        }
                    }
                }
            }
            BotInstance bot = new BotInstance(inputHandlers);
            bot.Converse();
        }
    }
}