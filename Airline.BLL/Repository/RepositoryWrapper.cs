using Airline.BLL.Repository.EntityRepository;
using Airline.DAL.IRepository;
using Airline.DAL.IRepository.IEntityRepository;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Airline.BLL.Repository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private readonly DbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        private IStudentRepository _studentRepository;
        private IDisciplinesRepository _disciplinesRepository;
        private IStudDiscRepository _studDiscRepository;
        private ITeacherRepository _teacherRepository;
        private IPilotRepository _pilotRepository;
        private INavigatorRepository _navigatorRepository;
        private ITeamPersonRepository _teamPersonRepository;
        private IFligthRepository _fligthRepository;
        private IRequsetRepository _requsetRepository;
        private IStewardessesRepository _stewardessesRepository;
        private ICitiesRepository _citiesRepository;
        

        public RepositoryWrapper(DbContext repoContext, UserManager<IdentityUser> userManager)
        {
            _context = repoContext;
            _userManager = userManager;
        }

        public IStudentRepository StudentRepo
        {
            get
            {
                if (_studentRepository == null)
                {
                    _studentRepository = new StudentRepository(_context);
                }

                return _studentRepository;
            }
        }
        public IPilotRepository PilotRepository
        {
            get { return _pilotRepository ??= new PilotRepository(_context); }
        }


        public IStudDiscRepository StudDiscRepo => _studDiscRepository ??= new StudDiscRepository(_context);

        public IDisciplinesRepository DisciplinesRepo => _disciplinesRepository ??= new DisciplinesRepository(_context);

        public ITeacherRepository TeacherRepository => _teacherRepository ??= new TeacherRepository(_context);

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
