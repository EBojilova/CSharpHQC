namespace BangaloreUniversityLearningSystem.Controllers
{
    using System;
    using System.Linq;

    using BangaloreUniversityLearningSystem.Contracts;
    using BangaloreUniversityLearningSystem.Exeptions;
    using BangaloreUniversityLearningSystem.Models;
    using BangaloreUniversityLearningSystem.Utilities;

    internal class CoursesController : Controller
    {
        public CoursesController(IBangaloreUniversityDate data, User currentUser)
        {
            this.Data = data;
            this.CurrentUser = currentUser;
        }

        public IView All()
        {
            return this.View(this.Data.Courses.GetAll().OrderBy(course => course));
        }

        public IView Details(int courseId)
        {
            // There is no logged in currentUser in the system
            this.EnsureThereIsLoggedInUser();

            // The currently logged in currentUser is not a student or a lecturer
            this.EnsureAuthorization(Role.Student, Role.Lecturer);

            // The course does not exist
            var course = this.CourseGetter(courseId);

            // The course is not in the currently logged in user’s courses
            if (!this.CurrentUser.Courses.Contains(course))
            {
                throw new ArgumentException("You are not enrolled in this course.");
            }

            // Success
            return this.View(course);
        }

        public IView Enroll(int courseId)
        {
            // There is no logged in currentUser in the system
            this.EnsureThereIsLoggedInUser();

            // The currently logged in currentUser is not a student or a lecturer
            this.EnsureAuthorization(Role.Student, Role.Lecturer);

            // The course does not exist
            var course = this.CourseGetter(courseId);

            // The currently logged in currentUser has already enrolled in the course
            if (this.CurrentUser.Courses.Contains(course))
            {
                throw new ArgumentException("You are already enrolled in this course.");
            }

            // Success 
            course.AddStudent(this.CurrentUser);
            return this.View(course);
        }

        public IView Create(string name)
        {
            // There is no logged in currentUser in the system
            this.EnsureThereIsLoggedInUser();

            // The currently logged in currentUser is not a lecturer
            this.EnsureUserIsLecturer();

            var course = new Course(name);
            this.Data.Courses.Add(course);
            return this.View(course);
        }

        public IView AddLecture(int courseId, string lectureName)
        {
            // There is no logged in currentUser in the system
            this.EnsureThereIsLoggedInUser();

            // The currently logged in currentUser is not a lecturer
            this.EnsureUserIsLecturer();

            // The course does not exist
            var course = this.CourseGetter(courseId);

            // Success
            course.AddLecture(new Lecture(lectureName));
            return this.View(course);
        }

        private void EnsureUserIsLecturer()
        {
            if (!this.CurrentUser.IsInRole(Role.Lecturer))
            {
                throw new AuthorizationFailedException("The current user is not authorized to perform this operation.");
            }
        }

        private Course CourseGetter(int courseId)
        {
            var course = this.Data.Courses.Get(courseId);
            if (course == null)
            {
                throw new ArgumentException(string.Format("There is no course with ID {0}.", courseId));
            }
            return course;
        }
    }
}