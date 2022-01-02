using System;
using System.IO;
using System.Reflection;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Tracker.AutoMapperProfiles;
using Tracker.Interfaces;
using Tracker.Logic;
using Tracker.WebApi.AutoMapperProfilesDto;
using Tracker.WebApi.Extensions;

namespace Tracker.WebApi
{
	public class Startup
	{
		private IConfiguration Configuration { get; }

		public Startup(IConfiguration configuration) =>
				Configuration = configuration;
		
		public void ConfigureServices(IServiceCollection services)
		{
			var mapperConfig = new MapperConfiguration(mc =>
			{
				mc.AddProfile(new ProjectProfile());
				mc.AddProfile(new CreateProjectDtoProfile());
				mc.AddProfile(new UpdateProjectDtoProfile());

				mc.AddProfile(new TaskProfile());
				mc.AddProfile(new CreateTaskDtoProfile());
				mc.AddProfile(new UpdateTaskDtoProfile());
			});
			services.AddSingleton(mapperConfig.CreateMapper());
			
			var assembly = AppDomain.CurrentDomain.Load("Tracker.Dal");
			services.AddMediatR(assembly);

			var connectionString = Configuration["DbConnection"];
			services.AddDbContext<TrackerDbContext>(options =>
					options.UseSqlite(connectionString));
			services.AddScoped<ITrackerDbContext>(provider =>
					provider.GetService<TrackerDbContext>());
			
			services.AddControllers();
			
			services.AddSwaggerGen(config =>
			{
				var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
				var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
				config.IncludeXmlComments(xmlPath);
			});
		}

		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseMyExceptionHandler();
			app.UseSwagger();
			app.UseSwaggerUI(config =>
			{
				config.RoutePrefix = string.Empty;
				config.SwaggerEndpoint("swagger/v1/swagger.json", "Tracker API");
			});

			app.UseRouting();
			app.UseHttpsRedirection();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
		}
	}
}
