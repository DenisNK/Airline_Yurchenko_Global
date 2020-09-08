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
        
    }
}
