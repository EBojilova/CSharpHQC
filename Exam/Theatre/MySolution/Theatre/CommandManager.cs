namespace Theatre
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;

    using Theatre.Interfaces;

    public class CommandManager
    {
        private static readonly IPerformanceDatabase Universal = new PerformanceDatabase();

        public string CommandExecute(string data)
        {
            var commands = data.Split(new[] { '(', ',', ')' }, StringSplitOptions.RemoveEmptyEntries);
            var command = commands[0].Trim();
            var commandParameters = commands.Skip(1).Select(performance => performance.Trim()).ToArray();

            string output;

            switch (command)
            {
                case "AddTheatre":
                    output = ExecuteAddTheatreCommand(commandParameters);
                    break;
                case "PrintAllTheatres":
                    output = ExecutePrintAllTheatresCommand();
                    break;
                case "AddPerformance":
                    output = ExecuteAddPerformanceCommand(commandParameters);
                    break;
                case "PrintAllPerformances":
                    output = ExecutePrintAllPerformancesCommand();
                    break;
                case "PrintPerformances":
                    output = ExecutePrintPerformancesCommand(commandParameters);
                    break;
                default:
                    output = "Invalid command!";
                    break;
            }

            return output;
        }

        /// <summary>
        /// PrintPerformances(theatre) – prints all performances for the specified theatre in format 
        /// (performance, date-and-time), ordered by date and time, separated by comma and space, 
        /// or "No performances" in case of empty list of performances for the specified theatre. 
        /// Print “Error: Theatre does not exist” in case of non-existing theatre.
        /// </summary>
        /// <returns></returns>
        private static string ExecutePrintPerformancesCommand(IReadOnlyList<string> commandParameters)
        {
            var theatre = commandParameters[0];
            var performances = Universal.ListPerformances(theatre).Select(
                performance =>
                    {
                        var startTime = performance.StartDateTime.ToString("dd.MM.yyyy HH:mm");
                        return string.Format("({0}, {1})", performance.PerformanceTitle, startTime);
                    }).ToList();
            var output = performances.Any() ? string.Join(", ", performances) : "No performances";
            return output;
        }

        private static string ExecuteAddPerformanceCommand(IReadOnlyList<string> commandParameters)
        {
            var theatreName = commandParameters[0];
            var performanceTitle = commandParameters[1];
            var result = DateTime.ParseExact(commandParameters[2], "dd.MM.yyyy HH:mm", CultureInfo.InvariantCulture);
            var startDateTime = result;
            var result2 = TimeSpan.Parse(commandParameters[3]);
            var duration = result2;
            var result3 = decimal.Parse(commandParameters[4], NumberStyles.Float);
            var price = result3;
            Universal.AddPerformance(theatreName, performanceTitle, startDateTime, duration, price);
            const string Output = "Performance added";
            return Output;
        }

        /// <summary>
        /// PrintAllPerformances() – prints all performances in the city in format (performance, theatre, date-and-time),
        /// ordered by theatre (as first criteria) and 
        /// by date and time (as second criteria), separated by comma and space, 
        /// or "No performances" in case of empty list of performances.
        /// </summary>
        /// <returns></returns>
        private static string ExecutePrintAllPerformancesCommand()
        {
            var performances = Universal.ListAllPerformances().ToList();
            if (!performances.Any())
            {
                return "No performances";
            }

            var allPerfomancesInfo =
                performances.Select(
                    p =>
                    string.Format(
                        "({0}, {1}, {2})", 
                        p.PerformanceTitle, 
                        p.TheathreName, 
                        p.StartDateTime.ToString("dd.MM.yyyy HH:mm")));

            return string.Join(", ", allPerfomancesInfo);
        }

        private static string ExecuteAddTheatreCommand(IReadOnlyList<string> parameters)
        {
            var theatreName = parameters[0];
            Universal.AddTheatre(theatreName);
            return "Theatre added";
        }

        private static string ExecutePrintAllTheatresCommand()
        {
            var theatresCount = Universal.ListTheatres().Count();
            return theatresCount <= 0 ? "No theatres" : string.Join(", ", Universal.ListTheatres());
        }
    }
}