using BusinessLogic.Data;
using BusinessLogic.Logic;
using Core.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebApi.DTOs;
using WebApi.Middlewares;

namespace WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAutoMapper(typeof(MappingProfiles));

            /*se procede a inyectar la interfaz generica, para cuando arranca el 
             app se genera un objeto de esta interfaz, por cada request que envia el cliente */
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            services.AddDbContext<MarketDbContext>(opt =>
            {
                opt.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
            });
            services.AddTransient<IProductoRepository, ProductoRepository>();
            services.AddControllers();

            /*para establecer la configuracion del CORS*/
            services.AddCors(opt =>
            {
                opt.AddPolicy("CorsRule", rule =>
                {
                    /*Se coloca el asterisco para que cualquier ip se conecte, queda
                     disponible de manera publica, pero si se quisiera establecer cuales
                    ip tendrian unicamente acceso, se colocan en vez del asterisco*/
                    rule.AllowAnyHeader().AllowAnyMethod().WithOrigins("*");
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //if (env.IsDevelopment())
            //{
            //    app.UseDeveloperExceptionPage();
            //}

            app.UseMiddleware<ExceptionMiddleware>(); /*agregar esta linea con el middleware personalizado para 
                                                       mostrar errores en vez de la pagina de la linea de arriba que esta comentada*/

            app.UseStatusCodePagesWithReExecute("/errors", "?code={0}");

            app.UseRouting();

            /*agregar el Cors*/
            app.UseCors("CorsRule");

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
