// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IRepository.cs" company="Katya">
//   Katya.com. All rights reserved.
// </copyright>
// // <summary>
//   The Repository interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace BULS.Interfaces
{
    using System.Collections.Generic;

    /// <summary>
    /// The Repository interface.
    /// </summary>
    /// <typeparam name="T">
    /// </typeparam>
    public interface IRepository<T>
    {
        /// <summary>
        /// The get all elements of the particular repository.
        /// </summary>
        /// <returns>
        /// The <see cref="IEnumerable"/>.
        /// </returns>
        IEnumerable<T> GetAll();

        /// <summary>
        /// The Get method - gets an item of the repository by Id.
        /// </summary>
        /// <param name="id">
        /// The item id.
        /// </param>
        /// <returns>
        /// The <see cref="T"/> item.
        /// </returns>
        T Get(int id);

        /// <summary>
        /// The add method - adds an item to the repository.
        /// </summary>
        /// <param name="item">
        /// The item.
        /// </param>
        void Add(T item);
    }
}