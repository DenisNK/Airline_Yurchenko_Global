using System.Collections.Generic;
using Airline.DAL.IRepository;

namespace Airline.DAL.Models
{
    public class Team_Person : BaseId, IEntity
    {
        public string Name_Team { get; set; }

        public virtual ICollection<Navigator> Navigators { get; set; }
        public virtual ICollection<Pilot> Pilots { get; set; }
        public virtual ICollection<Radio_operator> Radio_Operators { get; set; }
        public virtual ICollection<Stewardess> Stewardesses { get; set; }

        public virtual ICollection<FligthTeam> FligthTeams { get; set; }
        public Team_Person()
        {
            Navigators = new List<Navigator>();
            Pilots = new List<Pilot>();
            Radio_Operators = new List<Radio_operator>();
            Stewardesses = new List<Stewardess>();
            FligthTeams = new List<FligthTeam>();
        }
    }
}
