using System;
using Bogus;
using IFlow.Testing.Utils.DataBase;

namespace IFlow.Testing.Utils.DataFactory
{
    public static class UserData
    {
        public static readonly User CorrectApiUser = new User(UserConsts.key, UserConsts.header);

        [Obsolete("Visual Studio IntelliSense Work Around", true)]
        public static Faker<User> CreateUserData()       //Method that generates data and returns it to save in scenario context (see BaseSteps.cs)
        {
           return  new Faker<User>()                     //All fields have description and example in Bogus Faker documentation 
                              .CustomInstantiator(f => new User())
                              .RuleFor(u => u.FirstName, f => f.Name.FirstName())
                              .RuleFor(u => u.LastName, f => f.Name.LastName())
                              .RuleFor(u => u.UserName, (f, u) => f.Internet.UserName(u.FirstName, u.LastName))
                              .RuleFor(u => u.Email, (f, u) => f.Internet.Email(u.FirstName, u.LastName))
                              .RuleFor(u => u.Country, f => f.Address.Country())
                              .RuleFor(u => u.PhoneNumber, f => f.Phone.PhoneNumber())
                              .RuleFor(u => u.Password, f => f.Internet.Password(8, false, "", ""));
        }
    }
}
