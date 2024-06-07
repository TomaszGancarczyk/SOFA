namespace Guide.Models.DatabaseModels
{
    public interface IItem
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Rarity { get; set; }
        public string Class { get; set; }
        public double Weight { get; set; }
        public List<string> Features { get; set; }
        public Dictionary<string, int> Properties { get; set; }
        public Dictionary<string, string> Stats { get; set; }
        public string Description { get; set; }
        public string ImgSource { get; set; }

        public ItemBarter Barter { get; set; }

        public Dictionary<int, Dictionary<string, string>> UpgradeStats { get; set; }

        public WeaponModel.DamageGraph DamageGraphField { get; set; }

        public string CompatibleBackpacks { get; set; }
        public string CompatibleContainers { get; set; }

        public Dictionary<string, Dictionary<double, double>> ArtefactStats { get; set; }
        public Dictionary<string, Dictionary<double, double>> PossibleArtefactStats { get; set; }

        public List<string> SuitableFor { get; set; }
        public List<string> AttachmentAmmoType { get; set; }

        public string Obtained { get; set; }
    }
}
