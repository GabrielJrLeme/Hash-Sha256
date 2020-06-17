using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using PasswordSha256.Model;
using PasswordSha256.Models;
using PasswordSha256.Services;

namespace PasswordSha256
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
            var cache = new CacheService();

            Database(cache.Cache);

            services.AddSingleton(cache);

            services.AddControllers();
            services.AddScoped<AuthService>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private void Database(ConcurrentDictionary<string, Registros> cache)
        {

            List<Usuario> usuarios = new List<Usuario>()
            {
                new Usuario()
                {
                    Name = "gabriel",
                    SenhaNormal = "1234",
                    Password = "6c19c17e0a3bb5c27cec8c2ea786780feff7d10067250957e696adb5320f5742",
                    Email = "gabriel@email.com"
                },
                new Usuario()
                {
                    Name = "carlos",
                    SenhaNormal = "carlos",
                    Password = "30214bec4b8d5d701bf30efd0f4ca5c3505c847767d9b2f0656ff0f8bd272b5a",
                    Email = "carlos@email.com"
                }
            };

            Registros listaRegistros = new Registros(usuarios) { };

            cache.TryAdd(listaRegistros.Chave, listaRegistros);
        }

    }
}
