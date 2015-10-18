namespace LearningSystem.Interfaces
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Provides basics operation with a repository.
    /// </summary>
    /// <typeparam name="T">Type of the members of the repository.</typeparam>
    public interface IRepository<T>
    {
        /// <summary>
        /// Shows all members in the repository.
        /// </summary>
        /// <returns>In case of success returns sequence of all members.Oterwise returns error message.</returns>
        IEnumerable<T> GetAll();

        /// <summary>
        /// Shows member in the repository by given id number of the member.
        /// </summary>
        /// <param name="id">Id of the member to be found.</param>
        /// <returns>In case of scucess returns serched member. Oterwise returns error message.</returns>
        T Get(int id);

        /// <summary>
        /// Adds a member to teh repository.
        /// </summary>
        /// <param name="item">The member to be added.</param>
        /// <exception cref="ArgumentException">If the member to be added already exist, or is not an valid member.</exception>
        void Add(T item);
    }
}