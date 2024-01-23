using Guide.Models;
using Guide.Models.Interfaces;

namespace Guide.Models.Objects
{
    public class ArtifactContainerObject
    {
        public List<ArtifactContainer> GetAllContainers()
        {
            return new List<ArtifactContainer>
            {
                kzs1, kzs2, kzs3, kzs4, kzs5, bearsDen4, bearsDen6, cocoon, forager, hive
            };
        }

        ArtifactContainer kzs1 = new ArtifactContainer(
            "https://raw.githubusercontent.com/EXBO-Studio/stalcraft-database/main/global/icons/containers/9yyq.png",
            "KZS-1 Container",
            50,
            0,
            "Container",
            "Newbie",
            1.75,
            new Dictionary<string, string>
            {
                { "Garages", "1" }
            },
            new List<Barter>
            {
                new Barter(4040, new Dictionary<IBarter, int>
                {

                })
            },
            "One of the first container models for transporting artifacts. Contains only 1 artifact slot but has good shielding capabilities. Widespread and inexpensive."
            );
        ArtifactContainer kzs2 = new ArtifactContainer(
            "https://raw.githubusercontent.com/EXBO-Studio/stalcraft-database/main/global/icons/containers/j33l.png",
            "KZS-2 Container",
            50,
            0,
            "Container",
            "Newbie",
            3.5,
            new Dictionary<string, string>
            {
                { "Garages", "3" }
            },
            new List<Barter>
            {
                new Barter(2990, new Dictionary<IBarter, int>
                {

                })
            },
            "A set of two KZS-1 containers. Lets you carry two artifacts and, obviously, has good shielding capabilities."
            );
        ArtifactContainer kzs3 = new ArtifactContainer(
            "https://raw.githubusercontent.com/EXBO-Studio/stalcraft-database/main/global/icons/containers/2vvv.png",
            "KZS-3 Container",
            50,
            0,
            "Container",
            "Stalker",
            5.25,
            new Dictionary<string, string>
            {
                { "The Bar", "1" }
            },
            new List<Barter>
            {
                new Barter(25980, new Dictionary<IBarter, int>
                {

                }),
                new Barter(33010, new Dictionary<IBarter, int>
                {

                })
            },
            "A set of three KZS-1 containers. Lets you carry three artifacts and, obviously, has good shielding capabilities."
            );
        ArtifactContainer kzs4 = new ArtifactContainer(
            "https://raw.githubusercontent.com/EXBO-Studio/stalcraft-database/main/global/icons/containers/49gj.png",
            "KZS-4 Container",
            50,
            0,
            "Container",
            "Stalker",
            7,
            new Dictionary<string, string>
            {
                { "The Bar", "3" }
            },
            new List<Barter>
            {
                new Barter(31020, new Dictionary<IBarter, int>
                {

                })
            },
            "A set of four KZS-1 containers. Lets you carry four artifacts and, obviously, has good shielding capabilities."
            );
        ArtifactContainer kzs5 = new ArtifactContainer(
            "https://raw.githubusercontent.com/EXBO-Studio/stalcraft-database/main/global/icons/containers/n3v9.png",
            "KZS-5 Container",
            50,
            0,
            "Container",
            "Stalker",
            9,
            new Dictionary<string, string>
            {
                { "The Bar", "4" }
            },
            new List<Barter>
            {
                new Barter(32750, new Dictionary<IBarter, int>
                {

                }),
                new Barter(96780, new Dictionary<IBarter, int>
                {

                })
            },
            "A set of five KZS-1 containers. Lets you carry five artifacts and, obviously, has good shielding capabilities."
            );
        ArtifactContainer bearsDen4 = new ArtifactContainer(
            "https://raw.githubusercontent.com/EXBO-Studio/stalcraft-database/main/global/icons/containers/w4wz.png",
            "Bear's Den - 4 Container",
            60,
            0,
            "Container",
            "Stalker",
            5,
            new Dictionary<string, string>
            {
                { "The Bar", "4" }
            },
            new List<Barter>
            {
                new Barter(44410, new Dictionary<IBarter, int>
                {

                }),
                new Barter(77420, new Dictionary<IBarter, int>
                {

                })
            },
            "A widely-used artifact container model. Has weak shielding capabilities but is easy to produce, reliable, and lets you carry four artifacts. These factors had a strong influence on this model’s popularity."
            );
        ArtifactContainer bearsDen6 = new ArtifactContainer(
            "https://raw.githubusercontent.com/EXBO-Studio/stalcraft-database/main/global/icons/containers/g35n.png",
            "Bear's Den - 6 Container",
            60,
            0,
            "Container",
            "Master",
            7,
            new Dictionary<string, string>
            {
                { "100 Rads Bar", "5" },
                { "Freedom Underground", "5" },
                { "Duty Base", "5" },
                { "Mercenary Camp", "5" },
                { "Covenant Abode", "5" }
            },
            new List<Barter>
            {
                new Barter(1774680, new Dictionary<IBarter, int>
                {

                }),
                new Barter(1774680, new Dictionary<IBarter, int>
                {

                }),
                new Barter(719950, new Dictionary<IBarter, int>
                {

                })
            },
            "A widely-used artifact container model. Has weak shielding capabilities but is easy to produce, reliable, and lets you carry six artifacts. These factors had a strong influence on this model’s popularity."
            );
        ArtifactContainer cocoon = new ArtifactContainer(
            "https://raw.githubusercontent.com/EXBO-Studio/stalcraft-database/main/global/icons/containers/k3oj.png",
            "Cocoon Container",
            93.5,
            0,
            "Container",
            "Veteran",
            7,
            new Dictionary<string, string>
            {
                { "100 Rads Bar", "3" },
                { "Freedom Underground", "3" },
                { "Duty Base", "3" },
                { "Mercenary Camp", "3" },
                { "Covenant Abode", "3" }
            },
            new List<Barter>
            {
                new Barter(1035370, new Dictionary<IBarter, int>
                {

                }),
                new Barter(1035370, new Dictionary<IBarter, int>
                {

                })
            },
            "An alternative version of the Hive, with fewer artifact slots but greater internal protection and reliability."
            );
        ArtifactContainer forager = new ArtifactContainer(
            "https://raw.githubusercontent.com/EXBO-Studio/stalcraft-database/main/global/icons/containers/q194.png",
            "Forager Container",
            60,
            0,
            "Container",
            "Veteran",
            6.5,
            new Dictionary<string, string>
            {
                { "100 Rads Bar", "3" },
                { "Freedom Underground", "3" },
                { "Duty Base", "3" },
                { "Mercenary Camp", "3" },
                { "Covenant Abode", "3" }
            },
            new List<Barter>
            {
                new Barter(1035370, new Dictionary<IBarter, int>
                {

                }),
                new Barter(1054730, new Dictionary<IBarter, int>
                {

                })
            },
            ""
            );
        ArtifactContainer hive = new ArtifactContainer(
            "https://raw.githubusercontent.com/EXBO-Studio/stalcraft-database/main/global/icons/containers/p92d.png",
            "Hive Container",
            85,
            0,
            "Container",
            "Master",
            8,
            new Dictionary<string, string>
            {
                { "100 Rads Bar", "6" },
                { "Freedom Underground", "6" },
                { "Duty Base", "6" },
                { "Mercenary Camp", "6" },
                { "Covenant Abode", "6" }
            },
            new List<Barter>
            {
                new Barter(1633570, new Dictionary<IBarter, int>
                {

                }),
                new Barter(1382860, new Dictionary<IBarter, int>
                {

                }),
                new Barter(1633570, new Dictionary<IBarter, int>
                {

                })
            },
            "While the Bear’s Den was much more compact than the KZS bundle, it was still fairly cumbersome. Scientists conducted a series of projects to improve popular containers. This led to the Hive, a compact, spacious, reliable, but fairly expensive option."
            );
    }
}
