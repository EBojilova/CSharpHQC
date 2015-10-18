namespace BULS.Views.Courses
{
    using System.Text;

    using BULS.Infrastructure;
    using BULS.Models;

    public class Create : View
    {
        public Create(Course course)
            : base(course)
        {
        }

        internal override void BuildViewResult(StringBuilder viewResult)
        {
            Course course = this.Model as Course;
            viewResult.AppendFormat("Course {0} created successfully.", course.Name).AppendLine();
        }
    }
}