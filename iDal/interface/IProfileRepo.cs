using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iDal.Dto;

namespace iDal.Interface
{
    public interface IProfileRepo
    {
        bool SaveChanges();

        void Save(ProfileSaveDto profile);
    }
}
