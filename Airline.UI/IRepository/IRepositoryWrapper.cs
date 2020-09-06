using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Global_Logic_ASP.Core.IRepository
{
    public interface IRepositoryWrapper

    {
        IDisciplinesRepository DisciplinesRepo { get; }
        IStudentRepository StudentRepo { get; }
        IStudDiscRepository StudDiscRepo { get; }
        ITeacherRepository TeacherRepository{ get; }
        void Save();

    }
}
