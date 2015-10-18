namespace LearningSystem.Interfaces
{
    using LearningSystem.Data;
    using LearningSystem.Models;

    public interface IBangaloreUniversityDate
    {
        UsersRepository Users { get; }

        IRepository<Course> Courses { get; }
    }
}