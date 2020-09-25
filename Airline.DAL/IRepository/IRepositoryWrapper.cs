using Airline.DAL.IRepository.IEntityRepository;

namespace Airline.DAL.IRepository
{
    public interface IRepositoryWrapper

    {
        IUserRepository UserRepo { get; }
        IPilotRepository PilotRepository{ get; }
        INavigatorRepository NavigatorRepository{ get; }
        ITeamPersonRepository TeamPersonRepository { get; }
        IFligthRepository FligthRepository{ get; }
        IRequsetRepository RequsetRepository { get; }
        IStewardessesRepository StewardessesRepository{ get; }
        ICitiesRepository CitiesRepository{ get; }
        void Save();

    }
}
