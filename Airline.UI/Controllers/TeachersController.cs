using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Global_Logic_ASP.Core.Models;
using Global_Logic_ASP.Core.IRepository;
using Global_Logic_ASP.Core.ViewModels;

namespace Global_Logic_ASP.Core.Controllers
{
    public class TeachersController : Controller
    {
        private readonly IGenericRepository<Teacher> _repository;
        public TeachersController(IGenericRepository<Teacher> repository)
        {
            _repository = repository;
        }

        // GET: Teacher
        public IActionResult Index()
        {
            return View(_repository.Get());
        }

        // GET: teachers/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Teacher teacher)
        {
            if (!ModelState.IsValid)
                return View();
            await _repository.Create(teacher);
            return RedirectToAction("Index", "Teachers");
        }

        // GET: teachers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                throw new ArgumentNullException("teacher id has not been entered OR teacher id is not number!"); //                return NotFound();

            var teacher = await _repository.GetById(id);
            var model = new EditTeacherViewModel { Name = teacher.Name };
            if (teacher == null)
            {
                return NotFound();
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, EditTeacherViewModel teacher)
        {
            if (id != teacher.Id)
            {
                return View(teacher);
            }

            var teah = await _repository.GetById(id);
            teah.Name = teacher.Name;
            await _repository.Update(id, teah);
            return RedirectToAction("Index", "Teachers");
        }

        // GET: teachers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var teacher = await _repository.GetById(id.Value);

            if (teacher == null)
            {
                return NotFound();
            }
            return View(teacher);
        }

        // POST: teachers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _repository.Delete(id);
            return RedirectToAction("Index", "Teachers");
        }

        // GET: teachers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var teacher = await _repository.GetById(id);
            if (teacher == null)
            {
                return NotFound();
            }

            return View(teacher);
        }


    }
}
