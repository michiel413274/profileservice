using iDal.Dto;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Dal.Data
{
    public static class PrepDb
    {
        public static void PrepPopulation(IApplicationBuilder app, bool isProd)
        {
            using( var serviceScope = app.ApplicationServices.CreateScope())
            {
                SeedData(serviceScope.ServiceProvider.GetService<ProfileDbContext>(), isProd);
            }
        }

        private static void SeedData(ProfileDbContext context, bool isProd)
        {
            if(isProd)
            {
                Console.WriteLine(" attempting to apply migrations");
                try
                {
                    context.Database.Migrate();
                }
                catch(Exception ex)
                {
                    Console.WriteLine($"could not migrate {ex.Message}");
                }
                
            }

            if(!context.Profile.Any())
            {
                Console.WriteLine("Seeding Data");
                context.Profile.AddRange(
                    new ProfileSaveDto() {Id = 1, Name = "hea", Age = 4, Hometown = "shrt", Fyver = DateTime.Now },
                    new ProfileSaveDto() { Id = 5, Name = "gae", Age = 4, Hometown = "sh", Fyver = DateTime.Now },
                    new ProfileSaveDto() { Id = 3, Name = "dfgdd", Age = 1, Hometown = "shge", Fyver = DateTime.Now });

                context.SaveChanges();
            }
            else
            {
                Console.WriteLine("Already have data");
            }
        }
    }
}
