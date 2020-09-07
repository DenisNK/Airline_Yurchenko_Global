using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Airline.DAL.Airline_Db_Context;
using Airline.DAL.Models;

namespace Airline_Yurchenko.Controllers
{
    public class Team_PersonController : Controller
    {
        private readonly AirlineContext _context;

        public Team_PersonController(AirlineContext context)
        {
            _context = context;
        }

        // GET: Team_Person
        public async Task<IActionResult> Index()
        {
            return View(await _context.Team_Persons.ToListAsync());
        }


        [HttpGet]
        public async Task <ActionResult> TeamDetails(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Team_Person team_Person = _context.Team_Persons.Include(t => t.Pilots).FirstOrDefault(t => t.Id == id);
            team_Person = _context.Team_Persons.Include(t => t.Radio_Operators).FirstOrDefault(t => t.Id == id);
            team_Person = _context.Team_Persons.Include(t => t.Stewardesses).FirstOrDefault(t => t.Id == id);
            team_Person = _context.Team_Persons.Include(t => t.Navigators).FirstOrDefault(t => t.Id == id);
            if (team_Person == null)
            {
                return NotFound();
            }
            return View(team_Person);
        }


        // GET: Team_Person/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var team_Person = await _context.Team_Persons
                .FirstOrDefaultAsync(m => m.Id == id);
            if (team_Person == null)
            {
                return NotFound();
            }

            return View(team_Person);
        }

        // GET: Team_Person/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Team_Person/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name_Team,Id")] Team_Person team_Person)
        {
            if (ModelState.IsValid)
            {
                _context.Add(team_Person);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(team_Person);
        }

        // GET: Team_Person/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var team_Person = await _context.Team_Persons.FindAsync(id);
            if (team_Person == null)
            {
                return NotFound();
            }
            return View(team_Person);
        }

        // POST: Team_Person/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Name_Team,Id")] Team_Person team_Person)
        {
            if (id != team_Person.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(team_Person);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Team_PersonExists(team_Person.Id))
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
            return View(team_Person);
        }

        // GET: Team_Person/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var team_Person = await _context.Team_Persons
                .FirstOrDefaultAsync(m => m.Id == id);
            if (team_Person == null)
            {
                return NotFound();
            }

            return View(team_Person);
        }

        // POST: Team_Person/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var team_Person = await _context.Team_Persons.FindAsync(id);
            _context.Team_Persons.Remove(team_Person);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Team_PersonExists(int id)
        {
            return _context.Team_Persons.Any(e => e.Id == id);
        }
    }
}
