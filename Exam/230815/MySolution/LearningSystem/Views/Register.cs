namespace LearningSystem.Views
{
    using System.Text;

    using LearningSystem.Models;

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