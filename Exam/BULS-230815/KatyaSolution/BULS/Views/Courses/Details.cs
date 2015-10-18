namespace BULS.Views
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using BULS.Infrastructure;
    using BULS.Models;

    public class Details : View
    {
        public Details(Course course)
            : base(course)
        {
        }

        internal override void BuildViewResult(StringBuilder viewResult)
        {
            Course course = this.Model as Course;
            viewResult.AppendLine(course.Name);
            if (!course.Lectures.Any())
            {
                viewResult.AppendLine("No lectures");
            }
            else
            {
                IEnumerable<string> lectureNames = course.Lectures.Select(l => "- " + l.Name);
                viewResult.AppendLine(string.Join(Environment.NewLine, lectureNames));
            }
        }
    }
}