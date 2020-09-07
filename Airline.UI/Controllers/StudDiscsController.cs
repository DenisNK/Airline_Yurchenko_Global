using System.Linq;
using System.Threading.Tasks;
using Airline.DAL.Airline_Db_Context;
using Airline.DAL.IRepository;
using Airline.DAL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Airline_Yurchenko.Controllers
{
    public class StudDiscsController : Controller
    {
        private readonly AirlineContext _context;
        private readonly IRepositoryWrapper _repositoryWrapper;


        public StudDiscsController(AirlineContext context, IRepositoryWrapper repositoryWrapper)
        {
            _context = context;
            _repositoryWrapper = repositoryWrapper;
        }

        // GET: StudDiscs
        public async Task<IActionResult> Index()
        {
            var choiceContext = _repositoryWrapper.StudDiscRepo.GetAllStudDisc();
            return View(await choiceContext.ToListAsync());
        }

        // GET: StudDiscs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studDisc = await _context.StudDiscs
                .Include(s => s.Discipline)
                .Include(s => s.Student)
                .FirstOrDefaultAsync(m => m.DisciplineId == id);

            if (studDisc == null)
            {
                return NotFound();
            }

            return View(studDisc);
        }

        // GET: StudDiscs/Create
        public IActionResult Create()
        {
            ViewData["DisciplineId"] = new SelectList(_context.Disciplines, "Id", "Title");
            ViewData["StudentId"] = new SelectList(_context.Students, "Id", "Name");
            return View();
        }

        // POST: StudDiscs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StudentId,DisciplineId")] StudDisc studDisc)
        {
            if (ModelState.IsValid)
            {
                _context.Add(studDisc);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DisciplineId"] = new SelectList(_context.Disciplines, "Id", "Id", studDisc.DisciplineId);
            ViewData["StudentId"] = new SelectList(_context.Students, "Id", "Group", studDisc.StudentId);
            return View(studDisc);
        }

        // GET: StudDiscs/Edit/5
        public async Task<IActionResult> Edit(int? id, int id2)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studDisc = await _context.StudDiscs.FindAsync(id, id2);
            if (studDisc == null)
            {
                return NotFound();
            }
            ViewData["DisciplineId"] = new SelectList(_context.Disciplines, "Id", "Id", studDisc.DisciplineId);
            ViewData["StudentId"] = new SelectList(_context.Students, "Id", "Group", studDisc.StudentId);
            return View(studDisc);
        }

        // POST: StudDiscs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("StudentId,DisciplineId")] StudDisc studDisc)
        {
            if (id != studDisc.DisciplineId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(studDisc);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudDiscExists(studDisc.DisciplineId))
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
            ViewData["DisciplineId"] = new SelectList(_context.Disciplines, "Id", "Id", studDisc.DisciplineId);
            ViewData["StudentId"] = new SelectList(_context.Students, "Id", "Group", studDisc.StudentId);
            return View(studDisc);
        }

        // GET: StudDiscs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studDisc = await _context.StudDiscs
                .Include(s => s.Discipline)
                .Include(s => s.Student)
                .FirstOrDefaultAsync(m => m.DisciplineId == id);
            if (studDisc == null)
            {
                return NotFound();
            }

            return View(studDisc);
        }

        // POST: StudDiscs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var studDisc = await _context.StudDiscs.FindAsync(id);
            _context.StudDiscs.Remove(studDisc);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StudDiscExists(int id)
        {
            return _context.StudDiscs.Any(e => e.DisciplineId == id);
        }
    }
}
