using System;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Tracker.AutoMapperProfiles;
using Tracker.Interfaces;
using Tracker.Logic;
using Tracker.WebApi.Models.AutoMapperProfiles;

namespace Tracker.WebApi
{
	public class Startup
	{
		private IConfiguration Configuration { get; }

		public Startup(IConfiguration configuration) =>
				Configuration = configuration;
		
		public void ConfigureServices(IServiceCollection services)
		{
			//services.AddSwaggerGen();
			
			var mapperConfig = new MapperConfiguration(mc =>
			{
				mc.AddProfile(new ProjectProfile());
				mc.AddProfile(new CreateProjectDtoProfile());
				mc.AddProfile(new UpdateProjectDtoProfile());

				mc.AddProfile(new TaskProfile());
				mc.AddProfile(new CreateTaskDtoProfile());
				mc.AddProfile(new UpdateTaskDtoProfile());
			});
			var mapper = mapperConfig.CreateMapper();
			services.AddSingleton(mapper);
			
			var assembly = AppDomain.CurrentDomain.Load("Tracker.Dal");
			services.AddMediatR(assembly);

			
			var connectionString = Configuration["DbConnection"];
			services.AddDbContext<TrackerDbContext>(options =>
					options.UseSqlite(connectionString));
			services.AddScoped<ITrackerDbContext>(provider =>
					provider.GetService<TrackerDbContext>());
			
			services.AddControllers();
		}

		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			//app.UseSwagger();
			//app.UseSwaggerUI();
			
			app.UseRouting();
			app.UseHttpsRedirection();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
		}
	}
}
