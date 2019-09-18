using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LiftingWeight.Models;

namespace LiftingWeight.Controllers
{
    public class LiftingProgressController : Controller
    {
        private readonly WeightLiftingDbContext _context;

        public LiftingProgressController(WeightLiftingDbContext context)
        {
            _context = context;
        }

        // GET: LiftingProgress
        public async Task<IActionResult> Index()
        {
            var weightLiftingDbContext = _context.LiftingProgress.Include(l => l.Exercise);
            return View(await weightLiftingDbContext.ToListAsync());
        }

        // GET: LiftingProgress/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var liftingProgress = await _context.LiftingProgress
                .Include(l => l.Exercise)
                .FirstOrDefaultAsync(m => m.ProgressId == id);
            if (liftingProgress == null)
            {
                return NotFound();
            }

            return View(liftingProgress);
        }

        // GET: LiftingProgress/Create
        public IActionResult Create()
        {
            ViewData["ExerciseId"] = new SelectList(_context.Exercises, "ExerciseId", "ExerciseId");
            return View();
        }

        // POST: LiftingProgress/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProgressId,WorkoutDate,WeightUsed,Repititions,ExerciseId")] LiftingProgress liftingProgress)
        {
            if (ModelState.IsValid)
            {
                _context.Add(liftingProgress);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ExerciseId"] = new SelectList(_context.Exercises, "ExerciseId", "ExerciseId", liftingProgress.ExerciseId);
            return View(liftingProgress);
        }

        // GET: LiftingProgress/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var liftingProgress = await _context.LiftingProgress.FindAsync(id);
            if (liftingProgress == null)
            {
                return NotFound();
            }
            ViewData["ExerciseId"] = new SelectList(_context.Exercises, "ExerciseId", "ExerciseId", liftingProgress.ExerciseId);
            return View(liftingProgress);
        }

        // POST: LiftingProgress/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProgressId,WorkoutDate,WeightUsed,Repititions,ExerciseId")] LiftingProgress liftingProgress)
        {
            if (id != liftingProgress.ProgressId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(liftingProgress);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LiftingProgressExists(liftingProgress.ProgressId))
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
            ViewData["ExerciseId"] = new SelectList(_context.Exercises, "ExerciseId", "ExerciseId", liftingProgress.ExerciseId);
            return View(liftingProgress);
        }

        // GET: LiftingProgress/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var liftingProgress = await _context.LiftingProgress
                .Include(l => l.Exercise)
                .FirstOrDefaultAsync(m => m.ProgressId == id);
            if (liftingProgress == null)
            {
                return NotFound();
            }

            return View(liftingProgress);
        }

        // POST: LiftingProgress/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var liftingProgress = await _context.LiftingProgress.FindAsync(id);
            _context.LiftingProgress.Remove(liftingProgress);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LiftingProgressExists(int id)
        {
            return _context.LiftingProgress.Any(e => e.ProgressId == id);
        }
    }
}
