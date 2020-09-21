using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Airline.DAL.Airline_Db_Context;
using Airline.DAL.IRepository;
using Airline.DAL.Models;
using Airline_Yurchenko.Areas.AccountFilters;
using Airline_Yurchenko.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace Airline_Yurchenko.Controllers
{
    public class FligthsController : Controller
    {
        private readonly ILoggerManager _logger;
        private readonly AirlineContext _context;
        private readonly IRepositoryWrapper _repositoryWrapper;
        
        public FligthsController(AirlineContext context, IRepositoryWrapper repositoryWrapper, ILoggerManager logger)
        {
            _context = context;
            _repositoryWrapper = repositoryWrapper;
            _logger = logger;
        }
        [HttpGet]
        public IActionResult GetProblem()
        {
            var source = _repositoryWrapper.RequsetRepository.Get().ToList();

            var airlineContext = _context.Requests
                .GroupBy(u => u.SignIn, (key, items) => new RequestViewModel
                {
                    Sig = key,
                    Cost = items.Count(),
                })
                .ToList();

            var model = new GroupedRequestViewModel
            {
                Items = airlineContext,
                Total = source.Count
            };
            _logger.LogInfo($"Returned all requests from admin.");
            return View(model);
        }

        public async Task<IActionResult> GetListProblem(string id)
        {
            var source = _repositoryWrapper.RequsetRepository.GetListProblem(id);
            return View(await source.ToListAsync());
        }
        // GET: Fligths

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            if (IsUser())
                return View(await _repositoryWrapper.FligthRepository.GetFligthAllUsers().ToListAsync());
            return User.IsInRole("admin")
                ? View(await _repositoryWrapper.FligthRepository.GetFligthAdmin()
                    .ToListAsync())
                : View(await _repositoryWrapper.FligthRepository.GetFligthAdminDisp(User.Identity.Name)
                    .ToListAsync());
        }

        // GET: Fligths/Details/5

        [AllowAnonymous]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fligth = await _context.Fligths
                .Include(f => f.FromCity)
                .Include(f => f.WhereCity).Include(req => req.Request)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (fligth == null)
            {
                return NotFound();
            }

            return View(fligth);
        }

        [ForAdminDispatcher]
        // GET: Fligths/Create
        public IActionResult Create()
        {
            ViewData["FromCityId"] = new SelectList(_context.Cities, "Id", "Name_City");
            ViewData["WhereCityId"] = new SelectList(_context.Cities, "Id", "Name_City");
            return View();
        }

        // POST: Fligths/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Fligth fligth, int id)
        {
            if (User.IsInRole("dispatcher"))
            {

            }

            if (ModelState.IsValid)
            {
                if (fligth.Request.Message != "")
                    fligth.Request = new Request { Message = fligth.Request.Message, SignIn = User.Identity.Name };
                _context.Add(fligth);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FromCityId"] = new SelectList(_context.Cities, "Id", "AirportCode", fligth.FromCityId);
            ViewData["WhereCityId"] = new SelectList(_context.Cities, "Id", "AirportCode", fligth.WhereCityId);

            return View(fligth);
        }

        [ForAdmin]
        // GET: Fligths/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fligth = await _context.Fligths.FindAsync(id);
            if (fligth == null)
            {
                return NotFound();
            }
            ViewData["FromCityId"] = new SelectList(_context.Cities, "Id", "AirportCode", fligth.FromCityId);
            ViewData["WhereCityId"] = new SelectList(_context.Cities, "Id", "AirportCode", fligth.WhereCityId);
            return View(fligth);
        }

        // POST: Fligths/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Name_Fligth,FromCityId,WhereCityId,DepartureDate,ArrivalDate,IsConfirmed,Price,Id")] Fligth fligth)
        {
            if (id != fligth.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(fligth);
                    var request = await _context.Requests.FindAsync(id);
                     if(request !=null)
                        _context.Requests.Remove(request);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FligthExists(fligth.Id))
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
            ViewData["FromCityId"] = new SelectList(_context.Cities, "Id", "AirportCode", fligth.FromCityId);
            ViewData["WhereCityId"] = new SelectList(_context.Cities, "Id", "AirportCode", fligth.WhereCityId);
            return View(fligth);
        }
        [ForAdmin]
        // GET: Fligths/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fligth = await _context.Fligths
                .Include(f => f.FromCity)
                .Include(f => f.WhereCity)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (fligth == null)
            {
                return NotFound();
            }

            return View(fligth);
        }

        // POST: Fligths/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var fligth = await _context.Fligths.FindAsync(id);
            _context.Fligths.Remove(fligth);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FligthExists(int id)
        {
            return _context.Fligths.Any(e => e.Id == id);
        }
        /// <summary>
        /// Represents is it user or not
        /// </summary>
        /// <returns></returns>
        private bool IsUser()
        {
            return !(User.IsInRole("admin") || User.IsInRole("dispatcher"));
        }
    }
}
