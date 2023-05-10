using CoreDemo.Data;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDemo
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
			services.AddDbContext<ApplicationDbContext>(options =>
				options.UseSqlServer(
					Configuration.GetConnectionString("DefaultConnection")));
			services.AddDatabaseDeveloperPageExceptionFilter();

			services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
				.AddEntityFrameworkStores<ApplicationDbContext>();
			services.AddControllersWithViews();

			//services.AddSession();
			
			//Proje seviyesinde authorize

			services.AddMvc(config=>
			{
				var policy = new AuthorizationPolicyBuilder()		//authanticate i�lemini zorunlu k�lan metod
							.RequireAuthenticatedUser()				//kullan�c�n�n sisteme login olmas�
							.Build();
				config.Filters.Add(new AuthorizeFilter(policy));		//policy'den gelen de�eri filtrele
			});

			//returnUrl sayfa dizini
			services.AddMvc();
			services.AddAuthentication(
				CookieAuthenticationDefaults.AuthenticationScheme
				).AddCookie(x =>
				{
					x.LoginPath = "/Login/Index/";
				});
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
				app.UseMigrationsEndPoint();
			}
			else
			{
				app.UseExceptionHandler("/Home/Error");
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				app.UseHsts();
			}

			app.UseStatusCodePagesWithReExecute("/ErrorPage/Error1/", "?code={0}");		//hata k�sm�nda hangi sayfaya y�nlendirecek, query almas� gerekiyor(sorgu)-sorgu k�sm�nda htk almas� gerekiyorhata kodu i�in kod de�eri-null'da d�nebilir

			app.UseHttpsRedirection();
			app.UseStaticFiles();

			app.UseAuthentication();

			//app.UseSession();

			app.UseRouting();

			app.UseAuthentication();
			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllerRoute(
					name: "default",
					pattern: "{controller=Home}/{action=Index}/{id?}");
				endpoints.MapRazorPages();
			});
		}
	}
}
