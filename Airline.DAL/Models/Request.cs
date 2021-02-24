using Airline.DAL.IRepository;

namespace Airline.DAL.Models
{
   public  class Request : BaseId, IEntity
    {
        public Fligth Fligth{ get; set; }
        public string Message{ get; set; }
        public int RequestRef { get; set; }
        public string SignIn { get; set; }
    }
}
