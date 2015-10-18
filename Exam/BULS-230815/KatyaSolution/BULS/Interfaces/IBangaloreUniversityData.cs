namespace BULS.Interfaces
{
    using BULS.Data;
    using BULS.Models;

    public interface IBangaloreUniversityData
    {
        UsersRepository Users { get; }

        IRepository<Course> Courses { get; }
    }
}