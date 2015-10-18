namespace BangaloreUniversityLearningSystem.Controllers
{
    using System;
    using System.Diagnostics;
    using System.Linq;
    using System.Reflection;

    using BangaloreUniversityLearningSystem.Contracts;
    using BangaloreUniversityLearningSystem.Exeptions;
    using BangaloreUniversityLearningSystem.Models;
    using BangaloreUniversityLearningSystem.Utilities;

    public abstract class Controller
    {
        protected IBangaloreUniversityDate Data { get; set; }

        public User CurrentUser { get; set; }

        public bool HasCurrentUser
        {
            get
            {
                return this.CurrentUser != null;
            }
        }

        protected IView View(object model)
        {
            var fullNamespace = this.GetType().Namespace;
            var firstSeparatorIndex = fullNamespace.IndexOf(".");
            var baseNamespace = fullNamespace.Substring(0, firstSeparatorIndex);
            var controllerName = this.GetType().Name.Replace("Controller", "");
            var actionName = new StackTrace().GetFrame(1).GetMethod().Name;
            var fullPath = baseNamespace + ".Views." + controllerName + "." + actionName;
            var viewType = Assembly.GetExecutingAssembly().GetType(fullPath);
            return Activator.CreateInstance(viewType, model) as IView;
        }

        protected void EnsureAuthorization(params Role[] roles)
        {
            if (!this.HasCurrentUser)
            {
                throw new ArgumentException("There is no currently logged in user.");
            }

            foreach (var user in this.Data.Users.GetAll())
            {
                if (!roles.Any(role => this.CurrentUser.IsInRole(role)))
                {
                    throw new AuthorizationFailedException("The current user is not authorized to perform this operation.");
                }
            }
        }

        protected void EnsureThereIsLoggedInUser()
        {
            if (!this.HasCurrentUser)
            {
                throw new ArgumentException("There is no currently logged in user.");
            }
        }
    }
}