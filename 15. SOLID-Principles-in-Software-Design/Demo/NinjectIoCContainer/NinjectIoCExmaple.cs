// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NinjectIoCExmaple.cs" company="">
//   
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace NinjectIoCContainer
{
    using System;
    using System.Reflection;

    using Ninject;

    using NinjectIoCContainer.Contracts;

    public class NinjectIoCExmaple
    {
        internal static void Main()
        {
            var kernel = new StandardKernel();

            // kazvame da zaredi klasovete ot tekustoto asebli chrez reflection(metoda Load e ot NinjectConfiguration)
            kernel.Load(Assembly.GetExecutingAssembly());

            // kazvame na ninject da mi sasdade data ot CourseData, koiato sme bindnali s ICourseData
            var data = kernel.Get<ICourseData>();
            Console.WriteLine(string.Join(", ", data.GetCourseNames()));
        }
    }
}
