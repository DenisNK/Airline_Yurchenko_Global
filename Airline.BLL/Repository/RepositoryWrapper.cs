using Airline.BLL.Repository.EntityRepository;
using Airline.DAL.IRepository;
using Airline.DAL.IRepository.IEntityRepository;
using Microsoft.EntityFrameworkCore;

namespace Airline.BLL.Repository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private DbContext _context;
        private IStudentRepository _studentRepository;
        private IDisciplinesRepository _disciplinesRepository;
        private IStudDiscRepository _studDiscRepository;
        private ITeacherRepository _teacherRepository;
        private IPilotRepository _pilotRepository;

        public RepositoryWrapper(DbContext repoContext, ITeacherRepository teacherRepository, IPilotRepository pilotRepository)
        {
            _context = repoContext;
            _teacherRepository = teacherRepository;
            _pilotRepository = pilotRepository;
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


        public IStudDiscRepository StudDiscRepo
        {
            get
            {
                if (_studDiscRepository == null)
                {
                    _studDiscRepository = new StudDiscRepository(_context);
                }

                return _studDiscRepository;
            }
        }

        public IDisciplinesRepository DisciplinesRepo
        {
            get
            {
                if (_disciplinesRepository == null)
                {
                    _disciplinesRepository = new DisciplinesRepository(_context);
                }

                return _disciplinesRepository;
            }
        }

        public ITeacherRepository TeacherRepository
        {
            get
            {
                if (_teacherRepository == null)
                {
                    _teacherRepository = new TeacherRepository(_context);
                }

                return _teacherRepository;
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }

    }
}
