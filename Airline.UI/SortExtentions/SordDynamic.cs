using System.Linq;
using System.Linq.Dynamic.Core;

namespace Airline_Yurchenko.SortExtentions
{
    public static class SordDynamic
    {
        public static IQueryable SortDynamic(this IQueryable collection, string sortBy, bool reverse = false)
        {
            return collection.OrderBy(sortBy + (reverse ? " descending" : ""));
        }
    }
}
