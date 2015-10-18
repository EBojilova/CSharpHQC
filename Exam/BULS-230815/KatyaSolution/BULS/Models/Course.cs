namespace BULS.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Course
    {
        private string name;

        public Course(string name)
        {
            this.Name = name;
            this.Lectures = new List<Lecture>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                if (string.IsNullOrEmpty(value) || value.Length < 5)
                {
                    const string Message = "The course name must be at least 5 symbols long.";
                    throw new ArgumentException(Message);
                }

                this.name = value;
            }
        }

        public IList<Lecture> Lectures { get; set; }

        public IList<User> Students { get; set; }

        public void AddLecture(Lecture lecture)
        {
            this.Lectures.Add(lecture);
        }

        public void AddStudent(User student)
        {
            this.Students.Add(student);
            student.Courses.Add(this);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(this.Name);

            if (this.Lectures.Count < 1)
            {
                sb.AppendLine("No lectures");
            }
            else
            {
                foreach (Lecture lecture in this.Lectures)
                {
                    sb.AppendFormat("- {0}{1}", lecture, Environment.NewLine);
                }
            }

            return sb.ToString().Trim();
        }
    }
}