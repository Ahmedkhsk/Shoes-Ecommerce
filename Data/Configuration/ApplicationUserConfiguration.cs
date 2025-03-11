namespace Shoes_Ecommerce.Data.Configuration
{
    public class ApplicationUserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.HasIndex(u => u.Email)
                  .IsUnique()
                  .HasDatabaseName("IX_ApplicationUser_Email");
        }
    }
}
