using System;
using System.Collections.Generic;
using System.Linq;
using Global_Logic_ASP.Core.Areas.AccountFilters;
using Global_Logic_ASP.Core.DAL;
using Global_Logic_ASP.Core.IRepository;
using Global_Logic_ASP.Core.Models;
using Global_Logic_ASP.Core.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static Global_Logic_ASP.Core.Initializator.Constants;
namespace Global_Logic_ASP.Core.Controllers
{
    // [Authorize(Roles = STUDENT)]
    [ForStudent]
    public class SelectStudentDisciplinesController : Controller
    {
       
        private readonly IRepositoryWrapper _repositoryWrapper;

        public SelectStudentDisciplinesController(AirlineContext context, IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }
        public IActionResult Index()
        {
            var claim = User.Claims.FirstOrDefault(c => c.Type == STUDENTID);
            if (claim == null)
                return View();
            return RedirectToAction(nameof(Select), new { id = Convert.ToInt32(claim.Value) });
        }

        [HttpGet]
        public IActionResult Select(int? id)
        {
            var student = _repositoryWrapper.StudentRepo.GetWithInclude(e => e.StudDiscs).SingleOrDefault(t => t.Id == id);
            var selectDiscId = student.StudDiscs.Select(e => e.DisciplineId);
            var disc = _repositoryWrapper.DisciplinesRepo.Get();
            var model = new StudentDisciplinesViewModel { Student = student };
            model.IsChoose = disc.Where(t => selectDiscId.Contains(t.Id)).OrderBy(sort => sort.Title);
            model.NoChoose = disc.Except(model.IsChoose).OrderBy(sort => sort.Title);
            return View(model);
        }

        [HttpPost]
        public IActionResult Select(int studentId, int[] IsChoose)
        {
            var student = _repositoryWrapper.StudentRepo.GetWithInclude(e => e.StudDiscs).SingleOrDefault(t => t.Id == studentId);
            student.StudDiscs = new List<StudDisc>();
            foreach (var discId in IsChoose)
            {
                student.StudDiscs.Add(new StudDisc { StudentId = student.Id, DisciplineId = discId });
            }
            _repositoryWrapper.Save();
            return RedirectToAction(nameof(Select));
        }
    }
}
