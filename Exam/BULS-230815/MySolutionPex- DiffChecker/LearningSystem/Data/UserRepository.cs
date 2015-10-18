// ReSharper disable AllCourses
// ReSharper disable All
namespace LearningSystem.Data
{
    using System.Collections.Generic;

    using LearningSystem.Models;

    public class UsersRepository : Repository<User>
    {
        public UsersRepository()
        {
            this.UserName_User = new Dictionary<string, User>();
        }

        public Dictionary<string, User> UserName_User { get; }
    }
}