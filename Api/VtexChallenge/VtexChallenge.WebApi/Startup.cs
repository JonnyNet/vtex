using FluentValidation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using VtexChallenge.Entities.Exceptions;
using VtexChallenge.IoC;
using VtexChallenge.WebExceptionPresenter;

namespace VtexChallenge.WebApi
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
			services.AddSwaggerGen(c =>
			{
				c.SwaggerDoc("v1", new OpenApiInfo { Title = "VtexChallenge.WebApi", Version = "v1" });
			});

			services.AddVtexChallengeDependencies(
				Configuration,
				"VtexChallenge");

			services.AddControllers(option => option.Filters.Add(new ExceptionHandlingAttribute(
				new Dictionary<Type, IExceptionHandler>
				{
					{ typeof(GeneralException), new GeneralExceptionHandler() },
					{ typeof(ValidationException), new ValidationExceptionHandler() },
					{ typeof(RecordNotFoudException), new RecordNotFoudExceptionHandler() }
				})));

			services.AddCors(options =>
			{
				options.AddDefaultPolicy(
				builder =>
				{
					builder.WithOrigins("http://localhost:4200")
					.AllowAnyHeader()
					.WithMethods(new string[] { "POST", "GET", "PATCH" })
					.AllowCredentials();
				});
			});
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			app.RunMigrations();

			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
				app.UseSwagger();
				app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "VtexChallenge.WebApi v1"));
			}

			app.UseCors(options =>
				options.WithOrigins("http://localhost:4200")
				.WithMethods(new string[] { "POST", "GET", "PATCH" })
				.AllowAnyHeader()
				.AllowCredentials());

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
