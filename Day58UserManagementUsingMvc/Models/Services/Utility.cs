﻿namespace Day58UserManagementUsingMvc.Models.Services
{
    public static class Utility
    {
        public static User GenerateFakeData()
        {
            var user = new User
            {
                FirstName = Faker.Name.First(),
                LastName = Faker.Name.Last(),
                DateOfBirth = Faker.Identification.DateOfBirth(),
                Pan = "ADHYT1656O",
                Address = Faker.Address.StreetAddress(true),
                Gender = (char)Faker.Enum.Random<Gender>(),
                MobileNumber = Faker.Phone.Number(),
                Email = Faker.Internet.Email("rajnisir"),
                Comments = "Some test Comment",
                DepartmentRefId = 1
            };
            return user;
        }

        public static Department GenerateFakeDataForDept()
        {
            var department = new Department
            {
                Name = Faker.Name.First(),
                Description = "Some department information"
            };
            return department;

        }

    }


    enum Gender
    {
        Male='M',
        Female = 'F',
        Other = 'O'
    }
}
