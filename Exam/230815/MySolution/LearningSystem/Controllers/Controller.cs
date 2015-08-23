namespace LearningSystem.Controllers
{
    using System;
    using System.Diagnostics;
    using System.Linq;
    using System.Reflection;

    using LearningSystem.Interfaces;
    using LearningSystem.Models;
    using LearningSystem.Utilities;

    public abstract class Controller
    {
        protected Controller(IBangaloreUniversityDate data, User user)
        {
            this.Data = data;
            this.User = user;
        }

        public IBangaloreUniversityDate Data { get; set; }

        public User User { get; set; }

        public bool HasCurrentUser
        {
            get
            {
                return this.User != null;
            }
        }

        protected IView View(object model)
        {
            var fullNamespace = this.GetType().Namespace;
            var firstSeparatorIndex = fullNamespace.IndexOf(".");
            var baseNamespace = fullNamespace.Substring(0, firstSeparatorIndex);
            var controllerName = this.GetType().Name.Replace("Controller", string.Empty);
            var actionName = new StackTrace().GetFrame(1).GetMethod().Name;
            var fullPath = baseNamespace + ".Views." + actionName;
            var viewType = Assembly.GetExecutingAssembly().GetType(fullPath);
            return Activator.CreateInstance(viewType, model) as IView;
        }
    }
}