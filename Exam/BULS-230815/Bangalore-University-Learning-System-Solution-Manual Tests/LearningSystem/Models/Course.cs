namespace LearningSystem.Models
{
    using System;
    using System.Collections.Generic;

    using LearningSystem.Utilities;

    public class Course : IComparable<Course>
    {
        private const int MinNameLength = 5;
        private string name;

        public Course(string name)
        {
            this.Name = name;
            // TODO: To make IUser
            this.Lectures = new List<Lecture>();
            this.Students = new List<User>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                Validations.ValidateArgumentLenght(value, "course name", MinNameLength);
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

        public int CompareTo(Course otherCourse)
        {
            int resultOfCompare = string.Compare(this.Name, otherCourse.Name, StringComparison.InvariantCulture);
            if (resultOfCompare == 0)
            {
                resultOfCompare = otherCourse.Students.Count.CompareTo(this.Students.Count);
            }

            return resultOfCompare;
        }
    }
}