namespace LearningSystem.Controllers
{
    using System;

    using LearningSystem.Interfaces;
    using LearningSystem.Models;
    using LearningSystem.Utilities;

    internal class UsersController : Controller
    {
        public UsersController(IBangaloreUniversityDate data, User user)
            : base(data, user)
        {
        }

        /// <summary>
        /// The controller actions which performs user registration.
        /// </summary>
        /// <param name="username">The user name of the person to be registered.</param>
        /// <param name="password">The password.</param>
        /// <param name="confirmPassword">The confirmation password. Should be identical with the password.</param>
        /// <param name="role">The role of the person- can be lecture or student.</param>
        /// <returns>In case of sucess retunrs sucess message. If passwords do not mathch, 
        /// there is logged user, or user is not registered returns error message.</returns>
        /// <exception cref="ArgumentException">Appropriate error message.</exception>
        public IView Register(string username, string password, string confirmPassword, string role)
        {
            Validations.CheckPasswordsMatch(password, confirmPassword);
            Validations.EnsureNoLoggedInUser(this.HasCurrentUser);
            Validations.EnsureUserIsNotRgistered(this.Data.Users, username);
            var userRole = (Role)Enum.Parse(typeof(Role), role, true);
            var user = new User(username, password, userRole);
            this.Data.Users.Add(user);
            this.Data.Users.UserName_User[username] = user;

            return this.View(user);
        }

        public IView Login(string username, string password)
        {
            Validations.EnsureNoLoggedInUser(this.HasCurrentUser);
            var existingUser = Validations.EnsureUserIsRegistered(this.Data.Users, username);
            Validations.ChecksForPasswordHashMatch(password, existingUser.Password);
            this.User = existingUser;

            return this.View(existingUser);
        }

        public IView Logout()
        {
            Validations.CheckForCurrentUser(this.HasCurrentUser);
            Validations.ValidateRoles(this.User);
            var user = this.User;
            this.User = null;

            return this.View(user);
        }
    }
}