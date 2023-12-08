using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using SAKIB_PORTFOLIO.Common;
using SAKIB_PORTFOLIO.Data;
using SAKIB_PORTFOLIO.Models;
using System.Diagnostics;

namespace SAKIB_PORTFOLIO.Controllers
{
    public class HomeController : BaseController
    {
        //private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;
        private readonly IMemoryCache _memoryCache;

        public HomeController(ApplicationDbContext context, IMemoryCache memoryCache):base(memoryCache)
        {
            //_logger = logger;
            _context = context;
            _memoryCache = memoryCache;
        }

        public async Task<IActionResult> Index()
        {
            if (User.Identity!.IsAuthenticated)
            {
                //if (S_CONTACTS is not null)
                //    myMessage = S_CONTACTS!.Where(x => x.IsConfirmed == null).ToList();
                //else
                var myMessage = await _context.CONTACTS.Where(x => x.IsConfirmed == null).ToListAsync();
                TempData["Message"] = myMessage == null ? "" : myMessage.Count.ToString();
            }

            //if (S_PROFILE_COVER is not null)
            //    Cover = S_PROFILE_COVER!.FirstOrDefault();
            //else
            var cover = await _context.PROFILE_COVER.FirstOrDefaultAsync();

            ViewBag.Name = "Md. Sakibur Rahman";
            ViewBag.Bio = "I am a professiona Software Developer from Khulna, Bangladesh";
            ViewBag.Cover = cover;
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }   

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}