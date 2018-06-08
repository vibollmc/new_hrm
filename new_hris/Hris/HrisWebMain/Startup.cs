using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hris.Database;
using Hris.List.Api;
using Hris.List.Business.Repositories;
using Hris.List.Business.Services.Implementations;
using Hris.List.Business.Services.Interfaces;
using Hris.List.Persistence;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

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
      services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
      services.AddDbContext<HrisContext>(options => options.UseSqlServer(Configuration.GetConnectionString("MySqlConnection")));

      #region List

      #region repositories
      services.AddTransient<IGenderRepository, GenderRepository>();
      #endregion

      #region services
      services.AddTransient<IGenderService, GenderService>();
      #endregion

      #region api
      services.AddTransient<IHrisListApi, HrisListApi>();
      #endregion

      #endregion
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
