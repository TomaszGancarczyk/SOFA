namespace Guide.Models.Objects.ArmorObject
{
    public class CombatArmorObject
    {
        public List<Armor> GetAll()
        {
            return new List<Armor>
            {
                jacketWithBodyArmor, cloak, currant, huntersCloak, scout, houndmaster, berill5m, worntrapper, striker, trapper, cd2, ghillieSuit, wornHoplite, wornFleece, hoplite, fleece, wornLegionnaire, wornOsh, voshod, legionnaire, osh, wornExoskeleton, damagedCenturion, jaeger, exoskeleton, wornCenturion, wornBeastSlayer, wornMule, centurion, beastSlayer, mule
            };
        }

        static List<BarterItem> barterItems = new BarterItemObject().GetAll();
        public Armor jacketWithBodyArmor { get; set; }
        public Armor cloak { get; set; }
        public Armor currant { get; set; }
        public Armor huntersCloak { get; set; }
        public Armor scout { get; set; }
        public Armor houndmaster { get; set; }
        public Armor berill5m { get; set; }
        public Armor worntrapper { get; set; }
        public Armor striker { get; set; }
        public Armor trapper { get; set; }
        public Armor cd2 { get; set; }
        public Armor ghillieSuit { get; set; }
        public Armor wornHoplite { get; set; }
        public Armor wornFleece { get; set; }
        public Armor hoplite { get; set; }
        public Armor fleece { get; set; }
        public Armor wornLegionnaire { get; set; }
        public Armor wornOsh { get; set; }
        public Armor voshod { get; set; }
        public Armor legionnaire { get; set; }
        public Armor osh { get; set; }
        public Armor wornExoskeleton { get; set; }
        public Armor damagedCenturion { get; set; }
        public Armor jaeger { get; set; }
        public Armor exoskeleton { get; set; }
        public Armor wornCenturion { get; set; }
        public Armor wornBeastSlayer { get; set; }
        public Armor wornMule { get; set; }
        public Armor centurion { get; set; }
        public Armor beastSlayer { get; set; }
        public Armor mule { get; set; }

        public CombatArmorObject()
        {
            mule = new Armor(

                );
        }
    }
}
