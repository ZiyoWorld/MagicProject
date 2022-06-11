using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;


namespace MagicProject.Models
{
    public class AppMagicInit:DropCreateDatabaseIfModelChanges<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
            var userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(context));
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            var r_administrator = new IdentityRole { Name = "Administrator" };
            var r_employer = new IdentityRole { Name = "Employer" };
            var r_guest = new IdentityRole { Name = "Guest" };

            var mir_uz = new ApplicationUser { Email = "mirziyod@gmail.com", UserName = "mirziyod@gmail.com" };
            var ziyo_uz = new ApplicationUser { Email = "emp@belstu.by", UserName = "emp@belstu.by" };

            var b_administrator = roleManager.Create(r_administrator).Succeeded;
            var b_employer = roleManager.Create(r_employer).Succeeded;


            var b_mir = userManager.Create(mir_uz, "12345678").Succeeded;
            var b_ziyo = userManager.Create(ziyo_uz, "12345678").Succeeded;


            if (b_administrator && b_mir) userManager.AddToRole(mir_uz.Id, r_administrator.Name);
            // if (b_employer && b_mir) userManager.AddToRole(mir_uz.Id, r_employer.Name);
            if (b_employer && b_ziyo) userManager.AddToRole(ziyo_uz.Id, r_employer.Name);
            base.Seed(context);
        }
    }
}