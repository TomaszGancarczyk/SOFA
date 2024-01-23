using Guide.Models.Interfaces;

namespace Guide.Models.Objects.BackpackAndContainerObject
{
    public class BackpackObject
    {
        public List<BackpackAndContainer> GetAll()
        {
            return new List<BackpackAndContainer>
            {
               transformer, errandJunior, sports, mbss, hellboy, triZip
            };
        }
        public BackpackAndContainer transformer { get; set; }
        public BackpackAndContainer errandJunior { get; set; }
        public BackpackAndContainer sports { get; set; }
        public BackpackAndContainer mbss { get; set; }
        public BackpackAndContainer hellboy { get; set; }
        public BackpackAndContainer triZip { get; set; }
        public BackpackObject()
        {
            triZip = new BackpackAndContainer(
                "https://raw.githubusercontent.com/EXBO-Studio/stalcraft-database/main/global/icons/containers/lny1.png",
                "Tri-Zip Backpack",
                50,
                4,
                40,
                "Backpack",
                "Stalker",
                1.5,
                new Dictionary<string, string>
                {
                { "The Bar", "1" }
                },
                new List<Barter>
                {
                new Barter(24800, new Dictionary<IBarter, int>
                {

                }),
                new Barter(31360, new Dictionary<IBarter, int>
                {

                })
                },
                new List<IBarter>
                {

                },
                ""
                );
            hellboy = new BackpackAndContainer(
                "https://raw.githubusercontent.com/EXBO-Studio/stalcraft-database/main/global/icons/containers/l332.png",
                "Hellboy Backpack",
                50,
                2,
                28,
                "Backpack",
                "Stalker",
                14.1,
                new Dictionary<string, string>
                {
                { "The Bar", "1" }
                },
                new List<Barter>
                {
                new Barter(25620, new Dictionary<IBarter, int>
                {

                }),
                new Barter(32180, new Dictionary<IBarter, int>
                {

                })
                },
                new List<IBarter>
                {

                },
                "A fairly spacious backpack that comes equipped with two average-sized artifact containers. It gets its name from its visual similarity to the character of the same name."
                );
            mbss = new BackpackAndContainer(
                "https://raw.githubusercontent.com/EXBO-Studio/stalcraft-database/main/global/icons/containers/12r1.png",
                "MBSS Backpack",
                0,
                3,
                30,
                "Backpack",
                "Newbie",
                2,
                new Dictionary<string, string>
                {
                { "Garages", "3" }
                },
                new List<Barter>
                {
                new Barter(3860, new Dictionary<IBarter, int>
                {

                })
                },
                new List<IBarter>
                {
                hellboy, triZip
                },
                ""
                );
            sports = new BackpackAndContainer(
                "https://raw.githubusercontent.com/EXBO-Studio/stalcraft-database/main/global/icons/containers/odq0.png",
                "Sports Bag",
                0,
                2,
                20,
                "Backpack",
                "Newbie",
                1.5,
                new Dictionary<string, string>
                {
                { "Garages", "1" }
                },
                new List<Barter>
                {
                new Barter(2190, new Dictionary<IBarter, int>
                {

                })
                },
                new List<IBarter>
                {

                },
                ""
                );
            errandJunior = new BackpackAndContainer(
                "https://raw.githubusercontent.com/EXBO-Studio/stalcraft-database/main/global/icons/containers/7yl7.png",
                "Errand Junior Backpack",
                0,
                2,
                27,
                "Backpack",
                "Newbie",
                1.6,
                new Dictionary<string, string>
                {
                { "Garages", "1" }
                },
                new List<Barter>
                {
                new Barter(2190, new Dictionary<IBarter, int>
                {

                })
                },
                new List<IBarter>
                {
                mbss
                },
                ""
                );
            transformer = new BackpackAndContainer(
                "https://raw.githubusercontent.com/EXBO-Studio/stalcraft-database/main/global/icons/containers/jmp6.png",
                "Transformer Bag",
                0,
                1,
                15,
                "Backpack",
                "Picklock",
                1,
                new Dictionary<string, string>
                {
                { "Ataman's HQ", "3" }
                },
                new List<Barter>
                {
                new Barter(510, new Dictionary<IBarter, int>
                {

                })
                },
                new List<IBarter>
                {
               errandJunior, sports
                },
                ""
                );
        }
    }
}
