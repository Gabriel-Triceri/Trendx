using Microsoft.EntityFrameworkCore;
using Lista_de_Tarefas.Persistence;
using Microsoft.OpenApi.Models;
using System.Reflection;

namespace Lista_de_Tarefas
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllersWithViews();

            var sqlServerConnectionString = builder.Configuration.GetConnectionString("SqlServerConnection");
            builder.Services.AddDbContext<DbContextSqlServer>(options =>
                options.UseSqlServer(sqlServerConnectionString));

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(c =>
                   {
                       c.SwaggerDoc("v1", new OpenApiInfo { Title = "SeuProjeto API", Version = "v1" });

                       var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                       var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                       c.IncludeXmlComments(xmlPath);
                   });
        

            var app = builder.Build();

            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                c.RoutePrefix = string.Empty; // Set Swagger UI at app's root
            });

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
