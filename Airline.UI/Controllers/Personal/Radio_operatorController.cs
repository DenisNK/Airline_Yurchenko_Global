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
    public class Radio_operatorController : Controller
    {
        private readonly AirlineContext _context;

        public Radio_operatorController(AirlineContext context)
        {
            _context = context;
        }

        // GET: Radio_operator
        public async Task<IActionResult> Index()
        {
            var airlineContext = _context.Radio_Operators.Include(r => r.Team_Person);
            return View(await airlineContext.ToListAsync());
        }

        // GET: Radio_operator/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var radio_operator = await _context.Radio_Operators
                .Include(r => r.Team_Person)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (radio_operator == null)
            {
                return NotFound();
            }

            return View(radio_operator);
        }

        // GET: Radio_operator/Create
        public IActionResult Create()
        {
            ViewData["Team_PersonId"] = new SelectList(_context.Team_Persons, "Id", "Name_Team");
            return View();
        }

        // POST: Radio_operator/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Surname,Age,Experience,Salary,Team_PersonId,Id")] Radio_operator radio_operator)
        {
            if (ModelState.IsValid)
            {
                _context.Add(radio_operator);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Team_PersonId"] = new SelectList(_context.Team_Persons, "Id", "Name_Team", radio_operator.Team_PersonId);
            return View(radio_operator);
        }

        // GET: Radio_operator/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var radio_operator = await _context.Radio_Operators.FindAsync(id);
            if (radio_operator == null)
            {
                return NotFound();
            }
            ViewData["Team_PersonId"] = new SelectList(_context.Team_Persons, "Id", "Name_Team", radio_operator.Team_PersonId);
            return View(radio_operator);
        }

        // POST: Radio_operator/Edit/5
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Name,Surname,Age,Experience,Salary,Team_PersonId,Id")] Radio_operator radio_operator)
        {
            if (id != radio_operator.Id)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                ViewData["Team_PersonId"] =
                    new SelectList(_context.Team_Persons, "Id", "Name_Team", radio_operator.Team_PersonId);
                return View(radio_operator);
            }

            try
            {
                _context.Update(radio_operator);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Radio_operatorExists(radio_operator.Id))
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

        // GET: Radio_operator/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var radio_operator = await _context.Radio_Operators
                .Include(r => r.Team_Person)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (radio_operator == null)
            {
                return NotFound();
            }

            return View(radio_operator);
        }

        // POST: Radio_operator/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var radio_operator = await _context.Radio_Operators.FindAsync(id);
            _context.Radio_Operators.Remove(radio_operator);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Radio_operatorExists(int id)
        {
            return _context.Radio_Operators.Any(e => e.Id == id);
        }
    }
}
