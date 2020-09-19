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
        IFligthRepository FligthRepository{ get; }
        IRequsetRepository RequsetRepository { get; }
        void Save();

    }
}
