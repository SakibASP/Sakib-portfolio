using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using SAKIB_PORTFOLIO.Common;
using SAKIB_PORTFOLIO.Data;
using SAKIB_PORTFOLIO.Models;

namespace SAKIB_PORTFOLIO.Controllers
{
    public class MY_PROFILEController : BaseController
    {
        private readonly ApplicationDbContext _context;
        public MY_PROFILEController(ApplicationDbContext context, IMemoryCache cache) : base(cache)
        {
            _context = context;
        }

        // GET: MY_PROFILE
        [Authorize]
        public async Task<IActionResult> Index()
        {
              return _context.MY_PROFILE != null ? 
                          View(await _context.MY_PROFILE.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.MY_PROFILE'  is null.");
        }

        public async Task<IActionResult> About()
        {
            ViewData["SKILLS"] = await _context.MY_SKILLS.AsNoTracking().ToListAsync();
            ViewData["PROFILES"] = await _context.MY_PROFILE.AsNoTracking().FirstOrDefaultAsync();
            return View();
        }

        public async Task<IActionResult> Resume()
        {
            ViewData["PROFILES"] = await _context.MY_PROFILE.AsNoTracking().FirstOrDefaultAsync();
            ViewData["EDUCATIONS"] = await _context.EDUCATION.AsNoTracking().ToListAsync(); 
            ViewData["EXPERIENCEs"] = await _context.EXPERIENCE.AsNoTracking().ToListAsync(); 
            return View();
        }

        public async Task<IActionResult> Projects()
        {
            ViewData["PROFILES"] = await _context.MY_PROFILE.AsNoTracking().FirstOrDefaultAsync();
            ViewData["PROJECTS"] = await _context.PROJECTS.AsNoTracking().ToListAsync();
            return View();
        }

        // for testing images view in browser
        public IActionResult Test()
        {
            var services = _context.PROJECTS.ToList();
            var prof = _context.MY_PROFILE.FirstOrDefault();

            ViewData["PROFILES"] = prof;
            ViewData["PROJECTS"] = services;
            return View();
        }

        public async Task<IActionResult> Contact()
        {
            ViewData["PROFILES"] = await _context.MY_PROFILE.AsNoTracking().FirstOrDefaultAsync();
            return View();
        }

        [HttpPost]
        public JsonResult Contact(CONTACTS objContact)
        {
            try
            {
                _context.CONTACTS.Add(objContact);
                _context.SaveChanges();
                _cache.Remove(Constant.myContact);

                //HttpContext.Session.Remove(Constant.myContact);

                return Json(data: new { message = "Message Sent Successfully", status = true });
            }
            catch (Exception ex)
            {
                return Json(data: new { message = ex.Message, status = false });
            }
        }
        //// GET: MY_PROFILE/Details/5
        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null || _context.MY_PROFILE == null)
        //    {
        //        return NotFound();
        //    }

        //    var mY_PROFILE = await _context.MY_PROFILE
        //        .FirstOrDefaultAsync(m => m.AUTO_ID == id);
        //    if (mY_PROFILE == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(mY_PROFILE);
        //}

        //[Authorize]
        // GET: MY_PROFILE/Create
        //public IActionResult Create()
        //{
        //    return View();
        //}

        // POST: MY_PROFILE/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[Authorize]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("AUTO_ID,MY_NAME,DESIGNATION,AGE,MY_WEBSITE,DEGREE,PHONE,EMAIL,CURRENT_CITY,HOMETOWN,PROFILE_IMAGE,DES_1,DES_2,DES_3,DATE_OF_BIRTH")] MY_PROFILE mY_PROFILE)
        //{
        //    try
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            var imgFile = Request.Form.Files.FirstOrDefault();
        //            if (imgFile != null)
        //            {
        //                mY_PROFILE.PROFILE_IMAGE = Utility.Getimage(mY_PROFILE.PROFILE_IMAGE, Request.Form.Files);
        //            }
        //            _context.Add(mY_PROFILE);
        //            await _context.SaveChangesAsync();
        //            return RedirectToAction(nameof(Index));
        //        }
        //    }
        //    catch
        //    {
        //        //DO SOMTHING
        //    }
        //    return View(mY_PROFILE);
        //}

        // GET: MY_PROFILE/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.MY_PROFILE == null)
            {
                return NotFound();
            }

            var mY_PROFILE = await _context.MY_PROFILE.FindAsync(id);
            if (mY_PROFILE == null)
            {
                return NotFound();
            }
            return View(mY_PROFILE);
        }

        // POST: MY_PROFILE/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AUTO_ID,MY_NAME,DESIGNATION,AGE,MY_WEBSITE,DEGREE,PHONE,EMAIL,CURRENT_CITY,HOMETOWN,PROFILE_IMAGE,DES_1,DES_2,DES_3,DATE_OF_BIRTH")] MY_PROFILE mY_PROFILE)
        {
            if (id != mY_PROFILE.AUTO_ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var img_file = Request.Form.Files.FirstOrDefault();
                    if (img_file != null)
                    {
                        mY_PROFILE.PROFILE_IMAGE = Utility.Getimage(mY_PROFILE.PROFILE_IMAGE, Request.Form.Files);
                    }
                    _context.Update(mY_PROFILE);
                    await _context.SaveChangesAsync();
                    _cache.Remove(Constant.myProfile);

                    //HttpContext.Session.Remove(Constant.myProfile);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MY_PROFILEExists(mY_PROFILE.AUTO_ID))
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
            return View(mY_PROFILE);
        }

        // GET: MY_PROFILE/Delete/5
        //[Authorize]
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null || _context.MY_PROFILE == null)
        //    {
        //        return NotFound();
        //    }

        //    var mY_PROFILE = await _context.MY_PROFILE
        //        .FirstOrDefaultAsync(m => m.AUTO_ID == id);
        //    if (mY_PROFILE == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(mY_PROFILE);
        //}

        // POST: MY_PROFILE/Delete/5
        [HttpPost, ActionName("Delete")]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.MY_PROFILE == null)
            {
                return Problem("Entity set 'ApplicationDbContext.MY_PROFILE'  is null.");
            }
            var mY_PROFILE = await _context.MY_PROFILE.FindAsync(id);
            if (mY_PROFILE != null)
            {
                _context.MY_PROFILE.Remove(mY_PROFILE);
            }
            
            await _context.SaveChangesAsync();

            _cache.Remove(Constant.myProfile);

            //HttpContext.Session.Remove(Constant.myProfile);
            return RedirectToAction(nameof(Index));
        }

        private bool MY_PROFILEExists(int id)
        {
          return (_context.MY_PROFILE?.Any(e => e.AUTO_ID == id)).GetValueOrDefault();
        }
    }
}
