namespace Guide.Services
{
    public class Shared
    {
        public static string GetEuDatabasePath()
        {
            return "C:\\Users\\a\\Desktop\\SOFA\\Guide\\Guide\\Database\\stalcraft-database\\global\\";
        }
        public static string GetRuDatabasePath()
        {
            return "C:\\Users\\a\\Desktop\\SOFA\\Guide\\Guide\\Database\\stalcraft-database\\ru\\";
        }
        public static string Reader(string filePath)
        {
            using StreamReader reader = new(filePath);
            string text = reader.ReadToEnd();
            return text;
        }
    }
}
