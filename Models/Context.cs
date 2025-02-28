using Microsoft.EntityFrameworkCore;

namespace Shoes_Ecommerce.Models
{
    public class Context : IdentityDbContext<ApplicationUser>
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {
                
        }
    }
}
