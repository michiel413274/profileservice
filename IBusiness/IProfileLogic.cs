using IBusiness.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBusiness
{
    public interface IProfileLogic
    {
        public ProfileCreateDto Create(ProfileCreateDto profile);
    }
}
