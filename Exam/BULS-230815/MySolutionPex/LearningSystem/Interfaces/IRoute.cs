namespace LearningSystem.Interfaces
{
    using System.Collections.Generic;

    /// <summary>
    /// Holds information for controller name, action name and action parameters.
    /// </summary>
    public interface IRoute
    {
        /// <summary>
        /// Gets the name of of the controller.
        /// </summary>
        string ControllerName { get; }

        /// <summary>
        /// Gets the name of the action to be performed.
        /// </summary>
        string ActionName { get; }

        /// <summary>
        /// Gets the action parameters.
        /// </summary>
        IDictionary<string, string> ActionParameters { get; }
    }
}