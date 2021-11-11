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
using HB.RestAPI.Core;
using HB.RestAPI.Core.Models;
using HB.RestAPI.Core.Services;
using Microsoft.Extensions.Options;
using MongoDB.Bson.Serialization;

namespace HB.RestAPI
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
            services.AddCors();

            services.AddSingleton<IDbClient, MongoDbClient>();

            services.Configure<DataBaseSettings>(Configuration);

            services.AddTransient<IDbCollectionServices,DataNodeCollectionServices>();

            BsonClassMap.RegisterClassMap<DataNode>(cm =>
            {
                cm.MapMember(dataNode => dataNode.EntityType);
                cm.MapMember(dataNode => dataNode.RawData);
            });


            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "HB.RestAPI", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // global CORS policy
            app.UseCors(x => x
                             .AllowAnyMethod() // allows all HTTP requests of this API to be consumed by a client.
                             .AllowAnyHeader()
                             .SetIsOriginAllowed(origin => true) // allows any client to make requests to this API
                             .AllowCredentials());

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "HB.RestAPI v1"));
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
