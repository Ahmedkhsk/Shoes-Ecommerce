using Microsoft.Extensions.Options;

namespace Shoes_Ecommerce
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

            builder.Services.AddDbContext<Context>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DB"));
            });
            builder.Services.AddIdentity<ApplicationUser, IdentityRole>(
                options => 
                {
                    options.Password.RequireNonAlphanumeric = false; 
                    options.Password.RequireDigit = true;            
                    options.Password.RequireLowercase = true;        
                    options.Password.RequireUppercase = true;        
                    options.Password.RequiredLength = 6;

                }                
                ).AddEntityFrameworkStores<Context>();
            
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
