namespace Students
{
    using System;

    internal class StudentsMain
    {
        private static void Main()
        {
            var peter = new Student("Peter", "Ivanov", "17.03.1992", "From Sofia");

            var stella = new Student("Stella", "Markova", "03.11.1993", "From Vidin, gamer, high results");

            Console.WriteLine("{0} older than {1} -> {2}", peter.FirstName, stella.FirstName, peter.IsOlderThan(stella));
        }
    }
}