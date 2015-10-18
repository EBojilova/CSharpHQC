// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IRoute.cs" company="Katya">
//   Katya.com. All rights reserved.
// </copyright>
// // <summary>
//   The Route interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace BULS.Interfaces
{
    using System.Collections.Generic;

    /// <summary>
    /// The Route interface.
    /// </summary>
    public interface IRoute
    {
        /// <summary>
        /// Gets the controller name.
        /// </summary>
        /// <value>
        /// The controller name.
        /// </value>
        string ControllerName { get; }

        /// <summary>
        /// Gets the action name.
        /// </summary>
        /// <value>
        /// The action name.
        /// </value>
        string ActionName { get; }

        /// <summary>
        /// Gets the parameters.
        /// </summary>
        /// <value>
        /// The parameters.
        /// </value>
        IDictionary<string, string> Parameters { get; }
    }
}