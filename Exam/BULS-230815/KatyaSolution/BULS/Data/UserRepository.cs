namespace BULS.Data
{
    using System.Linq;

    using BULS.Models;

    public class UsersRepository : Repository<User>
    {
        public User GetByUsername(string username)
        {
            return this.Items.FirstOrDefault(u => u.Username == username);
        }
    }
}