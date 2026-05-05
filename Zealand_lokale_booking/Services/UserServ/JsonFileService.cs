using System.Text.Json;
using Zealand_lokale_booking.Models;

namespace Zealand_lokale_booking.Services.UserServ
{
    public class JsonFileService

    {
        public IWebHostEnvironment WebHostEnvironment { get; }
        public JsonFileService(IWebHostEnvironment webHostEnvironment)
        {
            WebHostEnvironment = webHostEnvironment;
        }
        private string JsonFileName
        {
            get { return Path.Combine(WebHostEnvironment.WebRootPath, "Data", "Users.json"); }
        }


        public void SaveAll(List<User> users)
        {
            using FileStream jsonFileWriter = File.Create(JsonFileName);

            var options = new JsonSerializerOptions
            {
                WriteIndented = true
            };

            JsonSerializer.Serialize(jsonFileWriter, users, options);
        }


        public List<User> GetAll()
        {
            if (!File.Exists(JsonFileName))
                return new List<User>();

            using StreamReader jsonFileReader = File.OpenText(JsonFileName);

            var options = new JsonSerializerOptions
            {
                Converters = { new System.Text.Json.Serialization.JsonStringEnumConverter() }
            };

            return JsonSerializer.Deserialize<List<User>>(
                jsonFileReader.ReadToEnd(),
                options
            ) ?? new List<User>();
        }
    }
}

