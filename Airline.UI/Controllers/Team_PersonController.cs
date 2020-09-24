using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Airline.DAL.IRepository;
using Airline.DAL.Models;

namespace Airline_Yurchenko.Controllers
{
    public class Team_PersonController : Controller
    {
        private readonly ILoggerManager _logger;
        private readonly IRepositoryWrapper _repositoryWrapper;

        public Team_PersonController(IRepositoryWrapper repositoryWrapper, ILoggerManager logger)
        {
            _repositoryWrapper = repositoryWrapper;
            _logger = logger;
        }
        public IActionResult PersonalList()
        {
            return View();
        }

        // GET: Team_Person
        public IActionResult Index()
        {
            _logger.LogInfo($"Returned all team persons from database.");
            return View(_repositoryWrapper.TeamPersonRepository.Get());
        }
                      
        [HttpGet]
        public async Task <ActionResult> TeamDetails(int? id)
        {
            if (id == null)
            {
                _logger.LogError($"Team persons with id: {id}, hasn't been found in db.");
                return NotFound();
            }

            var teamPerson = await _repositoryWrapper.TeamPersonRepository.GetTeamByIdWithAllTeamAsync(id);

            if (teamPerson != null) return View(teamPerson);
            _logger.LogError($"Team persons not found");
            return NotFound();
        }
                                                             
        // GET: Team_Person/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                _logger.LogError($"Team persons with id: {id}, hasn't been found in db.");
                return NotFound();
            }

            var teamPerson = await _repositoryWrapper.TeamPersonRepository.GetById(id);
            if (teamPerson == null)
            {
                _logger.LogError($"Team persons not found");
                return NotFound();
            }

            return View(teamPerson);
        }

        // GET: Team_Person/Create
        public IActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name_Team,Id")] Team_Person teamPerson)
        {
            if (!ModelState.IsValid) 
                return View(teamPerson);
            _logger.LogInfo($"Team persons has been created into database.");
            await _repositoryWrapper.TeamPersonRepository.Create(teamPerson);
            return RedirectToAction(nameof(Index));
        }

        // GET: Team_Person/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                _logger.LogError($"Team persons id: {id}, hasn't been found in db.");
                return NotFound();
            }

            var teamPerson = await _repositoryWrapper.TeamPersonRepository.GetById(id);
            if (teamPerson == null)
            {
                _logger.LogError("Team persons object sent from client is null.");
                return NotFound();
            }
            return View(teamPerson);
        }

        // POST: Team_Person/Edit/5
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Name_Team,Id")] Team_Person teamPerson)
        {
            if (id != teamPerson.Id)
            {
                _logger.LogError("Team persons object sent from client is null.");
                return NotFound();
            }

            if (!ModelState.IsValid) 
                return View(teamPerson);
            _logger.LogInfo("Team persons has been updated.");
            await _repositoryWrapper.TeamPersonRepository.Update(id, teamPerson);
            return RedirectToAction(nameof(Index));
        }

        // GET: Team_Person/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                _logger.LogError($"Team persons with id: {id}, hasn't been found in db.");
                return NotFound();
            }
            _logger.LogWarn($"Team persons with id: {id}, has been choose for delete.");
            var teamPerson = await _repositoryWrapper.TeamPersonRepository.GetById(id);
            if (teamPerson == null)
            {
                _logger.LogError("Invalid owner object sent from client.");
                return NotFound();
            }

            return View(teamPerson);
        }

        // POST: Team_Person/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _repositoryWrapper.TeamPersonRepository.Delete(id);
            
            return RedirectToAction(nameof(Index));
        }
        
    }
}
