using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SAKIB_PORTFOLIO.Data;
using SAKIB_PORTFOLIO.Models;

namespace SAKIB_PORTFOLIO.Controllers
{
    public class DESCRIPTION_TYPEController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DESCRIPTION_TYPEController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: DESCRIPTION_TYPE
        public async Task<IActionResult> Index()
        {
            return View(await _context.DESCRIPTION_TYPE.ToListAsync());
        }

        // GET: DESCRIPTION_TYPE/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dESCRIPTION_TYPE = await _context.DESCRIPTION_TYPE
                .FirstOrDefaultAsync(m => m.AUTO_ID == id);
            if (dESCRIPTION_TYPE == null)
            {
                return NotFound();
            }

            return View(dESCRIPTION_TYPE);
        }

        // GET: DESCRIPTION_TYPE/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DESCRIPTION_TYPE/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AUTO_ID,TYPE")] DESCRIPTION_TYPE dESCRIPTION_TYPE)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dESCRIPTION_TYPE);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dESCRIPTION_TYPE);
        }

        // GET: DESCRIPTION_TYPE/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dESCRIPTION_TYPE = await _context.DESCRIPTION_TYPE.FindAsync(id);
            if (dESCRIPTION_TYPE == null)
            {
                return NotFound();
            }
            return View(dESCRIPTION_TYPE);
        }

        // POST: DESCRIPTION_TYPE/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AUTO_ID,TYPE")] DESCRIPTION_TYPE dESCRIPTION_TYPE)
        {
            if (id != dESCRIPTION_TYPE.AUTO_ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dESCRIPTION_TYPE);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DESCRIPTION_TYPEExists(dESCRIPTION_TYPE.AUTO_ID))
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
            return View(dESCRIPTION_TYPE);
        }

        // GET: DESCRIPTION_TYPE/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dESCRIPTION_TYPE = await _context.DESCRIPTION_TYPE
                .FirstOrDefaultAsync(m => m.AUTO_ID == id);
            if (dESCRIPTION_TYPE == null)
            {
                return NotFound();
            }

            return View(dESCRIPTION_TYPE);
        }

        // POST: DESCRIPTION_TYPE/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dESCRIPTION_TYPE = await _context.DESCRIPTION_TYPE.FindAsync(id);
            if (dESCRIPTION_TYPE != null)
            {
                _context.DESCRIPTION_TYPE.Remove(dESCRIPTION_TYPE);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DESCRIPTION_TYPEExists(int id)
        {
            return _context.DESCRIPTION_TYPE.Any(e => e.AUTO_ID == id);
        }
    }
}
