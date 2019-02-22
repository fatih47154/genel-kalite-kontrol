using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KaliteGiris.Web.Filter
{
    public class Authorize : AuthorizeAttribute
    {
        //Entities context = new Entities(); // my entity  
        private readonly List<string> _allowedroles = new List<string>();
        public Authorize()
        {
            List<string> roles = new List<string>(); // Rolleri oluşturturuyoruz
            roles.Add("Admin");
            roles.Add("TestRolü");

            _allowedroles = roles;
        }
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            bool authorize = false;
            foreach (var role in _allowedroles) // Roller içinde foreach ile dönüyoruz
            {
                if (role == "Admin") // Eğer kullanıcının rolü "AdminTestRol" ise 
                {
                    authorize = true; // Yetkiyi true yapıyoruz ve ActionResult'a erişme hakkı  veriyoruz
                    return authorize;
                }

                //var user = context.AppUser.Where(m => m.UserID == GetUser.CurrentUser/* getting user form current context */ && m.Role == role &&  
                // m.IsActive == true); // checking active users with allowed roles.  
                // if (user.Count() > 0)  
                //{  
                //authorize = true; /* return true if Entity has current user(active) with specific role */
                //}  

            }
            return authorize;
        }
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            filterContext.Result = new HttpUnauthorizedResult();
        }
        //public override void OnAuthorization(AuthorizationContext filterContext)
        //{
        //    if (this.AuthorizeCore(filterContext.HttpContext))
        //    {
        //        // yetkili olduğu sayfada ise herhangi bir değişiklik yapmıyoruz.
        //        // yetkili olduğu sayfaya direkt girebilir sonuçta,başka bir sayfaya yönlendirmeyeceğiz.
        //        base.OnAuthorization(filterContext);
        //    }
        //    else
        //    {
        //        // orada yetkili değilse ya yetkili olduğu sayfaya geri gönderiyoruz
        //        // yada yetkisiz olduğuna dair error page i istemciye gönderiyoruz.
        //        var _urlReferrer = filterContext.HttpContext.Request.UrlReferrer;

        //        if (_urlReferrer != null)
        //        {
        //            string _redirectUrl = "~" + _urlReferrer.LocalPath;
        //            filterContext.Result = new RedirectResult(_redirectUrl);
        //        }
        //        else
        //        {
        //            // direkt url den talebi göndermiş demektir.
        //            filterContext.Result = new RedirectResult("~/WorkFlow/Processor/UnAuthorized");
        //        }
        //    }
        //}
    }
}