namespace BangaloreUniversityLearningSystem.Contracts
{
    using BangaloreUniversityLearningSystem.Data;
    using BangaloreUniversityLearningSystem.Models;

    public interface IBangaloreUniversityDate
    {
        UsersRepository Users { get; }

        IRepository<Course> Courses { get; }
    }
}