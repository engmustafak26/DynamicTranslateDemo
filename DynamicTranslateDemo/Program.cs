using DynamicTranslate;
using DynamicTranslateDemo.DB;
using DynamicTranslateDemo.Filters;
using Microsoft.EntityFrameworkCore;

namespace DynamicTranslateDemo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            builder.Services.AddControllers(options => options.Filters.Add<TranslationResultFilter>());
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<DummyDBContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DBConnection"));

            });

            builder.Services.AddDynamicTranslate(typeof(DummyDBContext));

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
