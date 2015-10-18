namespace BangaloreUniversityLearningSystem.Models
{
    using System;
    using System.Collections.Generic;

    public class Course : IComparable<Course>
    {
        //A course name must be at least 5 symbols long
        private readonly int minNameLength = 5;

        private string name;

        public Course(string name)
        {
            this.Name = name;
            this.Lectures = new List<Lecture>();
            this.Students= new List<User>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (string.IsNullOrEmpty(value) || value.Length < this.minNameLength)
                {
                    var message = string.Format(
                        "The course name must be at least {0} symbols long.",
                        this.minNameLength);
                    throw new ArgumentException(message);
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