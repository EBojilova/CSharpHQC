namespace BangaloreUniversityLearningSystem.Data
{
    using System.Collections.Generic;

    using BangaloreUniversityLearningSystem.Models;

    public class UsersRepository : Repository<User>
    {
        public UsersRepository()
        {
            this.UserName_User = new Dictionary<string, User>();
        }

        public Dictionary<string, User> UserName_User { get; }

        public User GetByUsername(string username)
        {
            return this.UserName_User.ContainsKey(username) ? this.UserName_User[username] : null;
        }

        public override void Add(User item)
        {
            this.UserName_User.Add(item.UserName, item);
            base.Add(item);
        }
    }
}