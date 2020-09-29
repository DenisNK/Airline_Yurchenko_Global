using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Airline.DAL.IRepository;
using Airline.DAL.Models;
using Airline_Yurchenko.Areas.AccountFilters;
using Airline_Yurchenko.SortExtentions;
using Airline_Yurchenko.ViewModels;

namespace Airline_Yurchenko.Controllers.Personal
{
    [ForAdmin]
    public class StewardessesController : Controller
    {
        private readonly ILoggerManager _logger;
        private readonly IRepositoryWrapper _repositoryWrapper;

        public StewardessesController(IRepositoryWrapper repositoryWrapper, ILoggerManager logger)
        {
            _repositoryWrapper = repositoryWrapper;
            _logger = logger;
        }

        // GET: Stewardesses
        public IActionResult Index(string sort)
        {
            var airlineContext = _repositoryWrapper.StewardessesRepository.GetAllStewardess();
            sort ??= "Name"; 
            _logger.LogInfo($"Returned all owners from database.");
            return View(airlineContext.OrderByViaExpressions(sort));
        }

        // GET: Stewardesses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                _logger.LogError($"Pilot with id: {id}, hasn't been found in db.");
                return NotFound();
            }

            var stewardess = await _repositoryWrapper.StewardessesRepository.GetStewardessByIdWithTeamAsync(id);
            _logger.LogInfo($"Returned owner with id: {id}");
            if (stewardess != null) return View(stewardess);
            _logger.LogError($"Pilot not found");
            return NotFound();

        }

        // GET: Stewardesses/Create
        public IActionResult Create()
        {
            ViewData["Team_PersonId"] = _repositoryWrapper.TeamPersonRepository.SelectListTeamName();
            return View();
        }

        // POST: Stewardesses/Create
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Surname,Age,Experience,Salary,Team_PersonId,Id,ProfilePicture,ProfileImage")] Stewardess stewardess)
        {
            if (ModelState.IsValid)
            {
                _logger.LogInfo($"Pilot has been created into database.");
                await _repositoryWrapper.StewardessesRepository.CreateWithImage(stewardess);
                return RedirectToAction(nameof(Index));
            }
            ViewData["Team_PersonId"] = _repositoryWrapper.TeamPersonRepository.SelectListTeamName(stewardess.Team_PersonId);
            return View(stewardess);
        }

        // GET: Stewardesses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                _logger.LogError("Pilot object sent from client is null.");
                return NotFound();
            }

            var stewardess = await _repositoryWrapper.StewardessesRepository.GetById(id);
            if (stewardess == null)
            {
                _logger.LogError($"Pilot with id: {id}, hasn't been found in db.");
                return NotFound();
            }
            ViewData["Team_PersonId"] = _repositoryWrapper.TeamPersonRepository.SelectListTeamName(id);
            return View(stewardess);
        }

        // POST: Stewardesses/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Name,Surname,Age,Experience,Salary,Team_PersonId,ProfilePicture,ProfileImage,Id")] Stewardess stewardess)
        {
            if (id != stewardess.Id)
            {
                _logger.LogError($"Pilot with id: {id}, hasn't been found in db.");
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                _logger.LogError("Invalid owner object sent from client.");
                return View(stewardess);
            }
            else
            {
                ViewData["Team_PersonId"] = _repositoryWrapper.TeamPersonRepository.SelectListTeamName(stewardess.Team_PersonId);
                await _repositoryWrapper.StewardessesRepository.GetByIdWithImage(id, stewardess);
                return RedirectToAction(nameof(Index));
            }
        }

        // GET: Stewardesses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                _logger.LogError($"Pilot with id: {id}, hasn't been found in db.");
                return NotFound();
            }

            var stewardess = await _repositoryWrapper.StewardessesRepository.GetStewardessByIdWithTeamAsync(id);
            if (stewardess == null)
            {
                _logger.LogError($"Pilot with id: {id}, hasn't been found in db.");
                return NotFound();
            }
            _logger.LogWarn($"Pilot with id: {id}, has been choose for delete.");
            return View(stewardess);
        }

        // POST: Stewardesses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            _logger.LogInfo($"Pilot has been deleted from database.");
            await _repositoryWrapper.StewardessesRepository.Delete(id);
            return RedirectToAction(nameof(Index));
        }

    }
}
