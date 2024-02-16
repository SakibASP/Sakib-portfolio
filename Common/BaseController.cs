using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Caching.Memory;
using SAKIB_PORTFOLIO.Data;
using System.Security.Claims;

namespace SAKIB_PORTFOLIO.Common
{
    public class BaseController(IMemoryCache cache) : Controller 
    {
        //private ILogger<T>? _logger;
        //protected ILogger<T>? Logger => _logger ?? (_logger = HttpContext.RequestServices.GetService<ILogger<T>>());
        ////private IDistributedCache _Cache;
        ////protected IDistributedCache? cache => _Cache ?? throw new ArgumentNullException(nameof(_Cache));

        protected readonly IMemoryCache _cache = cache;

        public string? CurrentUserId { get; set; }
        public string? CurrentUserName { get; set; }
        //public List<MY_PROFILE>? S_MY_PROFILE { get; set; }
        //public List<PROFILE_COVER>? S_PROFILE_COVER { get; set; }
        //public List<PROJECTS>? S_PROJECTS { get; set; }
        //public List<EDUCATION>? S_EDUCATION { get; set; }
        //public List<EXPERIENCE>? S_EXPERIENCE { get; set; }
        //public List<CONTACTS>? S_CONTACTS { get; set; }
        //public List<MY_SKILLS>? S_MY_SKILLS { get; set; }

        private ApplicationDbContext _context = new();

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
            if (filterContext.HttpContext.User.Identity!.IsAuthenticated)
            {
                CurrentUserName = filterContext.HttpContext.User.Identity.Name;
                CurrentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            }

            //Populating the caches
            //My Profile Part
            //if (!_cache.TryGetValue(Constant.myProfile, out List<MY_PROFILE> _MY_PROFILE))
            //{
            //    // If not found in cache, fetch from the database
            //    _MY_PROFILE = _context.MY_PROFILE.ToList();

            //    if (_MY_PROFILE != null)
            //    {
            //        // Set up cache options
            //        var cacheEntryOptions = new MemoryCacheEntryOptions
            //        {
            //            AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(10),
            //            SlidingExpiration = TimeSpan.FromMinutes(5)
            //        };
            //        // Cache the fetched item
            //        _cache.Set(Constant.myProfile, _MY_PROFILE, cacheEntryOptions);
            //    }
            //}

            ////Cover Part
            //if (!_cache.TryGetValue(Constant.myProfileCover, out List<PROFILE_COVER> _PROFILE_COVER))
            //{
            //    // If not found in cache, fetch from the database
            //    _PROFILE_COVER = _context.PROFILE_COVER.ToList();

            //    if (_PROFILE_COVER != null)
            //    {
            //        // Set up cache options
            //        var cacheEntryOptions = new MemoryCacheEntryOptions
            //        {
            //            AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(10),
            //            SlidingExpiration = TimeSpan.FromMinutes(5)
            //        };
            //        // Cache the fetched item
            //        _cache.Set(Constant.myProfileCover, _PROFILE_COVER, cacheEntryOptions);
            //    }   
            //}

            ////Project Part
            //if (!_cache.TryGetValue(Constant.myProject, out List<PROJECTS> _PROJECTS))
            //{
            //    // If not found in cache, fetch from the database
            //    _PROJECTS = _context.PROJECTS.ToList();

            //    if (_PROJECTS != null)
            //    {
            //        // Set up cache options
            //        var cacheEntryOptions = new MemoryCacheEntryOptions
            //        {
            //            AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(10),
            //            SlidingExpiration = TimeSpan.FromMinutes(5)
            //        };
            //        // Cache the fetched item
            //        _cache.Set(Constant.myProject, _PROJECTS, cacheEntryOptions);
            //    }
            //}

            ////Education Part
            //if (!_cache.TryGetValue(Constant.myEducation, out List<EDUCATION> _EDUCATION))
            //{
            //    // If not found in cache, fetch from the database
            //    _EDUCATION = _context.EDUCATION.ToList();

            //    if (_EDUCATION != null)
            //    {
            //        // Set up cache options
            //        var cacheEntryOptions = new MemoryCacheEntryOptions
            //        {
            //            AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(10),
            //            SlidingExpiration = TimeSpan.FromMinutes(5)
            //        };
            //        // Cache the fetched item
            //        _cache.Set(Constant.myEducation, _EDUCATION, cacheEntryOptions);
            //    }
            //}

            ////Experience Part
            //if (!_cache.TryGetValue(Constant.myExperience, out List<EXPERIENCE> _EXPERIENCE))
            //{
            //    // If not found in cache, fetch from the database
            //    _EXPERIENCE = _context.EXPERIENCE.ToList();

            //    if (_EXPERIENCE != null)
            //    {
            //        // Set up cache options
            //        var cacheEntryOptions = new MemoryCacheEntryOptions
            //        {
            //            AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(10),
            //            SlidingExpiration = TimeSpan.FromMinutes(5)
            //        };
            //        // Cache the fetched item
            //        _cache.Set(Constant.myExperience, _EXPERIENCE, cacheEntryOptions);
            //    }
            //}

            ////Skill part
            //if (!_cache.TryGetValue(Constant.mySkill, out List<MY_SKILLS> _MY_SKILLS))
            //{
            //    // If not found in cache, fetch from the database
            //    _MY_SKILLS = _context.MY_SKILLS.ToList();

            //    if (_MY_SKILLS != null)
            //    {
            //        // Set up cache options
            //        var cacheEntryOptions = new MemoryCacheEntryOptions
            //        {
            //            AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(10),
            //            SlidingExpiration = TimeSpan.FromMinutes(5)
            //        };
            //        // Cache the fetched item
            //        _cache.Set(Constant.mySkill, _MY_SKILLS, cacheEntryOptions);
            //    }
            //}

            ////Contact part
            //if (!_cache.TryGetValue(Constant.myContact, out List<CONTACTS> _CONTACTS))
            //{
            //    // If not found in cache, fetch from the database
            //    _CONTACTS = _context.CONTACTS.ToList();

            //    if (_MY_SKILLS != null)
            //    {
            //        // Set up cache options
            //        var cacheEntryOptions = new MemoryCacheEntryOptions
            //        {
            //            AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(10),
            //            SlidingExpiration = TimeSpan.FromMinutes(5)
            //        };
            //        // Cache the fetched item
            //        _cache.Set(Constant.myContact, _CONTACTS, cacheEntryOptions);
            //    }

            //}

            ////Putting caches in global variables
            //S_MY_PROFILE = _MY_PROFILE;
            //S_PROFILE_COVER = _PROFILE_COVER;
            //S_PROJECTS = _PROJECTS;
            //S_EDUCATION = _EDUCATION;
            //S_EXPERIENCE = _EXPERIENCE;
            //S_MY_SKILLS = _MY_SKILLS;
            //S_CONTACTS = _CONTACTS;

            //Other way of setting cache
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

            ////Populating the sessions
            //var sessionProfife = HttpContext.Session.GetObjectFromJsonList<MY_PROFILE>(Constant.myProfile);
            //if (sessionProfife != null)
            //{
            //    S_MY_PROFILE = (List<MY_PROFILE>)sessionProfife;
            //}
            //else
            //{
            //    S_MY_PROFILE = _context.MY_PROFILE.ToList();
            //    HttpContext.Session.SetObjectAsJson<MY_PROFILE>(Constant.myProfile, S_MY_PROFILE);
            //}

            //var sessionProfifeCover = HttpContext.Session.GetObjectFromJsonList<PROFILE_COVER>(Constant.myProfileCover);
            //if (sessionProfifeCover != null)
            //{
            //    S_PROFILE_COVER = (List<PROFILE_COVER>)sessionProfifeCover;
            //}
            //else
            //{
            //    S_PROFILE_COVER = _context.PROFILE_COVER.ToList();
            //    HttpContext.Session.SetObjectAsJson<MY_PROFILE>(Constant.myProfileCover, S_PROFILE_COVER);
            //}

            //var sessionProject = HttpContext.Session.GetObjectFromJsonList<PROJECTS>(Constant.myProject);
            //if (sessionProject != null)
            //{
            //    S_PROJECTS = (List<PROJECTS>)sessionProject;
            //}
            //else
            //{
            //    S_PROJECTS = _context.PROJECTS.ToList();
            //    HttpContext.Session.SetObjectAsJson<MY_PROFILE>(Constant.myProject, S_PROJECTS);
            //}

            //var sessionEducation = HttpContext.Session.GetObjectFromJsonList<EDUCATION>(Constant.myEducation);
            //if (sessionEducation != null)
            //{
            //    S_EDUCATION = (List<EDUCATION>)sessionEducation;
            //}
            //else
            //{
            //    S_EDUCATION = _context.EDUCATION.ToList();
            //    HttpContext.Session.SetObjectAsJson<MY_PROFILE>(Constant.myEducation, S_EDUCATION);
            //}

            //var sessionExperience = HttpContext.Session.GetObjectFromJsonList<EXPERIENCE>(Constant.myExperience);
            //if (sessionExperience != null)
            //{
            //    S_EXPERIENCE = (List<EXPERIENCE>)sessionExperience;
            //}
            //else
            //{
            //    S_EXPERIENCE = _context.EXPERIENCE.ToList();
            //    HttpContext.Session.SetObjectAsJson<MY_PROFILE>(Constant.myExperience, S_EXPERIENCE);
            //}

            //var sessionSkills = HttpContext.Session.GetObjectFromJsonList<MY_SKILLS>(Constant.mySkill);
            //if (sessionSkills != null)
            //{
            //    S_MY_SKILLS = (List<MY_SKILLS>)sessionSkills;
            //}
            //else
            //{
            //    S_MY_SKILLS = _context.MY_SKILLS.ToList();
            //    HttpContext.Session.SetObjectAsJson<MY_SKILLS>(Constant.mySkill, S_MY_SKILLS);
            //}

            //var sessionContacts = HttpContext.Session.GetObjectFromJsonList<CONTACTS>(Constant.myContact);
            //if (sessionContacts != null)
            //{
            //    S_CONTACTS = (List<CONTACTS>)sessionContacts;
            //}
            //else
            //{
            //    S_CONTACTS = _context.CONTACTS.ToList();
            //    HttpContext.Session.SetObjectAsJson<MY_SKILLS>(Constant.myContact, S_CONTACTS);
            //}
        }
    }
}
