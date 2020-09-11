﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Airline.DAL.Airline_Db_Context;
using Airline.DAL.IRepository;
using Airline.DAL.IRepository.IEntityRepository;
using Airline.DAL.Models;

namespace Airline_Yurchenko.Controllers
{
    public class Team_PersonController : Controller
    {
        private readonly IRepositoryWrapper _repositoryWrapper;

        public Team_PersonController(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }
        public IActionResult PersonalList()
        {
            return View();
        }

        // GET: Team_Person
        public IActionResult Index()
        {
            return View(_repositoryWrapper.TeamPersonRepository.Get());
        }
                      
        [HttpGet]
        public async Task <ActionResult> TeamDetails(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var teamPerson = await _repositoryWrapper.TeamPersonRepository.GetTeamByIdWithAllTeamAsync(id);
        
            if (teamPerson == null)
            {
                return NotFound();
            }
            return View(teamPerson);
        }


        // GET: Team_Person/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var teamPerson = await _repositoryWrapper.TeamPersonRepository.GetById(id);
            if (teamPerson == null)
            {
                return NotFound();
            }

            return View(teamPerson);
        }

        // GET: Team_Person/Create
        public IActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name_Team,Id")] Team_Person teamPerson)
        {
            if (ModelState.IsValid)
            {
                await _repositoryWrapper.TeamPersonRepository.Create(teamPerson);
                return RedirectToAction(nameof(Index));
            }
            return View(teamPerson);
        }

        // GET: Team_Person/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var teamPerson = await _repositoryWrapper.TeamPersonRepository.GetById(id);
            if (teamPerson == null)
            {
                return NotFound();
            }
            return View(teamPerson);
        }

        // POST: Team_Person/Edit/5
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Name_Team,Id")] Team_Person teamPerson)
        {
            if (id != teamPerson.Id)
            {
                return NotFound();
            }

            if (!ModelState.IsValid) 
                return View(teamPerson);

            await _repositoryWrapper.TeamPersonRepository.Update(id, teamPerson);
            return RedirectToAction(nameof(Index));
        }

        // GET: Team_Person/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var teamPerson = await _repositoryWrapper.TeamPersonRepository.GetById(id);
            if (teamPerson == null)
            {
                return NotFound();
            }

            return View(teamPerson);
        }

        // POST: Team_Person/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _repositoryWrapper.TeamPersonRepository.Delete(id);
            
            return RedirectToAction(nameof(Index));
        }
        
    }
}
