using IBusiness.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBusiness.Dto
{
    public class ProfileCreateDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Location { get; set; }
        public Genders Genders { get; set; }

        public string Description { get; set; }
        public string ProfilePicture { get; set; }

        public ProfileCreateDto()
        {            
        }

        public ProfileCreateDto(int id, string name, int age, string location, Genders genders, string description, string profilePicture)
        {
            Id = id;
            Name = name;
            Age = age;
            Location = location;
            Genders = genders;
            Description = description;
            ProfilePicture = profilePicture;
        }
    }
}
