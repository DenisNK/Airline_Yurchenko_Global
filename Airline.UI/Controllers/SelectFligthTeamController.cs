using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Airline.DAL.Airline_Db_Context;
using Airline.DAL.Models;
using Airline_Yurchenko.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Airline_Yurchenko.Controllers
{
    public class SelectFligthTeamController : Controller
    {
        private readonly AirlineContext _context;

        public SelectFligthTeamController(AirlineContext context)
        {
            _context = context;
        }
            

        [HttpGet]
        public IActionResult ListSelectTeamFligth(int? id)
        {
            var fligth = _context.Fligths.Include(e=> e.FligthTeams).SingleOrDefault(t => t.Id == id);
            var selectFligthId = fligth.FligthTeams.Select(e => e.Team_PersonId);
            var team = _context.Team_Persons;
            var model = new FligthListViewModels { Fligth = fligth};
            model.IsChoose = team.Where(t => selectFligthId.Contains(t.Id)).OrderBy(sort => sort.Name_Team);
            return View(model);
        }

        [HttpGet]
        public IActionResult Select(int? id)
        {
            var fligth = _context.Fligths.Include(e => e.FligthTeams).SingleOrDefault(t => t.Id == id);
            var selectFligthId = fligth.FligthTeams.Select(e => e.Team_PersonId);
            var team = _context.Team_Persons;
            var model = new FligthListViewModels { Fligth = fligth };
            model.IsChoose = team.Where(t => selectFligthId.Contains(t.Id)).OrderBy(sort => sort.Name_Team);
            model.NoChoose = team.Except(model.IsChoose).OrderBy(sort => sort.Name_Team);
            return View(model);
        }
        [HttpPost]
        public IActionResult Select(int fligthId, int[] IsChoose)
        {
            var fligth = _context.Fligths.Include(e => e.FligthTeams).SingleOrDefault(t => t.Id == fligthId);
            fligth.FligthTeams = new List<FligthTeam>();
            foreach (var discId in IsChoose)
            {
                fligth.FligthTeams.Add(new FligthTeam { FligthId = fligth.Id, Team_PersonId = discId });
            }
            _context.SaveChanges();
            return RedirectToAction(nameof(Select));
        }

    }
}
