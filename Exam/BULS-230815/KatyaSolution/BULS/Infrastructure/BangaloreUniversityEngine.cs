namespace BULS.Core
{
    using System;
    using System.Linq;
    using System.Reflection;

    using BULS.Controllers;
    using BULS.Data;
    using BULS.Infrastructure;
    using BULS.Interfaces;
    using BULS.Models;

    public class BangaloreUniversityEngine : IEngine
    {
        public void Run()
        {
            BangaloreUniversityData database = new BangaloreUniversityData();
            User u = null;
            while (true)
            {
                string str = Console.ReadLine();
                if (str == null)
                {
                    break;
                }

                Route route = new Route(str);
                Type controllerType =
                    Assembly.GetExecutingAssembly()
                        .GetTypes()
                        .FirstOrDefault(type => type.Name == route.ControllerName);
                Controller ctrl = Activator.CreateInstance(controllerType, database, u) as Controller;
                MethodInfo act = controllerType.GetMethod(route.ActionName);
                object[] @params = MapParameters(route, act);
                try
                {
                    IView view = act.Invoke(ctrl, @params) as IView;
                    Console.WriteLine(view.Display());
                    u = ctrl.Usr;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.InnerException.Message);
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