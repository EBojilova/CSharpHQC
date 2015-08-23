namespace LearningSystem.Utilities
{
    using System;

    using LearningSystem.Data;
    using LearningSystem.Interfaces;
    using LearningSystem.Models;

    public static class Validations
    {
        public static bool IsInRole(this User user, Role role)
        {
            return user != null && user.Role == role;
        }

        public static void ValidateArgumentLenght(string argument, string argumentName, int minLenght)
        {
            if (argument == null || argument.Length < minLenght)
            {
                throw new ArgumentException($"The {argumentName} must be at least {minLenght} symbols long.");
            }
        }

        public static Course ValidateCourseId(IBangaloreUniversityDate data, int courseId)
        {
            var course = data.Courses.Get(courseId);
            if (course == null)
            {
                throw new ArgumentException($"There is no course with ID {courseId}.");
            }

            return course;
        }

        public static void ValidateLectureRole(User user)
        {
            if (!user.IsInRole(Role.Lecturer))
            {
                throw new ArgumentException("The current user is not authorized to perform this operation.");
            }
        }

        public static void ValidateRoles(User user)
        {
            if (!user.IsInRole(Role.Student) && !user.IsInRole(Role.Lecturer))
            {
                throw new ArgumentException("The current user is not authorized to perform this operation.");
            }
        }

        public static void CheckForCurrentUser(bool hasCurrentUser)
        {
            if (!hasCurrentUser)
            {
                throw new ArgumentException("There is no currently logged in user.");
            }
        }

        public static void ValidateEnrollingStudent(User user, Course course)
        {
            if (user.Courses.Contains(course))
            {
                throw new ArgumentException("You are already enrolled in this course.");
            }
        }

        public static void ValidateNotEnrolledStudent(User user, Course course)
        {
            if (!user.Courses.Contains(course))
            {
                throw new ArgumentException("You are not enrolled in this course.");
            }
        }

        public static void EnsureNoLoggedInUser(bool hasCurrentUser)
        {
            if (hasCurrentUser)
            {
                throw new ArgumentException("There is already a logged in user.");
            }
        }

        public static void CheckPasswordsMatch(string password, string confirmPassword)
        {
            if (password != confirmPassword)
            {
                throw new ArgumentException("The provided passwords do not match.");
            }
        }

        public static User EnsureUserIsRegistered(UsersRepository repository, string username)
        {
            if (!repository.UserName_User.ContainsKey(username))
            {
                throw new ArgumentException($"A user with username {username} does not exist.");
            }

            return repository.UserName_User[username];
        }

        public static void EnsureUserIsNotRgistered(UsersRepository repository, string username)
        {
            if (repository.UserName_User.ContainsKey(username))
            {
                throw new ArgumentException($"A user with username {username} already exists.");
            }
        }

        public static void ChecksForPasswordHashMatch(string passwordToCheck, string existingPassword)
        {
            if (existingPassword != HashUtilities.HashPassword(passwordToCheck))
            {
                throw new ArgumentException("The provided password is wrong.");
            }
        }
    }
}