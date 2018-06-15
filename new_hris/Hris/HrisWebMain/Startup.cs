using System.Text;
using AutoMapper;
using Hris.Common.Api;
using Hris.Common.Business.Repositories;
using Hris.Common.Business.Services.Implementations;
using Hris.Common.Business.Services.Interfaces;
using Hris.Common.Persistence;
using Hris.Database;
using Hris.List.Api;
using Hris.List.Business.Repositories;
using Hris.List.Business.Services.Implementations;
using Hris.List.Business.Services.Interfaces;
using Hris.List.Persistence;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace Hris.Web.Main
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
      #region Common DI

      #region repositories
      services.AddTransient<IUserRepository, UserRepository>();
      #endregion

      #region services
      services.AddTransient<IUserService, UserService>();
      #endregion

      #endregion

      #region List DI

      #region repositories
      services.AddTransient<IGenderRepository, GenderRepository>();
      services.AddTransient<ICountryRepository, CountryRepository>();
      services.AddTransient<IDistrictRepository, DistrictRepository>();
      services.AddTransient<IEducationRepository, EducationRepository>();
      services.AddTransient<INationRepository, NationRepository>();
      services.AddTransient<IProvinceRepository, ProvinceRepository>();
      services.AddTransient<IWardRepository, WardRepository>();
      #endregion

      #region services
      services.AddTransient<IGenderService, GenderService>();
      services.AddTransient<ICountryService, CountryService>();
      services.AddTransient<IDistrictService, DistrictService>();
      services.AddTransient<IEducationService, EducationService>();
      services.AddTransient<INationService, NationService>();
      services.AddTransient<IProvinceService, ProvinceService>();
      services.AddTransient<IWardService, WardService>();
      #endregion

      #endregion

      #region API DI
      services.AddTransient<ICommonApi, CommonApi>();
      services.AddTransient<IListApi, ListApi>();
      #endregion


      services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
        .AddJwtBearer(options =>
        {
          options.TokenValidationParameters = new TokenValidationParameters
          {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = Configuration["Jwt:Issuer"],
            ValidAudience = Configuration["Jwt:Issuer"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]))
          };
        });
      services.AddAutoMapper();
      services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
      services.AddDbContext<HrisContext>(options => options.UseSqlServer(Configuration.GetConnectionString("MySqlConnection")));
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

      app.UseAuthentication();

      app.UseHttpsRedirection();
      app.UseMvc(routes =>
      {
        routes.MapRoute(
          name: "default",
          template: "{controller=Home}/{action=Index}/{id?}");
      });

      app.UseDefaultFiles();
      app.UseStaticFiles();
    }
  }
}
