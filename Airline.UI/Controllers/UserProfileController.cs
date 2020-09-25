using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Airline.DAL.IRepository;
using Airline.DAL.Models;
using Airline_Yurchenko.Areas.AccountFilters;
using Airline_Yurchenko.Areas.IdentityViewModels;
using Airline_Yurchenko.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using static Airline.DAL.Initializator.Constants;
namespace Airline_Yurchenko.Controllers
{
    //[Authorize(Roles = ADMIN)]
    [ForAdmin]
    public class UserProfileController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        private readonly IGenericRepository<UserProfile> _repository;
        public UserProfileController(IGenericRepository<UserProfile> repository, UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _repository = repository;
            _userManager = userManager;
            _signInManager = signInManager;
        }

      
        public IActionResult Index()
        {
            return View(_repository.Get());
        }

      
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(RegisterUserViewModel userprofile)
        {
            if (!ModelState.IsValid)
                return View();

            var user = new IdentityUser { UserName = userprofile.Name, Email = userprofile.Email };
            var stud = new UserProfile { Name = userprofile.Name, Gender = userprofile.Gender };
            // добавляем пользователя
            var result = await _userManager.CreateAsync(user, userprofile.Password);
            if (result.Succeeded)
            {
                // установка куки
                await _signInManager.SignInAsync(user, false);
                // Add new userprofile
                await _repository.Create(stud);
                await _userManager.AddToRoleAsync(user, USER);

                await _userManager.AddClaimAsync(user, new Claim(USERID, stud.Id.ToString()));
                return RedirectToAction("Index", "Fligths");
            }
            else
            {
                ModelState.AddModelError("Name", result.Errors.First().Description);
            }
            return View(userprofile);
        }

      
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                throw new ArgumentNullException("UserProfile id has not been entered OR UserProfile id is not number!"); //                return NotFound();

            var userprofile = await _repository.GetById(id);
            var user = await _userManager.FindByNameAsync(userprofile.Name);

            if (userprofile == null)
            {
                return NotFound();
            }
            var model = new EditStudentViewModel { Name = userprofile.Name, Gender = userprofile.Gender, Email = user.Email };

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

            var userprofile = await _repository.GetById(id);
            var user = await _userManager.FindByNameAsync(userprofile.Name);
            if (user != null)
            {
                userprofile.Name = model.Name;
                userprofile.Gender = model.Gender;
                user.Email = model.Email;
                user.UserName = model.Name;
            }

            await _userManager.UpdateAsync(user);
            await _repository.Update(id, userprofile);
            return RedirectToAction(nameof(Index), "UserProfile");
        }

       
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var userprofile = await _repository.GetById(id.Value);

            if (userprofile == null)
            {
                return NotFound();
            }
            return View(userprofile);
        }

      
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _repository.Delete(id);
            return RedirectToAction(nameof(Index), "UserProfile");
        }

      
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userprofile = await _repository.GetById(id);
            if (userprofile == null)
            {
                return NotFound();
            }

            return View(userprofile);
        }


    }
}
