namespace Guide.Models.Objects.ArmorObject
{
    public class ComboArmorObject
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
