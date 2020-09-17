using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Airline_Yurchenko.ViewModels
{
    public class GroupedRequestViewModel
    {
        public IReadOnlyList<RequestViewModel> Items { get; set; }
        public decimal Total { get; set; }
    }
}
