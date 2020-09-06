using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Global_Logic_ASP.Core.Areas.AccountFilters;
using Global_Logic_ASP.Core.Areas.AccountViewModels;
using Microsoft.AspNetCore.Mvc;
using Global_Logic_ASP.Core.IRepository;
using Global_Logic_ASP.Core.Models;
using Global_Logic_ASP.Core.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using static Global_Logic_ASP.Core.Initializator.Constants;

namespace Global_Logic_ASP.Core.Controllers
{
    //[Authorize(Roles = ADMIN)]
   [ForAdmin]
    public class StudentsController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        private readonly IGenericRepository<Student> _repository;
        public StudentsController(IGenericRepository<Student> repository, UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _repository = repository;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        // GET: Students
        public IActionResult Index()
        {
            return View(_repository.Get()); 
        }
        
        // GET: Students/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(RegisterStudentViewModel student)
        {
            if (!ModelState.IsValid)
                return View();

            var user = new IdentityUser { UserName = student.Name ,Email = student.Email };
            var stud = new Student { Name = student.Name,Group = student.Group};
            // добавляем пользователя
            var result = await _userManager.CreateAsync(user, student.Password);
            if (result.Succeeded)
            {
                // установка куки
                await _signInManager.SignInAsync(user, false);
                // Add new student
                await _repository.Create(stud);
               await _userManager.AddToRoleAsync(user, STUDENT);

               await _userManager.AddClaimAsync(user, new Claim(STUDENTID, stud.Id.ToString()));
                return RedirectToAction("Index", "SelectStudentDisciplines");
            }
            else
            {
                ModelState.AddModelError("Name", result.Errors.First().Description);
            }
            return View(student);
        }

        // GET: Students/Edit/5
           public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                throw new ArgumentNullException("Student id has not been entered OR Student id is not number!"); //                return NotFound();

            var student = await  _repository.GetById(id);
             var user = await _userManager.FindByNameAsync(student.Name);
         
            if (student == null)
            {
                return NotFound();
            }
            var model = new EditStudentViewModel { Name=student.Name,Group =student.Group ,Email =user.Email};

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, EditStudentViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
           
            var student = await _repository.GetById(id);
            var user = await _userManager.FindByNameAsync(student.Name);
            if (user!=null)
            {
                student.Name = model.Name;
                student.Group = model.Group;
                user.Email = model.Email;
                user.UserName = model.Name;
            }
            
            await _userManager.UpdateAsync(user);
            await _repository.Update(id, student);
            return RedirectToAction(nameof(Index), "Students");
        }
        
        // GET: Students/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var student = await _repository.GetById(id.Value);

            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
             await _repository.Delete(id);
             return RedirectToAction(nameof(Index), "Students");
        }

        // GET: Students/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _repository.GetById(id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }


    }
}
