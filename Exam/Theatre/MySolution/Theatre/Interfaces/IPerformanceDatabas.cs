// Do not modify the interface members
// Moving the interface to separate namespace is allowed
// Adding XML documentation is allowed
// TODO: document this interface definition

namespace Theatre.Interfaces
{
    using System;
    using System.Collections.Generic;

    using Theatre.Exeptions;

    /// <summary>
    /// Provides the basic operations required to run a performance database of theatres. 
    /// Each of them has a name and a timetable that holds all performances, their start date and time, 
    /// their duration and ticket price.
    /// </summary>
    public interface IPerformanceDatabase
    {
        /// <summary>
        /// Adds a theatre by given theatre name. The theatre name is unique among all theatres.
        /// </summary>
        /// <param name="theatreName">The name of the theatre.</param>
        /// <exception cref="DuplicateTheatreException">Thrown in case of duplicate theatre. 
        /// Holds a "Duplicate theatre" as error message.</exception>
        void AddTheatre(string theatreName);

        /// <summary>
        /// Lists all theatres in the performance database.
        /// </summary>
        /// <returns>Returns sequence of the theater's names, orderd alpabetically.</returns>
        IEnumerable<string> ListTheatres();

        /// <summary>
        /// Adds a performance to the database.
        /// </summary>
        /// <param name="theatreName">Name of the theater, where the performance will be added.</param>
        /// <param name="performanceTitle">The name of the performance.</param>
        /// <param name="startDateTime">Date and start time of the performance.</param>
        /// <param name="duration">Duration of the performance.</param>
        /// <param name="price">Price of the ticket.</param>
        /// <exception cref="TheatreNotFoundException">Thrown if name of the theatre does not exist in the database. 
        /// Holds a "Theatre does not exist" as error message.</exception>
        /// <exception cref="TimeDurationOverlapException">Thrown if there is ovelaping of the start and finish time
        /// between the perfomance we would like to add and any of the other perfomances in the theatre. 
        /// Holds a "Time/duration overlap" as error message.</exception>
        void AddPerformance(
            string theatreName,
            string performanceTitle,
            DateTime startDateTime,
            TimeSpan duration,
            decimal price);

        /// <summary>
        /// Lists all perfomances in the database.
        /// </summary>
        /// <returns>Returns sequence of all performances.</returns>
        IEnumerable<Performance> ListAllPerformances();

        /// <summary>
        /// Lists all perfomances per a requested theatre.
        /// </summary>
        /// <param name="theatreName"></param>
        /// <returns>Returns sequence of all performances per the requested theatre.</returns>
        IEnumerable<Performance> ListPerformances(string theatreName);
    }
}