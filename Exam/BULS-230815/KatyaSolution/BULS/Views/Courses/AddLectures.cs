namespace BULS.Views.Courses
{
    using System;
    using System.Text;

    using BULS.Infrastructure;
    using BULS.Models;

    public class AddLectures : View
    {
        public AddLectures(Course course)
            : base(course)
        {
        }

        internal override void BuildViewResult(StringBuilder viewResult)
        {
            Course course = this.Model as Course;
            if (course == null)
            {
                throw new NullReferenceException();
            }

            viewResult.AppendFormat("Lecture successfully added to course {0}.", course.Name).AppendLine();
        }

    }
}