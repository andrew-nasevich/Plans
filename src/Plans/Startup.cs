using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Plans.DB;
using Plans.DB.Converters;
using Plans.DB.DBManagers;
using Plans.DomainModel.Interfaces;
using Plans.DomainModel.Plans;
using Plans.DomainModel.Users;
using System;
using System.Collections.Generic;

namespace Plans
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    var context1 = new DBContext();
                    var converter = new DatetimeConverter();
                    var manager = new PlanDBManager(context1, converter);
                    var user = new User() { Id = 3 };
                    var daysInterval = new DaysInterval
                    {
                        DaysGap = 1,
                        FinishDay = DateTime.Now,
                        IncludeHolidays = true,
                        IsRepeated = true,
                        StartDay = DateTime.Now,
                        StartOverEveryWeak = true,
                        FinishDayOfRepetition = DateTime.Now
                    };
                    var plan = new Plan
                    {
                        CreatingTime = DateTime.Now,
                        FinishingTime = DateTime.Now,
                        Name = "abc",
                        Percentage = 10,
                        User = user,
                        DaysIntervals = new List<DaysInterval> { daysInterval }
                    };

                    manager.CreatePlan(plan, 3);

                    var result = converter.ConvertToDateTime("2000-07-17 23:14:10");
                    var daytime = converter.ConvertToString(result);

                    var a = new Class1();
                    a.connect();
                    await context.Response.WriteAsync("Hello World!");
                });
            });
        }
    }
}
