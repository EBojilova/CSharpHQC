namespace LearningSystem.Views.Users
{
    using System.Text;

    using LearningSystem.Models;
    using LearningSystem.Views.Courses;

    public class Logout : View
    {
        public Logout(User user)
            : base(user)
        {
        }

        internal override void BuildViewResult(StringBuilder viewResult)
        {
            var user = this.Model as User;
            if (user != null)
            {
                viewResult.AppendFormat("User {0} logged out successfully.", user.Username).AppendLine();
            }
        }
    }
}