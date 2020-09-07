﻿using System.Collections.Generic;
using static System.IO.File;
using static System.Text.Json.JsonSerializer;

namespace Airline.BLL.Services
{
    public class GroupService : IGroupService
    {
        private readonly string GroupFile = "groups.json";
        public IEnumerable<string> GetGroups()
        {
            string jsonString = ReadAllText(GroupFile);
            var resultDeserialize = Deserialize<IDictionary<string, IEnumerable<string>>>(jsonString);
            return resultDeserialize["name_groups"];
        }
    }
}