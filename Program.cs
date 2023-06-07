using System;
namespace Chatbot_04_4
{
    class Program
    {
        static void Main()
        {
            // Set of questions to be asked
            List<CommonIH> inputHandlers = new List<CommonIH>()
            {
            new BooleanReaderIH(
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
                }, "Do you like cats?"),
            new BooleanReaderIH(new string[]
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
                }, "Do you like dogs?"),
            new FavouriteReaderIH(new string[][]
                {
                    new string[] {"Cats", "cat" },
                    new string[] {"Dogs", "dog" },
                    new string[] {"Rabbits", "rabbit" },
                    new string[] {"Lions", "lion" },
                    new string[] {"Dinosaurs", "dinosaur" },
                    new string[] {"Lizards", "lizard" }
                }, new string[][]
                {
                    new string[] {"I like cats too!", "Wow $! Cats are also my favourite"},
                    new string[] {"They are man's best friend", "I'm not a fan myself"},
                    new string[] {"I also like bunny ears :)", "They have fluffy tails"},
                    new string[] {"I think they're big and strong", "roar :O"},
                    new string[] {"When I was a kid I worshipped dinosaurs, I always wanted to be a dinosaur. I wanted to be a Tyrannosaurus Rex more than anything in the world. I made my arms short and I roamed the backyard, I chased the neighborhood cats, I growled and I roared. Everybody knew me and was afraid of me.", "The T-Rex is my favourite dinosaur"},
                    new string[] {"Lizards are cute, they look so warm and comfy on rocks", "They are cool"},
                    new string[] {"Some animals aren't for everyone"}
                }, "What's your favourite animal"),
            new ChainReaders(new CommonIH[]
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
                new FavouriteReaderIH(new string[][]
                {
                    new string[] {"Football" },
                    new string[] {"Rugby" },
                    new string[] {"Hockey" },
                    new string[] {"Chess" },
                    new string[] {"Futsal"},
                    new string[] {"Touch" },
                    new string[] {"Table Tennis", "Ping Pong" },
                    new string[] {"Tennis" },
                    new string[] {"Golf" }
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
                    new string[] {"Are you an old man?", "Quite refined I see", "I've never played myself, but it seems fun"},
                    new string[] {"Some sports aren't for everyone"}
                }, "What's your favourite sport?")
            }),
            new ChainReaders(new CommonIH[]
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
                new FavouriteReaderIH(new string[][]
                {
                    new string[] {"Coffee" },
                    new string[] {"Tea" },
                    new string[] {"Chocolate", "Milo" },
                    new string[] {"Mocha" },
                    new string[] {"Frappuccino" }
                }, new string[][]
                {
                    new string[] {"Coffee's a little too bitter for me", "It can really wake me up in the morning"},
                    new string[] {"I love tea", "It's quite nice to have a cup of tea at the end of the day, isn't it"},
                    new string[] {"I like sweet things", "It's lovely with marshmallows"},
                    new string[] {"That's quite unique", "It is nice to have a bit of sweetness"},
                    new string[] {"They're a touch too sweet for me"},
                    new string[] {"Some drinks aren't for everyone"}
                }, "What's your favourite hot drink?")
            }),
            new NumberReaderIH("How old are you?", new double[] {5, 12, 18, 30, 60}, new string[][]
            {
                new string[] {"You're quite young", "I hope you have parental supervision"},
                new string[] {"That's cool", "Wow $, You're quite young"},
                new string[] {"Same as me :)", "High school's a pain"},
                new string[] {"Quite adult I see", "So you're employed?"},
                new string[] {"That's quite old"},
                new string[] {"I hope you're doing well", "People have been living longer recently"}
            }),
            new FavouriteReaderIH(new string[][]
            {
                new string[] {"pop" },
                new string[] {"rock" },
                new string[] {"classical", "baroque", "romantic" },
                new string[] {"jazz" },
            }, new string[][]
            {
                new string[] {"I guess it is popular", "It's not really for me"},
                new string[] {"I like rock music", "It's my favourite"},
                new string[] {"That's quite refined", "I enjoy classical sometimes as well"},
                new string[] {"I especially like smooth jazz", "It can be quite nice to listen to"},
                new string[] {"That's quite refined", "I enjoy classical sometimes as well"},
                new string[] {"Some types of music aren't for everyone"}
            }, "What's your favourite music genre")
            };
            // name getter property
            NameReaderIH namer = new NameReaderIH("What is your name?");
            // establish and invoke the chatbot with necessary sets
            BotInstance bot = new BotInstance(namer, inputHandlers);
            bot.Converse();
        }
    }
}