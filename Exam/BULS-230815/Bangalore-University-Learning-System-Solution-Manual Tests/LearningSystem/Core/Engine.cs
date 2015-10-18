namespace LearningSystem.Core
{
    using System;
    using System.Linq;
    using System.Reflection;

    using LearningSystem.Controllers;
    using LearningSystem.Data;
    using LearningSystem.Interfaces;
    using LearningSystem.Models;

    public class Egine : IEgine
    {
        public void Run()
        {
            // DA NAPRAVIA 2 KONSTRUKTORA, KATO VTORIA DA E S DEPENDENCY INJECTION

            var data = new BangaloreUniversityData();
            User user = null;
            while (true)
            {
                var input = Console.ReadLine();
                if (input == null)
                {
                    break;
                }

                var route = new Route(input);
                var controllerType =
                    Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(type => type.Name == route.ControllerName);
                var controller = Activator.CreateInstance(controllerType, data, user) as Controller;
                var action = controllerType.GetMethod(route.ActionName);
                var parameters = MapParameters(route, action);
                try
                {
                    var view = action.Invoke(controller, parameters) as IView;
                    Console.WriteLine(view.Display());
                    user = controller.CurrentUser;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.InnerException.Message);
                }
            }
        }

        private static object[] MapParameters(IRoute route, MethodInfo action)
        {
            return action.GetParameters().Select<ParameterInfo, object>(
                parameter =>
                    {
                        if (parameter.ParameterType == typeof(int))
                        {
                            return int.Parse(route.ActionParameters[parameter.Name]);
                        }

                        return route.ActionParameters[parameter.Name];
                    }).ToArray();
        }
    }
}