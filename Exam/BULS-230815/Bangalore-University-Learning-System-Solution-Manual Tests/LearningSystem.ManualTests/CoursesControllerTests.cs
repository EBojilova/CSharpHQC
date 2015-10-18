namespace LearningSystem.ManualTests
{
    using System;
    using System.Collections.Generic;

    using LearningSystem.Controllers;
    using LearningSystem.Exceptions;
    using LearningSystem.Interfaces;
    using LearningSystem.Models;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Moq;

    [TestClass]
    public class CoursesControllerTests
    {
        [TestMethod]
        public void All_WithValidData_ShouldCallDatabaseGetAll()
        {
            var user = new User("Pesho", "1234567", Role.Lecturer);

            var database = new Mock<IBangaloreUniversityData>();
            database.Setup(data => data.Courses.GetAll()).Returns(new List<Course>());

            var controller = new CoursesController(database.Object, user);

            controller.All();

            database.Verify(data => data.Courses.GetAll(), Times.Exactly(1));
        }

        [TestMethod]
        public void All_ReturnsIView()
        {
            var user = new User("Pesho", "1234567", Role.Lecturer);

            var database = new Mock<IBangaloreUniversityData>();

            database.Setup(data => data.Courses.GetAll()).Returns(new List<Course>());

            var controller = new CoursesController(database.Object, user);

            var result = controller.All();

            Assert.IsInstanceOfType(result, typeof(IView));
        }

        [TestMethod]
        public void All_WithoutCurrentUser_RetunrnsIView()
        {
            var database = new Mock<IBangaloreUniversityData>();

            database.Setup(data => data.Courses.GetAll()).Returns(new List<Course>());

            var controller = new CoursesController(database.Object, null);

            var result = controller.All();

            Assert.IsInstanceOfType(result, typeof(IView));
        }

        // Addiotional tests of CoursesCotntroller- Problem 8. Mocking

        [TestMethod]
        public void AddLecture_WithValidInput_ShouldCallDatabaseCoursesGetMethod()
        {
            var database = new Mock<IBangaloreUniversityData>();

            // kakavto i da e int ste varne edin i sast kurs
            database.Setup(data => data.Courses.Get(It.IsAny<int>())).Returns(new Course("Test1234"));

            var courseController = new CoursesController(
                database.Object,
                new User("Ivan Ivanov", "123456", Role.Lecturer));

            var result = courseController.AddLecture(1, "TestLecture");

            database.Verify(data => data.Courses.Get(It.IsAny<int>()), Times.Exactly(1));
        }

        [TestMethod]
        public void AddLecture_WithValidInput_ShouldAddNewLectureToSpecifiedCourse()
        {
            var database = new Mock<IBangaloreUniversityData>();
            var course = new Course("Test1234");
            Assert.AreEqual(0, course.Lectures.Count);
            database.Setup(a => a.Courses.Get(It.IsAny<int>())).Returns(course);

            var courseController = new CoursesController(
                database.Object,
                new User("Ivan Ivanov", "123456", Role.Lecturer));

            courseController.AddLecture(5, "TestLecture");

            Assert.AreEqual(1, course.Lectures.Count);
        }

        [TestMethod]
        public void AddLecture_WithValidInput_ShouldAddCorrectLectureToTheCourse()
        {
            var course = new Course("Test1234");
            Assert.AreEqual(0, course.Lectures.Count);

            var database = new Mock<IBangaloreUniversityData>();
            database.Setup(a => a.Courses.Get(It.IsAny<int>())).Returns(course);

            var courseController = new CoursesController(
                database.Object,
                new User("Ivan Ivanov", "123456", Role.Lecturer));

            courseController.AddLecture(5, "TestLecture");

            Assert.AreEqual("TestLecture", course.Lectures[0].Name);
        }

        [TestMethod]
        public void AddLecture_WithoutLoggedUser_ShouldThrowCorrectException()
        {
            var database = new Mock<IBangaloreUniversityData>();
            var course = new Course("Test1234");
            database.Setup(a => a.Courses.Get(It.IsAny<int>())).Returns(course);

            var courseController = new CoursesController(database.Object, null);

            var exception =
                NUnit.Framework.Assert.Catch<ArgumentException>(
                    () => { courseController.AddLecture(5, "TestLecture"); });
            Assert.AreEqual("There is no currently logged in user.", exception.Message);
        }

        [TestMethod]
        public void AddLecture_WithIncorrectRole_ShouldThrowCorrectException()
        {
            var database = new Mock<IBangaloreUniversityData>();
            var course = new Course("Test1234");
            database.Setup(a => a.Courses.Get(It.IsAny<int>())).Returns(course);

            var courseController = new CoursesController(
                database.Object,
                new User("Ivan ivanov", "123456", Role.Student));

            var exception =
                NUnit.Framework.Assert.Catch<AuthorizationFailedException>(
                    () => { courseController.AddLecture(5, "TestLecture"); });
            Assert.AreEqual("The current user is not authorized to perform this operation.", exception.Message);
        }

        [TestMethod]
        public void AddLecture_WithNonExistantCourse_ShouldThrowCorrectException()
        {
            var database = new Mock<IBangaloreUniversityData>();
            Course course = null;
            database.Setup(data => data.Courses.Get(It.IsAny<int>())).Returns(course);

            var courseController = new CoursesController(
                database.Object,
                new User("Ivan Ivanov", "123456", Role.Lecturer));

            var exception =
                NUnit.Framework.Assert.Catch<ArgumentException>(
                    () => { courseController.AddLecture(5, "TestLecture"); });
            Assert.AreEqual(string.Format("There is no course with ID {0}.", 5), exception.Message);
        }

        [TestMethod]
        public void AddLecture_WithValidData_ReturnAnIViewObject()
        {
            var course = new Course("Test1234");
            Assert.AreEqual(0, course.Lectures.Count);

            var database = new Mock<IBangaloreUniversityData>();
            database.Setup(a => a.Courses.Get(It.IsAny<int>())).Returns(course);

            var courseController = new CoursesController(
                database.Object,
                new User("Ivan Ivanov", "123456", Role.Lecturer));

            var result = courseController.AddLecture(5, "TestLecture");

            Assert.IsInstanceOfType(result, typeof(IView));
        }
    }
}