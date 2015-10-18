namespace BangaloreUniversityLearningSystem.Data
{
    using BangaloreUniversityLearningSystem.Contracts;
    using BangaloreUniversityLearningSystem.Models;

    public class BangaloreUniversityDate : IBangaloreUniversityDate
    {
        public BangaloreUniversityDate()
        {
            this.Users = new UsersRepository();
            this.Courses = new Repository<Course>();
        }

        public UsersRepository Users { get; internal set; }

        public IRepository<Course> Courses { get; protected set; }
    }
}