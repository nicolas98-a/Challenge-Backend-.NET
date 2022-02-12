using Challenge.Backend.AccessData;
using Challenge.Backend.AccessData.Commands;
using Challenge.Backend.AccessData.Queries;
using Challenge.Backend.Application.Filters;
using Challenge.Backend.Application.Services;
using Challenge.Backend.Domain.ICommands;
using Challenge.Backend.Domain.IQueries;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using SqlKata.Compilers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Challenge.Backend.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            var connectionstring = Configuration.GetSection("ConnectionString").Value;
            //EF Core
            services.AddDbContext<DisneyDbContext>(options => options.UseSqlServer(connectionstring));

            // SQLKata
            services.AddTransient<Compiler, SqlServerCompiler>();
            services.AddTransient<IDbConnection>(b =>
            {
                return new SqlConnection(connectionstring);
            });

            services.AddTransient<IGenericsRepository, GenericRepository>();
            services.AddTransient<ICharacterService, CharacterService>();
            services.AddTransient<IMovieOrSerieService, MovieOrSerieService>();
            services.AddTransient<ICharacterQuery, CharacterQuery>();
            services.AddTransient<IMovieOrSerieQuery, MovieOrSerieQuery>();

            // Fluent Validation
            services.AddMvc(options =>
            {
                options.Filters.Add<ValidationFilter>();
            }).AddFluentValidation(options =>
            {
                options.RegisterValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo 
                { 
                    Title = "Challenge.Backend.API", 
                    Version = "v1",
                    Description = "REST API  para explorar el mundo de Disney",
                    Contact = new OpenApiContact()
                    {
                        Name = "Nicolas Acu�a",
                        Email = "acu.nicolas.1998@gmail.com"
                    }
                });
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Challenge.Backend.API v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
