namespace LearningSystem.Views.Users
{
    using System.Text;

    using LearningSystem.Models;
    using LearningSystem.Views.Courses;

    public class Login : View
    {
        public Login(User user)
            : base(user)
        {
        }

        internal override void BuildViewResult(StringBuilder viewResult)
        {
            var user = this.Model as User;
            if (user != null)
            {
                viewResult.AppendFormat("User {0} logged in successfully.", user.Username).AppendLine();
            }
        }
    }
}