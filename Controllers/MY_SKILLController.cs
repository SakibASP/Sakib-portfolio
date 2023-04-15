using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SAKIB_PORTFOLIO.Common;
using SAKIB_PORTFOLIO.Data;
using SAKIB_PORTFOLIO.Models;

namespace SAKIB_PORTFOLIO.Controllers
{
    [Authorize]
    public class MY_SKILLController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MY_SKILLController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: MY_SKILL
        public async Task<IActionResult> Index()
        {
              return _context.MY_SKILLS != null ? 
                          View(await _context.MY_SKILLS.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.MY_SKILLS'  is null.");
        }

        // GET: MY_SKILL/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.MY_SKILLS == null)
            {
                return NotFound();
            }

            var mY_SKILLS = await _context.MY_SKILLS
                .FirstOrDefaultAsync(m => m.AUTO_ID == id);
            if (mY_SKILLS == null)
            {
                return NotFound();
            }

            return View(mY_SKILLS);
        }

        // GET: MY_SKILL/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MY_SKILL/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AUTO_ID,SKILL_NAME,SKILL_PERCENTAGE")] MY_SKILLS mY_SKILLS)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mY_SKILLS);
                await _context.SaveChangesAsync();
                HttpContext.Session.Remove(Constant.mySkill);

                return RedirectToAction(nameof(Index));
            }
            return View(mY_SKILLS);
        }

        // GET: MY_SKILL/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.MY_SKILLS == null)
            {
                return NotFound();
            }

            var mY_SKILLS = await _context.MY_SKILLS.FindAsync(id);
            if (mY_SKILLS == null)
            {
                return NotFound();
            }
            return View(mY_SKILLS);
        }

        // POST: MY_SKILL/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AUTO_ID,SKILL_NAME,SKILL_PERCENTAGE")] MY_SKILLS mY_SKILLS)
        {
            if (id != mY_SKILLS.AUTO_ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mY_SKILLS);
                    await _context.SaveChangesAsync();
                    HttpContext.Session.Remove(Constant.mySkill);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MY_SKILLSExists(mY_SKILLS.AUTO_ID))
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
            return View(mY_SKILLS);
        }

        // GET: MY_SKILL/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.MY_SKILLS == null)
            {
                return NotFound();
            }

            var mY_SKILLS = await _context.MY_SKILLS
                .FirstOrDefaultAsync(m => m.AUTO_ID == id);
            if (mY_SKILLS == null)
            {
                return NotFound();
            }

            return View(mY_SKILLS);
        }

        // POST: MY_SKILL/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.MY_SKILLS == null)
            {
                return Problem("Entity set 'ApplicationDbContext.MY_SKILLS'  is null.");
            }
            var mY_SKILLS = await _context.MY_SKILLS.FindAsync(id);
            if (mY_SKILLS != null)
            {
                _context.MY_SKILLS.Remove(mY_SKILLS);
            }
            
            await _context.SaveChangesAsync();
            HttpContext.Session.Remove(Constant.mySkill);

            return RedirectToAction(nameof(Index));
        }

        private bool MY_SKILLSExists(int id)
        {
          return (_context.MY_SKILLS?.Any(e => e.AUTO_ID == id)).GetValueOrDefault();
        }
    }
}
