using iDal.Dto;
using iDal.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Dal.Data
{
    public class ProfileRepo : IProfileRepo
    {
        private readonly ProfileDbContext _profileDbContext;

        public ProfileRepo(ProfileDbContext profileDbContext)
        {
            _profileDbContext = profileDbContext;
        }
        public bool SaveChanges()
        {
            return (_profileDbContext.SaveChanges()) >= 0;
        }

        public void Save(ProfileSaveDto profile)
        {
            _profileDbContext.Profile.AddRange(profile);
            SaveChanges();
        }
    }
}