namespace BangaloreUniversityLearningSystem.Controllers
{
    using System;

    using BangaloreUniversityLearningSystem.Contracts;
    using BangaloreUniversityLearningSystem.Models;
    using BangaloreUniversityLearningSystem.Utilities;

    internal class UsersController : Controller
    {
        public UsersController(IBangaloreUniversityDate data, User currentUser)
        {
            this.Data = data;
            this.CurrentUser = currentUser;
        }

        public IView Register(string username, string password, string confirmPassword, string role)
        {
            // The two passwords do not match
            if (password != confirmPassword)
            {
                throw new ArgumentException("The provided passwords do not match.");
            }

            // There is already a logged in currentUser in the system
            this.EnsureNoLoggedInUser();

            // There is already a currentUser with the specified username in the system
            var existingUser = this.Data.Users.GetByUsername(username);
            if (existingUser != null)
            {
                throw new ArgumentException(string.Format("A currentUser with username {0} already exists.", username));
            }

            // Success 
            var userRole = (Role)Enum.Parse(typeof(Role), role, true);
            var user = new User(username, password, userRole);
            this.Data.Users.Add(user);
            return this.View(user);
        }

        public IView Login(string username, string password)
        {
            // There is already a logged in currentUser in the system
            this.EnsureNoLoggedInUser();

            // There is  no currentUser with the specified username in the system
            var existingUser = this.Data.Users.GetByUsername(username);
            if (existingUser == null)
            {
                throw new ArgumentException(string.Format("A user with username {0} does not exist.", username));
            }

            // The username has been found, but the password does not match the database record
            if (existingUser.PasswordHash != HashUtilities.HashPassword(password))
            {
                throw new ArgumentException("The provided password is wrong.");
            }

            // Success 
            this.CurrentUser = existingUser;
            return this.View(existingUser);
        }

        public IView Logout()
        {
            // There is already a logged in currentUser in the system
            this.EnsureThereIsLoggedInUser();

            // Success 
            var user = this.CurrentUser;
            this.CurrentUser = null;
            return this.View(user);
        }

        private void EnsureNoLoggedInUser()
        {
            if (this.HasCurrentUser)
            {
                throw new ArgumentException("There is already a logged in user.");
            }
        }
    }
}