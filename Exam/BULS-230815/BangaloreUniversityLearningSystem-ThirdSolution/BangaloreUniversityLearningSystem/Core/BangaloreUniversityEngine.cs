namespace BangaloreUniversityLearningSystem.Core
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Reflection;

    using BangaloreUniversityLearningSystem.Contracts;
    using BangaloreUniversityLearningSystem.Controllers;
    using BangaloreUniversityLearningSystem.Data;
    using BangaloreUniversityLearningSystem.Infrastructure;
    using BangaloreUniversityLearningSystem.Models;

    public class Engine : IRunable
    {
        public void Run()
        {
            var db = new BangaloreUniversityDate();
            User user = null;
            using (var reader = new StreamReader("../../URLs/002.txt"))
            {
                while (true)
                {
                    var url = reader.ReadLine();
                    //var url = Console.ReadLine();
                    if (url == null)
                    {
                        break;
                    }
                    var route = new Route(url);
                    var controllerType =
                        Assembly.GetExecutingAssembly()
                            .GetTypes()
                            .FirstOrDefault(type => type.Name == route.ControllerName);
                    var controller = Activator.CreateInstance(controllerType, db, user) as Controller;
                    var act = controllerType.GetMethod(route.ActionName);
                    var @params = MapParameters(route, act);
                    try
                    {
                        var view = act.Invoke(controller, @params) as IView;
                        Console.WriteLine(view.Display());
                        user = controller.CurrentUser;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.InnerException.Message);
                    }
                }
            }
        }

        private static object[] MapParameters(Route route, MethodInfo action)
        {
            return action.GetParameters().Select<ParameterInfo, object>(
                p =>
                    {
                        if (p.ParameterType == typeof(int))
                        {
                            return int.Parse(route.Parameters[p.Name]);
                        }
                        return route.Parameters[p.Name];
                    }).ToArray();
        }
    }
}