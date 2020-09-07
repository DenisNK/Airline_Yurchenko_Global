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
    public class FligthTeamsController : Controller
    {
        private readonly AirlineContext _context;

        public FligthTeamsController(AirlineContext context)
        {
            _context = context;
        }

        // GET: FligthTeams
        public async Task<IActionResult> Index()
        {
            var airlineContext = _context.FligthTeams.Include(f => f.Fligth).Include(f => f.Team_Person);
            return View(await airlineContext.ToListAsync());
        }

        // GET: FligthTeams/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fligthTeam = await _context.FligthTeams
                .Include(f => f.Fligth)
                .Include(f => f.Team_Person)
                .FirstOrDefaultAsync(m => m.Team_PersonId == id);
            if (fligthTeam == null)
            {
                return NotFound();
            }

            return View(fligthTeam);
        }

        // GET: FligthTeams/Create
        public IActionResult Create()
        {
            ViewData["FligthId"] = new SelectList(_context.Fligths, "Id", "Name_Fligth");
            ViewData["Team_PersonId"] = new SelectList(_context.Team_Persons, "Id", "Name_Team");
            return View();
        }

        // POST: FligthTeams/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FligthId,Team_PersonId")] FligthTeam fligthTeam)
        {
            if (ModelState.IsValid)
            {
                _context.Add(fligthTeam);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FligthId"] = new SelectList(_context.Fligths, "Id", "Name_Fligth", fligthTeam.FligthId);
            ViewData["Team_PersonId"] = new SelectList(_context.Team_Persons, "Id", "Name_Team", fligthTeam.Team_PersonId);
            return View(fligthTeam);
        }

        // GET: FligthTeams/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fligthTeam = await _context.FligthTeams.FindAsync(id);
            if (fligthTeam == null)
            {
                return NotFound();
            }
            ViewData["FligthId"] = new SelectList(_context.Fligths, "Id", "Name_Fligth", fligthTeam.FligthId);
            ViewData["Team_PersonId"] = new SelectList(_context.Team_Persons, "Id", "Name_Team", fligthTeam.Team_PersonId);
            return View(fligthTeam);
        }

        // POST: FligthTeams/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FligthId,Team_PersonId")] FligthTeam fligthTeam)
        {
            if (id != fligthTeam.Team_PersonId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(fligthTeam);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FligthTeamExists(fligthTeam.Team_PersonId))
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
            ViewData["FligthId"] = new SelectList(_context.Fligths, "Id", "Name_Fligth", fligthTeam.FligthId);
            ViewData["Team_PersonId"] = new SelectList(_context.Team_Persons, "Id", "Name_Team", fligthTeam.Team_PersonId);
            return View(fligthTeam);
        }

        // GET: FligthTeams/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fligthTeam = await _context.FligthTeams
                .Include(f => f.Fligth)
                .Include(f => f.Team_Person)
                .FirstOrDefaultAsync(m => m.Team_PersonId == id);
            if (fligthTeam == null)
            {
                return NotFound();
            }

            return View(fligthTeam);
        }

        // POST: FligthTeams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var fligthTeam = await _context.FligthTeams.FindAsync(id);
            _context.FligthTeams.Remove(fligthTeam);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FligthTeamExists(int id)
        {
            return _context.FligthTeams.Any(e => e.Team_PersonId == id);
        }
    }
}
