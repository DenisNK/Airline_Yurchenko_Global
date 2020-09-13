using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Airline.DAL.IRepository;
using Airline.DAL.Models;

namespace Airline_Yurchenko.Controllers.Personal
{
    
    public class PilotsController : Controller
    {
        private readonly IRepositoryWrapper _repositoryWrapper;
        public PilotsController(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        // GET: Pilots
        public IActionResult Index()
        {
            var airlineContext = _repositoryWrapper.PilotRepository.GetAllPilot();
            return View(airlineContext);
        }

        // GET: Pilots/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pilot = await _repositoryWrapper.PilotRepository.GetPilotcByIdWithTeamAsync(id);
            if (pilot == null)
            {
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
            if (ModelState.IsValid)
            {
                await _repositoryWrapper.PilotRepository.CreateWithImage(pilot);
                return RedirectToAction(nameof(Index));
            }

            ViewData["Team_PersonId"] = _repositoryWrapper.TeamPersonRepository.SelectListTeamName(pilot.Team_PersonId);
            return View(pilot);
        }
        
        // GET: Pilots/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            
            if (id == null)
            {
                return NotFound();
            }

            var pilot = await _repositoryWrapper.PilotRepository.GetById(id);
            if (pilot == null)
            {
                return NotFound();
            }

            ViewData["Team_PersonId"] = _repositoryWrapper.TeamPersonRepository.SelectListTeamName(id);
            return View(pilot);
        }

        // POST: Pilots/Edit/5
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,  Pilot pilot)
        {
            if (id != pilot.Id)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return View(pilot);
            }
            else
            {
                ViewData["Team_PersonId"] =
                    _repositoryWrapper.TeamPersonRepository.SelectListTeamName(pilot.Team_PersonId);
                await _repositoryWrapper.PilotRepository.GetByIdWithImage(id, pilot);
                return RedirectToAction(nameof(Index));
            }

        }

        // GET: Pilots/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pilot = await _repositoryWrapper.PilotRepository
                .GetPilotcByIdWithTeamAsync(id); // await _context.Pilots

            if (pilot == null)
            {
                return NotFound();
            }

            return View(pilot);
        }

        // POST: Pilots/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _repositoryWrapper.PilotRepository.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}