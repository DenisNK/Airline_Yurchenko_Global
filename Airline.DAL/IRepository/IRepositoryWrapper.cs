using System;
using System.Collections.Generic;
using System.Text;
using Airline.DAL.IRepository.IEntityRepository;

namespace Airline.DAL.IRepository
{
    public interface IRepositoryWrapper

    {
        IDisciplinesRepository DisciplinesRepo { get; }
        IStudentRepository StudentRepo { get; }
        IStudDiscRepository StudDiscRepo { get; }
        ITeacherRepository TeacherRepository { get; }
        IPilotRepository PilotRepository{ get; }
        INavigatorRepository NavigatorRepository{ get; }
        ITeamPersonRepository TeamPersonRepository { get; }
        void Save();

    }
}
