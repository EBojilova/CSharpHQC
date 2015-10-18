namespace LearningSystem.Controllers
{
    using System.Linq;

    using LearningSystem.Interfaces;
    using LearningSystem.Models;
    using LearningSystem.Utilities;

    public class CoursesController : Controller
    {
        public CoursesController(IBangaloreUniversityData data, User currentUser)
            : base(data, currentUser)
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
            Validations.ValidateNotEnrolledStudent(this.CurrentUser, course);
            
            return this.View(this.Data.Courses.Get(courseId));
        }

        public IView Enroll(int courseId)
        {
            Validations.CheckForCurrentUser(this.HasCurrentUser);
            Validations.ValidateRoles(this.CurrentUser);
            var course = Validations.ValidateCourseId(this.Data, courseId);
            Validations.ValidateEnrollingStudent(this.CurrentUser, course);
            course.AddStudent(this.CurrentUser);

            return this.View(course);
        }

        public IView Create(string name)
        {
            Validations.CheckForCurrentUser(this.HasCurrentUser);
            Validations.ValidateLectureRole(this.CurrentUser);
            var course = new Course(name);
            this.Data.Courses.Add(course);

            return this.View(course);
        }

        public IView AddLecture(int courseId, string lectureName)
        {
            Validations.CheckForCurrentUser(this.HasCurrentUser);
            Validations.ValidateLectureRole(this.CurrentUser);
            var course = Validations.ValidateCourseId(this.Data, courseId);
            course.AddLecture(new Lecture(lectureName));

            return this.View(course);
        }
    }
}