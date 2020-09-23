using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Airline.DAL.Airline_Db_Context;
using Airline.DAL.Models;
using Airline_Yurchenko.ViewModels;
using Airline.DAL.IRepository;
using Airline_Yurchenko.SortExtentions;

namespace Airline_Yurchenko.Controllers.Personal
{
    public class NavigatorsController : Controller
    {
        private readonly AirlineContext _context;
        private readonly IRepositoryWrapper _repositoryWrapper;
        
        public NavigatorsController(AirlineContext context, IRepositoryWrapper repositoryWrapper)
        {
            _context = context;
            _repositoryWrapper = repositoryWrapper;
        }
       
        // GET: Navigators
        public async Task<IActionResult> Index(string sort)
        {
            var users = _repositoryWrapper.NavigatorRepository.GetAllNavigator();
            sort ??= "Name";

            users = (IQueryable<Navigator>) users.SortDynamic(sort);

            return View(await users.ToListAsync());
            //return View(users.OrderByViaExpressions(sort).ToList());
        }

        // GET: Navigators/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var navigator = await _context.Navigators
                .Include(n => n.Team_Person)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (navigator == null)
            {
                return NotFound();
            }

            return View(navigator);
        }

        // GET: Navigators/Create
        public IActionResult Create()
        {
            ViewData["Team_PersonId"] = new SelectList(_context.Team_Persons, "Id", "Name_Team");
            return View();
        }

        // POST: Navigators/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Surname,Age,Experience,Salary,Team_PersonId,Id")] Navigator navigator)
        {
            if (ModelState.IsValid)
            {
                _context.Add(navigator);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Team_PersonId"] = new SelectList(_context.Team_Persons, "Id", "Name_Team", navigator.Team_PersonId);
            return View(navigator);
        }

        // GET: Navigators/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var navigator = await _context.Navigators.FindAsync(id);
            if (navigator == null)
            {
                return NotFound();
            }
            ViewData["Team_PersonId"] = new SelectList(_context.Team_Persons, "Id", "Name_Team", navigator.Team_PersonId);
            return View(navigator);
        }

        // POST: Navigators/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Name,Surname,Age,Experience,Salary,Team_PersonId,Id")] Navigator navigator)
        {
            if (id != navigator.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(navigator);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NavigatorExists(navigator.Id))
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
            ViewData["Team_PersonId"] = new SelectList(_context.Team_Persons, "Id", "Name_Team", navigator.Team_PersonId);
            return View(navigator);
        }

        // GET: Navigators/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var navigator = await _context.Navigators
                .Include(n => n.Team_Person)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (navigator == null)
            {
                return NotFound();
            }

            return View(navigator);
        }

        // POST: Navigators/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var navigator = await _context.Navigators.FindAsync(id);
            _context.Navigators.Remove(navigator);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NavigatorExists(int id)
        {
            return _context.Navigators.Any(e => e.Id == id);
        }
    }
}
