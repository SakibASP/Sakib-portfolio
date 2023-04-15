using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using SAKIB_PORTFOLIO.Data;
using SAKIB_PORTFOLIO.Helper;
using SAKIB_PORTFOLIO.Models;
using System.Reflection.Metadata;
using System.Security.Claims;

namespace SAKIB_PORTFOLIO.Common
{
    public abstract class BaseController<T> : Controller where T : BaseController<T>
    {
        //private ILogger<T>? _logger;
        //protected ILogger<T>? Logger => _logger ?? (_logger = HttpContext.RequestServices.GetService<ILogger<T>>());
        ////private IDistributedCache _Cache;
        ////protected IDistributedCache? cache => _Cache ?? throw new ArgumentNullException(nameof(_Cache));


        public string? CurrentUserId { get; set; }
        public string? CurrentUserName { get; set; }
        public List<MY_PROFILE>? S_MY_PROFILE { get; set; }
        public List<PROFILE_COVER>? S_PROFILE_COVER { get; set; }
        public List<PROJECTS>? S_PROJECTS { get; set; }
        public List<EDUCATION>? S_EDUCATION { get; set; }
        public List<EXPERIENCE>? S_EXPERIENCE { get; set; }
        public List<CONTACTS>? S_CONTACTS { get; set; }
        public List<MY_SKILLS>? S_MY_SKILLS { get; set; }

        private ApplicationDbContext _context = new();

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
            if (filterContext.HttpContext.User.Identity.IsAuthenticated)
            {
                CurrentUserName = filterContext.HttpContext.User.Identity.Name;
                CurrentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            }

            //Populating the sessions
            var sessionProfife = HttpContext.Session.GetObjectFromJsonList<MY_PROFILE>(Constant.myProfile);
            if (sessionProfife != null)
            {
                S_MY_PROFILE = (List<MY_PROFILE>)sessionProfife;
            }
            else
            {
                S_MY_PROFILE = _context.MY_PROFILE.ToList();
                HttpContext.Session.SetObjectAsJson<MY_PROFILE>(Constant.myProfile, S_MY_PROFILE);
            }

            var sessionProfifeCover = HttpContext.Session.GetObjectFromJsonList<PROFILE_COVER>(Constant.myProfileCover);
            if (sessionProfifeCover != null)
            {
                S_PROFILE_COVER = (List<PROFILE_COVER>)sessionProfifeCover;
            }
            else
            {
                S_PROFILE_COVER = _context.PROFILE_COVER.ToList();
                HttpContext.Session.SetObjectAsJson<MY_PROFILE>(Constant.myProfileCover, S_PROFILE_COVER);
            }
            
            var sessionProject = HttpContext.Session.GetObjectFromJsonList<PROJECTS>(Constant.myProject);
            if (sessionProject != null)
            {
                S_PROJECTS = (List<PROJECTS>)sessionProject;
            }
            else
            {
                S_PROJECTS = _context.PROJECTS.ToList();
                HttpContext.Session.SetObjectAsJson<MY_PROFILE>(Constant.myProject, S_PROJECTS);
            }

            var sessionEducation = HttpContext.Session.GetObjectFromJsonList<EDUCATION>(Constant.myEducation);
            if (sessionEducation != null)
            {
                S_EDUCATION = (List<EDUCATION>)sessionEducation;
            }
            else
            {
                S_EDUCATION = _context.EDUCATION.ToList();
                HttpContext.Session.SetObjectAsJson<MY_PROFILE>(Constant.myEducation, S_EDUCATION);
            }

            var sessionExperience = HttpContext.Session.GetObjectFromJsonList<EXPERIENCE>(Constant.myExperience);
            if (sessionExperience != null)
            {
                S_EXPERIENCE = (List<EXPERIENCE>)sessionExperience;
            }
            else
            {
                S_EXPERIENCE = _context.EXPERIENCE.ToList();
                HttpContext.Session.SetObjectAsJson<MY_PROFILE>(Constant.myExperience, S_EXPERIENCE);
            }
            
            var sessionSkills = HttpContext.Session.GetObjectFromJsonList<MY_SKILLS>(Constant.mySkill);
            if (sessionSkills != null)
            {
                S_MY_SKILLS = (List<MY_SKILLS>)sessionSkills;
            }
            else
            {
                S_MY_SKILLS = _context.MY_SKILLS.ToList();
                HttpContext.Session.SetObjectAsJson<MY_SKILLS>(Constant.mySkill, S_MY_SKILLS);
            }
            
            var sessionContacts = HttpContext.Session.GetObjectFromJsonList<CONTACTS>(Constant.myContact);
            if (sessionContacts != null)
            {
                S_CONTACTS = (List<CONTACTS>)sessionContacts;
            }
            else
            {
                S_CONTACTS = _context.CONTACTS.ToList();
                HttpContext.Session.SetObjectAsJson<MY_SKILLS>(Constant.myContact, S_CONTACTS);
            }
        }
    }
}
