using Microsoft.EntityFrameworkCore;
using ProductCRUD_RepoPattern.DB;
using ProductCRUD_RepoPattern.Repository.CategoryRepository;
using ProductCRUD_RepoPattern.Repository.ProductRepository;

namespace ProuctCRUD_RepoPattern
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddMvc();
            builder.Services.AddScoped<IProductRepository, ProductRepository>();
            builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
            builder.Services.AddControllers();
            builder.Services.AddAutoMapper(typeof(Program));

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<AppDBContext>(opt =>
            {
                opt.UseSqlServer(builder.Configuration.GetConnectionString("MyDb"));
                opt.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
                opt.EnableSensitiveDataLogging();
            });

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