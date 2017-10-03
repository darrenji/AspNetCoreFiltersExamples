using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using AspNetCoreFiltersExamples.Infrastructure;

namespace AspNetCoreFiltersExamples
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddScoped<IFilterDiagnostics, DefaultFilterDiagnostics>();

            //services.AddSingleton<IFilterDiagnostics, DefaultFilterDiagnostics>();
            //services.AddSingleton<TimeFilter>();

            services.AddScoped<IFilterDiagnostics, DefaultFilterDiagnostics>();//把诊断信息放到字符串集合中
            services.AddScoped<TimeFilter>(); //实现IAsyncResultFilter接口，使用IFilterDiagnostics记录
            services.AddScoped<ViewResultDiagnostics>();//实现IActionFilter接口，使用IFilterDiagnostics记录
            services.AddScoped<DiagnosticsFilter>();//实现IAsyncResultFilter接口，把IFilterDiagnostics的字符串集合响应出去
            services.AddMvc().AddMvcOptions(options => {
                //options.Filters.AddService(typeof(ViewResultDiagnostics));
                //options.Filters.AddService(typeof(DiagnosticsFilter));
                options.Filters.Add(new MessageAttribute("This is the Globally-Scoped Filter"));
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            app.UseStatusCodePages();
            app.UseDeveloperExceptionPage();
            app.UseStaticFiles();
            app.UseMvcWithDefaultRoute();
        }
    }
}
