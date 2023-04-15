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
    public class CONTACTSController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CONTACTSController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: CONTACTS
        public async Task<IActionResult> Index()
        {
              return _context.CONTACTS != null ? 
                          View(await _context.CONTACTS.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.CONTACTS'  is null.");
        }
        
        public async Task<IActionResult> PendingIndex()
        {
              return _context.CONTACTS != null ? 
                          View(await _context.CONTACTS.Where(x=>x.IsConfirmed == null).ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.CONTACTS'  is null.");
        }

        // GET: CONTACTS/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.CONTACTS == null)
            {
                return NotFound();
            }

            var cONTACTS = await _context.CONTACTS
                .FirstOrDefaultAsync(m => m.AUTO_ID == id);

            if (cONTACTS == null)
            {
                return NotFound();
            }
            cONTACTS.IsConfirmed = 1;
            _context.CONTACTS.Update(cONTACTS);
            _context.SaveChanges();
            HttpContext.Session.Remove(Constant.myContact);

            return View(cONTACTS);
        }

        // GET: CONTACTS/Create
        //public IActionResult Create()
        //{
        //    return View();
        //}

        // POST: CONTACTS/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("AUTO_ID,IsConfirmed,NAME,SUBJECT,MESSAGE,EMAIL,PHONE")] CONTACTS cONTACTS)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(cONTACTS);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(cONTACTS);
        //}

        // GET: CONTACTS/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.CONTACTS == null)
            {
                return NotFound();
            }

            var cONTACTS = await _context.CONTACTS.FindAsync(id);
            if (cONTACTS == null)
            {
                return NotFound();
            }
            return View(cONTACTS);
        }

        // POST: CONTACTS/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AUTO_ID,IsConfirmed,NAME,SUBJECT,MESSAGE,EMAIL,PHONE")] CONTACTS cONTACTS)
        {
            if (id != cONTACTS.AUTO_ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cONTACTS);
                    await _context.SaveChangesAsync();
                    HttpContext.Session.Remove(Constant.myContact);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CONTACTSExists(cONTACTS.AUTO_ID))
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
            return View(cONTACTS);
        }

        // GET: CONTACTS/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null || _context.CONTACTS == null)
        //    {
        //        return NotFound();
        //    }

        //    var cONTACTS = await _context.CONTACTS
        //        .FirstOrDefaultAsync(m => m.AUTO_ID == id);
        //    if (cONTACTS == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(cONTACTS);
        //}

        //// POST: CONTACTS/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    if (_context.CONTACTS == null)
        //    {
        //        return Problem("Entity set 'ApplicationDbContext.CONTACTS'  is null.");
        //    }
        //    var cONTACTS = await _context.CONTACTS.FindAsync(id);
        //    if (cONTACTS != null)
        //    {
        //        _context.CONTACTS.Remove(cONTACTS);
        //    }
            
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        private bool CONTACTSExists(int id)
        {
          return (_context.CONTACTS?.Any(e => e.AUTO_ID == id)).GetValueOrDefault();
        }
    }
}
