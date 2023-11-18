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
    public class DESCRIPTIONsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DESCRIPTIONsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: DESCRIPTIONs
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.DESCRIPTION.Include(d => d.DESCRIPTION_TYPE_);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: DESCRIPTIONs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dESCRIPTION = await _context.DESCRIPTION
                .Include(d => d.DESCRIPTION_TYPE_)
                .FirstOrDefaultAsync(m => m.AUTO_ID == id);
            if (dESCRIPTION == null)
            {
                return NotFound();
            }

            return View(dESCRIPTION);
        }

        // GET: DESCRIPTIONs/Create
        public IActionResult Create()
        {
            ViewData["TYPE_ID"] = new SelectList(_context.DESCRIPTION_TYPE, "AUTO_ID", "TYPE");
            return View();
        }

        // POST: DESCRIPTIONs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AUTO_ID,DESCRIPTION_TEXT,TYPE_ID,CREATED_BY,CREATED_DATE,MODIFIED_BY,MODIFIED_DATE,SORT_ORDER")] DESCRIPTION dESCRIPTION)
        {
            if (ModelState.IsValid)
            {
                dESCRIPTION.CREATED_BY = User.Identity!.Name;
                dESCRIPTION.CREATED_DATE = DateTime.Now;
                _context.Add(dESCRIPTION);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TYPE_ID"] = new SelectList(_context.DESCRIPTION_TYPE, "AUTO_ID", "TYPE", dESCRIPTION.TYPE_ID);
            return View(dESCRIPTION);
        }

        // GET: DESCRIPTIONs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dESCRIPTION = await _context.DESCRIPTION.FindAsync(id);
            if (dESCRIPTION == null)
            {
                return NotFound();
            }
            ViewData["TYPE_ID"] = new SelectList(_context.DESCRIPTION_TYPE, "AUTO_ID", "TYPE", dESCRIPTION.TYPE_ID);
            return View(dESCRIPTION);
        }

        // POST: DESCRIPTIONs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AUTO_ID,DESCRIPTION_TEXT,TYPE_ID,CREATED_BY,CREATED_DATE,MODIFIED_BY,MODIFIED_DATE,SORT_ORDER")] DESCRIPTION dESCRIPTION)
        {
            if (id != dESCRIPTION.AUTO_ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    dESCRIPTION.MODIFIED_BY = User.Identity!.Name;
                    dESCRIPTION.MODIFIED_DATE = DateTime.Now;
                    _context.Update(dESCRIPTION);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DESCRIPTIONExists(dESCRIPTION.AUTO_ID))
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
            ViewData["TYPE_ID"] = new SelectList(_context.DESCRIPTION_TYPE, "AUTO_ID", "TYPE", dESCRIPTION.TYPE_ID);
            return View(dESCRIPTION);
        }

        // GET: DESCRIPTIONs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dESCRIPTION = await _context.DESCRIPTION
                .Include(d => d.DESCRIPTION_TYPE_)
                .FirstOrDefaultAsync(m => m.AUTO_ID == id);
            if (dESCRIPTION == null)
            {
                return NotFound();
            }

            return View(dESCRIPTION);
        }

        // POST: DESCRIPTIONs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dESCRIPTION = await _context.DESCRIPTION.FindAsync(id);
            if (dESCRIPTION != null)
            {
                _context.DESCRIPTION.Remove(dESCRIPTION);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DESCRIPTIONExists(int id)
        {
            return _context.DESCRIPTION.Any(e => e.AUTO_ID == id);
        }
    }
}
