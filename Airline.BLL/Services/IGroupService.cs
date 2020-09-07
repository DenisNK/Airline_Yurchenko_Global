using System.Collections.Generic;

namespace Airline.BLL.Services
{
    public interface IGroupService
    {
     IEnumerable<string> GetGroups();
    }
}
