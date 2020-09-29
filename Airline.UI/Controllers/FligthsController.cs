using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Airline.DAL.Airline_Db_Context;
using Airline.DAL.IRepository;
using Airline.DAL.Models;
using Airline_Yurchenko.Areas.AccountFilters;
using Airline_Yurchenko.SortExtentions;
using Airline_Yurchenko.ViewModels;
using Microsoft.AspNetCore.Authorization;

namespace Airline_Yurchenko.Controllers
{
    public class FligthsController : Controller
    {
        private readonly ILoggerManager _logger;
        private readonly IRepositoryWrapper _repositoryWrapper;
        
        public FligthsController(IRepositoryWrapper repositoryWrapper, ILoggerManager logger)
        {
            _repositoryWrapper = repositoryWrapper;
            _logger = logger;
        }
        [HttpGet]
        public IActionResult GetProblem()
        {
            var source = _repositoryWrapper.RequsetRepository.Get().ToList();
            var airlineContext = _repositoryWrapper.RequsetRepository.Get()
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
        public async Task<IActionResult> Index(string sort)
        {
            sort ??= "Name_Fligth";
            if (IsUser())       //get all flight for all users
                return View(await _repositoryWrapper.FligthRepository.GetFligthAllUsers().SortDynamic(sort).ToDynamicListAsync<Fligth>());
            return User.IsInRole("admin")                     //get flight for users with role
                ? View(await _repositoryWrapper.FligthRepository.GetFligthAdmin().SortDynamic(sort)
                    .ToDynamicListAsync<Fligth>())      
                : View(await _repositoryWrapper.FligthRepository.GetFligthAdminDisp(User.Identity.Name)
                    .SortDynamic(sort).ToDynamicListAsync<Fligth>());
        }
        
        // GET: Fligths/Details/5

        [AllowAnonymous]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fligth = await _repositoryWrapper.FligthRepository.GetFligthByIdAsync(id);
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
            ViewData["FromCityId"] = _repositoryWrapper.CitiesRepository.SelectListCity();
            ViewData["WhereCityId"] = _repositoryWrapper.CitiesRepository.SelectListCity();
            return View();
        }

        // POST: Fligths/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Fligth fligth)
        {
            if (ModelState.IsValid)
            {
                if (fligth.Request.Message != "")
                    fligth.Request = new Request { Message = fligth.Request.Message, SignIn = User.Identity.Name };
                await _repositoryWrapper.FligthRepository.Create(fligth);
                return RedirectToAction(nameof(Index));
            }

            ViewData["FromCityId"] = _repositoryWrapper.CitiesRepository.SelectListCity(fligth.FromCityId);
            ViewData["WhereCityId"] = _repositoryWrapper.CitiesRepository.SelectListCity(fligth.WhereCityId);

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

            var fligth = await _repositoryWrapper.FligthRepository.GetById(id);
            if (fligth == null)
            {
                return NotFound();
            }
            ViewData["FromCityId"] = _repositoryWrapper.CitiesRepository.SelectListCity(id);
            ViewData["WhereCityId"] = _repositoryWrapper.CitiesRepository.SelectListCity(id);
            return View(fligth);
        }

        // POST: Fligths/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Name_Fligth,FromCityId,WhereCityId,DepartureDate,ArrivalDate,IsConfirmed,Price,Id")] Fligth fligth)
        {
            if (id != fligth.Id)
            {
                _logger.LogError($"Fligth with id: {id}, hasn't been found in db.");
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                _logger.LogError("Invalid owner object sent from client.");
                return View(fligth);
            }
            await _repositoryWrapper.FligthRepository.Update(id, fligth);
            var request = await _repositoryWrapper.RequsetRepository.GetRequestByIdAsync(id);
            if (request != null)
                await _repositoryWrapper.RequsetRepository.RemoveRequest(request);

            ViewData["FromCityId"] = _repositoryWrapper.CitiesRepository.SelectListCity(fligth.FromCityId);
            ViewData["WhereCityId"] = _repositoryWrapper.CitiesRepository.SelectListCity(fligth.FromCityId);
            return RedirectToAction(nameof(Index));
        }

        [ForAdmin]
        // GET: Fligths/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fligth = await _repositoryWrapper.FligthRepository.GetFligthByIdAsync(id);
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
            await _repositoryWrapper.FligthRepository.Delete(id);
            return RedirectToAction(nameof(Index));
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
