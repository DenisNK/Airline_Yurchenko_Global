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
    public class FligthsController : Controller
    {
        private readonly AirlineContext _context;

        public FligthsController(AirlineContext context)
        {
            _context = context;
        }

        // GET: Fligths
        public async Task<IActionResult> Index()
        {
            var airlineContext = _context.Fligths.Include(f => f.FromCity).Include(f => f.WhereCity);
            return View(await airlineContext.ToListAsync());
        }

        // GET: Fligths/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fligth = await _context.Fligths
                .Include(f => f.FromCity)
                .Include(f => f.WhereCity)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (fligth == null)
            {
                return NotFound();
            }

            return View(fligth);
        }

        // GET: Fligths/Create
        public IActionResult Create()
        {
            ViewData["FromCityId"] = new SelectList(_context.Cities, "Id", "AirportCode");
            ViewData["WhereCityId"] = new SelectList(_context.Cities, "Id", "AirportCode");
            return View();
        }

        // POST: Fligths/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name_Fligth,FromCityId,WhereCityId,DepartureDate,ArrivalDate,IsConfirmed,Price,Id")] Fligth fligth)
        {
            if (ModelState.IsValid)
            {
                _context.Add(fligth);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FromCityId"] = new SelectList(_context.Cities, "Id", "AirportCode", fligth.FromCityId);
            ViewData["WhereCityId"] = new SelectList(_context.Cities, "Id", "AirportCode", fligth.WhereCityId);
            return View(fligth);
        }

        // GET: Fligths/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fligth = await _context.Fligths.FindAsync(id);
            if (fligth == null)
            {
                return NotFound();
            }
            ViewData["FromCityId"] = new SelectList(_context.Cities, "Id", "AirportCode", fligth.FromCityId);
            ViewData["WhereCityId"] = new SelectList(_context.Cities, "Id", "AirportCode", fligth.WhereCityId);
            return View(fligth);
        }

        // POST: Fligths/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Name_Fligth,FromCityId,WhereCityId,DepartureDate,ArrivalDate,IsConfirmed,Price,Id")] Fligth fligth)
        {
            if (id != fligth.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(fligth);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FligthExists(fligth.Id))
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
            ViewData["FromCityId"] = new SelectList(_context.Cities, "Id", "AirportCode", fligth.FromCityId);
            ViewData["WhereCityId"] = new SelectList(_context.Cities, "Id", "AirportCode", fligth.WhereCityId);
            return View(fligth);
        }

        // GET: Fligths/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fligth = await _context.Fligths
                .Include(f => f.FromCity)
                .Include(f => f.WhereCity)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (fligth == null)
            {
                return NotFound();
            }

            return View(fligth);
        }

        // POST: Fligths/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var fligth = await _context.Fligths.FindAsync(id);
            _context.Fligths.Remove(fligth);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FligthExists(int id)
        {
            return _context.Fligths.Any(e => e.Id == id);
        }
    }
}
