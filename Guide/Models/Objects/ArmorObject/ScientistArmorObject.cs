namespace Guide.Models.Objects.ArmorObject
{
    public class ScientistArmorObject
    {
        public List<Armor> GetAll()
        {
            return new List<Armor>
            {

            };
        }

        static List<BarterItem> barterItems = new BarterItemObject().GetAll();
    }
}
