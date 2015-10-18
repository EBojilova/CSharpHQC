namespace BULS.Controllers
{
    using System;

    using BULS.Interfaces;
    using BULS.Models;

    using BULS.Utilities;

    internal class UsersController : Controller
    {
        public UsersController(IBangaloreUniversityData data, User user)
        {
            this.Data = data;
            this.Usr = user;
        }

        /// <summary>
        /// Registers the specified user.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <param name="password">The password.</param>
        /// <param name="confirmPassword">The password confirmation.</param>
        /// <param name="role">The user role.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">
        /// The provided passwords do not match.
        /// or
        /// A user with this username already exists.
        /// </exception>
        public IView Register(string username, string password, string confirmPassword, string role)
        {
            if (password != confirmPassword)
            {
                throw new ArgumentException("The provided passwords do not match.");
            }

            this.EnsureNoLoggedInUser();

            User existingUser = this.Data.Users.GetByUsername(username);
            if (existingUser != null)
            {
                throw new ArgumentException(string.Format("A user with username {0} already exists.", username));
            }

            Role userRole = (Role)Enum.Parse(typeof(Role), role, true);
            User user = new User(username, password, userRole);
            this.Data.Users.Add(user);
            return this.View(user);
        }

        public IView Login(string username, string password)
        {
            this.EnsureNoLoggedInUser();

            User existingUser = this.Data.Users.GetByUsername(username);
            if (existingUser == null)
            {
                throw new ArgumentException(string.Format("A user with username {0} does not exist.", username));
            }

            if (existingUser.Password != HashUtilities.HashPassword(password))
            {
                throw new ArgumentException("The provided password is wrong.");
            }

            this.Usr = existingUser;
            return this.View(existingUser);
        }

        public IView Logout()
        {
            if (!this.HasCurrentUser)
            {
                throw new ArgumentException("There is no currently logged in user.");
            }

            if (!this.Usr.IsInRole(Role.Lecturer) && !this.Usr.IsInRole(Role.Student))
            {
                throw new DivideByZeroException("The current user is not authorized to perform this operation.");
            }

            User user = this.Usr;
            this.Usr = null;
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