using AutoRegisterServices.Data;

using GraphiQl;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;

namespace AutoRegisterServices.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        public static void UsePublic(this IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseCors("CorsPolicy");

            app.UseRouting(routes =>
            {
                routes.MapApplication();
            });

            app.UseCookiePolicy();
        }

        public static void UsePrivate(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUi3();

            app.UseGraphiQl();

            //app.UseGraphQl("/graph-api", options =>
            //{
            //    //options.SchemaName = "SinjulMSBH";
            //    //options.AuthorizationPolicy = "Authenticated";
            //});

            app.EnsureSeedData();
        }
    }
}
