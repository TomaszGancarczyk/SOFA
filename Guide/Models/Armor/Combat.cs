namespace Guide.Models.Armor
{
    public class Combat
    {
        private readonly DatabaseContext _context;

        public Combat(DatabaseContext context)
        {
            _context = context;
        }
    }
}
