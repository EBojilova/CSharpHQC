namespace LearningSystem.Views.Users
{
    using System.Text;

    using LearningSystem.Models;
    using LearningSystem.Views.Courses;

    public class Register : View
    {
        public Register(User user)
            : base(user)
        {
        }

        internal override void BuildViewResult(StringBuilder viewResult)
        {
            var user = this.Model as User;
            if (user != null)
            {
                viewResult.AppendFormat("User {0} registered successfully.", user.Username).AppendLine();
            }
        }
    }
}