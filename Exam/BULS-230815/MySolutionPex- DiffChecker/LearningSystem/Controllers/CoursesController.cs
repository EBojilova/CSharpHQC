namespace LearningSystem.Controllers
{
    using System.Linq;

    using LearningSystem.Interfaces;
    using LearningSystem.Models;
    using LearningSystem.Utilities;

    internal class CoursesController : Controller
    {
        public CoursesController(IBangaloreUniversityDate data, User user)
            : base(data, user)
        {
        }

        public IView All()
        {
            return this.View(
                this.Data.Courses.GetAll().OrderBy(course => course));
        }

        public IView Details(int courseId)
        {
            Validations.CheckForCurrentUser(this.HasCurrentUser);
            var course = Validations.ValidateCourseId(this.Data, courseId);
            Validations.ValidateNotEnrolledStudent(this.User, course);
            
            return this.View(this.Data.Courses.Get(courseId));
        }

        public IView Enroll(int courseId)
        {
            Validations.CheckForCurrentUser(this.HasCurrentUser);
            Validations.ValidateRoles(this.User);
            var course = Validations.ValidateCourseId(this.Data, courseId);
            Validations.ValidateEnrollingStudent(this.User, course);
            course.AddStudent(this.User);

            return this.View(course);
        }

        public IView Create(string name)
        {
            Validations.CheckForCurrentUser(this.HasCurrentUser);
            Validations.ValidateLectureRole(this.User);
            var course = new Course(name);
            this.Data.Courses.Add(course);

            return this.View(course);
        }

        public IView AddLecture(int courseId, string lectureName)
        {
            Validations.CheckForCurrentUser(this.HasCurrentUser);
            Validations.ValidateLectureRole(this.User);
            var course = Validations.ValidateCourseId(this.Data, courseId);
            course.AddLecture(new Lecture(lectureName));

            return this.View(course);
        }
    }
}