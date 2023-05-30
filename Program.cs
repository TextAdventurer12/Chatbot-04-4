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
            inputHandlers.Add("Animal", new FavouriteReaderIH(new string[]
            {
                "Cats",
                "Dogs",
                "Rabbits",
                "Lions",
                "Dinosaurs",
                "Lizards"
            }, new string[][]
            {
                new string[] {"I like cats too!", "Wow $! Cat's are also my favourite"},
                new string[] {"They are man's best friend", "I'm not a fan myself"},
                new string[] {"I also like bunny ears :)", "They have fluffy tails"},
                new string[] {"I think they're big and strong", "roar :O"},
                new string[] {"When I was a kid I worshipped dinosaurs, I always wanted to be a dinosaur. I wanted to be a Tyrannosaurus Rex more than anything in the world. I made my arms short and I roamed the backyard, I chased the neighborhood cats, I growled and I roared. Everybody knew me and was afraid of me.", "The T-Rex is my favourite dinosaur"},
                new string[] {"Lizards are cute, they look so warm and comfy on rocks", "They are cool"}
            }, "Which of these is your favourite?"));
            BotInstance bot = new BotInstance(inputHandlers.Values.ToList());
            bot.Converse();
        }
    }
}