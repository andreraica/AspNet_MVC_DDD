using Budget.Infrastructure.CrossCutting.Identity.Model;
using Microsoft.AspNet.Identity.EntityFramework;
using System;

namespace Budget.Infrastructure.CrossCutting.Identity.Context
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>, IDisposable
    {
        public ApplicationDbContext()
            : base("BudgetConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}
