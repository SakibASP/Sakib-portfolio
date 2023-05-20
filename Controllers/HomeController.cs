using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.VisualBasic;
using SAKIB_PORTFOLIO.Common;
using SAKIB_PORTFOLIO.Data;
using SAKIB_PORTFOLIO.Models;
using System.Diagnostics;

namespace SAKIB_PORTFOLIO.Controllers
{
    public class HomeController : BaseController<HomeController>
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;
        private readonly IMemoryCache _memoryCache;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context, IMemoryCache memoryCache)
        {
            _logger = logger;
            _context = context;
            _memoryCache = memoryCache;
        }

        public IActionResult Index()
        {
            //Using Memory Cache
            //List<CONTACTS>? myMessage = _memoryCache.Get<List<CONTACTS>>(Constant.myContact);
            //PROFILE_COVER? Cover = _memoryCache.Get<PROFILE_COVER>(Constant.myProfileCover);

            //if(myMessage == null)
            //{
            //    var contancts = _context.CONTACTS.Where(x => x.IsConfirmed == null).ToList();
            //    _memoryCache.Set(Constant.myContact, contancts);
            //    myMessage = _memoryCache.Get<List<CONTACTS>>(Constant.myContact);
            //}

            //if(Cover == null)
            //{
            //    var myCover = _context.PROFILE_COVER.FirstOrDefault();
            //    _memoryCache.Set(Constant.myProfileCover, myCover);
            //    Cover = _memoryCache.Get<PROFILE_COVER>(Constant.myProfileCover);
            //}

            //Using Sessions
            List<CONTACTS> myMessage = new();
            PROFILE_COVER? Cover = new();
            if (S_CONTACTS is not null)
                myMessage = S_CONTACTS!.Where(x => x.IsConfirmed == null).ToList();
            else
                myMessage = _context.CONTACTS.Where(x => x.IsConfirmed == null).ToList();

            if (S_PROFILE_COVER is not null)
                Cover = S_PROFILE_COVER!.FirstOrDefault();
            else
                Cover = _context.PROFILE_COVER.FirstOrDefault();

            TempData["Message"] = myMessage == null ? "" : myMessage.Count.ToString();
            ViewBag.Name = "Md. Sakibur Rahman";
            ViewBag.Bio = "I am a professiona Software Developer from Khulna, Bangladesh";
            ViewBag.Cover = Cover;
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