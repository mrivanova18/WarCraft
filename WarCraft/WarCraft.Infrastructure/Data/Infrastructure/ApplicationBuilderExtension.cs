using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarCraft.Infrastructure.Data.Entities;

namespace WarCraft.Infrastructure.Data.Infrastructure
{
    public static class ApplicationBuilderExtension
    {
        public static async Task<IApplicationBuilder> PrepareDatabase(this IApplicationBuilder app)
        {
            using var serviceScope = app.ApplicationServices.CreateScope();
            var services = serviceScope.ServiceProvider;

            await RoleSeeder(services);
            await SeedAdministrator(services);

            var dataCategory = serviceScope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            SeedCategories(dataCategory);
            var dataManufacturer = serviceScope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            SeedManufacturer(dataManufacturer);

            return app;
        }
        public static async Task RoleSeeder(IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            string[] roleNames = { "Administrator", "Client" };
            IdentityResult roleResult;
            foreach (var role in roleNames)
            {
                var roleExist = await roleManager.RoleExistsAsync(role);
                if (!roleExist)
                {
                    roleResult = await roleManager.CreateAsync(new IdentityRole(role));
                }
            }
        }
        public static async Task SeedAdministrator(IServiceProvider serviceProvider)
        {
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            if (await userManager.FindByNameAsync("admin") == null)
            {
                ApplicationUser user = new ApplicationUser();
                user.FirstName = "admin";
                user.LastName = "admin";
                user.PhoneNumber = "0888888888";
                user.UserName = "admin";
                user.Address = "admin address";
                user.Email = "admin@admin.com";

                var result = await userManager.CreateAsync(user, "Admin123456");

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "Administrator").Wait();
                }
            }
        }
        private static void SeedCategories(ApplicationDbContext dataCategory)
        {
            if (dataCategory.Categories.Any())
            {
                return;
            }
            dataCategory.Categories.AddRange(new[]
            {
                new Category {CategoryName = "Plane - Bomber" },
                new Category {CategoryName = "Plane - Fighter" },
                new Category {CategoryName = "Plane - Attack" },
                new Category {CategoryName = "Plane - Cargo" },
                new Category {CategoryName = "Plane - Multirole" },
                new Category {CategoryName = "Tank – Cruiser" },
                new Category {CategoryName = "Tank – Main battle tank" },
                new Category {CategoryName = "Tank – Tank Destroyer" },
                new Category {CategoryName = "Tank – Light/Medium/Heavy" },
                new Category {CategoryName = "Ship – Amphibious warfare ships" },
                new Category {CategoryName = "Ship – Brig" },
                new Category {CategoryName = "Ship – Aviation cruiser" },
                new Category {CategoryName = "Ship – Destroyer" }
            }); ;
            dataCategory.SaveChanges();
        }

        private static void SeedManufacturer(ApplicationDbContext dataManufacturer)
        {
            if (dataManufacturer.Manufacturers.Any())
            {
                return;
            }
            dataManufacturer.Manufacturers.AddRange(new[]
            {
                new Manufacturer{ManufacturerName = "Lockheed Martin – America"},
                new Manufacturer{ManufacturerName = "McDonnell Douglas – America"},
                new Manufacturer{ManufacturerName = "Boeing – America"},
                new Manufacturer{ManufacturerName = "Northrop Grumman – America" },
                new Manufacturer{ManufacturerName = "Albatros – Germany" },
                new Manufacturer{ManufacturerName = "Messerschmitt – Germany" },
                new Manufacturer{ManufacturerName = "Supermarine – United Kingdom"},
                new Manufacturer{ManufacturerName = "Nuffield Mechanizations and Aero"},
            });
            dataManufacturer.SaveChanges();
        }
    }
}
