using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Monkeys.Models;
using System.Linq;
using System.Threading.Tasks;

namespace Monkeys.Helpers
{
    public static class MonkeyHelper
    {

        private static Random random;

        public static Monkey GetRandomMonkey()
        {
            //var output = Newtonsoft.Json.JsonConvert.SerializeObject(Monkeys);
            return Monkeys[random.Next(0, Monkeys.Count)];
        }


        public static ObservableCollection<Grouping<string, Monkey>> MonkeysGrouped { get; set; }

        public static ObservableCollection<Monkey> Monkeys { get; set; }

        static async void LoadData()
        {
            foreach (var monkey in Monkeys)
            {
                await Task.Delay(500);

                switch (monkey.Name)
                {
                    case "Baboon":
                        monkey.Load("Africa & Asia",
                            "Baboons are African and Arabian Old World monkeys belonging to the genus Papio, part of the subfamily Cercopithecinae.",
                            "http://upload.wikimedia.org/wikipedia/commons/thumb/f/fc/Papio_anubis_%28Serengeti%2C_2009%29.jpg/200px-Papio_anubis_%28Serengeti%2C_2009%29.jpg");
                        break;

                    case "Capuchin Monkey":
                        monkey.Load("Central & South America",
                          "The capuchin monkeys are New World monkeys of the subfamily Cebinae. Prior to 2011, the subfamily contained only a single genus, Cebus.",
                          "http://upload.wikimedia.org/wikipedia/commons/thumb/4/40/Capuchin_Costa_Rica.jpg/200px-Capuchin_Costa_Rica.jpg");
                        break;
                    case "Blue Monkey":
                        monkey.Load("Central and East Africa",
                          "The blue monkey or diademed monkey is a species of Old World monkey native to Central and East Africa, ranging from the upper Congo River basin east to the East African Rift and south to northern Angola and Zambia.",
                          "http://upload.wikimedia.org/wikipedia/commons/thumb/8/83/BlueMonkey.jpg/220px-BlueMonkey.jpg");
                        break;
                    case "Squirrel Monkey":
                        monkey.Load("Central & South America",
                          "The squirrel monkeys are the New World monkeys of the genus Saimiri. They are the only genus in the subfamily Saimirinae. The name of the genus Saimiri is of Tupi origin, and was also used as an English name by early researchers.",
                          "http://upload.wikimedia.org/wikipedia/commons/thumb/2/20/Saimiri_sciureus-1_Luc_Viatour.jpg/220px-Saimiri_sciureus-1_Luc_Viatour.jpg");
                        break;
                    case "Golden Lion Tamarin":
                        monkey.Load("Brazil",
                          "The golden lion tamarin also known as the golden marmoset, is a small New World monkey of the family Callitrichidae.",
                          "http://upload.wikimedia.org/wikipedia/commons/thumb/8/87/Golden_lion_tamarin_portrait3.jpg/220px-Golden_lion_tamarin_portrait3.jpg");
                        break;
                    case "Howler Monkey":
                        monkey.Load("South America",
                          "Howler monkeys are among the largest of the New World monkeys. Fifteen species are currently recognised. Previously classified in the family Cebidae, they are now placed in the family Atelidae.",
                          "http://upload.wikimedia.org/wikipedia/commons/thumb/0/0d/Alouatta_guariba.jpg/200px-Alouatta_guariba.jpg");
                        break;

                    case "Japanese Macaque":
                        monkey.Load("Japan",
                          "The Japanese macaque, is a terrestrial Old World monkey species native to Japan. They are also sometimes known as the snow monkey because they live in areas where snow covers the ground for months each.",
                          "http://upload.wikimedia.org/wikipedia/commons/thumb/c/c1/Macaca_fuscata_fuscata1.jpg/220px-Macaca_fuscata_fuscata1.jpg");
                        break;
                    case "Mandrill":
                        monkey.Load("Southern Cameroon, Gabon, Equatorial Guinea, and Congo",
                          "The mandrill is a primate of the Old World monkey family, closely related to the baboons and even more closely to the drill. It is found in southern Cameroon, Gabon, Equatorial Guinea, and Congo.",
                          string.Empty);
                        break;
                    case "Proboscis Monkey":
                        monkey.Load("Borneo",
                          "The proboscis monkey or long-nosed monkey, known as the bekantan in Malay, is a reddish-brown arboreal Old World monkey that is endemic to the south-east Asian island of Borneo.",
                          "http://upload.wikimedia.org/wikipedia/commons/thumb/e/e5/Proboscis_Monkey_in_Borneo.jpg/250px-Proboscis_Monkey_in_Borneo.jpg");
                        break;
                }
            }
        }

        static MonkeyHelper()
        {
            random = new Random();
            Monkeys = new ObservableCollection<Monkey>();

            Monkeys.Add(new Monkey
            {
                Name = "Baboon",
            });

            Monkeys.Add(new Monkey
            {
                Name = "Capuchin Monkey",
            });

            Monkeys.Add(new Monkey
            {
                Name = "Blue Monkey",
            });


            Monkeys.Add(new Monkey
            {
                Name = "Squirrel Monkey",
            });

            Monkeys.Add(new Monkey
            {
                Name = "Golden Lion Tamarin",
            });

            Monkeys.Add(new Monkey
            {
                Name = "Howler Monkey",
            });

            Monkeys.Add(new Monkey
            {
                Name = "Japanese Macaque",
            });

            Monkeys.Add(new Monkey
            {
                Name = "Mandrill",
            });

            Monkeys.Add(new Monkey
            {
                Name = "Proboscis Monkey",
            });


            var sorted = from monkey in Monkeys
                         orderby monkey.Name
                         group monkey by monkey.NameSort into monkeyGroup
                         select new Grouping<string, Monkey>(monkeyGroup.Key, monkeyGroup);

            MonkeysGrouped = new ObservableCollection<Grouping<string, Monkey>>(sorted);

            LoadData();
        }
    }
}
