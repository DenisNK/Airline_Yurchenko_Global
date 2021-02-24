using Airline.BLL.Repository.EntityRepository;
using Airline.DAL.IRepository;
using Airline.DAL.IRepository.IEntityRepository;
using Microsoft.EntityFrameworkCore;

namespace Airline.BLL.Repository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private readonly DbContext _context;
        private IUserRepository _userRepository;
        private IPilotRepository _pilotRepository;
        private INavigatorRepository _navigatorRepository;
        private ITeamPersonRepository _teamPersonRepository;
        private IFligthRepository _fligthRepository;
        private IRequsetRepository _requsetRepository;
        private IStewardessesRepository _stewardessesRepository;
        private ICitiesRepository _citiesRepository;
        

        public RepositoryWrapper(DbContext repoContext)
        {
            _context = repoContext;
        }

        public IUserRepository UserRepo
        {
            get
            {
                if (_userRepository == null)
                {
                    _userRepository = new UserRepository(_context);
                }

                return _userRepository;
            }
        }
        public IPilotRepository PilotRepository
        {
            get { return _pilotRepository ??= new PilotRepository(_context); }
        }

        public INavigatorRepository NavigatorRepository => _navigatorRepository ??= new NavigatorRepository(_context);

        public ITeamPersonRepository TeamPersonRepository => _teamPersonRepository ??= new TeamPersonRepository(_context);

        public IFligthRepository FligthRepository => _fligthRepository ??= new FligthRepository(_context);

        public IRequsetRepository RequsetRepository => _requsetRepository ??= new RequsetRepository(_context);

        public IStewardessesRepository StewardessesRepository => _stewardessesRepository ??= new StewardessesRepository(_context);

        public ICitiesRepository CitiesRepository => _citiesRepository ??= new CitiesRepository(_context);

        public void Save()
        {
            _context.SaveChanges();
        }

    }
}
