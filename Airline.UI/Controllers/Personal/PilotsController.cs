using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Airline.DAL.IRepository;
using Airline.DAL.Models;
using Airline_Yurchenko.Helpers.Pagination;

namespace Airline_Yurchenko.Controllers.Personal
{

    public class PilotsController : Controller

    {
        private readonly ILoggerManager _logger;
        private readonly IRepositoryWrapper _repositoryWrapper;
        public PilotsController(IRepositoryWrapper repositoryWrapper, ILoggerManager logger)
        {
            _repositoryWrapper = repositoryWrapper;
            _logger = logger;
        }

        public async Task<IActionResult> Index(int? company, string name, SortState sortOrder = SortState.NameAsc, int page = 1)
        {
            const int pageSize = 3;

            //фильтрация
            var users = _repositoryWrapper.PilotRepository.GetAllPilot();
            //IQueryable<User> users = db.Users.Include(x => x.Company);

            if (company != null && company != 0)
            {
                users = users.Where(p => p.Team_PersonId == company);
            }
            if (!String.IsNullOrEmpty(name))
            {
                users = users.Where(p => p.Name.Contains(name));
            }

            // сортировка
            users = Queryable(sortOrder, users);
           
            // пагинация
            var count = users.Count();
            var items = users.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            // формируем модель представления
            IndexViewModel viewModel = new IndexViewModel
            {
                PageViewModel = new PageViewModel(count, page, pageSize),
                SortViewModel = new SortViewModel(sortOrder),
            FilterViewModel = new FilterViewModel(_repositoryWrapper.TeamPersonRepository.Get().ToList(), company, name),
                Users = items
            };
            return View(viewModel);
        }
     
        private static IQueryable<Pilot> Queryable(SortState sortOrder, IQueryable<Pilot> users)
        {
            users = sortOrder switch
            {
                SortState.NameDesc => users.OrderByDescending(s => s.Name),
                SortState.AgeAsc => users.OrderBy(s => s.Age),
                SortState.AgeDesc => users.OrderByDescending(s => s.Age),
                SortState.CompanyAsc => users.OrderBy(s => s.Team_Person.Name_Team), ////????
                SortState.CompanyDesc => users.OrderByDescending(s => s.Team_Person.Name_Team) ////??????
                ,
                _ => users.OrderBy(s => s.Name)
            };

            return users;
        }
        // GET: Pilots
        //public IActionResult Index()
        //{
        //    var airlineContext = _repositoryWrapper.PilotRepository.GetAllPilot();
        //    _logger.LogInfo($"Returned all owners from database.");
        //    return View(airlineContext);
        //}

        // GET: Pilots/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                _logger.LogError($"Pilot with id: {id}, hasn't been found in db.");
                return NotFound();
            }
            _logger.LogInfo($"Returned owner with id: {id}");
            var pilot = await _repositoryWrapper.PilotRepository.GetPilotcByIdWithTeamAsync(id);
            if (pilot == null)
            {
                _logger.LogError($"Pilot not found");
                return NotFound();
            }

            return View(pilot);
        }

        // GET: Pilots/Create
        public IActionResult Create()
        {
            ViewData["Team_PersonId"] = _repositoryWrapper.TeamPersonRepository.SelectListTeamName();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Pilot pilot)
        {
            if (!ModelState.IsValid)
            {
                ViewData["Team_PersonId"] = _repositoryWrapper.TeamPersonRepository.SelectListTeamName(pilot.Team_PersonId);
                return View(pilot);
            }

            _logger.LogInfo($"Pilot has been created into database.");
            await _repositoryWrapper.PilotRepository.CreateWithImage(pilot);
            return RedirectToAction(nameof(Index));
        }

        // GET: Pilots/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {

            if (id == null)
            {
                _logger.LogError("Pilot object sent from client is null.");
                return NotFound();
            }

            var pilot = await _repositoryWrapper.PilotRepository.GetById(id);
            if (pilot == null)
            {
                _logger.LogError($"Pilot with id: {id}, hasn't been found in db.");
                return NotFound();
            }

            ViewData["Team_PersonId"] = _repositoryWrapper.TeamPersonRepository.SelectListTeamName(id);
            return View(pilot);
        }

        // POST: Pilots/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Pilot pilot)
        {
            if (id != pilot.Id)
            {
                _logger.LogError($"Pilot with id: {id}, hasn't been found in db.");
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                _logger.LogError("Invalid owner object sent from client.");
                return View(pilot);
            }
            else
            {
                ViewData["Team_PersonId"] = _repositoryWrapper.TeamPersonRepository.SelectListTeamName(pilot.Team_PersonId);
                await _repositoryWrapper.PilotRepository.GetByIdWithImage(id, pilot);
                return RedirectToAction(nameof(Index));
            }

        }

        // GET: Pilots/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                _logger.LogError($"Pilot with id: {id}, hasn't been found in db.");
                return NotFound();
            }

            var pilot = await _repositoryWrapper.PilotRepository
                .GetPilotcByIdWithTeamAsync(id); // await _context.Pilots

            if (pilot == null)
            {
                _logger.LogError($"Pilot with id: {id}, hasn't been found in db.");
                return NotFound();
            }
            _logger.LogWarn($"Pilot with id: {id}, has been choose for delete.");
            return View(pilot);
        }

        // POST: Pilots/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            _logger.LogInfo($"Pilot has been deleted from database.");
            await _repositoryWrapper.PilotRepository.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}