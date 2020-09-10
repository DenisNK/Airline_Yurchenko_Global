using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Airline.DAL.Airline_Db_Context;
using Airline.DAL.IRepository;
using Airline.DAL.Models;

namespace Airline_Yurchenko.Controllers.Personal
{
    public class PilotsController : Controller
    {
        private readonly AirlineContext _context;
        private readonly IRepositoryWrapper _repositoryWrapper;

        public PilotsController(AirlineContext context, IRepositoryWrapper repositoryWrapper)
        {
            _context = context;
            _repositoryWrapper = repositoryWrapper;
        }

        // GET: Pilots
        public IActionResult Index()
        {
            var airlineContext =_repositoryWrapper.PilotRepository.GetWithInclude(t=>t.Team_Person);
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
            //ViewData["Team_PersonId"] = _repositoryWrapper.PilotRepository. new SelectList(_context.Team_Persons, "Id", "Name_Team");
            return View();
        }

        // POST: Pilots/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Surname,Age,Experience,Salary,Team_PersonId,Id")] Pilot pilot)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pilot);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Team_PersonId"] = new SelectList(_context.Team_Persons, "Id", "Name_Team", pilot.Team_PersonId);
            return View(pilot);
        }

        // GET: Pilots/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pilot = await _context.Pilots.FindAsync(id);
            if (pilot == null)
            {
                return NotFound();
            }
            ViewData["Team_PersonId"] = new SelectList(_context.Team_Persons, "Id", "Name_Team", pilot.Team_PersonId);
            return View(pilot);
        }

        // POST: Pilots/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Name,Surname,Age,Experience,Salary,Team_PersonId,Id")] Pilot pilot)
        {
            if (id != pilot.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pilot);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PilotExists(pilot.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["Team_PersonId"] = new SelectList(_context.Team_Persons, "Id", "Name_Team", pilot.Team_PersonId);
            return View(pilot);
        }

        // GET: Pilots/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pilot = await _context.Pilots
                .Include(p => p.Team_Person)
                .FirstOrDefaultAsync(m => m.Id == id);
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
            var pilot = await _context.Pilots.FindAsync(id);
            _context.Pilots.Remove(pilot);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PilotExists(int id)
        {
            return _context.Pilots.Any(e => e.Id == id);
        }
    }
}
