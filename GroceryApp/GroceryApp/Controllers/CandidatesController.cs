using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GroceryApp.Models;

namespace GroceryApp.Controllers
{
    public class CandidatesController : Controller
    {
        private readonly GroceryAppContext _context;

        public CandidatesController(GroceryAppContext context)
        {
            _context = context;    
        }

        // GET: Candidates
        public async Task<IActionResult> Index()
        {
            return View(await _context.Candidates.ToListAsync());
        }

        // GET: Candidates/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var candidates = await _context.Candidates
                .SingleOrDefaultAsync(m => m.Id == id);
            if (candidates == null)
            {
                return NotFound();
            }

            return View(candidates);
        }

        // GET: Candidates/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Candidates/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,Goals,Bands")] Candidates candidates)
        {
            if (ModelState.IsValid)
            {
                _context.Add(candidates);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(candidates);
        }

        // GET: Candidates/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var candidates = await _context.Candidates.SingleOrDefaultAsync(m => m.Id == id);
            if (candidates == null)
            {
                return NotFound();
            }
            return View(candidates);
        }

        // POST: Candidates/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,Goals,Bands")] Candidates candidates)
        {
            if (id != candidates.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(candidates);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CandidatesExists(candidates.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            return View(candidates);
        }

        // GET: Candidates/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var candidates = await _context.Candidates
                .SingleOrDefaultAsync(m => m.Id == id);
            if (candidates == null)
            {
                return NotFound();
            }

            return View(candidates);
        }

        // POST: Candidates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var candidates = await _context.Candidates.SingleOrDefaultAsync(m => m.Id == id);
            _context.Candidates.Remove(candidates);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool CandidatesExists(int id)
        {
            return _context.Candidates.Any(e => e.Id == id);
        }
    }
}
