﻿namespace ProfileService.Models
{
    public class ProfileModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Location { get; set; }
        public Genders Genders { get; set; }

        public string Description { get; set; }
        public string ProfilePicture { get; set; }

        public ProfileModel() { }

        public ProfileModel(int id, string name, int age, string location, Genders genders, string description, string profilePicture)
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
