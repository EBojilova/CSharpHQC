namespace DependencyInjectionVideo
{
    internal class DependencyInjectionMain
    {
        private static void Main(string[] args)
        {
            var studentSorter = DependencyContainer.GetStudentsSorter();
            studentSorter.OrderStudentsByFirstName();
        }
    }
}