namespace LearningSystem.ManualTests
{
    using System.Text;

    using LearningSystem.Views;

    public class ViewMock : View
    {
        public ViewMock(object model)
            : base(model)
        {
        }

        protected override void BuildViewResult(StringBuilder viewResult)
        {
            viewResult.Append(this.Model);
        }
    }
}