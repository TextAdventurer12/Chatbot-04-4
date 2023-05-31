﻿using System;
namespace Chatbot_04_4
{
    class Program
    {
        static void Main()
        {
            Dictionary<string, CommonInputHandler> inputHandlers = new Dictionary<string, CommonInputHandler>();
            NameReaderIH namer = new NameReaderIH(new List<string>
            {
                ""
            }, "What is your name?");
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
            }, "Do you like cats?"));
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
            }, "Then what about dogs?"));
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
            inputHandlers.Add("Sports", new ChainReadersIH(new CommonInputHandler[]
            {
                new BooleanReaderIH(new string[]
                {
                    "So do I!",
                    "Sports are fun :)",
                    "I'm not a massive fan of running"
                }, new string[]
                {
                    "Ok $, I guess sports aren't for everyone",
                    "You should try them sometime",
                    "I don't like them either"
                }, "Do you like sport?"),
                new FavouriteReaderIH(new string[]
                {
                    "Football",
                    "Rugby",
                    "Hockey",
                    "Chess",
                    "Futsal",
                    "Touch",
                    "Table Tennis",
                    "Tennis",
                    "Golf"
                }, new string[][]
                {
                    new string[] {"I play football too!", "Football is fun!", "I liked the world cup"},
                    new string[] {"I play some rugby", "I get scared of being tackled"},
                    new string[] {"A lot of my friends play hockey", "I've heard that its a fun sport"},
                    new string[] {"I see that you're an intellectual", "I'm over 1000 ELO, though some of my brothers are a lot higher rated", "Is that really a sport though?"},
                    new string[] {"Is it very different to football?", "I'm not really sure how different to football it is", "Sounds fun"},
                    new string[] {"Isn't that just rugby?", "Are you scared of tackling?"},
                    new string[] {"Table tennis is fun :)", "I like to play sometimes", "I think you could just play normal tennis"},
                    new string[] {"You must be quite fit", "I've never been good at it"},
                    new string[] {"Are you an old man?", "Quite refined I see", "I've never played myself, but it seems fun"}
                }, "Which of these is your favourite?")
            }));
            inputHandlers.Add("Drinks", new ChainReadersIH(new CommonInputHandler[]
            {
                new BooleanReaderIH(new string[]
                {
                    "I love a cup of tea in the morning",
                    "Wow $, me too :)",
                    "I need some to start me in the morning"
                }, new string[]
                {
                    "How do you survive early mornings?",
                    "I love them myself"
                }, "Do you like hot drinks?"),
                new BooleanReaderIH(new string[]
                {
                    "Thats cool",
                    "We should have one together sometime"
                }, new string[]
                {
                    "I guess it's not for everyone"
                }, "How about tea? It's my favourite"),
                new FavouriteReaderIH(new string[]
                {
                    "Coffee",
                    "Tea",
                    "Hot Chocolate",
                    "Mocha",
                    "Frappuccino"
                }, new string[][]
                {
                    new string[] {"Coffee's a little too bitter for me"}
                }, "What's your favourite?")
            }));
            BotInstance bot = new BotInstance(namer, inputHandlers.Values.ToList());
            bot.Converse();
        }
    }
}