using iDal.Dto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Data
{
    public class ProfileDbContext : DbContext
    {
        public ProfileDbContext(DbContextOptions<ProfileDbContext> options) : base(options)
        {

        }

        public DbSet<ProfileSaveDto> Profile { get; set; }
    }
}
