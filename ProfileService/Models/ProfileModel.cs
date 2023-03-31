namespace ProfileService.Models
{
    public class ProfileModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Hometown { get; set; }

        public DateTime Fyver { get; set; }
        //public Genders Genders { get; set; }

        public string Description { get; set; }
        public string ProfilePicture { get; set; }

        public ProfileModel() { }

        public ProfileModel(int id, string name, int age, string hometown, DateTime fyver)
        {
            Id = id;
            Name = name;
            Age = age;
            Hometown = hometown;
            Fyver = fyver;
        }
    }
}
