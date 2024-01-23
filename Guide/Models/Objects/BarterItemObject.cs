using System.Security.Cryptography.Xml;

namespace Guide.Models.Objects
{
    public class BarterItemObject
    {
        public List<BarterItem> GetAll()
        {
            return new List<BarterItem>
            {
               swampStone, greenMold, stinkyRoot, crappite
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
    }
}
