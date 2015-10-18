namespace LearningSystem.Controllers
{
    using System;
    using System.Diagnostics;
    using System.Reflection;

    using LearningSystem.Interfaces;
    using LearningSystem.Models;

    public abstract class Controller
    {
        protected Controller(IBangaloreUniversityData data, User currentUser)
        {
            this.Data = data;
            this.CurrentUser = currentUser;
        }

        public IBangaloreUniversityData Data { get; set; }

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
            var controllerName = this.GetType().Name.Replace("Controller", string.Empty);
            var actionName = new StackTrace().GetFrame(1).GetMethod().Name;
            var fullPath = baseNamespace + ".Views." + controllerName + "." + actionName;
            var viewType = Assembly.GetExecutingAssembly().GetType(fullPath);
            return Activator.CreateInstance(viewType, model) as IView;
        }
    }
}