using AddressBook.Config;
using AddressBook.DAL;
using AddressBook.Logic;
using AddressBook.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Swagger;

namespace AddressBook.WebAPI
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc()
                .SetCompatibilityVersion(Microsoft.AspNetCore.Mvc.CompatibilityVersion.Version_2_1);

            services.Configure<AddressBookConfig>(x =>
                Configuration.GetSection(nameof(AddressBookConfig)).Bind(x));

            services.AddSingleton<AddressBookConfig>(sp =>
                sp.GetRequiredService<IOptions<AddressBookConfig>>().Value);

            services.AddSingleton<AddressDetails>();
            services.AddSingleton<IAddressBookEngine, AddressBookEngine>();
            services.AddSingleton<IAddressContext, AddressContext>();
            services.AddSingleton<IAddressBookConfig, AddressBookConfig>();
            

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "My API", Version = "v1" });
            });
        }

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

            app.UseDefaultFiles();
            app.UseStaticFiles();

            app.UseHttpsRedirection();
            app.UseMvc();

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

        }
    }
}
