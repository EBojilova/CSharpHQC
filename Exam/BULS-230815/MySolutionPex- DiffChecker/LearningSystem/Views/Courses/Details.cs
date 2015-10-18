﻿namespace LearningSystem.Views.Courses
{
    using System;
    using System.Linq;
    using System.Text;

    using LearningSystem.Models;

    public class Details : View
    {
        public Details(Course course)
            : base(course)
        {
        }

        internal override void BuildViewResult(StringBuilder viewResult)
        {
            var course = this.Model as Course;
            if (course == null)
            {
                return;
            }

            viewResult.AppendLine(course.Name);
            if (!course.Lectures.Any())
            {
                viewResult.AppendLine("No lectures");
            }
            else
            {
                var lectureNames = course.Lectures.Select(lecture => "- " + lecture.Name);
                viewResult.AppendLine(string.Join(Environment.NewLine, lectureNames));
            }
        }
    }
}