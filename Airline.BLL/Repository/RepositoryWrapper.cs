using Airline.BLL.Repository.EntityRepository;
using Airline.DAL.IRepository;
using Airline.DAL.IRepository.IEntityRepository;
using Microsoft.EntityFrameworkCore;

namespace Airline.BLL.Repository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private readonly DbContext _context;
        private IStudentRepository _studentRepository;
        private IDisciplinesRepository _disciplinesRepository;
        private IStudDiscRepository _studDiscRepository;
        private ITeacherRepository _teacherRepository;
        private IPilotRepository _pilotRepository;
        private INavigatorRepository _navigatorRepository;
        private ITeamPersonRepository _teamPersonRepository;

        public RepositoryWrapper(DbContext repoContext)
        {
            _context = repoContext;
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

        public void Save()
        {
            _context.SaveChanges();
        }

    }
}
