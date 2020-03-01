using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLogic.Models;
using BusinessLogic.Repositories.DtoConverters;
using BusinessLogic.Repositories.Implementations;
using BusinessLogic.Repositories.Interfaces;
using Database;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace BusinessLogic
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddScoped<IConverter<Employee, Database.Models.Employee>>(options =>
                new EmployeeConverter());

            services.AddScoped<IConverter<ExtraInformation, Database.Models.ExtraInformation>>(options =>
             new ExtraInformationConverter());

            services.AddScoped<IConverter<Topic, Database.Models.Topic>>(options =>
                new TopicConverter(options.GetRequiredService<IConverter<ExtraInformation, Database.Models.ExtraInformation>>()));

            services.AddScoped<IConverter<LearningDay, Database.Models.LearningDay>>(options =>
                new LearningDayConverter(
                    options.GetRequiredService<IConverter<Employee, Database.Models.Employee>>(),
                    options.GetRequiredService<IConverter<Topic, Database.Models.Topic>>()));

            services.AddScoped<IRepository<LearningDay>>(options =>
                new LearningDayRepository(
                    options.GetRequiredService<DatabaseContext>(),
                    options.GetRequiredService<IConverter<LearningDay, Database.Models.LearningDay>>()));

            services.AddDbContext<DatabaseContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("Database")));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}