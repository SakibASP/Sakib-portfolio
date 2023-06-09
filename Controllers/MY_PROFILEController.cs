﻿using System;
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
    public class MY_PROFILEController : BaseController<MY_PROFILEController>
    {
        private readonly ApplicationDbContext _context;
        private MY_PROFILE? pROFILE;
        private List<MY_SKILLS>? sKILL;
        private List<EDUCATION>? eDUCATION;
        private List<EXPERIENCE>? eXPERIENCE;
        private List<PROJECTS>? pROJECT;


        public MY_PROFILEController(ApplicationDbContext context)
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

        public IActionResult About()
        {
            if(S_MY_PROFILE.Any())
                pROFILE = S_MY_PROFILE.FirstOrDefault();
            else
                pROFILE = _context.MY_PROFILE.FirstOrDefault();

            if(S_MY_SKILLS.Any())
                sKILL = S_MY_SKILLS.ToList();
            else
                sKILL = S_MY_SKILLS.ToList();

            ViewData["SKILLS"] = sKILL;
            ViewData["PROFILES"] = pROFILE;
            return View();
        }

        public IActionResult Resume()
        {
            if (S_MY_PROFILE.Any())
                pROFILE = S_MY_PROFILE.FirstOrDefault();
            else
                pROFILE = _context.MY_PROFILE.FirstOrDefault();

            if (S_EDUCATION.Any())
                eDUCATION = S_EDUCATION.ToList();
            else
                eDUCATION = _context.EDUCATION.ToList();

            if (S_EXPERIENCE.Any())
                eXPERIENCE = S_EXPERIENCE.ToList();
            else
                eXPERIENCE = _context.EXPERIENCE.ToList();

            ViewData["PROFILES"] = pROFILE;
            ViewData["EDUCATIONS"] = eDUCATION;
            ViewData["EXPERIENCEs"] = eXPERIENCE;
            return View();
        }

        public IActionResult Projects()
        {
            if (S_MY_PROFILE.Any())
                pROFILE = S_MY_PROFILE.FirstOrDefault();
            else
                pROFILE = _context.MY_PROFILE.FirstOrDefault();

            if (S_PROJECTS.Any())
                pROJECT = S_PROJECTS.ToList();
            else
                pROJECT = _context.PROJECTS.ToList();

            ViewData["PROFILES"] = pROFILE;
            ViewData["PROJECTS"] = pROJECT.Count > 0 ? pROJECT : null;
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

        public IActionResult Contact()
        {
            if (S_MY_PROFILE.Any())
                pROFILE = S_MY_PROFILE.FirstOrDefault();
            else
                pROFILE = _context.MY_PROFILE.FirstOrDefault();

            ViewData["PROFILES"] = pROFILE;
            return View();
        }

        [HttpPost]
        public JsonResult Contact(CONTACTS objContact)
        {
            try
            {
                _context.CONTACTS.Add(objContact);
                _context.SaveChanges();
                HttpContext.Session.Remove(Constant.myContact);

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
                    HttpContext.Session.Remove(Constant.myProfile);
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
            HttpContext.Session.Remove(Constant.myProfile);
            return RedirectToAction(nameof(Index));
        }

        private bool MY_PROFILEExists(int id)
        {
          return (_context.MY_PROFILE?.Any(e => e.AUTO_ID == id)).GetValueOrDefault();
        }
    }
}
