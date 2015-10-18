// ReSharper disable All

namespace LearningSystem.Data
{
    using System.Collections.Specialized;

    using LearningSystem.Interfaces;
    using LearningSystem.Models;

    public class BangaloreUniversityData : IBangaloreUniversityData
    {
        public BangaloreUniversityData()
        {
            this.Users = new UsersRepository();
            this.Courses = new Repository<Course>();
        }

        public UsersRepository Users { get; internal set; }

        public IRepository<Course> Courses { get; protected set; }
    }
}