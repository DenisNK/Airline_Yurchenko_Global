using System;
using System.Collections.Generic;
using System.Text;

namespace Airline.DAL.IRepository
{
    public interface IRepositoryWrapper

    {
        //IDisciplinesRepository DisciplinesRepo { get; }
        //IStudentRepository StudentRepo { get; }
        //IStudDiscRepository StudDiscRepo { get; }
        ITeacherRepository TeacherRepository { get; }
        void Save();

    }
}
