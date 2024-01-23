using System.Security.Cryptography.Xml;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Guide.Models.Objects
{
    public class BarterItemObject
    {
        public List<BarterItem> GetAll()
        {
            return new List<BarterItem>
            {
                swampStone, greenMold, 
                stinkyRoot, crappite, copperWire, 
                spring, radioTransmiter, pickle, alpha, 
                beta, dopestone, northernMoss, remainsOfBatteries, gamma, 
                substance07270, redFern, remainsOfPsyTracker, quantumBattery, 
                lim, bitterleaf, lambda, anomalousBattery, limboplasma, 
                anomalousSerum
            };
        }
        BarterItem swampStone = new BarterItem(
            "https://raw.githubusercontent.com/EXBO-Studio/stalcraft-database/main/global/icons/other/9dknl.png",
            "Swamp Stone",
            "Newbie",
            12,
            0.025,
            "From people in the Swamps",
            "This dark green mineral was formed as a result of the effect of anomalies on the layers of soil in the Swamps. It’s only really useful for jewelry."
        );
        BarterItem greenMold = new BarterItem(
            "https://raw.githubusercontent.com/EXBO-Studio/stalcraft-database/main/global/icons/other/191kg.png",
            "Green Mold",
            "Newbie",
            6,
            0.012,
            "From mutants in the Swamps",
            "A mixture of radiation and the moist conditions of the Swamps gave rise to this mold, which often grows in mutants’ hiding places."
        );
        BarterItem stinkyRoot = new BarterItem(
            "https://raw.githubusercontent.com/EXBO-Studio/stalcraft-database/main/global/icons/other/w30g2.png",
            "Stinky Root",
            "Newbie",
            16,
            0.03,
            "From mutants at the Cordon, Agroprom, the Dark Valley, and the Dump",
            "It’s difficult to describe the odor of the stinky root, which grows primarily at the Cordon. Imagine a mixture of the smells of cilantro, cat urine, and rush hour traffic..."
        );
        BarterItem crappite = new BarterItem(
            "https://raw.githubusercontent.com/EXBO-Studio/stalcraft-database/main/global/icons/other/j0z30.png",
            "Crappite",
            "Newbie",
            24,
            0.05,
            "From mutants at the Cordon, Agroprom, the Dark Valley, and the Dump",
            "Layers of rusted metal, which abound in the Dump, become heated by anomalous activity and turn into a new metal that the diggers named “crappite.”"
        );
        BarterItem copperWire = new BarterItem(
            "https://raw.githubusercontent.com/EXBO-Studio/stalcraft-database/main/global/icons/other/rj6gv.png",
            "Pieces of Copper Wire",
            "Newbie",
            20,
            0.05,
            "From caches in the Dark Valley, Agroprom, and the Dump",
            "Copper wire is the bedrock of the Dump diggers’ economy."
        );
        BarterItem spring = new BarterItem(
            "https://raw.githubusercontent.com/EXBO-Studio/stalcraft-database/main/global/icons/other/pj52w.png",
            "Sprig of Chernobyl Chamomile",
            "Newbie",
            22,
            0.015,
            "From mutants in the Pit, the Forest, and Rostok Factory",
            "Somewhat reminiscent of chamomile, this flower with dark petals grows in mutants’ dens further north. Given that it is extremely poisonous, it’s probably best not to make tea out of it..."
        );
        BarterItem radioTransmiter = new BarterItem(
            "https://raw.githubusercontent.com/EXBO-Studio/stalcraft-database/main/global/icons/other/vn0yr.png",
            "Remains of a Radio Transmitter",
            "Newbie",
            25,
            0.05,
            "From caches in the Pit and the Forest",
            "In some areas of the Zone, you can come across quite a lot of old radio equipment. Any marauder will gladly scavenge the remains of it."
        );
        BarterItem pickle = new BarterItem(
            "https://raw.githubusercontent.com/EXBO-Studio/stalcraft-database/main/global/icons/other/gn9l6.png",
            "Pickle",
            "Newbie",
            32,
            0.02,
            "From people in the Pit, the Forest, and Rostok Factory",
            "This yellowy-green mineral was first discovered in the Rostok Factory. If you pour boiling water into it and leave it for a couple of hours, the resulting decoction can alleviate a hangover. It goes without saying that it’s a really valuable resource!"
        );
        BarterItem alpha = new BarterItem(
            "https://raw.githubusercontent.com/EXBO-Studio/stalcraft-database/main/global/icons/other/556z1.png",
            "Alpha Data Fragment",
            "Newbie",
            420,
            0.015,
            "When you close rifts, explore protoanomalies, and randomly when you detect signals south of the Rostok Factory, in the Pit, and in the Forest",
            "A fragment of data from the Alpha group that was obtained from the corresponding anomaly research installation."
        );
        BarterItem beta = new BarterItem(
            "https://raw.githubusercontent.com/EXBO-Studio/stalcraft-database/main/global/icons/other/olzr6.png",
            "Beta Data Fragment",
            "Newbie",
            600,
            0.015,
            "When you close rifts and randomly when you detect signals in the Dead City, the Graveyard, the Path of Fools, and Army Warehouses",
            "A fragment of data from the Beta group that was obtained from the corresponding anomaly research installation."
        );
        BarterItem dopestone = new BarterItem(
            "https://raw.githubusercontent.com/EXBO-Studio/stalcraft-database/main/global/icons/other/77o96.png",
            "Dopestone",
            "Newbie",
            40,
            0.01,
            "From people in the Dead City, the Graveyard, the Path of Fools, and Army Warehouses",
            "Once, anomalies sprung up all over a large Freedom hideout containing weed... I mean, er... artifacts. That’s where the first forms of dopestone appeared."
        );
        BarterItem northernMoss = new BarterItem(
            "https://raw.githubusercontent.com/EXBO-Studio/stalcraft-database/main/global/icons/other/6ol3p.png",
            "Northern Moss",
            "Newbie",
            32,
            0.01,
            "From mutants in the Dead City, the Graveyard, the Path of Fools, and Army Warehouses",
            "This bluish moss is being used on an experimental basis by a couple of German companies for the production of new antibiotics. As a result, it is extremely valuable."
        );
        BarterItem remainsOfBatteries = new BarterItem(
            "https://raw.githubusercontent.com/EXBO-Studio/stalcraft-database/main/global/icons/other/9dkgl.png",
            "Remains of Batteries",
            "Newbie",
            36,
            0.05,
            "From caches in the Dead City, the Graveyard, the Path of Fools, and Army Warehouses",
            "Back in the day, you used to be able to find a lot more heavy army tech in the Army Warehouses. Now, there’s much less loot, but it still has value."
        );
        BarterItem gamma = new BarterItem(
            "https://raw.githubusercontent.com/EXBO-Studio/stalcraft-database/main/global/icons/other/191ng.png",
            "Gamma Data Fragment",
            "Newbie",
            900,
            0.15,
            "When you close rifts and randomly when you detect signals in the North",
            "A fragment of data from the Gamma group that was obtained from the corresponding anomaly research installation."
        );
        BarterItem substance07270 = new BarterItem(
            "https://raw.githubusercontent.com/EXBO-Studio/stalcraft-database/main/global/icons/other/vn0wr.png",
            "Substance 07270",
            "Newbie",
            48,
            0.04,
            "From people in the North",
            "This mineral has excited the minds of many people from the Mainland. They think that Substance 07270 could be the perfect fuel of the future. The problem is that it can only be found in the northernmost area of the Zone and only in tiny quantities."
        );
        BarterItem redFern = new BarterItem(
            "https://raw.githubusercontent.com/EXBO-Studio/stalcraft-database/main/global/icons/other/dr6nj.png",
            "Red Fern",
            "Newbie",
            60,
            0.03,
            "From mutants in the North",
            "TThe spread of this rare plant across the north of the Zone began from the Red Forest. Red ferns can be turned into extremely effective combat stimulants, so the military from all over the world are interested in buying them."
        );
        BarterItem remainsOfPsyTracker = new BarterItem(
            "https://raw.githubusercontent.com/EXBO-Studio/stalcraft-database/main/global/icons/other/21gkl.png",
            "Remains of a Psy-Tracker",
            "Newbie",
            42,
            0.03,
            "From caches in the North",
            "Not much is known about the developments made by the Zone’s secret labs, but those who live there were distinctly interested in researching the effect of various types of signal on the human brain. The remains of their developments, even those that are not in a working condition, are the stuff of dreams for any mad scientist."
        );
        BarterItem quantumBattery = new BarterItem(
            "https://raw.githubusercontent.com/EXBO-Studio/stalcraft-database/main/global/icons/other/77ov6.png",
            "Quantum Battery",
            "Newbie",
            450,
            0.1,
            "From airdrops in the North",
            "Smuggled into the Zone as contraband, these new batteries based on quantum technology assist scientific expeditions and large clans to work with hi-tech equipment within the CEZ."
        );
        BarterItem lim = new BarterItem(
            "https://raw.githubusercontent.com/EXBO-Studio/stalcraft-database/main/global/icons/other/21365.png",
            "Lim",
            "Newbie",
            50,
            0.1,
            "From people in Limansk",
            "Rumor has it that formations of this smooth mercury-colored metal are nothing more than scrap metal that, due to the “relocation” of Limansk, was compacted into lim."
        );
        BarterItem bitterleaf = new BarterItem(
            "https://raw.githubusercontent.com/EXBO-Studio/stalcraft-database/main/global/icons/other/34305.png",
            "Bitterleaf",
            "Newbie",
            50,
            0.01,
            "From mutants in Limansk",
            "This mutated plant became one of the staples of the diet of mutants in Limansk. Rumor has it that extract of bitterleaf is beneficial for the nervous system."
        );
        BarterItem lambda = new BarterItem(
            "https://raw.githubusercontent.com/EXBO-Studio/stalcraft-database/main/global/icons/other/6o7m0.png",
            "Lambda Data Fragment",
            "Newbie",
            900,
            0.15,
            "When you close rifts in Limansk",
            "A fragment of data from the Lambda group that was obtained from the corresponding anomaly research installation."
        );
        BarterItem anomalousBattery = new BarterItem(
            "https://raw.githubusercontent.com/EXBO-Studio/stalcraft-database/main/global/icons/other/9d1qy.png",
            "Anomalous Battery",
            "Newbie",
            2000,
            0.25,
            "From airdrops in Limansk",
            "These experimental developments can currently only be found on the black market, as official production of them has been deemed illegal. The principle according to which these batteries function is based on the use of the Zone’s anomalous energy. Representatives of the scientific community assure us that anomalous batteries are not safe to use."
        );
        BarterItem limboplasma = new BarterItem(
            "https://raw.githubusercontent.com/EXBO-Studio/stalcraft-database/main/global/icons/other/19402.png",
            "Limboplasma",
            "Newbie",
            3000,
            0.3,
            "From bosses in Limansk",
            "Creatures that somehow manage to survive the constant “relocation” of Limansk in the Zone’s unknown space (or subspace?) are covered in a thin layer of limboplasma. Some scientists also call it “stagnant plasma.”"
        );
        BarterItem anomalousSerum = new BarterItem(
            "https://raw.githubusercontent.com/EXBO-Studio/stalcraft-database/main/global/icons/other/9dk7l.png",
            "Anomalous Serum",
            "Master",
            0,
            0.03,
            "From Weekly Quests",
            "This rare serum is a valuable resource derived from several kinds of artifacts. It is the subject of a number of scientific experiments. Scientists theorize that it could eventually be used to stabilize some of the most dangerous anomalies."
        );
    }
}
