using AliceDriveData.Implementation;
using AliceDriveData.Interfaces;
using AliceDriveEntity;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AliceDriveApi
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
            services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));
            services.AddCors(options =>
            {
                options.AddPolicy("AllowSpecificOrigin", builder => builder.AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin());
            });
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "AliceDriveApi", Version = "v1" });
            });
            services.Configure<IISServerOptions>(options =>
            {

                options.MaxRequestBodySize = 4000000000;
            });
            services.AddTransient<IDapper, AliceDriveData.Implementation.Dapper>();
            services.AddTransient<IFilesConsummer, FilesConsummer>();
            services.AddTransient<IPostConsummer, PostConsummer>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "AliceDriveApi v1"));
            }
            app.UseDeveloperExceptionPage();
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();
            app.UseCors("AllowSpecificOrigin");
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
