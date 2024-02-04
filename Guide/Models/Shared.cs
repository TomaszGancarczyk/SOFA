using Microsoft.Identity.Client;

namespace Guide.Models
{
    public class Json
    {
        public string Reader(string filePath)
        {
            using StreamReader reader = new(filePath);
            string text = reader.ReadToEnd();
            return text;
        }
    }
}
