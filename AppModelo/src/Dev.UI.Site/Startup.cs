using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Dev.UI.Site.Data;

namespace Dev.UI.Site
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
           services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddTransient<IPedidoRepository, PedidoRepository>();
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=index}/{id?}");

                //routes.MapRoute(
                //   name: "areas",
                //   template: "{area:exists}/{controller=Home}/{action=index}/{id?}");

                routes.MapAreaRoute(
                    name: "AreaProdutos",
                    areaName: "Produtos",
                    template: "Produtos/{controller=Cadastro}/{action=index}/{id?}");

                routes.MapAreaRoute(
                    name: "AreaVendas",
                    areaName: "Vendas",
                    template: "Vendas/{controller=Pedidos}/{action=index}/{id?}");
            });
        }
    }
}
