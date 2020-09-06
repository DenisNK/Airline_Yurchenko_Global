using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Global_Logic_ASP.Core.Models;
using Global_Logic_ASP.Core.IRepository;

namespace Global_Logic_ASP.Core.Controllers
{
    public class DisciplinesController : Controller
    {
        private readonly IRepositoryWrapper _repositoryWrapper;

        public DisciplinesController(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        // GET: disciplines
        public IActionResult Index()
        {
           var query = _repositoryWrapper.DisciplinesRepo.GetWithInclude(p => p.Teacher);
            
           return View(query);
        }

        // GET: disciplines/Create
        public IActionResult Create()
        {
            ViewData["TeacherId"] = _repositoryWrapper.TeacherRepository.SelectListTeacherName();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Discipline discipline)
        {
            if (!ModelState.IsValid)
            {
                ViewData["TeacherId"] = _repositoryWrapper.TeacherRepository.SelectListTeacherName(discipline.TeacherId);
                return View();
            }

            await _repositoryWrapper.DisciplinesRepo.Create(discipline);// _repository.Create(discipline);
          
            return RedirectToAction("Index", "Disciplines");
        }

        // Checked add to table dublicate data
        public JsonResult ValidateJsonResultTitle(string title)
        {
            if (_repositoryWrapper.DisciplinesRepo.Get().Any(s => s.Title == title))
                return Json("title is not unique.");
            return Json(true);
        }

        // GET: disciplines/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                throw new ArgumentNullException(
                    "discipline id has not been entered OR discipline id is not number!"); //                return NotFound();

            var discipline = await _repositoryWrapper.DisciplinesRepo.GetById(id);
            if (discipline == null)
            {
                return NotFound();
            }

            return View(discipline);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Discipline discipline)
        {
            if (id != discipline.Id)
            {
                return View(discipline);
            }

            await _repositoryWrapper.DisciplinesRepo.Update(id, discipline);
            return RedirectToAction("Index", "Disciplines");
        }


        // GET: disciplines/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var discipline = await _repositoryWrapper.DisciplinesRepo.GetDiscByIdWithTeacherAsync(id.Value);

            if (discipline == null)
            {
                return NotFound();
            }

            return View(discipline);
        }

        // POST: disciplines/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _repositoryWrapper.DisciplinesRepo.Delete(id);
            return RedirectToAction("Index", "Disciplines");
        }

        // GET: disciplines/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var discipline = await _repositoryWrapper.DisciplinesRepo.GetDiscByIdWithTeacherAsync(id);
            if (discipline == null)
            {
                return NotFound();
            }

            return View(discipline);
        }
    }
}
