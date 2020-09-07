using Airline.DAL.IRepository;
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

        public RepositoryWrapper(DbContext repoContext, ITeacherRepository teacherRepository)
        {
            _context = repoContext;
            _teacherRepository = teacherRepository;
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
