namespace Shoes_Ecommerce.Data
{
    public class Context : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ProductColor> productColor { get; set; }
        public DbSet<ProductImage> productImage { get; set; }
        public DbSet<ProductSize> productSize { get; set; }
        public DbSet<ProductVariant> productVariant { get; set; }

        public Context(DbContextOptions<Context> options) : base(options){}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(Context).Assembly);
        }
    }
}
