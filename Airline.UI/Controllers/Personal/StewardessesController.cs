using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Airline.DAL.Airline_Db_Context;
using Airline.DAL.Models;

namespace Airline_Yurchenko.Controllers.Personal
{
    public class StewardessesController : Controller
    {
        private readonly AirlineContext _context;

        public StewardessesController(AirlineContext context)
        {
            _context = context;
        }

        // GET: Stewardesses
        public async Task<IActionResult> Index()
        {
            var airlineContext = _context.Stewardesses.Include(s => s.Team_Person);
            return View(await airlineContext.ToListAsync());
        }

        // GET: Stewardesses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stewardess = await _context.Stewardesses
                .Include(s => s.Team_Person)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (stewardess == null)
            {
                return NotFound();
            }

            return View(stewardess);
        }

        // GET: Stewardesses/Create
        public IActionResult Create()
        {
            ViewData["Team_PersonId"] = new SelectList(_context.Team_Persons, "Id", "Name_Team");
            return View();
        }

        // POST: Stewardesses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Surname,Age,Experience,Salary,Team_PersonId,Id")] Stewardess stewardess)
        {
            if (ModelState.IsValid)
            {
                _context.Add(stewardess);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Team_PersonId"] = new SelectList(_context.Team_Persons, "Id", "Name_Team", stewardess.Team_PersonId);
            return View(stewardess);
        }

        // GET: Stewardesses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stewardess = await _context.Stewardesses.FindAsync(id);
            if (stewardess == null)
            {
                return NotFound();
            }
            ViewData["Team_PersonId"] = new SelectList(_context.Team_Persons, "Id", "Name_Team", stewardess.Team_PersonId);
            return View(stewardess);
        }

        // POST: Stewardesses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Name,Surname,Age,Experience,Salary,Team_PersonId,Id")] Stewardess stewardess)
        {
            if (id != stewardess.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(stewardess);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StewardessExists(stewardess.Id))
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
            ViewData["Team_PersonId"] = new SelectList(_context.Team_Persons, "Id", "Name_Team", stewardess.Team_PersonId);
            return View(stewardess);
        }

        // GET: Stewardesses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stewardess = await _context.Stewardesses
                .Include(s => s.Team_Person)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (stewardess == null)
            {
                return NotFound();
            }

            return View(stewardess);
        }

        // POST: Stewardesses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var stewardess = await _context.Stewardesses.FindAsync(id);
            _context.Stewardesses.Remove(stewardess);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StewardessExists(int id)
        {
            return _context.Stewardesses.Any(e => e.Id == id);
        }
    }
}
