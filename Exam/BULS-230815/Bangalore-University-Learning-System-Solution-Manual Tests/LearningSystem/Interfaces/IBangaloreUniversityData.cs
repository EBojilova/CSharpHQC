namespace LearningSystem.Interfaces
{
    using LearningSystem.Data;
    using LearningSystem.Models;

    public interface IBangaloreUniversityData
    {
        UsersRepository Users { get; }

        IRepository<Course> Courses { get; }
    }
}