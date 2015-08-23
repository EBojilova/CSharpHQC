namespace AssertionsDemo
{
    using System;
    using System.Diagnostics;

    internal class AssertionsDemo
    {
        private static bool PerformAction()
        {
            Console.WriteLine("Action performed.");
            return true;
        }

        private static void Main()
        {
            Debug.Assert(PerformAction(), "Could not perform action");

            var calc = new StudentGradesCalculator(new[] { 6, 5, 5, 4, 6, 6, 5, 6 });
            Console.WriteLine(calc.GetAverageStudentGrade());

            calc = new StudentGradesCalculator(new int[] { });
            Console.WriteLine(calc.GetAverageStudentGrade());
        }
    }
}