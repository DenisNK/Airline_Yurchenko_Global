using System.Collections.Generic;
using static System.IO.File;
using static System.Text.Json.JsonSerializer;

namespace Airline.BLL.Services
{
    public class GroupService : IGroupService
    {
        private readonly string GroupFile = "genders.json";
        public IEnumerable<string> GetGroups()
        {
            var jsonString = ReadAllText(GroupFile);
            var resultDeserialize = Deserialize<IDictionary<string, IEnumerable<string>>>(jsonString);
            return resultDeserialize["name_gender"];
        }
    }
}