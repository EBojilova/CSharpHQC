namespace LearningSystem.Views
{
    using System.Text;

    using LearningSystem.Models;

    public class AddLecture : View
    {
        public AddLecture(Course course)
            : base(course)
        {
        }

        internal override void BuildViewResult(StringBuilder viewResult)
        {
            var course = this.Model as Course;
            if (course != null)
            {
                viewResult.AppendFormat("Lecture successfully added to course {0}.", course.Name).AppendLine();
            }
        }
    }
}