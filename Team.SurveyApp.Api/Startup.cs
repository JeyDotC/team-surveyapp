using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Team.SurveyApp.Dapper;
using Team.SurveyApp.Repositories;
using Microsoft.OpenApi.Models;
using Team.SurveyApp.Services;

namespace Team.SurveyApp.Api
{
    public class Startup
    {
        private string _connectionString;

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            _connectionString = Configuration["ConnectionString"];
            services.AddControllers();
            // Repositories
            services.AddSingleton<IDbConnection>(ctx => new SqlConnection(_connectionString))
                .AddTransient<ISurveysRepository, SurveysRepositoryDapper>()
                .AddTransient<IQuestionsRepository, QuestionsRepositoryDapper>()
                .AddTransient<IRespondentsRepository, RespondentsRepositoryDapper>();
            // Hashing service
            services.AddTransient<IHashingService, DefaultHashingService>();

            services.AddSwaggerGen(c => c.SwaggerDoc("v1", new OpenApiInfo { Title = "Team.SurveyApp API Docs", Version="v1" }));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
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

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "eam.SurveyApp API Docs v1");
            });
        }
    }
}
