namespace LearningSystem.Views
{
    using System.Text;

    using LearningSystem.Models;

    public class Create : View
    {
        public Create(Course course)
            : base(course)
        {
        }

        internal override void BuildViewResult(StringBuilder viewResult)
        {
            var course = this.Model as Course;
            if (course != null)
            {
                viewResult.AppendFormat("Course {0} created successfully.", course.Name).AppendLine();
            }
        }
    }
}