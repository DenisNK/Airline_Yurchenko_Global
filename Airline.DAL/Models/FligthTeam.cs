namespace Airline.DAL.Models
{
    public class FligthTeam
    {
        public int FligthId { get; set; }
        public Fligth Fligth { get; set; }
        public int Team_PersonId { get; set; }
        public Team_Person Team_Person{ get; set; }
    }
}
