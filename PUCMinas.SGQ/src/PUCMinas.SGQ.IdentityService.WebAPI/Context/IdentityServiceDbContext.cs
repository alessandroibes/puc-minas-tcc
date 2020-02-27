using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace PUCMinas.SGQ.IdentityService.WebAPI.Context
{
    public class IdentityServiceDbContext : IdentityDbContext
    {
        public IdentityServiceDbContext(DbContextOptions<IdentityServiceDbContext> options) : base(options)
        { }
    }
}
